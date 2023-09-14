#include "TSCANLINApi.h"


#define IDX_ERR_DLL_NOT_READY           (77)
#define IDX_CMD_OK                      (0)
#define IDX_CMD_LOADAPI_ERR             (2)
#define IDX_FUNCTION_POINTER_NOT_READY  (3)

TSCANLINApi::TSCANLINApi(bool AUseHWTime)
{
	dllIsLoaded = 0;
	LoadAPI();	
	InitTSCANAPI(true, false, AUseHWTime);
}


TSCANLINApi::~TSCANLINApi()
{
	if (hDll != NULL)
	{
		FreeTSCANApi();
		FreeLibrary(hDll);
		hDll = NULL;
	}
	InitializePointers();
}

byte TSCANLINApi::LoadAPI()
{
	// Initializes pointers
	InitializePointers();
	// Loads the DLL
	hDll = LoadLibrary(TEXT("./libTSCAN.dll"));
	if (hDll == NULL)
	{
		return IDX_CMD_LOADAPI_ERR;
	}
	// Loads API functions
	p_initialize_lib_tscan = (initialize_lib_tscan_t)GetProcAddress(hDll, "initialize_lib_tscan");
	p_finalize_lib_tscan = (finalize_lib_tscan_t)GetProcAddress(hDll, "finalize_lib_tscan");
	//
	p_tscan_register_event_can = (tscan_register_event_can_t)GetProcAddress(hDll, "tscan_register_event_can");
	p_tscan_unregister_event_can = (tscan_unregister_event_can_t)GetProcAddress(hDll, "tscan_unregister_event_can");
	p_tscan_register_event_canfd = (tscan_unregister_event_canfd_t)GetProcAddress(hDll, "tscan_register_event_canfd");
	p_tscan_unregister_event_canfd = (tscan_unregister_event_canfd_t)GetProcAddress(hDll, "tscan_unregister_event_canfd");
	p_tslin_register_event_lin = (tslin_register_event_lin_t)GetProcAddress(hDll, "tslin_register_event_lin");
	p_tslin_unregister_event_lin = (tslin_unregister_event_lin_t)GetProcAddress(hDll, "tslin_unregister_event_lin");
	p_tscan_register_event_fastlin = (tscan_register_event_fastlin_t)GetProcAddress(hDll, "tscan_register_event_fastlin");
	p_tscan_unregister_event_fastlin = (tscan_unregister_event_fastlin_t)GetProcAddress(hDll, "tscan_unregister_event_fastlin");

	p_tscan_scan_devices = (tscan_scan_devices_t)GetProcAddress(hDll, "tscan_scan_devices");
	p_tscan_connect = (tscan_connect_t)GetProcAddress(hDll, "tscan_connect");
	p_tscan_disconnect_by_handle = (tscan_disconnect_by_handle_t)GetProcAddress(hDll, "tscan_disconnect_by_handle");
	p_tscan_disconnect_all_devices = (tscan_disconnect_all_devices_t)GetProcAddress(hDll, "tscan_disconnect_all_devices");

	//CAN Bus
	p_tscan_transmit_can_sync = (tscan_transmit_can_sync_t)GetProcAddress(hDll, "tscan_transmit_can_sync");
	p_tscan_transmit_can_async = (tscan_transmit_can_async_t)GetProcAddress(hDll, "tscan_transmit_can_async");
	p_tscan_config_can_by_baudrate = (tscan_config_can_by_baudrate_t)GetProcAddress(hDll, "tscan_config_can_by_baudrate");
	p_tsfifo_receive_can_msgs = (tsfifo_receive_can_msgs_t)GetProcAddress(hDll, "tsfifo_receive_can_msgs");

	//CANFD Bus
	p_tscan_transmit_canfd_sync = (tscan_transmit_canfd_sync_t)GetProcAddress(hDll, "tscan_transmit_canfd_sync");
	p_tscan_transmit_canfd_async = (tscan_transmit_canfd_async_t)GetProcAddress(hDll, "tscan_transmit_canfd_async");
	p_tscan_config_canfd_by_baudrate = (tscan_config_canfd_by_baudrate_t)GetProcAddress(hDll, "tscan_config_canfd_by_baudrate");
	p_tsfifo_receive_canfd_msgs = (tsfifo_receive_canfd_msgs_t)GetProcAddress(hDll, "tsfifo_receive_canfd_msgs");

	//Cyclic Message
	p_tscan_add_cyclic_msg_can  = (tscan_add_cyclic_msg_can_t)GetProcAddress(hDll, "tscan_add_cyclic_msg_can");
	p_tscan_delete_cyclic_msg_can  = (tscan_delete_cyclic_msg_can_t)GetProcAddress(hDll, "tscan_delete_cyclic_msg_can");	//去除周期发送CAN报文
	p_tscan_add_cyclic_msg_canfd  = (tscan_add_cyclic_msg_canfd_t)GetProcAddress(hDll, "tscan_add_cyclic_msg_canfd");	//添加周期发送CANFD报文
	p_tscan_delete_cyclic_msg_canfd  = (tscan_delete_cyclic_msg_canfd_t)GetProcAddress(hDll, "tscan_delete_cyclic_msg_canfd");	//去除周期发送CANFD报文
	//LIN Bus
	p_tslin_set_node_funtiontype = (tslin_set_node_funtiontype_t)GetProcAddress(hDll, "tslin_set_node_funtiontype");
	p_tslin_clear_schedule_tables = (tslin_clear_schedule_tables_t)GetProcAddress(hDll, "tslin_clear_schedule_tables");
	p_tslin_transmit_lin_sync = (tslin_transmit_lin_sync_t)GetProcAddress(hDll, "tslin_transmit_lin_sync");
	p_tslin_transmit_lin_async = (tslin_transmit_lin_async_t)GetProcAddress(hDll, "tslin_transmit_lin_async");
	p_tslin_transmit_fastlin_async = (tslin_transmit_fastlin_async_t)GetProcAddress(hDll, "tslin_transmit_fastlin_async");
	p_tslin_config_baudrate = (tslin_config_baudrate_t)GetProcAddress(hDll, "tslin_config_baudrate");
	p_tsfifo_receive_lin_msgs = (tsfifo_receive_lin_msgs_t)GetProcAddress(hDll, "tsfifo_receive_lin_msgs");
	p_tsfifo_receive_fastlin_msgs = (tsfifo_receive_fastlin_msgs_t)GetProcAddress(hDll, "tsfifo_receive_fastlin_msgs");
	//
	p_tscan_transmit_can_sequence = (tscan_transmit_can_sequence_t)GetProcAddress(hDll, "tscan_transmit_can_sequence");
	p_tscan_transmit_canfd_sequence = (tscan_transmit_canfd_sequence_t)GetProcAddress(hDll, "tscan_transmit_canfd_sequence");
	//
	pReplay_RegisterMapChannel = (tsreplay_add_channel_map_t)GetProcAddress(hDll, "tsreplay_add_channel_map");
	pReplay_ClearMapChannel = (tsreplay_clear_channel_map_t)GetProcAddress(hDll, "tsreplay_clear_channel_map");
	pReplay_Start_Blf = (tsreplay_start_blf_t)GetProcAddress(hDll, "tsreplay_start_blf");
	pReplay_Stop_Blf = (tsreplay_stop_t)GetProcAddress(hDll, "tsreplay_stop");
	//System
	p_tscan_get_error_description = (tscan_get_error_description_t)GetProcAddress(hDll, "tscan_get_error_description");
	//
	p_tsdiag_can_create = (tsdiag_can_create_t)GetProcAddress(hDll, "tsdiag_can_create");
	p_tsdiag_can_delete = (tsdiag_can_delete_t)GetProcAddress(hDll, "tsdiag_can_delete");
	p_tsdiag_can_delete_all = (tsdiag_can_delete_all_t)GetProcAddress(hDll, "tsdiag_can_delete_all");
	p_tsdiag_can_attach_to_tscan_tool = (tsdiag_can_attach_to_tscan_tool_t)GetProcAddress(hDll, "tsdiag_can_attach_to_tscan_tool");
	p_tstp_can_send_functional = (tstp_can_send_functional_t)GetProcAddress(hDll, "tstp_can_send_functional");
	p_tstp_can_send_request = (tstp_can_send_request_t)GetProcAddress(hDll, "tstp_can_send_request");
	p_tstp_can_request_and_get_response = (tstp_can_request_and_get_response_t)GetProcAddress(hDll, "tstp_can_request_and_get_response");
	p_tsdiag_can_session_control = (tsdiag_can_session_control_t)GetProcAddress(hDll, "tsdiag_can_session_control");
	p_tsdiag_can_routine_control = (tsdiag_can_routine_control_t)GetProcAddress(hDll, "tsdiag_can_routine_control");
	p_tsdiag_can_communication_control = (tsdiag_can_communication_control_t)GetProcAddress(hDll, "tsdiag_can_communication_control");
	p_tsdiag_can_security_access_request_seed = (tsdiag_can_security_access_request_seed_t)GetProcAddress(hDll, "tsdiag_can_security_access_request_seed");
	p_tsdiag_can_security_access_send_key = (tsdiag_can_security_access_send_key_t)GetProcAddress(hDll, "tsdiag_can_security_access_send_key");
	p_tsdiag_can_request_download = (tsdiag_can_request_download_t)GetProcAddress(hDll, "tsdiag_can_request_download");
	p_tsdiag_can_request_upload = (tsdiag_can_request_upload_t)GetProcAddress(hDll, "tsdiag_can_request_upload");
	p_tsdiag_can_transfer_data = (tsdiag_can_transfer_data_t)GetProcAddress(hDll, "tsdiag_can_transfer_data");
	p_tsdiag_can_request_transfer_exit = (tsdiag_can_request_transfer_exit_t)GetProcAddress(hDll, "tsdiag_can_request_transfer_exit");
	p_tsdiag_can_write_data_by_identifier = (tsdiag_can_write_data_by_identifier_t)GetProcAddress(hDll, "tsdiag_can_write_data_by_identifier");
	p_tsdiag_can_read_data_by_identifier = (tsdiag_can_read_data_by_identifier_t)GetProcAddress(hDll, "tsdiag_can_read_data_by_identifier");
	/*Flexray*/
	p_tsflexray_set_controller_frametrigger = (tsflexray_set_controller_frametrigger_t)GetProcAddress(hDll, "tsflexray_set_controller_frametrigger");
	p_tsflexray_set_controller = (tsflexray_set_controller_t)GetProcAddress(hDll, "tsflexray_set_controller");;
	p_tsflexray_set_frametrigger = (tsflexray_set_frametrigger_t)GetProcAddress(hDll, "tsflexray_set_frametrigger");
	p_tsflexray_cmdreq = (tsflexray_cmdreq_t)GetProcAddress(hDll, "tsflexray_cmdreq");
	p_tsflexray_transmit_sync = (tsflexray_transmit_sync_t)GetProcAddress(hDll, "tsflexray_transmit_sync");
    p_tsflexray_transmit_async = (tsflexray_transmit_async_t)GetProcAddress(hDll, "tsflexray_transmit_async");
	p_tsfifo_receive_flexray_msgs = (tsfifo_receive_flexray_msgs_t)GetProcAddress(hDll, "tsfifo_receive_flexray_msgs");
	p_tsfifo_clear_flexray_receive_buffers = (tsfifo_clear_flexray_receive_buffers_t)GetProcAddress(hDll, "tsfifo_clear_flexray_receive_buffers");
	p_tsflexray_start_net = (tsflexray_start_net_t)GetProcAddress(hDll, "tsflexray_start_net");
	p_tsflexray_stop_net = (tsflexray_stop_net_t)GetProcAddress(hDll, "tsflexray_stop_net");
	p_tsfifo_read_flexray_buffer_frame_count = (tsfifo_read_flexray_buffer_frame_count_t)GetProcAddress(hDll, "tsfifo_read_flexray_buffer_frame_count");
	p_tsfifo_read_flexray_tx_buffer_frame_count = (tsfifo_read_flexray_tx_buffer_frame_count_t)GetProcAddress(hDll, "tsfifo_read_flexray_tx_buffer_frame_count");
	p_tsfifo_read_flexray_rx_buffer_frame_count = (tsfifo_read_flexray_rx_buffer_frame_count_t)GetProcAddress(hDll, "tsfifo_read_flexray_rx_buffer_frame_count");

	// Checks that all functions are loaded
	dllIsLoaded = p_tscan_register_event_can && p_tscan_unregister_event_can && p_tslin_register_event_lin &&
		p_tslin_unregister_event_lin && p_tscan_register_event_fastlin && p_tscan_unregister_event_fastlin && p_tscan_scan_devices &&
		p_tscan_connect && p_tscan_disconnect_by_handle && p_tscan_disconnect_all_devices && p_finalize_lib_tscan && p_tscan_transmit_can_sync &&
		p_tscan_transmit_can_async && p_tscan_config_can_by_baudrate && p_tsfifo_receive_can_msgs && p_tscan_transmit_canfd_sync &&
		p_tscan_register_event_canfd && p_tscan_unregister_event_canfd &&
		p_tscan_transmit_canfd_async && p_tscan_config_canfd_by_baudrate && p_tsfifo_receive_canfd_msgs && p_tslin_set_node_funtiontype && p_tslin_clear_schedule_tables &&
		p_tslin_transmit_lin_sync && p_tslin_transmit_lin_async && p_tslin_transmit_fastlin_async && p_tslin_config_baudrate && p_tsfifo_receive_lin_msgs && p_tsfifo_receive_fastlin_msgs &&
		p_tscan_get_error_description && p_tsdiag_can_create && p_tsdiag_can_delete && 
		/*pReplay_RegisterMapChannel &&
		pReplay_ClearMapChannel && 
		pReplay_Start_Blf && 
		pReplay_Stop_Blf &&*/
		p_tslin_clear_schedule_tables &&
		p_tscan_transmit_canfd_sequence &&
		p_tsdiag_can_delete_all &&
		p_tsdiag_can_attach_to_tscan_tool &&
		p_tstp_can_send_functional &&
		p_tstp_can_send_request &&
		p_tstp_can_request_and_get_response &&
		p_tsdiag_can_session_control &&
		p_tsdiag_can_routine_control &&
		p_tsdiag_can_communication_control &&
		p_tsdiag_can_security_access_request_seed &&
		p_tsdiag_can_security_access_send_key &&
		p_tsdiag_can_request_download &&
		p_tsdiag_can_request_upload &&
		p_tsdiag_can_transfer_data &&
		p_tsdiag_can_request_transfer_exit &&
		p_tsdiag_can_write_data_by_identifier &&
		p_tsdiag_can_read_data_by_identifier &&
		p_tsflexray_set_controller_frametrigger &&
		p_tsflexray_set_controller&&
		p_tsflexray_set_frametrigger&&
		p_tsflexray_cmdreq &&
		p_tsflexray_transmit_sync &&
		p_tsflexray_transmit_async &&
		p_tsfifo_receive_flexray_msgs &&
		p_tsfifo_clear_flexray_receive_buffers &&
		p_tsflexray_start_net &&
		p_tsflexray_stop_net &&
		p_tsfifo_read_flexray_buffer_frame_count &&
		p_tsfifo_read_flexray_tx_buffer_frame_count &&
		p_tsfifo_read_flexray_rx_buffer_frame_count;
	;
	if (dllIsLoaded)
		return IDX_CMD_OK;
	else
		return IDX_FUNCTION_POINTER_NOT_READY;
}

