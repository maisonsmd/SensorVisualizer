using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Threading;

namespace SensorVisualizer {

	public enum ConnectionState {
		Connected,
		Disconnected
	}

	public enum EventType : UInt16 {
		Info = 0,
		Warning = 1,
		Error = 2
	};

	internal class AutoSerial {
		private String TAG = "Serial";
		private const Int32 rescanInterval = 2000;
		private const Int32 waitResponseTimeout = 1000;

		private ConnectionState currentConnectionState;
		private SerialPort serial;
		public Boolean Enabled;
		public String DeviceName;
		private Boolean IsFindingPort;
		public delegate void OnConnectionChangedHandler(String portName, ConnectionState connectionState);
		public delegate void OnDataReceivedHandler(String portName, String data);
		public delegate void OnDataSentHandler(String portName, String data);
		public delegate void OnInfoReceivedHandler(String tag, String text, EventType eventType);
		public event OnDataReceivedHandler DataReceived;
		public event OnDataSentHandler DataSent;
		public event OnInfoReceivedHandler InfoReceived;
		public event OnConnectionChangedHandler ConnectionStateChanged;

		private System.Windows.Forms.Timer rescanTimer = new System.Windows.Forms.Timer();
		private System.Windows.Forms.Timer releaseDtr = new System.Windows.Forms.Timer();

		private AutoSerial(Int32 baudrate) {
			this.serial = new SerialPort() {
				BaudRate = baudrate,
				RtsEnable = true,
				DtrEnable = false,
				ReadTimeout = 5
			};
			this.IsFindingPort = false;
			this.Enabled = false;
			this.currentConnectionState = ConnectionState.Disconnected;
			this.rescanTimer.Tick += this.RescanTimer_Tick;
			this.rescanTimer.Interval = rescanInterval;
			this.rescanTimer.Enabled = true;

			this.releaseDtr.Tick += this.ReleaseDtr_Tick;
			this.releaseDtr.Interval = 100;
			this.releaseDtr.Enabled = true;

			this.DeviceName = "";
		}

		private List<String> lastPortList = new List<String>();

		private void RescanTimer_Tick(Object sender, EventArgs e) {
			if (this.serial.IsOpen)
				return;

			//find new port
			/*List<String> newPortList = new List<String>(SerialPort.GetPortNames());

            List<String> newPluggedPorts = newPortList.Except(this.lastPortList).ToList();

            if (newPluggedPorts.Any()) {
                String names = "";
                foreach (String p in newPluggedPorts)
                    names += p + " ";

                this.PrintInfo($"new plugged ports: [ {names}]");

                if (this.Enabled)
                    this.FindPort();
            }*/

			if (this.Enabled)
				this.FindPort();

			//this.lastPortList = newPortList;
		}

		private static AutoSerial Instance = null;

		public static AutoSerial GetInstance(Int32 baudrate) {
			if (Instance != null)
				return Instance;
			Instance = new AutoSerial(9600);
			return Instance;
		}

		private ConnectionState CurrentConnectionState {
			get => this.currentConnectionState;
			set {
				if (value != this.currentConnectionState) {
					this.currentConnectionState = value;
					ConnectionStateChanged?.BeginInvoke(this.serial.PortName, this.currentConnectionState, this.ConnectionStateChangedInvokeCallback, null);
				}
			}
		}

		private void PrintInfo(String format, params Object[] args) => InfoReceived?.BeginInvoke(this.TAG, String.Format(format, args), EventType.Info, this.InfoReceivedInvokeCallback, null);

		private void PrintWarning(String format, params Object[] args) => InfoReceived?.BeginInvoke(this.TAG, String.Format(format, args), EventType.Warning, this.InfoReceivedInvokeCallback, null);

		private void PrintError(String format, params Object[] args) => InfoReceived?.BeginInvoke(this.TAG, String.Format(format, args), EventType.Error, this.InfoReceivedInvokeCallback, null);

		private void WriteRaw(SerialPort port, String data) {
			if (!port.IsOpen)
				return;
			try {
				port.WriteLine(data);
				DataSent?.BeginInvoke(port.PortName, data, this.DataSentInvokeCallback, null);
			}
			catch (Exception exception) {
				this.PrintError(exception.ToString());
				port.Close();
				this.PrintInfo($"{port.PortName} closed!");
			}
		}

		public Boolean IsOpen => this.serial.IsOpen;

