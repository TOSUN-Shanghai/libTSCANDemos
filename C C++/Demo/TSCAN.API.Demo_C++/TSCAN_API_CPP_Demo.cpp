#include "TSCANLINApi.h"


//#define TEST_CAN_API
#define TEST_CANFD_API
//#define TEST_LIN_API
#define TEST_FLEXRAY_API

extern void ProcessLINMsg1(TLibLIN AMsg);

/// <summary>
/// CAN报文接收回调函数
/// </summary>
/// <param name="AData">CAN报文指针</param>
/// <returns></returns>
void __stdcall ReceiveCANMessage1(const TLibCAN* AData)
{

}

/*如果注册了本函数，当驱动收到了一帧LIN报文过后，就会触发此函数*/
/// <summary>
/// LIN报文接收回调函数
/// </summary>
/// <param name="AData">LIN报文指针</param>
/// <returns></returns>
void __stdcall ReceiveLINMessage1(const TLibLIN* AData)
{
	//通过回调函数读取数据
	printf("Receive Recall\n");
	ProcessLINMsg1(*AData);
}


/*如果注册了本函数，当驱动收到了一帧LIN报文过后，就会触发此函数*/
/// <summary>
/// LIN报文接收回调函数
/// </summary>
/// <param name="AData">LIN报文指针</param>
/// <returns></returns>
void __stdcall ReceiveFastLINMessage1(const TLibLIN* AData)
{
	//通过回调函数读取数据
	printf("Receive FastLIN Recall\n");
	ProcessLINMsg1(*AData);
}

/// <summary>
/// 处理收到的LIN报文数据
/// </summary>
/// <param name="AMsg">LIN报文</param>
/// <returns></returns>
void ProcessLINMsg1(TLibLIN AMsg)
{
	if (AMsg.FProperties.bits.istx)
	{
		printf("Translate message:");
	}
	else
	{
		printf("Receive message:");
	}
	printf("ID:%x ", AMsg.FIdentifier);
	printf("Datalength:%d ", AMsg.FDLC);
	printf("Datas:");
	for (int i = 0; i < AMsg.FDLC; i++)
	{
		printf(" %x", AMsg.FData.d[i]);
	}
	printf("\n");
}

/// <summary>
/// 处理收到的LIN报文数据
/// </summary>
/// <param name="AMsg">LIN报文</param>
/// <returns></returns>
void ProcessCANMsg1(TLibCAN AMsg)
{
	if (AMsg.FProperties.bits.istx)
	{
		printf("Translate message:");
	}
	else
	{
		printf("Receive message:");
	}
	printf("ID:%x ", AMsg.FIdentifier);
	printf("Datalength:%d ", AMsg.FDLC);
	printf("Datas:");
	for (int i = 0; i < AMsg.FDLC; i++)
	{
		printf(" %x", AMsg.FData.d[i]);
	}
	printf("\n");
}