void TSCANLINApi::InitializePointers()
{
	// Initializes thepointers for the PCANBasic functions
	//function Pointers
	p_tscan_register_event_can = NULL;
	p_tscan_unregister_event_can = NULL;
	p_tscan_register_event_canfd = NULL;
	p_tscan_unregister_event_canfd = NULL;
	p_tslin_register_event_lin = NULL;
	p_tslin_unregister_event_lin = NULL;
	p_tscan_register_event_fastlin = NULL;
	p_tscan_unregister_event_fastlin = NULL;

	p_tscan_scan_devices = NULL;
	p_tscan_connect = NULL;
	p_tscan_disconnect_by_handle = NULL;
	p_tscan_disconnect_all_devices = NULL;
	p_finalize_lib_tscan = NULL;

	p_tscan_transmit_can_sync = NULL;
	p_tscan_transmit_can_async = NULL;
	p_tscan_config_can_by_baudrate = NULL;
	p_tsfifo_receive_can_msgs = NULL;
	p_tslin_set_node_funtiontype = NULL;
	p_tslin_clear_schedule_tables = NULL;
	p_tslin_transmit_lin_sync = NULL;
	p_tslin_transmit_lin_async = NULL;
	p_tslin_transmit_fastlin_async = NULL;
	p_tslin_config_baudrate = NULL;
	p_tsfifo_receive_lin_msgs = NULL;
	p_tsfifo_receive_fastlin_msgs = NULL;
	p_tscan_get_error_description = NULL;
	p_tscan_transmit_can_sequence = NULL;
	p_tscan_transmit_canfd_sequence = NULL;
	//
	p_tsdiag_can_create = NULL;
	p_tsdiag_can_delete = NULL;
	p_tsdiag_can_delete_all = NULL;
	p_tsdiag_can_attach_to_tscan_tool = NULL;
	p_tstp_can_send_functional = NULL;
	p_tstp_can_send_request = NULL;
	p_tstp_can_request_and_get_response = NULL;
	p_tsdiag_can_session_control = NULL;
	p_tsdiag_can_routine_control = NULL;
	p_tsdiag_can_communication_control = NULL;
	p_tsdiag_can_security_access_request_seed = NULL;
	p_tsdiag_can_security_access_send_key = NULL;
	p_tsdiag_can_request_download = NULL;
	p_tsdiag_can_request_upload = NULL;
	p_tsdiag_can_transfer_data = NULL;
	p_tsdiag_can_request_transfer_exit = NULL;
	p_tsdiag_can_write_data_by_identifier = NULL;
	p_tsdiag_can_read_data_by_identifier = NULL;
	//
	p_tsflexray_set_controller_frametrigger = NULL;
	p_tsflexray_set_controller = NULL;
	p_tsflexray_set_frametrigger = NULL;
	p_tsflexray_cmdreq = NULL;
	p_tsflexray_transmit_sync = NULL;
	p_tsflexray_transmit_async = NULL;
	p_tsfifo_receive_flexray_msgs = NULL;
	p_tsfifo_clear_flexray_receive_buffers = NULL;
	p_tsflexray_start_net = NULL;
	p_tsflexray_stop_net = NULL;
	p_tsfifo_read_flexray_buffer_frame_count = NULL;
	p_tsfifo_read_flexray_tx_buffer_frame_count = NULL;
	p_tsfifo_read_flexray_rx_buffer_frame_count = NULL;
}