		public Boolean FindPort() {
			if (this.serial.IsOpen) {
				this.PrintError("close existing port first!");
				return false;
			}
			if (this.IsFindingPort) {
				this.PrintWarning("requested to find ports, but busy!");
				return false;
			}
			this.IsFindingPort = true;

			String[] portNames = SerialPort.GetPortNames();

			if (portNames.Length == 0) {
				this.PrintInfo("no available port");
				this.IsFindingPort = false;
				return false;
			}

			String names = "";
			foreach (String p in portNames)
				names += p + " ";

			this.PrintInfo($"available ports: [ {names}]");

			Int32 totalWorks = portNames.Length;
			Int32 completedWorks = 0;
			Boolean isValidPortFound = false;

			foreach (String portName in portNames) {
				SerialPort currentPort = new SerialPort {
					BaudRate = this.serial.BaudRate,
					DtrEnable = this.serial.DtrEnable,
					ReadTimeout = 5,
					PortName = portName
				};

				BackgroundWorker backgroundWorker = new BackgroundWorker();
				backgroundWorker.DoWork += new DoWorkEventHandler(delegate (Object o, DoWorkEventArgs e) {
					e.Result = this.TryOpen(currentPort);
				});

				backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
					delegate (Object o, RunWorkerCompletedEventArgs e) {
						completedWorks++;

						if ((Boolean)e.Result == true) {
							this.serial = currentPort;
							isValidPortFound = true;
						}

						if (completedWorks != totalWorks)
							return;

						this.IsFindingPort = false;

						if (isValidPortFound) {
							this.CurrentConnectionState = ConnectionState.Connected;
							this.serial.DataReceived += this.Serial_DataReceived;
						}
						else {
							this.PrintWarning("no valid port found!");
						}
					});
				backgroundWorker.RunWorkerAsync();
			}
			return true;
		}

		/// <summary>
		/// try opening and validating a port
		/// </summary>
		/// <param name="port">the port to try</param>
		/// <returns>if the port is valid</returns>
		private Boolean TryOpen(SerialPort port) {
			//this.PrintInfo($"establishing connection to: \"{port.PortName}\"");
			try {
				port.Open();
				//force reset
				port.DtrEnable = true;
			}
			catch {
				this.PrintWarning($"cannot open \"{port.PortName}\"");
				return false;
			}
			Thread.Sleep(50);
			port.DtrEnable = false;
			//arduino AVR usually resets in 2s when COM port opened, STM USBSerial doesn't
			UInt64 startMillis = TimeCounter.Millis();
			Thread.Sleep(200);

			this.WriteRaw(port, "chkcon?");

			startMillis = TimeCounter.Millis();
			while (TimeCounter.Millis() - startMillis < waitResponseTimeout) {
				if (port.BytesToRead != 0)
					break;
			}

			//wait for the rest of data
			Thread.Sleep(10);
			if (port.BytesToRead == 0) {
				this.PrintWarning($"{port.PortName} not responding");
				port.Close();
				return false;
			}

			String indata = port.ReadExisting();
			indata = indata.Replace("\n", "");

			if (!indata.Contains("!name=")) {
				this.PrintWarning($"\"{port.PortName}\": invalid response (\"{indata}\")");
				port.Close();
				return false;
			}
			String deviceName = indata.Substring2Indexes(indata.IndexOf("name=") + 5, indata.IndexOf(";"));
			this.DeviceName = deviceName;

			this.PrintInfo($"\"{port.PortName}\" (Name=\"{deviceName}\") is valid!");
			return true;
		}

		public Boolean Close() {
			this.Enabled = false;
			this.CurrentConnectionState = ConnectionState.Disconnected;
			try {
				if (this.serial.IsOpen) {
					this.serial.Close();
					this.PrintInfo($"\"{this.serial.PortName}\" closed!");
				}
				else {
					this.PrintWarning($"\"{this.serial.PortName}\" is not opened yet!");
					return true;
				}
			}
			catch (Exception exception) { this.PrintError(exception.ToString()); return false; }
			return true;
		}

		public Boolean Open() {
			this.Enabled = true;
			try {
				if (!this.serial.IsOpen) {
					this.serial.Open();
					this.PrintInfo($"{this.serial.PortName} opened successfully!");
					this.CurrentConnectionState = ConnectionState.Connected;
				}
				else
					this.PrintWarning($"{this.serial.PortName} is already opened or not valid!");
			}
			catch (Exception exception) {
				this.CurrentConnectionState = ConnectionState.Disconnected;
				this.PrintError(exception.ToString());
				return false;
			}
			return true;
		}

		private void Serial_DataReceived(Object sender, SerialDataReceivedEventArgs e) {
			if (this.serial.BytesToRead < 1) {
				return;
			}
			try {
				String indata = this.serial.ReadTo("\n");
				DataReceived?.BeginInvoke(this.serial.PortName, indata, this.DataReceivedInvokeCallback, null);
			}
			catch {
				this.PrintError("read timeout!");
			}
		}

		private void InfoReceivedInvokeCallback(IAsyncResult ar) {
			try {
				InfoReceived?.EndInvoke(ar);
			}
			catch {
				//err detail: "can not access disposed object: FrmMain"
			}
		}

		private void DataReceivedInvokeCallback(IAsyncResult ar) {
			try {
				DataReceived?.EndInvoke(ar);
			}
			catch { }
		}

		private void DataSentInvokeCallback(IAsyncResult ar) {
			try {
				DataSent?.EndInvoke(ar);
			}
			catch { }
		}

		private void ConnectionStateChangedInvokeCallback(IAsyncResult ar) {
			try {
				ConnectionStateChanged?.EndInvoke(ar);
			}
			catch { }
		}

		public Boolean Write(String data) {
			if (!this.serial.IsOpen)
				return false;
			this.serial.Write(data);
			return true;
		}

		public void ResetDevice() {
			this.serial.DtrEnable = true;
			this.releaseDtr.Start();
		}

		private void ReleaseDtr_Tick(Object sender, EventArgs e) {
			this.serial.DtrEnable = false;
			this.releaseDtr.Stop();
		}
	}
}