void TestLINAPI(TSCANLINApi* tsCANLINAPIObj, size_t ADeviceHandle)
{
	s32 retValue;
	/*定义CAN发送报文，并填充数据*/
	TLibLIN msg;
	//把当前设备设置为主节点模式：主节点模式下，才能够主动调度报文，发送报文头等
	if (tsCANLINAPIObj->tslin_set_node_funtiontype(ADeviceHandle, CHN1, (u8)MasterNode) == 0)
	{
		printf("LIN Device with handle:%zu set function type success\n", ADeviceHandle);
	}
	else
	{
		printf("LIN Device with handle:%zu set function type failed\n", ADeviceHandle);
	}
	//清除内部ldf文件
	if (tsCANLINAPIObj->tslin_clear_schedule_tables(ADeviceHandle, CHN1) == 0)
	{
		printf("LIN Device with handle:%zu apply new ldf callback success\n", ADeviceHandle);
	}
	else
	{
		printf("LIN Device with handle:%zu apply new ldf callback failed\n", ADeviceHandle);
	}
	//注册普通LIN接收回调函数：类似于接收中断
	if (tsCANLINAPIObj->tslin_register_event_lin(ADeviceHandle, ReceiveLINMessage1) == 0)
	{
		printf("LIN Device with handle:%zu register rev callback success\n", ADeviceHandle);
	}
	else
	{
		printf("LIN Device with handle:%zu register rev callback failed\n", ADeviceHandle);
	}
	//注册FalstLIN接收回调函数：类似于接收中断
	if (tsCANLINAPIObj->tscan_register_event_fastlin(ADeviceHandle, ReceiveFastLINMessage1) == 0)
	{
		printf("LIN Device with handle:%zu register rev callback success\n", ADeviceHandle);
	}
	else
	{
		printf("LIN Device with handle:%zu register rev callback failed\n", ADeviceHandle);
	}
	//设置波特率
	if (tsCANLINAPIObj->tslin_config_baudrate(ADeviceHandle, CHN1, 100) == 0)
	{
		printf("LIN Device with handle:%zu set baudrate 100k success\n", ADeviceHandle);
	}
	else
	{
		printf("LIN Device with handle:%zu set baudrate 100k failed\n", ADeviceHandle);
	}
	//同步函数发送LIN报文
	msg.FIdentifier = 0x3C;
	msg.FDLC = 3;
	msg.FIdxChn = 0;
	msg.FProperties.value = 0x00;
	msg.FProperties.bits.istx = 1;
	msg.FData.d[0] = (byte)0x12;
	msg.FData.d[1] = (byte)0x34;
	msg.FData.d[2] = (byte)0x56;
	//普通LIN发送函数
	if (tsCANLINAPIObj->tslin_transmit_lin_sync(ADeviceHandle, &msg, 500) == 0)
	{
		printf("LIN Device with handle:%zu sync send lin message success\n", ADeviceHandle);
	}
	else
	{
		printf("LIN Device with handle:%zu sync send lin message failed\n", ADeviceHandle);
	}
	//LIN Receive Function
	Sleep(3);
	//普通LIN读取数据API
	TLibLIN recMessageBuffs[5];
	int cnt = 0;
	retValue = 5;
	tsCANLINAPIObj->tsfifo_receive_lin_msgs(ADeviceHandle, recMessageBuffs, &retValue, CHN1, TX_RX_MESSAGES);
	printf("%d  messages received\n", retValue);
	for (int i = 0; i < (int)retValue; i++)
	{
		ProcessLINMsg1(recMessageBuffs[i]);
	}
	//注意：对于LIN总线来说，如果要接收报文，也要调用报文发送函数sendMsgAsync，把istx设置为0，实际上
	//是把报文帧头发送出去并读取总线上的报文
	msg.FIdentifier = 0x31;
	msg.FProperties.value = 0x00;
	msg.FProperties.bits.istx = 0; // as rx frame
	msg.FDLC = 3;
	msg.FIdxChn = 0;
	if (tsCANLINAPIObj->tslin_transmit_lin_async(ADeviceHandle, &msg) == 0)
	{
		printf("LIN Device with handle:%zu async send lin message success\n", ADeviceHandle);
	}
	else
	{
		printf("LIN Device with handle:%zu async send lin message failed\n", ADeviceHandle);
	}
	//对于接收类型的报文，如果从节点没有及时回复，则retValue =0,接收失败
	Sleep(10);
	//采用延时等待的方式，直到读取到LIN报文或者超时
	cnt = 0;
	while ((retValue == 0) && (cnt < 100))
	{
		retValue = 5; //Set Receive Buffer Size
		if (tsCANLINAPIObj->tsfifo_receive_lin_msgs(ADeviceHandle, recMessageBuffs, &retValue, CHN1, TX_RX_MESSAGES) == 0x00)
		{
			cnt++;
			Sleep(10);
		}
	}
	//如果超时都还收不到数据，则接收数据失败
	printf("%d  messages received\n", retValue);
	for (int i = 0; i < (int)retValue; i++)
	{
		ProcessLINMsg1(recMessageBuffs[i]);
	}
	msg.FIdentifier = 0x32;
	if (tsCANLINAPIObj->tslin_transmit_lin_async(ADeviceHandle, &msg) == 0)
	{
		printf("LIN Device with handle:%zu async fast lin send lin message success\n", ADeviceHandle);
	}
	else
	{
		printf("LIN Device with handle:%zu async fast lin send lin message failed\n", ADeviceHandle);
	}
    //FastLIN接收函数
	Sleep(10);
	retValue = 0;
	cnt = 0;
	//采用延时等待的方式，直到读取到LIN报文或者超时
	while ((retValue == 0) && (cnt < 100))
	{
		retValue = 5; //set receive buffer size
		if (tsCANLINAPIObj->tsfifo_receive_fastlin_msgs(ADeviceHandle, recMessageBuffs, &retValue, CHN1, TX_RX_MESSAGES) == 0x00)
		{
			cnt++;
			Sleep(10);
		}
	}
	//如果超时都还收不到数据，则接收数据失败
	printf("%d  messages received\n", retValue);
	for (int i = 0; i < (int)retValue; i++)
	{
		ProcessLINMsg1(recMessageBuffs[i]);
	}
	//反注册接收回调函数
	if (tsCANLINAPIObj->tslin_unregister_event_lin(ADeviceHandle, ReceiveLINMessage1) == 0)
	{
		printf("LIN Device with handle:%zu unregister rev callback success\n", ADeviceHandle);
	}
	else
	{
		printf("LIN Device with handle:%zu unregister rev callback failed\n", ADeviceHandle);
	}
	//反注册FastLIN接收回调函数
	if (tsCANLINAPIObj->tscan_unregister_event_fastlin(ADeviceHandle, ReceiveFastLINMessage1) == 0)
	{
		printf("LIN Device with handle:%zu unregister rev callback success\n", ADeviceHandle);
	}
	else
	{
		printf("LIN Device with handle:%zu unregister rev callback failed\n", ADeviceHandle);
	}
}


