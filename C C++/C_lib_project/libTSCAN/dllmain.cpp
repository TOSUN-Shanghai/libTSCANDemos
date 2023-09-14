
// dllmain.cpp : 定义 DLL 应用程序的入口点。
#include "pch.h"
#include"libTSCAN.h"
TSAPI(u32)tscan_register_event_can(const size_t ADeviceHandle, const TCANQueueEvent_Win32_t ACallback)
{
	return 0;
}
//反注册CAN报文接收回调函数
TSAPI(u32)tscan_unregister_event_can(const size_t ADeviceHandle, const TCANQueueEvent_Win32_t ACallback)
{
	return 0;
}
//注册CAN报文接收回调函数
TSAPI(u32) tscan_register_event_canfd(const size_t ADeviceHandle, const TCANFDQueueEvent_Win32_t ACallback)
{
	return 0;
}//反注册CAN报文接收回调函数
TSAPI(u32) tscan_unregister_event_canfd(const size_t ADeviceHandle, const TCANFDQueueEvent_Win32_t ACallback)
{
	return 0;
}

//注册LIN报文接收回调函数
TSAPI(u32) tslin_register_event_lin(const size_t ADeviceHandle, const TLINQueueEvent_Win32_t ACallback)
{
	return 0;
}//反注册LIN报文接收回调函数
TSAPI(u32) tslin_unregister_event_lin(const size_t ADeviceHandle, const TLINQueueEvent_Win32_t ACallback)
{
	return 0;
}
//注册FastLIN报文接收回调函数
TSAPI(u32) tscan_register_event_fastlin(const size_t ADeviceHandle, const TLINQueueEvent_Win32_t ACallback)
{
	return 0;
}//反注册FastLIN报文接收回调函数
TSAPI(u32) tscan_unregister_event_fastlin(const size_t ADeviceHandle, const TLINQueueEvent_Win32_t ACallback)
{
	return 0;
}
//功能函数类型
//扫描在线的设备
TSAPI(u32) tscan_scan_devices(uint32_t* ADeviceCount)
{
	return 0;
}
TSAPI(u32)tscan_get_device_info(const s32 ADeviceIndex, char** AFManufacturer, char** AFProduct, char** AFSerial)
{
	return 0;
}
//连接设备，ADeviceSerial !=NULL：连接指定的设备；ADeviceSerial == NULL：连接默认设备
TSAPI(u32) tscan_connect(const char* ADeviceSerial, size_t* AHandle)
{
	return 0;
}//断开指定设备
TSAPI(u32) tscan_disconnect_by_handle(const size_t ADeviceHandle)
{
	return 0;
}//断开所有设备
TSAPI(u32) tscan_disconnect_all_devices(void)
{
	return 0;
}//初始化TSCANAPI模块
TSAPI(void) initialize_lib_tscan(bool AEnableFIFO, bool AEnableErrorFrame, bool AUseHWTime)
{
	return ;
}//释放TSCANAPI模块
TSAPI(void) finalize_lib_tscan(void)
{
	return ;
}
//CAN工具相关
//同步发送CAN报文
TSAPI(u32) tscan_transmit_can_sync(const size_t ADeviceHandle, const TLIBCAN* ACAN, const u32 ATimeoutMS)
{
	return 0;
}
//CAN报文序列发送
TSAPI(u32) tscan_transmit_can_sequence(const size_t ADeviceHandle, const TLIBCAN* ACANSeq, const s32 ASize)
{
	return 0;
}//异步发送CAN报文
TSAPI(u32) tscan_transmit_can_async(const size_t ADeviceHandle, const TLIBCAN* ACAN)
{
	return 0;
}//设置CAN报文波特率参数
TSAPI(u32) tscan_config_can_by_baudrate(const size_t ADeviceHandle, const APP_CHANNEL AChnIdx, const double ARateKbps, const u32 A120OhmConnected)
{
	return 0;
}
//CAN周期函数
//添加周期发送CAN报文
TSAPI(u32) tscan_add_cyclic_msg_can(const size_t ADeviceHandle, const TLIBCAN* ACAN, const float APeriodMS) //float is single
{
	return 0;
}//去除周期发送CAN报文
TSAPI(u32) tscan_delete_cyclic_msg_can(const size_t ADeviceHandle, const TLIBCAN* ACAN)
{
	return 0;
}//添加周期发送CANFD报文
TSAPI(u32) tscan_add_cyclic_msg_canfd(const size_t ADeviceHandle, const TLIBCANFD* ACANFD, const float APeriodMS) //single
{
	return 0;
}//去除周期发送CANFD报文
TSAPI(u32) tscan_delete_cyclic_msg_canfd(const size_t ADeviceHandle, const TLIBCANFD* ACANFD)
{
	return 0;
}
//读取CAN报文
//ADeviceHandle：设备句柄；ACANBuffers:存储接收报文的数组；ACANBufferSize：存储数组的长度
//返回值：实际收到的报文数量
TSAPI(u32) tsfifo_receive_can_msgs(const size_t ADeviceHandle, TLIBCAN* ACANBuffers, s32* ACANBufferSize, u8 AChn, u8 ARXTX)
{
	return 0;
}
//CANFD工具相关
//同步发送CANFD报文
TSAPI(u32) tscan_transmit_canfd_sync(const size_t ADeviceHandle, const TLIBCANFD* ACAN, const u32 ATimeoutMS)
{
	return 0;
}//CANFD报文序列发送
TSAPI(u32) tscan_transmit_canfd_sequence(const size_t ADeviceHandle, const TLIBCANFD* ACANFDSeq, const s32 ASize)
{
	return 0;
}//异步发送CANFD报文
TSAPI(u32) tscan_transmit_canfd_async(const size_t ADeviceHandle, const TLIBCANFD* ACAN)
{
	return 0;
}//设置CANFD报文波特率参数
TSAPI(u32) tscan_config_canfd_by_baudrate(const size_t  ADeviceHandle, const APP_CHANNEL AChnIdx, const double AArbRateKbps, const double ADataRateKbps, const TLIBCANFDControllerType AControllerType,
	const TLIBCANFDControllerMode AControllerMode, const u32 A120OhmConnected)
{
	return 0;
}//读取CANFD报文
//ADeviceHandle：设备句柄；ACANBuffers:存储接收报文的数组；ACANBufferSize：存储数组的长度
//返回值：实际收到的报文数量
TSAPI(u32) tsfifo_receive_canfd_msgs(const size_t ADeviceHandle, TLIBCANFD* ACANBuffers, s32* ACANBufferSize, u8 AChn, u8 ARXTX)
{
	return 0;
}
TSAPI(u32) tsfifo_clear_canfd_receive_buffers(const size_t ADeviceHandle, const s32 AIdxChn)
{
	return 0;
}
//Flexray工具相关
TSAPI(u32) tsflexray_set_controller_frametrigger(const size_t ADeviceHandle, const int ANodeIndex,
	const PLibFlexray_controller_config AControllerConfig,
	const int* AFrameLengthArray, const int AFrameNum,
	const PLibTrigger_def AFrameTrigger, const int AFrameTriggerNum, const int ATimeoutMs)
{
	return 0;
}
TSAPI(u32) tsflexray_set_controller(const size_t ADeviceHandle, const int ANodeIndex,
	const PLibFlexray_controller_config AControllerConfig, const int ATimeoutMs)
{
	return 0;
}
TSAPI(u32) tsflexray_set_frametrigger(const size_t ADeviceHandle, const int ANodeIndex,
	const int* AFrameLengthArray, const int AFrameNum,
	const PLibTrigger_def AFrameTrigger, const int AFrameTriggerNum, const int ATimeoutMs)
{
	return 0;
}
TSAPI(u32) tsflexray_cmdreq(const size_t ADeviceHandle, const int AChnIdx, const int Action, const u8* AWriteDataBuffer, const s32 AWriteBufferSize, const u8* AReadDataBuffer, const s32* AReadDataBufferSize, const int  ATimeoutMs)
{
	return 0;
}
TSAPI(u32) tsflexray_transmit_sync(const size_t ADeviceHandle, const PLibFlexRay AData, const int ATimeoutMs)
{
	return 0;
}
TSAPI(u32) tsflexray_transmit_async(const size_t ADeviceHandle, const PLibFlexRay AData)

