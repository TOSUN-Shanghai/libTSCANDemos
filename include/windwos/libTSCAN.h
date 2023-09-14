#ifndef __LIBTSCAN_H
#define __LIBTSCAN_H

#include <iostream>
#include <windows.h>  
#define byte  unsigned char
#define DLLIMPORT __declspec(dllimport)
#pragma pack(push)
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
#define TSAPI(ret) __declspec(dllimport) ret __stdcall
#define TSAPI(ret) __declspec(dllexport) ret __stdcall

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
{
	lfdtCAN = 0,
	lfdtISOCAN = 1,
	lfdtNonISOCAN = 2
}TLIBCANFDControllerType;

typedef enum :int
{
	lfdmNormal = 0,
	lfdmACKOff = 1,
	lfdmRestricted = 2
}TLIBCANFDControllerMode;


typedef enum :byte
{
	ONLY_RX_MESSAGES,  //receive msg inclued tx and rx msg 
	TX_RX_MESSAGES //: only receive rx msg    
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

typedef struct _TLIBCAN {
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
	u8 FData[8];           // 8 data bytes to send
} TLIBCAN, * PLibCAN;


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
typedef struct _TLIBCANFD {
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
	u8 FData[64];          // 64 data bytes to send                <> CAN
}TLIBCANFD, * PLibCANFD;

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
}TLIBLIN, * PLibLIN;

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
typedef struct _TLIBFlexRay {
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
}TLIBFlexRay, * PLibFlexRay;
//Flexray
typedef struct _TLIBFlexray_controller_config {
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
	u8 wake_up_idx;                // Wake up channe: 0:ChannelA�� 1:ChannelB
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
	
	u8 config_byte;  						// bit0: 1:Channel A set termination resistor  0:Channel A not set termination resistor
                                            // bit1: 1:Channel B set termination resistor  0:Channel B not set termination resistor
                                            // bit2: 1:enable FIFO     0:disable FIFO
                                            // bit4: 1:cha enable Bridging    0:cha disable Bridging
                                            // bit5: 1:chb enable Bridging    0:chb disable Bridging
                                            // bit6: 1:not ignore NULL Frame  0: ignore NULL Frame
}TLIBFlexray_controller_config, * PLibFlexray_controller_config;

typedef struct _TLIBTrigger_def {
	u16 slot_id;
	u8 frame_idx;
	u8 cycle_code;//BASE-CYCLE + CYCLE-REPETITION
	u8 config_byte;
											// bit0: enanle A
                                            // bit1: enanle B
                                            // bit2: is NM msg
                                            // bit3: 0 :cycle ，1:Single trigger
                                            // bit4: Whether it is a cold start message, only buffer 0 can be set to 1
                                            // bit5: Whether it is a synchronization message, only the buffer 0/1 can be set to 1
                                            // bit6:
                                            // bit7: 0 - static，1 - Dynamic
	u8 rev;
}TLIBTrigger_def, * PLibTrigger_def;


//function pointer type
typedef void(__stdcall* TTSCANConnectedCallback_t)(const size_t ADevicehandle);

typedef void(__stdcall* TTSCANDisConnectedCallback_t)(const size_t ADevicehandle);

typedef void(__stdcall* THighResTimerCallback_t)(const u32 ADevicehandle);

typedef void(__stdcall* TCANQueueEvent_Win32_t)(const PLibCANFD AData);

typedef void(__stdcall* TCANFDQueueEvent_Win32_t)(const PLibCANFD AData);

typedef void(__stdcall* TLINQueueEvent_Win32_t)(const PLibLIN AData);

typedef void(__stdcall* TFlexRayQueueEvent_Win32_t)(const PLibFlexRay AData);


typedef void(__stdcall* TCANQueueEvent_whandle)(size_t* obj,const PLibCANFD AData);

typedef void(__stdcall* TCANFDQueueEvent_whandle)(size_t* obj, const PLibCANFD AData);

typedef void(__stdcall* TLINQueueEvent_whandle)(size_t* obj, const PLibLIN AData);

typedef void(__stdcall* TFlexRayQueueEvent_whandle)(size_t* obj, const PLibFlexRay AData);