void TestCANAPI(TSCANLINApi* tsCANLINAPIObj, size_t ADeviceHandle)
{
	s32 retValue = 0;
	/*定义CAN发送报文，并填充数据*/
	TLibCAN msg;
	msg.FIdentifier = 0x03;
	msg.FProperties.bits.extframe = 0;
	msg.FProperties.bits.remoteframe = 0x00; //not remote frame,standard frame
	msg.FDLC = 3;
	msg.FIdxChn = 0;
	//注册接收回调函数：类似于接收中断
	if (tsCANLINAPIObj->tscan_register_event_can(ADeviceHandle, ReceiveCANMessage1) == 0)
	{
		printf("CAN Device with handle:%zu register rev callback success\n", ADeviceHandle);
	}
	else
	{
		printf("CAN Device with handle:%zu register rev callback failed\n", ADeviceHandle);
	}
	//设置波特率
	if (tsCANLINAPIObj->tscan_config_can_by_baudrate(ADeviceHandle, CHN1, 500, 1) == 0)
	{
		printf("CAN Device with handle:%zu set baudrate 500k success\n", ADeviceHandle);
	}
	else
	{
		printf("CAN Device with handle:%zu set baudrate 500k failed\n", ADeviceHandle);
	}
	//同步函数发送CAN报文
	if (tsCANLINAPIObj->tscan_transmit_can_sync(ADeviceHandle, &msg, 500) == 0)
	{
		printf("CAN Device with handle:%zu sync send can message success\n", ADeviceHandle);
	}
	else
	{
		printf("CAN Device with handle:%zu sync send can message failed\n", ADeviceHandle);
	}
	//异步函数发送CAN报文：
	if (tsCANLINAPIObj->tscan_transmit_can_async(ADeviceHandle, &msg) == 0)
	{
		printf("CAN Device with handle:%zu async send can message success\n", ADeviceHandle);
	}
	else
	{
		printf("CAN Device with handle:%zu async send can message failed\n", ADeviceHandle);
	}
	//普通CAN读取数据API
	TLibCAN recMessageBuffs[5];
	int cnt = 0;
	retValue = 5;
	if (tsCANLINAPIObj->tsfifo_receive_can_msgs(ADeviceHandle, recMessageBuffs, &retValue, CHN1, TX_RX_MESSAGES) == 0x00)
	{
		printf("%d  messages received\n", retValue);
		for (int i = 0; i < (int)retValue; i++)
		{
			ProcessCANMsg1(recMessageBuffs[i]);
		}
	}
	else
		printf("tsfifo_receive_can_msgs executed failed");
}


