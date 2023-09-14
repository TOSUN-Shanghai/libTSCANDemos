namespace TSCANDLL_CSHARP
{
    partial class frmTSCANDemo
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTSCANDemo));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cbbTSCANDeviceList = new System.Windows.Forms.ComboBox();
            this.tbManufacture = new System.Windows.Forms.TextBox();
            this.tbProduct = new System.Windows.Forms.TextBox();
            this.tbSerial = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsMsgInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbHandle = new System.Windows.Forms.TextBox();
            this.lblConnectManage = new System.Windows.Forms.Label();
            this.btnRegisterConnecttedCallback = new System.Windows.Forms.Button();
            this.btnUnRegisterDisConnecttedCallback = new System.Windows.Forms.Button();
            this.btnUnregisterConnecttedCallback = new System.Windows.Forms.Button();
            this.btnRegisterDisConnecttedCallback = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.lblMotorType = new System.Windows.Forms.Label();
            this.cbScheduleTables = new System.Windows.Forms.ComboBox();
            this.button9 = new System.Windows.Forms.Button();
            this.cbMDorMR = new System.Windows.Forms.ComboBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.rBStop = new System.Windows.Forms.RadioButton();
            this.rbTilt = new System.Windows.Forms.RadioButton();
            this.rBClose = new System.Windows.Forms.RadioButton();
            this.rBOpen = new System.Windows.Forms.RadioButton();
            this.btnAsynLINMsg = new System.Windows.Forms.Button();
            this.btnUnRegisterLINRxCallback = new System.Windows.Forms.Button();
            this.btnRegisterLINRxRecall = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnClearStatistics = new System.Windows.Forms.Button();
            this.lblStatisticValue = new System.Windows.Forms.Label();
            this.cbbStatisticType = new System.Windows.Forms.ComboBox();
            this.btnGetStatistics = new System.Windows.Forms.Button();
            this.btnStartBusStatistics = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDemoName = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.lblDeviceNum = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button19 = new System.Windows.Forms.Button();
            this.label34 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.button18 = new System.Windows.Forms.Button();
            this.btnReceiveFDCANTxRxMessageFromBuffer = new System.Windows.Forms.Button();
            this.btnUnRegisterClassicCANRxRecall = new System.Windows.Forms.Button();
            this.btnRegisterClassicCANRxRecall = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.btnReceiveClassicCANRxMessageFromBuffer = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.btnReceiveCANTxRxMessageFromBuffer = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnReceiveFDCANRxMessageFromBuffer = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnRegisterFDCANRxRecall = new System.Windows.Forms.Button();
            this.btnUnRegisterFDCANRxRecall = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label33 = new System.Windows.Forms.Label();
            this.tBFDDatas = new System.Windows.Forms.TextBox();
            this.cbbFDDLC = new System.Windows.Forms.ComboBox();
            this.tBFDFrameID = new System.Windows.Forms.TextBox();
            this.lblFDDLC = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.rBFDExt = new System.Windows.Forms.RadioButton();
            this.rbFDStd = new System.Windows.Forms.RadioButton();
            this.grpFDModeSelect = new System.Windows.Forms.GroupBox();
            this.rBFD = new System.Windows.Forms.RadioButton();
            this.rBClassic = new System.Windows.Forms.RadioButton();
            this.chkBRS = new System.Windows.Forms.CheckBox();
            this.btnSyncSendCANFDMessage = new System.Windows.Forms.Button();
            this.btnASyncSendCANFDMessage = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnStartCyclicCANFD = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.btnStopCyclicCANFD = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.btnCANFDSwTimer = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button20 = new System.Windows.Forms.Button();
            this.chkEnableCANFDMonitor = new System.Windows.Forms.CheckBox();
            this.rBReadFIFO = new System.Windows.Forms.RadioButton();
            this.rBRecallFunction = new System.Windows.Forms.RadioButton();
            this.cbbCANFDControllerMode = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.btnCANFDConfig = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.cbbCANFDArbBaudrate = new System.Windows.Forms.ComboBox();
            this.cbbCANFDDataBaudrate = new System.Windows.Forms.ComboBox();
            this.chkEnableCANFDResistor = new System.Windows.Forms.CheckBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.cbbCANFDChannel = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnUnregisterCANRxRecall = new System.Windows.Forms.Button();
            this.btnRegisterCANRecall = new System.Windows.Forms.Button();
            this.btnReceiveCANMessages = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.button14 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnStartSWTimer = new System.Windows.Forms.Button();
            this.btnStopCyclicSendMsg = new System.Windows.Forms.Button();
            this.btnASyncSendCANMsg = new System.Windows.Forms.Button();
            this.btnSyncSendCANMsg = new System.Windows.Forms.Button();
            this.btnStartCyclicSendMsg = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAsyncSendCANMsg = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblStartCyclicMsg = new System.Windows.Forms.Label();
            this.lblSyncSendCANMsg = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button12 = new System.Windows.Forms.Button();
            this.cbbChannelIndex = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkEnableTerminaResistor = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbCANBaudrate = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.cbbSeedAndKeyLevel = new System.Windows.Forms.ComboBox();
            this.button17 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpTrace = new System.Windows.Forms.GroupBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tBLog = new System.Windows.Forms.TextBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.tmrTrace = new System.Windows.Forms.Timer(this.components);
            this.tmrReadFIFO = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.grpFDModeSelect.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(123, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(206, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "连接设备";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(578, 70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "获取设备信息";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(123, 70);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(206, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "扫描设备";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cbbTSCANDeviceList
            // 
            this.cbbTSCANDeviceList.FormattingEnabled = true;
            this.cbbTSCANDeviceList.Location = new System.Drawing.Point(405, 70);
            this.cbbTSCANDeviceList.Name = "cbbTSCANDeviceList";
            this.cbbTSCANDeviceList.Size = new System.Drawing.Size(108, 20);
            this.cbbTSCANDeviceList.TabIndex = 3;
            // 
            // tbManufacture
            // 
            this.tbManufacture.Location = new System.Drawing.Point(730, 70);
            this.tbManufacture.Name = "tbManufacture";
            this.tbManufacture.Size = new System.Drawing.Size(108, 21);
            this.tbManufacture.TabIndex = 4;
            // 
            // tbProduct
            // 
            this.tbProduct.Location = new System.Drawing.Point(844, 70);
            this.tbProduct.Name = "tbProduct";
            this.tbProduct.Size = new System.Drawing.Size(108, 21);
            this.tbProduct.TabIndex = 5;
            // 
            // tbSerial
            // 
            this.tbSerial.Location = new System.Drawing.Point(730, 97);
            this.tbSerial.Name = "tbSerial";
            this.tbSerial.Size = new System.Drawing.Size(108, 21);
            this.tbSerial.TabIndex = 6;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(123, 132);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(206, 23);
            this.button6.TabIndex = 10;
            this.button6.Text = "断开设备";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMsgInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 685);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1243, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsMsgInfo
            // 
            this.tsMsgInfo.Name = "tsMsgInfo";
            this.tsMsgInfo.Size = new System.Drawing.Size(87, 17);
            this.tsMsgInfo.Text = "TSCAN Demo";
            // 
            // tbHandle
            // 
            this.tbHandle.Location = new System.Drawing.Point(405, 105);
            this.tbHandle.Name = "tbHandle";
            this.tbHandle.Size = new System.Drawing.Size(108, 21);
            this.tbHandle.TabIndex = 12;
            // 
            // lblConnectManage
            // 
            this.lblConnectManage.AutoSize = true;
            this.lblConnectManage.Location = new System.Drawing.Point(130, 206);
            this.lblConnectManage.Name = "lblConnectManage";
            this.lblConnectManage.Size = new System.Drawing.Size(269, 12);
            this.lblConnectManage.TabIndex = 19;
            this.lblConnectManage.Text = "注册回调函数后，系统自动监测设备连接断开状态";
            // 
            // btnRegisterConnecttedCallback
            // 
            this.btnRegisterConnecttedCallback.Location = new System.Drawing.Point(127, 221);
            this.btnRegisterConnecttedCallback.Name = "btnRegisterConnecttedCallback";
            this.btnRegisterConnecttedCallback.Size = new System.Drawing.Size(202, 23);
            this.btnRegisterConnecttedCallback.TabIndex = 15;
            this.btnRegisterConnecttedCallback.Text = "注册连接成功回调函数";
            this.btnRegisterConnecttedCallback.UseVisualStyleBackColor = true;
            this.btnRegisterConnecttedCallback.Click += new System.EventHandler(this.btnRegisterConnecttedRecall_Click);
            // 
            // btnUnRegisterDisConnecttedCallback
            // 
            this.btnUnRegisterDisConnecttedCallback.Location = new System.Drawing.Point(335, 250);
            this.btnUnRegisterDisConnecttedCallback.Name = "btnUnRegisterDisConnecttedCallback";
            this.btnUnRegisterDisConnecttedCallback.Size = new System.Drawing.Size(222, 23);
            this.btnUnRegisterDisConnecttedCallback.TabIndex = 18;
            this.btnUnRegisterDisConnecttedCallback.Text = "反注册断开连接成功回调函数";
            this.btnUnRegisterDisConnecttedCallback.UseVisualStyleBackColor = true;
            this.btnUnRegisterDisConnecttedCallback.Click += new System.EventHandler(this.btnUnRegisterDisConnecttedCallback_Click);
            // 
            // btnUnregisterConnecttedCallback
            // 
            this.btnUnregisterConnecttedCallback.Location = new System.Drawing.Point(335, 221);
            this.btnUnregisterConnecttedCallback.Name = "btnUnregisterConnecttedCallback";
            this.btnUnregisterConnecttedCallback.Size = new System.Drawing.Size(222, 23);
            this.btnUnregisterConnecttedCallback.TabIndex = 16;
            this.btnUnregisterConnecttedCallback.Text = "反注册连接成功回调函数";
            this.btnUnregisterConnecttedCallback.UseVisualStyleBackColor = true;
            this.btnUnregisterConnecttedCallback.Click += new System.EventHandler(this.btnUnregisterConnecttedCallback_Click);
            // 
            // btnRegisterDisConnecttedCallback
            // 
            this.btnRegisterDisConnecttedCallback.Location = new System.Drawing.Point(127, 250);
            this.btnRegisterDisConnecttedCallback.Name = "btnRegisterDisConnecttedCallback";
            this.btnRegisterDisConnecttedCallback.Size = new System.Drawing.Size(202, 23);
            this.btnRegisterDisConnecttedCallback.TabIndex = 17;
            this.btnRegisterDisConnecttedCallback.Text = "注册断开连接回调函数";
            this.btnRegisterDisConnecttedCallback.UseVisualStyleBackColor = true;
            this.btnRegisterDisConnecttedCallback.Click += new System.EventHandler(this.btnRegisterDisConnecttedCallback_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(103, 179);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(200, 25);
            this.button11.TabIndex = 14;
            this.button11.Text = "button11";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.Button11_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(103, 150);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(202, 23);
            this.button10.TabIndex = 13;
            this.button10.Text = "Stop";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.Button10_Click);
            // 
            // lblMotorType
            // 
            this.lblMotorType.AutoSize = true;
            this.lblMotorType.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMotorType.Location = new System.Drawing.Point(15, 88);
            this.lblMotorType.Name = "lblMotorType";
            this.lblMotorType.Size = new System.Drawing.Size(82, 12);
            this.lblMotorType.TabIndex = 12;
            this.lblMotorType.Text = "Motor Types";
            // 
            // cbScheduleTables
            // 
            this.cbScheduleTables.FormattingEnabled = true;
            this.cbScheduleTables.Items.AddRange(new object[] {
            "YETI/TIGUAN",
            "MQB371",
            "MQB373"});
            this.cbScheduleTables.Location = new System.Drawing.Point(103, 80);
            this.cbScheduleTables.Name = "cbScheduleTables";
            this.cbScheduleTables.Size = new System.Drawing.Size(200, 20);
            this.cbScheduleTables.TabIndex = 11;
            this.cbScheduleTables.SelectedIndexChanged += new System.EventHandler(this.CbMotorTypes_SelectedIndexChanged);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(349, 181);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(202, 23);
            this.button9.TabIndex = 10;
            this.button9.Text = "任意帧测试";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.Button9_Click);
            // 
            // cbMDorMR
            // 
            this.cbMDorMR.FormattingEnabled = true;
            this.cbMDorMR.Items.AddRange(new object[] {
            "天窗电机",
            "遮阳帘电机"});
            this.cbMDorMR.Location = new System.Drawing.Point(246, 106);
            this.cbMDorMR.Name = "cbMDorMR";
            this.cbMDorMR.Size = new System.Drawing.Size(57, 20);
            this.cbMDorMR.TabIndex = 9;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(349, 150);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(202, 22);
            this.button8.TabIndex = 8;
            this.button8.Text = "MRInitial";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.Button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(349, 106);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(202, 23);
            this.button7.TabIndex = 7;
            this.button7.Text = "MDInitial";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.Button7_Click);
            // 
            // rBStop
            // 
            this.rBStop.AutoSize = true;
            this.rBStop.Checked = true;
            this.rBStop.Location = new System.Drawing.Point(177, 128);
            this.rBStop.Name = "rBStop";
            this.rBStop.Size = new System.Drawing.Size(47, 16);
            this.rBStop.TabIndex = 6;
            this.rBStop.TabStop = true;
            this.rBStop.Text = "Stop";
            this.rBStop.UseVisualStyleBackColor = true;
            // 
            // rbTilt
            // 
            this.rbTilt.AutoSize = true;
            this.rbTilt.Location = new System.Drawing.Point(177, 106);
            this.rbTilt.Name = "rbTilt";
            this.rbTilt.Size = new System.Drawing.Size(47, 16);
            this.rbTilt.TabIndex = 5;
            this.rbTilt.TabStop = true;
            this.rbTilt.Text = "Tilt";
            this.rbTilt.UseVisualStyleBackColor = true;
            // 
            // rBClose
            // 
            this.rBClose.AutoSize = true;
            this.rBClose.Location = new System.Drawing.Point(109, 128);
            this.rBClose.Name = "rBClose";
            this.rBClose.Size = new System.Drawing.Size(53, 16);
            this.rBClose.TabIndex = 4;
            this.rBClose.TabStop = true;
            this.rBClose.Text = "Close";
            this.rBClose.UseVisualStyleBackColor = true;
            // 
            // rBOpen
            // 
            this.rBOpen.AutoSize = true;
            this.rBOpen.Location = new System.Drawing.Point(109, 106);
            this.rBOpen.Name = "rBOpen";
            this.rBOpen.Size = new System.Drawing.Size(47, 16);
            this.rBOpen.TabIndex = 3;
            this.rBOpen.TabStop = true;
            this.rBOpen.Text = "Open";
            this.rBOpen.UseVisualStyleBackColor = true;
            // 
            // btnAsynLINMsg
            // 
            this.btnAsynLINMsg.Location = new System.Drawing.Point(349, 77);
            this.btnAsynLINMsg.Name = "btnAsynLINMsg";
            this.btnAsynLINMsg.Size = new System.Drawing.Size(202, 23);
            this.btnAsynLINMsg.TabIndex = 2;
            this.btnAsynLINMsg.Text = "Async Send LIN Message";
            this.btnAsynLINMsg.UseVisualStyleBackColor = true;
            this.btnAsynLINMsg.Click += new System.EventHandler(this.BtnAsynLINMsg_Click);
            // 
            // btnUnRegisterLINRxCallback
            // 
            this.btnUnRegisterLINRxCallback.Location = new System.Drawing.Point(349, 49);
            this.btnUnRegisterLINRxCallback.Name = "btnUnRegisterLINRxCallback";
            this.btnUnRegisterLINRxCallback.Size = new System.Drawing.Size(202, 23);
            this.btnUnRegisterLINRxCallback.TabIndex = 1;
            this.btnUnRegisterLINRxCallback.Text = "UnRegister LIN Rx Callback";
            this.btnUnRegisterLINRxCallback.UseVisualStyleBackColor = true;
            this.btnUnRegisterLINRxCallback.Click += new System.EventHandler(this.BtnUnRegisterLINRxCallback_Click);
            // 
            // btnRegisterLINRxRecall
            // 
            this.btnRegisterLINRxRecall.Location = new System.Drawing.Point(101, 49);
            this.btnRegisterLINRxRecall.Name = "btnRegisterLINRxRecall";
            this.btnRegisterLINRxRecall.Size = new System.Drawing.Size(202, 23);
            this.btnRegisterLINRxRecall.TabIndex = 0;
            this.btnRegisterLINRxRecall.Text = "Register LIN Rx Callback";
            this.btnRegisterLINRxRecall.UseVisualStyleBackColor = true;
            this.btnRegisterLINRxRecall.Click += new System.EventHandler(this.BtnRegisterLINRxRecall_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1037, 496);
            this.tabControl1.TabIndex = 21;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnClearStatistics);
            this.tabPage4.Controls.Add(this.lblStatisticValue);
            this.tabPage4.Controls.Add(this.cbbStatisticType);
            this.tabPage4.Controls.Add(this.btnGetStatistics);
            this.tabPage4.Controls.Add(this.btnStartBusStatistics);
            this.tabPage4.Controls.Add(this.pictureBox1);
            this.tabPage4.Controls.Add(this.lblDemoName);
            this.tabPage4.Controls.Add(this.label30);
            this.tabPage4.Controls.Add(this.lblDeviceNum);
            this.tabPage4.Controls.Add(this.label28);
            this.tabPage4.Controls.Add(this.label27);
            this.tabPage4.Controls.Add(this.label26);
            this.tabPage4.Controls.Add(this.lblConnectManage);
            this.tabPage4.Controls.Add(this.label25);
            this.tabPage4.Controls.Add(this.btnRegisterConnecttedCallback);
            this.tabPage4.Controls.Add(this.btnUnRegisterDisConnecttedCallback);
            this.tabPage4.Controls.Add(this.button2);
            this.tabPage4.Controls.Add(this.btnUnregisterConnecttedCallback);
            this.tabPage4.Controls.Add(this.tbSerial);
            this.tabPage4.Controls.Add(this.btnRegisterDisConnecttedCallback);
            this.tabPage4.Controls.Add(this.button6);
            this.tabPage4.Controls.Add(this.tbProduct);
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Controls.Add(this.tbManufacture);
            this.tabPage4.Controls.Add(this.button3);
            this.tabPage4.Controls.Add(this.tbHandle);
            this.tabPage4.Controls.Add(this.cbbTSCANDeviceList);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1029, 470);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "设备管理";
            this.tabPage4.UseVisualStyleBackColor = true;
            this.tabPage4.Resize += new System.EventHandler(this.tabPage4_Resize);
            // 
            // btnClearStatistics
            // 
            this.btnClearStatistics.Location = new System.Drawing.Point(578, 190);
            this.btnClearStatistics.Name = "btnClearStatistics";
            this.btnClearStatistics.Size = new System.Drawing.Size(146, 23);
            this.btnClearStatistics.TabIndex = 39;
            this.btnClearStatistics.Text = "清除统计数据";
            this.btnClearStatistics.UseVisualStyleBackColor = true;
            this.btnClearStatistics.Click += new System.EventHandler(this.btnClearStatistics_Click);
            // 
            // lblStatisticValue
            // 
            this.lblStatisticValue.AutoSize = true;
            this.lblStatisticValue.Location = new System.Drawing.Point(911, 164);
            this.lblStatisticValue.Name = "lblStatisticValue";
            this.lblStatisticValue.Size = new System.Drawing.Size(17, 12);
            this.lblStatisticValue.TabIndex = 38;
            this.lblStatisticValue.Text = "0%";
            // 
            // cbbStatisticType
            // 
            this.cbbStatisticType.FormattingEnabled = true;
            this.cbbStatisticType.Items.AddRange(new object[] {
            "CAN总线负载率",
            "CAN总线峰值负载率",
            "标准数据帧帧率",
            "所有标准数据帧个数",
            "扩展数据帧帧率",
            "所有扩展数据帧个数",
            "标准远程帧帧率",
            "所有标准远程帧个数",
            "扩展远程帧帧率",
            "所有扩展远程帧个数",
            "错误帧帧率",
            "所有错误帧个数"});
            this.cbbStatisticType.Location = new System.Drawing.Point(730, 161);
            this.cbbStatisticType.Name = "cbbStatisticType";
            this.cbbStatisticType.Size = new System.Drawing.Size(175, 20);
            this.cbbStatisticType.TabIndex = 37;
            // 
            // btnGetStatistics
            // 
            this.btnGetStatistics.Location = new System.Drawing.Point(578, 161);
            this.btnGetStatistics.Name = "btnGetStatistics";
            this.btnGetStatistics.Size = new System.Drawing.Size(146, 23);
            this.btnGetStatistics.TabIndex = 36;
            this.btnGetStatistics.Text = "读取统计数据";
            this.btnGetStatistics.UseVisualStyleBackColor = true;
            this.btnGetStatistics.Click += new System.EventHandler(this.button18_Click);
            // 
            // btnStartBusStatistics
            // 
            this.btnStartBusStatistics.Location = new System.Drawing.Point(578, 132);
            this.btnStartBusStatistics.Name = "btnStartBusStatistics";
            this.btnStartBusStatistics.Size = new System.Drawing.Size(146, 23);
            this.btnStartBusStatistics.TabIndex = 35;
            this.btnStartBusStatistics.Text = "启动总线信息统计";
            this.btnStartBusStatistics.UseVisualStyleBackColor = true;
            this.btnStartBusStatistics.Click += new System.EventHandler(this.btnStartBusStatistics_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TSCANDLL_CSHARP.Properties.Resources.TOSUN_Pic2;
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(108, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // lblDemoName
            // 
            this.lblDemoName.AutoSize = true;
            this.lblDemoName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDemoName.Location = new System.Drawing.Point(291, 21);
            this.lblDemoName.Name = "lblDemoName";
            this.lblDemoName.Size = new System.Drawing.Size(405, 19);
            this.lblDemoName.TabIndex = 34;
            this.lblDemoName.Text = "TOSUN CAN/CANFD/LIN/Flexray API Demo";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(346, 108);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(53, 12);
            this.label30.TabIndex = 33;
            this.label30.Text = "设备句柄";
            // 
            // lblDeviceNum
            // 
            this.lblDeviceNum.AutoSize = true;
            this.lblDeviceNum.Location = new System.Drawing.Point(346, 75);
            this.lblDeviceNum.Name = "lblDeviceNum";
            this.lblDeviceNum.Size = new System.Drawing.Size(53, 12);
            this.lblDeviceNum.TabIndex = 32;
            this.lblDeviceNum.Text = "设备列表";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(29, 137);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(53, 12);
            this.label28.TabIndex = 31;
            this.label28.Text = "断开设备";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(29, 108);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(53, 12);
            this.label27.TabIndex = 30;
            this.label27.Text = "连接设备";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(29, 78);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(53, 12);
            this.label26.TabIndex = 29;
            this.label26.Text = "扫描设备";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(39, 289);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(725, 72);
            this.label25.TabIndex = 28;
            this.label25.Text = resources.GetString("label25.Text");
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1029, 470);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "CANFD API ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.button19);
            this.groupBox7.Controls.Add(this.label34);
            this.groupBox7.Controls.Add(this.label29);
            this.groupBox7.Controls.Add(this.button18);
            this.groupBox7.Controls.Add(this.btnReceiveFDCANTxRxMessageFromBuffer);
            this.groupBox7.Controls.Add(this.btnUnRegisterClassicCANRxRecall);
            this.groupBox7.Controls.Add(this.btnRegisterClassicCANRxRecall);
            this.groupBox7.Controls.Add(this.label18);
            this.groupBox7.Controls.Add(this.btnReceiveClassicCANRxMessageFromBuffer);
            this.groupBox7.Controls.Add(this.label19);
            this.groupBox7.Controls.Add(this.btnReceiveCANTxRxMessageFromBuffer);
            this.groupBox7.Controls.Add(this.label20);
            this.groupBox7.Controls.Add(this.label12);
            this.groupBox7.Controls.Add(this.label21);
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.btnReceiveFDCANRxMessageFromBuffer);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.btnRegisterFDCANRxRecall);
            this.groupBox7.Controls.Add(this.btnUnRegisterFDCANRxRecall);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.Location = new System.Drawing.Point(3, 211);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(1023, 188);
            this.groupBox7.TabIndex = 76;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "报文读取";
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(737, 139);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(230, 23);
            this.button19.TabIndex = 65;
            this.button19.Text = "Clear CAN Tx/Rx Messages";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(534, 144);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(155, 12);
            this.label34.TabIndex = 64;
            this.label34.Text = "清除CAN读取Buffer中的数据";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(6, 144);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(167, 12);
            this.label29.TabIndex = 63;
            this.label29.Text = "清除CANFD读取Buffer中的数据";
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(233, 139);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(230, 23);
            this.button18.TabIndex = 62;
            this.button18.Text = "Clear CANFD Tx/Rx Messages";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click_1);
            // 
            // btnReceiveFDCANTxRxMessageFromBuffer
            // 
            this.btnReceiveFDCANTxRxMessageFromBuffer.Location = new System.Drawing.Point(233, 110);
            this.btnReceiveFDCANTxRxMessageFromBuffer.Name = "btnReceiveFDCANTxRxMessageFromBuffer";
            this.btnReceiveFDCANTxRxMessageFromBuffer.Size = new System.Drawing.Size(230, 23);
            this.btnReceiveFDCANTxRxMessageFromBuffer.TabIndex = 57;
            this.btnReceiveFDCANTxRxMessageFromBuffer.Text = "Receive CANFD Tx/Rx Messages";
            this.btnReceiveFDCANTxRxMessageFromBuffer.UseVisualStyleBackColor = true;
            this.btnReceiveFDCANTxRxMessageFromBuffer.Click += new System.EventHandler(this.btnReceiveFDCANTxRxMessageFromBuffer_Click);
            // 
            // btnUnRegisterClassicCANRxRecall
            // 
            this.btnUnRegisterClassicCANRxRecall.Location = new System.Drawing.Point(737, 46);
            this.btnUnRegisterClassicCANRxRecall.Name = "btnUnRegisterClassicCANRxRecall";
            this.btnUnRegisterClassicCANRxRecall.Size = new System.Drawing.Size(230, 23);
            this.btnUnRegisterClassicCANRxRecall.TabIndex = 41;
            this.btnUnRegisterClassicCANRxRecall.Text = "UnRegister Classic CAN Rx Recall";
            this.btnUnRegisterClassicCANRxRecall.UseVisualStyleBackColor = true;
            this.btnUnRegisterClassicCANRxRecall.Click += new System.EventHandler(this.btnUnRegisterClassicCANRxRecall_Click);
            // 
            // btnRegisterClassicCANRxRecall
            // 
            this.btnRegisterClassicCANRxRecall.Location = new System.Drawing.Point(737, 17);
            this.btnRegisterClassicCANRxRecall.Name = "btnRegisterClassicCANRxRecall";
            this.btnRegisterClassicCANRxRecall.Size = new System.Drawing.Size(230, 23);
            this.btnRegisterClassicCANRxRecall.TabIndex = 40;
            this.btnRegisterClassicCANRxRecall.Text = "Register Classic CAN Rx Recall";
            this.btnRegisterClassicCANRxRecall.UseVisualStyleBackColor = true;
            this.btnRegisterClassicCANRxRecall.Click += new System.EventHandler(this.btnRegisterClassicCANRxRecall_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 115);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(209, 12);
            this.label18.TabIndex = 61;
            this.label18.Text = "读取FD CAN Tx/Rx数据到接收Buffer中";
            // 
            // btnReceiveClassicCANRxMessageFromBuffer
            // 
            this.btnReceiveClassicCANRxMessageFromBuffer.Location = new System.Drawing.Point(737, 81);
            this.btnReceiveClassicCANRxMessageFromBuffer.Name = "btnReceiveClassicCANRxMessageFromBuffer";
            this.btnReceiveClassicCANRxMessageFromBuffer.Size = new System.Drawing.Size(230, 23);
            this.btnReceiveClassicCANRxMessageFromBuffer.TabIndex = 43;
            this.btnReceiveClassicCANRxMessageFromBuffer.Text = "Receive Classic CAN Rx Messages";
            this.btnReceiveClassicCANRxMessageFromBuffer.UseVisualStyleBackColor = true;
            this.btnReceiveClassicCANRxMessageFromBuffer.Click += new System.EventHandler(this.btnReceiveClassicCANRxMessageFromBuffer_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(30, 86);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(167, 12);
            this.label19.TabIndex = 60;
            this.label19.Text = "读取FD CAN Rx数据到Buffer中";
            // 
            // btnReceiveCANTxRxMessageFromBuffer
            // 
            this.btnReceiveCANTxRxMessageFromBuffer.Location = new System.Drawing.Point(737, 110);
            this.btnReceiveCANTxRxMessageFromBuffer.Name = "btnReceiveCANTxRxMessageFromBuffer";
            this.btnReceiveCANTxRxMessageFromBuffer.Size = new System.Drawing.Size(230, 23);
            this.btnReceiveCANTxRxMessageFromBuffer.TabIndex = 44;
            this.btnReceiveCANTxRxMessageFromBuffer.Text = "Receive Classic CAN Tx/Rx Messages";
            this.btnReceiveCANTxRxMessageFromBuffer.UseVisualStyleBackColor = true;
            this.btnReceiveCANTxRxMessageFromBuffer.Click += new System.EventHandler(this.btnReceiveCANTxRxMessageFromBuffer_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(39, 51);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(149, 12);
            this.label20.TabIndex = 59;
            this.label20.Text = "反注册FD CAN接收回调函数";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(534, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(167, 12);
            this.label12.TabIndex = 50;
            this.label12.Text = "注册Classic CAN接收回调函数";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(39, 25);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(137, 12);
            this.label21.TabIndex = 58;
            this.label21.Text = "注册FD CAN接收回调函数";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(534, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(179, 12);
            this.label11.TabIndex = 51;
            this.label11.Text = "反注册Classic CAN接收回调函数";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(534, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(197, 12);
            this.label10.TabIndex = 52;
            this.label10.Text = "读取Classic CAN Rx数据到Buffer中";
            // 
            // btnReceiveFDCANRxMessageFromBuffer
            // 
            this.btnReceiveFDCANRxMessageFromBuffer.Location = new System.Drawing.Point(233, 81);
            this.btnReceiveFDCANRxMessageFromBuffer.Name = "btnReceiveFDCANRxMessageFromBuffer";
            this.btnReceiveFDCANRxMessageFromBuffer.Size = new System.Drawing.Size(230, 23);
            this.btnReceiveFDCANRxMessageFromBuffer.TabIndex = 56;
            this.btnReceiveFDCANRxMessageFromBuffer.Text = "Receive CANFD Rx Messages";
            this.btnReceiveFDCANRxMessageFromBuffer.UseVisualStyleBackColor = true;
            this.btnReceiveFDCANRxMessageFromBuffer.Click += new System.EventHandler(this.btnReceiveFDCANRxMessageFromBuffer_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(492, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(239, 12);
            this.label9.TabIndex = 53;
            this.label9.Text = "读取Classic CAN Tx/Rx数据到接收Buffer中";
            // 
            // btnRegisterFDCANRxRecall
            // 
            this.btnRegisterFDCANRxRecall.Location = new System.Drawing.Point(233, 17);
            this.btnRegisterFDCANRxRecall.Name = "btnRegisterFDCANRxRecall";
            this.btnRegisterFDCANRxRecall.Size = new System.Drawing.Size(230, 23);
            this.btnRegisterFDCANRxRecall.TabIndex = 54;
            this.btnRegisterFDCANRxRecall.Text = "Register CANFD Rx Recall";
            this.btnRegisterFDCANRxRecall.UseVisualStyleBackColor = true;
            this.btnRegisterFDCANRxRecall.Click += new System.EventHandler(this.btnRegisterFDCANRxRecall_Click);
            // 
            // btnUnRegisterFDCANRxRecall
            // 
            this.btnUnRegisterFDCANRxRecall.Location = new System.Drawing.Point(233, 46);
            this.btnUnRegisterFDCANRxRecall.Name = "btnUnRegisterFDCANRxRecall";
            this.btnUnRegisterFDCANRxRecall.Size = new System.Drawing.Size(230, 23);
            this.btnUnRegisterFDCANRxRecall.TabIndex = 55;
            this.btnUnRegisterFDCANRxRecall.Text = "UnRegister CANFD Rx Recall";
            this.btnUnRegisterFDCANRxRecall.UseVisualStyleBackColor = true;
            this.btnUnRegisterFDCANRxRecall.Click += new System.EventHandler(this.btnUnRegisterFDCANRxRecall_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label33);
            this.groupBox6.Controls.Add(this.tBFDDatas);
            this.groupBox6.Controls.Add(this.cbbFDDLC);
            this.groupBox6.Controls.Add(this.tBFDFrameID);
            this.groupBox6.Controls.Add(this.lblFDDLC);
            this.groupBox6.Controls.Add(this.label32);
            this.groupBox6.Controls.Add(this.groupBox9);
            this.groupBox6.Controls.Add(this.groupBox8);
            this.groupBox6.Controls.Add(this.grpFDModeSelect);
            this.groupBox6.Controls.Add(this.chkBRS);
            this.groupBox6.Controls.Add(this.btnSyncSendCANFDMessage);
            this.groupBox6.Controls.Add(this.btnASyncSendCANFDMessage);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.btnStartCyclicCANFD);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.btnStopCyclicCANFD);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.btnCANFDSwTimer);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(3, 80);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1023, 131);
            this.groupBox6.TabIndex = 75;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "发送报文";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(335, 102);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(41, 12);
            this.label33.TabIndex = 81;
            this.label33.Text = "帧数据";
            // 
            // tBFDDatas
            // 
            this.tBFDDatas.Location = new System.Drawing.Point(391, 99);
            this.tBFDDatas.Name = "tBFDDatas";
            this.tBFDDatas.Size = new System.Drawing.Size(630, 21);
            this.tBFDDatas.TabIndex = 80;
            this.tBFDDatas.Text = "112233AABBCCDDEE";
            // 
            // cbbFDDLC
            // 
            this.cbbFDDLC.FormattingEnabled = true;
            this.cbbFDDLC.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cbbFDDLC.Location = new System.Drawing.Point(919, 73);
            this.cbbFDDLC.Name = "cbbFDDLC";
            this.cbbFDDLC.Size = new System.Drawing.Size(102, 20);
            this.cbbFDDLC.TabIndex = 79;
            // 
            // tBFDFrameID
            // 
            this.tBFDFrameID.Location = new System.Drawing.Point(759, 73);
            this.tBFDFrameID.Name = "tBFDFrameID";
            this.tBFDFrameID.Size = new System.Drawing.Size(100, 21);
            this.tBFDFrameID.TabIndex = 78;
            this.tBFDFrameID.Text = "123";
            // 
            // lblFDDLC
            // 
            this.lblFDDLC.AutoSize = true;
            this.lblFDDLC.Location = new System.Drawing.Point(872, 76);
            this.lblFDDLC.Name = "lblFDDLC";
            this.lblFDDLC.Size = new System.Drawing.Size(41, 12);
            this.lblFDDLC.TabIndex = 77;
            this.lblFDDLC.Text = "帧长度";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(724, 76);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(29, 12);
            this.label32.TabIndex = 76;
            this.label32.Text = "帧ID";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.radioButton1);
            this.groupBox9.Controls.Add(this.radioButton2);
            this.groupBox9.Location = new System.Drawing.Point(712, 17);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(147, 46);
            this.groupBox9.TabIndex = 75;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "帧格式";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(79, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(59, 16);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.Text = "远程帧";
            this.radioButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(14, 20);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 16);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "数据帧";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.rBFDExt);
            this.groupBox8.Controls.Add(this.rbFDStd);
            this.groupBox8.Location = new System.Drawing.Point(874, 17);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(147, 46);
            this.groupBox8.TabIndex = 74;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "帧类型";
            // 
            // rBFDExt
            // 
            this.rBFDExt.AutoSize = true;
            this.rBFDExt.Location = new System.Drawing.Point(79, 20);
            this.rBFDExt.Name = "rBFDExt";
            this.rBFDExt.Size = new System.Drawing.Size(59, 16);
            this.rBFDExt.TabIndex = 1;
            this.rBFDExt.Text = "扩展帧";
            this.rBFDExt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rBFDExt.UseVisualStyleBackColor = true;
            // 
            // rbFDStd
            // 
            this.rbFDStd.AutoSize = true;
            this.rbFDStd.Checked = true;
            this.rbFDStd.Location = new System.Drawing.Point(14, 20);
            this.rbFDStd.Name = "rbFDStd";
            this.rbFDStd.Size = new System.Drawing.Size(59, 16);
            this.rbFDStd.TabIndex = 0;
            this.rbFDStd.TabStop = true;
            this.rbFDStd.Text = "标准帧";
            this.rbFDStd.UseVisualStyleBackColor = true;
            // 
            // grpFDModeSelect
            // 
            this.grpFDModeSelect.Controls.Add(this.rBFD);
            this.grpFDModeSelect.Controls.Add(this.rBClassic);
            this.grpFDModeSelect.Location = new System.Drawing.Point(559, 17);
            this.grpFDModeSelect.Name = "grpFDModeSelect";
            this.grpFDModeSelect.Size = new System.Drawing.Size(147, 46);
            this.grpFDModeSelect.TabIndex = 72;
            this.grpFDModeSelect.TabStop = false;
            this.grpFDModeSelect.Text = "FD/CAN帧";
            // 
            // rBFD
            // 
            this.rBFD.AutoSize = true;
            this.rBFD.Checked = true;
            this.rBFD.Location = new System.Drawing.Point(79, 20);
            this.rBFD.Name = "rBFD";
            this.rBFD.Size = new System.Drawing.Size(35, 16);
            this.rBFD.TabIndex = 1;
            this.rBFD.TabStop = true;
            this.rBFD.Text = "FD";
            this.rBFD.UseVisualStyleBackColor = true;
            // 
            // rBClassic
            // 
            this.rBClassic.AutoSize = true;
            this.rBClassic.Location = new System.Drawing.Point(14, 20);
            this.rBClassic.Name = "rBClassic";
            this.rBClassic.Size = new System.Drawing.Size(71, 16);
            this.rBClassic.TabIndex = 0;
            this.rBClassic.Text = "Classic ";
            this.rBClassic.UseVisualStyleBackColor = true;
            this.rBClassic.CheckedChanged += new System.EventHandler(this.rBClassic_CheckedChanged);
            // 
            // chkBRS
            // 
            this.chkBRS.AutoSize = true;
            this.chkBRS.Location = new System.Drawing.Point(568, 75);
            this.chkBRS.Name = "chkBRS";
            this.chkBRS.Size = new System.Drawing.Size(138, 16);
            this.chkBRS.TabIndex = 73;
            this.chkBRS.Text = "BRS(是否可变波特率)";
            this.chkBRS.UseVisualStyleBackColor = true;
            // 
            // btnSyncSendCANFDMessage
            // 
            this.btnSyncSendCANFDMessage.Location = new System.Drawing.Point(385, 23);
            this.btnSyncSendCANFDMessage.Name = "btnSyncSendCANFDMessage";
            this.btnSyncSendCANFDMessage.Size = new System.Drawing.Size(168, 23);
            this.btnSyncSendCANFDMessage.TabIndex = 37;
            this.btnSyncSendCANFDMessage.Text = "Sync Send CAN Message";
            this.btnSyncSendCANFDMessage.UseVisualStyleBackColor = true;
            this.btnSyncSendCANFDMessage.Click += new System.EventHandler(this.btnSendCANFDSync_Click);
            // 
            // btnASyncSendCANFDMessage
            // 
            this.btnASyncSendCANFDMessage.Location = new System.Drawing.Point(125, 26);
            this.btnASyncSendCANFDMessage.Name = "btnASyncSendCANFDMessage";
            this.btnASyncSendCANFDMessage.Size = new System.Drawing.Size(155, 23);
            this.btnASyncSendCANFDMessage.TabIndex = 36;
            this.btnASyncSendCANFDMessage.Text = "ASync Send CAN Message";
            this.btnASyncSendCANFDMessage.UseVisualStyleBackColor = true;
            this.btnASyncSendCANFDMessage.Click += new System.EventHandler(this.btnSendCANFDAsync_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(18, 31);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(95, 12);
            this.label17.TabIndex = 45;
            this.label17.Text = "异步发送CAN报文";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(284, 28);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(95, 12);
            this.label16.TabIndex = 46;
            this.label16.Text = "同步发送CAN报文";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(23, 65);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(101, 12);
            this.label15.TabIndex = 47;
            this.label15.Text = "启动发送周期报文";
            // 
            // btnStartCyclicCANFD
            // 
            this.btnStartCyclicCANFD.Location = new System.Drawing.Point(125, 60);
            this.btnStartCyclicCANFD.Name = "btnStartCyclicCANFD";
            this.btnStartCyclicCANFD.Size = new System.Drawing.Size(155, 23);
            this.btnStartCyclicCANFD.TabIndex = 38;
            this.btnStartCyclicCANFD.Text = "Start Cyclic Send Message";
            this.btnStartCyclicCANFD.UseVisualStyleBackColor = true;
            this.btnStartCyclicCANFD.Click += new System.EventHandler(this.btnStartCyclicCANFD_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(284, 62);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(101, 12);
            this.label14.TabIndex = 48;
            this.label14.Text = "停止发送周期报文";
            // 
            // btnStopCyclicCANFD
            // 
            this.btnStopCyclicCANFD.Location = new System.Drawing.Point(385, 57);
            this.btnStopCyclicCANFD.Name = "btnStopCyclicCANFD";
            this.btnStopCyclicCANFD.Size = new System.Drawing.Size(168, 23);
            this.btnStopCyclicCANFD.TabIndex = 39;
            this.btnStopCyclicCANFD.Text = "Stop Cyclic Send Message";
            this.btnStopCyclicCANFD.UseVisualStyleBackColor = true;
            this.btnStopCyclicCANFD.Click += new System.EventHandler(this.btnStopCyclicCANFD_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 99);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 12);
            this.label13.TabIndex = 49;
            this.label13.Text = "启动软件定时器";
            // 
            // btnCANFDSwTimer
            // 
            this.btnCANFDSwTimer.Location = new System.Drawing.Point(125, 94);
            this.btnCANFDSwTimer.Name = "btnCANFDSwTimer";
            this.btnCANFDSwTimer.Size = new System.Drawing.Size(155, 23);
            this.btnCANFDSwTimer.TabIndex = 42;
            this.btnCANFDSwTimer.Text = "Start Software Timer";
            this.btnCANFDSwTimer.UseVisualStyleBackColor = true;
            this.btnCANFDSwTimer.Click += new System.EventHandler(this.btnCANFDSwTimer_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button20);
            this.groupBox2.Controls.Add(this.chkEnableCANFDMonitor);
            this.groupBox2.Controls.Add(this.rBReadFIFO);
            this.groupBox2.Controls.Add(this.rBRecallFunction);
            this.groupBox2.Controls.Add(this.cbbCANFDControllerMode);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.btnCANFDConfig);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.cbbCANFDArbBaudrate);
            this.groupBox2.Controls.Add(this.cbbCANFDDataBaudrate);
            this.groupBox2.Controls.Add(this.chkEnableCANFDResistor);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.cbbCANFDChannel);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1023, 77);
            this.groupBox2.TabIndex = 74;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "硬件通道配置";
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(686, 48);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(155, 23);
            this.button20.TabIndex = 75;
            this.button20.Text = "Add CAN/CANFD Messae Filter";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // chkEnableCANFDMonitor
            // 
            this.chkEnableCANFDMonitor.AutoSize = true;
            this.chkEnableCANFDMonitor.Location = new System.Drawing.Point(125, 55);
            this.chkEnableCANFDMonitor.Name = "chkEnableCANFDMonitor";
            this.chkEnableCANFDMonitor.Size = new System.Drawing.Size(150, 16);
            this.chkEnableCANFDMonitor.TabIndex = 74;
            this.chkEnableCANFDMonitor.Text = "打开CANFD/CAN报文监测";
            this.chkEnableCANFDMonitor.UseVisualStyleBackColor = true;
            this.chkEnableCANFDMonitor.CheckedChanged += new System.EventHandler(this.chkEnableCANFDMonitor_CheckedChanged);
            // 
            // rBReadFIFO
            // 
            this.rBReadFIFO.AutoSize = true;
            this.rBReadFIFO.Enabled = false;
            this.rBReadFIFO.Location = new System.Drawing.Point(428, 55);
            this.rBReadFIFO.Name = "rBReadFIFO";
            this.rBReadFIFO.Size = new System.Drawing.Size(143, 16);
            this.rBReadFIFO.TabIndex = 73;
            this.rBReadFIFO.Text = "通过读取FIFO监测报文";
            this.rBReadFIFO.UseVisualStyleBackColor = true;
            // 
            // rBRecallFunction
            // 
            this.rBRecallFunction.AutoSize = true;
            this.rBRecallFunction.Checked = true;
            this.rBRecallFunction.Enabled = false;
            this.rBRecallFunction.Location = new System.Drawing.Point(278, 55);
            this.rBRecallFunction.Name = "rBRecallFunction";
            this.rBRecallFunction.Size = new System.Drawing.Size(143, 16);
            this.rBRecallFunction.TabIndex = 72;
            this.rBRecallFunction.TabStop = true;
            this.rBRecallFunction.Text = "通过回调函数监测报文";
            this.rBRecallFunction.UseVisualStyleBackColor = true;
            // 
            // cbbCANFDControllerMode
            // 
            this.cbbCANFDControllerMode.FormattingEnabled = true;
            this.cbbCANFDControllerMode.Items.AddRange(new object[] {
            "Classic CAN(经典CAN)",
            "ISO CANFD",
            "No-ISO CANFD"});
            this.cbbCANFDControllerMode.Location = new System.Drawing.Point(320, 24);
            this.cbbCANFDControllerMode.Name = "cbbCANFDControllerMode";
            this.cbbCANFDControllerMode.Size = new System.Drawing.Size(101, 20);
            this.cbbCANFDControllerMode.TabIndex = 71;
            this.cbbCANFDControllerMode.SelectedIndexChanged += new System.EventHandler(this.cbbCANFDControllerMode_SelectedIndexChanged);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(231, 26);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(83, 12);
            this.label31.TabIndex = 70;
            this.label31.Text = "CAN控制器模式";
            // 
            // btnCANFDConfig
            // 
            this.btnCANFDConfig.Location = new System.Drawing.Point(868, 19);
            this.btnCANFDConfig.Name = "btnCANFDConfig";
            this.btnCANFDConfig.Size = new System.Drawing.Size(153, 23);
            this.btnCANFDConfig.TabIndex = 65;
            this.btnCANFDConfig.Text = "下载CANFD配置参数";
            this.btnCANFDConfig.UseVisualStyleBackColor = true;
            this.btnCANFDConfig.Click += new System.EventHandler(this.btnCANFDHardwareConfig_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(426, 28);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(77, 12);
            this.label23.TabIndex = 62;
            this.label23.Text = "仲裁场波特率";
            // 
            // cbbCANFDArbBaudrate
            // 
            this.cbbCANFDArbBaudrate.FormattingEnabled = true;
            this.cbbCANFDArbBaudrate.Items.AddRange(new object[] {
            "125Kbps",
            "250Kbps",
            "500Kbps",
            "1000Kbps",
            "",
            ""});
            this.cbbCANFDArbBaudrate.Location = new System.Drawing.Point(509, 23);
            this.cbbCANFDArbBaudrate.Name = "cbbCANFDArbBaudrate";
            this.cbbCANFDArbBaudrate.Size = new System.Drawing.Size(75, 20);
            this.cbbCANFDArbBaudrate.TabIndex = 63;
            // 
            // cbbCANFDDataBaudrate
            // 
            this.cbbCANFDDataBaudrate.FormattingEnabled = true;
            this.cbbCANFDDataBaudrate.Items.AddRange(new object[] {
            "125Kbps",
            "250Kbps",
            "500Kbps",
            "1000Kbps",
            "2000Kbps",
            "4000Kbps",
            "5000Kbps",
            "8000Kbps",
            "",
            "",
            "",
            "",
            "",
            ""});
            this.cbbCANFDDataBaudrate.Location = new System.Drawing.Point(686, 23);
            this.cbbCANFDDataBaudrate.Name = "cbbCANFDDataBaudrate";
            this.cbbCANFDDataBaudrate.Size = new System.Drawing.Size(74, 20);
            this.cbbCANFDDataBaudrate.TabIndex = 69;
            // 
            // chkEnableCANFDResistor
            // 
            this.chkEnableCANFDResistor.AutoSize = true;
            this.chkEnableCANFDResistor.Checked = true;
            this.chkEnableCANFDResistor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnableCANFDResistor.Location = new System.Drawing.Point(766, 24);
            this.chkEnableCANFDResistor.Name = "chkEnableCANFDResistor";
            this.chkEnableCANFDResistor.Size = new System.Drawing.Size(96, 16);
            this.chkEnableCANFDResistor.TabIndex = 64;
            this.chkEnableCANFDResistor.Text = "使能终端电阻";
            this.chkEnableCANFDResistor.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(603, 27);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(77, 12);
            this.label24.TabIndex = 68;
            this.label24.Text = "数据场波特率";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(78, 26);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(29, 12);
            this.label22.TabIndex = 66;
            this.label22.Text = "通道";
            // 
            // cbbCANFDChannel
            // 
            this.cbbCANFDChannel.FormattingEnabled = true;
            this.cbbCANFDChannel.Items.AddRange(new object[] {
            "Channel 1",
            "Channel 2",
            "Channel 3",
            "Channel 4",
            "Channel 5",
            "Channel 6",
            "Channel 7",
            "Channel 8",
            "Channel 9",
            "Channel 10"});
            this.cbbCANFDChannel.Location = new System.Drawing.Point(125, 23);
            this.cbbCANFDChannel.Name = "cbbCANFDChannel";
            this.cbbCANFDChannel.Size = new System.Drawing.Size(98, 20);
            this.cbbCANFDChannel.TabIndex = 67;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1029, 470);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "CAN API  ";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.btnUnregisterCANRxRecall);
            this.groupBox5.Controls.Add(this.btnRegisterCANRecall);
            this.groupBox5.Controls.Add(this.btnReceiveCANMessages);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.button14);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 166);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1023, 115);
            this.groupBox5.TabIndex = 38;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "读取CAN报文";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(167, 12);
            this.label8.TabIndex = 35;
            this.label8.Text = "读取Tx/Rx数据到接收Buffer中";
            // 
            // btnUnregisterCANRxRecall
            // 
            this.btnUnregisterCANRxRecall.Location = new System.Drawing.Point(699, 52);
            this.btnUnregisterCANRxRecall.Name = "btnUnregisterCANRxRecall";
            this.btnUnregisterCANRxRecall.Size = new System.Drawing.Size(206, 23);
            this.btnUnregisterCANRxRecall.TabIndex = 17;
            this.btnUnregisterCANRxRecall.Text = "UnRegister CAN Rx Recall";
            this.btnUnregisterCANRxRecall.UseVisualStyleBackColor = true;
            this.btnUnregisterCANRxRecall.Click += new System.EventHandler(this.BtnUnregisterCANRxRecall_Click);
            // 
            // btnRegisterCANRecall
            // 
            this.btnRegisterCANRecall.Location = new System.Drawing.Point(699, 23);
            this.btnRegisterCANRecall.Name = "btnRegisterCANRecall";
            this.btnRegisterCANRecall.Size = new System.Drawing.Size(206, 23);
            this.btnRegisterCANRecall.TabIndex = 16;
            this.btnRegisterCANRecall.Text = "Register CAN Rx Recall";
            this.btnRegisterCANRecall.UseVisualStyleBackColor = true;
            this.btnRegisterCANRecall.Click += new System.EventHandler(this.BtnRegisterCANRecall_Click);
            // 
            // btnReceiveCANMessages
            // 
            this.btnReceiveCANMessages.Location = new System.Drawing.Point(192, 28);
            this.btnReceiveCANMessages.Name = "btnReceiveCANMessages";
            this.btnReceiveCANMessages.Size = new System.Drawing.Size(206, 23);
            this.btnReceiveCANMessages.TabIndex = 23;
            this.btnReceiveCANMessages.Text = "Receive Rx CAN Messages";
            this.btnReceiveCANMessages.UseVisualStyleBackColor = true;
            this.btnReceiveCANMessages.Click += new System.EventHandler(this.btnReceiveCANRxMessages_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(60, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 12);
            this.label7.TabIndex = 34;
            this.label7.Text = "读取Rx数据到Buffer中";
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(192, 57);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(206, 23);
            this.button14.TabIndex = 24;
            this.button14.Text = "Receive Tx/Rx CAN Messages";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.btnReadClassicCANTxRxMessages_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(567, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 33;
            this.label4.Text = "反注册接收回调函数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(567, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 32;
            this.label3.Text = "注册接收回调函数";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnStartSWTimer);
            this.groupBox4.Controls.Add(this.btnStopCyclicSendMsg);
            this.groupBox4.Controls.Add(this.btnASyncSendCANMsg);
            this.groupBox4.Controls.Add(this.btnSyncSendCANMsg);
            this.groupBox4.Controls.Add(this.btnStartCyclicSendMsg);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.lblAsyncSendCANMsg);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.lblStartCyclicMsg);
            this.groupBox4.Controls.Add(this.lblSyncSendCANMsg);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 57);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1023, 109);
            this.groupBox4.TabIndex = 37;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "发送CAN报文";
            // 
            // btnStartSWTimer
            // 
            this.btnStartSWTimer.Location = new System.Drawing.Point(124, 67);
            this.btnStartSWTimer.Name = "btnStartSWTimer";
            this.btnStartSWTimer.Size = new System.Drawing.Size(206, 23);
            this.btnStartSWTimer.TabIndex = 22;
            this.btnStartSWTimer.Text = "Start Software Timer";
            this.btnStartSWTimer.UseVisualStyleBackColor = true;
            this.btnStartSWTimer.Click += new System.EventHandler(this.btnStartSWTimer_Click);
            // 
            // btnStopCyclicSendMsg
            // 
            this.btnStopCyclicSendMsg.Location = new System.Drawing.Point(448, 38);
            this.btnStopCyclicSendMsg.Name = "btnStopCyclicSendMsg";
            this.btnStopCyclicSendMsg.Size = new System.Drawing.Size(206, 23);
            this.btnStopCyclicSendMsg.TabIndex = 15;
            this.btnStopCyclicSendMsg.Text = "Stop Cyclic Send Message";
            this.btnStopCyclicSendMsg.UseVisualStyleBackColor = true;
            this.btnStopCyclicSendMsg.Click += new System.EventHandler(this.BtnStopCyclicSendMsg_Click);
            // 
            // btnASyncSendCANMsg
            // 
            this.btnASyncSendCANMsg.Location = new System.Drawing.Point(124, 12);
            this.btnASyncSendCANMsg.Name = "btnASyncSendCANMsg";
            this.btnASyncSendCANMsg.Size = new System.Drawing.Size(206, 23);
            this.btnASyncSendCANMsg.TabIndex = 8;
            this.btnASyncSendCANMsg.Text = "ASync Send CAN Message";
            this.btnASyncSendCANMsg.UseVisualStyleBackColor = true;
            this.btnASyncSendCANMsg.Click += new System.EventHandler(this.btnSendCANAsync_Click);
            // 
            // btnSyncSendCANMsg
            // 
            this.btnSyncSendCANMsg.Location = new System.Drawing.Point(448, 12);
            this.btnSyncSendCANMsg.Name = "btnSyncSendCANMsg";
            this.btnSyncSendCANMsg.Size = new System.Drawing.Size(206, 23);
            this.btnSyncSendCANMsg.TabIndex = 9;
            this.btnSyncSendCANMsg.Text = "Sync Send CAN Message";
            this.btnSyncSendCANMsg.UseVisualStyleBackColor = true;
            this.btnSyncSendCANMsg.Click += new System.EventHandler(this.btnSendCANSync_Click);
            // 
            // btnStartCyclicSendMsg
            // 
            this.btnStartCyclicSendMsg.Location = new System.Drawing.Point(124, 38);
            this.btnStartCyclicSendMsg.Name = "btnStartCyclicSendMsg";
            this.btnStartCyclicSendMsg.Size = new System.Drawing.Size(206, 23);
            this.btnStartCyclicSendMsg.TabIndex = 14;
            this.btnStartCyclicSendMsg.Text = "Start Cyclic Send Message";
            this.btnStartCyclicSendMsg.UseVisualStyleBackColor = true;
            this.btnStartCyclicSendMsg.Click += new System.EventHandler(this.BtnStartCyclicSendMsg_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 31;
            this.label6.Text = "启动软件定时器";
            // 
            // lblAsyncSendCANMsg
            // 
            this.lblAsyncSendCANMsg.AutoSize = true;
            this.lblAsyncSendCANMsg.Location = new System.Drawing.Point(20, 17);
            this.lblAsyncSendCANMsg.Name = "lblAsyncSendCANMsg";
            this.lblAsyncSendCANMsg.Size = new System.Drawing.Size(95, 12);
            this.lblAsyncSendCANMsg.TabIndex = 27;
            this.lblAsyncSendCANMsg.Text = "异步发送CAN报文";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(347, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 30;
            this.label5.Text = "停止发送周期报文";
            // 
            // lblStartCyclicMsg
            // 
            this.lblStartCyclicMsg.AutoSize = true;
            this.lblStartCyclicMsg.Location = new System.Drawing.Point(20, 43);
            this.lblStartCyclicMsg.Name = "lblStartCyclicMsg";
            this.lblStartCyclicMsg.Size = new System.Drawing.Size(101, 12);
            this.lblStartCyclicMsg.TabIndex = 29;
            this.lblStartCyclicMsg.Text = "启动发送周期报文";
            // 
            // lblSyncSendCANMsg
            // 
            this.lblSyncSendCANMsg.AutoSize = true;
            this.lblSyncSendCANMsg.Location = new System.Drawing.Point(347, 17);
            this.lblSyncSendCANMsg.Name = "lblSyncSendCANMsg";
            this.lblSyncSendCANMsg.Size = new System.Drawing.Size(95, 12);
            this.lblSyncSendCANMsg.TabIndex = 28;
            this.lblSyncSendCANMsg.Text = "同步发送CAN报文";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button12);
            this.groupBox3.Controls.Add(this.cbbChannelIndex);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.chkEnableTerminaResistor);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cbbCANBaudrate);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1023, 54);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "硬件配置";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(489, 19);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(110, 21);
            this.button12.TabIndex = 21;
            this.button12.Text = "配置硬件通道";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.btnCANHardwareConfig_Click);
            // 
            // cbbChannelIndex
            // 
            this.cbbChannelIndex.FormattingEnabled = true;
            this.cbbChannelIndex.Items.AddRange(new object[] {
            "Channel 1",
            "Channel 2",
            "Channel 3",
            "Channel 4",
            "Channel 5",
            "Channel 6",
            "Channel 7",
            "Channel 8",
            "Channel 9",
            "Channel 10"});
            this.cbbChannelIndex.Location = new System.Drawing.Point(124, 19);
            this.cbbChannelIndex.Name = "cbbChannelIndex";
            this.cbbChannelIndex.Size = new System.Drawing.Size(98, 20);
            this.cbbChannelIndex.TabIndex = 26;
            this.cbbChannelIndex.SelectedIndexChanged += new System.EventHandler(this.cbbChannelIndex_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 25;
            this.label2.Text = "通道";
            // 
            // chkEnableTerminaResistor
            // 
            this.chkEnableTerminaResistor.AutoSize = true;
            this.chkEnableTerminaResistor.Checked = true;
            this.chkEnableTerminaResistor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnableTerminaResistor.Location = new System.Drawing.Point(367, 21);
            this.chkEnableTerminaResistor.Name = "chkEnableTerminaResistor";
            this.chkEnableTerminaResistor.Size = new System.Drawing.Size(96, 16);
            this.chkEnableTerminaResistor.TabIndex = 20;
            this.chkEnableTerminaResistor.Text = "使能终端电阻";
            this.chkEnableTerminaResistor.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(228, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "波特率";
            // 
            // cbbCANBaudrate
            // 
            this.cbbCANBaudrate.FormattingEnabled = true;
            this.cbbCANBaudrate.Items.AddRange(new object[] {
            "125Kbps",
            "250Kbps",
            "500Kbps",
            "1000Kbps"});
            this.cbbCANBaudrate.Location = new System.Drawing.Point(275, 19);
            this.cbbCANBaudrate.Name = "cbbCANBaudrate";
            this.cbbCANBaudrate.Size = new System.Drawing.Size(86, 20);
            this.cbbCANBaudrate.TabIndex = 19;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button11);
            this.tabPage3.Controls.Add(this.btnRegisterLINRxRecall);
            this.tabPage3.Controls.Add(this.button10);
            this.tabPage3.Controls.Add(this.btnUnRegisterLINRxCallback);
            this.tabPage3.Controls.Add(this.lblMotorType);
            this.tabPage3.Controls.Add(this.btnAsynLINMsg);
            this.tabPage3.Controls.Add(this.cbScheduleTables);
            this.tabPage3.Controls.Add(this.rBOpen);
            this.tabPage3.Controls.Add(this.button9);
            this.tabPage3.Controls.Add(this.rBClose);
            this.tabPage3.Controls.Add(this.cbMDorMR);
            this.tabPage3.Controls.Add(this.rbTilt);
            this.tabPage3.Controls.Add(this.button8);
            this.tabPage3.Controls.Add(this.rBStop);
            this.tabPage3.Controls.Add(this.button7);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1029, 470);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "LIN API  ";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBox10);
            this.tabPage5.Controls.Add(this.groupBox1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1029, 470);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "诊断API";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.cbbSeedAndKeyLevel);
            this.groupBox10.Controls.Add(this.button17);
            this.groupBox10.Controls.Add(this.button16);
            this.groupBox10.Controls.Add(this.button15);
            this.groupBox10.Controls.Add(this.button13);
            this.groupBox10.Controls.Add(this.button4);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox10.Location = new System.Drawing.Point(0, 88);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(1029, 382);
            this.groupBox10.TabIndex = 3;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "14229服务层";
            this.groupBox10.Enter += new System.EventHandler(this.groupBox10_Enter);
            // 
            // cbbSeedAndKeyLevel
            // 
            this.cbbSeedAndKeyLevel.FormattingEnabled = true;
            this.cbbSeedAndKeyLevel.Items.AddRange(new object[] {
            "1",
            "3",
            "5",
            "7",
            "9",
            "11"});
            this.cbbSeedAndKeyLevel.Location = new System.Drawing.Point(353, 80);
            this.cbbSeedAndKeyLevel.Name = "cbbSeedAndKeyLevel";
            this.cbbSeedAndKeyLevel.Size = new System.Drawing.Size(121, 20);
            this.cbbSeedAndKeyLevel.TabIndex = 5;
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(188, 93);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(159, 23);
            this.button17.TabIndex = 4;
            this.button17.Text = "Send Key";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(188, 64);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(159, 23);
            this.button16.TabIndex = 3;
            this.button16.Text = "GetSeed";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(188, 151);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(159, 23);
            this.button15.TabIndex = 2;
            this.button15.Text = "ReadDataByID";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(188, 122);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(159, 23);
            this.button13.TabIndex = 1;
            this.button13.Text = "WriteDataByID";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(188, 35);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(159, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "Session Control";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1029, 88);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ISO-15765-2传输层";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(188, 35);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(159, 23);
            this.button5.TabIndex = 1;
            this.button5.Text = "测试发送数据包";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grpTrace);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1037, 685);
            this.panel1.TabIndex = 22;
            // 
            // grpTrace
            // 
            this.grpTrace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTrace.Location = new System.Drawing.Point(0, 499);
            this.grpTrace.Name = "grpTrace";
            this.grpTrace.Size = new System.Drawing.Size(1037, 186);
            this.grpTrace.TabIndex = 27;
            this.grpTrace.TabStop = false;
            this.grpTrace.Text = "Trace";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 496);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1037, 3);
            this.splitter1.TabIndex = 26;
            this.splitter1.TabStop = false;
            // 
            // tBLog
            // 
            this.tBLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tBLog.Location = new System.Drawing.Point(3, 17);
            this.tBLog.Multiline = true;
            this.tBLog.Name = "tBLog";
            this.tBLog.Size = new System.Drawing.Size(200, 665);
            this.tBLog.TabIndex = 23;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.tBLog);
            this.groupBox11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox11.Location = new System.Drawing.Point(1037, 0);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(206, 685);
            this.groupBox11.TabIndex = 24;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "系统消息";
            // 
            // tmrTrace
            // 
            this.tmrTrace.Enabled = true;
            this.tmrTrace.Interval = 300;
            this.tmrTrace.Tick += new System.EventHandler(this.tmrTrace_Tick);
            // 
            // tmrReadFIFO
            // 
            this.tmrReadFIFO.Tick += new System.EventHandler(this.tmrRefresh_Tick);
            // 
            // frmTSCANDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 707);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTSCANDemo";
            this.Text = "TsCAN API Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTestTSCANDll_FormClosing);
            this.Load += new System.EventHandler(this.frmTestTSCANDll_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.grpFDModeSelect.ResumeLayout(false);
            this.grpFDModeSelect.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cbbTSCANDeviceList;
        private System.Windows.Forms.TextBox tbManufacture;
        private System.Windows.Forms.TextBox tbProduct;
        private System.Windows.Forms.TextBox tbSerial;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsMsgInfo;
        private System.Windows.Forms.TextBox tbHandle;
        private System.Windows.Forms.Button btnRegisterLINRxRecall;
        private System.Windows.Forms.Button btnUnRegisterLINRxCallback;
        private System.Windows.Forms.RadioButton rBStop;
        private System.Windows.Forms.RadioButton rbTilt;
        private System.Windows.Forms.RadioButton rBClose;
        private System.Windows.Forms.RadioButton rBOpen;
        private System.Windows.Forms.Button btnAsynLINMsg;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.ComboBox cbMDorMR;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label lblMotorType;
        private System.Windows.Forms.ComboBox cbScheduleTables;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnReceiveFDCANTxRxMessageFromBuffer;
        private System.Windows.Forms.Button btnReceiveFDCANRxMessageFromBuffer;
        private System.Windows.Forms.Button btnRegisterFDCANRxRecall;
        private System.Windows.Forms.Button btnUnRegisterFDCANRxRecall;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnReceiveCANTxRxMessageFromBuffer;
        private System.Windows.Forms.Button btnReceiveClassicCANRxMessageFromBuffer;
        private System.Windows.Forms.Button btnStartCyclicCANFD;
        private System.Windows.Forms.Button btnCANFDSwTimer;
        private System.Windows.Forms.Button btnSyncSendCANFDMessage;
        private System.Windows.Forms.Button btnRegisterClassicCANRxRecall;
        private System.Windows.Forms.Button btnASyncSendCANFDMessage;
        private System.Windows.Forms.Button btnStopCyclicCANFD;
        private System.Windows.Forms.Button btnUnRegisterClassicCANRxRecall;
        private System.Windows.Forms.ComboBox cbbCANFDChannel;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnCANFDConfig;
        private System.Windows.Forms.CheckBox chkEnableCANFDResistor;
        private System.Windows.Forms.ComboBox cbbCANFDArbBaudrate;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cbbCANFDDataBaudrate;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.CheckBox chkBRS;
        private System.Windows.Forms.GroupBox grpFDModeSelect;
        private System.Windows.Forms.RadioButton rBFD;
        private System.Windows.Forms.RadioButton rBClassic;
        private System.Windows.Forms.Button btnRegisterConnecttedCallback;
        private System.Windows.Forms.Button btnUnRegisterDisConnecttedCallback;
        private System.Windows.Forms.Button btnRegisterDisConnecttedCallback;
        private System.Windows.Forms.Button btnUnregisterConnecttedCallback;
        private System.Windows.Forms.Label lblConnectManage;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblStartCyclicMsg;
        private System.Windows.Forms.Label lblSyncSendCANMsg;
        private System.Windows.Forms.Label lblAsyncSendCANMsg;
        private System.Windows.Forms.ComboBox cbbChannelIndex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.CheckBox chkEnableTerminaResistor;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.ComboBox cbbCANBaudrate;
        private System.Windows.Forms.Button btnReceiveCANMessages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartCyclicSendMsg;
        private System.Windows.Forms.Button btnStartSWTimer;
        private System.Windows.Forms.Button btnSyncSendCANMsg;
        private System.Windows.Forms.Button btnRegisterCANRecall;
        private System.Windows.Forms.Button btnASyncSendCANMsg;
        private System.Windows.Forms.Button btnStopCyclicSendMsg;
        private System.Windows.Forms.Button btnUnregisterCANRxRecall;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label lblDeviceNum;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbbCANFDControllerMode;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox tBFDDatas;
        private System.Windows.Forms.ComboBox cbbFDDLC;
        private System.Windows.Forms.TextBox tBFDFrameID;
        private System.Windows.Forms.Label lblFDDLC;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RadioButton rBFDExt;
        private System.Windows.Forms.RadioButton rbFDStd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.GroupBox grpTrace;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TextBox tBLog;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label lblDemoName;
        private System.Windows.Forms.Timer tmrTrace;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.ComboBox cbbSeedAndKeyLevel;
        private System.Windows.Forms.Timer tmrReadFIFO;
        private System.Windows.Forms.Button btnStartBusStatistics;
        private System.Windows.Forms.ComboBox cbbStatisticType;
        private System.Windows.Forms.Button btnGetStatistics;
        private System.Windows.Forms.Label lblStatisticValue;
        private System.Windows.Forms.Button btnClearStatistics;
        private System.Windows.Forms.RadioButton rBReadFIFO;
        private System.Windows.Forms.RadioButton rBRecallFunction;
        private System.Windows.Forms.CheckBox chkEnableCANFDMonitor;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Button button20;
    }
}

