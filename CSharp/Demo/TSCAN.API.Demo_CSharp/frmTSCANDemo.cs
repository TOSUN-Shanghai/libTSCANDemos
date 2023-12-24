using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TsMaster;
using System.Threading;
using System.Runtime.InteropServices;
using CSharp.Basic;

namespace TSCANDLL_CSHARP
{
    public partial class frmTSCANDemo : Form
    {
        static IntPtr deviceHandle = (IntPtr)0x00;
        static int diagnosticHandle = -1;
        CHANNEL_INDEX FCLCANChnIndex = CHANNEL_INDEX.CHN1;
        CHANNEL_INDEX FFDCANChnIndex = CHANNEL_INDEX.CHN1;
        TCANQueueEvent_Win32 receiveCANCallBack;// = ReceivedCANMsgCallBack;
        TCANFDQueueEvent_Win32 receiveCANFDCallBack;// = ReceivedCANFDMsgCallBack;
        TLINQueueEvent_Win32 receiveLINCallBack;// = ReceivedLINMsgCallBack;
        TTSCANConnectedCallback_Win32 connecttedCallBack;// = TSCANConnectedCallBack;
        TTSCANConnectedCallback_Win32 disconnectedCallBack;// = TSCANDisConnectedCallBack;
        private CtlTrace traceListView = new CtlTrace(1000);

        private ThreadProc testThreadObj = new ThreadProc(1);

        void TSCANConnectedCallBack(IntPtr ADevicehandle)
        {
            DispMsg("CAN工具连接成功！");
            deviceHandle = ADevicehandle;  //Refresh Device Handle;
        }

        void TSCANDisConnectedCallBack(IntPtr ADevicehandle)
        {
            DispMsg("CAN工具断开连接！");
            //TsCANApi.tscan_register_event_disconnected(disconnectedCallBack);
        }

        public frmTSCANDemo()
        {
            InitializeComponent();
        }

        private void AddMsg(string Msg)
        {
            tsMsgInfo.Text = Msg;
        }

        public delegate void CallBackDelegate(string message);

        public void DispMsg(string strMsg)
        {
            if (this.tBLog.InvokeRequired == false)                      //如果调用该函数的线程和控件lstMain位于同一个线程内
            {
                tBLog.AppendText(strMsg + "\r\n");
                if (tBLog.Lines.Count() > 100)
                    tBLog.Clear();
            }
            else                                                        //如果调用该函数的线程和控件lstMain不在同一个线程
            {   //使用控件lstMain的Invoke方法执行DMSGD代理(其类型是DispMSGDelegate)
                Invoke(new CallBackDelegate(DispMsg), new string[] { strMsg });
            }
        }