void TestCANFDAPI(TSCANLINApi* tsCANLINAPIObj, size_t ADeviceHandle)
{
	s32 retValue = 0;
	/*定义CAN发送报文，并填充数据*/
	//注册接收回调函数：类似于接收中断
	if (tsCANLINAPIObj->tscan_register_event_can(ADeviceHandle, ReceiveCANMessage1) == 0)
	{
		printf("CAN Device with handle:%zu register rev callback success\n", ADeviceHandle);
	}
	else
	{
		printf("CAN Device with handle:%zu register rev callback failed\n", ADeviceHandle);
	}
	//设置通讯波特率相关参数：
	//设置通道1，仲裁场波特率为500，数据长波特率：2000（当经典CAN模式下，数据场波特率无意义）,lfdtCAN:经典CAN模式，普通工作模式，使能内部120Ω终端电阻
	int ret = tsCANLINAPIObj->tscan_config_canfd_by_baudrate(ADeviceHandle, CHN1, 1000, 2000, lfdtCAN, lfdmNormal, 1);
	if (ret == 0)
	{
		printf("CANFD Device with handle:%zu set baudrate 1000k , 2000k success\n", ADeviceHandle);
	}
	else
	{
		printf("CANFD Device with handle:%zu set baudrate 1000k,2000k failed\n", ADeviceHandle);
	}
	//同步函数发送CAN报文
	//FD Message Send
	TLibCAN canMsg;
	canMsg.FIdentifier = 0x03;
	canMsg.FProperties.bits.extframe = 0;
	canMsg.FProperties.bits.remoteframe = 0x00; //not remote frame,standard frame
	canMsg.FData.d[0] = 0x01;
	canMsg.FData.d[1] = 0x02;
	canMsg.FData.d[2] = 0x03;
	canMsg.FDLC = 3;
	canMsg.FIdxChn = CHN1;
	//CAN Message Send
	if (tsCANLINAPIObj->tscan_transmit_can_sync(ADeviceHandle, &canMsg, 500) == 0)
	{
		printf("CAN Device with handle:%zu sync send can message success\n", ADeviceHandle);
	}
	else
	{
		printf("CAN Device with handle:%zu sync send can message failed\n", ADeviceHandle);
	}
	//异步函数发送CAN报文：
	if (tsCANLINAPIObj->tscan_transmit_can_async(ADeviceHandle, &canMsg) == 0)
	{
		printf("CAN Device with handle:%zu async send can message success\n", ADeviceHandle);
	}
	else
	{
		printf("CAN Device with handle:%zu async send can message failed\n", ADeviceHandle);
	}
	canMsg.FIdentifier = 0x55;
	if(tsCANLINAPIObj->tscan_add_cyclic_msg_can(ADeviceHandle, &canMsg, 500) == 0)
	{
	printf("CAN Device with handle:%zu start send cyclic can message success\n", ADeviceHandle);
	}
	else
	{
		printf("CAN Device with handle:%zu async send cyclic can message failed\n", ADeviceHandle);
	}
	Sleep(3000);
	if (tsCANLINAPIObj->tscan_delete_cyclic_msg_can(ADeviceHandle, &canMsg) == 0)
	{
		printf("CAN Device with handle:%zu stop send cyclic can message success\n", ADeviceHandle);
	}
	else
	{
		printf("CAN Device with handle:%zu async stop send cyclic can message failed\n", ADeviceHandle);
	}
	//FD Message Send
	TLibCANFD CANFDMsg;
	CANFDMsg.FIdentifier = 0x03;
	CANFDMsg.FProperties.bits.extframe = 0;
	CANFDMsg.FProperties.bits.remoteframe = 0x00; //not remote frame,standard frame
	CANFDMsg.FDLC = 3;
	CANFDMsg.FIdxChn = CHN1;
	//同步函数发送CANFD报文
	if (tsCANLINAPIObj->tscan_transmit_canfd_sync(ADeviceHandle, &CANFDMsg, 500) == 0)
	{
		printf("CAN Device with handle:%zu sync send can message success\n", ADeviceHandle);
	}
	else
	{
		printf("CAN Device with handle:%zu sync send can message failed\n", ADeviceHandle);
	}
	//异步函数发送CANFD报文：
	if (tsCANLINAPIObj->tscan_transmit_canfd_async(ADeviceHandle, &CANFDMsg) == 0)
	{
		printf("CAN Device with handle:%zu async send can message success\n", ADeviceHandle);
	}
	else
	{
		printf("CAN Device with handle:%zu async send can message failed\n", ADeviceHandle);
	}
	//读取CAN报文
	TLibCAN recMessageCANBuffs[5];
	//TX_RX_DATA 发送出去的数据和接收的数据都读取进来，
	retValue = 5; //set receive buffer size
	if (tsCANLINAPIObj->tsfifo_receive_can_msgs(ADeviceHandle, recMessageCANBuffs, &retValue, CHN1, TX_RX_MESSAGES) == 0x00)
	{
		printf("%d CAN messages received\n", retValue);
		for (int i = 0; i < (int)retValue; i++)
		{
			ProcessCANMsg1(recMessageCANBuffs[i]);
		}
	}
	else
	{
		printf("tsfifo_receive_can_msgs executed  failed");
	}
	//读取CANFD报文
	TLibCANFD recMessageCANFDBuffs[5];
	retValue = 5;
	if (tsCANLINAPIObj->tsfifo_receive_canfd_msgs(ADeviceHandle, recMessageCANFDBuffs, &retValue, CHN1, TX_RX_MESSAGES) == 0x00)
	{
		printf("%d CANFD messages received\n", retValue);
		for (int i = 0; i < (int)retValue; i++)
		{
			//ProcessCANFDMsg1(recMessageCANFDBuffs[i]);
		}
	}
	else
	{
		printf("tsfifo_receive_canfd_msgs executed failed");
	}
}