/*
*/
u32 TSCANLINApi::tscan_register_event_can(const size_t ADeviceHandle, const TCANQueueEvent_Win32_t ACallback)
{
  if(NULL != p_tscan_register_event_can)
  { 
	 return  p_tscan_register_event_can(ADeviceHandle, ACallback);
  }
  else
	  return IDX_ERR_DLL_NOT_READY;
}
//反注册CAN报文接收回调函数
u32 TSCANLINApi::tscan_unregister_event_can(const size_t ADeviceHandle, const TCANQueueEvent_Win32_t ACallback)
{
	if (NULL != p_tscan_unregister_event_can)
	{
		return p_tscan_unregister_event_can(ADeviceHandle, ACallback);
	}
	else
		return IDX_ERR_DLL_NOT_READY;
}

u32 TSCANLINApi::tscan_register_event_canfd(const size_t ADeviceHandle, const TCANFDQueueEvent_Win32_t ACallback)
{
	if (NULL != p_tscan_register_event_canfd)
	{
		return  p_tscan_register_event_canfd(ADeviceHandle, ACallback);
	}
	else
		return IDX_ERR_DLL_NOT_READY;
}

u32 TSCANLINApi::tscan_unregister_event_canfd(const size_t ADeviceHandle, const TCANFDQueueEvent_Win32_t ACallback)
{
	if (NULL != p_tscan_unregister_event_canfd)
	{
		return p_tscan_unregister_event_canfd(ADeviceHandle, ACallback);
	}
	else
		return IDX_ERR_DLL_NOT_READY;
}


