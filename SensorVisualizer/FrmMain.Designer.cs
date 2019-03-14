namespace SensorVisualizer {     partial class FrmMain     {         /// <summary>         /// Required designer variable.         /// </summary>         private System.ComponentModel.IContainer components = null;          /// <summary>         /// Clean up any resources being used.         /// </summary>         /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>         protected override void Dispose(bool disposing)         {             if (disposing && (components != null))             {                 components.Dispose();             }             base.Dispose(disposing);         }          #region Windows Form Designer generated code          /// <summary>         /// Required method for Designer support - do not modify         /// the contents of this method with the code editor.         /// </summary>         private void InitializeComponent()         {			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.Graph = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblCurrentPort = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.BtnEnable = new MaterialSkin.Controls.MaterialRaisedButton();
			this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
			this.txtOffset = new MaterialSkin.Controls.MaterialSingleLineTextField();
			this.txtScale = new MaterialSkin.Controls.MaterialSingleLineTextField();
			this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
			this.BtnReset = new MaterialSkin.Controls.MaterialFlatButton();
			this.ChkLM35 = new MaterialSkin.Controls.MaterialRadioButton();
			this.chkHX711 = new MaterialSkin.Controls.MaterialRadioButton();
			this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
			this.txtInterval = new MaterialSkin.Controls.MaterialSingleLineTextField();
			this.BtnClear = new MaterialSkin.Controls.MaterialFlatButton();
			this.lblValue = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.Graph)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// Graph
			// 
			this.Graph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			chartArea3.AxisX.LabelStyle.Format = "0.00";
			chartArea3.AxisX.Minimum = 0D;
			chartArea3.AxisX.Title = "time (s)";
			chartArea3.AxisX.TitleFont = new System.Drawing.Font("Segoe UI", 10F);
			chartArea3.AxisY.LabelStyle.Format = "0.00";
			chartArea3.AxisY.Title = "sensor value";
			chartArea3.AxisY.TitleFont = new System.Drawing.Font("Segoe UI", 10F);
			chartArea3.CursorX.Interval = 0.1D;
			chartArea3.CursorX.IsUserEnabled = true;
			chartArea3.CursorX.IsUserSelectionEnabled = true;
			chartArea3.CursorX.LineColor = System.Drawing.Color.DodgerBlue;
			chartArea3.CursorX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
			chartArea3.CursorX.LineWidth = 2;
			chartArea3.Name = "ChartArea1";
			this.Graph.ChartAreas.Add(chartArea3);
			this.Graph.Cursor = System.Windows.Forms.Cursors.Default;
			legend3.Enabled = false;
			legend3.Name = "Legend1";
			this.Graph.Legends.Add(legend3);
			this.Graph.Location = new System.Drawing.Point(6, 134);
			this.Graph.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.Graph.Name = "Graph";
			series3.BorderWidth = 2;
			series3.ChartArea = "ChartArea1";
			series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series3.Color = System.Drawing.Color.Red;
			series3.Legend = "Legend1";
			series3.Name = "Series1";
			series3.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			series3.ToolTip = "#VALY{0.00}";
			this.Graph.Series.Add(series3);
			this.Graph.Size = new System.Drawing.Size(1064, 425);
			this.Graph.TabIndex = 4;
			this.Graph.Text = "chart1";
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BackColor = System.Drawing.Color.Transparent;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.lblCurrentPort);
			this.panel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panel1.Location = new System.Drawing.Point(4, 610);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1066, 26);
			this.panel1.TabIndex = 5;
			// 
			// lblCurrentPort
			// 
			this.lblCurrentPort.AutoSize = true;
			this.lblCurrentPort.Location = new System.Drawing.Point(2, 1);
			this.lblCurrentPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblCurrentPort.Name = "lblCurrentPort";
			this.lblCurrentPort.Size = new System.Drawing.Size(42, 20);
			this.lblCurrentPort.TabIndex = 0;
			this.lblCurrentPort.Text = "none";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(142, 55);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(0, 24);
			this.label3.TabIndex = 11;
			// 
			// BtnEnable
			// 
			this.BtnEnable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnEnable.AutoSize = true;
			this.BtnEnable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BtnEnable.Depth = 0;
			this.BtnEnable.Icon = null;
			this.BtnEnable.Location = new System.Drawing.Point(129, 572);
			this.BtnEnable.MouseState = MaterialSkin.MouseState.HOVER;
			this.BtnEnable.Name = "BtnEnable";
			this.BtnEnable.Primary = true;
			this.BtnEnable.Size = new System.Drawing.Size(74, 36);
			this.BtnEnable.TabIndex = 12;
			this.BtnEnable.Text = "Close";
			this.BtnEnable.UseVisualStyleBackColor = true;
			this.BtnEnable.Click += new System.EventHandler(this.BtnEnable_Click);
			// 
			// materialLabel1
			// 
			this.materialLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.materialLabel1.AutoSize = true;
			this.materialLabel1.Depth = 0;
			this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
			this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.materialLabel1.Location = new System.Drawing.Point(512, 572);
			this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialLabel1.Name = "materialLabel1";
			this.materialLabel1.Size = new System.Drawing.Size(61, 24);
			this.materialLabel1.TabIndex = 14;
			this.materialLabel1.Text = "offset";
			// 
			// txtOffset
			// 
			this.txtOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOffset.Depth = 0;
			this.txtOffset.Hint = "";
			this.txtOffset.Location = new System.Drawing.Point(579, 572);
			this.txtOffset.MaxLength = 32767;
			this.txtOffset.MouseState = MaterialSkin.MouseState.HOVER;
			this.txtOffset.Name = "txtOffset";
			this.txtOffset.PasswordChar = '\0';
			this.txtOffset.SelectedText = "";
			this.txtOffset.SelectionLength = 0;
			this.txtOffset.SelectionStart = 0;
			this.txtOffset.Size = new System.Drawing.Size(94, 28);
			this.txtOffset.TabIndex = 15;
			this.txtOffset.TabStop = false;
			this.txtOffset.Text = "0";
			this.txtOffset.UseSystemPasswordChar = false;
			this.txtOffset.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtOffset_KeyDown);
			// 
			// txtScale
			// 
			this.txtScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtScale.Depth = 0;
			this.txtScale.Hint = "";
			this.txtScale.Location = new System.Drawing.Point(749, 572);
			this.txtScale.MaxLength = 32767;
			this.txtScale.MouseState = MaterialSkin.MouseState.HOVER;
			this.txtScale.Name = "txtScale";
			this.txtScale.PasswordChar = '\0';
			this.txtScale.SelectedText = "";
			this.txtScale.SelectionLength = 0;
			this.txtScale.SelectionStart = 0;
			this.txtScale.Size = new System.Drawing.Size(108, 28);
			this.txtScale.TabIndex = 17;
			this.txtScale.TabStop = false;
			this.txtScale.Text = "0";
			this.txtScale.UseSystemPasswordChar = false;
			this.txtScale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtScale_KeyDown);
			// 
			// materialLabel2
			// 
			this.materialLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.materialLabel2.AutoSize = true;
			this.materialLabel2.Depth = 0;
			this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
			this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.materialLabel2.Location = new System.Drawing.Point(688, 572);
			this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialLabel2.Name = "materialLabel2";
			this.materialLabel2.Size = new System.Drawing.Size(55, 24);
			this.materialLabel2.TabIndex = 16;
			this.materialLabel2.Text = "scale";
			// 
			// BtnReset
			// 
			this.BtnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnReset.AutoSize = true;
			this.BtnReset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BtnReset.Depth = 0;
			this.BtnReset.Icon = null;
			this.BtnReset.Location = new System.Drawing.Point(6, 572);
			this.BtnReset.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.BtnReset.MouseState = MaterialSkin.MouseState.HOVER;
			this.BtnReset.Name = "BtnReset";
			this.BtnReset.Primary = false;
			this.BtnReset.Size = new System.Drawing.Size(116, 36);
			this.BtnReset.TabIndex = 18;
			this.BtnReset.Text = "reset chip";
			this.BtnReset.UseVisualStyleBackColor = true;
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			// 
			// ChkLM35
			// 
			this.ChkLM35.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.ChkLM35.AutoSize = true;
			this.ChkLM35.Checked = true;
			this.ChkLM35.Depth = 0;
			this.ChkLM35.Font = new System.Drawing.Font("Roboto", 10F);
			this.ChkLM35.Location = new System.Drawing.Point(310, 572);
			this.ChkLM35.Margin = new System.Windows.Forms.Padding(0);
			this.ChkLM35.MouseLocation = new System.Drawing.Point(-1, -1);
			this.ChkLM35.MouseState = MaterialSkin.MouseState.HOVER;
			this.ChkLM35.Name = "ChkLM35";
			this.ChkLM35.Ripple = true;
			this.ChkLM35.Size = new System.Drawing.Size(74, 30);
			this.ChkLM35.TabIndex = 19;
			this.ChkLM35.TabStop = true;
			this.ChkLM35.Text = "LM35";
			this.ChkLM35.UseVisualStyleBackColor = true;
			this.ChkLM35.CheckedChanged += new System.EventHandler(this.ChkLM35_CheckedChanged);
			// 
			// chkHX711
			// 
			this.chkHX711.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.chkHX711.AutoSize = true;
			this.chkHX711.Depth = 0;
			this.chkHX711.Font = new System.Drawing.Font("Roboto", 10F);
			this.chkHX711.Location = new System.Drawing.Point(395, 572);
			this.chkHX711.Margin = new System.Windows.Forms.Padding(0);
			this.chkHX711.MouseLocation = new System.Drawing.Point(-1, -1);
			this.chkHX711.MouseState = MaterialSkin.MouseState.HOVER;
			this.chkHX711.Name = "chkHX711";
			this.chkHX711.Ripple = true;
			this.chkHX711.Size = new System.Drawing.Size(82, 30);
			this.chkHX711.TabIndex = 20;
			this.chkHX711.Text = "HX711";
			this.chkHX711.UseVisualStyleBackColor = true;
			// 
			// materialLabel3
			// 
			this.materialLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.materialLabel3.AutoSize = true;
			this.materialLabel3.Depth = 0;
			this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
			this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.materialLabel3.Location = new System.Drawing.Point(870, 572);
			this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialLabel3.Name = "materialLabel3";
			this.materialLabel3.Size = new System.Drawing.Size(111, 24);
			this.materialLabel3.TabIndex = 16;
			this.materialLabel3.Text = "interval(ms)";
			// 
			// txtInterval
			// 
			this.txtInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtInterval.Depth = 0;
			this.txtInterval.Hint = "";
			this.txtInterval.Location = new System.Drawing.Point(987, 572);
			this.txtInterval.MaxLength = 32767;
			this.txtInterval.MouseState = MaterialSkin.MouseState.HOVER;
			this.txtInterval.Name = "txtInterval";
			this.txtInterval.PasswordChar = '\0';
			this.txtInterval.SelectedText = "";
			this.txtInterval.SelectionLength = 0;
			this.txtInterval.SelectionStart = 0;
			this.txtInterval.Size = new System.Drawing.Size(83, 28);
			this.txtInterval.TabIndex = 17;
			this.txtInterval.TabStop = false;
			this.txtInterval.Text = "0";
			this.txtInterval.UseSystemPasswordChar = false;
			this.txtInterval.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtInterval_KeyPress);
			// 
			// BtnClear
			// 
			this.BtnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnClear.AutoSize = true;
			this.BtnClear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BtnClear.Depth = 0;
			this.BtnClear.Icon = null;
			this.BtnClear.Location = new System.Drawing.Point(232, 572);
			this.BtnClear.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.BtnClear.MouseState = MaterialSkin.MouseState.HOVER;
			this.BtnClear.Name = "BtnClear";
			this.BtnClear.Primary = false;
			this.BtnClear.Size = new System.Drawing.Size(74, 36);
			this.BtnClear.TabIndex = 21;
			this.BtnClear.Text = "clear";
			this.BtnClear.UseVisualStyleBackColor = true;
			this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
			// 
			// lblValue
			// 
			this.lblValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblValue.AutoSize = true;
			this.lblValue.BackColor = System.Drawing.Color.Transparent;
			this.lblValue.Font = new System.Drawing.Font("Seven Segment", 30F);
			this.lblValue.Location = new System.Drawing.Point(12, 79);
			this.lblValue.Name = "lblValue";
			this.lblValue.Size = new System.Drawing.Size(48, 52);
			this.lblValue.TabIndex = 23;
			this.lblValue.Text = "0";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Segoe UI Light", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(253, 68);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(554, 62);
			this.label1.TabIndex = 24;
			this.label1.Text = "THỰC TẬP CÔNG NHÂN 2";
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1075, 639);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblValue);
			this.Controls.Add(this.BtnClear);
			this.Controls.Add(this.chkHX711);
			this.Controls.Add(this.ChkLM35);
			this.Controls.Add(this.BtnReset);
			this.Controls.Add(this.txtInterval);
			this.Controls.Add(this.txtScale);
			this.Controls.Add(this.materialLabel3);
			this.Controls.Add(this.materialLabel2);
			this.Controls.Add(this.txtOffset);
			this.Controls.Add(this.materialLabel1);
			this.Controls.Add(this.BtnEnable);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.Graph);
			this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.MinimumSize = new System.Drawing.Size(1075, 639);
			this.Name = "FrmMain";
			this.Text = "SensorVisualizer";
			((System.ComponentModel.ISupportInitialize)(this.Graph)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

         }          #endregion        private System.Windows.Forms.DataVisualization.Charting.Chart Graph;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCurrentPort;
		private System.Windows.Forms.Label label3;
		private MaterialSkin.Controls.MaterialRaisedButton BtnEnable;
		private MaterialSkin.Controls.MaterialLabel materialLabel1;
		private MaterialSkin.Controls.MaterialSingleLineTextField txtOffset;
		private MaterialSkin.Controls.MaterialSingleLineTextField txtScale;
		private MaterialSkin.Controls.MaterialLabel materialLabel2;
		private MaterialSkin.Controls.MaterialFlatButton BtnReset;
		private MaterialSkin.Controls.MaterialRadioButton ChkLM35;
		private MaterialSkin.Controls.MaterialRadioButton chkHX711;
		private MaterialSkin.Controls.MaterialLabel materialLabel3;
		private MaterialSkin.Controls.MaterialSingleLineTextField txtInterval;
		private MaterialSkin.Controls.MaterialFlatButton BtnClear;
		private System.Windows.Forms.Label lblValue;
		private System.Windows.Forms.Label label1;
	} }  