void InitFlexrayNode(TSCANLINApi* tsCANLINAPIObj, size_t ADeviceHandle, int AChnIdx)
{
	TLibFlexray_controller_config	controllerConfig;
	int FrameLength[3];
	int frameNum;
	TLibTrigger_def vFrameTriggerList[3];
	int channelIndex = AChnIdx;
	controllerConfig.NETWORK_MANAGEMENT_VECTOR_LENGTH = 8;
	controllerConfig.PAYLOAD_LENGTH_STATIC = 16;
	controllerConfig.LATEST_TX = 124;
	// __ prtc1Control
	controllerConfig.T_S_S_TRANSMITTER = 9;
	controllerConfig.CAS_RX_LOW_MAX = 87;
	controllerConfig.SPEED = 0;
	controllerConfig.WAKE_UP_SYMBOL_RX_WINDOW = 301;
	if (channelIndex == 0)
		controllerConfig.WAKE_UP_PATTERN = 43;
	else
		controllerConfig.WAKE_UP_PATTERN = 42;
	// __ prtc2Control
	controllerConfig.WAKE_UP_SYMBOL_RX_IDLE = 59;
	controllerConfig.WAKE_UP_SYMBOL_RX_LOW = 55;
	controllerConfig.WAKE_UP_SYMBOL_TX_IDLE = 180;
	controllerConfig.WAKE_UP_SYMBOL_TX_LOW = 60;
	// __ succ1Config
	controllerConfig.channelAConnectedNode = 1;// 是否启用通道A,0不启动，1启动
	controllerConfig.channelBConnectedNode = 1;// 是否启用通道B,0不启动，1启动
	controllerConfig.channelASymbolTransmitted = 1;// 是否启用通道A的符号传输功能,0不启动，1启动
	controllerConfig.channelBSymbolTransmitted = 1;// 是否启用通道B的符号传输功能,0不启动，1启动
	controllerConfig.ALLOW_HALT_DUE_TO_CLOCK = 1;
	controllerConfig.SINGLE_SLOT_ENABLED = 0;// FALSE_0, TRUE_1
	controllerConfig.wake_up_idx = 0;// 唤醒通道选择， 0_通道A， 1 通道B
	controllerConfig.ALLOW_PASSIVE_TO_ACTIVE = 2;
	controllerConfig.COLD_START_ATTEMPTS = 10;
	controllerConfig.synchFrameTransmitted = 1;// 本节点是否需要发送同步报文
	controllerConfig.startupFrameTransmitted = 1;// 本节点是否需要发送启动报文
				// __ succ2Config
	controllerConfig.LISTEN_TIMEOUT = 401202;
	controllerConfig.LISTEN_NOISE = 2;//2_16
				// __ succ3Config
	controllerConfig.MAX_WITHOUT_CLOCK_CORRECTION_PASSIVE = 10;
	controllerConfig.MAX_WITHOUT_CLOCK_CORRECTION_FATAL = 14;
	//uint8_t REVERS0;//内存对齐
	// __ gtuConfig
	// __ gtu01Config
	controllerConfig.MICRO_PER_CYCLE = 200000;
	// __ gtu02Config
	controllerConfig.Macro_Per_Cycle = 5000;
	controllerConfig.SYNC_NODE_MAX = 8;
	//uint8_t REVERS1;//内存对齐
	// __ gtu03Config
	controllerConfig.MICRO_INITIAL_OFFSET_A = 31;
	controllerConfig.MICRO_INITIAL_OFFSET_B = 31;
	controllerConfig.MACRO_INITIAL_OFFSET_A = 11;
	controllerConfig.MACRO_INITIAL_OFFSET_B = 11;
	// __ gtu04Config
	controllerConfig.N_I_T = 44;
	controllerConfig.OFFSET_CORRECTION_START = 4981;
	// __ gtu05Config
	controllerConfig.DELAY_COMPENSATION_A = 1;
	controllerConfig.DELAY_COMPENSATION_B = 1;
	controllerConfig.CLUSTER_DRIFT_DAMPING = 2;
	controllerConfig.DECODING_CORRECTION = 48;
	// __ gtu06Config
	controllerConfig.ACCEPTED_STARTUP_RANGE = 212;
	controllerConfig.MAX_DRIFT = 601;
	// __ gtu07Config
	controllerConfig.STATIC_SLOT = 61;
	controllerConfig.NUMBER_OF_STATIC_SLOTS = 60;
	// __ gtu08Config
	controllerConfig.MINISLOT = 10;
	//uint8_t REVERS2;//内存对齐
	controllerConfig.NUMBER_OF_MINISLOTS = 129;
	// __ gtu09Config
	controllerConfig.DYNAMIC_SLOT_IDLE_PHASE = 0;
	controllerConfig.ACTION_POINT_OFFSET = 9;
	controllerConfig.MINISLOT_ACTION_POINT_OFFSET = 3;
	//uint8_t REVERS3;//内存对齐
	// __ gtu10Config
	controllerConfig.OFFSET_CORRECTION_OUT = 378;
	controllerConfig.RATE_CORRECTION_OUT = 601;
	// __ gtu11Config
	controllerConfig.EXTERN_OFFSET_CORRECTION = 0;
	controllerConfig.EXTERN_RATE_CORRECTION = 0;
	controllerConfig.config_byte1 = 1;  //启动桥接功能，启用接收FIFO，启动终端电阻
	controllerConfig.config_byte = 0xbF;  //启动桥接功能，启用接收FIFO，启动终端电阻
	if (channelIndex == 0)
	{
		FrameLength[0] = 32;
		FrameLength[1] = 32;
		FrameLength[2] = 32;
		vFrameTriggerList[0].frame_idx = 0;
		vFrameTriggerList[0].slot_id = 1;
		vFrameTriggerList[0].cycle_code = 1;//BASE-CYCLE + CYCLE-REPETITION
		vFrameTriggerList[0].config_byte = 0x33;
		vFrameTriggerList[1].frame_idx = 1;
		vFrameTriggerList[1].slot_id = 3;
		vFrameTriggerList[1].cycle_code = 4;//BASE-CYCLE + CYCLE-REPETITION
		vFrameTriggerList[1].config_byte = 0x07;
		vFrameTriggerList[2].frame_idx = 2;
		vFrameTriggerList[2].slot_id = 3;
		vFrameTriggerList[2].cycle_code = 7;//BASE-CYCLE + CYCLE-REPETITION
		vFrameTriggerList[2].config_byte = 0x03;       //3 is A,B Channel
		frameNum = 3;
	}
	else
	{
		FrameLength[0] = 32;
		vFrameTriggerList[0].frame_idx = 0;
		vFrameTriggerList[0].slot_id = 2;
		vFrameTriggerList[0].cycle_code = 4;//BASE-CYCLE + CYCLE-REPETITION
		vFrameTriggerList[0].config_byte = 0x33;    //3 is A,B Channel
		frameNum = 1;
	}

	if (tsCANLINAPIObj->tsflexray_set_controller_frametrigger(ADeviceHandle, channelIndex, &controllerConfig, &FrameLength[0], frameNum, &vFrameTriggerList[0], frameNum, 1000) == 0) {
		printf("Config node %d  Success\r\n", channelIndex);
	}
	else
	{
		printf("Config node %d Failed\t\n", channelIndex);
	}
}