//注册LIN报文接收回调函数
u32 TSCANLINApi::tslin_register_event_lin(const size_t ADeviceHandle, const TLINQueueEvent_Win32_t ACallback)
{
	if (NULL != p_tslin_register_event_lin)
	{
		return p_tslin_register_event_lin(ADeviceHandle, ACallback);
	}
	return IDX_ERR_DLL_NOT_READY;
}
//反注册LIN报文接收回调函数
u32 TSCANLINApi::tslin_unregister_event_lin(const size_t ADeviceHandle, const TLINQueueEvent_Win32_t ACallback)
{
	if (NULL != p_tslin_unregister_event_lin)
	{
		return p_tslin_unregister_event_lin(ADeviceHandle, ACallback);
	}
	return IDX_ERR_DLL_NOT_READY;
}

//注册FastLIN报文接收回调函数
u32 TSCANLINApi::tscan_register_event_fastlin(const size_t ADeviceHandle, const TLINQueueEvent_Win32_t ACallback)
{
	if (NULL != p_tscan_register_event_fastlin)
	{
		return p_tscan_register_event_fastlin(ADeviceHandle, ACallback);
	}
	return IDX_ERR_DLL_NOT_READY;
}

//反注册FastLIN报文接收回调函数
u32 TSCANLINApi::tscan_unregister_event_fastlin(const size_t ADeviceHandle, const TLINQueueEvent_Win32_t ACallback)
{
	if (NULL != p_tscan_unregister_event_fastlin)
	{
		return p_tscan_unregister_event_fastlin(ADeviceHandle, ACallback);
	}
	return IDX_ERR_DLL_NOT_READY;
}

//功能函数类型
//扫描在线的设备
u32 TSCANLINApi::tscan_scan_devices(uint32_t* ADeviceCount)
{
	if (NULL != p_tscan_scan_devices)
	{
		return p_tscan_scan_devices(ADeviceCount);
	}
	return IDX_ERR_DLL_NOT_READY;
}
//连接设备，ADeviceSerial !=NULL：连接指定的设备；ADeviceSerial == NULL：连接默认设备
u32 TSCANLINApi::tscan_connect(const char* ADeviceSerial, size_t* AHandle)
{
	if (NULL != p_tscan_connect)
	{
		return p_tscan_connect(ADeviceSerial,AHandle);
	}
	return IDX_ERR_DLL_NOT_READY;
}
//断开指定设备
u32 TSCANLINApi::tscan_disconnect_by_handle(const size_t ADeviceHandle)
{
	if (NULL != p_tscan_disconnect_by_handle)
	{
		return p_tscan_disconnect_by_handle(ADeviceHandle);
	}
	return IDX_ERR_DLL_NOT_READY;
}
//断开所有设备
u32 TSCANLINApi::tscan_disconnect_all_devices(void)
{
	if (NULL != p_tscan_disconnect_all_devices)
	{
		return p_tscan_disconnect_all_devices();
	}
	return IDX_ERR_DLL_NOT_READY;
}
void TSCANLINApi::InitTSCANAPI(bool AEnableFIFO, bool AErrorFrame, bool AEnableTurbe)
{
	if (NULL != p_initialize_lib_tscan)
	{
		p_initialize_lib_tscan(AEnableFIFO, AErrorFrame, AEnableTurbe);
	}
}
//释放TSCANAPI模块
void TSCANLINApi::FreeTSCANApi(void)
{
	if (NULL != p_finalize_lib_tscan)
	{
		p_finalize_lib_tscan();
	}
}

//CAN工具相关
//同步发送CAN报文
u32 TSCANLINApi::tscan_transmit_can_sync(const size_t ADeviceHandle, const TLibCAN* ACAN, const u32 ATimeoutMS)
{
	if (NULL != p_tscan_transmit_can_sync)
	{
		return p_tscan_transmit_can_sync(ADeviceHandle,ACAN,ATimeoutMS);
	}
	return IDX_ERR_DLL_NOT_READY;
}
//异步发送CAN报文
u32 TSCANLINApi::tscan_transmit_can_async(const size_t ADeviceHandle, const TLibCAN* ACAN)
{
	if (NULL != p_tscan_transmit_can_async)
	{
		return p_tscan_transmit_can_async(ADeviceHandle, ACAN);
	}
	return IDX_ERR_DLL_NOT_READY;
}
//设置CAN报文波特率参数
u32 TSCANLINApi::tscan_config_can_by_baudrate(const size_t ADeviceHandle, const APP_CHANNEL AChnIdx, const double ARateKbps, const u32 A120OhmConnected)
{
	if (NULL != p_tscan_config_can_by_baudrate)
	{
		return p_tscan_config_can_by_baudrate(ADeviceHandle, AChnIdx,ARateKbps,A120OhmConnected);
	}
	return IDX_ERR_DLL_NOT_READY;
}

