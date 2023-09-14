// test_tscan_dll.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include <iostream>
#include <windows.h>  
#include "TSCANLINApi.h"


#define TEST_CAN_API
//#define TEST_LIN_API
//#define TEST_CANFD_API

extern void ProcessLINMsg(TLibLIN AMsg);

/// <summary>
/// CAN报文接收回调函数
/// </summary>
/// <param name="AData">CAN报文指针</param>
/// <returns></returns>
void __stdcall ReceiveCANMessage(const TLibCAN* AData)
{

}

/*如果注册了本函数，当驱动收到了一帧LIN报文过后，就会触发此函数*/
/// <summary>
/// LIN报文接收回调函数
/// </summary>
/// <param name="AData">LIN报文指针</param>
/// <returns></returns>
void __stdcall ReceiveLINMessage(const TLibLIN* AData)
{
	//通过回调函数读取数据
	printf("Receive Recall\n");
	ProcessLINMsg(*AData);
}


/*如果注册了本函数，当驱动收到了一帧LIN报文过后，就会触发此函数*/
/// <summary>
/// LIN报文接收回调函数
/// </summary>
/// <param name="AData">LIN报文指针</param>
/// <returns></returns>
void __stdcall ReceiveFastLINMessage(const TLibLIN* AData)
{
	//通过回调函数读取数据
	printf("Receive FastLIN Recall\n");
	ProcessLINMsg(*AData);
}

/// <summary>
/// 处理收到的LIN报文数据
/// </summary>
/// <param name="AMsg">LIN报文</param>
/// <returns></returns>
void ProcessLINMsg(TLibLIN AMsg)
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


