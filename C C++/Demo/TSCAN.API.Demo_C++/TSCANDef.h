#ifndef __LIBTSCAN_H
#define __LIBTSCAN_H

#include <iostream>
#include <windows.h>  

#define DLLIMPORT __declspec(dllimport)
#pragma pack(1)
#include <stdint.h>
typedef uint8_t u8;
typedef int8_t s8;
typedef uint16_t u16;
typedef int16_t s16;
typedef uint32_t u32;
typedef int32_t s32;
typedef uint64_t u64;
typedef int64_t s64;
typedef wchar_t wchar;
typedef struct _u8x8 { u8 d[8]; } u8x8;
typedef struct _u8x64 { u8 d[64]; } u8x64;


typedef enum
{
	CHN1,
	CHN2,
	CHN3,
	CHN4,
	CHN5,
	CHN6,
	CHN7,
	CHN8,
	CHN9,
	CHN10,
	CHN11,
	CHN12,
	CHN13,
	CHN14,
	CHN15,
	CHN16,
	CHN17,
	CHN18,
	CHN19,
	CHN20,
	CHN21,
	CHN22,
	CHN23,
	CHN24,
	CHN25,
	CHN26,
	CHN27,
	CHN28,
	CHN29,
	CHN30,
	CHN31,
	CHN32
}APP_CHANNEL;


typedef enum :int
{ lfdtCAN = 0, 
  lfdtISOCAN = 1, 
  lfdtNonISOCAN = 2
}TLIBCANFDControllerType;

typedef enum:int
{
	lfdmNormal = 0, 
	lfdmACKOff = 1, 
	lfdmRestricted = 2
}TLIBCANFDControllerMode;


typedef enum:byte
{
	ONLY_RX_MESSAGES,  //只读取接收的数据
	TX_RX_MESSAGES     //发送出去和接收的数据都读取出来
}READ_TX_RX_DEF;

typedef union {
	u8 value;
	struct {
		u8 istx : 1;
		u8 remoteframe : 1;
		u8 extframe : 1;
		u8 tbd : 4;
		u8 iserrorframe : 1;
	}bits;
}TCANProperty;

//typedef struct _TCAN {
//	u8 FIdxChn;           // channel index starting from 0
//	TCANProperty FProperties;       // default 0, masked status:
//						  // [7] 0-normal frame, 1-error frame
//						  // [6-3] tbd
//						  // [2] 0-std frame, 1-extended frame
//						  // [1] 0-data frame, 1-remote frame
//						  // [0] dir: 0-RX, 1-TX
//	u8 FDLC;              // dlc from 0 to 8
//	u8 FReserved;         // reserved to keep alignment
//	s32 FIdentifier;      // CAN identifier
//	u64 FTimeUS;          // timestamp in us  //Modified by Eric 0321
//	u8x8 FData;           // 8 data bytes to send
//} TCAN;

typedef struct _TLibCAN {
	u8 FIdxChn;           // channel index starting from 0
	TCANProperty FProperties;       // default 0, masked status:
						  // [7] 0-normal frame, 1-error frame
						  // [6-3] tbd
						  // [2] 0-std frame, 1-extended frame
						  // [1] 0-data frame, 1-remote frame
						  // [0] dir: 0-RX, 1-TX
	u8 FDLC;              // dlc from 0 to 8
	u8 FReserved;         // reserved to keep alignment
	s32 FIdentifier;      // CAN identifier
	u64 FTimeUS;          // timestamp in us  //Modified by Eric 0321
	u8x8 FData;           // 8 data bytes to send
} TLibCAN,*PLibCAN;


typedef union {
	u8 value;
	struct {
		u8 EDL : 1;
		u8 BRS : 1;
		u8 ESI : 1;
		u8 tbd : 5;
	}bits;
}TCANFDProperty;
// CAN FD frame definition = 80 B
  // CAN FD frame definition = 80 B