//读取CAN报文
//ADeviceHandle：设备句柄；ACANBuffers:存储接收报文的数组；ACANBufferSize：存储数组的长度
//返回值：实际收到的报文数量
u32 TSCANLINApi::tsfifo_receive_can_msgs(const size_t ADeviceHandle, const TLibCAN* ACANBuffers, s32* ACANBufferSize, u8 AChn, u8 ARxTx)
{
	if (NULL != p_tsfifo_receive_can_msgs)
	{
		return p_tsfifo_receive_can_msgs(ADeviceHandle, ACANBuffers, ACANBufferSize, AChn, ARxTx);
	}
	return IDX_ERR_DLL_NOT_READY;
}

//CANFD工具相关
//同步发送CANFD报文
u32 TSCANLINApi::tscan_transmit_canfd_sync(const size_t ADeviceHandle, const TLibCANFD* ACAN, const u32 ATimeoutMS)
{
	if (NULL != p_tscan_transmit_canfd_sync)
	{
		return p_tscan_transmit_canfd_sync(ADeviceHandle, ACAN, ATimeoutMS);
	}
	return IDX_ERR_DLL_NOT_READY;
}
//异步发送CAN报文
u32 TSCANLINApi::tscan_transmit_canfd_async(const size_t ADeviceHandle, const TLibCANFD* ACAN)
{
	if (NULL != p_tscan_transmit_canfd_async)
	{
		return p_tscan_transmit_canfd_async(ADeviceHandle, ACAN);
	}
	return IDX_ERR_DLL_NOT_READY;
}

u32 TSCANLINApi::tsflexray_set_controller_frametrigger(const size_t ADeviceHandle, const int ANodeIndex,
	const PLibFlexray_controller_config AControllerConfig,
	const int* AFrameLengthArray, const int AFrameNum,
	const PLibTrigger_def AFrameTrigger, const int AFrameTriggerNum, const int ATimeoutMs)
{
	if (NULL != p_tsflexray_set_controller_frametrigger)
	{
		return p_tsflexray_set_controller_frametrigger(ADeviceHandle, ANodeIndex, AControllerConfig, AFrameLengthArray, AFrameNum, AFrameTrigger, AFrameTriggerNum, ATimeoutMs);
	}
	return IDX_ERR_DLL_NOT_READY;
}

u32 TSCANLINApi::tsflexray_set_controller(const size_t ADeviceHandle, const int ANodeIndex,
	const PLibFlexray_controller_config AControllerConfig, const int ATimeoutMs)
{
	if (NULL != p_tsflexray_set_controller)
	{
		return p_tsflexray_set_controller(ADeviceHandle, ANodeIndex, AControllerConfig, ATimeoutMs);
	}
	return IDX_ERR_DLL_NOT_READY;
}

u32 TSCANLINApi::tsflexray_set_frametrigger(const size_t ADeviceHandle, const int ANodeIndex,
	const int* AFrameLengthArray, const int AFrameNum,
	const PLibTrigger_def AFrameTrigger, const int AFrameTriggerNum, const int ATimeoutMs)
{
	if (NULL != p_tsflexray_set_frametrigger)
	{
		return p_tsflexray_set_frametrigger(ADeviceHandle, ANodeIndex, AFrameLengthArray, AFrameNum, AFrameTrigger, AFrameTriggerNum, ATimeoutMs);
	}
	return IDX_ERR_DLL_NOT_READY;
}

u32 TSCANLINApi::tsflexray_cmdreq(const size_t ADeviceHandle, const int AChnIdx, const int Action, const u8* AWriteDataBuffer, const s32 AWriteBufferSize, const u8* AReadDataBuffer, const s32* AReadDataBufferSize, const int  ATimeoutMs)
{
	if (NULL != p_tsflexray_cmdreq)
	{
		return p_tsflexray_cmdreq(ADeviceHandle, AChnIdx, Action, AWriteDataBuffer, AWriteBufferSize, AReadDataBuffer, AReadDataBufferSize, ATimeoutMs);
	}
	return IDX_ERR_DLL_NOT_READY;
}

u32 TSCANLINApi::tsflexray_transmit_sync(const size_t ADeviceHandle, const PLibFlexRay AData, const int ATimeoutMs)
{
	if (NULL != p_tsflexray_transmit_sync)
	{
		return p_tsflexray_transmit_sync(ADeviceHandle, AData, ATimeoutMs);
	}
	return IDX_ERR_DLL_NOT_READY;
}

u32 TSCANLINApi::tsflexray_transmit_async(const size_t ADeviceHandle, const PLibFlexRay AData)
{
	if (NULL != p_tsflexray_transmit_async)
	{
		return p_tsflexray_transmit_async(ADeviceHandle, AData);
	}
	return IDX_ERR_DLL_NOT_READY;
}

u32 TSCANLINApi::tsfifo_receive_flexray_msgs(const size_t ADeviceHandle, PLibFlexRay ADataBuffers, s32* ADataBufferSize, u8 AIdxChn, u8 ARxTx)
{
	if (NULL != p_tsfifo_receive_flexray_msgs)
	{
		return p_tsfifo_receive_flexray_msgs(ADeviceHandle, ADataBuffers, ADataBufferSize, AIdxChn, ARxTx);
	}
	return IDX_ERR_DLL_NOT_READY;
}

u32 TSCANLINApi::tsfifo_clear_flexray_receive_buffers(const size_t ADeviceHandle, const s32 AIdxChn)
{
	if (NULL != p_tsfifo_clear_flexray_receive_buffers)
	{
		return p_tsfifo_clear_flexray_receive_buffers(ADeviceHandle, AIdxChn);
	}
	return IDX_ERR_DLL_NOT_READY;
}