        /// <summary>
        /// Classic CAN接收函数回调函数：需要注意的是，这个函数是在多线程中调用的。类似于串口控件的OnDataReceived事件机制，开发人员使用时候注意做好线程保护和同步。
        /// </summary>
        /// <param name="ADevicehandle"></param>
        /// <param name="AData"></param>
        void ReceivedCANMsgCallBack(IntPtr ADevicehandle, ref TLIBCAN AData)
        {
            traceListView.AddGridCANViewItem(AData);
        }
        /// <summary>
        /// FDCAN接收函数回调函数：需要注意的是，这个函数是在多线程中调用的。类似于串口控件的OnDataReceived事件机制，开发人员使用时候注意做好线程保护和同步。
        /// </summary>
        /// <param name="AData"></param>
        //delegate void DELE_RECEIVEDCANFDCALLBACK(ref TLIBCANFD AData);
        //DELE_RECEIVEDCANFDCALLBACK tmpInvoke;
        void ReceivedCANFDMsgCallBack(IntPtr ADevicehandle, ref TLIBCANFD AData)
        {
           traceListView.AddGridCANFDViewItem(AData);
        }
        void ReceivedLINMsgCallBack(IntPtr ADevicehandle, ref TLIBLIN AData)
        {
            string tmpMsg = "";
            tmpMsg += "LIN FID:" + AData.FIdentifier.ToString("X2") + " Time:" + AData.FTimeUS.ToString("D4");
            DispMsg(tmpMsg);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uint ret = TsCANApi.tscan_connect(null, ref deviceHandle);
            if ((ret == 0) || (ret == 5))
            {
                tbHandle.Text = deviceHandle.ToString();
                AddMsg("连接成功！");
                TsCANApi.tsdiag_can_attach_to_tscan_tool(diagnosticHandle, deviceHandle);
                AddMsg("把诊断模块" + diagnosticHandle.ToString() + "绑定到CAN工具:" + deviceHandle.ToString());
            }
            else
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str1 = "", str2 = "", str3 = "";
            if (cbbTSCANDeviceList.SelectedIndex < 0)
            {
                AddMsg("请先选择一个设备进行查询");
                return;
            }
            uint ret = TsCANApi.GetDeviceInfo((UInt32)cbbTSCANDeviceList.SelectedIndex, ref str1, ref str2, ref str3);
            if (ret == 0)
            {
                tbManufacture.Text = str1;
                tbProduct.Text = str2;
                tbSerial.Text = str3;
                AddMsg("查询信息成功！");
            }
            else
            {
                //AddMsg(TsCANApi.TSCAN_GetTSCANErrorDescription(ret));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UInt32 deviceCount = 0;
            if (TsCANApi.tscan_scan_devices(ref deviceCount) == 0)
            {
                cbbTSCANDeviceList.Items.Clear();
                for (int i = 0; i < deviceCount; i++)
                {
                    cbbTSCANDeviceList.Items.Add(i.ToString());
                }
                if (cbbTSCANDeviceList.Items.Count > 0)
                    cbbTSCANDeviceList.SelectedIndex = 0;
                AddMsg("设备数量为：" + deviceCount.ToString());
                lblDeviceNum.Text = "设备：" + deviceCount.ToString() ;
            }
            else
            {
                AddMsg("查询设备列表失败！");
            }
        }

        private void frmTestTSCANDll_Load(object sender, EventArgs e)
        {
            receiveCANCallBack += new TCANQueueEvent_Win32(ReceivedCANMsgCallBack);
            receiveCANFDCallBack += new TCANFDQueueEvent_Win32(ReceivedCANFDMsgCallBack);
            receiveLINCallBack += new TLINQueueEvent_Win32(ReceivedLINMsgCallBack);
            connecttedCallBack += new TTSCANConnectedCallback_Win32(TSCANConnectedCallBack);
            disconnectedCallBack += new TTSCANConnectedCallback_Win32(TSCANDisConnectedCallBack);

            //
            cbMDorMR.SelectedIndex = 0;
            cbbCANBaudrate.SelectedIndex = 1;
            FCLCANChnIndex = CHANNEL_INDEX.CHN1;  //Default is channel 1
            cbbChannelIndex.SelectedIndex = (int)FCLCANChnIndex;
            //
            cbbCANFDArbBaudrate.SelectedIndex = 2;
            cbbCANFDDataBaudrate.SelectedIndex = 5;
            FFDCANChnIndex = CHANNEL_INDEX.CHN1;
            cbbCANFDChannel.SelectedIndex = (int)FFDCANChnIndex;
            TsCANApi.initialize_lib_tscan(true, true, false);  //Enable TSFIFO, Enable Error Frame, Disable Turbo Moded
            TsCANApi.tsdiag_can_create(ref diagnosticHandle, CHANNEL_INDEX.CHN1, 0, 8, 0x7C0, true, 0x7C8, true, 0x7DF, true);   //创建诊断模块
            //
            cbbFDDLC.SelectedIndex = 8;
            cbbCANFDControllerMode.SelectedIndex = 0;
            //Trace view
            traceListView.Parent = grpTrace;
            traceListView.Dock = DockStyle.Fill;
            //
            cbbSeedAndKeyLevel.SelectedIndex = 2;
        }

        /// <summary>
        /// 异步发送CAN报文：报文推送到发送缓冲区，函数不等待直接返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendCANAsync_Click(object sender, EventArgs e)
        {
            TLIBCAN msg = new TLIBCAN((CHANNEL_INDEX)FCLCANChnIndex, 0xFD, true, false, false, 8);
            msg.FData[0] = 0x00;
            uint ret = TsCANApi.tscan_transmit_can_async(deviceHandle, ref msg);
            if (ret == (uint)TSCAN_DEF.IDX_ERR_OK)
            {
                AddMsg("Asynchronous Send Msg Success!");
            }
            else
            {
                //AddMsg(TsCANApi.TSCAN_GetTSCANErrorDescription(ret));
            }
        }

        /// <summary>
        /// 同步发送CAN报文：报文推送到发送缓冲区，设备确认该报文已经发送到总线上，才返回成功；否则，等待超时过后，返回错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendCANSync_Click(object sender, EventArgs e)
        {
            TLIBCAN msg = new TLIBCAN((CHANNEL_INDEX)FCLCANChnIndex, 0xFD, true, false, false, 8);
            uint ret = TsCANApi.tscan_transmit_can_sync(deviceHandle, ref msg, 500);
            if (ret == (uint)TSCAN_DEF.IDX_ERR_OK)
            {
                AddMsg("Synchronous Send Msg Success!");
            }
            else
            {
                //AddMsg(TsCANApi.GetTSCANErrorDescription(ret));
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (TsCANApi.tscan_disconnect_by_handle(deviceHandle) == (uint)TSCAN_DEF.IDX_ERR_OK)
            {
                AddMsg("断开设备成功");
            }
            else
            {
                AddMsg("断开设备失败");
            }
        }

        private void frmTestTSCANDll_FormClosing(object sender, FormClosingEventArgs e)
        {
            button6_Click(null, null);
            if (threadIsStarted)
            {
                testThreadObj.stopThread();
            }
           TsCANApi.finalize_lib_tscan();   //
        }

        /// <summary>
        /// 启动周期发送API，通过TSMaster驱动内部封装的机制实现周期发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStartCyclicSendMsg_Click(object sender, EventArgs e)
        {
            TLIBCAN msg = new TLIBCAN((CHANNEL_INDEX)FCLCANChnIndex, 0xE1, true, false, false, 8);
            uint ret = TsCANApi.tscan_add_cyclic_msg_can(deviceHandle, ref msg, 1);
            if (ret == (uint)TSCAN_DEF.IDX_ERR_OK)
            {
                AddMsg("Send Msg Success!");
            }
            else
            {
                //ddMsg(TsCANApi.TSCAN_GetTSCANErrorDescription(ret));
            }
        }
        /// <summary>
        /// 停止周期发送API
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStopCyclicSendMsg_Click(object sender, EventArgs e)
        {
            TLIBCAN msg = new TLIBCAN((CHANNEL_INDEX)FCLCANChnIndex, 0xE1, true, false, false, 8);
            uint ret = TsCANApi.tscan_delete_cyclic_msg_can(deviceHandle, ref msg);
            if (ret == (uint)TSCAN_DEF.IDX_ERR_OK)
            {
                AddMsg("Send Msg Success!");
            }
            else
            {
                //AddMsg(TsCANApi.TSCAN_GetTSCANErrorDescription(ret));
            }
        }
        /// <summary>
        /// 注册接收回调函数：当设备收到CAN报文过后，就会触发执行此函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void BtnRegisterCANRecall_Click(object sender, EventArgs e)
        {
            uint ret = TsCANApi.tscan_register_event_can(deviceHandle, receiveCANCallBack);
            if (ret == (uint)TSCAN_DEF.IDX_ERR_OK)
            {
                AddMsg("CAN Register Success!");
            }
            else
            {
                //AddMsg(TsCANApi.TSCAN_GetTSCANErrorDescription(ret));              
            }
        }

        /// <summary>
        /// 反注册CAN报文接收回调函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUnregisterCANRxRecall_Click(object sender, EventArgs e)
        {
            uint ret = TsCANApi.tscan_unregister_event_can(deviceHandle, receiveCANCallBack);
            if (ret == (uint)TSCAN_DEF.IDX_ERR_OK)
            {
                AddMsg("CAN UnRegister Success!");
            }
            else
            {
                //AddMsg(TsCANApi.TSCAN_GetTSCANErrorDescription(ret));
            }
        }

        private void BtnRegisterLINRxRecall_Click(object sender, EventArgs e)
        {
            if (TsCANApi.tslin_register_event_lin(deviceHandle, receiveLINCallBack) == (uint)TSCAN_DEF.IDX_ERR_OK)
            {
                AddMsg("LIN Register Success!");
            }
            else
            {
                AddMsg("LIN Register Fail!");
            }
        }

        private void BtnUnRegisterLINRxCallback_Click(object sender, EventArgs e)
        {
            if (TsCANApi.tslin_unregister_event_lin(deviceHandle, receiveLINCallBack) == (uint)TSCAN_DEF.IDX_ERR_OK)
            {
                AddMsg("LIN UnRegister Success!");
            }
            else
            {
                AddMsg("LIN UnRegister Fail!");
            }
        }

        private void BtnAsynLINMsg_Click(object sender, EventArgs e)
        {
            TLIBLIN msg = new TLIBLIN(0, 0x12, 8, true);
            msg.FIdxChn = 0;
            msg.FDLC = 0x08;
            msg.FData[0] = 0x58;
            msg.FData[1] = 0x00;
            msg.FData[2] = 0xFE;
            msg.FData[3] = 0x00;
            msg.FData[4] = 0x00;
            msg.FData[5] = 0xEE;
            msg.FData[6] = 0x4D;
            msg.FData[7] &= 0xFF;
            if (rBOpen.Checked)
            {
                if (cbMDorMR.SelectedIndex == 0)
                    msg.FData[3] |= 0x02;
                else
                    msg.FData[3] |= 0x04;
            }
            else if (rBClose.Checked)
            {
                if (cbMDorMR.SelectedIndex == 0)
                    msg.FData[3] |= 0x10;
                else
                    msg.FData[3] |= 0x20;
            }
            else if (rbTilt.Checked)  //
            {
                if (cbMDorMR.SelectedIndex == 0)
                    msg.FData[3] |= 0x01;
            }
            else  //stop
            {

            }
            msg.FIdentifier = 0x10; //0x50
            msg.FTimeUS = 10;
            if (TsCANApi.tslin_transmit_lin_async(deviceHandle, ref msg) == (uint)TSCAN_DEF.IDX_ERR_OK)
            {
                AddMsg("Send LIN Msg Success!");
            }
            else
            {
                AddMsg("Send LIN Msg Failed!");
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            TLIBLIN msg = new TLIBLIN(0, 0x22, 8, true);
            msg.FIdxChn = 0;
            msg.FDLC = 0x08;
            msg.FData[0] = 0x58;
            msg.FData[1] = 0x00;
            msg.FData[2] = 0xFE;
            msg.FData[3] = 0x00;
            msg.FData[4] = 0x01;
            msg.FData[5] = 0xEE;
            msg.FData[6] = 0x4D;
            msg.FData[7] &= 0xFF;
            msg.FIdentifier = 0x10; //0x50
            msg.FTimeUS = 10;
            if (TsCANApi.tslin_transmit_lin_async(deviceHandle, ref msg) == (uint)TSCAN_DEF.IDX_ERR_OK)
            {
                AddMsg("Send LIN Msg Success!");
            }
            else
            {
                AddMsg("Send LIN Msg Failed!");
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            TLIBLIN msg = new TLIBLIN(0, 0x15, 8, true);
            msg.FIdxChn = 0;
            msg.FDLC = 0x08;
            msg.FData[0] = 0x58;
            msg.FData[1] = 0x00;
            msg.FData[2] = 0xFE;
            msg.FData[3] = 0x00;
            msg.FData[4] = 0x02;
            msg.FData[5] = 0xEE;
            msg.FData[6] = 0x4D;
            msg.FData[7] &= 0xFF;
            msg.FIdentifier = 0x10; //0x50
            msg.FTimeUS = 10;
            if (TsCANApi.tslin_transmit_lin_async(deviceHandle, ref msg) == (uint)TSCAN_DEF.IDX_ERR_OK)
            {
                AddMsg("Send LIN Msg Success!");
            }
            else
            {
                AddMsg("Send LIN Msg Failed!");
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            TLIBLIN msg = new TLIBLIN(0, 0x11, 8, true);
            msg.FIdxChn = 0;
            msg.FDLC = 0x08;
            msg.FData[0] = 0x58;
            msg.FData[1] = 0x00;
            msg.FData[2] = 0xFE;
            msg.FData[3] = 0x00;
            msg.FData[4] = 0x02;
            msg.FData[5] = 0xEE;
            msg.FData[6] = 0x4D;
            msg.FData[7] &= 0xFF;
            msg.FIdentifier = 0x11; //0x50
            msg.FTimeUS = 10;
            msg.FIsTx = true;
            if (TsCANApi.tslin_transmit_lin_async(deviceHandle, ref msg) == (uint)TSCAN_DEF.IDX_ERR_OK)
            {
                AddMsg("Send LIN Msg Success!");
            }
            else
            {
                AddMsg("Send LIN Msg Failed!");
            }
        }

        private void CbMotorTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TsCANApi.tslin_set_schedule_table(deviceHandle, 0, (byte)cbScheduleTables.SelectedIndex) == (uint)TSCAN_DEF.IDX_ERR_OK)
            {
                AddMsg("Switch LIN Schedule Table Success!");
            }
            else
            {
                AddMsg("Switch LIN Schedule Table Failed!");
            }
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            if (TsCANApi.tslin_stop_lin_channel(deviceHandle, 0) == (uint)TSCAN_DEF.IDX_ERR_OK)
            {
                AddMsg("Stop LIN Schedule Table Success!");
            }
            else
            {
                AddMsg("Stop LIN Schedule Table Failed!");
            }
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            TLIBLIN msg = new TLIBLIN(0, 0x3C, 8, true);
            msg.FIdxChn = 0;
            msg.FDLC = 0x06;
            msg.FData[0] = 0x0E;
            msg.FData[1] = 0x60;
            msg.FData[2] = 0x20;
            msg.FData[3] = 0x00;
            msg.FData[4] = 0x00;
            msg.FData[5] = 0x01;
            msg.FData[6] = 0x00;
            msg.FData[7] &= 0x00;
            msg.FIdentifier = 0x3C;
            msg.FTimeUS = 10;
            msg.FIsTx = true;
            if (TsCANApi.tslin_transmit_lin_async(deviceHandle, ref msg) == (uint)TSCAN_DEF.IDX_ERR_OK)
            {
                AddMsg("Send LIN Msg Success!");
            }
            else
            {
                AddMsg("Send LIN Msg Failed!");
            }
        }

        /// <summary>
        /// 配置CAN工具参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCANHardwareConfig_Click(object sender, EventArgs e)
        {
            double baudrate = 0;
            uint ret = 0;
            switch (cbbCANBaudrate.SelectedIndex)
            {
                case 0: baudrate = 125; break;
                case 1: baudrate = 250; break;
                case 2: baudrate = 500; break;
                case 3: baudrate = 1000; break;
                default:
                    MessageBox.Show("请先选择一个有效的波特率参数", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }
            if (chkEnableTerminaResistor.Checked)
                ret = TsCANApi.tscan_config_can_by_baudrate(deviceHandle, FCLCANChnIndex, baudrate, 1);
            else
                ret = TsCANApi.tscan_config_can_by_baudrate(deviceHandle, FCLCANChnIndex, baudrate, 0);
            if (ret == 0x00)
            {
                DispMsg("Set Baudrate:" + baudrate.ToString() + " Success");
            }
            else
            {
                DispMsg("Set Baudrate failed, please check the device type(tscan_config_can_by_baudrate api is used for classic can device such as tc1001)");
            }
        }

        private Boolean threadIsStarted = false;
        /// <summary>
        /// 采用多线程机制，实现周期发送报文
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartSWTimer_Click(object sender, EventArgs e)
        {
            if (threadIsStarted == false)
            {
                testThreadObj.startThread(ExecutePolling);
                btnStartSWTimer.Text = "Stop Software Timer";
            }
            else
            {
                testThreadObj.stopThread();
                btnStartSWTimer.Text = "Start Software Timer";
            }
            threadIsStarted = !threadIsStarted;
        }
        public static void ExecutePolling(int ARealIntervalTime)
        {
            TLIBCAN msg = new TLIBCAN(0, 0xFD, true, false, false, 8);
            msg.FData[0] = (byte)ARealIntervalTime;
            uint ret = TsCANApi.tscan_transmit_can_async(deviceHandle, ref msg);
            if (ret == (uint)TSCAN_DEF.IDX_ERR_OK)
            {
                //AddMsg("Send Msg Success!");
            }
            else
            {
                //AddMsg(TsCANApi.TSCAN_GetTSCANErrorDescription(ret));
            }
        }

        /// <summary>
        /// 通过读取FIFO的方式，读取设备收到的CAN报文：仅仅读取接收的报文
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReceiveCANRxMessages_Click(object sender, EventArgs e)
        {
            //首先：读取当前设备中缓存有多少数据：TX，RX的所有数据
            int dataCountInBuffer = 0;
            if (TsCANApi.tsfifo_read_can_buffer_frame_count(deviceHandle, CHANNEL_INDEX.CHN1, ref dataCountInBuffer) == 0x00)
            {
                DispMsg("Get Tx/Rx Count Success:" + dataCountInBuffer.ToString());
            }
            else
            {
                DispMsg("Get Tx/Rx Count Failed");
            }
            //创建Buffer，用于存储读取的数据
            TLIBCAN[] ACANMsgBuffers = new TLIBCAN[dataCountInBuffer];
            //返回值是实际读取的值：如果读取的是TXRX值，则realCnts == dataCountInBuffer； 如果值读取Rx值，则则realCnts <= dataCountInBuffer
            int realCnts = TsCANApi.ReceiveCANMsgList(deviceHandle, ref ACANMsgBuffers, dataCountInBuffer, CHANNEL_INDEX.CHN1, READ_TX_RX_DEF.TX_RX_MESSAGES);
            string msg = "";
            for (int i = 0; i < realCnts; i++)
            {
                if (ACANMsgBuffers[i].FIsTx)
                    msg += "Tx:";
                else
                    msg += "Rx:";
                msg += ACANMsgBuffers[i].FIdentifier.ToString("X8") + ":";
                for (int j = 0; j < ACANMsgBuffers[i].FDLC; j++)
                {
                    msg += ACANMsgBuffers[i].FData[j].ToString("X2") + " ";
                }
                msg += "\r\n";
            }
            if (msg == "")
            {
                DispMsg("No Message");
            }
            else
                DispMsg(msg);
        }
        /// <summary>
        /// 通过读取Buffer的机制，读取设备收到的CAN报文：包含Tx和Rx，根据时序全部读取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadClassicCANTxRxMessages_Click(object sender, EventArgs e)
        {
            //首先：读取当前设备中缓存有多少数据：TX，RX的所有数据
            int dataCountInBuffer = 0;
            if (TsCANApi.tsfifo_read_can_buffer_frame_count(deviceHandle, CHANNEL_INDEX.CHN1, ref dataCountInBuffer) == 0x00)
            {
                DispMsg("Get Tx/Rx Count Success:" + dataCountInBuffer.ToString());
            }
            else
            {
                DispMsg("Get Tx/Rx Count Failed");
            }
            //创建Buffer，用于存储读取的数据
            TLIBCAN[] ACANMsgBuffers = new TLIBCAN[dataCountInBuffer];
            //返回值是实际读取的值：如果读取的是TXRX值，则realCnts == dataCountInBuffer； 如果值读取Rx值，则则realCnts <= dataCountInBuffer
            int realCnts = TsCANApi.ReceiveCANMsgList(deviceHandle, ref ACANMsgBuffers, dataCountInBuffer, CHANNEL_INDEX.CHN1, READ_TX_RX_DEF.TX_RX_MESSAGES); //means recevei data all tx/rx data from channel 1
            string msg = "";
            for (int i = 0; i < realCnts; i++)
            {
                if (ACANMsgBuffers[i].FIsTx)
                    msg += "Tx:";
                else
                    msg += "Rx:";
                msg += ACANMsgBuffers[i].FIdentifier.ToString("X8") + ":";
                for (int j = 0; j < ACANMsgBuffers[i].FDLC; j++)
                {
                    msg += ACANMsgBuffers[i].FData[j].ToString("X2") + " ";
                }
                msg += "\r\n";
            }
            if (msg == "")
            {
                DispMsg("No Message");
            }
            else
                DispMsg(msg);
        }

        private void cbbChannelIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            FCLCANChnIndex = (CHANNEL_INDEX)cbbChannelIndex.SelectedIndex;
            if (FCLCANChnIndex < 0)
            {
                FCLCANChnIndex = 0;
                cbbChannelIndex.SelectedIndex = (int)FCLCANChnIndex;
            }

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// CANFD硬件参数设置：主要包括：仲裁场波特率，数据场波特率，是否使能CANFD模式等
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCANFDHardwareConfig_Click(object sender, EventArgs e)
        {
            if (cbbCANFDControllerMode.SelectedIndex < 0)
            {
                MessageBox.Show("请先选择一个有效控制器类型", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            double arbbaudrate = 0;
            double databaudrate = 0;
            uint ret = 0;
            switch (cbbCANFDArbBaudrate.SelectedIndex)
            {
                case 0: arbbaudrate = 125; break;
                case 1: arbbaudrate = 250; break;
                case 2: arbbaudrate = 500; break;
                case 3: arbbaudrate = 1000; break;
                default:
                    MessageBox.Show("请先选择一个有效的仲裁场波特率参数", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }
            FFDCANChnIndex = (CHANNEL_INDEX)cbbCANFDChannel.SelectedIndex;
            switch (cbbCANFDDataBaudrate.SelectedIndex)
            {
                case 0: databaudrate = 125; break;
                case 1: databaudrate = 250; break;
                case 2: databaudrate = 500; break;
                case 3: databaudrate = 1000; break;
                case 4: databaudrate = 2000; break;
                case 5: databaudrate = 4000; break;
                case 6: databaudrate = 5000; break;
                case 7: databaudrate = 8000; break;
                default:
                    MessageBox.Show("请先选择一个有效的数据场波特率参数", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }
            uint enableResistor = 0;
            if (chkEnableCANFDResistor.Checked)
                enableResistor = 1;
            ret = TsCANApi.tscan_config_canfd_by_baudrate(deviceHandle, FFDCANChnIndex, arbbaudrate, databaudrate, (TLIBCANFDControllerType)cbbCANFDControllerMode.SelectedIndex, TLIBCANFDControllerMode.lfdmNormal, enableResistor);
            if (ret == 0x00)
            {
                DispMsg("Set ArbBaudrate:" + arbbaudrate.ToString() + " DataBaudrate:" + databaudrate.ToString() + " Success");
            }
            else
            {
                DispMsg("Set Baudrate failed, please check the device type(tscan_config_canfd_by_baudrate api is used for fdcan device such as tc1011,tc1014)");
            }
        }


        public byte[] strToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");   //去除空格
            if ((hexString.Length % 2) != 0)     //判断hexstring的长度是否为偶数
            {
                hexString += "";
            }
            //声明一个长度为hexstring长度一半的字节组returnBytes
            byte[] returnBytes = new byte[hexString.Length / 2];

            for (int i = 0; i < returnBytes.Length; i++)
            {
                //将hexstring的两个字符转换成16进制的字节组
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }
            return returnBytes;
        }
        Boolean getCANFDMessage(out TLIBCANFD ACAN)
        {
            try
            {
                if (tBFDFrameID.Text.Trim() == "")
                {
                    MessageBox.Show("请先输入帧ID","警告",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    ACAN = new TLIBCANFD((CHANNEL_INDEX)FCLCANChnIndex, 0x1FFFFFFF, false, false, false,0);
                    return false;
                }
                if (tBFDDatas.Text.Trim() == "")
                {
                    MessageBox.Show("请先输入发送数据", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ACAN = new TLIBCANFD((CHANNEL_INDEX)FCLCANChnIndex, 0x1FFFFFFF, false, false,false,0);
                    return false;
                }
                int id = Convert.ToInt32(tBFDFrameID.Text, 16);
                TLIBCANFD msg = new TLIBCANFD((CHANNEL_INDEX)FCLCANChnIndex, id, false, false, false, (byte)cbbFDDLC.SelectedIndex, strToHexByte(tBFDDatas.Text));
                msg.FIsExt = rBFDExt.Checked;
                msg.FIsFD = rBFD.Checked;
                msg.FIsBRS = chkBRS.Checked;
                ACAN = msg;
                return true;
            }
            catch
            {
                ACAN = new TLIBCANFD((CHANNEL_INDEX)FCLCANChnIndex, 0x1FFFFFFF, false, false, false, 0);
                return false;
            }
        }
        /// <summary>
        /// 异步发送CANFD报文：发送报文不等待实际发送状态即返回,保持对主调度逻辑最小的干扰，一般推荐这种发送方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendCANFDAsync_Click(object sender, EventArgs e)
        {
            TLIBCANFD msg;
            if (getCANFDMessage(out msg) == false)
            {
                return;
            }
            //上述代码也可以采用下面的方式创建一个CANFD报文
            //TCANFD msg = new TCANFD((byte)FCLCANChnIndex, 0xFD, false, false, 8, rBFD.Checked, chkBRS.Checked);
            uint ret = TsCANApi.tscan_transmit_canfd_async(deviceHandle, ref msg);
            if (ret == (uint)TSCAN_DEF.IDX_ERR_OK)
            {
                AddMsg("Asynchronous Send FD CAN Msg Success!");
            }
            else
            {
                //AddMsg(TsCANApi.TSCAN_GetTSCANErrorDescription(ret));
            }
        }

        /// <summary>
        /// 同步发送CANFD报文：发送并且确认该报文已经发送到总线上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendCANFDSync_Click(object sender, EventArgs e)
        {
            TLIBCANFD msg;
            if (getCANFDMessage(out msg) == false)
            {
                return;
            }
            //上述代码也可以采用下面的方式创建一个CANFD报文
            //TCANFD msg = new TCANFD((byte)FCLCANChnIndex, 0xFD, false, false, 8, rBFD.Checked, chkBRS.Checked);
            uint ret = TsCANApi.tscan_transmit_canfd_sync(deviceHandle, ref msg, 500);
            if (ret == (uint)TSCAN_DEF.IDX_ERR_OK)
            {
                AddMsg("Synchronous Send Msg Success!");
            }
            else
            {
                //AddMsg(TsCANApi.TSCAN_GetTSCANErrorDescription(ret));
            }
        }

        private void rBClassic_CheckedChanged(object sender, EventArgs e)
        {
            int maxDLC = 8;
            if (rBClassic.Checked)
            {
                chkBRS.Enabled = false;
            }
            else
            {
                chkBRS.Enabled = true;
                maxDLC = 15;
            }
            cbbFDDLC.Items.Clear();
            for (int i = 0; i <= maxDLC; i++)
            {
                cbbFDDLC.Items.Add(i.ToString());
            }
            cbbFDDLC.SelectedIndex = cbbFDDLC.Items.Count - 1;
        }

        /// <summary>
        /// 启动周期发送API：采用TSMaster驱动内部机制实现周期发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartCyclicCANFD_Click(object sender, EventArgs e)
        {
            TLIBCANFD msg;
            if (getCANFDMessage(out msg) == false)
            {
                return;
            }
            uint ret = TsCANApi.tscan_add_cyclic_msg_canfd(deviceHandle, ref msg, 10);
            if (ret == (uint)TSCAN_DEF.IDX_ERR_OK)
            {
                AddMsg("Send Msg Success!");
            }
            else
            {
                //ddMsg(TsCANApi.TSCAN_GetTSCANErrorDescription(ret));
            }
        }

        /// <summary>
        /// 停止周期发送API
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStopCyclicCANFD_Click(object sender, EventArgs e)
        {
            TLIBCANFD msg;
            if (getCANFDMessage(out msg) == false)
            {
                return;
            }
            uint ret = TsCANApi.tscan_delete_cyclic_msg_canfd(deviceHandle, ref msg);
            if (ret == (uint)TSCAN_DEF.IDX_ERR_OK)
            {
                AddMsg("Send Msg Success!");
            }
            else
            {
                //ddMsg(TsCANApi.TSCAN_GetTSCANErrorDescription(ret));
            }
        }

        /// <summary>
        /// 注册经典CAN报文接收回调函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegisterClassicCANRxRecall_Click(object sender, EventArgs e)
        {
            uint ret = TsCANApi.tscan_register_event_can(deviceHandle, receiveCANCallBack);
            if (ret == (uint)TSCAN_DEF.IDX_ERR_OK)
            {
                AddMsg("CAN Register Success!");
            }
            else
            {
                //AddMsg(TsCANApi.TSCAN_GetTSCANErrorDescription(ret));              
            }
        }

        /// <summary>
        /// 读取设备Buffer机制，仅仅读取接收的报文
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReceiveClassicCANRxMessageFromBuffer_Click(object sender, EventArgs e)
        {
            //首先：读取当前设备中缓存有多少数据：TX，RX的所有数据
            int dataCountInBuffer = 0;
            if (TsCANApi.tsfifo_read_can_buffer_frame_count(deviceHandle, CHANNEL_INDEX.CHN1, ref dataCountInBuffer) == 0x00)
            {
                DispMsg("Get Tx/Rx Count Success:" + dataCountInBuffer.ToString());
            }
            else
            {
                DispMsg("Get Tx/Rx Count Failed");
            }
            //创建Buffer，用于存储读取的数据
            TLIBCAN[] ACANMsgBuffers = new TLIBCAN[dataCountInBuffer];
            //返回值是实际读取的值：如果读取的是TXRX值，则realCnts == dataCountInBuffer； 如果值读取Rx值，则则realCnts <= dataCountInBuffer
            int realCnts = TsCANApi.ReceiveCANMsgList(deviceHandle, ref ACANMsgBuffers, dataCountInBuffer,CHANNEL_INDEX.CHN1,READ_TX_RX_DEF.TX_RX_MESSAGES);
            
            for (int i = 0; i < realCnts; i++)
            {
                traceListView.AddGridCANViewItem(ACANMsgBuffers[i]);
            }
        }

        /// <summary>
        /// 注册CANFD接收回调函数：当设备从总线上发送/收到报文的时候就会触发此函数（TSMaster驱动中，无论自己发送的Tx报文还是接收的Rx报文都会往上面汇报，方便用户确认报文状态）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegisterFDCANRxRecall_Click(object sender, EventArgs e)
        {
            uint ret = TsCANApi.tscan_register_event_canfd(deviceHandle, receiveCANFDCallBack);
            if (ret == (uint)TSCAN_DEF.IDX_ERR_OK)
            {
                AddMsg("CANFD Register Success!");
            }
            else
            {
                //AddMsg(TsCANApi.TSCAN_GetTSCANErrorDescription(ret));              
            }
        }

        private void btnRegisterConnecttedRecall_Click(object sender, EventArgs e)
        {
            uint ret = TsCANApi.tscan_register_event_connected(connecttedCallBack);
            if (ret == (uint)TSCAN_DEF.IDX_ERR_OK)
            {
                AddMsg("注册设备连接回调函数成功!");
            }
            else
            {
                //AddMsg(TsCANApi.TSCAN_GetTSCANErrorDescription(ret));              
            }
        }

        private void btnUnregisterConnecttedCallback_Click(object sender, EventArgs e)
        {
            uint ret = TsCANApi.tscan_unregister_event_connected(connecttedCallBack);
            if (ret == (uint)TSCAN_DEF.IDX_ERR_OK)
            {
                AddMsg("反注册设备连接回调函数成功");
            }
            else
            {
                //AddMsg(TsCANApi.TSCAN_GetTSCANErrorDescription(ret));              
            }
        }

        private void btnRegisterDisConnecttedCallback_Click(object sender, EventArgs e)
        {
            uint ret = TsCANApi.tscan_register_event_disconnected(disconnectedCallBack);
            if (ret == (uint)TSCAN_DEF.IDX_ERR_OK)
            {
                AddMsg("注册设备断开回调函数成功!");
            }
            else
            {
                //AddMsg(TsCANApi.TSCAN_GetTSCANErrorDescription(ret));              
            }
        }

        private void btnUnRegisterDisConnecttedCallback_Click(object sender, EventArgs e)
        {
            uint ret = TsCANApi.tscan_unregister_event_disconnected(disconnectedCallBack);
            if (ret == (uint)TSCAN_DEF.IDX_ERR_OK)
            {
                AddMsg("反注册设备断开回调函数成功!");
            }
            else
            {
                //AddMsg(TsCANApi.TSCAN_GetTSCANErrorDescription(ret));              
            }
        }

        private void btnCANFDSwTimer_Click(object sender, EventArgs e)
        {
            if (threadIsStarted == false)
            {
                testThreadObj.startThread(ExecuteFDPolling);
                btnStartSWTimer.Text = "Stop Software Timer";
            }
            else
            {
                testThreadObj.stopThread();
                btnStartSWTimer.Text = "Start Software Timer";
            }
            threadIsStarted = !threadIsStarted;
        }

        static byte cnt = 0;
        public static void ExecuteFDPolling(int ARealIntervalTime)
        {
            TLIBCANFD msg = new TLIBCANFD((CHANNEL_INDEX)0, 0xFD, false, false, false, 8);
            msg.FIsFD = false;
            msg.FIsBRS = false;
            msg.FData[0] = cnt++;
            uint ret = TsCANApi.tscan_transmit_canfd_async(deviceHandle, ref msg);
            if (ret == (uint)TSCAN_DEF.IDX_ERR_OK)
            {
                //AddMsg("Send Msg Success!");
            }
            else
            {
                //AddMsg(TsCANApi.TSCAN_GetTSCANErrorDescription(ret));
            }
        }

        private void btnUnRegisterClassicCANRxRecall_Click(object sender, EventArgs e)
        {
            uint ret = TsCANApi.tscan_unregister_event_can(deviceHandle, receiveCANCallBack);
            if (ret == (uint)TSCAN_DEF.IDX_ERR_OK)
            {
                AddMsg("CAN UnRegister Success!");
            }
            else
            {
                //AddMsg(TsCANApi.TSCAN_GetTSCANErrorDescription(ret));              
            }
        }

        /// <summary>
        /// 通过读取设备FIFO，读取设备该通道发送和接收的报文
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReceiveCANTxRxMessageFromBuffer_Click(object sender, EventArgs e)
        {
            //首先：读取当前设备中缓存有多少数据：TX，RX的所有数据
            int dataCountInBuffer = 0;
            if (TsCANApi.tsfifo_read_can_buffer_frame_count(deviceHandle, CHANNEL_INDEX.CHN1, ref dataCountInBuffer) == 0x00)
            {
                DispMsg("Get Tx/Rx Count Success:" + dataCountInBuffer.ToString());
            }
            else
            {
                DispMsg("Get Tx/Rx Count Failed");
            }
            //创建Buffer，用于存储读取的数据
            TLIBCAN[] ACANMsgBuffers = new TLIBCAN[dataCountInBuffer];
            //返回值是实际读取的值：如果读取的是TXRX值，则realCnts == dataCountInBuffer； 如果值读取Rx值，则则realCnts <= dataCountInBuffer
            int realCnts = TsCANApi.ReceiveCANMsgList(deviceHandle, ref ACANMsgBuffers, dataCountInBuffer, CHANNEL_INDEX.CHN1, READ_TX_RX_DEF.TX_RX_MESSAGES); //means recevei data all tx/rx data from channel 1
            
            for (int i = 0; i < realCnts; i++)
            {
                traceListView.AddGridCANViewItem(ACANMsgBuffers[i]);
            }
        }

        /// <summary>
        /// 通过读取设备Buffer，读取CANFD报文（只读取自己接收的，不读取发送的）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReceiveFDCANRxMessageFromBuffer_Click(object sender, EventArgs e)
        {
            ReadCANFDFifo(true);
        }

        private void ReadCANFDFifo(bool AEnableNotify)
        {
            //首先：读取当前设备中缓存有多少数据：TX，RX的所有数据
            int dataCountInBuffer = 0;
            if (TsCANApi.tsfifo_read_canfd_buffer_frame_count(deviceHandle, CHANNEL_INDEX.CHN1, ref dataCountInBuffer) == 0x00)
            {
                if (AEnableNotify)
                    DispMsg("Get Tx/Rx Count Success:" + dataCountInBuffer.ToString());
            }
            else
            {
                if (AEnableNotify)
                    DispMsg("Get Tx/Rx Count Failed");
            }
            //创建Buffer，用于存储读取的数据
            TLIBCANFD[] ACANMsgBuffers = new TLIBCANFD[dataCountInBuffer];
            //返回值是实际读取的值：如果读取的是TXRX值，则realCnts == dataCountInBuffer； 如果值读取Rx值，则则realCnts <= dataCountInBuffer
            int realCnts = TsCANApi.ReceiveCANFDMsgList(deviceHandle, ref ACANMsgBuffers, dataCountInBuffer, CHANNEL_INDEX.CHN1, READ_TX_RX_DEF.TX_RX_MESSAGES);

            for (int i = 0; i < realCnts; i++)
            {
                TLIBCANFD AData = ACANMsgBuffers[i];
                traceListView.AddGridCANFDViewItem(AData);
            }
        }

        /// <summary>
        /// 通过读取设备FIFO，读取设备Tx/Rx报文
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReceiveFDCANTxRxMessageFromBuffer_Click(object sender, EventArgs e)
        {
            //首先：读取当前设备中缓存有多少数据：TX，RX的所有数据
            int dataCountInBuffer = 0;
            if (TsCANApi.tsfifo_read_canfd_buffer_frame_count(deviceHandle, CHANNEL_INDEX.CHN1, ref dataCountInBuffer) == 0x00)
            {
                DispMsg("Get Tx/Rx Count Success:" + dataCountInBuffer.ToString());
            }
            else
            {
                DispMsg("Get Tx/Rx Count Failed");
            }
            //创建Buffer，用于存储读取的数据
            TLIBCANFD[] ACANMsgBuffers = new TLIBCANFD[dataCountInBuffer];
            //返回值是实际读取的值：如果读取的是TXRX值，则realCnts == dataCountInBuffer； 如果值读取Rx值，则则realCnts <= dataCountInBuffer
            int realCnts = TsCANApi.ReceiveCANFDMsgList(deviceHandle, ref ACANMsgBuffers, dataCountInBuffer, CHANNEL_INDEX.CHN1, READ_TX_RX_DEF.TX_RX_MESSAGES); //means recevei data all tx/rx data from channel 1
           
            for (int i = 0; i < realCnts; i++)
            {
                traceListView.AddGridCANFDViewItem(ACANMsgBuffers[i]);
            }
        }

        /// <summary>
        /// 反注册CAN报文接收回调函数，当设备从总线上发送/收到报文后不再触发此函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnRegisterFDCANRxRecall_Click(object sender, EventArgs e)
        {
            uint ret = TsCANApi.tscan_unregister_event_canfd(deviceHandle, receiveCANFDCallBack);
            if (ret == (uint)TSCAN_DEF.IDX_ERR_OK)
            {
                AddMsg("CANFD UnRegister Success!");
            }
            else
            {
                //AddMsg(TsCANApi.TSCAN_GetTSCANErrorDescription(ret));              
            }
        }

        private void cbbCANFDControllerMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbCANFDDataBaudrate.Enabled = cbbCANFDControllerMode.SelectedIndex != 0;
            if (cbbCANFDControllerMode.SelectedIndex == 0)
                rBClassic.Checked = true;
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int ret = TsCANApi.tsdiag_can_session_control(diagnosticHandle, 0x02);
            if (ret == 0x00)
            {
                DispMsg("Session Control Success!");
            }
            else
            {
                DispMsg("Session Control Failed!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            byte[] testDatas = new byte[20];
            byte[] receiveDatas = new byte[200];
            int revBytesNum = 200;
            unsafe
            {

                testDatas[0] = 0x22;
                testDatas[1] = 0xF1;
                testDatas[2] = 0x95;
                fixed (byte* pDatas = &testDatas[0])
                {
                    fixed (byte* pRev = &receiveDatas[0])
                    {
                        int ret = TsCANApi.tstp_can_request_and_get_response(diagnosticHandle, pDatas, 3,
                            pRev, ref revBytesNum);
                        if (ret == 0x00)
                        {
                            DispMsg("发送数据包成功!");
                        }
                        else
                        {
                            DispMsg("发送数据包失败！");
                        }
                    }
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            byte[] testDatas = new byte[20];
            unsafe
            {
                for (int i = 0; i < 20; i++)
                {
                    testDatas[i] = (byte)i;
                }
                fixed (byte* pDatas = &testDatas[0])
                {
                    int ret = TsCANApi.tsdiag_can_write_data_by_identifier(diagnosticHandle, 0xF110, pDatas, 20);
                    if (ret == 0x00)
                    {
                        DispMsg("写入数据成功!");
                    }
                    else
                    {
                        DispMsg("写入数据包失败！");
                    }
                }
            }
        }

        string getHexString(byte[] ADatas, int ADataLen)
        {
            string ret = "";
            for (int i = 0; i < ADataLen; i++)
            {
                ret += ADatas[i].ToString("X2") + " ";
            }
            return ret;
        } 
        private void button15_Click(object sender, EventArgs e)
        {
            byte[] testDatas = new byte[20];
            int retDataLen = 20;
            unsafe
            {
                for (int i = 0; i < 20; i++)
                {
                    testDatas[i] = (byte)i;
                }
                fixed (byte* pDatas = &testDatas[0])
                {
                    int ret = TsCANApi.tsdiag_can_read_data_by_identifier(diagnosticHandle, 0xF110, pDatas, ref retDataLen);
                    if (ret == 0x00)
                    {
                        DispMsg("读取数据成功:数据长度" + retDataLen.ToString()  + ":"+ getHexString(testDatas,retDataLen));
                    }
                    else
                    {
                        DispMsg("读取数据包失败！");
                    }
                }
            }
        }

        private void tabPage4_Resize(object sender, EventArgs e)
        {
            lblDemoName.Left = (tabPage1.ClientSize.Width - lblDemoName.Width)/ 2;
        }

        private void tmrTrace_Tick(object sender, EventArgs e)
        {
            traceListView.RefreshDataList();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (cbbSeedAndKeyLevel.SelectedIndex < 0)
            {
                DispMsg("请先选择加密访问等级！");
                return;
            }
            UInt32 seedValue = 0;
            int ret = TsCANApi.tsdiag_can_security_access_request_seed_dontnet(diagnosticHandle, 5, ref seedValue);
            if (ret == 0x00)
            {
                vSeedValue = seedValue;
                DispMsg("Get Seed Success:" + seedValue.ToString());
            }
            else
            {
                DispMsg("Get Seed Failed!");
            }
        }

        private void groupBox10_Enter(object sender, EventArgs e)
        {

        }

        UInt32 CalcKeyValue(UInt32 ASeedValue)
        {
            /*用户再次添加自己的算法*/
            return ASeedValue + 1;
        }
        UInt32 vSeedValue = 0;
        private void button17_Click(object sender, EventArgs e)
        {
            if (cbbSeedAndKeyLevel.SelectedIndex < 0)
            {
                DispMsg("请先选择加密访问等级！");
                return;
            }
            int secLevel = Convert.ToInt32(cbbSeedAndKeyLevel.Text) + 1;
            UInt32 keyValue = CalcKeyValue(vSeedValue);
            int ret = TsCANApi.tsdiag_can_security_access_send_key_dontnet(diagnosticHandle, secLevel, keyValue);
            if (ret == 0x00)
            {
                DispMsg("Send Key Success:" + keyValue.ToString());
            }
            else
            {
                DispMsg("Send Key Failed!");
            }
        }

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            ReadCANFDFifo(false);
        }

        private void btnStartBusStatistics_Click(object sender, EventArgs e)
        {
            if (btnStartBusStatistics.Text == "启动总线信息统计")
            {
                TsCANApi.tscan_set_auto_calc_bus_statistics(true);
                btnStartBusStatistics.Text = "停止总线信息统计";
            }
            else
            {
                TsCANApi.tscan_set_auto_calc_bus_statistics(false);
                btnStartBusStatistics.Text = "启动总线信息统计";
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (cbbStatisticType.SelectedIndex < 0)
                return;
            double retvalue = TsCANApi.tscan_get_bus_status(deviceHandle, CHANNEL_INDEX.CHN1,(TSTATISTICTYPE)cbbStatisticType.SelectedIndex);
            lblStatisticValue.Text = retvalue.ToString();
        }

        private void btnClearStatistics_Click(object sender, EventArgs e)
        {
            TsCANApi.tscan_clear_can_bus_statistic();
        }


        private void rBRecallFunction_CheckedChanged(object sender, EventArgs e)
        {
            if (rBRecallFunction.Checked)
            {
                btnRegisterFDCANRxRecall_Click(null, null);
                //BtnRegisterCANRecall_Click(null, null);
                tmrReadFIFO.Enabled = false;
            }
            else
            {
                btnUnRegisterFDCANRxRecall_Click(null, null);
                //BtnUnregisterCANRxRecall_Click(null, null);
                tmrReadFIFO.Enabled = true;
            }
        }

        private void chkEnableCANFDMonitor_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableCANFDMonitor.Checked)
            {
                if (rBRecallFunction.Checked)
                {
                    btnRegisterFDCANRxRecall_Click(null, null);
                    //BtnRegisterCANRecall_Click(null, null);
                    tmrReadFIFO.Enabled = false;
                }
                else
                {
                    btnUnRegisterFDCANRxRecall_Click(null, null);
                    //BtnUnregisterCANRxRecall_Click(null, null);
                    tmrReadFIFO.Enabled = true;
                }
            }
            else
            {
                btnUnRegisterFDCANRxRecall_Click(null, null);
                //BtnUnregisterCANRxRecall_Click(null, null);
                tmrReadFIFO.Enabled = false;
            }
            rBRecallFunction.Enabled = chkEnableCANFDMonitor.Checked;
            rBReadFIFO.Enabled = chkEnableCANFDMonitor.Checked;
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            uint errCode = TsCANApi.tsfifo_clear_canfd_receive_buffers(deviceHandle, CHANNEL_INDEX.CHN1);
            if (errCode == 0x00)
            {
                AddMsg("Clear FDCAN fifo success!");
            }else
                AddMsg("Clear FDCAN fifo failed!");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            uint errCode = TsCANApi.tsfifo_clear_can_receive_buffers(deviceHandle, CHANNEL_INDEX.CHN1);
            if (errCode == 0x00)
            {
                AddMsg("Clear CAN fifo of Channel 1 success!");
            }
            else
                AddMsg("Clear CAN fifo of Channel 1 failed!");
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (TsCANApi.tsfifo_add_can_canfd_pass_filter(deviceHandle, CHANNEL_INDEX.CHN1, 0x123, true) == 0x00)
                AddMsg("Add CAN/CANFD Filter success"); //Allow 0x123 to pass
            else
                AddMsg("Add CAN/CANFD Filter failed"); //Allow 0x123 to pass
        }
    }

}