typedef struct _TLibCANFD {
	u8 FIdxChn;           // channel index starting from 0        = CAN
	TCANProperty FProperties;       // default 0, masked status:            = CAN
						   // [7] 0-normal frame, 1-error frame
						   // [6] 0-not logged, 1-already logged
						   // [5-3] tbd
						   // [2] 0-std frame, 1-extended frame
						   // [1] 0-data frame, 1-remote frame
						   // [0] dir: 0-RX, 1-TX
	u8 FDLC;              // dlc from 0 to 15                     = CAN
	TCANFDProperty FFDProperties;      // [7-3] tbd                            <> CAN
						   // [2] ESI, The E RROR S TATE I NDICATOR (ESI) flag is transmitted dominant by error active nodes, recessive by error passive nodes. ESI does not exist in CAN format frames
						   // [1] BRS, If the bit is transmitted recessive, the bit rate is switched from the standard bit rate of the A RBITRATION P HASE to the preconfigured alternate bit rate of the D ATA P HASE . If it is transmitted dominant, the bit rate is not switched. BRS does not exist in CAN format frames.
						   // [0] EDL: 0-normal CAN frame, 1-FD frame, added 2020-02-12, The E XTENDED D ATA L ENGTH (EDL) bit is recessive. It only exists in CAN FD format frames
	s32  FIdentifier;      // CAN identifier                       = CAN
	u64 FTimeUS;          // timestamp in us                      = CAN
    u8x64 FData;          // 64 data bytes to send                <> CAN
}TLibCANFD, * PLibCANFD;

typedef union
{
	u8 value;
	struct {
		u8 istx : 1;
		u8 breaksended : 1;
		u8 breakreceived : 1;
		u8 syncreceived : 1;
		u8 hwtype : 2;
		u8 isLogged : 1;
		u8 iserrorframe : 1;
	}bits;
}TLINProperty;
typedef struct _TLIN {
	u8 FIdxChn;           // channel index starting from 0
	u8 FErrCode;          //  0: normal
	TLINProperty FProperties;       // default 0, masked status:
						   // [7] tbd
						   // [6] 0-not logged, 1-already logged
						   // [5-4] FHWType //DEV_MASTER,DEV_SLAVE,DEV_LISTENER
						   // [3] 0-not ReceivedSync, 1- ReceivedSync
						   // [2] 0-not received FReceiveBreak, 1-Received Break
						   // [1] 0-not send FReceiveBreak, 1-send Break
						   // [0] dir: 0-RX, 1-TX
	u8 FDLC;              // dlc from 0 to 8
	u8 FIdentifier;       // LIN identifier:0--64
	u8 FChecksum;         // LIN checksum
	u8 FStatus;           // place holder 1
	u64 FTimeUS;          // timestamp in us  //Modified by Eric 0321
	u8x8 FData;           // 8 data bytes to send
}TLibLIN, *PLibLIN;

typedef enum : byte  //new property in C++ 11
{
	LIN_Protocol_13,
	LIN_Protocol_20,
	LIN_Protocol_21,
	LIN_Protocol_J2602
}TLINProtocol;

typedef enum
{
	MasterNode,
	SlaveNode,
	MonitorNode
}TLIN_FUNCTION_TYPE;