u32 TSCANLINApi::tsflexray_start_net(const size_t ADeviceHandle, const int AChnIdx, const int ATimeoutMs)
{
	if (NULL != p_tsflexray_start_net)
	{
		return p_tsflexray_start_net(ADeviceHandle, AChnIdx, ATimeoutMs);
	}
	return IDX_ERR_DLL_NOT_READY;
}

u32 TSCANLINApi::tsflexray_stop_net(const size_t ADeviceHandle, const int AChnIdx, const int ATimeoutMs)
{
	if (NULL != p_tsflexray_stop_net)
	{
		return p_tsflexray_stop_net(ADeviceHandle, AChnIdx, ATimeoutMs);
	}
	return IDX_ERR_DLL_NOT_READY;
}

u32 TSCANLINApi::tsfifo_read_flexray_buffer_frame_count(const size_t ADeviceHandle, const int AIdxChn, int* ACount)
{
	if (NULL != p_tsfifo_read_flexray_buffer_frame_count)
	{
		return p_tsfifo_read_flexray_buffer_frame_count(ADeviceHandle, AIdxChn, ACount);
	}
	return IDX_ERR_DLL_NOT_READY;
}

u32 TSCANLINApi::tsfifo_read_flexray_tx_buffer_frame_count(const size_t ADeviceHandle, const int AIdxChn, int* ACount)
{
	if (NULL != p_tsfifo_read_flexray_tx_buffer_frame_count)
	{
		return p_tsfifo_read_flexray_tx_buffer_frame_count(ADeviceHandle, AIdxChn, ACount);
	}
	return IDX_ERR_DLL_NOT_READY;
}

u32 TSCANLINApi::tsfifo_read_flexray_rx_buffer_frame_count(const size_t ADeviceHandle, const int AIdxChn, int* ACount)
{
	if (NULL != p_tsfifo_read_flexray_rx_buffer_frame_count)
	{
		return p_tsfifo_read_flexray_rx_buffer_frame_count(ADeviceHandle, AIdxChn, ACount);
	}
	return IDX_ERR_DLL_NOT_READY;
}


u32 TSCANLINApi::tscan_add_cyclic_msg_can(const size_t ADeviceHandle, const TLibCAN* ACAN, const float APeriodMS)
{
	if (NULL != p_tscan_add_cyclic_msg_can)
	{
		return p_tscan_add_cyclic_msg_can(ADeviceHandle, ACAN, APeriodMS);
	}
	return IDX_ERR_DLL_NOT_READY;
}

u32 TSCANLINApi::tscan_delete_cyclic_msg_can(const size_t ADeviceHandle, const TLibCAN* ACAN)
{
	if (NULL != p_tscan_delete_cyclic_msg_can)
	{
		return p_tscan_delete_cyclic_msg_can(ADeviceHandle, ACAN);
	}
	return IDX_ERR_DLL_NOT_READY;
}

u32 TSCANLINApi::tscan_add_cyclic_msg_canfd(const size_t ADeviceHandle, const TLibCANFD* ACANFD, const float APeriodMS)
{
	if (NULL != p_tscan_add_cyclic_msg_canfd)
	{
		return p_tscan_add_cyclic_msg_canfd(ADeviceHandle, ACANFD, APeriodMS);
	}
	return IDX_ERR_DLL_NOT_READY;
}

u32 TSCANLINApi::tscan_delete_cyclic_msg_canfd(const size_t ADeviceHandle, const TLibCANFD* ACANFD)
{
	if (NULL != p_tscan_delete_cyclic_msg_canfd)
	{
		return p_tscan_delete_cyclic_msg_canfd(ADeviceHandle, ACANFD);
	}
	return IDX_ERR_DLL_NOT_READY;
}
//设置CAN报文波特率参数
u32 TSCANLINApi::tscan_config_canfd_by_baudrate(const size_t  ADeviceHandle, const APP_CHANNEL AChnIdx, const double AArbRateKbps, const double ADataRateKbps, const TLIBCANFDControllerType AControllerType,
	const TLIBCANFDControllerMode AControllerMode, const u32 A120OhmConnected)
{
	if (NULL != p_tscan_config_canfd_by_baudrate)
	{
		return p_tscan_config_canfd_by_baudrate(ADeviceHandle, AChnIdx, AArbRateKbps, ADataRateKbps, AControllerType,
			AControllerMode, A120OhmConnected);
	}
	return IDX_ERR_DLL_NOT_READY;
}

//读取CAN报文
//ADeviceHandle：设备句柄；ACANBuffers:存储接收报文的数组；ACANBufferSize：存储数组的长度
//返回值：实际收到的报文数量
u32 TSCANLINApi::tsfifo_receive_canfd_msgs(const size_t ADeviceHandle, const TLibCANFD* ACANBuffers, s32* ACANBufferSize, u8 AChn, u8 ARxTx)
{
	if (NULL != p_tsfifo_receive_canfd_msgs)
	{
		return p_tsfifo_receive_canfd_msgs(ADeviceHandle, ACANBuffers, ACANBufferSize, AChn, ARxTx);
	}
	return IDX_ERR_DLL_NOT_READY;
}

