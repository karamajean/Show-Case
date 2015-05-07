namespace C303_Produce
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMacAddress = new System.Windows.Forms.Label();
            this.lblSerialNumber = new System.Windows.Forms.Label();
            this.lblTestResult = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comPort1 = new System.IO.Ports.SerialPort(this.components);
            this.comPort2 = new System.IO.Ports.SerialPort(this.components);
            this.comPort3 = new System.IO.Ports.SerialPort(this.components);
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.btnReset = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnYellowPass = new System.Windows.Forms.RadioButton();
            this.btnYellowFail = new System.Windows.Forms.RadioButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGreenFail = new System.Windows.Forms.RadioButton();
            this.btnGreenPass = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.tbxBarcode = new System.Windows.Forms.TextBox();
            this.tabEZRP = new System.Windows.Forms.TabPage();
            this.btnWriteInvalid = new System.Windows.Forms.Button();
            this.btnIdentify = new System.Windows.Forms.Button();
            this.btnWrite = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rdbICB = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.rdbC303 = new System.Windows.Forms.RadioButton();
            this.rdbEZRP = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnLeave = new System.Windows.Forms.Button();
            this.btnJoin = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblLicenseStatus = new System.Windows.Forms.Label();
            this.lblLicenseResult = new System.Windows.Forms.Label();
            this.lblLicenseMac = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbxLicense = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPageSetting = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCloseAll = new System.Windows.Forms.Button();
            this.btnCloseCom3 = new System.Windows.Forms.Button();
            this.btnOpenCom3 = new System.Windows.Forms.Button();
            this.btnOpenAll = new System.Windows.Forms.Button();
            this.cmbEmber = new System.Windows.Forms.ComboBox();
            this.cmbRs485 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelComPort = new System.Windows.Forms.Label();
            this.cmbRs232 = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pBar = new System.Windows.Forms.ToolStripProgressBar();
            this.resetWorker = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabEZRP.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPageSetting.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(37, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "SerialNumber :";
            // 
            // lblMacAddress
            // 
            this.lblMacAddress.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblMacAddress.Font = new System.Drawing.Font("PMingLiU", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblMacAddress.ForeColor = System.Drawing.Color.Lime;
            this.lblMacAddress.Location = new System.Drawing.Point(231, 200);
            this.lblMacAddress.Name = "lblMacAddress";
            this.lblMacAddress.Size = new System.Drawing.Size(336, 42);
            this.lblMacAddress.TabIndex = 55;
            this.lblMacAddress.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblSerialNumber
            // 
            this.lblSerialNumber.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSerialNumber.Font = new System.Drawing.Font("PMingLiU", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSerialNumber.ForeColor = System.Drawing.Color.Lime;
            this.lblSerialNumber.Location = new System.Drawing.Point(231, 125);
            this.lblSerialNumber.Name = "lblSerialNumber";
            this.lblSerialNumber.Size = new System.Drawing.Size(336, 42);
            this.lblSerialNumber.TabIndex = 56;
            this.lblSerialNumber.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblTestResult
            // 
            this.lblTestResult.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTestResult.Font = new System.Drawing.Font("PMingLiU", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTestResult.ForeColor = System.Drawing.Color.Lime;
            this.lblTestResult.Location = new System.Drawing.Point(231, 268);
            this.lblTestResult.Name = "lblTestResult";
            this.lblTestResult.Size = new System.Drawing.Size(336, 42);
            this.lblTestResult.TabIndex = 57;
            this.lblTestResult.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(37, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 30);
            this.label5.TabIndex = 58;
            this.label5.Text = "Mac Address :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(37, 269);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(189, 30);
            this.label6.TabIndex = 59;
            this.label6.Text = "Zigbee Result :";
            // 
            // comPort3
            // 
            this.comPort3.BaudRate = 115200;
            this.comPort3.Handshake = System.IO.Ports.Handshake.RequestToSend;
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(115, 26);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.settingToolStripMenuItem.Text = "Setting";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageMain);
            this.tabControl1.Controls.Add(this.tabEZRP);
            this.tabControl1.Controls.Add(this.tabPageSetting);
            this.tabControl1.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(12, 28);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(643, 594);
            this.tabControl1.TabIndex = 61;
            // 
            // tabPageMain
            // 
            this.tabPageMain.Controls.Add(this.btnReset);
            this.tabPageMain.Controls.Add(this.label7);
            this.tabPageMain.Controls.Add(this.groupBox3);
            this.tabPageMain.Controls.Add(this.groupBox2);
            this.tabPageMain.Controls.Add(this.groupBox1);
            this.tabPageMain.Controls.Add(this.label2);
            this.tabPageMain.Controls.Add(this.label6);
            this.tabPageMain.Controls.Add(this.lblMacAddress);
            this.tabPageMain.Controls.Add(this.label5);
            this.tabPageMain.Controls.Add(this.lblSerialNumber);
            this.tabPageMain.Controls.Add(this.lblTestResult);
            this.tabPageMain.Location = new System.Drawing.Point(4, 30);
            this.tabPageMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageMain.Size = new System.Drawing.Size(635, 560);
            this.tabPageMain.TabIndex = 9;
            this.tabPageMain.Text = "C303";
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnReset.Checked = true;
            this.btnReset.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnReset.Location = new System.Drawing.Point(237, 339);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(92, 38);
            this.btnReset.TabIndex = 65;
            this.btnReset.TabStop = true;
            this.btnReset.Text = "Reset";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(37, 339);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 30);
            this.label7.TabIndex = 64;
            this.label7.Text = "Reset Result :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnYellowPass);
            this.groupBox3.Controls.Add(this.btnYellowFail);
            this.groupBox3.Controls.Add(this.pictureBox2);
            this.groupBox3.Location = new System.Drawing.Point(43, 484);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(525, 72);
            this.groupBox3.TabIndex = 63;
            this.groupBox3.TabStop = false;
            // 
            // btnYellowPass
            // 
            this.btnYellowPass.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnYellowPass.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnYellowPass.Location = new System.Drawing.Point(195, 24);
            this.btnYellowPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnYellowPass.Name = "btnYellowPass";
            this.btnYellowPass.Size = new System.Drawing.Size(92, 38);
            this.btnYellowPass.TabIndex = 65;
            this.btnYellowPass.TabStop = true;
            this.btnYellowPass.Text = "Pass";
            this.btnYellowPass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnYellowPass.UseVisualStyleBackColor = true;
            this.btnYellowPass.CheckedChanged += new System.EventHandler(this.btnYellowPass_CheckedChanged);
            // 
            // btnYellowFail
            // 
            this.btnYellowFail.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnYellowFail.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnYellowFail.Location = new System.Drawing.Point(352, 24);
            this.btnYellowFail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnYellowFail.Name = "btnYellowFail";
            this.btnYellowFail.Size = new System.Drawing.Size(92, 38);
            this.btnYellowFail.TabIndex = 62;
            this.btnYellowFail.TabStop = true;
            this.btnYellowFail.Text = "Fail";
            this.btnYellowFail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnYellowFail.UseVisualStyleBackColor = true;
            this.btnYellowFail.CheckedChanged += new System.EventHandler(this.btnYellowFail_CheckedChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::C303_Produce.Properties.Resources.led_Yellow;
            this.pictureBox2.Location = new System.Drawing.Point(107, 18);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 61;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGreenFail);
            this.groupBox2.Controls.Add(this.btnGreenPass);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Location = new System.Drawing.Point(43, 391);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(525, 78);
            this.groupBox2.TabIndex = 62;
            this.groupBox2.TabStop = false;
            // 
            // btnGreenFail
            // 
            this.btnGreenFail.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnGreenFail.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnGreenFail.Location = new System.Drawing.Point(352, 24);
            this.btnGreenFail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGreenFail.Name = "btnGreenFail";
            this.btnGreenFail.Size = new System.Drawing.Size(92, 38);
            this.btnGreenFail.TabIndex = 64;
            this.btnGreenFail.TabStop = true;
            this.btnGreenFail.Text = "Fail";
            this.btnGreenFail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnGreenFail.UseVisualStyleBackColor = true;
            this.btnGreenFail.CheckedChanged += new System.EventHandler(this.btnGreenFail_CheckedChanged);
            // 
            // btnGreenPass
            // 
            this.btnGreenPass.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnGreenPass.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnGreenPass.Location = new System.Drawing.Point(195, 28);
            this.btnGreenPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGreenPass.Name = "btnGreenPass";
            this.btnGreenPass.Size = new System.Drawing.Size(92, 38);
            this.btnGreenPass.TabIndex = 63;
            this.btnGreenPass.TabStop = true;
            this.btnGreenPass.Text = "Pass";
            this.btnGreenPass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnGreenPass.UseVisualStyleBackColor = true;
            this.btnGreenPass.CheckedChanged += new System.EventHandler(this.btnGreenPass_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::C303_Produce.Properties.Resources.led_Green;
            this.pictureBox1.Location = new System.Drawing.Point(107, 24);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 60;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.lblBarcode);
            this.groupBox1.Controls.Add(this.tbxBarcode);
            this.groupBox1.Location = new System.Drawing.Point(33, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(531, 108);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblBarcode.Location = new System.Drawing.Point(12, 34);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(172, 30);
            this.lblBarcode.TabIndex = 111;
            this.lblBarcode.Text = "SerialNumber";
            // 
            // tbxBarcode
            // 
            this.tbxBarcode.Location = new System.Drawing.Point(204, 34);
            this.tbxBarcode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxBarcode.Name = "tbxBarcode";
            this.tbxBarcode.Size = new System.Drawing.Size(297, 31);
            this.tbxBarcode.TabIndex = 1;
            this.tbxBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxBarcode_KeyPress);
            // 
            // tabEZRP
            // 
            this.tabEZRP.Controls.Add(this.btnWriteInvalid);
            this.tabEZRP.Controls.Add(this.btnIdentify);
            this.tabEZRP.Controls.Add(this.btnWrite);
            this.tabEZRP.Controls.Add(this.groupBox5);
            this.tabEZRP.Controls.Add(this.label10);
            this.tabEZRP.Controls.Add(this.btnRead);
            this.tabEZRP.Controls.Add(this.btnLeave);
            this.tabEZRP.Controls.Add(this.btnJoin);
            this.tabEZRP.Controls.Add(this.label11);
            this.tabEZRP.Controls.Add(this.label9);
            this.tabEZRP.Controls.Add(this.lblLicenseStatus);
            this.tabEZRP.Controls.Add(this.lblLicenseResult);
            this.tabEZRP.Controls.Add(this.lblLicenseMac);
            this.tabEZRP.Controls.Add(this.groupBox4);
            this.tabEZRP.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabEZRP.Location = new System.Drawing.Point(4, 30);
            this.tabEZRP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabEZRP.Name = "tabEZRP";
            this.tabEZRP.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabEZRP.Size = new System.Drawing.Size(635, 560);
            this.tabEZRP.TabIndex = 10;
            this.tabEZRP.Text = "Licenese";
            this.tabEZRP.UseVisualStyleBackColor = true;
            // 
            // btnWriteInvalid
            // 
            this.btnWriteInvalid.Location = new System.Drawing.Point(27, 461);
            this.btnWriteInvalid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnWriteInvalid.Name = "btnWriteInvalid";
            this.btnWriteInvalid.Size = new System.Drawing.Size(131, 34);
            this.btnWriteInvalid.TabIndex = 69;
            this.btnWriteInvalid.Text = "Write invalid";
            this.btnWriteInvalid.UseVisualStyleBackColor = true;
            this.btnWriteInvalid.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnIdentify
            // 
            this.btnIdentify.Location = new System.Drawing.Point(259, 412);
            this.btnIdentify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIdentify.Name = "btnIdentify";
            this.btnIdentify.Size = new System.Drawing.Size(87, 31);
            this.btnIdentify.TabIndex = 68;
            this.btnIdentify.Text = "Identify";
            this.btnIdentify.UseVisualStyleBackColor = true;
            this.btnIdentify.Click += new System.EventHandler(this.btnIdentify_Click);
            // 
            // btnWrite
            // 
            this.btnWrite.Font = new System.Drawing.Font("PMingLiU", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnWrite.Location = new System.Drawing.Point(27, 412);
            this.btnWrite.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(107, 34);
            this.btnWrite.TabIndex = 67;
            this.btnWrite.Text = "Write valid";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rdbICB);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.rdbC303);
            this.groupBox5.Controls.Add(this.rdbEZRP);
            this.groupBox5.Location = new System.Drawing.Point(33, 112);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(531, 71);
            this.groupBox5.TabIndex = 66;
            this.groupBox5.TabStop = false;
            // 
            // rdbICB
            // 
            this.rdbICB.AutoSize = true;
            this.rdbICB.Font = new System.Drawing.Font("PMingLiU", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rdbICB.Location = new System.Drawing.Point(447, 23);
            this.rdbICB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbICB.Name = "rdbICB";
            this.rdbICB.Size = new System.Drawing.Size(78, 32);
            this.rdbICB.TabIndex = 5;
            this.rdbICB.TabStop = true;
            this.rdbICB.Text = "ICB";
            this.rdbICB.UseVisualStyleBackColor = true;
            this.rdbICB.CheckedChanged += new System.EventHandler(this.rdbICB_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(13, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(160, 30);
            this.label12.TabIndex = 4;
            this.label12.Text = "Deviec Type";
            // 
            // rdbC303
            // 
            this.rdbC303.AutoSize = true;
            this.rdbC303.Font = new System.Drawing.Font("PMingLiU", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rdbC303.Location = new System.Drawing.Point(331, 22);
            this.rdbC303.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbC303.Name = "rdbC303";
            this.rdbC303.Size = new System.Drawing.Size(90, 32);
            this.rdbC303.TabIndex = 3;
            this.rdbC303.Text = "C303";
            this.rdbC303.UseVisualStyleBackColor = true;
            this.rdbC303.CheckedChanged += new System.EventHandler(this.rdbC303_CheckedChanged);
            // 
            // rdbEZRP
            // 
            this.rdbEZRP.AutoSize = true;
            this.rdbEZRP.Font = new System.Drawing.Font("PMingLiU", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rdbEZRP.Location = new System.Drawing.Point(204, 24);
            this.rdbEZRP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbEZRP.Name = "rdbEZRP";
            this.rdbEZRP.Size = new System.Drawing.Size(98, 32);
            this.rdbEZRP.TabIndex = 2;
            this.rdbEZRP.Text = "EZRP";
            this.rdbEZRP.UseVisualStyleBackColor = true;
            this.rdbEZRP.CheckedChanged += new System.EventHandler(this.rdbEZRP_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(45, 208);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(180, 30);
            this.label10.TabIndex = 65;
            this.label10.Text = "Mac Address :";
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(156, 412);
            this.btnRead.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(87, 31);
            this.btnRead.TabIndex = 64;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnLeave
            // 
            this.btnLeave.Location = new System.Drawing.Point(505, 412);
            this.btnLeave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLeave.Name = "btnLeave";
            this.btnLeave.Size = new System.Drawing.Size(84, 34);
            this.btnLeave.TabIndex = 63;
            this.btnLeave.Text = "Leave";
            this.btnLeave.UseVisualStyleBackColor = true;
            this.btnLeave.Click += new System.EventHandler(this.btnLeave_Click);
            // 
            // btnJoin
            // 
            this.btnJoin.Location = new System.Drawing.Point(381, 412);
            this.btnJoin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(87, 34);
            this.btnJoin.TabIndex = 62;
            this.btnJoin.Text = "Join";
            this.btnJoin.UseVisualStyleBackColor = true;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(117, 341);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 30);
            this.label11.TabIndex = 61;
            this.label11.Text = "Status :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(117, 272);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 30);
            this.label9.TabIndex = 61;
            this.label9.Text = "Result :";
            // 
            // lblLicenseStatus
            // 
            this.lblLicenseStatus.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblLicenseStatus.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblLicenseStatus.ForeColor = System.Drawing.Color.Lime;
            this.lblLicenseStatus.Location = new System.Drawing.Point(231, 329);
            this.lblLicenseStatus.Name = "lblLicenseStatus";
            this.lblLicenseStatus.Size = new System.Drawing.Size(336, 42);
            this.lblLicenseStatus.TabIndex = 60;
            this.lblLicenseStatus.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblLicenseResult
            // 
            this.lblLicenseResult.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblLicenseResult.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblLicenseResult.ForeColor = System.Drawing.Color.Lime;
            this.lblLicenseResult.Location = new System.Drawing.Point(231, 272);
            this.lblLicenseResult.Name = "lblLicenseResult";
            this.lblLicenseResult.Size = new System.Drawing.Size(336, 42);
            this.lblLicenseResult.TabIndex = 60;
            this.lblLicenseResult.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblLicenseMac
            // 
            this.lblLicenseMac.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblLicenseMac.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblLicenseMac.ForeColor = System.Drawing.Color.Lime;
            this.lblLicenseMac.Location = new System.Drawing.Point(231, 198);
            this.lblLicenseMac.Name = "lblLicenseMac";
            this.lblLicenseMac.Size = new System.Drawing.Size(336, 42);
            this.lblLicenseMac.TabIndex = 60;
            this.lblLicenseMac.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSize = true;
            this.groupBox4.Controls.Add(this.tbxLicense);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(33, 11);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(531, 108);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // tbxLicense
            // 
            this.tbxLicense.Location = new System.Drawing.Point(204, 34);
            this.tbxLicense.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxLicense.Name = "tbxLicense";
            this.tbxLicense.Size = new System.Drawing.Size(300, 31);
            this.tbxLicense.TabIndex = 1;
            this.tbxLicense.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxEZRP_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(12, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(172, 30);
            this.label8.TabIndex = 112;
            this.label8.Text = "SerialNumber";
            // 
            // tabPageSetting
            // 
            this.tabPageSetting.Controls.Add(this.label4);
            this.tabPageSetting.Controls.Add(this.btnCloseAll);
            this.tabPageSetting.Controls.Add(this.btnCloseCom3);
            this.tabPageSetting.Controls.Add(this.btnOpenCom3);
            this.tabPageSetting.Controls.Add(this.btnOpenAll);
            this.tabPageSetting.Controls.Add(this.cmbEmber);
            this.tabPageSetting.Controls.Add(this.cmbRs485);
            this.tabPageSetting.Controls.Add(this.label3);
            this.tabPageSetting.Controls.Add(this.label1);
            this.tabPageSetting.Controls.Add(this.labelComPort);
            this.tabPageSetting.Controls.Add(this.cmbRs232);
            this.tabPageSetting.Location = new System.Drawing.Point(4, 30);
            this.tabPageSetting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageSetting.Name = "tabPageSetting";
            this.tabPageSetting.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageSetting.Size = new System.Drawing.Size(635, 560);
            this.tabPageSetting.TabIndex = 9;
            this.tabPageSetting.Text = "Setting";
            this.tabPageSetting.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(29, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 30);
            this.label4.TabIndex = 39;
            this.label4.Text = "Rs232";
            // 
            // btnCloseAll
            // 
            this.btnCloseAll.Font = new System.Drawing.Font("PMingLiU", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCloseAll.Location = new System.Drawing.Point(457, 268);
            this.btnCloseAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCloseAll.Name = "btnCloseAll";
            this.btnCloseAll.Size = new System.Drawing.Size(129, 38);
            this.btnCloseAll.TabIndex = 37;
            this.btnCloseAll.Text = "CloseAll";
            this.btnCloseAll.UseVisualStyleBackColor = true;
            this.btnCloseAll.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCloseCom3
            // 
            this.btnCloseCom3.Font = new System.Drawing.Font("PMingLiU", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCloseCom3.Location = new System.Drawing.Point(457, 170);
            this.btnCloseCom3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCloseCom3.Name = "btnCloseCom3";
            this.btnCloseCom3.Size = new System.Drawing.Size(129, 38);
            this.btnCloseCom3.TabIndex = 36;
            this.btnCloseCom3.Text = "Close Ember";
            this.btnCloseCom3.UseVisualStyleBackColor = true;
            this.btnCloseCom3.Click += new System.EventHandler(this.btnCloseCom3_Click);
            // 
            // btnOpenCom3
            // 
            this.btnOpenCom3.Font = new System.Drawing.Font("PMingLiU", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnOpenCom3.Location = new System.Drawing.Point(304, 170);
            this.btnOpenCom3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOpenCom3.Name = "btnOpenCom3";
            this.btnOpenCom3.Size = new System.Drawing.Size(125, 38);
            this.btnOpenCom3.TabIndex = 36;
            this.btnOpenCom3.Text = "Open Ember";
            this.btnOpenCom3.UseVisualStyleBackColor = true;
            this.btnOpenCom3.Click += new System.EventHandler(this.btnOpenCom3_Click);
            // 
            // btnOpenAll
            // 
            this.btnOpenAll.Font = new System.Drawing.Font("PMingLiU", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnOpenAll.Location = new System.Drawing.Point(304, 268);
            this.btnOpenAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOpenAll.Name = "btnOpenAll";
            this.btnOpenAll.Size = new System.Drawing.Size(125, 38);
            this.btnOpenAll.TabIndex = 36;
            this.btnOpenAll.Text = "OpenAll";
            this.btnOpenAll.UseVisualStyleBackColor = true;
            this.btnOpenAll.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // cmbEmber
            // 
            this.cmbEmber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmber.FormattingEnabled = true;
            this.cmbEmber.Location = new System.Drawing.Point(140, 179);
            this.cmbEmber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbEmber.Name = "cmbEmber";
            this.cmbEmber.Size = new System.Drawing.Size(121, 28);
            this.cmbEmber.TabIndex = 35;
            // 
            // cmbRs485
            // 
            this.cmbRs485.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRs485.FormattingEnabled = true;
            this.cmbRs485.Location = new System.Drawing.Point(140, 126);
            this.cmbRs485.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbRs485.Name = "cmbRs485";
            this.cmbRs485.Size = new System.Drawing.Size(121, 28);
            this.cmbRs485.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(29, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 30);
            this.label3.TabIndex = 33;
            this.label3.Text = "Ember";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(29, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 30);
            this.label1.TabIndex = 32;
            this.label1.Text = "Rs485";
            // 
            // labelComPort
            // 
            this.labelComPort.Location = new System.Drawing.Point(0, 0);
            this.labelComPort.Name = "labelComPort";
            this.labelComPort.Size = new System.Drawing.Size(100, 22);
            this.labelComPort.TabIndex = 38;
            // 
            // cmbRs232
            // 
            this.cmbRs232.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRs232.FormattingEnabled = true;
            this.cmbRs232.Location = new System.Drawing.Point(140, 72);
            this.cmbRs232.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbRs232.Name = "cmbRs232";
            this.cmbRs232.Size = new System.Drawing.Size(121, 28);
            this.cmbRs232.TabIndex = 30;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 622);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(673, 26);
            this.statusStrip1.TabIndex = 62;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pBar
            // 
            this.pBar.ForeColor = System.Drawing.Color.Lime;
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(600, 20);
            this.pBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // resetWorker
            // 
            this.resetWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.resetWorker_DoWork);
            this.resetWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.resetWorker_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(673, 648);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "C303 Produce Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.tabPageMain.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabEZRP.ResumeLayout(false);
            this.tabEZRP.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPageSetting.ResumeLayout(false);
            this.tabPageSetting.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMacAddress;
        private System.Windows.Forms.Label lblSerialNumber;
        private System.Windows.Forms.Label lblTestResult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.IO.Ports.SerialPort comPort1;
        private System.IO.Ports.SerialPort comPort2;
        private System.IO.Ports.SerialPort comPort3;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.TabPage tabPageSetting;
        private System.Windows.Forms.Label labelComPort;
        private System.Windows.Forms.ComboBox cmbRs232;
        private System.Windows.Forms.ComboBox cmbEmber;
        private System.Windows.Forms.ComboBox cmbRs485;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox tbxBarcode;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar pBar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton btnYellowFail;
        //private System.Windows.Forms.RadioButton btnGreenPassbtnGreenFail;
        private System.Windows.Forms.RadioButton btnGreenPass;
        private System.Windows.Forms.RadioButton btnYellowPass;
        private System.Windows.Forms.Button btnCloseAll;
        private System.Windows.Forms.Button btnOpenAll;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton btnReset;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton btnGreenFail;
        private System.ComponentModel.BackgroundWorker resetWorker;
        private System.Windows.Forms.TabPage tabEZRP;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblLicenseMac;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbxLicense;
        private System.Windows.Forms.Button btnCloseCom3;
        private System.Windows.Forms.Button btnOpenCom3;
        private System.Windows.Forms.Button btnLeave;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Label lblLicenseResult;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblLicenseStatus;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rdbC303;
        private System.Windows.Forms.RadioButton rdbEZRP;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Button btnIdentify;
        private System.Windows.Forms.Button btnWriteInvalid;
        private System.Windows.Forms.RadioButton rdbICB;
    }
}

