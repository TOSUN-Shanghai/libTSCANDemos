// test_tscan_dll.cpp : ���ļ����� "main" ����������ִ�н��ڴ˴���ʼ��������
//

#include <iostream>
#include <windows.h>  
#include "TSCANLINApi.h"


#define TEST_CAN_API
//#define TEST_LIN_API
//#define TEST_CANFD_API

extern void ProcessLINMsg(TLibLIN AMsg);

/// <summary>
/// CAN���Ľ��ջص�����
/// </summary>
/// <param name="AData">CAN����ָ��</param>
/// <returns></returns>
void __stdcall ReceiveCANMessage(const TLibCAN* AData)
{

}

/*���ע���˱��������������յ���һ֡LIN���Ĺ��󣬾ͻᴥ���˺���*/
/// <summary>
/// LIN���Ľ��ջص�����
/// </summary>
/// <param name="AData">LIN����ָ��</param>
/// <returns></returns>
void __stdcall ReceiveLINMessage(const TLibLIN* AData)
{
	//ͨ���ص�������ȡ����
	printf("Receive Recall\n");
	ProcessLINMsg(*AData);
}


/*���ע���˱��������������յ���һ֡LIN���Ĺ��󣬾ͻᴥ���˺���*/
/// <summary>
/// LIN���Ľ��ջص�����
/// </summary>
/// <param name="AData">LIN����ָ��</param>
/// <returns></returns>
void __stdcall ReceiveFastLINMessage(const TLibLIN* AData)
{
	//ͨ���ص�������ȡ����
	printf("Receive FastLIN Recall\n");
	ProcessLINMsg(*AData);
}