//LIN工具相关
//设置节点类型:ADeviceHandle:句柄；AChnIdx:通道号;0:MasterNode;1:SlaveNode;2:MonitorNode
u32 TSCANLINApi::tslin_set_node_funtiontype(const size_t ADeviceHandle, const APP_CHANNEL AChnIdx, const u8 AFunctionType)
{
	if (NULL != p_tslin_set_node_funtiontype)
	{
		return p_tslin_set_node_funtiontype(ADeviceHandle, AChnIdx, AFunctionType);
	}
	return IDX_ERR_DLL_NOT_READY;
}
//请求下载新的ldf文件：该命令会清除设备中现存的所有ldf文件
u32 TSCANLINApi::tslin_clear_schedule_tables(const size_t ADeviceHandle, const APP_CHANNEL AChnIdx)
{
	if (NULL != p_tslin_clear_schedule_tables)
	{
		return p_tslin_clear_schedule_tables(ADeviceHandle, AChnIdx);
	}
	return IDX_ERR_DLL_NOT_READY;
}
//同步发送LIN报文
u32 TSCANLINApi::tslin_transmit_lin_sync(const size_t ADeviceHandle, const TLibLIN* ALIN, const u32 ATimeoutMS)
{
	if (NULL != p_tslin_transmit_lin_sync)
	{
		return p_tslin_transmit_lin_sync(ADeviceHandle, ALIN, ATimeoutMS);
	}
	return IDX_ERR_DLL_NOT_READY;
}
//异步发送LIN报文
u32 TSCANLINApi::tslin_transmit_lin_async(const size_t ADeviceHandle, const TLibLIN* ALIN)
{
	if (NULL != p_tslin_transmit_lin_async)
	{
		return p_tslin_transmit_lin_async(ADeviceHandle, ALIN);
	}
	return IDX_ERR_DLL_NOT_READY;
}
//异步发送LIN报文
u32 TSCANLINApi::tslin_transmit_fastlin_async(const size_t ADeviceHandle, const TLibLIN* ALIN)
{
	if (NULL != p_tslin_transmit_fastlin_async)
	{
		return p_tslin_transmit_fastlin_async(ADeviceHandle, ALIN);
	}
	return IDX_ERR_DLL_NOT_READY;
}
//设置LIN报文波特率参数
u32 TSCANLINApi::tslin_config_baudrate(const size_t ADeviceHandle, const APP_CHANNEL AChnIdx, const double ARateKbps)
{
	if (NULL != p_tslin_config_baudrate)
	{
		return p_tslin_config_baudrate(ADeviceHandle, AChnIdx, ARateKbps, LIN_Protocol_21);
	}
	return IDX_ERR_DLL_NOT_READY;
}

//读取LIN报文
//ADeviceHandle：设备句柄；ACANBuffers:存储接收报文的数组；ALINBufferSize：存储数组的长度
//返回值：实际收到的报文数量
u32 TSCANLINApi::tsfifo_receive_lin_msgs(const size_t ADeviceHandle, const TLibLIN* ALINBuffers, s32* ALINBufferSize, u8 AChn, u8 ARxTx)
{
	if (NULL != p_tsfifo_receive_lin_msgs)
	{
		return p_tsfifo_receive_lin_msgs(ADeviceHandle, ALINBuffers, ALINBufferSize, AChn, ARxTx);
	}
	return IDX_ERR_DLL_NOT_READY;
}

//读取LIN报文
//ADeviceHandle：设备句柄；ACANBuffers:存储接收报文的数组；ALINBufferSize：存储数组的长度
//返回值：实际收到的报文数量
u32 TSCANLINApi::tsfifo_receive_fastlin_msgs(const size_t ADeviceHandle, const TLibLIN* ALINBuffers, s32* ALINBufferSize, u8 AChn, u8 ARxTx)
{
	if (NULL != p_tsfifo_receive_fastlin_msgs)
	{
		return p_tsfifo_receive_fastlin_msgs(ADeviceHandle, ALINBuffers, ALINBufferSize, AChn, ARxTx);
	}
	return IDX_ERR_DLL_NOT_READY;
}

u32 TSCANLINApi::tscan_get_error_description(const u32 ACode, char** ADesc)
{
	if (NULL != p_tscan_get_error_description)
	{
		return p_tscan_get_error_description(ACode, ADesc);
	}
	return IDX_ERR_DLL_NOT_READY;
}

u32 TSCANLINApi::Replay_RegisterReplayMapChannel(const size_t ADeviceHandle, APP_CHANNEL ALogicChannel, APP_CHANNEL AHardwareChannel)
{
	if (NULL != pReplay_RegisterMapChannel)
	{
		return pReplay_RegisterMapChannel(ADeviceHandle, ALogicChannel, AHardwareChannel);
	}
	return IDX_ERR_DLL_NOT_READY;
}

void TSCANLINApi::Replay_ClearReplayMapChannel(const size_t ADeviceHandle)
{
	if (NULL != pReplay_ClearMapChannel)
	{
		pReplay_ClearMapChannel(ADeviceHandle);
	}
}

u32 TSCANLINApi::Replay_Start_Blf(const size_t ADeviceHandle, char* ABlfFilePath, int ATriggerByHardware, u64 AStartUs, u64 AEndUs)
{
	if (NULL != pReplay_Start_Blf)
	{
		return pReplay_Start_Blf(ADeviceHandle, ABlfFilePath, ATriggerByHardware, AStartUs, AEndUs);
	}
	return IDX_ERR_DLL_NOT_READY;
}

u32 TSCANLINApi::Replay_Stop(const size_t ADeviceHandle)
{
	if (NULL != pReplay_Stop_Blf)
	{
		return pReplay_Stop_Blf(ADeviceHandle);
	}
	return IDX_ERR_DLL_NOT_READY;
}


