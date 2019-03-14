using MaterialSkin;
using MaterialSkin.Controls;

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SensorVisualizer {

	public partial class FrmMain : MaterialForm {
		private String TAG = "Main";
		private AutoSerial serial = AutoSerial.GetInstance(9600);

		private readonly MaterialSkinManager MaterialSkinManager;
		private Timer pingTimer = new Timer();

		private UInt32 interval = 500;

		private struct SensorConfig {
			public Single offset;
			public Single scale;
			public Single raw;
			public Single value;
			public String unit;
		};

		private SensorConfig LM35, HX711, selectedConfig;

		private Int32 numberOfZoom = 0;

		public FrmMain() {
			this.InitializeComponent();

			Console.SetWindowSize(50, 25);

			this.StartPosition = FormStartPosition.CenterScreen;

			this.LM35.offset = Properties.Settings.Default.LM35_Offset;
			this.LM35.scale = Properties.Settings.Default.LM35_Scale;
			this.HX711.offset = Properties.Settings.Default.HX711_Offset;
			this.HX711.scale = Properties.Settings.Default.HX711_Scale;
			this.interval = (UInt32)Properties.Settings.Default.Interval;

			this.LM35.unit = "*C";
			this.HX711.unit = "kg";

			if (this.interval < 100) {
				this.interval = 1000;
				Properties.Settings.Default.Interval = this.interval;
				Properties.Settings.Default.Save();
			}

			this.txtOffset.Text = this.LM35.offset.ToString();
			this.txtScale.Text = this.LM35.scale.ToString();

			this.MaterialSkinManager = MaterialSkinManager.Instance;
			this.MaterialSkinManager.AddFormToManage(this);
			this.MaterialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
			this.ForeColor = Color.White;
			this.MaterialSkinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green700, Primary.Green200, Accent.Red100, TextShade.WHITE);

			this.serial.ConnectionStateChanged += this.Serial_ConnectionStateChanged;
			this.serial.InfoReceived += this.PrintInfo;
			this.serial.DataReceived += this.Serial_DataReceived;

			this.serial.Enabled = true;

			this.pingTimer.Enabled = true;
			this.pingTimer.Interval = 500;
			this.pingTimer.Tick += (sender, e) => {
				if (this.serial.IsOpen)
					this.serial.Write(this.interval.ToString());
			};

			this.txtInterval.Text = this.interval.ToString();

			this.Graph.MouseWheel += (sender, e) => {
				Chart chart = (Chart)sender;
				Axis xAxis = chart.ChartAreas[0].AxisX;

				Double xMin = xAxis.ScaleView.ViewMinimum;
				Double xMax = xAxis.ScaleView.ViewMaximum;

				Int32 IntervalX = 3;
				try {
					if (e.Delta < 0 && this.numberOfZoom > 0) // Scrolled down.
					{
						Double posXStart = xAxis.PixelPositionToValue(e.Location.X) - IntervalX * 2 / Math.Pow(2, this.numberOfZoom);
						Double posXFinish = xAxis.PixelPositionToValue(e.Location.X) + IntervalX * 2 / Math.Pow(2, this.numberOfZoom);

						if (posXStart < 0)
							posXStart = 0;
						if (posXFinish > xAxis.Maximum)
							posXFinish = xAxis.Maximum;
						xAxis.ScaleView.Zoom(posXStart, posXFinish);
						this.numberOfZoom--;
					}
					else if (e.Delta < 0 && this.numberOfZoom == 0) { //Last scrolled dowm
						xAxis.ScaleView.ZoomReset();
					}
					else if (e.Delta > 0) // Scrolled up.
					{
						Double posXStart = xAxis.PixelPositionToValue(e.Location.X) - IntervalX / Math.Pow(2, this.numberOfZoom);
						Double posXFinish = xAxis.PixelPositionToValue(e.Location.X) + IntervalX / Math.Pow(2, this.numberOfZoom);

						xAxis.ScaleView.Zoom(posXStart, posXFinish);
						this.numberOfZoom++;
					}

					if (this.numberOfZoom < 0)
						this.numberOfZoom = 0;
				}
				catch { }
			};

			this.selectedConfig = this.LM35;
		}

		private Single lastTimeSeconds = 0;

		private void Serial_DataReceived(String portName, String data) {
			data = data.Replace("\n", "");
			this.PrintInfo(this.TAG, data, EventType.Info);

			if (!data.Contains(","))
				return;

			String tempStr = data.Substring2Indexes(0, data.IndexOf(','));
			String tempStr1 = data.Substring2Indexes(data.IndexOf(',') + 1, data.Length);

			Single.TryParse(tempStr, out this.LM35.raw);
			Single.TryParse(tempStr1, out this.HX711.raw);

			this.LM35.value = (this.LM35.raw - this.LM35.offset) / this.LM35.scale;
			this.HX711.value = (this.HX711.raw - this.HX711.offset) / this.HX711.scale;

			this.selectedConfig = this.ChkLM35.Checked ? this.LM35 : this.HX711;

			this.lblValue.Invoke((MethodInvoker)(() =>
				this.lblValue.Text = this.selectedConfig.value.ToString("0.00") + " " + this.selectedConfig.unit));
			this.Graph.Invoke((MethodInvoker)(() =>
				this.Graph.Series[0].Points.AddXY(this.lastTimeSeconds, this.selectedConfig.value)));
			this.lastTimeSeconds += this.interval / 1000.0f;
		}

		private void PrintInfo(String tag, String text, EventType eventType) {
			switch (eventType) {
				case EventType.Error:
					Console.BackgroundColor = ConsoleColor.Red;
					Console.ForegroundColor = ConsoleColor.White;
					break;

				case EventType.Info:
					Console.BackgroundColor = ConsoleColor.Black;
					Console.ForegroundColor = ConsoleColor.Green;
					break;

				case EventType.Warning:
					Console.BackgroundColor = ConsoleColor.Black;
					Console.ForegroundColor = ConsoleColor.Yellow;
					break;
			}
			Console.WriteLine($"[{tag}] {text}");

			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.White;
		}

		private void Serial_ConnectionStateChanged(String portName, ConnectionState connectionState) {
			this.PrintInfo(this.TAG, $"{portName}: {connectionState.ToString()}", EventType.Info);

			if (connectionState == ConnectionState.Connected) {
				this.lblCurrentPort.Invoke((MethodInvoker)(() =>
					this.lblCurrentPort.Text = String.Format($"{this.serial.DeviceName} ({portName}, 9600, 8N1)")));
				this.BtnEnable.Invoke((MethodInvoker)(() => {
					this.BtnEnable.Text = "Close";
					this.BtnEnable.Enabled = true;
					this.BtnEnable.BackColor = Color.DarkGray;
				}));
				this.BtnReset.Invoke((MethodInvoker)(() => this.BtnReset.Enabled = true));
			}
			else {
				this.lblCurrentPort.Invoke((MethodInvoker)(() => this.lblCurrentPort.Text = "Port not opened"));
				this.BtnEnable.Invoke((MethodInvoker)(() => {
					this.BtnEnable.Text = "Find";
					this.BtnEnable.Enabled = true;
				}));
				this.BtnReset.Invoke((MethodInvoker)(() => this.BtnReset.Enabled = false));
			}
		}

		private void BtnEnable_Click(Object sender, EventArgs e) {
			if (this.serial.Enabled) {
				this.serial.Close();
				this.BtnEnable.Text = "Find";
			}
			else {
				this.serial.Enabled = true;
				this.BtnEnable.Enabled = false;
				this.serial.FindPort();
			}
		}

		private void BtnReset_Click(Object sender, EventArgs e) => this.serial.ResetDevice();

		private void TxtInterval_KeyPress(Object sender, KeyEventArgs e) {
			if (e.KeyData == Keys.Enter) {
				if (!UInt32.TryParse(this.txtInterval.Text, out UInt32 newValue)) {
					MessageBox.Show("Invalid data!");
					return;
				}
				if (newValue < 100)
					newValue = 100;

				Properties.Settings.Default.Interval = newValue;
				Properties.Settings.Default.Save();

				this.interval = newValue;
				this.txtInterval.Text = newValue.ToString();
			}
		}

		private void TxtOffset_KeyDown(Object sender, KeyEventArgs e) {
			if (e.KeyData == Keys.Enter) {
				if (!Single.TryParse(this.txtOffset.Text, out Single newValue)) {
					MessageBox.Show("Invalid data!");
					this.txtOffset.Text = (this.ChkLM35.Checked ? this.LM35.offset : this.HX711.offset).ToString();
					return;
				}

				if (this.ChkLM35.Checked) {
					this.LM35.offset = newValue;
					Properties.Settings.Default.LM35_Offset = this.LM35.offset;
				}
				else {
					this.HX711.offset = newValue;
					Properties.Settings.Default.HX711_Offset = this.HX711.offset;
				}
				Properties.Settings.Default.Save();
				this.selectedConfig = this.ChkLM35.Checked ? this.LM35 : this.HX711;

				this.txtOffset.Text = newValue.ToString();
			}
		}

		private void ChkLM35_CheckedChanged(Object sender, EventArgs e) {
			if (this.ChkLM35.Checked) {
				this.selectedConfig = this.LM35;
				this.txtOffset.Text = this.LM35.offset.ToString();
				this.txtScale.Text = this.LM35.scale.ToString();
			}
			else {
				this.selectedConfig = this.HX711;
				this.txtOffset.Text = this.HX711.offset.ToString();
				this.txtScale.Text = this.HX711.scale.ToString();
			}
			this.Graph.Series[0].Points.Clear();
			this.lastTimeSeconds = 0;
		}

		private void BtnClear_Click(Object sender, EventArgs e) {
			this.Graph.Series[0].Points.Clear();
			this.lastTimeSeconds = 0;
		}

		private void TxtScale_KeyDown(Object sender, KeyEventArgs e) {
			if (e.KeyData == Keys.Enter) {
				if (!Single.TryParse(this.txtScale.Text, out Single newValue)) {
					MessageBox.Show("Invalid data!");
					this.txtOffset.Text = (this.ChkLM35.Checked ? this.LM35.scale : this.HX711.scale).ToString();
					return;
				}

				if (this.ChkLM35.Checked) {
					this.LM35.scale = newValue;
					Properties.Settings.Default.LM35_Scale = this.LM35.scale;
				}
				else {
					this.HX711.scale = newValue;
					Properties.Settings.Default.HX711_Scale = this.HX711.scale;
				}

				Properties.Settings.Default.Save();

				this.selectedConfig = this.ChkLM35.Checked ? this.LM35 : this.HX711;

				this.txtScale.Text = newValue.ToString();
			}
		}
	}
}