/// <summary>
/// �����յ���LIN��������
/// </summary>
/// <param name="AMsg">LIN����</param>
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
	/*����CAN���ͱ��ģ����������*/
	TLibLIN msg;
	//�ѵ�ǰ�豸����Ϊ���ڵ�ģʽ�����ڵ�ģʽ�£����ܹ��������ȱ��ģ����ͱ���ͷ��
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
	//����ڲ�ldf�ļ�
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
	//ע����ջص������������ڽ����ж�
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
	//ע��FalstLIN���ջص������������ڽ����ж�
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
	//���ò�����
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
	//ͬ����������LIN����
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
		//ֱ�Ӷ�ȡ����
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
	//ע�⣺����LIN������˵�����Ҫ���ձ��ģ�ҲҪ���ñ��ķ��ͺ���sendMsgAsync����istx����Ϊ0��ʵ����
	//�ǰѱ���֡ͷ���ͳ�ȥ����ȡ�����ϵı���
	msg.FIdentifier = 0x31;
	msg.FProperties.value = 0x00;
	msg.FProperties.bits.istx = 0; // as rx frame
	msg.FDLC = 3;
	msg.FIdxChn = 0;
	tslin_transmit_lin_async_t sendMsgASync = (tslin_transmit_lin_async_t)GetProcAddress(hDll, "tslin_transmit_lin_async");  //�첽��������LIN����
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
	//���ڽ������͵ı��ģ�����ӽڵ�û�м�ʱ�ظ�����retValue =0,����ʧ��
	Sleep(10);
	if (receiveFunc != NULL)
	{
		int cnt = 0;
		retValue = 0;
		//������ʱ�ȴ��ķ�ʽ��ֱ����ȡ��LIN���Ļ��߳�ʱ
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
		//�����ʱ�����ղ������ݣ����������ʧ��
		printf("%d  messages received\n", retValue);
		for (int i = 0; i < (int)retValue; i++)
		{
			ProcessLINMsg(recMessageBuffs[i]);
		}
	}
	msg.FIdentifier = 0x32;
	tslin_transmit_fastlin_async_t sendFastLINMsgAsync = (tslin_transmit_fastlin_async_t)GetProcAddress(hDll, "tslin_transmit_fastlin_async");  //�첽��������LIN����
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
	//���ڽ������͵ı��ģ�����ӽڵ�û�м�ʱ�ظ�����retValue =0,����ʧ��
	tsfifo_receive_fastlin_msgs_t receiveFastLINFunc = (tsfifo_receive_fastlin_msgs_t)GetProcAddress(hDll, "tsfifo_receive_fastlin_msgs");
	Sleep(10);
	if (receiveFastLINFunc != NULL)
	{
		retValue = 0;
		int cnt = 0;
		//������ʱ�ȴ��ķ�ʽ��ֱ����ȡ��LIN���Ļ��߳�ʱ
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
		//�����ʱ�����ղ������ݣ����������ʧ��
		printf("%d  messages received\n", retValue);
		for (int i = 0; i < (int)retValue; i++)
		{
			ProcessLINMsg(recMessageBuffs[i]);
		}
	}
	//��ע����ջص�����
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
	//��ע��FastLIN���ջص�����
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
	/*����CAN���ͱ��ģ����������*/
	TLibCAN msg;
	msg.FIdentifier = 0x03;
	msg.FProperties.bits.remoteframe = 0x00; //not remote frame,standard frame
	msg.FProperties.bits.extframe = 0;
	msg.FDLC = 3;
	msg.FIdxChn = 0;
	//ע����ջص������������ڽ����ж�
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
	//���ò�����
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
	//ͬ����������CAN����
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
	//�첽��������CAN���ģ�
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
			//����㣺�������ݰ���Request Array�������Ҷ�ȡ�ڵ㷵�ص����ݰ���Response Array��
			tstp_can_request_and_get_response_t tstp_can_request_and_get_response = (tstp_can_request_and_get_response_t)GetProcAddress(hDll, "tstp_can_request_and_get_response");
			if (tstp_can_request_and_get_response != NULL)
			{
				byte reqArray[2] = {0x10,0x02};
				byte resArray[10];
				int responseArraySize = 10;   //ÿһ�ε���tstp_can_request_and_response֮ǰ��responseArraySize����Ҫ����ֵ������Ӧ��Buffer�Ĵ�С
				retValue = tstp_can_request_and_get_response(FDiagHandle, reqArray, 2, resArray, &responseArraySize);
				if (retValue == 0x00)
				{
					printf("Request and response success, the real response data size is %d\n", responseArraySize);
				}
			}
			//����㣬������������
            tsdiag_can_request_download_t tsdiag_can_request_download = (tsdiag_can_request_download_t)GetProcAddress(hDll, "tsdiag_can_request_download");
			if (tsdiag_can_request_download != NULL)
			{
				//FDiagHandle:���ģ����
				//0x08000000:�������ص����ݵ�ַ
				//0x20000:�������ص����ݳ���
				//0x1000:��ʱʱ��
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
	/*Load TSCAN Dll:����libTSCAN���ļ�*/
	HMODULE hDll = LoadLibrary(TEXT("./libTSCAN.dll"));
	if (hDll != NULL)
	{
		std::cout << "find libTSCAN.dll!\n";
		uint32_t ADeviceCount;
		size_t ADeviceHandle = 0x00;
		uint32_t retValue;
		/*����initialize_lib_tscan�����������⣬���øú�����ʼ�����ļ����󣬲��ܵ��ÿ��ļ��е�API�����ӿ�*/
		initialize_lib_tscan_t initialTSCAN = (initialize_lib_tscan_t)GetProcAddress(hDll, "initialize_lib_tscan");
		//ɨ����ڵ��豸�����Ǳ�����õ�
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
		/*����tscan_scan_devices��ɨ�赱ǰ���ڵ����ϵĸ���TSCAN�豸*/
		tscan_scan_devices_t ScanTSCANDevices = (tscan_scan_devices_t)GetProcAddress(hDll, "tscan_scan_devices");
		//ɨ����ڵ��豸�����Ǳ�����õ�
		if (ScanTSCANDevices != NULL)
		{
			ScanTSCANDevices(&ADeviceCount);
			printf("TSCAN Device Count:%d\n", ADeviceCount);
		}
		/*�����豸��ʹ���豸ǰ�������*/
		tscan_connect_t connectDevice_f = (tscan_connect_t)GetProcAddress(hDll, "tscan_connect");
		if (connectDevice_f != NULL)
		{
			/*������"":�������������һ���豸
			        "���к�"������ִ�д��кŵ��豸*/
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
		/*��ȡdisConnectDevice_f�����ڶϿ��豸����*/
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
		/*��ȡfinalize_lib_tscan_t�������ͷ�TSCANApi�����⣬��initialTSCAN�ǳɶ�ʹ�õ�*/
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