extern "C"
{
	// register can event  Triggered when there is message transmission on the bus
	TSAPI(u32)tscan_register_event_can(const size_t ADeviceHandle, const TCANQueueEvent_Win32_t ACallback);
    // unregister can event  Triggered when there is message transmission on the bus
	TSAPI(u32)tscan_unregister_event_can(const size_t ADeviceHandle, const TCANQueueEvent_Win32_t ACallback);

// register canfd event  Triggered when there is message transmission on the bus
	TSAPI(u32) tscan_register_event_canfd(const size_t ADeviceHandle, const TCANFDQueueEvent_Win32_t ACallback);
// unregister canfd event  Triggered when there is message transmission on the bus
	TSAPI(u32) tscan_unregister_event_canfd(const size_t ADeviceHandle, const TCANFDQueueEvent_Win32_t ACallback);


// register lin event  Triggered when there is message transmission on the bus
	TSAPI(u32) tslin_register_event_lin(const size_t ADeviceHandle, const TLINQueueEvent_Win32_t ACallback);
// unregister lin event  Triggered when there is message transmission on the bus
	TSAPI(u32) tslin_unregister_event_lin(const size_t ADeviceHandle, const TLINQueueEvent_Win32_t ACallback);


	TSAPI(u32) tscan_register_event_canfd_whandle(const size_t ADeviceHandle, const TCANFDQueueEvent_whandle ACallback);
	// unregister canfd event  Triggered when there is message transmission on the bus
	TSAPI(u32) tscan_unregister_event_canfd_whandle(const size_t ADeviceHandle, const TCANFDQueueEvent_whandle ACallback);


	// register lin event  Triggered when there is message transmission on the bus
	TSAPI(u32) tslin_register_event_lin_whandle(const size_t ADeviceHandle, const TLINQueueEvent_whandle ACallback);
	// unregister lin event  Triggered when there is message transmission on the bus
	TSAPI(u32) tslin_unregister_event_lin_whandle(const size_t ADeviceHandle, const TLINQueueEvent_whandle ACallback);


	TSAPI(u32) tsflexray_register_event_flexray_whandle(const size_t ADeviceHandle, const TFlexRayQueueEvent_whandle ACallback);

	TSAPI(u32) tsflexray_unregister_event_flexray_whandle(const size_t ADeviceHandle, const TFlexRayQueueEvent_whandle ACallback);


// register fastlin event  Triggered when there is message transmission on the bus
	TSAPI(u32) tscan_register_event_fastlin(const size_t ADeviceHandle, const TLINQueueEvent_Win32_t ACallback);
// unregister fastlin event  Triggered when there is message transmission on the bus
	TSAPI(u32) tscan_unregister_event_fastlin_t(const size_t ADeviceHandle, const TLINQueueEvent_Win32_t ACallback);

//scan online devices
	TSAPI(u32) tscan_scan_devices(uint32_t* ADeviceCount);
//get online devices info
	TSAPI(u32)tscan_get_device_info(const s32 ADeviceIndex, char** AFManufacturer, char** AFProduct, char** AFSerial);
//connect devices 
	TSAPI(u32) tscan_connect(const char* ADeviceSerial, size_t* AHandle);
//get connect devices can channel
	TSAPI(u32) tscan_get_can_channel_count(const size_t AHandle, s32* ACount);
	//get connect devices lin channel
	TSAPI(u32) tscan_get_lin_channel_count(const size_t AHandle, s32* ACount);
	//get connect devices flexray channel
	TSAPI(u32) tscan_get_flexray_channel_count(const size_t AHandle, s32* ACount);
//disconnect devices by handle
	TSAPI(u32) tscan_disconnect_by_handle(const size_t ADeviceHandle);
//disconnect all devices 
	TSAPI(u32) tscan_disconnect_all_devices(void);
//initialize function must use 
	TSAPI(void) initialize_lib_tscan(bool AEnableFIFO, bool AEnableErrorFrame, bool AUseHWTime);
//release function
	TSAPI(void) finalize_lib_tscan(void);

//can msg send function by sync
	TSAPI(u32) tscan_transmit_can_sync(const size_t ADeviceHandle, const TLIBCAN* ACAN, const u32 ATimeoutMS);


	TSAPI(u32) tscan_transmit_can_sequence(const size_t ADeviceHandle, const TLIBCAN* ACANSeq, const s32 ASize);
//can msg send function by async
	TSAPI(u32) tscan_transmit_can_async(const size_t ADeviceHandle, const TLIBCAN* ACAN);
//config can baudrate
	TSAPI(u32) tscan_config_can_by_baudrate(const size_t ADeviceHandle, const APP_CHANNEL AChnIdx, const double ARateKbps, const u32 A120OhmConnected);

//cyclic can msg 
	TSAPI(u32) tscan_add_cyclic_msg_can(const size_t ADeviceHandle, const TLIBCAN* ACAN, const float APeriodMS); //float is single
//del cyclic can msg 
	TSAPI(u32) tscan_delete_cyclic_msg_can(const size_t ADeviceHandle, const TLIBCAN* ACAN);
//cyclic canfd msg 
	TSAPI(u32) tscan_add_cyclic_msg_canfd(const size_t ADeviceHandle, const TLIBCANFD* ACANFD, const float APeriodMS); //single
//del cyclic canfd msg 
	TSAPI(u32) tscan_delete_cyclic_msg_canfd(const size_t ADeviceHandle, const TLIBCANFD* ACANFD);

//receive can_msgs
	TSAPI(u32) tsfifo_receive_can_msgs(const size_t ADeviceHandle,TLIBCAN* ACANBuffers, s32* ACANBufferSize, u8 AChn, u8 ARXTX);

//can msg send function by sync
	TSAPI(u32) tscan_transmit_canfd_sync(const size_t ADeviceHandle, const TLIBCANFD* ACAN, const u32 ATimeoutMS);

	TSAPI(u32) tscan_transmit_canfd_sequence(const size_t ADeviceHandle, const TLIBCANFD* ACANFDSeq, const s32 ASize);
//can msg send function by async
	TSAPI(u32) tscan_transmit_canfd_async(const size_t ADeviceHandle, const TLIBCANFD* ACAN);
//config canfd baudrate
	TSAPI(u32) tscan_config_canfd_by_baudrate(const size_t  ADeviceHandle, const APP_CHANNEL AChnIdx, const double AArbRateKbps, const double ADataRateKbps, const TLIBCANFDControllerType AControllerType,
		const TLIBCANFDControllerMode AControllerMode, const u32 A120OhmConnected);
//receive canfd_msgs
	TSAPI(u32) tsfifo_receive_canfd_msgs(const size_t ADeviceHandle,TLIBCANFD* ACANBuffers, s32* ACANBufferSize, u8 AChn, u8 ARXTX);
//clear canfd fifo buffers now
	TSAPI(u32) tsfifo_clear_canfd_receive_buffers(const size_t ADeviceHandle, const s32 AIdxChn);

	
	TSAPI(u32) tsflexray_set_controller_frametrigger(const size_t ADeviceHandle, const int ANodeIndex,
		const PLibFlexray_controller_config AControllerConfig,
		const int* AFrameLengthArray, const int AFrameNum,
		const PLibTrigger_def AFrameTrigger, const int AFrameTriggerNum, const int ATimeoutMs);
	TSAPI(u32) tsflexray_set_controller(const size_t ADeviceHandle, const int ANodeIndex,
		const PLibFlexray_controller_config AControllerConfig, const int ATimeoutMs);
	TSAPI(u32) tsflexray_set_frametrigger(const size_t ADeviceHandle, const int ANodeIndex,
		const int* AFrameLengthArray, const int AFrameNum,
		const PLibTrigger_def AFrameTrigger, const int AFrameTriggerNum, const int ATimeoutMs);
	TSAPI(u32) tsflexray_cmdreq(const size_t ADeviceHandle, const int AChnIdx, const int Action, const u8* AWriteDataBuffer, const s32 AWriteBufferSize, const u8* AReadDataBuffer, const s32* AReadDataBufferSize, const int  ATimeoutMs);
	TSAPI(u32) tsflexray_transmit_sync(const size_t ADeviceHandle, const PLibFlexRay AData, const int ATimeoutMs);
	TSAPI(u32) tsflexray_transmit_async(const size_t ADeviceHandle, const PLibFlexRay AData);
	TSAPI(u32) tsfifo_receive_flexray_msgs(const size_t ADeviceHandle, PLibFlexRay ADataBuffers, s32* ADataBufferSize, u8 AIdxChn, u8 ARxTx);
	TSAPI(u32) tsfifo_clear_flexray_receive_buffers(const size_t ADeviceHandle, const s32 AIdxChn);
	TSAPI(u32) tsflexray_start_net(const size_t ADeviceHandle, const int AChnIdx, const int ATimeoutMs);
	TSAPI(u32) tsflexray_stop_net(const size_t ADeviceHandle, const int AChnIdx, const int ATimeoutMs);
	TSAPI(u32) tsfifo_read_flexray_buffer_frame_count(const size_t ADeviceHandle, const int AIdxChn, int* ACount);
	TSAPI(u32) tsfifo_read_flexray_tx_buffer_frame_count(const size_t ADeviceHandle, const int AIdxChn, int* ACount);
	TSAPI(u32) tsfifo_read_flexray_rx_buffer_frame_count(const size_t ADeviceHandle, const int AIdxChn, int* ACount);


	
	TSAPI(u32) tslin_set_node_funtiontype(const size_t ADeviceHandle, const APP_CHANNEL AChnIdx, const u8 AFunctionType);

	TSAPI(u32) tslin_clear_schedule_tables(const size_t ADeviceHandle, const APP_CHANNEL AChnIdx);

	TSAPI(u32) tslin_transmit_lin_sync(const size_t ADeviceHandle, const TLIBLIN* ALIN, const u32 ATimeoutMS);

	TSAPI(u32) tslin_transmit_lin_async(const size_t ADeviceHandle, const TLIBLIN* ALIN);

	TSAPI(u32) tslin_transmit_fastlin_async(const size_t ADeviceHandle, const TLIBLIN* ALIN);

	TSAPI(u32) tslin_config_baudrate(const size_t ADeviceHandle, const APP_CHANNEL AChnIdx, const double ARateKbps, TLINProtocol AProtocol);

	
	TSAPI(u32) tsfifo_receive_lin_msgs(const size_t ADeviceHandle, const TLIBLIN* ALINBuffers, s32* ALINBufferSize, u8 AChn, u8 ARXTX);

	
	TSAPI(u32) tsfifo_receive_fastlin_msgs(const size_t ADeviceHandle, const TLIBLIN* ALINBuffers, s32* ALINBufferSize, u8 AChn, u8 ARXTX);

	//
	TSAPI(u32) tscan_get_error_description(const u32 ACode, char** ADesc);

	//
	TSAPI(u32) tsreplay_add_channel_map(const size_t ADeviceHandle, APP_CHANNEL ALogicChannel, APP_CHANNEL AHardwareChannel);
	TSAPI(void) tsreplay_clear_channel_map(const size_t ADeviceHandle);
	TSAPI(u32) tsreplay_start_blf(const size_t ADeviceHandle, char* ABlfFilePath, int ATriggerByHardware, u64 AStartUs, u64 AEndUs);
	TSAPI(u32) tsreplay_stop(const size_t ADeviceHandle);

	TSAPI(u32) tsdiag_can_create(int* pDiagModuleIndex,
		u32 AChnIndex,
		byte ASupportFDCAN,
		byte AMaxDLC,
		u32 ARequestID,
		bool ARequestIDIsStd,
		u32 AResponseID,
		bool AResponseIDIsStd,
		u32 AFunctionID,
		bool AFunctionIDIsStd);
	TSAPI(u32) tsdiag_can_delete(int ADiagModuleIndex);
	TSAPI(u32) tsdiag_can_delete_all(void);
	TSAPI(u32) tsdiag_can_attach_to_tscan_tool(int ADiagModuleIndex, size_t ACANToolHandle);
	/*TP Raw Function*/
	TSAPI(u32) tstp_can_send_functional(int ADiagModuleIndex, byte* AReqArray, int AReqArraySize);
	TSAPI(u32) tstp_can_send_request(int ADiagModuleIndex, byte* AReqArray, int AReqArraySize);
	TSAPI(u32) tstp_can_request_and_get_response(int ADiagModuleIndex, byte* AReqArray, int AReqArraySize, byte* AReturnArray, int* AReturnArraySize);

	TSAPI(u32) tsdiag_can_session_control(int ADiagModuleIndex, byte ASubSession);
	TSAPI(u32) tsdiag_can_routine_control(int ADiagModuleIndex, byte AARoutineControlType, u16 ARoutintID);
	TSAPI(u32) tsdiag_can_communication_control(int ADiagModuleIndex, byte AControlType);
	TSAPI(u32) tsdiag_can_security_access_request_seed(int ADiagModuleIndex, int ALevel,
		byte* ARecSeed, int* ARecSeedSize);
	TSAPI(u32) tsdiag_can_security_access_send_key(int ADiagModuleIndex, int ALevel, byte* ASeed, int ASeedSize);
	TSAPI(u32) tsdiag_can_request_download(int ADiagModuleIndex, u32 AMemAddr, u32 AMemSize);
	TSAPI(u32) tsdiag_can_request_upload(int ADiagModuleIndex, u32 AMemAddr, u32 AMemSize);
	TSAPI(u32) tsdiag_can_transfer_data(int ADiagModuleIndex, byte* ASourceDatas, int ASize, int AReqCase);
	TSAPI(u32) tsdiag_can_request_transfer_exit(int ADiagModuleIndex);
	TSAPI(u32) tsdiag_can_write_data_by_identifier(int ADiagModuleIndex, u16 ADataIdentifier, byte* AWriteData, int AWriteDataSize);
	TSAPI(u32) tsdiag_can_read_data_by_identifier(int ADiagModuleIndex, u16 ADataIdentifier, byte* AReturnArray, int* AReturnArraySize);

	//flexray on frFrame
	TSAPI(u32) tsflexray_register_event_flexray(const size_t ADeviceHandle, const TFlexRayQueueEvent_Win32_t ACallback);
	TSAPI(u32) tsflexray_unregister_event_flexray(const size_t ADeviceHandle, const TFlexRayQueueEvent_Win32_t ACallback);
	TSAPI(u32) tsflexray_unregister_pretx_event_flexray(const size_t ADeviceHandle, const TFlexRayQueueEvent_Win32_t ACallback);
	TSAPI(u32) tsflexray_register_pretx_event_flexray(const size_t ADeviceHandle, const TFlexRayQueueEvent_Win32_t ACallback);

}
#pragma pack(pop)
#endif