/*Flexray*/
typedef struct _TLibFlexRay {
	u8 FIdxChn;               // channel index starting from 0
	u8 FChannelMask;          // 0: reserved, 1: A, 2: B, 3: AB
	u8 FDir;                  // 0: Rx, 1: Tx, 2: Tx Request
	u8 FPayloadLength;        // payload length in bytes
	u8 FActualPayloadLength;  // actual data bytes
	u8 FCycleNumber;          // cycle number: 0~63
	u8 FCCType;               // 0 = Architecture independent, 1 = Invalid CC type, 2 = Cyclone I, 3 = BUSDOCTOR, 4 = Cyclone II, 5 = Vector VN interface, 6 = VN - Sync - Pulse(only in Status Event, for debugging purposes only)
	u8 FFrameType;		// // 0 = raw flexray frame, 1 = error event, 2 = status, 3 = start cycle
	u16 FHeaderCRCA;          // header crc A
	u16 FHeaderCRCB;          // header crc B
	u16 FFrameStateInfo;      // bit 0~15, error flags
	u16 FSlotId;              // static seg: 0~1023
	u32 FFrameFlags;          // bit 0~22
							 // 0 1 = Null frame.
							 // 1 1 = Data segment contains valid data
							 // 2 1 = Sync bit
							 // 3 1 = Startup flag
							 // 4 1 = Payload preamble bit
							 // 5 1 = Reserved bit
							 // 6 1 = Error flag(error frame or invalid frame)
							 // 7 Reserved
							 // 8 Internally used in CANoe / CANalyzer
							 // 9 Internally used in CANoe / CANalyzer
							 // 10 Internally used in CANoe / CANalyzer
							 // 11 Internally used in CANoe / CANalyzer
							 // 12 Internally used in CANoe / CANalyzer
							 // 13 Internally used in CANoe / CANalyzer
							 // 14 Internally used in CANoe / CANalyzer
							 // 15 1 = Async.monitoring has generated this event
							 // 16 1 = Event is a PDU
							 // 17 Valid for PDUs only.The bit is set if the PDU is valid(either if the PDU has no  // update bit, or the update bit for the PDU was set in the received frame).
							 // 18 Reserved
							 // 19 1 = Raw frame(only valid if PDUs are used in the configuration).A raw frame may  // contain PDUs in its payload
							 // 20 1 = Dynamic segment	0 = Static segment
							 // 21 This flag is only valid for frames and not for PDUs.	1 = The PDUs in the payload of  // this frame are logged in separate logging entries. 0 = The PDUs in the payload of this  // frame must be extracted out of this frame.The logging file does not contain separate  // PDU - entries.
							 // 22 Valid for PDUs only.The bit is set if the PDU has an update bit
	u32 FFrameCRC;            // frame crc
	u64 FReserved1;           // 8 reserved bytes
	u64 FReserved2;           // 8 reserved bytes
	u64 FTimeUs;              // timestamp in us
	u8  FData[254];// 254 data bytes
}TLibFlexRay, * PLibFlexRay;
//Flexray
typedef struct _TLibFlexray_controller_config {
	u8 NETWORK_MANAGEMENT_VECTOR_LENGTH;
	u8 PAYLOAD_LENGTH_STATIC;
	u16 FReserved;
	u16 LATEST_TX;
		// __ prtc1Control
	u16 T_S_S_TRANSMITTER;
	u8 CAS_RX_LOW_MAX;
	u8 SPEED;      //0 for 10m, 1 for 5m, 2 for 2.5m, convert from Database
	u16 WAKE_UP_SYMBOL_RX_WINDOW;
	u8 WAKE_UP_PATTERN;
		// __ prtc2Control
	u8 WAKE_UP_SYMBOL_RX_IDLE;
	u8 WAKE_UP_SYMBOL_RX_LOW;
	u8 WAKE_UP_SYMBOL_TX_IDLE;
	u8 WAKE_UP_SYMBOL_TX_LOW;
		// __ succ1Config
	u8 channelAConnectedNode;      // Enable ChannelA: 0: Disable 1: Enable
	u8 channelBConnectedNode;      // Enable ChannelB: 0: Disable 1: Enable
	u8 channelASymbolTransmitted; // Enable Symble Transmit function of Channel A: 0: Disable 1: Enable
	u8 channelBSymbolTransmitted; // Enable Symble Transmit function of Channel B: 0: Disable 1: Enable
	u8 ALLOW_HALT_DUE_TO_CLOCK;
	u8 SINGLE_SLOT_ENABLED;        // FALSE_0, TRUE_1
	u8 wake_up_idx;                // Wake up channe: 0:ChannelA， 1:ChannelB
	u8 ALLOW_PASSIVE_TO_ACTIVE;
	u8 COLD_START_ATTEMPTS;
	u8 synchFrameTransmitted;      // Need to transmit sync frame
	u8 startupFrameTransmitted;    // Need to transmit startup frame
	// __ succ2Config
	u32 LISTEN_TIMEOUT;
	u8 LISTEN_NOISE;               //2_16
	// __ succ3Config
	u8 MAX_WITHOUT_CLOCK_CORRECTION_PASSIVE;
	u8 MAX_WITHOUT_CLOCK_CORRECTION_FATAL;
	u8 REVERS0;                    //Memory Align
	// __ gtuConfig
	// __ gtu01Config
	u32 MICRO_PER_CYCLE;
		// __ gtu02Config
	u16 Macro_Per_Cycle;
	u8 SYNC_NODE_MAX;
	u8 REVERS1;  //Memory Align
	// __ gtu03Config
	u8 MICRO_INITIAL_OFFSET_A;
	u8 MICRO_INITIAL_OFFSET_B;
	u8 MACRO_INITIAL_OFFSET_A;
	u8 MACRO_INITIAL_OFFSET_B;
		// __ gtu04Config
	u16 N_I_T;
	u16 OFFSET_CORRECTION_START;
		// __ gtu05Config
	u8 DELAY_COMPENSATION_A;
	u8 DELAY_COMPENSATION_B;
	u8 CLUSTER_DRIFT_DAMPING;
	u8 DECODING_CORRECTION;
		// __ gtu06Config
	u16 ACCEPTED_STARTUP_RANGE;
	u16 MAX_DRIFT;
		// __ gtu07Config
	u16 STATIC_SLOT;
	u16 NUMBER_OF_STATIC_SLOTS;
		// __ gtu08Config
	u8 MINISLOT;
	u8 REVERS2;  //Memory Align
	u16 NUMBER_OF_MINISLOTS;
		// __ gtu09Config
	u8 DYNAMIC_SLOT_IDLE_PHASE;
	u8 ACTION_POINT_OFFSET;
	u8 MINISLOT_ACTION_POINT_OFFSET;
	u8 REVERS3;  //Memory Align
	// __ gtu10Config
	u16 OFFSET_CORRECTION_OUT;
	u16 RATE_CORRECTION_OUT;
		// __ gtu11Config
	u8 EXTERN_OFFSET_CORRECTION;
	u8 EXTERN_RATE_CORRECTION;
		//
	u8 config_byte1;  //Memory Align
	//bit0:1:通道进入halt后自动重启   0：不启用

	u8 config_byte;  //Memory Align
	//bit0: 1：启用cha上终端电阻  0：不启用
	//bit1: 1：启用chb上终端电阻  0：不启用
	//bit2: 1：启用接收FIFO    0：不启用
	//bit3: 1：FIFO支持接收静态帧（FIFO不启用时无效，建议默认开启todo）   0:不启用
	//bit4: 1：cha桥接使能             0：不使能
	//bit5: 1：chb桥接使能             0：不使能
	//bit6: 1：FIFO支持接收空帧（FIFO不启用时无效，建议默认关闭todo）   0:不启用
	//bit7: 1：启动网络时发送wakeup-pattern   0:启动网络时不发送wakeup-pattern
}TLibFlexray_controller_config, * PLibFlexray_controller_config;