void FlexrayReadDataTest(TSCANLINApi* tsCANLINAPIObj, size_t ADeviceHandle)
{
	TLibFlexRay	flexrayDataArray[100];
	int flexrayDataSize;
	int i;
	if (ADeviceHandle > 0)
	{
	    flexrayDataSize = 100;
		if (tsCANLINAPIObj->tsfifo_receive_flexray_msgs(ADeviceHandle,
			&flexrayDataArray[0],
			&flexrayDataSize,
			0xFF, //read all channel
			1) == 0)
		{
			printf("Received Data Count:%d\r\n", flexrayDataSize);
			for(i = 0; i< flexrayDataSize; i++)
			{
				if (flexrayDataArray[i].FFrameType == 0)
				{
					printf("SlotID:%d, CycleNumer:%d\r\n", flexrayDataArray[i].FSlotId, flexrayDataArray[i].FCycleNumber);
				}
			}
		}
	}
}


void TestFlexrayAPI(TSCANLINApi* tsCANLINAPIObj, size_t ADeviceHandle)
{
	printf("Start Flexray Test\r\n");
	InitFlexrayNode(tsCANLINAPIObj, ADeviceHandle, 0);  //Channel1
	InitFlexrayNode(tsCANLINAPIObj, ADeviceHandle, 1);  //Channel2
	tsCANLINAPIObj->tsflexray_start_net(ADeviceHandle, 0, 1000);
	tsCANLINAPIObj->tsflexray_start_net(ADeviceHandle, 1, 1000);
	int starttick = GetTickCount();
	int endtick = starttick;
	do
	{
		endtick = GetTickCount();
		FlexrayReadDataTest(tsCANLINAPIObj, ADeviceHandle);
		Sleep(10);
	} while ((endtick - starttick) < 5000);
	tsCANLINAPIObj->tsflexray_stop_net(ADeviceHandle, 0, 1000);
	tsCANLINAPIObj->tsflexray_stop_net(ADeviceHandle, 1, 1000);
	printf("End Flexray Test\r\n");
}



