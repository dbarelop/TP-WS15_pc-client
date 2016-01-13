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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbV2 = new System.Windows.Forms.RadioButton();
            this.rbV1 = new System.Windows.Forms.RadioButton();
            this.btnWriteEprom = new System.Windows.Forms.Button();
            this.btnReadEprom = new System.Windows.Forms.Button();
            this.chkPoll = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSend = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkDTR = new System.Windows.Forms.CheckBox();
            this.btnOpenPort = new System.Windows.Forms.Button();
            this.chkRTS = new System.Windows.Forms.CheckBox();
            this.chkSimulation = new System.Windows.Forms.CheckBox();
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
            this.btnClearOut = new System.Windows.Forms.Button();
            this.btnClearIn = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(4, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(482, 469);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.MouseEnter += new System.EventHandler(this.OnMouseEntering);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage1.Controls.Add(this.checkBox2);
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.btnWriteEprom);
            this.tabPage1.Controls.Add(this.btnReadEprom);
            this.tabPage1.Controls.Add(this.chkPoll);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Controls.Add(this.btnReadADC2);
            this.tabPage1.Controls.Add(this.btnReadADC1);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.tbADChannel2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.tbTemperatur);
            this.tabPage1.Controls.Add(this.tbADChannel1);
            this.tabPage1.Controls.Add(this.tbHardware);
            this.tabPage1.Controls.Add(this.btnReadTemperatur);
            this.tabPage1.Controls.Add(this.btnResetHardware);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(474, 443);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Start";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(375, 132);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(50, 20);
            this.checkBox2.TabIndex = 19;
            this.checkBox2.Text = "Poll";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(375, 94);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(50, 20);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.Text = "Poll";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(-12, 168);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(504, 67);
            this.panel2.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(92, 39);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(126, 16);
            this.label13.TabIndex = 19;
            this.label13.Text = "Connected to ComX";
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
            this.panel1.Size = new System.Drawing.Size(172, 25);
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
            // 
            // rbV1
            // 
            this.rbV1.AutoSize = true;
            this.rbV1.Checked = true;
            this.rbV1.Location = new System.Drawing.Point(3, 1);
            this.rbV1.Name = "rbV1";
            this.rbV1.Size = new System.Drawing.Size(62, 20);
            this.rbV1.TabIndex = 0;
            this.rbV1.TabStop = true;
            this.rbV1.Text = "2.56 V";
            this.rbV1.UseVisualStyleBackColor = true;
            // 
            // btnWriteEprom
            // 
            this.btnWriteEprom.Location = new System.Drawing.Point(278, 403);
            this.btnWriteEprom.Name = "btnWriteEprom";
            this.btnWriteEprom.Size = new System.Drawing.Size(75, 23);
            this.btnWriteEprom.TabIndex = 16;
            this.btnWriteEprom.Text = "Write";
            this.btnWriteEprom.UseVisualStyleBackColor = true;
            // 
            // btnReadEprom
            // 
            this.btnReadEprom.Location = new System.Drawing.Point(189, 403);
            this.btnReadEprom.Name = "btnReadEprom";
            this.btnReadEprom.Size = new System.Drawing.Size(75, 23);
            this.btnReadEprom.TabIndex = 15;
            this.btnReadEprom.Text = "Read";
            this.btnReadEprom.UseVisualStyleBackColor = true;
            // 
            // chkPoll
            // 
            this.chkPoll.AutoSize = true;
            this.chkPoll.Location = new System.Drawing.Point(375, 56);
            this.chkPoll.Name = "chkPoll";
            this.chkPoll.Size = new System.Drawing.Size(50, 20);
            this.chkPoll.TabIndex = 14;
            this.chkPoll.Text = "Poll";
            this.chkPoll.UseVisualStyleBackColor = true;
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
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(85, 241);
            this.richTextBox1.MaxLength = 512;
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(378, 155);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            // 
            // btnReadADC2
            // 
            this.btnReadADC2.Location = new System.Drawing.Point(256, 130);
            this.btnReadADC2.Name = "btnReadADC2";
            this.btnReadADC2.Size = new System.Drawing.Size(75, 23);
            this.btnReadADC2.TabIndex = 12;
            this.btnReadADC2.Text = "Read";
            this.btnReadADC2.UseVisualStyleBackColor = true;
            // 
            // btnReadADC1
            // 
            this.btnReadADC1.Location = new System.Drawing.Point(256, 92);
            this.btnReadADC1.Name = "btnReadADC1";
            this.btnReadADC1.Size = new System.Drawing.Size(75, 23);
            this.btnReadADC1.TabIndex = 11;
            this.btnReadADC1.Text = "Read";
            this.btnReadADC1.UseVisualStyleBackColor = true;
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
            // 
            // btnResetHardware
            // 
            this.btnResetHardware.Location = new System.Drawing.Point(256, 15);
            this.btnResetHardware.Name = "btnResetHardware";
            this.btnResetHardware.Size = new System.Drawing.Size(75, 23);
            this.btnResetHardware.TabIndex = 0;
            this.btnResetHardware.Text = "Reset";
            this.btnResetHardware.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage2.Controls.Add(this.btnClearIn);
            this.tabPage2.Controls.Add(this.btnClearOut);
            this.tabPage2.Controls.Add(this.btnSend);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.chkHex);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.rtfTerminalIn);
            this.tabPage2.Controls.Add(this.chkInputType);
            this.tabPage2.Controls.Add(this.rtfTerminalOut);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(474, 443);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ComPort";
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
            this.panel3.Controls.Add(this.chkSimulation);
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
            // chkSimulation
            // 
            this.chkSimulation.AutoSize = true;
            this.chkSimulation.Location = new System.Drawing.Point(188, 67);
            this.chkSimulation.Name = "chkSimulation";
            this.chkSimulation.Size = new System.Drawing.Size(89, 20);
            this.chkSimulation.TabIndex = 11;
            this.chkSimulation.Text = "Simulation";
            this.chkSimulation.UseVisualStyleBackColor = true;
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
            this.rtfTerminalOut.Location = new System.Drawing.Point(7, 31);
            this.rtfTerminalOut.Name = "rtfTerminalOut";
            this.rtfTerminalOut.Size = new System.Drawing.Size(356, 130);
            this.rtfTerminalOut.TabIndex = 1;
            this.rtfTerminalOut.Text = "";
            this.rtfTerminalOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtfTerminalOut_KeyDown);
            // 
            // btnClearOut
            // 
            this.btnClearOut.Location = new System.Drawing.Point(369, 133);
            this.btnClearOut.Name = "btnClearOut";
            this.btnClearOut.Size = new System.Drawing.Size(83, 28);
            this.btnClearOut.TabIndex = 19;
            this.btnClearOut.Text = "Clear";
            this.btnClearOut.UseVisualStyleBackColor = true;
            this.btnClearOut.Click += new System.EventHandler(this.btnClearOut_Click);
            // 
            // btnClearIn
            // 
            this.btnClearIn.Location = new System.Drawing.Point(369, 295);
            this.btnClearIn.Name = "btnClearIn";
            this.btnClearIn.Size = new System.Drawing.Size(83, 28);
            this.btnClearIn.TabIndex = 20;
            this.btnClearIn.Text = "Clear";
            this.btnClearIn.UseVisualStyleBackColor = true;
            this.btnClearIn.Click += new System.EventHandler(this.btnClearIn_Click);
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
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
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
        private System.Windows.Forms.CheckBox chkSimulation;
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
        private System.Windows.Forms.CheckBox chkPoll;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnWriteEprom;
        private System.Windows.Forms.Button btnReadEprom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbV2;
        private System.Windows.Forms.RadioButton rbV1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnClearIn;
        private System.Windows.Forms.Button btnClearOut;
    }
}