typedef struct _TLibTrigger_def {
	u16 slot_id;
	u8 frame_idx;
	u8 cycle_code;//BASE-CYCLE + CYCLE-REPETITION
	u8 config_byte;
	//bit 0:是否使能通道A
	//bit 1:是否使能通道B
	//bit 2:是否网络管理报文， dir 为rx时不管
	//bit 3:传输模式，0表示连续传输，1表示单次触发， dir 为rx时不管
	//bit 4:是否为冷启动报文，只有缓冲区0可以置1， dir 为rx时不管
	//bit 5:是否为同步报文，只有缓冲区0/1可以置1， dir 为rx时不管
	//bit 6:dir: 0-tx  1-rx
	//bit 7:
	u8 rev;
}TLibTrigger_def, * PLibTrigger_def;


//function pointer type
//回调函数类型
//TS系列工具连接回调函数
typedef void(__stdcall* TTSCANConnectedCallback_t)(const size_t ADevicehandle);
//TS系列工具断开回调函数
typedef void(__stdcall* TTSCANDisConnectedCallback_t)(const size_t ADevicehandle);
//高精度时钟回调函数
typedef void(__stdcall* THighResTimerCallback_t)(const u32 ADevicehandle);
//CAN报文接收回调函数
typedef void(__stdcall* TCANQueueEvent_Win32_t)(const TLibCAN* AData);
//CANFD报文接收回调函数
typedef void(__stdcall* TCANFDQueueEvent_Win32_t)(const TLibCANFD* AData);
//LIN报文接收回调函数
typedef void(__stdcall* TLINQueueEvent_Win32_t)(const TLibLIN* AData);

