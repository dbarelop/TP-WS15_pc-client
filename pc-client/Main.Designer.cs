namespace pc_client
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.main = new System.Windows.Forms.TabPage();
            this.chkAD2 = new System.Windows.Forms.CheckBox();
            this.chkAD1 = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkSimulation = new System.Windows.Forms.CheckBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this._portLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbV2 = new System.Windows.Forms.RadioButton();
            this.rbV1 = new System.Windows.Forms.RadioButton();
            this.btnWriteEprom = new System.Windows.Forms.Button();
            this.btnReadEprom = new System.Windows.Forms.Button();
            this.chkPollTemp = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.rtfEprom = new System.Windows.Forms.RichTextBox();
            this.btnReadADC2 = new System.Windows.Forms.Button();
            this.btnReadADC1 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.tbADChannel2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTemperatur = new System.Windows.Forms.TextBox();
            this.tbADChannel1 = new System.Windows.Forms.TextBox();
            this.tbHardware = new System.Windows.Forms.TextBox();
            this.btnReadTemperatur = new System.Windows.Forms.Button();
            this.btnResetHardware = new System.Windows.Forms.Button();
            this.comport = new System.Windows.Forms.TabPage();
            this.btnClearIn = new System.Windows.Forms.Button();
            this.btnClearOut = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkDTR = new System.Windows.Forms.CheckBox();
            this.btnOpenPort = new System.Windows.Forms.Button();
            this.chkRTS = new System.Windows.Forms.CheckBox();
            this.cmbPortName = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.cmbStopBits = new System.Windows.Forms.ComboBox();
            this.cmbDataBits = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbParity = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.chkHex = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.rtfTerminalIn = new System.Windows.Forms.RichTextBox();
            this.chkInputType = new System.Windows.Forms.CheckBox();
            this.rtfTerminalOut = new System.Windows.Forms.RichTextBox();
            this.log = new System.Windows.Forms.TabPage();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnLogClear = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.rtfLog = new System.Windows.Forms.RichTextBox();
            this.about = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.portTimer = new System.Windows.Forms.Timer(this.components);
            this._backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.bgwTimer = new System.Windows.Forms.Timer(this.components);
            this._backgroundWorkerADW = new System.ComponentModel.BackgroundWorker();
            this.tempTimer = new System.Windows.Forms.Timer(this.components);
            this.ad1Timer = new System.Windows.Forms.Timer(this.components);
            this.ad2Timer = new System.Windows.Forms.Timer(this.components);
            this._backgroundWorkerEepromRead = new System.ComponentModel.BackgroundWorker();
            this._backgroundWorkerEepromWrite = new System.ComponentModel.BackgroundWorker();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.main.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.comport.SuspendLayout();
            this.panel3.SuspendLayout();
            this.log.SuspendLayout();
            this.about.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.main);
            this.tabControl1.Controls.Add(this.comport);
            this.tabControl1.Controls.Add(this.log);
            this.tabControl1.Controls.Add(this.about);
            this.tabControl1.Location = new System.Drawing.Point(4, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(496, 469);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.Enter += new System.EventHandler(this.mainTabControl_Enter);
            this.tabControl1.MouseEnter += new System.EventHandler(this.OnMouseEntering);
            // 
            // main
            // 
            this.main.BackColor = System.Drawing.Color.Gainsboro;
            this.main.Controls.Add(this.label21);
            this.main.Controls.Add(this.label20);
            this.main.Controls.Add(this.label19);
            this.main.Controls.Add(this.chkAD2);
            this.main.Controls.Add(this.chkAD1);
            this.main.Controls.Add(this.panel2);
            this.main.Controls.Add(this.btnWriteEprom);
            this.main.Controls.Add(this.btnReadEprom);
            this.main.Controls.Add(this.chkPollTemp);
            this.main.Controls.Add(this.label17);
            this.main.Controls.Add(this.rtfEprom);
            this.main.Controls.Add(this.btnReadADC2);
            this.main.Controls.Add(this.btnReadADC1);
            this.main.Controls.Add(this.label16);
            this.main.Controls.Add(this.tbADChannel2);
            this.main.Controls.Add(this.label3);
            this.main.Controls.Add(this.label2);
            this.main.Controls.Add(this.label1);
            this.main.Controls.Add(this.tbTemperatur);
            this.main.Controls.Add(this.tbADChannel1);
            this.main.Controls.Add(this.tbHardware);
            this.main.Controls.Add(this.btnReadTemperatur);
            this.main.Controls.Add(this.btnResetHardware);
            this.main.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main.Location = new System.Drawing.Point(4, 22);
            this.main.Name = "main";
            this.main.Padding = new System.Windows.Forms.Padding(3);
            this.main.Size = new System.Drawing.Size(488, 443);
            this.main.TabIndex = 0;
            this.main.Text = "Start";
            // 
            // chkAD2
            // 
            this.chkAD2.AutoSize = true;
            this.chkAD2.Location = new System.Drawing.Point(375, 132);
            this.chkAD2.Name = "chkAD2";
            this.chkAD2.Size = new System.Drawing.Size(50, 20);
            this.chkAD2.TabIndex = 19;
            this.chkAD2.Text = "Poll";
            this.chkAD2.UseVisualStyleBackColor = true;
            this.chkAD2.CheckedChanged += new System.EventHandler(this.chkAD2_CheckedChanged);
            // 
            // chkAD1
            // 
            this.chkAD1.AutoSize = true;
            this.chkAD1.Location = new System.Drawing.Point(375, 94);
            this.chkAD1.Name = "chkAD1";
            this.chkAD1.Size = new System.Drawing.Size(50, 20);
            this.chkAD1.TabIndex = 18;
            this.chkAD1.Text = "Poll";
            this.chkAD1.UseVisualStyleBackColor = true;
            this.chkAD1.CheckedChanged += new System.EventHandler(this.chkAD1_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.chkSimulation);
            this.panel2.Controls.Add(this.btnConnect);
            this.panel2.Controls.Add(this._portLabel);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(-12, 168);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(504, 67);
            this.panel2.TabIndex = 17;
            // 
            // chkSimulation
            // 
            this.chkSimulation.AutoSize = true;
            this.chkSimulation.Location = new System.Drawing.Point(387, 38);
            this.chkSimulation.Name = "chkSimulation";
            this.chkSimulation.Size = new System.Drawing.Size(89, 20);
            this.chkSimulation.TabIndex = 21;
            this.chkSimulation.Text = "Simulation";
            this.chkSimulation.UseVisualStyleBackColor = true;
            this.chkSimulation.CheckedChanged += new System.EventHandler(this.chkSimulation_CheckedChanged);
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.Gainsboro;
            this.btnConnect.Location = new System.Drawing.Point(268, 36);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 20;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnOpenPort_Click);
            // 
            // _portLabel
            // 
            this._portLabel.AutoSize = true;
            this._portLabel.Location = new System.Drawing.Point(92, 39);
            this._portLabel.Name = "_portLabel";
            this._portLabel.Size = new System.Drawing.Size(126, 16);
            this._portLabel.TabIndex = 19;
            this._portLabel.Text = "Connected to ComX";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(27, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 16);
            this.label12.TabIndex = 18;
            this.label12.Text = "Status:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 16);
            this.label11.TabIndex = 17;
            this.label11.Text = "Range:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbV2);
            this.panel1.Controls.Add(this.rbV1);
            this.panel1.Location = new System.Drawing.Point(92, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(154, 25);
            this.panel1.TabIndex = 15;
            // 
            // rbV2
            // 
            this.rbV2.AutoSize = true;
            this.rbV2.Location = new System.Drawing.Point(82, 3);
            this.rbV2.Name = "rbV2";
            this.rbV2.Size = new System.Drawing.Size(62, 20);
            this.rbV2.TabIndex = 1;
            this.rbV2.Text = "0.16 V";
            this.rbV2.UseVisualStyleBackColor = true;
            this.rbV2.Click += new System.EventHandler(this.rbV2_Click);
            // 
            // rbV1
            // 
            this.rbV1.AutoSize = true;
            this.rbV1.Location = new System.Drawing.Point(3, 1);
            this.rbV1.Name = "rbV1";
            this.rbV1.Size = new System.Drawing.Size(62, 20);
            this.rbV1.TabIndex = 0;
            this.rbV1.Text = "2.56 V";
            this.rbV1.UseVisualStyleBackColor = true;
            this.rbV1.Click += new System.EventHandler(this.rbV1_Click);
            // 
            // btnWriteEprom
            // 
            this.btnWriteEprom.Location = new System.Drawing.Point(278, 403);
            this.btnWriteEprom.Name = "btnWriteEprom";
            this.btnWriteEprom.Size = new System.Drawing.Size(75, 23);
            this.btnWriteEprom.TabIndex = 16;
            this.btnWriteEprom.Text = "Write";
            this.btnWriteEprom.UseVisualStyleBackColor = true;
            this.btnWriteEprom.Click += new System.EventHandler(this.btnWriteEprom_Click);
            // 
            // btnReadEprom
            // 
            this.btnReadEprom.Location = new System.Drawing.Point(189, 403);
            this.btnReadEprom.Name = "btnReadEprom";
            this.btnReadEprom.Size = new System.Drawing.Size(75, 23);
            this.btnReadEprom.TabIndex = 15;
            this.btnReadEprom.Text = "Read";
            this.btnReadEprom.UseVisualStyleBackColor = true;
            this.btnReadEprom.Click += new System.EventHandler(this.btnReadEeprom_Click);
            // 
            // chkPollTemp
            // 
            this.chkPollTemp.AutoSize = true;
            this.chkPollTemp.Location = new System.Drawing.Point(375, 56);
            this.chkPollTemp.Name = "chkPollTemp";
            this.chkPollTemp.Size = new System.Drawing.Size(50, 20);
            this.chkPollTemp.TabIndex = 14;
            this.chkPollTemp.Text = "Poll";
            this.chkPollTemp.UseVisualStyleBackColor = true;
            this.chkPollTemp.CheckedChanged += new System.EventHandler(this.chkPollTemp_CheckedChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(13, 312);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(66, 16);
            this.label17.TabIndex = 14;
            this.label17.Text = "EEPROM";
            // 
            // rtfEprom
            // 
            this.rtfEprom.Location = new System.Drawing.Point(85, 241);
            this.rtfEprom.MaxLength = 512;
            this.rtfEprom.Name = "rtfEprom";
            this.rtfEprom.Size = new System.Drawing.Size(378, 155);
            this.rtfEprom.TabIndex = 13;
            this.rtfEprom.Text = "";
            // 
            // btnReadADC2
            // 
            this.btnReadADC2.Location = new System.Drawing.Point(256, 130);
            this.btnReadADC2.Name = "btnReadADC2";
            this.btnReadADC2.Size = new System.Drawing.Size(75, 23);
            this.btnReadADC2.TabIndex = 12;
            this.btnReadADC2.Text = "Read";
            this.btnReadADC2.UseVisualStyleBackColor = true;
            this.btnReadADC2.Click += new System.EventHandler(this.btnReadADC2_Click);
            // 
            // btnReadADC1
            // 
            this.btnReadADC1.Location = new System.Drawing.Point(256, 92);
            this.btnReadADC1.Name = "btnReadADC1";
            this.btnReadADC1.Size = new System.Drawing.Size(75, 23);
            this.btnReadADC1.TabIndex = 11;
            this.btnReadADC1.Text = "Read";
            this.btnReadADC1.UseVisualStyleBackColor = true;
            this.btnReadADC1.Click += new System.EventHandler(this.btnReadADC1_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(13, 133);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(96, 16);
            this.label16.TabIndex = 10;
            this.label16.Text = "AD - Channel 2";
            // 
            // tbADChannel2
            // 
            this.tbADChannel2.BackColor = System.Drawing.Color.Gainsboro;
            this.tbADChannel2.Location = new System.Drawing.Point(123, 130);
            this.tbADChannel2.Name = "tbADChannel2";
            this.tbADChannel2.ReadOnly = true;
            this.tbADChannel2.Size = new System.Drawing.Size(100, 22);
            this.tbADChannel2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Temperatur";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "AD - Channel 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Hardware";
            // 
            // tbTemperatur
            // 
            this.tbTemperatur.BackColor = System.Drawing.Color.Gainsboro;
            this.tbTemperatur.Location = new System.Drawing.Point(123, 54);
            this.tbTemperatur.Name = "tbTemperatur";
            this.tbTemperatur.ReadOnly = true;
            this.tbTemperatur.Size = new System.Drawing.Size(100, 22);
            this.tbTemperatur.TabIndex = 4;
            // 
            // tbADChannel1
            // 
            this.tbADChannel1.BackColor = System.Drawing.Color.Gainsboro;
            this.tbADChannel1.Location = new System.Drawing.Point(123, 92);
            this.tbADChannel1.Name = "tbADChannel1";
            this.tbADChannel1.ReadOnly = true;
            this.tbADChannel1.Size = new System.Drawing.Size(100, 22);
            this.tbADChannel1.TabIndex = 3;
            // 
            // tbHardware
            // 
            this.tbHardware.BackColor = System.Drawing.Color.Gainsboro;
            this.tbHardware.Location = new System.Drawing.Point(123, 16);
            this.tbHardware.Name = "tbHardware";
            this.tbHardware.ReadOnly = true;
            this.tbHardware.Size = new System.Drawing.Size(100, 22);
            this.tbHardware.TabIndex = 2;
            // 
            // btnReadTemperatur
            // 
            this.btnReadTemperatur.Location = new System.Drawing.Point(256, 53);
            this.btnReadTemperatur.Name = "btnReadTemperatur";
            this.btnReadTemperatur.Size = new System.Drawing.Size(75, 23);
            this.btnReadTemperatur.TabIndex = 1;
            this.btnReadTemperatur.Text = "Read";
            this.btnReadTemperatur.UseVisualStyleBackColor = true;
            this.btnReadTemperatur.Click += new System.EventHandler(this.btnReadTemperatur_Click);
            // 
            // btnResetHardware
            // 
            this.btnResetHardware.Location = new System.Drawing.Point(256, 15);
            this.btnResetHardware.Name = "btnResetHardware";
            this.btnResetHardware.Size = new System.Drawing.Size(75, 23);
            this.btnResetHardware.TabIndex = 0;
            this.btnResetHardware.Text = "Read";
            this.btnResetHardware.UseVisualStyleBackColor = true;
            this.btnResetHardware.Click += new System.EventHandler(this.btnReadHardware_Click);
            // 
            // comport
            // 
            this.comport.BackColor = System.Drawing.Color.Gainsboro;
            this.comport.Controls.Add(this.btnClearIn);
            this.comport.Controls.Add(this.btnClearOut);
            this.comport.Controls.Add(this.btnSend);
            this.comport.Controls.Add(this.panel3);
            this.comport.Controls.Add(this.label10);
            this.comport.Controls.Add(this.chkHex);
            this.comport.Controls.Add(this.label9);
            this.comport.Controls.Add(this.rtfTerminalIn);
            this.comport.Controls.Add(this.chkInputType);
            this.comport.Controls.Add(this.rtfTerminalOut);
            this.comport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comport.Location = new System.Drawing.Point(4, 22);
            this.comport.Name = "comport";
            this.comport.Padding = new System.Windows.Forms.Padding(3);
            this.comport.Size = new System.Drawing.Size(488, 443);
            this.comport.TabIndex = 1;
            this.comport.Text = "ComPort";
            // 
            // btnClearIn
            // 
            this.btnClearIn.Enabled = false;
            this.btnClearIn.Location = new System.Drawing.Point(369, 295);
            this.btnClearIn.Name = "btnClearIn";
            this.btnClearIn.Size = new System.Drawing.Size(83, 28);
            this.btnClearIn.TabIndex = 20;
            this.btnClearIn.Text = "Clear";
            this.btnClearIn.UseVisualStyleBackColor = true;
            this.btnClearIn.Click += new System.EventHandler(this.btnClearIn_Click);
            // 
            // btnClearOut
            // 
            this.btnClearOut.Enabled = false;
            this.btnClearOut.Location = new System.Drawing.Point(369, 133);
            this.btnClearOut.Name = "btnClearOut";
            this.btnClearOut.Size = new System.Drawing.Size(83, 28);
            this.btnClearOut.TabIndex = 19;
            this.btnClearOut.Text = "Clear";
            this.btnClearOut.UseVisualStyleBackColor = true;
            this.btnClearOut.Click += new System.EventHandler(this.btnClearOut_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(369, 84);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(83, 28);
            this.btnSend.TabIndex = 15;
            this.btnSend.Text = "Send Line";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Controls.Add(this.chkDTR);
            this.panel3.Controls.Add(this.btnOpenPort);
            this.panel3.Controls.Add(this.chkRTS);
            this.panel3.Controls.Add(this.cmbPortName);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.cmbBaudRate);
            this.panel3.Controls.Add(this.cmbStopBits);
            this.panel3.Controls.Add(this.cmbDataBits);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.cmbParity);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(7, 335);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(461, 98);
            this.panel3.TabIndex = 18;
            // 
            // chkDTR
            // 
            this.chkDTR.AutoSize = true;
            this.chkDTR.Location = new System.Drawing.Point(99, 67);
            this.chkDTR.Name = "chkDTR";
            this.chkDTR.Size = new System.Drawing.Size(56, 20);
            this.chkDTR.TabIndex = 13;
            this.chkDTR.Text = "DTR";
            this.chkDTR.UseVisualStyleBackColor = true;
            // 
            // btnOpenPort
            // 
            this.btnOpenPort.Location = new System.Drawing.Point(332, 62);
            this.btnOpenPort.Name = "btnOpenPort";
            this.btnOpenPort.Size = new System.Drawing.Size(117, 28);
            this.btnOpenPort.TabIndex = 4;
            this.btnOpenPort.Text = "Open ComPort";
            this.btnOpenPort.UseVisualStyleBackColor = true;
            this.btnOpenPort.Click += new System.EventHandler(this.btnOpenPort_Click);
            // 
            // chkRTS
            // 
            this.chkRTS.AutoSize = true;
            this.chkRTS.Location = new System.Drawing.Point(13, 67);
            this.chkRTS.Name = "chkRTS";
            this.chkRTS.Size = new System.Drawing.Size(55, 20);
            this.chkRTS.TabIndex = 12;
            this.chkRTS.Text = "RTS";
            this.chkRTS.UseVisualStyleBackColor = true;
            // 
            // cmbPortName
            // 
            this.cmbPortName.FormattingEnabled = true;
            this.cmbPortName.Location = new System.Drawing.Point(10, 31);
            this.cmbPortName.Name = "cmbPortName";
            this.cmbPortName.Size = new System.Drawing.Size(83, 24);
            this.cmbPortName.TabIndex = 0;
            this.cmbPortName.DropDown += new System.EventHandler(this.cmbPortName_DropDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(363, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Stop Bits";
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Location = new System.Drawing.Point(99, 31);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(83, 24);
            this.cmbBaudRate.TabIndex = 1;
            this.cmbBaudRate.DropDown += new System.EventHandler(this.cmbBaudRate_DropDown);
            // 
            // cmbStopBits
            // 
            this.cmbStopBits.FormattingEnabled = true;
            this.cmbStopBits.Location = new System.Drawing.Point(366, 31);
            this.cmbStopBits.Name = "cmbStopBits";
            this.cmbStopBits.Size = new System.Drawing.Size(83, 24);
            this.cmbStopBits.TabIndex = 9;
            // 
            // cmbDataBits
            // 
            this.cmbDataBits.FormattingEnabled = true;
            this.cmbDataBits.Location = new System.Drawing.Point(188, 31);
            this.cmbDataBits.Name = "cmbDataBits";
            this.cmbDataBits.Size = new System.Drawing.Size(83, 24);
            this.cmbDataBits.TabIndex = 2;
            this.cmbDataBits.DropDown += new System.EventHandler(this.cmbDataBits_DropDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(274, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "Parity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "ComPort";
            // 
            // cmbParity
            // 
            this.cmbParity.FormattingEnabled = true;
            this.cmbParity.Location = new System.Drawing.Point(277, 31);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(83, 24);
            this.cmbParity.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(96, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Baud Rate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(185, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Data Bits";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(14, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 16);
            this.label10.TabIndex = 17;
            this.label10.Text = "Output";
            // 
            // chkHex
            // 
            this.chkHex.AutoSize = true;
            this.chkHex.Location = new System.Drawing.Point(369, 58);
            this.chkHex.Name = "chkHex";
            this.chkHex.Size = new System.Drawing.Size(51, 20);
            this.chkHex.TabIndex = 14;
            this.chkHex.Text = "Hex";
            this.chkHex.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(14, 174);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 16);
            this.label9.TabIndex = 15;
            this.label9.Text = "Input";
            // 
            // rtfTerminalIn
            // 
            this.rtfTerminalIn.BackColor = System.Drawing.Color.Gainsboro;
            this.rtfTerminalIn.Location = new System.Drawing.Point(7, 193);
            this.rtfTerminalIn.Name = "rtfTerminalIn";
            this.rtfTerminalIn.ReadOnly = true;
            this.rtfTerminalIn.Size = new System.Drawing.Size(356, 130);
            this.rtfTerminalIn.TabIndex = 16;
            this.rtfTerminalIn.Text = "";
            this.rtfTerminalIn.TextChanged += new System.EventHandler(this.rtfTerminalIn_TextChanged);
            // 
            // chkInputType
            // 
            this.chkInputType.AccessibleDescription = "";
            this.chkInputType.AutoSize = true;
            this.chkInputType.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkInputType.Location = new System.Drawing.Point(369, 253);
            this.chkInputType.Name = "chkInputType";
            this.chkInputType.Size = new System.Drawing.Size(86, 20);
            this.chkInputType.TabIndex = 15;
            this.chkInputType.Text = "Raw Data";
            this.chkInputType.UseVisualStyleBackColor = true;
            this.chkInputType.CheckedChanged += new System.EventHandler(this.chkInputType_CheckedChanged);
            // 
            // rtfTerminalOut
            // 
            this.rtfTerminalOut.Enabled = false;
            this.rtfTerminalOut.Location = new System.Drawing.Point(7, 31);
            this.rtfTerminalOut.Name = "rtfTerminalOut";
            this.rtfTerminalOut.Size = new System.Drawing.Size(356, 130);
            this.rtfTerminalOut.TabIndex = 1;
            this.rtfTerminalOut.Text = "";
            this.rtfTerminalOut.TextChanged += new System.EventHandler(this.rtfTerminalOut_TextChanged);
            this.rtfTerminalOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtfTerminalOut_KeyDown);
            // 
            // log
            // 
            this.log.BackColor = System.Drawing.Color.Gainsboro;
            this.log.Controls.Add(this.btnExport);
            this.log.Controls.Add(this.btnLogClear);
            this.log.Controls.Add(this.label14);
            this.log.Controls.Add(this.rtfLog);
            this.log.Location = new System.Drawing.Point(4, 22);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(488, 443);
            this.log.TabIndex = 3;
            this.log.Text = "Log";
            this.log.Click += new System.EventHandler(this.logExport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(253, 401);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(83, 28);
            this.btnExport.TabIndex = 21;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.logExport_Click);
            // 
            // btnLogClear
            // 
            this.btnLogClear.Enabled = false;
            this.btnLogClear.Location = new System.Drawing.Point(144, 401);
            this.btnLogClear.Name = "btnLogClear";
            this.btnLogClear.Size = new System.Drawing.Size(83, 28);
            this.btnLogClear.TabIndex = 20;
            this.btnLogClear.Text = "Clear";
            this.btnLogClear.UseVisualStyleBackColor = true;
            this.btnLogClear.Click += new System.EventHandler(this.btnLogClear_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Location = new System.Drawing.Point(14, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 16);
            this.label14.TabIndex = 19;
            this.label14.Text = "Log";
            // 
            // rtfLog
            // 
            this.rtfLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtfLog.Location = new System.Drawing.Point(4, 31);
            this.rtfLog.Name = "rtfLog";
            this.rtfLog.ReadOnly = true;
            this.rtfLog.Size = new System.Drawing.Size(460, 364);
            this.rtfLog.TabIndex = 18;
            this.rtfLog.Text = "";
            this.rtfLog.TextChanged += new System.EventHandler(this.rtfLog_TextChanged);
            // 
            // about
            // 
            this.about.BackColor = System.Drawing.Color.Gainsboro;
            this.about.Controls.Add(this.label15);
            this.about.Controls.Add(this.pictureBox1);
            this.about.Controls.Add(this.label18);
            this.about.Controls.Add(this.label13);
            this.about.Location = new System.Drawing.Point(4, 22);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(488, 443);
            this.about.TabIndex = 2;
            this.about.Text = "About";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(17, 414);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 16);
            this.label15.TabIndex = 4;
            this.label15.Text = "© 2016\r\n";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(19, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(308, 99);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(14, 149);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(310, 31);
            this.label18.TabIndex = 2;
            this.label18.Text = "Teamprojekt WS 15/16\r\n";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(15, 205);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(225, 168);
            this.label13.TabIndex = 0;
            this.label13.Text = "Prof. Dr. Irenäus Schoppa\r\n\r\nDaniel Barea López\r\nAndreas Maier\r\nAndreas Reinhardt" +
    "\r\nLukas Stoppel\r\nMatthias Weis";
            // 
            // portTimer
            // 
            this.portTimer.Tick += new System.EventHandler(this.portTimer_Tick);
            // 
            // _backgroundWorker
            // 
            this._backgroundWorker.WorkerSupportsCancellation = true;
            this._backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
            this._backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this._backgroundWorker_RunWorkerCompleted);
            // 
            // bgwTimer
            // 
            this.bgwTimer.Tick += new System.EventHandler(this.bgwTimer_Tick);
            // 
            // _backgroundWorkerADW
            // 
            this._backgroundWorkerADW.WorkerSupportsCancellation = true;
            this._backgroundWorkerADW.DoWork += new System.ComponentModel.DoWorkEventHandler(this._backgroundWorkerADW_DoWork);
            this._backgroundWorkerADW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this._backgroundWorkerADW_RunWorkerCompleted);
            // 
            // tempTimer
            // 
            this.tempTimer.Tick += new System.EventHandler(this.tempTimer_Tick);
            // 
            // ad1Timer
            // 
            this.ad1Timer.Tick += new System.EventHandler(this.ad1Timer_Tick);
            // 
            // ad2Timer
            // 
            this.ad2Timer.Tick += new System.EventHandler(this.ad2Timer_Tick);
            // 
            // _backgroundWorkerEepromRead
            // 
            this._backgroundWorkerEepromRead.WorkerSupportsCancellation = true;
            this._backgroundWorkerEepromRead.DoWork += new System.ComponentModel.DoWorkEventHandler(this._backgroundWorkerEepromRead_DoWork);
            this._backgroundWorkerEepromRead.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this._backgroundWorkerEepromRead_RunWorkerCompleted);
            // 
            // _backgroundWorkerEepromWrite
            // 
            this._backgroundWorkerEepromWrite.WorkerSupportsCancellation = true;
            this._backgroundWorkerEepromWrite.DoWork += new System.ComponentModel.DoWorkEventHandler(this._backgroundWorkerEepromWrite_DoWork);
            this._backgroundWorkerEepromWrite.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this._backgroundWorkerEepromWrite_RunWorkerCompleted);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(224, 57);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(21, 16);
            this.label19.TabIndex = 20;
            this.label19.Text = "°C";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(224, 95);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(17, 16);
            this.label20.TabIndex = 21;
            this.label20.Text = "V";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(224, 133);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(17, 16);
            this.label21.TabIndex = 22;
            this.label21.Text = "V";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(484, 462);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "PC-Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.main.ResumeLayout(false);
            this.main.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.comport.ResumeLayout(false);
            this.comport.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.log.ResumeLayout(false);
            this.log.PerformLayout();
            this.about.ResumeLayout(false);
            this.about.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage main;
        private System.Windows.Forms.TabPage comport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTemperatur;
        private System.Windows.Forms.TextBox tbADChannel1;
        private System.Windows.Forms.TextBox tbHardware;
        private System.Windows.Forms.Button btnReadTemperatur;
        private System.Windows.Forms.Button btnResetHardware;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbParity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnOpenPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDataBits;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.ComboBox cmbPortName;
        private System.Windows.Forms.RichTextBox rtfTerminalOut;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbStopBits;
        private System.Windows.Forms.CheckBox chkDTR;
        private System.Windows.Forms.CheckBox chkRTS;
        private System.Windows.Forms.CheckBox chkInputType;
        private System.Windows.Forms.CheckBox chkHex;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox rtfTerminalIn;
        private System.Windows.Forms.Button btnReadADC2;
        private System.Windows.Forms.Button btnReadADC1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbADChannel2;
        private System.Windows.Forms.CheckBox chkPollTemp;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.RichTextBox rtfEprom;
        private System.Windows.Forms.Button btnWriteEprom;
        private System.Windows.Forms.Button btnReadEprom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbV2;
        private System.Windows.Forms.RadioButton rbV1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label _portLabel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkAD2;
        private System.Windows.Forms.CheckBox chkAD1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnClearIn;
        private System.Windows.Forms.Button btnClearOut;
        private System.Windows.Forms.Timer portTimer;
        private System.Windows.Forms.Button btnConnect;
        private System.ComponentModel.BackgroundWorker _backgroundWorker;
        private System.Windows.Forms.TabPage about;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabPage log;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RichTextBox rtfLog;
        private System.Windows.Forms.CheckBox chkSimulation;
        private System.Windows.Forms.Timer bgwTimer;
        private System.ComponentModel.BackgroundWorker _backgroundWorkerADW;
        private System.Windows.Forms.Button btnLogClear;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Timer tempTimer;
        private System.Windows.Forms.Timer ad1Timer;
        private System.Windows.Forms.Timer ad2Timer;
        private System.Windows.Forms.Button btnExport;
        private System.ComponentModel.BackgroundWorker _backgroundWorkerEepromRead;
        private System.ComponentModel.BackgroundWorker _backgroundWorkerEepromWrite;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
    }
}