{
	return 0;
}
TSAPI(u32) tsfifo_receive_flexray_msgs(const size_t ADeviceHandle, PLibFlexRay ADataBuffers, s32* ADataBufferSize, u8 AIdxChn, u8 ARxTx)
{
	return 0;
}
TSAPI(u32) tsfifo_clear_flexray_receive_buffers(const size_t ADeviceHandle, const s32 AIdxChn)
{
	return 0;
}
TSAPI(u32) tsflexray_start_net(const size_t ADeviceHandle, const int AChnIdx, const int ATimeoutMs)
{
	return 0;
}
TSAPI(u32) tsflexray_stop_net(const size_t ADeviceHandle, const int AChnIdx, const int ATimeoutMs)
{
	return 0;
}
TSAPI(u32) tsfifo_read_flexray_buffer_frame_count(const size_t ADeviceHandle, const int AIdxChn, int* ACount)
{
	return 0;
}
TSAPI(u32) tsfifo_read_flexray_tx_buffer_frame_count(const size_t ADeviceHandle, const int AIdxChn, int* ACount)

{
	return 0;
}
TSAPI(u32) tsfifo_read_flexray_rx_buffer_frame_count(const size_t ADeviceHandle, const int AIdxChn, int* ACount)
{
	return 0;
}

//LIN工具相关
//设置节点类型:ADeviceHandle:句柄；AChnIdx:通道号;0:MasterNode;1:SlaveNode;2:MonitorNode
TSAPI(u32) tslin_set_node_funtiontype(const size_t ADeviceHandle, const APP_CHANNEL AChnIdx, const u8 AFunctionType)
{
	return 0;
}//请求下载新的ldf文件：该命令会清除设备中现存的所有ldf文件
TSAPI(u32) tslin_clear_schedule_tables(const size_t ADeviceHandle, const APP_CHANNEL AChnIdx)
{
	return 0;
}//同步发送LIN报文
TSAPI(u32) tslin_transmit_lin_sync(const size_t ADeviceHandle, const TLIBLIN* ALIN, const u32 ATimeoutMS)
{
	return 0;
}//异步发送LIN报文
TSAPI(u32) tslin_transmit_lin_async(const size_t ADeviceHandle, const TLIBLIN* ALIN)
{
	return 0;
}//异步发送LIN报文
TSAPI(u32) tslin_transmit_fastlin_async(const size_t ADeviceHandle, const TLIBLIN* ALIN)
{
	return 0;
}//设置LIN报文波特率参数
TSAPI(u32) tslin_config_baudrate(const size_t ADeviceHandle, const APP_CHANNEL AChnIdx, const double ARateKbps, TLINProtocol AProtocol)
{
	return 0;
}
//读取LIN报文
//ADeviceHandle：设备句柄；ACANBuffers:存储接收报文的数组；ALINBufferSize：存储数组的长度
//返回值：实际收到的报文数量
TSAPI(u32) tsfifo_receive_lin_msgs(const size_t ADeviceHandle, const TLIBLIN* ALINBuffers, s32* ALINBufferSize, u8 AChn, u8 ARXTX)
{
	return 0;
}
//读取LIN报文
//ADeviceHandle：设备句柄；ACANBuffers:存储接收报文的数组；ALINBufferSize：存储数组的长度
//返回值：实际收到的报文数量
TSAPI(u32) tsfifo_receive_fastlin_msgs(const size_t ADeviceHandle, const TLIBLIN* ALINBuffers, s32* ALINBufferSize, u8 AChn, u8 ARXTX)
{
	return 0;
}
//获取错误编码代表的意义
TSAPI(u32) tscan_get_error_description(const u32 ACode, char** ADesc)
{
	return 0;
}
//高精度回放API
TSAPI(u32) tsreplay_add_channel_map(const size_t ADeviceHandle, APP_CHANNEL ALogicChannel, APP_CHANNEL AHardwareChannel)
{
	return 0;
}
TSAPI(void) tsreplay_clear_channel_map(const size_t ADeviceHandle)
{
	return ;
}
TSAPI(u32) tsreplay_start_blf(const size_t ADeviceHandle, char* ABlfFilePath, int ATriggerByHardware, u64 AStartUs, u64 AEndUs)
{
	return 0;
}
TSAPI(u32) tsreplay_stop(const size_t ADeviceHandle)
{
	return 0;
}
TSAPI(u32) tsdiag_can_create(int* pDiagModuleIndex,
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
	return 0;
}
TSAPI(u32) tsdiag_can_delete(int ADiagModuleIndex)
{
	return 0;
}
TSAPI(u32) tsdiag_can_delete_all(void)
{
	return 0;
}
TSAPI(u32) tsdiag_can_attach_to_tscan_tool(int ADiagModuleIndex, size_t ACANToolHandle)
{
	return 0;
}/*TP Raw Function*/
TSAPI(u32) tstp_can_send_functional(int ADiagModuleIndex, byte* AReqArray, int AReqArraySize)
{
	return 0;
}
TSAPI(u32) tstp_can_send_request(int ADiagModuleIndex, byte* AReqArray, int AReqArraySize)
{
	return 0;
}
TSAPI(u32) tstp_can_request_and_get_response(int ADiagModuleIndex, byte* AReqArray, int AReqArraySize, byte* AReturnArray, int* AReturnArraySize)
{
	return 0;
}
TSAPI(u32) tsdiag_can_session_control(int ADiagModuleIndex, byte ASubSession)
{
	return 0;
}
TSAPI(u32) tsdiag_can_routine_control(int ADiagModuleIndex, byte AARoutineControlType, u16 ARoutintID)
{
	return 0;
}
TSAPI(u32) tsdiag_can_communication_control(int ADiagModuleIndex, byte AControlType)
{
	return 0;
}
TSAPI(u32) tsdiag_can_security_access_request_seed(int ADiagModuleIndex, int ALevel,
	byte* ARecSeed, int* ARecSeedSize)
{
	return 0;
}
TSAPI(u32) tsdiag_can_security_access_send_key(int ADiagModuleIndex, int ALevel, byte* ASeed, int ASeedSize)
{
	return 0;
}
TSAPI(u32) tsdiag_can_request_download(int ADiagModuleIndex, u32 AMemAddr, u32 AMemSize)
{
	return 0;
}
TSAPI(u32) tsdiag_can_request_upload(int ADiagModuleIndex, u32 AMemAddr, u32 AMemSize)
{
	return 0;
}
TSAPI(u32) tsdiag_can_transfer_data(int ADiagModuleIndex, byte* ASourceDatas, int ASize, int AReqCase)
{
	return 0;
}
TSAPI(u32) tsdiag_can_request_transfer_exit(int ADiagModuleIndex)
{
	return 0;
}
TSAPI(u32) tsdiag_can_write_data_by_identifier(int ADiagModuleIndex, u16 ADataIdentifier, byte* AWriteData, int AWriteDataSize)
{
	return 0;
}
TSAPI(u32) tsdiag_can_read_data_by_identifier(int ADiagModuleIndex, u16 ADataIdentifier, byte* AReturnArray, int* AReturnArraySize)
{
	return 0;
}
TSAPI(u32) tsflexray_register_event_flexray(const size_t ADeviceHandle, const TFlexRayQueueEvent_Win32_t ACallback)
{
	return 0;
}
TSAPI(u32) tsflexray_unregister_event_flexray(const size_t ADeviceHandle, const TFlexRayQueueEvent_Win32_t ACallback)
{
	return 0;
}
TSAPI(u32) tsflexray_unregister_pretx_event_flexray(const size_t ADeviceHandle, const TFlexRayQueueEvent_Win32_t ACallback)
{
	return 0;
}
TSAPI(u32) tsflexray_register_pretx_event_flexray(const size_t ADeviceHandle, const TFlexRayQueueEvent_Win32_t ACallback)
{
	return 0;
}
TSAPI(u32) tscan_get_can_channel_count(const size_t AHandle, s32* ACount) {
	return 0;
}
TSAPI(u32) tscan_get_lin_channel_count(const size_t AHandle, s32* ACount) {
	return 0;
}
TSAPI(u32) tscan_get_flexray_channel_count(const size_t AHandle, s32* ACount) {
	return 0;
}
TSAPI(u32) tscan_register_event_canfd_whandle(const size_t ADeviceHandle, const TCANFDQueueEvent_whandle ACallback) { return 0; }
// unregister canfd event  Triggered when there is message transmission on the bus
TSAPI(u32) tscan_unregister_event_canfd_whandle(const size_t ADeviceHandle, const TCANFDQueueEvent_whandle ACallback) { return 0; }


// register lin event  Triggered when there is message transmission on the bus
TSAPI(u32) tslin_register_event_lin_whandle(const size_t ADeviceHandle, const TLINQueueEvent_whandle ACallback) { return 0; }
// unregister lin event  Triggered when there is message transmission on the bus
TSAPI(u32) tslin_unregister_event_lin_whandle(const size_t ADeviceHandle, const TLINQueueEvent_whandle ACallback) { return 0; }


TSAPI(u32) tsflexray_register_event_flexray_whandle(const size_t ADeviceHandle, const TFlexRayQueueEvent_whandle ACallback) { return 0; }

TSAPI(u32) tsflexray_unregister_event_flexray_whandle(const size_t ADeviceHandle, const TFlexRayQueueEvent_whandle ACallback) { return 0; }