//回调函数注册函数
//注册CAN报文接收回调函数
typedef u32(__stdcall* tscan_register_event_can_t)(const size_t ADeviceHandle, const TCANQueueEvent_Win32_t ACallback);
//反注册CAN报文接收回调函数
typedef u32(__stdcall* tscan_unregister_event_can_t)(const size_t ADeviceHandle, const TCANQueueEvent_Win32_t ACallback);

//注册CAN报文接收回调函数
typedef u32(__stdcall* tscan_register_event_canfd_t)(const size_t ADeviceHandle, const TCANFDQueueEvent_Win32_t ACallback);
//反注册CAN报文接收回调函数
typedef u32(__stdcall* tscan_unregister_event_canfd_t)(const size_t ADeviceHandle, const TCANFDQueueEvent_Win32_t ACallback);


//注册LIN报文接收回调函数
typedef u32(__stdcall* tslin_register_event_lin_t)(const size_t ADeviceHandle, const TLINQueueEvent_Win32_t ACallback);
//反注册LIN报文接收回调函数
typedef u32(__stdcall* tslin_unregister_event_lin_t)(const size_t ADeviceHandle, const TLINQueueEvent_Win32_t ACallback);

//注册FastLIN报文接收回调函数
typedef u32(__stdcall* tscan_register_event_fastlin_t)(const size_t ADeviceHandle, const TLINQueueEvent_Win32_t ACallback);
//反注册FastLIN报文接收回调函数
typedef u32(__stdcall* tscan_unregister_event_fastlin_t)(const size_t ADeviceHandle, const TLINQueueEvent_Win32_t ACallback);

//功能函数类型
//扫描在线的设备
typedef uint32_t(__stdcall* tscan_scan_devices_t)(uint32_t* ADeviceCount);
//连接设备，ADeviceSerial !=NULL：连接指定的设备；ADeviceSerial == NULL：连接默认设备
typedef uint32_t(__stdcall* tscan_connect_t)(const char* ADeviceSerial, size_t* AHandle);
//断开指定设备
typedef u32(__stdcall* tscan_disconnect_by_handle_t)(const size_t ADeviceHandle);
//断开所有设备
typedef u32(__stdcall* tscan_disconnect_all_devices_t)(void);
//初始化TSCANAPI模块
typedef void(__stdcall* initialize_lib_tscan_t)(bool AEnableFIFO, bool AEnableErrorFrame, bool AUseHWTime);
//释放TSCANAPI模块
typedef void(__stdcall* finalize_lib_tscan_t)(void);

//CAN工具相关
//同步发送CAN报文
typedef u32(__stdcall* tscan_transmit_can_sync_t)(const size_t ADeviceHandle, const TLibCAN* ACAN, const u32 ATimeoutMS);