void TSCANLINApi_CPP_Demo()
{
	TSCANLINApi* tsCANLINAPIObj = new TSCANLINApi(true);   //True:使用硬件时间戳，则可以确保不同进程之间时间统一； False：使用相对时间，该时间位本进程启动后的时间
	uint32_t ADeviceCount;
	size_t ADeviceHandle;
	uint32_t retValue;

	printf("TOSUN TSCANLINAPI CPP Demo\n");
	//扫描存在的设备：不是必须调用的
	if (tsCANLINAPIObj->tscan_scan_devices(&ADeviceCount) == 0)
	{
		printf("TSCAN Device Count:%d\n", ADeviceCount);
	}
	//连接设备：使用设备前必须调用
	retValue = tsCANLINAPIObj->tscan_connect(0, &ADeviceHandle);
	if ((retValue == 0) || (retValue == 5))
	{
		printf("TSCANLIN Device with handle:%zu connectted\n", ADeviceHandle);
	}
#ifdef TEST_CAN_API
	TestCANAPI(tsCANLINAPIObj, ADeviceHandle);
#endif
#ifdef TEST_CANFD_API
	TestCANFDAPI(tsCANLINAPIObj, ADeviceHandle);
#endif
#ifdef TEST_LIN_API
	TestLINAPI(tsCANLINAPIObj, ADeviceHandle);
#endif
#ifdef TEST_FLEXRAY_API
	TestFlexrayAPI(tsCANLINAPIObj, ADeviceHandle);
#endif
	//Sample: Precise Replay
	//First Set Mapping
#ifdef TEST_REPLAY
	tsCANLINAPIObj->Replay_RegisterReplayMapChannel(ADeviceHandle, CHN2, CHN1);  //Mapping channel2 data to channel 1 of ADeviceHandle
	tsCANLINAPIObj->Replay_RegisterReplayMapChannel(ADeviceHandle, CHN2, CHN3);  //Mapping channel2 data to channel 3 of ADeviceHandle
	tsCANLINAPIObj->Replay_Start_Blf(ADeviceHandle, (char*)"a.blf", 0, 0, 0xFFFFFFFF);
#endif
	Sleep(3000);
	if (tsCANLINAPIObj->tscan_disconnect_by_handle(ADeviceHandle) == 0)
	{
		printf("Disconnect device with handle:%zu success\n", ADeviceHandle);
	}
	tsCANLINAPIObj->FreeTSCANApi();
	//释放API库
	free(tsCANLINAPIObj);
	//std::cout << "end dll!\n";
	printf("End C++ TSCANAPI CPP Demo\n");
}


