namespace RS232_GUI
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
            this.TabControl = new System.Windows.Forms.TabControl();
            this.RS = new System.Windows.Forms.TabPage();
            this.RSSettingPanel = new System.Windows.Forms.Panel();
            this.SettingPanel = new System.Windows.Forms.Panel();
            this.SettingLabelControl = new System.Windows.Forms.Label();
            this.SettingListControlFlew = new System.Windows.Forms.ListBox();
            this.SettingLabelSign = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SettingLabelBitStop = new System.Windows.Forms.Label();
            this.SettingLabelControlBit = new System.Windows.Forms.Label();
            this.SettingLabelDataPool = new System.Windows.Forms.Label();
            this.SettingListStop = new System.Windows.Forms.ListBox();
            this.SettingListParity = new System.Windows.Forms.ListBox();
            this.SettingListBitDataPool = new System.Windows.Forms.ListBox();
            this.SettingLabelSpeed = new System.Windows.Forms.Label();
            this.SettingListSpeed = new System.Windows.Forms.ListBox();
            this.SettingLabelMain = new System.Windows.Forms.Label();
            this.TerminatorPanel = new System.Windows.Forms.Panel();
            this.RSTerminatorLabel2 = new System.Windows.Forms.Label();
            this.RSTerminatorTextCurrent = new System.Windows.Forms.TextBox();
            this.RSTerminatorButtonCRLF = new System.Windows.Forms.RadioButton();
            this.TerminatorPanelCustom = new System.Windows.Forms.Panel();
            this.RSTerminatorButtonCustom = new System.Windows.Forms.RadioButton();
            this.RSTerminatorButtonCustomAccept = new System.Windows.Forms.Button();
            this.RSTerminatorTextCustom = new System.Windows.Forms.TextBox();
            this.RSTerminatorButtonLF = new System.Windows.Forms.RadioButton();
            this.RSTerminatorButtonCR = new System.Windows.Forms.RadioButton();
            this.RSTerminatorButtonNone = new System.Windows.Forms.RadioButton();
            this.RSTerminatorLabel = new System.Windows.Forms.Label();
            this.Modbus = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.domainUpDown2 = new System.Windows.Forms.DomainUpDown();
            this.MasterPanel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.SlaveButtonRadio = new System.Windows.Forms.RadioButton();
            this.SlavePanel = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.domainUpDown4 = new System.Windows.Forms.DomainUpDown();
            this.domainUpDown3 = new System.Windows.Forms.DomainUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.MasterButtonRadio = new System.Windows.Forms.RadioButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ConnectionPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.TimePing = new System.Windows.Forms.TextBox();
            this.PingButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ConnectRadioButton = new System.Windows.Forms.RadioButton();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.PortList = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RSReceivePanel = new System.Windows.Forms.Panel();
            this.ReceiveLabelASCII = new System.Windows.Forms.Label();
            this.ReceiveLabeFrame = new System.Windows.Forms.Label();
            this.ReceiveTextPanelFrame = new System.Windows.Forms.TextBox();
            this.ReceiveTextPanelASCII = new System.Windows.Forms.TextBox();
            this.ReceiveLabel = new System.Windows.Forms.Label();
            this.RSSendingPanel = new System.Windows.Forms.Panel();
            this.SendingLabelFrame = new System.Windows.Forms.Label();
            this.SendingLabelASCII = new System.Windows.Forms.Label();
            this.SendButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SendTextPanelFrame = new System.Windows.Forms.TextBox();
            this.SendTextPanelASCII = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.LogOutput = new System.Windows.Forms.TextBox();
            this.LogIpunt = new System.Windows.Forms.TextBox();
            this.LogLabel = new System.Windows.Forms.Label();
            this.TabControl.SuspendLayout();
            this.RS.SuspendLayout();
            this.RSSettingPanel.SuspendLayout();
            this.SettingPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.TerminatorPanel.SuspendLayout();
            this.TerminatorPanelCustom.SuspendLayout();
            this.Modbus.SuspendLayout();
            this.MasterPanel.SuspendLayout();
            this.SlavePanel.SuspendLayout();
            this.ConnectionPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.RSReceivePanel.SuspendLayout();
            this.RSSendingPanel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.RS);
            this.TabControl.Controls.Add(this.Modbus);
            this.TabControl.Location = new System.Drawing.Point(12, 303);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(301, 613);
            this.TabControl.TabIndex = 0;
            // 
            // RS
            // 
            this.RS.BackColor = System.Drawing.Color.DimGray;
            this.RS.Controls.Add(this.RSSettingPanel);
            this.RS.Location = new System.Drawing.Point(4, 25);
            this.RS.Name = "RS";
            this.RS.Padding = new System.Windows.Forms.Padding(3);
            this.RS.Size = new System.Drawing.Size(293, 584);
            this.RS.TabIndex = 0;
            this.RS.Text = "RS232";
            // 
            // RSSettingPanel
            // 
            this.RSSettingPanel.BackColor = System.Drawing.Color.DarkGray;
            this.RSSettingPanel.Controls.Add(this.SettingPanel);
            this.RSSettingPanel.Controls.Add(this.TerminatorPanel);
            this.RSSettingPanel.Location = new System.Drawing.Point(2, 0);
            this.RSSettingPanel.Name = "RSSettingPanel";
            this.RSSettingPanel.Size = new System.Drawing.Size(289, 948);
            this.RSSettingPanel.TabIndex = 0;
            // 
            // SettingPanel
            // 
            this.SettingPanel.Controls.Add(this.SettingLabelControl);
            this.SettingPanel.Controls.Add(this.SettingListControlFlew);
            this.SettingPanel.Controls.Add(this.SettingLabelSign);
            this.SettingPanel.Controls.Add(this.panel2);
            this.SettingPanel.Controls.Add(this.SettingLabelSpeed);
            this.SettingPanel.Controls.Add(this.SettingListSpeed);
            this.SettingPanel.Controls.Add(this.SettingLabelMain);
            this.SettingPanel.Location = new System.Drawing.Point(6, 6);
            this.SettingPanel.Name = "SettingPanel";
            this.SettingPanel.Size = new System.Drawing.Size(280, 272);
            this.SettingPanel.TabIndex = 0;
            // 
            // SettingLabelControl
            // 
            this.SettingLabelControl.AutoSize = true;
            this.SettingLabelControl.BackColor = System.Drawing.Color.DimGray;
            this.SettingLabelControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.SettingLabelControl.Location = new System.Drawing.Point(3, 221);
            this.SettingLabelControl.Name = "SettingLabelControl";
            this.SettingLabelControl.Size = new System.Drawing.Size(129, 17);
            this.SettingLabelControl.TabIndex = 9;
            this.SettingLabelControl.Text = "Kontrola Przepływu";
            // 
            // SettingListControlFlew
            // 
            this.SettingListControlFlew.FormattingEnabled = true;
            this.SettingListControlFlew.ItemHeight = 16;
            this.SettingListControlFlew.Items.AddRange(new object[] {
            "None",
            "Handshake",
            "XON/XOFF"});
            this.SettingListControlFlew.Location = new System.Drawing.Point(149, 218);
            this.SettingListControlFlew.Name = "SettingListControlFlew";
            this.SettingListControlFlew.Size = new System.Drawing.Size(119, 20);
            this.SettingListControlFlew.TabIndex = 8;
            // 
            // SettingLabelSign
            // 
            this.SettingLabelSign.AutoSize = true;
            this.SettingLabelSign.BackColor = System.Drawing.Color.DimGray;
            this.SettingLabelSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.SettingLabelSign.Location = new System.Drawing.Point(7, 75);
            this.SettingLabelSign.Name = "SettingLabelSign";
            this.SettingLabelSign.Size = new System.Drawing.Size(96, 17);
            this.SettingLabelSign.TabIndex = 7;
            this.SettingLabelSign.Text = "Format Znaku";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SettingLabelBitStop);
            this.panel2.Controls.Add(this.SettingLabelControlBit);
            this.panel2.Controls.Add(this.SettingLabelDataPool);
            this.panel2.Controls.Add(this.SettingListStop);
            this.panel2.Controls.Add(this.SettingListParity);
            this.panel2.Controls.Add(this.SettingListBitDataPool);
            this.panel2.Location = new System.Drawing.Point(3, 95);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(271, 111);
            this.panel2.TabIndex = 0;
            // 
            // SettingLabelBitStop
            // 
            this.SettingLabelBitStop.AutoSize = true;
            this.SettingLabelBitStop.BackColor = System.Drawing.Color.DimGray;
            this.SettingLabelBitStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.SettingLabelBitStop.Location = new System.Drawing.Point(4, 76);
            this.SettingLabelBitStop.Name = "SettingLabelBitStop";
            this.SettingLabelBitStop.Size = new System.Drawing.Size(63, 17);
            this.SettingLabelBitStop.TabIndex = 12;
            this.SettingLabelBitStop.Text = "Bit stopu";
            // 
            // SettingLabelControlBit
            // 
            this.SettingLabelControlBit.AutoSize = true;
            this.SettingLabelControlBit.BackColor = System.Drawing.Color.DimGray;
            this.SettingLabelControlBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.SettingLabelControlBit.Location = new System.Drawing.Point(4, 40);
            this.SettingLabelControlBit.Name = "SettingLabelControlBit";
            this.SettingLabelControlBit.Size = new System.Drawing.Size(137, 17);
            this.SettingLabelControlBit.TabIndex = 11;
            this.SettingLabelControlBit.Text = "Kontrola Parzystości";
            this.SettingLabelControlBit.Click += new System.EventHandler(this.label2_Click);
            // 
            // SettingLabelDataPool
            // 
            this.SettingLabelDataPool.AutoSize = true;
            this.SettingLabelDataPool.BackColor = System.Drawing.Color.DimGray;
            this.SettingLabelDataPool.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.SettingLabelDataPool.Location = new System.Drawing.Point(4, 6);
            this.SettingLabelDataPool.Name = "SettingLabelDataPool";
            this.SettingLabelDataPool.Size = new System.Drawing.Size(88, 17);
            this.SettingLabelDataPool.TabIndex = 10;
            this.SettingLabelDataPool.Text = "Pole Danych";
            // 
            // SettingListStop
            // 
            this.SettingListStop.FormattingEnabled = true;
            this.SettingListStop.ItemHeight = 16;
            this.SettingListStop.Items.AddRange(new object[] {
            "1",
            "2"});
            this.SettingListStop.Location = new System.Drawing.Point(154, 73);
            this.SettingListStop.Name = "SettingListStop";
            this.SettingListStop.Size = new System.Drawing.Size(111, 20);
            this.SettingListStop.TabIndex = 9;
            // 
            // SettingListParity
            // 
            this.SettingListParity.FormattingEnabled = true;
            this.SettingListParity.ItemHeight = 16;
            this.SettingListParity.Items.AddRange(new object[] {
            "E",
            "O",
            "N"});
            this.SettingListParity.Location = new System.Drawing.Point(154, 37);
            this.SettingListParity.Name = "SettingListParity";
            this.SettingListParity.Size = new System.Drawing.Size(111, 20);
            this.SettingListParity.TabIndex = 8;
            this.SettingListParity.SelectedIndexChanged += new System.EventHandler(this.SettingListControlBit_SelectedIndexChanged);
            // 
            // SettingListBitDataPool
            // 
            this.SettingListBitDataPool.FormattingEnabled = true;
            this.SettingListBitDataPool.ItemHeight = 16;
            this.SettingListBitDataPool.Items.AddRange(new object[] {
            "7 bit",
            "8 bit"});
            this.SettingListBitDataPool.Location = new System.Drawing.Point(154, 3);
            this.SettingListBitDataPool.Name = "SettingListBitDataPool";
            this.SettingListBitDataPool.Size = new System.Drawing.Size(111, 20);
            this.SettingListBitDataPool.TabIndex = 7;
            // 
            // SettingLabelSpeed
            // 
            this.SettingLabelSpeed.AutoSize = true;
            this.SettingLabelSpeed.BackColor = System.Drawing.Color.DimGray;
            this.SettingLabelSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.SettingLabelSpeed.Location = new System.Drawing.Point(12, 34);
            this.SettingLabelSpeed.Name = "SettingLabelSpeed";
            this.SettingLabelSpeed.Size = new System.Drawing.Size(68, 17);
            this.SettingLabelSpeed.TabIndex = 6;
            this.SettingLabelSpeed.Text = "Szybkość";
            this.SettingLabelSpeed.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // SettingListSpeed
            // 
            this.SettingListSpeed.FormattingEnabled = true;
            this.SettingListSpeed.ItemHeight = 16;
            this.SettingListSpeed.Location = new System.Drawing.Point(157, 31);
            this.SettingListSpeed.Name = "SettingListSpeed";
            this.SettingListSpeed.Size = new System.Drawing.Size(111, 20);
            this.SettingListSpeed.TabIndex = 2;
            this.SettingListSpeed.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            // 
            // SettingLabelMain
            // 
            this.SettingLabelMain.AutoSize = true;
            this.SettingLabelMain.BackColor = System.Drawing.Color.DimGray;
            this.SettingLabelMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SettingLabelMain.Location = new System.Drawing.Point(46, 0);
            this.SettingLabelMain.Name = "SettingLabelMain";
            this.SettingLabelMain.Size = new System.Drawing.Size(176, 20);
            this.SettingLabelMain.TabIndex = 0;
            this.SettingLabelMain.Text = "Ustawienia połączenia";
            // 
            // TerminatorPanel
            // 
            this.TerminatorPanel.Controls.Add(this.RSTerminatorLabel2);
            this.TerminatorPanel.Controls.Add(this.RSTerminatorTextCurrent);
            this.TerminatorPanel.Controls.Add(this.RSTerminatorButtonCRLF);
            this.TerminatorPanel.Controls.Add(this.TerminatorPanelCustom);
            this.TerminatorPanel.Controls.Add(this.RSTerminatorButtonLF);
            this.TerminatorPanel.Controls.Add(this.RSTerminatorButtonCR);
            this.TerminatorPanel.Controls.Add(this.RSTerminatorButtonNone);
            this.TerminatorPanel.Controls.Add(this.RSTerminatorLabel);
            this.TerminatorPanel.Location = new System.Drawing.Point(9, 284);
            this.TerminatorPanel.Name = "TerminatorPanel";
            this.TerminatorPanel.Size = new System.Drawing.Size(277, 219);
            this.TerminatorPanel.TabIndex = 0;
            // 
            // RSTerminatorLabel2
            // 
            this.RSTerminatorLabel2.AutoSize = true;
            this.RSTerminatorLabel2.BackColor = System.Drawing.Color.DimGray;
            this.RSTerminatorLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.RSTerminatorLabel2.Location = new System.Drawing.Point(147, 39);
            this.RSTerminatorLabel2.Name = "RSTerminatorLabel2";
            this.RSTerminatorLabel2.Size = new System.Drawing.Size(57, 17);
            this.RSTerminatorLabel2.TabIndex = 6;
            this.RSTerminatorLabel2.Text = "Obecny";
            this.RSTerminatorLabel2.Click += new System.EventHandler(this.RSTerminatorLabel2_Click);
            // 
            // RSTerminatorTextCurrent
            // 
            this.RSTerminatorTextCurrent.Location = new System.Drawing.Point(132, 61);
            this.RSTerminatorTextCurrent.Name = "RSTerminatorTextCurrent";
            this.RSTerminatorTextCurrent.Size = new System.Drawing.Size(100, 22);
            this.RSTerminatorTextCurrent.TabIndex = 5;
            // 
            // RSTerminatorButtonCRLF
            // 
            this.RSTerminatorButtonCRLF.AutoSize = true;
            this.RSTerminatorButtonCRLF.Location = new System.Drawing.Point(6, 113);
            this.RSTerminatorButtonCRLF.Name = "RSTerminatorButtonCRLF";
            this.RSTerminatorButtonCRLF.Size = new System.Drawing.Size(64, 21);
            this.RSTerminatorButtonCRLF.TabIndex = 4;
            this.RSTerminatorButtonCRLF.TabStop = true;
            this.RSTerminatorButtonCRLF.Text = "CRLF";
            this.RSTerminatorButtonCRLF.UseVisualStyleBackColor = true;
            this.RSTerminatorButtonCRLF.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // TerminatorPanelCustom
            // 
            this.TerminatorPanelCustom.Controls.Add(this.RSTerminatorButtonCustom);
            this.TerminatorPanelCustom.Controls.Add(this.RSTerminatorButtonCustomAccept);
            this.TerminatorPanelCustom.Controls.Add(this.RSTerminatorTextCustom);
            this.TerminatorPanelCustom.Location = new System.Drawing.Point(6, 152);
            this.TerminatorPanelCustom.Name = "TerminatorPanelCustom";
            this.TerminatorPanelCustom.Size = new System.Drawing.Size(226, 58);
            this.TerminatorPanelCustom.TabIndex = 0;
            // 
            // RSTerminatorButtonCustom
            // 
            this.RSTerminatorButtonCustom.AutoSize = true;
            this.RSTerminatorButtonCustom.Location = new System.Drawing.Point(3, 3);
            this.RSTerminatorButtonCustom.Name = "RSTerminatorButtonCustom";
            this.RSTerminatorButtonCustom.Size = new System.Drawing.Size(75, 21);
            this.RSTerminatorButtonCustom.TabIndex = 7;
            this.RSTerminatorButtonCustom.TabStop = true;
            this.RSTerminatorButtonCustom.Text = "Własny";
            this.RSTerminatorButtonCustom.UseVisualStyleBackColor = true;
            // 
            // RSTerminatorButtonCustomAccept
            // 
            this.RSTerminatorButtonCustomAccept.Location = new System.Drawing.Point(144, 32);
            this.RSTerminatorButtonCustomAccept.Name = "RSTerminatorButtonCustomAccept";
            this.RSTerminatorButtonCustomAccept.Size = new System.Drawing.Size(75, 23);
            this.RSTerminatorButtonCustomAccept.TabIndex = 0;
            this.RSTerminatorButtonCustomAccept.Text = "Ustaw";
            this.RSTerminatorButtonCustomAccept.UseVisualStyleBackColor = true;
            // 
            // RSTerminatorTextCustom
            // 
            this.RSTerminatorTextCustom.Location = new System.Drawing.Point(10, 33);
            this.RSTerminatorTextCustom.Name = "RSTerminatorTextCustom";
            this.RSTerminatorTextCustom.Size = new System.Drawing.Size(78, 22);
            this.RSTerminatorTextCustom.TabIndex = 0;
            this.RSTerminatorTextCustom.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // RSTerminatorButtonLF
            // 
            this.RSTerminatorButtonLF.AutoSize = true;
            this.RSTerminatorButtonLF.Location = new System.Drawing.Point(6, 89);
            this.RSTerminatorButtonLF.Name = "RSTerminatorButtonLF";
            this.RSTerminatorButtonLF.Size = new System.Drawing.Size(45, 21);
            this.RSTerminatorButtonLF.TabIndex = 3;
            this.RSTerminatorButtonLF.TabStop = true;
            this.RSTerminatorButtonLF.Text = "LF";
            this.RSTerminatorButtonLF.UseVisualStyleBackColor = true;
            // 
            // RSTerminatorButtonCR
            // 
            this.RSTerminatorButtonCR.AutoSize = true;
            this.RSTerminatorButtonCR.Location = new System.Drawing.Point(6, 62);
            this.RSTerminatorButtonCR.Name = "RSTerminatorButtonCR";
            this.RSTerminatorButtonCR.Size = new System.Drawing.Size(48, 21);
            this.RSTerminatorButtonCR.TabIndex = 2;
            this.RSTerminatorButtonCR.TabStop = true;
            this.RSTerminatorButtonCR.Text = "CR";
            this.RSTerminatorButtonCR.UseVisualStyleBackColor = true;
            // 
            // RSTerminatorButtonNone
            // 
            this.RSTerminatorButtonNone.AutoSize = true;
            this.RSTerminatorButtonNone.Location = new System.Drawing.Point(6, 35);
            this.RSTerminatorButtonNone.Name = "RSTerminatorButtonNone";
            this.RSTerminatorButtonNone.Size = new System.Drawing.Size(63, 21);
            this.RSTerminatorButtonNone.TabIndex = 1;
            this.RSTerminatorButtonNone.TabStop = true;
            this.RSTerminatorButtonNone.Text = "None";
            this.RSTerminatorButtonNone.UseVisualStyleBackColor = true;
            // 
            // RSTerminatorLabel
            // 
            this.RSTerminatorLabel.AutoSize = true;
            this.RSTerminatorLabel.BackColor = System.Drawing.Color.DimGray;
            this.RSTerminatorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.RSTerminatorLabel.Location = new System.Drawing.Point(50, 0);
            this.RSTerminatorLabel.Name = "RSTerminatorLabel";
            this.RSTerminatorLabel.Size = new System.Drawing.Size(106, 25);
            this.RSTerminatorLabel.TabIndex = 0;
            this.RSTerminatorLabel.Text = "Terminator";
            this.RSTerminatorLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // Modbus
            // 
            this.Modbus.BackColor = System.Drawing.Color.LightGray;
            this.Modbus.Controls.Add(this.label7);
            this.Modbus.Controls.Add(this.domainUpDown2);
            this.Modbus.Controls.Add(this.MasterPanel);
            this.Modbus.Controls.Add(this.SlavePanel);
            this.Modbus.Location = new System.Drawing.Point(4, 25);
            this.Modbus.Name = "Modbus";
            this.Modbus.Padding = new System.Windows.Forms.Padding(3);
            this.Modbus.Size = new System.Drawing.Size(293, 584);
            this.Modbus.TabIndex = 1;
            this.Modbus.Text = "MODBUS";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.DimGray;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(30, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Odstęp między znakami";
            // 
            // domainUpDown2
            // 
            this.domainUpDown2.Location = new System.Drawing.Point(60, 44);
            this.domainUpDown2.Name = "domainUpDown2";
            this.domainUpDown2.Size = new System.Drawing.Size(120, 22);
            this.domainUpDown2.TabIndex = 13;
            this.domainUpDown2.Text = "SlaveDomainTimeLimit";
            this.domainUpDown2.SelectedItemChanged += new System.EventHandler(this.domainUpDown2_SelectedItemChanged);
            // 
            // MasterPanel
            // 
            this.MasterPanel.Controls.Add(this.label6);
            this.MasterPanel.Controls.Add(this.domainUpDown1);
            this.MasterPanel.Controls.Add(this.label5);
            this.MasterPanel.Controls.Add(this.SlaveButtonRadio);
            this.MasterPanel.Location = new System.Drawing.Point(14, 91);
            this.MasterPanel.Name = "MasterPanel";
            this.MasterPanel.Size = new System.Drawing.Size(260, 105);
            this.MasterPanel.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.DimGray;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(26, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Adres";
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.Location = new System.Drawing.Point(127, 49);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(120, 22);
            this.domainUpDown1.TabIndex = 12;
            this.domainUpDown1.Text = "SlaveDomainAdres";
            this.domainUpDown1.SelectedItemChanged += new System.EventHandler(this.domainUpDown1_SelectedItemChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.DimGray;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label5.Location = new System.Drawing.Point(57, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 29);
            this.label5.TabIndex = 11;
            this.label5.Text = "Slave";
            // 
            // SlaveButtonRadio
            // 
            this.SlaveButtonRadio.AutoSize = true;
            this.SlaveButtonRadio.Location = new System.Drawing.Point(4, 4);
            this.SlaveButtonRadio.Name = "SlaveButtonRadio";
            this.SlaveButtonRadio.Size = new System.Drawing.Size(17, 16);
            this.SlaveButtonRadio.TabIndex = 0;
            this.SlaveButtonRadio.TabStop = true;
            this.SlaveButtonRadio.UseVisualStyleBackColor = true;
            // 
            // SlavePanel
            // 
            this.SlavePanel.Controls.Add(this.label9);
            this.SlavePanel.Controls.Add(this.label8);
            this.SlavePanel.Controls.Add(this.domainUpDown4);
            this.SlavePanel.Controls.Add(this.domainUpDown3);
            this.SlavePanel.Controls.Add(this.label1);
            this.SlavePanel.Controls.Add(this.MasterButtonRadio);
            this.SlavePanel.Location = new System.Drawing.Point(14, 222);
            this.SlavePanel.Name = "SlavePanel";
            this.SlavePanel.Size = new System.Drawing.Size(260, 144);
            this.SlavePanel.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.DimGray;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label9.Location = new System.Drawing.Point(16, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 20);
            this.label9.TabIndex = 17;
            this.label9.Text = "Retranmisje";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.DimGray;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label8.Location = new System.Drawing.Point(16, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Rozkaz";
            // 
            // domainUpDown4
            // 
            this.domainUpDown4.Location = new System.Drawing.Point(127, 100);
            this.domainUpDown4.Name = "domainUpDown4";
            this.domainUpDown4.Size = new System.Drawing.Size(120, 22);
            this.domainUpDown4.TabIndex = 15;
            this.domainUpDown4.Text = "MasterRetranmission";
            this.domainUpDown4.SelectedItemChanged += new System.EventHandler(this.domainUpDown4_SelectedItemChanged);
            // 
            // domainUpDown3
            // 
            this.domainUpDown3.Location = new System.Drawing.Point(127, 57);
            this.domainUpDown3.Name = "domainUpDown3";
            this.domainUpDown3.Size = new System.Drawing.Size(120, 22);
            this.domainUpDown3.TabIndex = 14;
            this.domainUpDown3.Text = "MasterOrder";
            this.domainUpDown3.SelectedItemChanged += new System.EventHandler(this.domainUpDown3_SelectedItemChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(48, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 29);
            this.label1.TabIndex = 10;
            this.label1.Text = "Master";
            // 
            // MasterButtonRadio
            // 
            this.MasterButtonRadio.AutoSize = true;
            this.MasterButtonRadio.Location = new System.Drawing.Point(4, 3);
            this.MasterButtonRadio.Name = "MasterButtonRadio";
            this.MasterButtonRadio.Size = new System.Drawing.Size(17, 16);
            this.MasterButtonRadio.TabIndex = 1;
            this.MasterButtonRadio.TabStop = true;
            this.MasterButtonRadio.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // ConnectionPanel
            // 
            this.ConnectionPanel.Controls.Add(this.panel1);
            this.ConnectionPanel.Controls.Add(this.panel3);
            this.ConnectionPanel.Controls.Add(this.label3);
            this.ConnectionPanel.Location = new System.Drawing.Point(18, 12);
            this.ConnectionPanel.Name = "ConnectionPanel";
            this.ConnectionPanel.Size = new System.Drawing.Size(241, 276);
            this.ConnectionPanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.TimePing);
            this.panel1.Controls.Add(this.PingButton);
            this.panel1.Location = new System.Drawing.Point(3, 170);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 92);
            this.panel1.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.DimGray;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label10.Location = new System.Drawing.Point(115, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 15);
            this.label10.TabIndex = 4;
            this.label10.Text = "ms";
            // 
            // TimePing
            // 
            this.TimePing.Location = new System.Drawing.Point(9, 19);
            this.TimePing.Name = "TimePing";
            this.TimePing.Size = new System.Drawing.Size(100, 22);
            this.TimePing.TabIndex = 8;
            // 
            // PingButton
            // 
            this.PingButton.Location = new System.Drawing.Point(11, 47);
            this.PingButton.Name = "PingButton";
            this.PingButton.Size = new System.Drawing.Size(109, 37);
            this.PingButton.TabIndex = 0;
            this.PingButton.Text = "PING";
            this.PingButton.UseVisualStyleBackColor = true;
            this.PingButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ConnectRadioButton);
            this.panel3.Controls.Add(this.ConnectButton);
            this.panel3.Controls.Add(this.PortList);
            this.panel3.Location = new System.Drawing.Point(6, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(222, 141);
            this.panel3.TabIndex = 2;
            // 
            // ConnectRadioButton
            // 
            this.ConnectRadioButton.AutoSize = true;
            this.ConnectRadioButton.Location = new System.Drawing.Point(112, 40);
            this.ConnectRadioButton.Name = "ConnectRadioButton";
            this.ConnectRadioButton.Size = new System.Drawing.Size(95, 21);
            this.ConnectRadioButton.TabIndex = 0;
            this.ConnectRadioButton.TabStop = true;
            this.ConnectRadioButton.Text = "Połączono";
            this.ConnectRadioButton.UseVisualStyleBackColor = true;
            this.ConnectRadioButton.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(48, 67);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(111, 35);
            this.ConnectButton.TabIndex = 2;
            this.ConnectButton.Text = "Połącz";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectPing_Click);
            // 
            // PortList
            // 
            this.PortList.FormattingEnabled = true;
            this.PortList.ItemHeight = 16;
            this.PortList.Location = new System.Drawing.Point(0, 41);
            this.PortList.Name = "PortList";
            this.PortList.Size = new System.Drawing.Size(111, 20);
            this.PortList.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DimGray;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(21, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Połączenie";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // RSReceivePanel
            // 
            this.RSReceivePanel.BackColor = System.Drawing.Color.Gray;
            this.RSReceivePanel.Controls.Add(this.ReceiveLabelASCII);
            this.RSReceivePanel.Controls.Add(this.ReceiveLabeFrame);
            this.RSReceivePanel.Controls.Add(this.ReceiveTextPanelFrame);
            this.RSReceivePanel.Controls.Add(this.ReceiveTextPanelASCII);
            this.RSReceivePanel.Controls.Add(this.ReceiveLabel);
            this.RSReceivePanel.Location = new System.Drawing.Point(339, 322);
            this.RSReceivePanel.Name = "RSReceivePanel";
            this.RSReceivePanel.Size = new System.Drawing.Size(846, 283);
            this.RSReceivePanel.TabIndex = 1;
            // 
            // ReceiveLabelASCII
            // 
            this.ReceiveLabelASCII.AutoSize = true;
            this.ReceiveLabelASCII.BackColor = System.Drawing.Color.DimGray;
            this.ReceiveLabelASCII.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ReceiveLabelASCII.Location = new System.Drawing.Point(136, 16);
            this.ReceiveLabelASCII.Name = "ReceiveLabelASCII";
            this.ReceiveLabelASCII.Size = new System.Drawing.Size(97, 20);
            this.ReceiveLabelASCII.TabIndex = 8;
            this.ReceiveLabelASCII.Text = "Wiadomość";
            // 
            // ReceiveLabeFrame
            // 
            this.ReceiveLabeFrame.AutoSize = true;
            this.ReceiveLabeFrame.BackColor = System.Drawing.Color.DimGray;
            this.ReceiveLabeFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ReceiveLabeFrame.Location = new System.Drawing.Point(620, 16);
            this.ReceiveLabeFrame.Name = "ReceiveLabeFrame";
            this.ReceiveLabeFrame.Size = new System.Drawing.Size(61, 20);
            this.ReceiveLabeFrame.TabIndex = 7;
            this.ReceiveLabeFrame.Text = "Ramka";
            // 
            // ReceiveTextPanelFrame
            // 
            this.ReceiveTextPanelFrame.Location = new System.Drawing.Point(415, 39);
            this.ReceiveTextPanelFrame.Multiline = true;
            this.ReceiveTextPanelFrame.Name = "ReceiveTextPanelFrame";
            this.ReceiveTextPanelFrame.ReadOnly = true;
            this.ReceiveTextPanelFrame.Size = new System.Drawing.Size(407, 208);
            this.ReceiveTextPanelFrame.TabIndex = 6;
            // 
            // ReceiveTextPanelASCII
            // 
            this.ReceiveTextPanelASCII.Location = new System.Drawing.Point(23, 39);
            this.ReceiveTextPanelASCII.Multiline = true;
            this.ReceiveTextPanelASCII.Name = "ReceiveTextPanelASCII";
            this.ReceiveTextPanelASCII.ReadOnly = true;
            this.ReceiveTextPanelASCII.Size = new System.Drawing.Size(361, 208);
            this.ReceiveTextPanelASCII.TabIndex = 5;
            // 
            // ReceiveLabel
            // 
            this.ReceiveLabel.AutoSize = true;
            this.ReceiveLabel.BackColor = System.Drawing.Color.DimGray;
            this.ReceiveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.ReceiveLabel.Location = new System.Drawing.Point(317, 0);
            this.ReceiveLabel.Name = "ReceiveLabel";
            this.ReceiveLabel.Size = new System.Drawing.Size(181, 29);
            this.ReceiveLabel.TabIndex = 4;
            this.ReceiveLabel.Text = "Odbiór Danych";
            // 
            // RSSendingPanel
            // 
            this.RSSendingPanel.BackColor = System.Drawing.Color.Gray;
            this.RSSendingPanel.Controls.Add(this.SendingLabelFrame);
            this.RSSendingPanel.Controls.Add(this.SendingLabelASCII);
            this.RSSendingPanel.Controls.Add(this.SendButton);
            this.RSSendingPanel.Controls.Add(this.textBox1);
            this.RSSendingPanel.Controls.Add(this.SendTextPanelFrame);
            this.RSSendingPanel.Controls.Add(this.SendTextPanelASCII);
            this.RSSendingPanel.Controls.Add(this.label2);
            this.RSSendingPanel.Location = new System.Drawing.Point(339, 631);
            this.RSSendingPanel.Name = "RSSendingPanel";
            this.RSSendingPanel.Size = new System.Drawing.Size(846, 373);
            this.RSSendingPanel.TabIndex = 2;
            // 
            // SendingLabelFrame
            // 
            this.SendingLabelFrame.AutoSize = true;
            this.SendingLabelFrame.BackColor = System.Drawing.Color.DimGray;
            this.SendingLabelFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SendingLabelFrame.Location = new System.Drawing.Point(636, 102);
            this.SendingLabelFrame.Name = "SendingLabelFrame";
            this.SendingLabelFrame.Size = new System.Drawing.Size(61, 20);
            this.SendingLabelFrame.TabIndex = 9;
            this.SendingLabelFrame.Text = "Ramka";
            // 
            // SendingLabelASCII
            // 
            this.SendingLabelASCII.AutoSize = true;
            this.SendingLabelASCII.BackColor = System.Drawing.Color.DimGray;
            this.SendingLabelASCII.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SendingLabelASCII.Location = new System.Drawing.Point(164, 102);
            this.SendingLabelASCII.Name = "SendingLabelASCII";
            this.SendingLabelASCII.Size = new System.Drawing.Size(97, 20);
            this.SendingLabelASCII.TabIndex = 9;
            this.SendingLabelASCII.Text = "Wiadomość";
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(445, 56);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(131, 34);
            this.SendButton.TabIndex = 9;
            this.SendButton.Text = "Wyślij";
            this.SendButton.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(31, 62);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(353, 22);
            this.textBox1.TabIndex = 8;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // SendTextPanelFrame
            // 
            this.SendTextPanelFrame.Location = new System.Drawing.Point(429, 125);
            this.SendTextPanelFrame.Multiline = true;
            this.SendTextPanelFrame.Name = "SendTextPanelFrame";
            this.SendTextPanelFrame.ReadOnly = true;
            this.SendTextPanelFrame.Size = new System.Drawing.Size(393, 208);
            this.SendTextPanelFrame.TabIndex = 7;
            // 
            // SendTextPanelASCII
            // 
            this.SendTextPanelASCII.Location = new System.Drawing.Point(23, 125);
            this.SendTextPanelASCII.Multiline = true;
            this.SendTextPanelASCII.Name = "SendTextPanelASCII";
            this.SendTextPanelASCII.ReadOnly = true;
            this.SendTextPanelASCII.Size = new System.Drawing.Size(364, 208);
            this.SendTextPanelASCII.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DimGray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(317, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Wysyłanie Danych";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gray;
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.LogOutput);
            this.panel4.Controls.Add(this.LogIpunt);
            this.panel4.Controls.Add(this.LogLabel);
            this.panel4.Location = new System.Drawing.Point(339, 21);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(846, 267);
            this.panel4.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DimGray;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label4.Location = new System.Drawing.Point(519, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 29);
            this.label4.TabIndex = 7;
            this.label4.Text = "LogOutput";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // LogOutput
            // 
            this.LogOutput.Location = new System.Drawing.Point(415, 36);
            this.LogOutput.Multiline = true;
            this.LogOutput.Name = "LogOutput";
            this.LogOutput.ReadOnly = true;
            this.LogOutput.Size = new System.Drawing.Size(402, 208);
            this.LogOutput.TabIndex = 6;
            // 
            // LogIpunt
            // 
            this.LogIpunt.Location = new System.Drawing.Point(32, 36);
            this.LogIpunt.Multiline = true;
            this.LogIpunt.Name = "LogIpunt";
            this.LogIpunt.ReadOnly = true;
            this.LogIpunt.Size = new System.Drawing.Size(352, 208);
            this.LogIpunt.TabIndex = 5;
            // 
            // LogLabel
            // 
            this.LogLabel.AutoSize = true;
            this.LogLabel.BackColor = System.Drawing.Color.DimGray;
            this.LogLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.LogLabel.Location = new System.Drawing.Point(135, 4);
            this.LogLabel.Name = "LogLabel";
            this.LogLabel.Size = new System.Drawing.Size(110, 29);
            this.LogLabel.TabIndex = 4;
            this.LogLabel.Text = "LogInput";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1197, 1020);
            this.Controls.Add(this.RSSendingPanel);
            this.Controls.Add(this.ConnectionPanel);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.RSReceivePanel);
            this.Controls.Add(this.TabControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.TabControl.ResumeLayout(false);
            this.RS.ResumeLayout(false);
            this.RSSettingPanel.ResumeLayout(false);
            this.SettingPanel.ResumeLayout(false);
            this.SettingPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.TerminatorPanel.ResumeLayout(false);
            this.TerminatorPanel.PerformLayout();
            this.TerminatorPanelCustom.ResumeLayout(false);
            this.TerminatorPanelCustom.PerformLayout();
            this.Modbus.ResumeLayout(false);
            this.Modbus.PerformLayout();
            this.MasterPanel.ResumeLayout(false);
            this.MasterPanel.PerformLayout();
            this.SlavePanel.ResumeLayout(false);
            this.SlavePanel.PerformLayout();
            this.ConnectionPanel.ResumeLayout(false);
            this.ConnectionPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.RSReceivePanel.ResumeLayout(false);
            this.RSReceivePanel.PerformLayout();
            this.RSSendingPanel.ResumeLayout(false);
            this.RSSendingPanel.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage Modbus;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.TabPage RS;
        private System.Windows.Forms.Panel RSSettingPanel;
        private System.Windows.Forms.Panel SettingPanel;
        private System.Windows.Forms.Label SettingLabelControl;
        private System.Windows.Forms.ListBox SettingListControlFlew;
        private System.Windows.Forms.Label SettingLabelSign;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label SettingLabelBitStop;
        private System.Windows.Forms.Label SettingLabelControlBit;
        private System.Windows.Forms.Label SettingLabelDataPool;
        private System.Windows.Forms.ListBox SettingListStop;
        private System.Windows.Forms.ListBox SettingListParity;
        private System.Windows.Forms.ListBox SettingListBitDataPool;
        private System.Windows.Forms.Label SettingLabelSpeed;
        private System.Windows.Forms.ListBox SettingListSpeed;
        private System.Windows.Forms.Label SettingLabelMain;
        private System.Windows.Forms.Panel TerminatorPanel;
        private System.Windows.Forms.Label RSTerminatorLabel2;
        private System.Windows.Forms.TextBox RSTerminatorTextCurrent;
        private System.Windows.Forms.RadioButton RSTerminatorButtonCRLF;
        private System.Windows.Forms.Panel TerminatorPanelCustom;
        private System.Windows.Forms.RadioButton RSTerminatorButtonCustom;
        private System.Windows.Forms.Button RSTerminatorButtonCustomAccept;
        private System.Windows.Forms.TextBox RSTerminatorTextCustom;
        private System.Windows.Forms.RadioButton RSTerminatorButtonLF;
        private System.Windows.Forms.RadioButton RSTerminatorButtonCR;
        private System.Windows.Forms.RadioButton RSTerminatorButtonNone;
        private System.Windows.Forms.Label RSTerminatorLabel;
        private System.Windows.Forms.Panel MasterPanel;
        private System.Windows.Forms.DomainUpDown domainUpDown2;
        private System.Windows.Forms.DomainUpDown domainUpDown1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton SlaveButtonRadio;
        private System.Windows.Forms.Panel SlavePanel;
        private System.Windows.Forms.DomainUpDown domainUpDown4;
        private System.Windows.Forms.DomainUpDown domainUpDown3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton MasterButtonRadio;
        private System.Windows.Forms.Panel ConnectionPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button PingButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton ConnectRadioButton;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.ListBox PortList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel RSReceivePanel;
        private System.Windows.Forms.Label ReceiveLabelASCII;
        private System.Windows.Forms.Label ReceiveLabeFrame;
        private System.Windows.Forms.TextBox ReceiveTextPanelFrame;
        private System.Windows.Forms.TextBox ReceiveTextPanelASCII;
        private System.Windows.Forms.Label ReceiveLabel;
        private System.Windows.Forms.Panel RSSendingPanel;
        private System.Windows.Forms.Label SendingLabelFrame;
        private System.Windows.Forms.Label SendingLabelASCII;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox SendTextPanelFrame;
        private System.Windows.Forms.TextBox SendTextPanelASCII;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox LogOutput;
        private System.Windows.Forms.TextBox LogIpunt;
        private System.Windows.Forms.Label LogLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TimePing;
        private System.Windows.Forms.Label label10;
    }
}