//CAN报文序列发送
typedef u32(__stdcall* tscan_transmit_can_sequence_t)(const size_t ADeviceHandle, const TLibCAN* ACANSeq, const s32 ASize);
//异步发送CAN报文
typedef u32(__stdcall* tscan_transmit_can_async_t)(const size_t ADeviceHandle, const TLibCAN* ACAN);
//设置CAN报文波特率参数
typedef u32(__stdcall* tscan_config_can_by_baudrate_t)(const size_t ADeviceHandle, const APP_CHANNEL AChnIdx, const double ARateKbps, const u32 A120OhmConnected);

//CAN周期函数
//添加周期发送CAN报文
typedef u32(__stdcall* tscan_add_cyclic_msg_can_t)(const size_t ADeviceHandle, const TLibCAN* ACAN, const float APeriodMS); //float is single
//去除周期发送CAN报文
typedef u32(__stdcall* tscan_delete_cyclic_msg_can_t)(const size_t ADeviceHandle, const TLibCAN* ACAN);
//添加周期发送CANFD报文
typedef u32(__stdcall* tscan_add_cyclic_msg_canfd_t)(const size_t ADeviceHandle, const TLibCANFD* ACANFD, const float APeriodMS); //single
//去除周期发送CANFD报文
typedef u32(__stdcall* tscan_delete_cyclic_msg_canfd_t)(const size_t ADeviceHandle, const TLibCANFD*  ACANFD);

//读取CAN报文
//ADeviceHandle：设备句柄；ACANBuffers:存储接收报文的数组；ACANBufferSize：存储数组的长度
//返回值：实际收到的报文数量
typedef u32(__stdcall* tsfifo_receive_can_msgs_t)(const size_t ADeviceHandle, const TLibCAN* ACANBuffers, s32* ACANBufferSize, u8 AChn, u8 ARXTX);

//CANFD工具相关
//同步发送CANFD报文
typedef u32(__stdcall* tscan_transmit_canfd_sync_t)(const size_t ADeviceHandle, const TLibCANFD* ACAN, const u32 ATimeoutMS);
//CANFD报文序列发送
typedef u32(__stdcall* tscan_transmit_canfd_sequence_t)(const size_t ADeviceHandle, const TLibCANFD* ACANFDSeq, const s32 ASize);
//异步发送CANFD报文
typedef u32(__stdcall* tscan_transmit_canfd_async_t)(const size_t ADeviceHandle, const TLibCANFD* ACAN);
//设置CANFD报文波特率参数
typedef u32(__stdcall* tscan_config_canfd_by_baudrate_t)(const size_t  ADeviceHandle, const APP_CHANNEL AChnIdx, const double AArbRateKbps, const double ADataRateKbps, const TLIBCANFDControllerType AControllerType,
	const TLIBCANFDControllerMode AControllerMode, const u32 A120OhmConnected);
//读取CANFD报文
//ADeviceHandle：设备句柄；ACANBuffers:存储接收报文的数组；ACANBufferSize：存储数组的长度
//返回值：实际收到的报文数量
typedef u32(__stdcall* tsfifo_receive_canfd_msgs_t)(const size_t ADeviceHandle, const TLibCANFD* ACANBuffers, s32* ACANBufferSize, u8 AChn, u8 ARXTX);

typedef u32(__stdcall* tsfifo_clear_canfd_receive_buffers_t)(const size_t ADeviceHandle, const s32 AIdxChn);

//Flexray工具相关
typedef u32(__stdcall* tsflexray_set_controller_frametrigger_t)(const size_t ADeviceHandle, const int ANodeIndex,
		const PLibFlexray_controller_config AControllerConfig,
		const int* AFrameLengthArray, const int AFrameNum,
		const PLibTrigger_def AFrameTrigger, const int AFrameTriggerNum, const int ATimeoutMs);
typedef u32(__stdcall* tsflexray_set_controller_t)(const size_t ADeviceHandle, const int ANodeIndex,
	const PLibFlexray_controller_config AControllerConfig, const int ATimeoutMs);