s32 TSCANLINApi::tsdiag_can_create(int* pDiagModuleIndex,
	u32 AChnIndex,
	byte ASupportFDCAN,
	byte AMaxDLC,
	u32 ARequestID,
	bool ARequestIDIsStd,
	u32 AResponseID,
	bool AResponseIDIsStd,
	u32 AFunctionID,
	bool AFunctionIDIsStd)
{
	if (NULL != p_tsdiag_can_create)
	{
		return p_tsdiag_can_create(
			pDiagModuleIndex,
			AChnIndex,
			ASupportFDCAN,
			AMaxDLC,
			ARequestID,
			ARequestIDIsStd,
			AResponseID,
			AResponseIDIsStd,
			AFunctionID,
			AFunctionIDIsStd);
	}
	return IDX_ERR_DLL_NOT_READY;
}
s32 TSCANLINApi::tsdiag_can_delete(int ADiagModuleIndex)
{
	if (NULL != p_tsdiag_can_delete)
	{
		return p_tsdiag_can_delete(
			ADiagModuleIndex
			);
	}
	return IDX_ERR_DLL_NOT_READY;
}
s32 TSCANLINApi::tsdiag_can_delete_all(void)
{
	if (NULL != p_tsdiag_can_delete_all)
	{
		return p_tsdiag_can_delete_all();
	}
	return IDX_ERR_DLL_NOT_READY;
}
s32 TSCANLINApi::tsdiag_can_attach_to_tscan_tool(int ADiagModuleIndex, size_t ACANToolHandle)
{
	if (NULL != p_tsdiag_can_attach_to_tscan_tool)
	{
		return p_tsdiag_can_attach_to_tscan_tool(
			ADiagModuleIndex,
			ACANToolHandle);
	}
	return IDX_ERR_DLL_NOT_READY;
}
/*TP Raw Function*/
s32 TSCANLINApi::tstp_can_send_functional(int ADiagModuleIndex, byte* AReqArray, int AReqArraySize)
{
	if (NULL != p_tstp_can_send_functional)
	{
		return p_tstp_can_send_functional(
			ADiagModuleIndex,
			AReqArray,
			AReqArraySize);
	}
	return IDX_ERR_DLL_NOT_READY;
}
s32 TSCANLINApi::tstp_can_send_request(int ADiagModuleIndex, byte* AReqArray, int AReqArraySize)
{
	if (NULL != p_tstp_can_send_request)
	{
		return p_tstp_can_send_request(
			ADiagModuleIndex,
			AReqArray,
			AReqArraySize);
	}
	return IDX_ERR_DLL_NOT_READY;
}
s32 TSCANLINApi::tstp_can_request_and_get_response(int ADiagModuleIndex, byte* AReqArray, int AReqArraySize, byte* AReturnArray, int* AReturnArraySize)
{
	if (NULL != p_tstp_can_request_and_get_response)
	{
		return p_tstp_can_request_and_get_response(
			ADiagModuleIndex,
			AReqArray,
			AReqArraySize,
			AReturnArray,
			AReturnArraySize);
	}
	return IDX_ERR_DLL_NOT_READY;
}

s32 TSCANLINApi::tsdiag_can_session_control(int ADiagModuleIndex, byte ASubSession)
{
	if (NULL != p_tsdiag_can_session_control)
	{
		return p_tsdiag_can_session_control(
			ADiagModuleIndex,
			ASubSession);
	}
	return IDX_ERR_DLL_NOT_READY;
}
s32 TSCANLINApi::tsdiag_can_routine_control(int ADiagModuleIndex, byte AARoutineControlType, u16 ARoutintID)
{
	if (NULL != p_tsdiag_can_routine_control)
	{
		return p_tsdiag_can_routine_control(
			ADiagModuleIndex,
			AARoutineControlType,
			ARoutintID);
	}
	return IDX_ERR_DLL_NOT_READY;
}
s32 TSCANLINApi::tsdiag_can_communication_control(int ADiagModuleIndex, byte AControlType)
{
	if (NULL != p_tsdiag_can_communication_control)
	{
		return p_tsdiag_can_communication_control(
			ADiagModuleIndex,
			AControlType);
	}
	return IDX_ERR_DLL_NOT_READY;
}
s32 TSCANLINApi::tsdiag_can_security_access_request_seed(int ADiagModuleIndex, int ALevel, byte* ARecSeed, int* ARecSeedSize)
{
	if (NULL != p_tsdiag_can_security_access_request_seed)
	{
		return p_tsdiag_can_security_access_request_seed(
			ADiagModuleIndex,
			ALevel,
			ARecSeed,
			ARecSeedSize);
	}
	return IDX_ERR_DLL_NOT_READY;
}
s32 TSCANLINApi::tsdiag_can_security_access_send_key(int ADiagModuleIndex, int ALevel, byte* ASeed, int ASeedSize)
{
	if (NULL != p_tsdiag_can_security_access_send_key)
	{
		return p_tsdiag_can_security_access_send_key(
			ADiagModuleIndex,
			ALevel,
			ASeed,
			ASeedSize);
	}
	return IDX_ERR_DLL_NOT_READY;
}
s32 TSCANLINApi::tsdiag_can_request_download(int ADiagModuleIndex, u32 AMemAddr, u32 AMemSize)
{
	if (NULL != p_tsdiag_can_request_download)
	{
		return p_tsdiag_can_request_download(
			ADiagModuleIndex,
			AMemAddr,
			AMemSize);
	}
	return IDX_ERR_DLL_NOT_READY;
}
s32 TSCANLINApi::tsdiag_can_request_upload(int ADiagModuleIndex, u32 AMemAddr, u32 AMemSize) 
{
	if (NULL != p_tsdiag_can_request_upload)
	{
		return p_tsdiag_can_request_upload(
			ADiagModuleIndex,
			AMemAddr,
			AMemSize);
	}
	return IDX_ERR_DLL_NOT_READY;
}
s32 TSCANLINApi::tsdiag_can_transfer_data(int ADiagModuleIndex, byte* ASourceDatas, int ASize, int AReqCase)
{
	if (NULL != p_tsdiag_can_transfer_data)
	{
		return p_tsdiag_can_transfer_data(
			ADiagModuleIndex,
			ASourceDatas,
			ASize,
			AReqCase);
	}
	return IDX_ERR_DLL_NOT_READY;
}
s32 TSCANLINApi::tsdiag_can_request_transfer_exit(int ADiagModuleIndex)
{
	if (NULL != p_tsdiag_can_request_transfer_exit)
	{
		return p_tsdiag_can_request_transfer_exit(
			ADiagModuleIndex);
	}
	return IDX_ERR_DLL_NOT_READY;
}
s32 TSCANLINApi::tsdiag_can_write_data_by_identifier(int ADiagModuleIndex, u16 ADataIdentifier, byte* AWriteData, int AWriteDataSize)
{
	if (NULL != p_tsdiag_can_write_data_by_identifier)
	{
		return p_tsdiag_can_write_data_by_identifier(
			ADiagModuleIndex,
			ADataIdentifier,
			AWriteData,
			AWriteDataSize);
	}
	return IDX_ERR_DLL_NOT_READY;
}
s32 TSCANLINApi::tsdiag_can_read_data_by_identifier(int ADiagModuleIndex, u16 ADataIdentifier, byte* AReturnArray, int* AReturnArraySize)
{
	if (NULL != p_tsdiag_can_read_data_by_identifier)
	{
		return p_tsdiag_can_read_data_by_identifier(
			ADiagModuleIndex,
			ADataIdentifier,
			AReturnArray,
			AReturnArraySize);
	}
	return IDX_ERR_DLL_NOT_READY;
}