void TestLINAPI(HMODULE hDll, size_t ADeviceHandle)
{
	s32 retValue;
	/*定义CAN发送报文，并填充数据*/
	TLibLIN msg;
	//把当前设备设置为主节点模式：主节点模式下，才能够主动调度报文，发送报文头等
	tslin_set_node_funtiontype_t setfunctionType = (tslin_set_node_funtiontype_t)GetProcAddress(hDll, "tslin_set_node_funtiontype");
	if (setfunctionType != NULL)
	{
		retValue = setfunctionType(ADeviceHandle, CHN1, (u8)MasterNode); //set as master node
		if (retValue == 0)
		{
			printf("LIN Device with handle:%zu set function type success\n", ADeviceHandle);
		}
		else
		{
			printf("LIN Device with handle:%zu set function type failed\n", ADeviceHandle);
		}
	}
	//清除内部ldf文件
	tslin_clear_schedule_tables_t clearscheduletable = (tslin_clear_schedule_tables_t)GetProcAddress(hDll, "tslin_clear_schedule_tables");
	if (clearscheduletable != NULL)
	{
		retValue = clearscheduletable(ADeviceHandle, CHN1);
		if (retValue == 0)
		{
			printf("LIN Device with handle:%zu apply new ldf callback success\n", ADeviceHandle);
		}
		else
		{
			printf("LIN Device with handle:%zu apply new ldf callback failed\n", ADeviceHandle);
		}
	}
	//注册接收回调函数：类似于接收中断
	tslin_register_event_lin_t registerRevCallback = (tslin_register_event_lin_t)GetProcAddress(hDll, "tslin_register_event_lin");
	if (registerRevCallback != NULL)
	{
		retValue = registerRevCallback(ADeviceHandle, ReceiveLINMessage);
		if (retValue == 0)
		{
			printf("LIN Device with handle:%zu register rev callback success\n", ADeviceHandle);
		}
		else
		{
			printf("LIN Device with handle:%zu register rev callback failed\n", ADeviceHandle);
		}
	}
	//注册FalstLIN接收回调函数：类似于接收中断
	tscan_register_event_fastlin_t registerFastLINRevCallback = (tscan_register_event_fastlin_t)GetProcAddress(hDll, "tscan_register_event_fastlin");
	if (registerFastLINRevCallback != NULL)
	{
		retValue = registerFastLINRevCallback(ADeviceHandle, ReceiveFastLINMessage);
		if (retValue == 0)
		{
			printf("LIN Device with handle:%zu register rev callback success\n", ADeviceHandle);
		}
		else
		{
			printf("LIN Device with handle:%zu register rev callback failed\n", ADeviceHandle);
		}
	}
	//设置波特率
	tslin_config_baudrate_t setBaudrate = (tslin_config_baudrate_t)GetProcAddress(hDll, "tslin_config_baudrate");
	if (setBaudrate != NULL)
	{
		retValue = setBaudrate(ADeviceHandle, CHN1, 100,LIN_Protocol_21);  //100kbps
		if (retValue == 0)
		{
			printf("LIN Device with handle:%zu set baudrate success\n", ADeviceHandle);
		}
		else
		{
			printf("LIN Device with handle:%zu set baudrate failed\n", ADeviceHandle);
		}
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
	tslin_transmit_lin_sync_t sendMsgSync = (tslin_transmit_lin_sync_t)GetProcAddress(hDll, "tslin_transmit_lin_sync");
	if (sendMsgSync != NULL)
	{
		retValue = sendMsgSync(ADeviceHandle, &msg, 500);
		if (retValue == 0)
		{
			printf("LIN Device with handle:%zu sync send lin message success\n", ADeviceHandle);
		}
		else
		{
			printf("LIN Device with handle:%zu sync send lin message failed\n", ADeviceHandle);
		}
	}
	//LIN Receive Function
	Sleep(3);
	tsfifo_receive_lin_msgs_t receiveFunc = (tsfifo_receive_lin_msgs_t)GetProcAddress(hDll, "tsfifo_receive_lin_msgs");
	TLibLIN recMessageBuffs[5];
	if (receiveFunc != NULL)
	{
		//直接读取数据
		retValue = 5;
		if (receiveFunc(ADeviceHandle, recMessageBuffs, &retValue, CHN1, ONLY_RX_MESSAGES) == 0x00)
		{
			printf("%d  messages received\n", retValue);
			for (int i = 0; i < (int)retValue; i++)
			{
				ProcessLINMsg(recMessageBuffs[i]);
			}
		}
		else
		{
			printf("tsfifo_receive_lin_msgs execute failed\n");
		}
	}
	//注意：对于LIN总线来说，如果要接收报文，也要调用报文发送函数sendMsgAsync，把istx设置为0，实际上
	//是把报文帧头发送出去并读取总线上的报文
	msg.FIdentifier = 0x31;
	msg.FProperties.value = 0x00;
	msg.FProperties.bits.istx = 0; // as rx frame
	msg.FDLC = 3;
	msg.FIdxChn = 0;
	tslin_transmit_lin_async_t sendMsgASync = (tslin_transmit_lin_async_t)GetProcAddress(hDll, "tslin_transmit_lin_async");  //异步函数发送LIN报文
	if (sendMsgASync != NULL)
	{
		retValue = sendMsgASync(ADeviceHandle, &msg);
		if (retValue == 0)
		{
			printf("LIN Device with handle:%zu async send lin message success\n", ADeviceHandle);
		}
		else
		{
			printf("LIN Device with handle:%zu async send lin message failed\n", ADeviceHandle);
		}
	}
	//对于接收类型的报文，如果从节点没有及时回复，则retValue =0,接收失败
	Sleep(10);
	if (receiveFunc != NULL)
	{
		int cnt = 0;
		retValue = 0;
		//采用延时等待的方式，直到读取到LIN报文或者超时
		while ((retValue == 0) && (cnt < 100))
		{
			retValue = 5;  //set receive buffer size
			if (receiveFunc(ADeviceHandle, recMessageBuffs, &retValue, CHN1, ONLY_RX_MESSAGES) == 0x00)
			{
				cnt++;
				Sleep(10);
			}
			else
			{
				retValue = 0; //receive no message
				//receiveFunc function executed failed
			}
		}
		//如果超时都还收不到数据，则接收数据失败
		printf("%d  messages received\n", retValue);
		for (int i = 0; i < (int)retValue; i++)
		{
			ProcessLINMsg(recMessageBuffs[i]);
		}
	}
	msg.FIdentifier = 0x32;
	tslin_transmit_fastlin_async_t sendFastLINMsgAsync = (tslin_transmit_fastlin_async_t)GetProcAddress(hDll, "tslin_transmit_fastlin_async");  //异步函数发送LIN报文
	if (sendFastLINMsgAsync != NULL)
	{
		retValue = sendFastLINMsgAsync(ADeviceHandle, &msg);
		if (retValue == 0)
		{
			printf("LIN Device with handle:%zu async fast lin send lin message success\n", ADeviceHandle);
		}
		else
		{
			printf("LIN Device with handle:%zu async fast lin send lin message failed\n", ADeviceHandle);
		}
	}
	//对于接收类型的报文，如果从节点没有及时回复，则retValue =0,接收失败
	tsfifo_receive_fastlin_msgs_t receiveFastLINFunc = (tsfifo_receive_fastlin_msgs_t)GetProcAddress(hDll, "tsfifo_receive_fastlin_msgs");
	Sleep(10);
	if (receiveFastLINFunc != NULL)
	{
		retValue = 0;
		int cnt = 0;
		//采用延时等待的方式，直到读取到LIN报文或者超时
		while ((retValue == 0) && (cnt < 100))
		{
			retValue = 5; //set  buffersize = 5;
			if (receiveFastLINFunc(ADeviceHandle, recMessageBuffs, &retValue, CHN1, ONLY_RX_MESSAGES) == 0x00)
			{
				cnt++;
				Sleep(10);
			}
			else
			{
				retValue = 0; //receiveFastLINFunc executed failed
			}
		}
		//如果超时都还收不到数据，则接收数据失败
		printf("%d  messages received\n", retValue);
		for (int i = 0; i < (int)retValue; i++)
		{
			ProcessLINMsg(recMessageBuffs[i]);
		}
	}
	//反注册接收回调函数
	tslin_unregister_event_lin_t unregisterRevCallback = (tslin_unregister_event_lin_t)GetProcAddress(hDll, "tslin_unregister_event_lin");
	if (unregisterRevCallback != NULL)
	{
		retValue = unregisterRevCallback(ADeviceHandle, ReceiveLINMessage);
		if (retValue == 0)
		{
			printf("LIN Device with handle:%zu unregister rev callback success\n", ADeviceHandle);
		}
		else
		{
			printf("LIN Device with handle:%zu unregister rev callback failed\n", ADeviceHandle);
		}
	}
	//反注册FastLIN接收回调函数
	tscan_unregister_event_fastlin_t unregisterFastLINRevCallback = (tscan_unregister_event_fastlin_t)GetProcAddress(hDll, "tscan_unregister_event_fastlin");
	if (unregisterFastLINRevCallback != NULL)
	{
		retValue = unregisterFastLINRevCallback(ADeviceHandle, ReceiveFastLINMessage);
		if (retValue == 0)
		{
			printf("LIN Device with handle:%zu unregister rev callback success\n", ADeviceHandle);
		}
		else
		{
			printf("LIN Device with handle:%zu unregister rev callback failed\n", ADeviceHandle);
		}
	}
}


void TestCANAPI(HMODULE hDll, size_t ADeviceHandle)
{
	uint32_t retValue;
	int FDiagHandle = 0;
	/*定义CAN发送报文，并填充数据*/
	TLibCAN msg;
	msg.FIdentifier = 0x03;
	msg.FProperties.bits.remoteframe = 0x00; //not remote frame,standard frame
	msg.FProperties.bits.extframe = 0;
	msg.FDLC = 3;
	msg.FIdxChn = 0;
	//注册接收回调函数：类似于接收中断
	tscan_register_event_can_t registerRevCallback = (tscan_register_event_can_t)GetProcAddress(hDll, "tscan_register_event_can");
	if (registerRevCallback != NULL)
	{
		retValue = registerRevCallback(ADeviceHandle, ReceiveCANMessage);
		if (retValue == 0)
		{
			printf("CAN Device with handle:%zu register rev callback success\n", ADeviceHandle);
		}
		else
		{
			printf("CAN Device with handle:%zu register rev callback failed\n", ADeviceHandle);
		}
	}
	//设置波特率
	tscan_config_canfd_by_baudrate_t setBaudrate = (tscan_config_canfd_by_baudrate_t)GetProcAddress(hDll, "tscan_config_canfd_by_baudrate");
	if (setBaudrate != NULL)
	{
		retValue = setBaudrate(ADeviceHandle, CHN1, 500,2000, lfdtISOCAN, lfdmNormal, 1);  //500,2000K
		if (retValue == 0)
		{
			printf("CAN Device with handle:%zu set baudrate (500,2000) success\n", ADeviceHandle);
		}
		else
		{
			printf("CAN Device with handle:%zu set baudrate  (500,2000) failed\n", ADeviceHandle);
		}
	}
	//同步函数发送CAN报文
	tscan_transmit_can_sync_t sendMsgSync = (tscan_transmit_can_sync_t)GetProcAddress(hDll, "tscan_transmit_can_sync");
	if (sendMsgSync != NULL)
	{
		retValue = sendMsgSync(ADeviceHandle, &msg, 500);
		if (retValue == 0)
		{
			printf("CAN Device with handle:%zu sync send can message success\n", ADeviceHandle);
		}
		else
		{
			printf("CAN Device with handle:%zu sync send can message failed\n", ADeviceHandle);
		}
	}
	//异步函数发送CAN报文：
	tscan_transmit_can_async_t sendMsgAsync = (tscan_transmit_can_async_t)GetProcAddress(hDll, "tscan_transmit_can_async");
	if (sendMsgAsync != NULL)
	{
		retValue = sendMsgAsync(ADeviceHandle, &msg);
		if (retValue == 0)
		{
			printf("CAN Device with handle:%zu async send can message success\n", ADeviceHandle);
		}
		else
		{
			printf("CAN Device with handle:%zu async send can message failed\n", ADeviceHandle);
		}
	}
	//Diagnostic
	tsdiag_can_create_t tsdiag_can_create = (tsdiag_can_create_t)GetProcAddress(hDll, "tsdiag_can_create");
	if (tsdiag_can_create != NULL)
	{
		retValue = tsdiag_can_create(&FDiagHandle, CHN1, 0, 8, 0x7E5, true, 0x7ED, true, 0x7DF, true);
		if (retValue == 0)
		{
			printf("Create Diagnostic Handle%d Success\n", FDiagHandle);
			//传输层：发送数据包（Request Array），并且读取节点返回的数据包（Response Array）
			tstp_can_request_and_get_response_t tstp_can_request_and_get_response = (tstp_can_request_and_get_response_t)GetProcAddress(hDll, "tstp_can_request_and_get_response");
			if (tstp_can_request_and_get_response != NULL)
			{
				byte reqArray[2] = {0x10,0x02};
				byte resArray[10];
				int responseArraySize = 10;   //每一次调用tstp_can_request_and_response之前，responseArraySize都需要赋初值，告诉应答Buffer的大小
				retValue = tstp_can_request_and_get_response(FDiagHandle, reqArray, 2, resArray, &responseArraySize);
				if (retValue == 0x00)
				{
					printf("Request and response success, the real response data size is %d\n", responseArraySize);
				}
			}
			//服务层，申请下载数据
            tsdiag_can_request_download_t tsdiag_can_request_download = (tsdiag_can_request_download_t)GetProcAddress(hDll, "tsdiag_can_request_download");
			if (tsdiag_can_request_download != NULL)
			{
				//FDiagHandle:诊断模块句柄
				//0x08000000:请求下载的数据地址
				//0x20000:请求下载的数据长度
				//0x1000:超时时间
				retValue = tsdiag_can_request_download(FDiagHandle, 0x08000000, 0x20000);
				if (retValue == 0x00)
				{
					printf("Request Download Success %d\n");
				}
			}
		}
	}
}



DWORD WINAPI ThreadProc(LPVOID lpParameter)
{
	return 0;
}


int TSCANLINApi_C_Demo()
{
	std::cout << "TOSUN TSCANLINAPI APIs C Demo Project Start!\n";
	/*Load TSCAN Dll:加载libTSCAN库文件*/
	HMODULE hDll = LoadLibrary(TEXT("./libTSCAN.dll"));
	if (hDll != NULL)
	{
		std::cout << "find libTSCAN.dll!\n";
		uint32_t ADeviceCount;
		size_t ADeviceHandle = 0x00;
		uint32_t retValue;
		/*引出initialize_lib_tscan，引出函数库，调用该函数初始化库文件过后，才能调用库文件中的API函数接口*/
		initialize_lib_tscan_t initialTSCAN = (initialize_lib_tscan_t)GetProcAddress(hDll, "initialize_lib_tscan");
		//扫描存在的设备：不是必须调用的
		if (initialTSCAN != NULL)
		{
			initialTSCAN(true,false,false);
			printf("Init TSCAN Api Success\n");
		}
		else
		{
			printf("Init TSCAN Api Failed\n");
			return 1;
		}
		/*引出tscan_scan_devices：扫描当前插在电脑上的各种TSCAN设备*/
		tscan_scan_devices_t ScanTSCANDevices = (tscan_scan_devices_t)GetProcAddress(hDll, "tscan_scan_devices");
		//扫描存在的设备：不是必须调用的
		if (ScanTSCANDevices != NULL)
		{
			ScanTSCANDevices(&ADeviceCount);
			printf("TSCAN Device Count:%d\n", ADeviceCount);
		}
		/*连接设备：使用设备前必须调用*/
		tscan_connect_t connectDevice_f = (tscan_connect_t)GetProcAddress(hDll, "tscan_connect");
		if (connectDevice_f != NULL)
		{
			/*参数："":则驱动随机连接一款设备
			        "串行号"：连接执行串行号的设备*/
			retValue = connectDevice_f("", &ADeviceHandle);
			if ((retValue == 0) || (retValue == 5))
			{
				printf("Device with handle:%zu connectted\n", ADeviceHandle);
			}
		}
#ifdef TEST_CAN_API
		TestCANAPI(hDll, ADeviceHandle);
#endif
#ifdef TEST_LIN_API
		TestLINAPI(hDll, ADeviceHandle);
#endif
		Sleep(300);
		/*获取disConnectDevice_f：用于断开设备连接*/
		tscan_disconnect_by_handle_t disConnectDevice_f = (tscan_disconnect_by_handle_t)GetProcAddress(hDll, "tscan_disconnect_by_handle");
		if (disConnectDevice_f != NULL)
		{
			retValue = disConnectDevice_f(ADeviceHandle);
			if ((retValue == 0))
			{
				printf("Disconnect device with handle:%zu success\n", ADeviceHandle);
			}
		}
		Sleep(300);
		/*获取finalize_lib_tscan_t：用于释放TSCANApi函数库，跟initialTSCAN是成对使用的*/
		finalize_lib_tscan_t freeTSCANApi_f = (finalize_lib_tscan_t)GetProcAddress(hDll, "finalize_lib_tscan");
		if (freeTSCANApi_f != NULL)
		{
			freeTSCANApi_f();
		}
		Sleep(3000);
		FreeLibrary(hDll);
	}
	std::cout << "end dll!\n";
	return 0;
	/*int i = 10000;
	HANDLE hThread = CreateThread(NULL, 0, ThreadProc, NULL, 0, NULL);
	while (i--)
	{
		Sleep(1000);
	}
	return 0;*/
}