typedef u32(__stdcall* tsflexray_set_frametrigger_t)(const size_t ADeviceHandle, const int ANodeIndex,
	const int* AFrameLengthArray, const int AFrameNum,
	const PLibTrigger_def AFrameTrigger, const int AFrameTriggerNum, const int ATimeoutMs);
typedef u32(__stdcall* tsflexray_cmdreq_t)(const size_t ADeviceHandle, const int AChnIdx, const int Action, const u8* AWriteDataBuffer, const s32 AWriteBufferSize, const u8* AReadDataBuffer, const s32* AReadDataBufferSize, const int  ATimeoutMs);
typedef u32(__stdcall* tsflexray_transmit_sync_t)(const size_t ADeviceHandle, const PLibFlexRay AData, const int ATimeoutMs);
typedef u32(__stdcall* tsflexray_transmit_async_t)(const size_t ADeviceHandle, const PLibFlexRay AData);
typedef u32(__stdcall* tsfifo_receive_flexray_msgs_t)(const size_t ADeviceHandle, PLibFlexRay ADataBuffers, s32* ADataBufferSize, u8 AIdxChn, u8 ARxTx);
typedef u32(__stdcall* tsfifo_clear_flexray_receive_buffers_t)(const size_t ADeviceHandle, const s32 AIdxChn);
typedef u32(__stdcall* tsflexray_start_net_t)(const size_t ADeviceHandle, const int AChnIdx, const int ATimeoutMs);
typedef u32(__stdcall* tsflexray_stop_net_t)(const size_t ADeviceHandle, const int AChnIdx, const int ATimeoutMs);
typedef u32(__stdcall* tsfifo_read_flexray_buffer_frame_count_t)(const size_t ADeviceHandle, const int AIdxChn, int* ACount);
typedef u32(__stdcall* tsfifo_read_flexray_tx_buffer_frame_count_t)(const size_t ADeviceHandle, const int AIdxChn, int* ACount);
typedef u32(__stdcall* tsfifo_read_flexray_rx_buffer_frame_count_t)(const size_t ADeviceHandle, const int AIdxChn, int* ACount);


//LIN工具相关
//设置节点类型:ADeviceHandle:句柄；AChnIdx:通道号;0:MasterNode;1:SlaveNode;2:MonitorNode
typedef u32(__stdcall* tslin_set_node_funtiontype_t)(const size_t ADeviceHandle, const APP_CHANNEL AChnIdx, const u8 AFunctionType);
//请求下载新的ldf文件：该命令会清除设备中现存的所有ldf文件
typedef u32(__stdcall* tslin_clear_schedule_tables_t)(const size_t ADeviceHandle, const APP_CHANNEL AChnIdx);
//同步发送LIN报文
typedef u32(__stdcall* tslin_transmit_lin_sync_t)(const size_t ADeviceHandle, const TLibLIN* ALIN, const u32 ATimeoutMS);
//异步发送LIN报文
typedef u32(__stdcall* tslin_transmit_lin_async_t)(const size_t ADeviceHandle, const TLibLIN* ALIN);
//异步发送LIN报文
typedef u32(__stdcall* tslin_transmit_fastlin_async_t)(const size_t ADeviceHandle, const TLibLIN* ALIN);
//设置LIN报文波特率参数
typedef u32(__stdcall* tslin_config_baudrate_t)(const size_t ADeviceHandle, const APP_CHANNEL AChnIdx, const double ARateKbps, TLINProtocol AProtocol);

//读取LIN报文
//ADeviceHandle：设备句柄；ACANBuffers:存储接收报文的数组；ALINBufferSize：存储数组的长度
//返回值：实际收到的报文数量
typedef u32(__stdcall* tsfifo_receive_lin_msgs_t)(const size_t ADeviceHandle, const TLibLIN* ALINBuffers, s32* ALINBufferSize, u8 AChn, u8 ARXTX);

//读取LIN报文
//ADeviceHandle：设备句柄；ACANBuffers:存储接收报文的数组；ALINBufferSize：存储数组的长度
//返回值：实际收到的报文数量
typedef u32(__stdcall* tsfifo_receive_fastlin_msgs_t)(const size_t ADeviceHandle, const TLibLIN* ALINBuffers, s32* ALINBufferSize, u8 AChn, u8 ARXTX);

//获取错误编码代表的意义
typedef u32(__stdcall* tscan_get_error_description_t)(const u32 ACode, char** ADesc);

//高精度回放API
typedef s32(__stdcall* tsreplay_add_channel_map_t)(const size_t ADeviceHandle, APP_CHANNEL ALogicChannel, APP_CHANNEL AHardwareChannel);
typedef void(__stdcall* tsreplay_clear_channel_map_t)(const size_t ADeviceHandle);
typedef s32(__stdcall* tsreplay_start_blf_t)(const size_t ADeviceHandle, char* ABlfFilePath, int ATriggerByHardware, u64 AStartUs,u64 AEndUs);
typedef s32(__stdcall* tsreplay_stop_t)(const size_t ADeviceHandle);

typedef s32(__stdcall* tsdiag_can_create_t)(int* pDiagModuleIndex,
											u32 AChnIndex,
											byte ASupportFDCAN,
											byte AMaxDLC,
											u32 ARequestID,
											bool ARequestIDIsStd,
											u32 AResponseID,
											bool AResponseIDIsStd,
											u32 AFunctionID,
											bool AFunctionIDIsStd);
typedef s32(__stdcall* tsdiag_can_delete_t)(int ADiagModuleIndex);
typedef s32(__stdcall* tsdiag_can_delete_all_t)(void);
typedef s32(__stdcall* tsdiag_can_attach_to_tscan_tool_t)(int ADiagModuleIndex, size_t ACANToolHandle);
/*TP Raw Function*/
typedef s32(__stdcall* tstp_can_send_functional_t)(int ADiagModuleIndex,byte* AReqArray,int AReqArraySize);
typedef s32(__stdcall* tstp_can_send_request_t)(int ADiagModuleIndex, byte* AReqArray, int AReqArraySize);
typedef s32(__stdcall* tstp_can_request_and_get_response_t)(int ADiagModuleIndex, byte* AReqArray, int AReqArraySize, byte* AReturnArray, int* AReturnArraySize);

typedef s32(__stdcall* tsdiag_can_session_control_t)(int ADiagModuleIndex,byte ASubSession);
typedef s32(__stdcall* tsdiag_can_routine_control_t)(int ADiagModuleIndex, byte AARoutineControlType,u16 ARoutintID);
typedef s32(__stdcall* tsdiag_can_communication_control_t)(int ADiagModuleIndex, byte AControlType);
typedef s32(__stdcall* tsdiag_can_security_access_request_seed_t)(int ADiagModuleIndex,int ALevel,
                                                                  byte* ARecSeed, int* ARecSeedSize);
typedef s32(__stdcall* tsdiag_can_security_access_send_key_t)(int ADiagModuleIndex,int ALevel,byte* ASeed,int ASeedSize);
typedef s32(__stdcall* tsdiag_can_request_download_t)(int ADiagModuleIndex,u32 AMemAddr,u32 AMemSize);
typedef s32(__stdcall* tsdiag_can_request_upload_t)(int ADiagModuleIndex, u32 AMemAddr,u32 AMemSize);
typedef s32(__stdcall* tsdiag_can_transfer_data_t)(int ADiagModuleIndex,byte* ASourceDatas, int ASize,int AReqCase);
typedef s32(__stdcall* tsdiag_can_request_transfer_exit_t)(int ADiagModuleIndex);
typedef s32(__stdcall* tsdiag_can_write_data_by_identifier_t)(int ADiagModuleIndex,u16 ADataIdentifier,byte* AWriteData, int AWriteDataSize);
typedef s32(__stdcall* tsdiag_can_read_data_by_identifier_t)(int ADiagModuleIndex, u16 ADataIdentifier, byte* AReturnArray, int* AReturnArraySize);


#endif