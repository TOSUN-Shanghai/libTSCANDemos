using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;

namespace TsMaster
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TLibTrigger_def
    {
        public UInt16 slot_id;
        public byte frame_idx;
        public byte cycle_code;//BASE-CYCLE + CYCLE-REPETITION
        public byte config_byte;
        public byte recv;
        public TLibTrigger_def(UInt16 slot_id, byte frame_idx, byte cycle_code, byte config_byte)
        {
            this.slot_id = slot_id;
            this.frame_idx = frame_idx;
            this.cycle_code = cycle_code;
            this.config_byte = config_byte;
            this.recv = 0;
        }
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TLibFlexray_controller_config
    {
        public byte NETWORK_MANAGEMENT_VECTOR_LENGTH;
        public byte PAYLOAD_LENGTH_STATIC;
        public UInt16 FReserved;
        public UInt16 LATEST_TX;
        // __ prtc1Control
        public UInt16 T_S_S_TRANSMITTER;
        public byte CAS_RX_LOW_MAX;
        public byte SPEED;      //0 for 10m, 1 for 5m, 2 for 2.5m, convert from Database
        public UInt16 WAKE_UP_SYMBOL_RX_WINDOW;
        public byte WAKE_UP_PATTERN;
        // __ prtc2Control
        public byte WAKE_UP_SYMBOL_RX_IDLE;
        public byte WAKE_UP_SYMBOL_RX_LOW;
        public byte WAKE_UP_SYMBOL_TX_IDLE;
        public byte WAKE_UP_SYMBOL_TX_LOW;
        // __ succ1Config
        public byte channelAConnectedNode;      // Enable ChannelA: 0: Disable 1: Enable
        public byte channelBConnectedNode;      // Enable ChannelB: 0: Disable 1: Enable
        public byte channelASymbolTransmitted; // Enable Symble Transmit function of Channel A: 0: Disable 1: Enable
        public byte channelBSymbolTransmitted; // Enable Symble Transmit function of Channel B: 0: Disable 1: Enable
        public byte ALLOW_HALT_DUE_TO_CLOCK;
        public byte SINGLE_SLOT_ENABLED;        // FALSE_0, TRUE_1
        public byte wake_up_idx;                // Wake up channe: 0:ChannelA， 1:ChannelB
        public byte ALLOW_PASSIVE_TO_ACTIVE;
        public byte COLD_START_ATTEMPTS;
        public byte synchFrameTransmitted;      // Need to transmit sync frame
        public byte startupFrameTransmitted;    // Need to transmit startup frame
                                                // __ succ2Config
        public UInt32 LISTEN_TIMEOUT;
        public byte LISTEN_NOISE;               //2_16
                                                // __ succ3Config
        public byte MAX_WITHOUT_CLOCK_CORRECTION_PASSIVE;
        public byte MAX_WITHOUT_CLOCK_CORRECTION_FATAL;
        public byte REVERS0;                    //Memory Align
                                                // __ gtuConfig
                                                // __ gtu01Config
        public UInt32 MICRO_PER_CYCLE;
        // __ gtu02Config
        public UInt16 Macro_Per_Cycle;
        public byte SYNC_NODE_MAX;
        public byte REVERS1;  //Memory Align
                              // __ gtu03Config
        public byte MICRO_INITIAL_OFFSET_A;
        public byte MICRO_INITIAL_OFFSET_B;
        public byte MACRO_INITIAL_OFFSET_A;
        public byte MACRO_INITIAL_OFFSET_B;
        // __ gtu04Config
        public UInt16 N_I_T;
        public UInt16 OFFSET_CORRECTION_START;
        // __ gtu05Config
        public byte DELAY_COMPENSATION_A;
        public byte DELAY_COMPENSATION_B;
        public byte CLUSTER_DRIFT_DAMPING;
        public byte DECODING_CORRECTION;
        // __ gtu06Config
        public UInt16 ACCEPTED_STARTUP_RANGE;
        public UInt16 MAX_DRIFT;
        // __ gtu07Config
        public UInt16 STATIC_SLOT;
        public UInt16 NUMBER_OF_STATIC_SLOTS;
        // __ gtu08Config
        public byte MINISLOT;
        public byte REVERS2;  //Memory Align
        public UInt16 NUMBER_OF_MINISLOTS;
        // __ gtu09Config
        public byte DYNAMIC_SLOT_IDLE_PHASE;
        public byte ACTION_POINT_OFFSET;
        public byte MINISLOT_ACTION_POINT_OFFSET;
        public byte REVERS3;  //Memory Align
                              // __ gtu10Config
        public UInt16 OFFSET_CORRECTION_OUT;
        public UInt16 RATE_CORRECTION_OUT;
        // __ gtu11Config
        public byte EXTERN_OFFSET_CORRECTION;
        public byte EXTERN_RATE_CORRECTION;
        //
        public byte REVERS4;  //Memory Align
        public byte config_byte;  //Memory Align
        
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TLIBFlexray
    {
        public byte FIdxChn;               // channel index starting from 0
        public byte FChannelMask;          // 0: reserved, 1: A, 2: B, 3: AB
        public byte FDir;                  // 0: Rx, 1: Tx, 2: Tx Request
        public byte FPayloadLength;        // payload length in bytes
        public byte FActualPayloadLength;  // actual data bytes
        public byte FCycleNumber;          // cycle number: 0~63
        public byte FCCType;               // 0 = Architecture independent, 1 = Invalid CC type, 2 = Cyclone I, 3 = BUSDOCTOR, 4 = Cyclone II, 5 = Vector VN interface, 6 = VN - Sync - Pulse(only in Status Event, for debugging purposes only)
        public byte FReserved0;            // 1 reserved byte
        public UInt16 FHeaderCRCA;          // header crc A
        public UInt16 FHeaderCRCB;          // header crc B
        public UInt16 FFrameStateInfo;      // bit 0~15, error flags
        public UInt16 FSlotId;              // static seg: 0~1023
        public UInt32 FFrameFlags;
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
        public UInt32 FFrameCRC;            // frame crc
        public UInt64 FReserved1;           // 8 reserved bytes
        public UInt64 FReserved2;           // 8 reserved bytes
        public UInt64 FTimeUs;              // timestamp in us
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 254)]
        public byte[] FData;// 254 data bytes

        public TLIBFlexray(byte FIdxChn, byte FChannelMask, byte FActualPayloadLength, byte FCycleNumber, UInt16 FSlotId, byte[] FData)
        {
            this.FIdxChn = FIdxChn;
            this.FChannelMask = FChannelMask;
            this.FActualPayloadLength = FActualPayloadLength;
            this.FCycleNumber = FCycleNumber;
            this.FSlotId = FSlotId;
            this.FData = new byte[254];
            this.FDir = 0;
            this.FPayloadLength = 0;
            this.FCCType = 0;
            this.FReserved0 = 0;
            this.FReserved1 = 0;
            this.FReserved2 = 0;
            this.FHeaderCRCA = 0;
            this.FHeaderCRCB = 0;
            this.FFrameCRC = 0;
            this.FTimeUs = 0;
            this.FFrameFlags = 0;
            this.FFrameStateInfo = 0;
            if (FData.Length < 254)
                for (int i = 0; i < FData.Length; i++)
                {
                    this.FData[i] = FData[i];
                }
            else
                for (int i = 0; i < 254; i++)
                {
                    this.FData[i] = FData[i];
                }

        }
    }
    public enum TSCAN_DEF
    {
        // error code
        //public const int ERR_CODE_COUNT = 56;
        IDX_ERR_OK,
        IDX_ERR_IDX_OUT_OF_RANGE,
        IDX_ERR_CONNECT_FAILED,
        IDX_ERR_DEV_NOT_FOUND,
        IDX_ERR_CODE_NOT_VALID,
        IDX_ERR_ALREADY_CONNECTED,
        IDX_ERR_SEND_FAILED
    }
    public enum LIN_PROTOCOL : int
    {
        LIN_PROTOCOL_13,
        LIN_PROTOCOL_20,
        LIN_PROTOCOL_21,
        LIN_PROTOCOL_J2602
    }
    ///
    public enum READ_TX_RX_DEF:byte
    { 
       ONLY_RX_MESSAGES,
       TX_RX_MESSAGES
    };

    public enum T_LIN_NODE_FUNCTION : byte
    { 
       T_MASTER_NODE,
       T_SLAVE_NODE,
       T_MONITOR_NODE
    };
    /// <summary>
    /// Support 32 channels
    /// </summary>
    public enum CHANNEL_INDEX : byte
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
    }
    public enum TLIBCANFDControllerType
    {
        lfdtCAN = 0,
        lfdtISOCAN = 1,
        lfdtNonISOCAN = 2
    };
    public enum TLIBCANFDControllerMode
    {
        lfdmNormal = 0,
        lfdmACKOff = 1,
        lfdmRestricted = 2
    };
    enum PropertyMask
    {
        MASK_IS_TX = 0x01,
        MASK_IS_REMOTE = 0x02,
        MASK_IS_EXT = 0x04,
        MASK_IS_LOGGED = 0x40,
        MASK_IS_ERROR = 0x80
    }
    enum FDPropertyMask
    {
        MASK_IS_EDL = 0x01,
        MASK_IS_BRS = 0x02,
        MASK_IS_ESI = 0x04
    }

    public enum CAN_ISO_TP_RESAULT
    {
        N_OK = 0
      , IDX_ERR_TP_TIMEOUT_AS = 139   //Maximum time for the sender to transmit data to the receiver, default 1000
      , IDX_ERR_TP_TIMEOUT_AR = 140   //Maximum time for the receiver to transmit flow control to the sender, default 1000
      , IDX_ERR_TP_TIMEOUT_BS = 141   //
      , IDX_ERR_TP_TIMEOUT_CR = 142
      , IDX_ERR_TP_WRONG_SN = 143
      , IDX_ERR_TP_INVALID_FS = 144
      , IDX_ERR_TP_UNEXP_PDU = 145
      , IDX_ERR_TP_WFT_OVRN = 146
      , IDX_ERR_TP_BUFFER_OVFLW = 147
      , IDX_ERR_TP_NOT_IDLE = 148
      , IDX_ERR_TP_ERROR_FROM_CAN_DRIVER = 149
    };

    public enum TSTATISTICTYPE:int
    {
        IDX_CAN_STAT_BUSLOAD = 0,      //普通负载率
        IDX_CAN_STAT_PEAKLOAD = 1,    //峰值负载率
        IDX_CAN_STAT_STD_DATA_RATE = 2,   //当前标准帧帧率
        IDX_CAN_STAT_STD_DATA_ALL = 3,   //当前已经发送了总的标准帧数量
        IDX_CAN_STAT_EXT_DATA_RATE = 4,  //扩展帧帧率
        IDX_CAN_STAT_EXT_DATA_ALL = 5,   //所有的扩展帧
        IDX_CAN_STAT_STD_REMOTE_RATE = 6,  //标准远程帧帧率
        IDX_CAN_STAT_STD_REMOTE_ALL = 7,     //所有标准远程帧数量
        IDX_CAN_STAT_EXT_REMOTE_RATE = 8,  //扩展远程帧帧率
        IDX_CAN_STAT_EXT_REMOTE_ALL = 9,   //所有扩展远程帧数量
        IDX_CAN_STAT_ERR_FRAME_RATE = 10,  //错误帧帧率
        IDX_CAN_STAT_ERR_FRAME_ALL = 11   //所有错误帧数量
        //        CAN_BUS_STAT_COUNT = 12;
    }

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void TCANQueueEvent_Win32(IntPtr ADevicehandle, ref TLIBCAN AData);
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void TCANFDQueueEvent_Win32(IntPtr ADevicehandle, ref TLIBCANFD AData);
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void TLINQueueEvent_Win32(IntPtr ADevicehandle, ref TLIBLIN AData);
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void TFlexrayQueueEvent_Win32(IntPtr ADevicehandle,ref TLIBLIN AData);
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void TTSCANConnectedCallback_Win32(IntPtr ADevicehandle);
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void N_USData_TranslateCompleted_Recall(int ATpModuleIndex, int AChn, UInt64 ATimeStamp,
                                      IntPtr APayLoad, UInt32 ASize,
                                      CAN_ISO_TP_RESAULT AError);//Reporting Received TP Data to Upper layer

    //const definition
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct TLIBCAN
    {
        public byte FIdxChn;              // channel index starting from 0
        public byte FProperties;   // default 0, masked status:
                                   // [7] 0-normal frame, 1-error frame
                                   // [6-3] tbd
                                   // [2] 0-std frame, 1-extended frame
                                   // [1] 0-data frame, 1-remote frame
                                   // [0] dir: 0-RX, 1-TX
        public byte FDLC;              // dlc from 0 to 8
        public byte FReserved;         // reserved to keep alignment
        public Int32 FIdentifier;      // CAN identifier
        public UInt64 FTimeUS;         // timestamp in us //Modified by Eric
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public Byte[] FData;           // 8 data bytes to send

        public string GetString()
        {
            string ret ="Classic CAN:"  + FTimeUS.ToString() + ":";
            if (FIsTx)
                ret += "Tx: ";
            else
                ret += "Rx: ";
            ret += FIdentifier.ToString("X8") + " ";
            ret += FDLC.ToString() + " ";
            for (int i = 0; i < FDLC; i++)
            {
                ret += FData[i].ToString("X2");
            }
            return ret; 
        }

        public Boolean FIsTx
        {
            get { return ((FProperties & (byte)PropertyMask.MASK_IS_TX) != 0); }
            set
            {
                if (value)
                {
                    FProperties |= (byte)(PropertyMask.MASK_IS_TX);
                }
                else
                {
                    byte MaskValue = (byte)PropertyMask.MASK_IS_TX;
                    FProperties &= (byte)(~(MaskValue));
                }
            }
        }

        public Boolean FIsLogged
        {
            get { return ((FProperties & (byte)PropertyMask.MASK_IS_LOGGED) != 0); }
            set
            {
                if (value)
                {
                    FProperties |= (byte)(PropertyMask.MASK_IS_LOGGED);
                }
                else
                {
                    byte MaskValue = (byte)PropertyMask.MASK_IS_LOGGED;
                    FProperties &= (byte)(~(MaskValue));
                }
            }
        }

        public Boolean FIsExt
        {
            get { return ((FProperties & (byte)PropertyMask.MASK_IS_EXT) != 0); }
            set
            {
                if (value)
                {
                    FProperties |= (byte)(PropertyMask.MASK_IS_EXT);
                }
                else
                {
                    byte MaskValue = (byte)PropertyMask.MASK_IS_EXT;
                    FProperties &= (byte)(~(MaskValue));
                }
            }
        }

        public Boolean FIsRemote
        {
            get { return ((FProperties & (byte)PropertyMask.MASK_IS_REMOTE) != 0); }
            set
            {
                if (value)
                {
                    FProperties |= (byte)(PropertyMask.MASK_IS_REMOTE);
                }
                else
                {
                    byte MaskValue = (byte)PropertyMask.MASK_IS_REMOTE;
                    FProperties &= (byte)(~(MaskValue));
                }
            }
        }
        public Boolean FIsError
        {
            get { return ((FProperties & (byte)PropertyMask.MASK_IS_ERROR) != 0); }
            set
            {
                if (value)
                {
                    FProperties |= (byte)(PropertyMask.MASK_IS_ERROR);
                }
                else
                {
                    byte MaskValue = (byte)PropertyMask.MASK_IS_ERROR;
                    FProperties &= (byte)(~(MaskValue));
                }
            }
        }



        /// <summary>
        /// TCAN帧构造函数：通过此函数构造一个TCAN帧数据类型
        /// </summary>
        /// <param name="AIdxChn">发送数据通道</param>
        /// <param name="AID">帧ID</param>
        /// <param name="AIsStd">是否标准帧</param>
        /// <param name="AIsData">是否数据帧</param>
        /// <param name="ADLC">数据长度</param>
        /// <param name="ADataArray">要发送的数组</param>
        public TLIBCAN(CHANNEL_INDEX AIdxChn, int AID, Boolean AIsTx, Boolean AIsExt, Boolean AIsRemote, byte ADLC, byte[] ADataArray)
        {
            FIdxChn = (byte)AIdxChn;
            FProperties = 0x00;
            FIdentifier = AID;
            FDLC = ADLC;
            FTimeUS = 0x00;
            FData = new byte[8];
            int cnt = ADataArray.Count();
            if (cnt > 8)
                cnt = 8;
            for (int i = 0; i < cnt; i++)
            {
                FData[i] = ADataArray[i];
            }
            FReserved = 0;
            FIsTx = AIsTx;
            FIsError = false;
            FIsExt = AIsExt;
            FIsRemote = AIsRemote;
        }

        /// <summary>
        /// TCAN帧构造函数：通过此函数构造一个TCAN帧数据类型，调用此函数创建的数据帧默认数据位0，
        /// 用户还需要通过TCANObj.FData[x]填入要发送的数据
        /// </summary>
        /// <param name="AIdxChn">发送的数据通道</param>
        /// <param name="AID">帧ID</param>
        /// <param name="AIsStd">是否标准帧</param>
        /// <param name="AIsData">是否数据帧</param>
        /// <param name="ADLC">数据长度</param>
        public TLIBCAN(CHANNEL_INDEX AIdxChn, int AID, Boolean AIsTx, Boolean AIsExt, Boolean AIsRemote, byte ADLC)
        {
            FIdxChn = (byte)AIdxChn;
            FIdentifier = AID;
            FProperties = 0;
            FDLC = ADLC;
            FTimeUS = 0x00;
            FData = new byte[8];
            FReserved = 0;
            FIsTx = AIsTx;
            FIsError = false;
            FIsExt = AIsExt;
            FIsRemote = AIsRemote;
        }
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct TLIBCANFD
    {
        public byte FIdxChn;           // channel index starting from 0        = CAN
        public byte FProperties;       // default 0, masked status:            = CAN
                                       // [7] 0-normal frame, 1-error frame
                                       // [6] 0-not logged, 1-already logged
                                       // [5-3] tbd
                                       // [2] 0-std frame, 1-extended frame
                                       // [1] 0-data frame, 1-remote frame
                                       // [0] dir: 0-RX, 1-TX
        public byte FDLC;              // dlc from 0 to 15                     = CAN
        public byte FFDProperties;     // [7-3] tbd                            <> CAN
                                       // [2] ESI, The E RROR S TATE I NDICATOR (ESI) flag is transmitted dominant by error active nodes, recessive by error passive nodes. ESI does not exist in CAN format frames
                                       // [1] BRS, If the bit is transmitted recessive, the bit rate is switched from the standard bit rate of the A RBITRATION P HASE to the preconfigured alternate bit rate of the D ATA P HASE . If it is transmitted dominant, the bit rate is not switched. BRS does not exist in CAN format frames.
                                       // [0] EDL: 0-normal CAN frame, 1-FD frame, added 2020-02-12, The E XTENDED D ATA L ENGTH (EDL) bit is recessive. It only exists in CAN FD format frames
        public Int32 FIdentifier;     // CAN identifier                       = CAN
        public UInt64 FTimeUS;          // timestamp in us                      = CAN
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public Byte[] FData;           // 64 data bytes to send
  
        public string GetString()
        {
            string ret = "";
            if (FIsFD)
              ret = "FD CAN:" + FTimeUS.ToString() + ":";
            else
              ret = "Classic CAN:" + FTimeUS.ToString() + ":";
            if (FIsTx)
                ret += "Tx: ";
            else
                ret += "Rx: ";
            ret += FIdentifier.ToString("X8") + " ";
            ret += FDLC.ToString() + " ";
            FDLC &= 0x0F;
            byte[] datalength = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 12, 16, 20, 24, 32, 48, 64 };
            FDLC = (byte)datalength[FDLC];
            for (int i = 0; i < FDLC; i++)
            {
                ret += FData[i].ToString("X2");
            }
            return ret;
        }
        public void SetStdId(Int32 AId, byte ADLC)
        {
            FIdentifier = AId;
            FDLC = ADLC;
            FProperties = (byte)(FProperties & 0xFB);
        }
        public void SetExtId(Int32 AId, byte ADLC)
        {
            FIdentifier = AId;
            FDLC = ADLC;
            FProperties |= (1 << 2);
        }
        public Boolean FIsTx
        {
            get { return ((FProperties & (byte)PropertyMask.MASK_IS_TX) != 0); }
            set
            {
                if (value)
                {
                    FProperties |= (byte)(PropertyMask.MASK_IS_TX);
                }
                else
                {
                    byte MaskValue = (byte)PropertyMask.MASK_IS_TX;
                    FProperties &= (byte)(~(MaskValue));
                }
            }
        }
        public Boolean FIsLogged
        {
            get { return ((FProperties & (byte)PropertyMask.MASK_IS_LOGGED) != 0); }
            set
            {
                if (value)
                {
                    FProperties |= (byte)(PropertyMask.MASK_IS_LOGGED);
                }
                else
                {
                    byte MaskValue = (byte)PropertyMask.MASK_IS_LOGGED;
                    FProperties &= (byte)(~(MaskValue));
                }
            }
        }

        public Boolean FIsExt
        {
            get { return ((FProperties & (byte)PropertyMask.MASK_IS_EXT) != 0); }
            set
            {
                if (value)
                {
                    FProperties |= (byte)(PropertyMask.MASK_IS_EXT);
                }
                else
                {
                    byte MaskValue = (byte)PropertyMask.MASK_IS_EXT;
                    FProperties &= (byte)(~(MaskValue));
                }
            }
        }

        public Boolean FIsRemote
        {
            get { return ((FProperties & (byte)PropertyMask.MASK_IS_REMOTE) != 0); }
            set
            {
                if (value)
                {
                    FProperties |= (byte)(PropertyMask.MASK_IS_REMOTE);
                }
                else
                {
                    byte MaskValue = (byte)PropertyMask.MASK_IS_REMOTE;
                    FProperties &= (byte)(~(MaskValue));
                }
            }
        }
        public Boolean FIsError
        {
            get { return ((FProperties & (byte)PropertyMask.MASK_IS_ERROR) != 0); }
            set
            {
                if (value)
                {
                    FProperties |= (byte)(PropertyMask.MASK_IS_ERROR);
                }
                else
                {
                    byte MaskValue = (byte)PropertyMask.MASK_IS_ERROR;
                    FProperties &= (byte)(~(MaskValue));
                }
            }
        }
        /// <summary>
        /// TCAN帧构造函数：通过此函数构造一个TCAN帧数据类型
        /// </summary>
        /// <param name="AIdxChn">发送数据通道</param>
        /// <param name="AID">帧ID</param>
        /// <param name="AIsStd">是否标准帧</param>
        /// <param name="AIsData">是否数据帧</param>
        /// <param name="ADLC">数据长度</param>
        /// <param name="ADataArray">要发送的数组</param>
        public TLIBCANFD(CHANNEL_INDEX AIdxChn, int AID, Boolean AIsTx, Boolean AIsExt, Boolean AIsRemote, byte ADLC, byte[] ADataArray)
        {
            FIdxChn = (byte)AIdxChn;
            FProperties = 0x00;
            FIdentifier = AID;
            FDLC = ADLC;
            FTimeUS = 0x00;
            FData = new byte[64];
            int cnt = ADataArray.Count();
            if (cnt > 64)
                cnt = 64;
            for (int i = 0; i < cnt; i++)
            {
                FData[i] = ADataArray[i];
            }
            FFDProperties = 0x00;
            //FReserved = 0;
            FIsTx = AIsTx;
            FIsError = false;
            FIsExt = AIsExt;
            FIsRemote = AIsRemote;
        }

        /// <summary>
        /// TCAN帧构造函数：通过此函数构造一个TCAN帧数据类型，调用此函数创建的数据帧默认数据位0，
        /// 用户还需要通过TCANObj.FData[x]填入要发送的数据
        /// </summary>
        /// <param name="AIdxChn">发送的数据通道</param>
        /// <param name="AID">帧ID</param>
        /// <param name="AIsStd">是否标准帧</param>
        /// <param name="AIsData">是否数据帧</param>
        /// <param name="ADLC">数据长度</param>
        public TLIBCANFD(CHANNEL_INDEX AIdxChn, int AID, Boolean AIsTx, Boolean AIsExt, Boolean AIsRemote, byte ADLC, Boolean AIsFD = false, Boolean AIsBRS = false)
        {
            FIdxChn = (byte)AIdxChn;
            FIdentifier = AID;
            FProperties = 0;
            FDLC = ADLC;
            FTimeUS = 0x00;
            FData = new byte[64];
            FFDProperties = 0x00;
            //FReserved = 0;
            FIsTx = AIsTx;
            FIsError = false;
            FIsExt = AIsExt;
            FIsRemote = AIsRemote;
            //FD Property
            FIsFD = AIsFD;
            FIsBRS = AIsBRS;
        }

        public TLIBCANFD(CHANNEL_INDEX AIdxChn, int AID, Boolean AIsTx, Boolean AIsExt, Boolean AIsRemote, byte ADLC, byte[] ADatas, Boolean AIsFD = false, Boolean AIsBRS = false)
        {
            FIdxChn = (byte)AIdxChn;
            FIdentifier = AID;
            FProperties = 0;
            FDLC = ADLC;
            FTimeUS = 0x00;
            FData = ADatas;
            FFDProperties = 0x00;
            //FReserved = 0;
            FIsTx = AIsTx;
            FIsError = false;
            FIsExt = AIsExt;
            FIsRemote = AIsRemote;
            //FD Property
            FIsFD = AIsFD;
            FIsBRS = AIsBRS;
        }
        public Boolean FIsFD
        {
            get { return ((FFDProperties & (byte)FDPropertyMask.MASK_IS_EDL) != 0); }
            set
            {
                if (value)
                {
                    FFDProperties |= (byte)(FDPropertyMask.MASK_IS_EDL);
                }
                else
                {
                    byte MaskValue = (byte)FDPropertyMask.MASK_IS_EDL;
                    FFDProperties &= (byte)(~(MaskValue));
                }
            }
        }
        public Boolean FIsBRS
        {
            get { return ((FFDProperties & (byte)FDPropertyMask.MASK_IS_BRS) != 0); }
            set
            {
                if (value)
                {
                    FFDProperties |= (byte)(FDPropertyMask.MASK_IS_BRS);
                }
                else
                {
                    byte MaskValue = (byte)FDPropertyMask.MASK_IS_BRS;
                    FFDProperties &= (byte)(~(MaskValue));
                }
            }
        }

        public Boolean FIsESI
        {
            get { return ((FFDProperties & (byte)FDPropertyMask.MASK_IS_ESI) != 0); }
            set
            {
                if (value)
                {
                    FFDProperties |= (byte)(FDPropertyMask.MASK_IS_ESI);
                }
                else
                {
                    byte MaskValue = (byte)FDPropertyMask.MASK_IS_ESI;
                    FFDProperties &= (byte)(~(MaskValue));
                }
            }
        }
        public static readonly byte[] DLC_DATA_BYTE_CNT = new byte[16] {
            0,  1,  2,  3,  4,  5,  6, 7,
            8,  12, 16, 20, 24, 32, 48, 64
        };
        int GetDataLength()
        {
            if (FIsFD)
            {
                if (FDLC >= 16)
                    FDLC = 15;
                return DLC_DATA_BYTE_CNT[FDLC];
            }
            else
                return FDLC;
        }
    }


    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct TLIBLIN
    {
        enum PropertyLINMask
        {
            MASK_IS_TX = 0x01,
            MASK_IS_SENDBREAK = 0x02,
            MASK_IS_RECEIVEDBREAK = 0x04,
            MASK_IS_RECEIVEDSYNC = 0x08,
            MASK_HW_TYPE = 0x30,
            MASK_IS_LOGGED = 0x40,
            MASK_RESERVED = 0x80
        }
        public byte FIdxChn;          // channel index starting from 0
        public byte FErrStatus;       // reserved to keep alignment
        public byte FProperties;      // default 0, masked status:
                                      // [7] tbd
                                      // [6] 0-not logged, 1-already logged
                                      // [5-4] FHWType //DEV_MASTER,DEV_SLAVE,DEV_LISTENER
                                      // [3] 0-not ReceivedSync, 1- ReceivedSync
                                      // [2] 0-not received FReceiveBreak, 1-Received Break
                                      // [1] 0-not send FReceiveBreak, 1-send Break
                                      // [0] dir: 0-RX, 1-TX
        public byte FDLC;             // dlc from 0 to 8 
        public byte FIdentifier;     // LIN identifier
        public byte FChecksum;        //
        public byte FStatus;
        public UInt64 FTimeUS;        // timestamp in us
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public Byte[] FData;           // 8 data bytes to send

        /// <summary>
        /// TCAN帧构造函数：通过此函数构造一个TCAN帧数据类型
        /// </summary>
        /// <param name="AIdxChn">发送数据通道</param>
        /// <param name="AID">帧ID</param>
        /// <param name="AIsStd">是否标准帧</param>
        /// <param name="AIsData">是否数据帧</param>
        /// <param name="ADLC">数据长度</param>
        /// <param name="ADataArray">要发送的数组</param>
        public TLIBLIN(CHANNEL_INDEX AIdxChn, byte AID, byte ADLC, Boolean AIsTx, byte[] ADataArray)
        {
            FIdxChn = (byte)AIdxChn;
            FProperties = 0x00;
            FIdentifier = AID;
            FDLC = ADLC;
            FTimeUS = 0x00;
            FData = new byte[8];
            int cnt = ADataArray.Count();
            if (cnt > 8)
                cnt = 8;
            for (int i = 0; i < cnt; i++)
            {
                FData[i] = ADataArray[i];
            }
            FChecksum = 0;
            FStatus = 0;
            FErrStatus = 0;
            FIsTx = AIsTx;
        }

        /// <summary>
        /// TCAN帧构造函数：通过此函数构造一个TCAN帧数据类型，调用此函数创建的数据帧默认数据位0，
        /// 用户还需要通过TCANObj.FData[x]填入要发送的数据
        /// </summary>
        /// <param name="AIdxChn">发送的数据通道</param>
        /// <param name="AID">帧ID</param>
        /// <param name="AIsStd">是否标准帧</param>
        /// <param name="AIsData">是否数据帧</param>
        /// <param name="ADLC">数据长度</param>
        public TLIBLIN(CHANNEL_INDEX AIdxChn, byte AID, byte ADLC, Boolean AIsTx)
        {
            FIdxChn = (byte)AIdxChn;
            FIdentifier = AID;
            FProperties = 0;
            FDLC = ADLC;
            FTimeUS = 0x00;
            FData = new byte[8];
            FChecksum = 0;
            FStatus = 0;
            FErrStatus = 0;
            FIsTx = AIsTx;
        }
        public Boolean FIsTx
        {
            get { return ((FProperties & (byte)PropertyLINMask.MASK_IS_TX) != 0); }
            set
            {
                if (value)
                {
                    FProperties |= (byte)(PropertyLINMask.MASK_IS_TX);
                }
                else
                {
                    byte MaskValue = (byte)PropertyLINMask.MASK_IS_TX;
                    FProperties &= (byte)(~(MaskValue));
                }
            }
        }
    }

    public enum TCARDTYPE {
        T_UNDEF,
        T_DI_DO,
        T_AI_AO_DI,
        T_CI_AI,
        T_KEY_BOARD,
        T_RESISTOR_MATRIX,
        T_EOL_TEST_BOARD,
        T_CI_AI_DO,
        T_RELAY_BOARD,
        T_DI_DO_NEW,
        T_TSCANLIN_CARD,
        T_LED_ACTUATOR,
        T_TSCANLIN_ROUTER,       
        T_External_Device, //现有外部设备,如外用表，电源等
        T_THERMO_COUPLE,
        T_ZIGBEE_EPOWER,
        T_RESISTOR_MATRIX_2,
        T_CAPACITOR_MATRIX,
        T_CARDTYPE_NUM
    };


    public class TsCANApi
    {
#if SUPPORT_CANIO_CARD
        const string TSCANDLL_NAME = @".\libTSCAN_WithIO.dll";
#else
        const string TSCANDLL_NAME = @".\libTSCAN.dll";
#endif

#if SUPPORT_CANIO_CARD
        //TSCANIO API
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void InitTSIOCardAPI_CAN(string AAppName, int AChnIndex, Boolean AEnableFIFO, int ABaudrateKBps = 1000);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void FinalizeTSIOBoardAPI_CAN();
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int tscanioapp_connect();
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int tsapp_set_turbo_mode(Boolean AEnable);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int AddNewCANIOModule_CAN(TCARDTYPE ACardType, Byte AHardwareIndex);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int SyncSetIOValue_CAN(int handle, int channelIndex, int highlevel, UInt32 ATimeoutMS);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int ASyncSetIOValue_CAN(int handle, int channelIndex, int highlevel);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int SyncGetDIPortValue_CAN(int handle, ref UInt32 pportValue, UInt32 ATimeoutMS);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int ASyncEPowerVoltage_CAN(int handle, ref Single pAdcValue);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int ASyncEPowerCurrent_CAN(int handle, ref Single pAdcValue);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int ASyncGetDIPortValue_CAN(int handle, ref UInt32 pportValue);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int SyncGetDOPortValue_CAN(int handle, ref UInt32 pportValue, UInt32 ATimeoutMS);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int ASyncGetDOPortValue_CAN(int handle, ref UInt32 pportValue);
        //ADI
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int SyncReadADCValue_CAN(int handle, int channelIndex,ref UInt16 pAdcValue, int ATimeoutMS);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int ASyncReadADCValue_CAN(int handle, int channelIndex,ref UInt16 pAdcValue);
        //FBL
        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern unsafe static int FBL_ApplyGoInFBL_CAN(int handle, byte* pData, int ALength, int ATimeoutMS);
        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern unsafe static int FBL_ReadData_CAN(int handle, UInt32 Address, int ALength, byte* pData, int ATimeoutMS);
        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern unsafe static int FBL_WriteData_CAN(int handle, UInt32 Address, int ALength, byte* pData, int ATimeoutMS);
        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static int FBL_ERASEFlash_CAN(int handle, int ATimeoutMS);
        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static int FBL_RestartExe_CAN(int handle, int ATimeoutMS);
        //Hardware Manage
        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static int RemoveIOBoardModule_CAN(int handle);
        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern unsafe static int System_QueryOnlineDevices_CAN(int* ADeviceList, int* AOnlineDeviceNum, Boolean AClearDeviceNotExist, int ATimeoutMS);
        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static int System_SetHardwareTypeAndIndex_CAN(byte AType, byte AIndex, int ATimeoutMS);
        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public extern static int SetCANChannel(int AChnIndex);
#endif

#if (SUPPORT_HANDLE_APL)
        //TSCANApi
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void initialize_lib_tscan(Boolean AEnableFIFO, Boolean AEnableErrorFrame, Boolean AEnableTurbe);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void finalize_lib_tscan();

        // Device management -----------------------------------------------------------
        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern UInt32 tscan_scan_devices(ref UInt32 ADeviceCount);
        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern UInt32 tscan_get_device_info(
        UInt32 ADeviceIndex,
        ref IntPtr AFManufacturer,
        ref IntPtr AFProduct,
        ref IntPtr AFSerial
        );
        //Bus Status
        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern Double tscan_get_bus_status(IntPtr ADeviceHandle, CHANNEL_INDEX AChnBase0, TSTATISTICTYPE AIndex);
        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern void tscan_set_auto_calc_bus_statistics(Boolean Value);  //启动自动总线数据统计
        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern void tscan_clear_can_bus_statistic();  //清除总线信息统计
        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern UInt32 tscan_connect(string ADeviceSerial, ref IntPtr ADeviceHandle);
        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern UInt32 tscan_disconnect_all_devices();
        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern UInt32 tscan_disconnect_by_serial(string ADeviceSerial);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tscan_disconnect_by_handle(IntPtr ADeviceHandle);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tscan_get_error_description(UInt32 ACode, IntPtr ADesc);   //Char**
        //API
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tscan_register_event_can_whandle(IntPtr ADeviceHandle, TCANQueueEvent_Win32 ACallback);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tscan_unregister_event_can_whandle(IntPtr ADeviceHandle, TCANQueueEvent_Win32 ACallback);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tscan_register_event_canfd(IntPtr ADeviceHandle, TCANFDQueueEvent_Win32 ACallback);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tscan_unregister_event_canfd(IntPtr ADeviceHandle, TCANFDQueueEvent_Win32 ACallback);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tscan_register_event_canfd_whandle(IntPtr ADeviceHandle, TCANFDQueueEvent_Win32 ACallback);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tscan_unregister_event_canfd_whandle(IntPtr ADeviceHandle, TCANFDQueueEvent_Win32 ACallback);

        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tslin_register_event_lin_whandle(IntPtr ADeviceHandle, TLINQueueEvent_Win32 ACallback);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tslin_unregister_event_lin_whandle(IntPtr ADeviceHandle, TLINQueueEvent_Win32 ACallback);

        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tscan_transmit_can_sync(IntPtr ADeviceHandle, ref TLIBCAN ACAN, UInt32 ATimeoutMS);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tscan_transmit_can_async(IntPtr ADeviceHandle, ref TLIBCAN ACAN);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tscan_add_cyclic_msg_can(IntPtr ADeviceHandle, ref TLIBCAN ACAN, Single APeriodMS);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tscan_delete_cyclic_msg_can(IntPtr ADeviceHandle, ref TLIBCAN ACAN);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        internal static extern UInt32 tsfifo_receive_can_msgs(IntPtr ADeviceHandle, IntPtr ACANBuffer, ref Int32 ABufferSize, CHANNEL_INDEX AChn, READ_TX_RX_DEF ATxRx);  //ACANBuffers: PCAN
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tsfifo_clear_can_receive_buffers(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIndex);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int tsfifo_read_can_buffer_frame_count(IntPtr ADeviceHandle, CHANNEL_INDEX AChannel, ref int ACount);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int tsfifo_read_can_tx_buffer_frame_count(IntPtr ADeviceHandle, CHANNEL_INDEX AChannel, ref int ACount);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int tsfifo_read_can_rx_buffer_frame_count(IntPtr ADeviceHandle, CHANNEL_INDEX AChannel, ref int ACount);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int tsfifo_read_canfd_buffer_frame_count(IntPtr ADeviceHandle, CHANNEL_INDEX AChannel, ref int ACount);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int tsfifo_read_canfd_tx_buffer_frame_count(IntPtr ADeviceHandle, CHANNEL_INDEX AChannel, ref int ACount);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int tsfifo_read_canfd_rx_buffer_frame_count(IntPtr ADeviceHandle, CHANNEL_INDEX AChannel, ref int ACount);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tsfifo_read_lin_buffer_datacount(IntPtr ADeviceHandle, CHANNEL_INDEX AChannel, ref int ACount);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tsfifo_read_lin_tx_buffer_frame_count(IntPtr ADeviceHandle, CHANNEL_INDEX AChannel, ref int ACount);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tsfifo_read_lin_rx_buffer_frame_count(IntPtr ADeviceHandle, CHANNEL_INDEX AChannel, ref int ACount);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tsfifo_read_fastlin_buffer_datacount(IntPtr ADeviceHandle, CHANNEL_INDEX AChannel, ref int ACount);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tsfifo_read_fastlin_tx_buffer_frame_count(IntPtr ADeviceHandle, CHANNEL_INDEX AChannel, ref int ACount);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tsfifo_read_fastlin_rx_buffer_frame_count(IntPtr ADeviceHandle, CHANNEL_INDEX AChannel, ref int ACount);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tscan_transmit_canfd_sync(IntPtr ADeviceHandle, ref TLIBCANFD ACANFD, UInt32 ATimeoutMS);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tscan_transmit_canfd_async(IntPtr ADeviceHandle, ref TLIBCANFD ACANFD);

        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tscan_add_cyclic_msg_canfd(IntPtr ADeviceHandle, ref TLIBCANFD ACANFD, Single APeriodMS);

        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tscan_delete_cyclic_msg_canfd(IntPtr ADeviceHandle, ref TLIBCANFD ACANFD);

        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        internal static extern UInt32 tsfifo_receive_canfd_msgs(IntPtr ADeviceHandle, IntPtr ACANFDBuffers, ref Int32 ACANFDBufferSize, CHANNEL_INDEX AChn, READ_TX_RX_DEF ATxRx);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tsfifo_clear_canfd_receive_buffers(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIndex);
        //Filter
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tsfifo_add_can_canfd_pass_filter(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIdx, int AIdentifier, Boolean AIsStd);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tsfifo_add_lin_pass_filter(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIdx, int AIdentifier);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tsfifo_delete_can_canfd_pass_filter(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIdx, int AIdentifier);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tsfifo_delete_lin_pass_filter(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIdx, int AIdentifier);
        //End Filter
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tscan_config_can_by_baudrate(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIdx, Double ARateKbp, UInt32 A120OhmConnected);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tscan_config_canfd_by_baudrate(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIdx, Double AArbRateKbps, double ADataRateKbps,
            TLIBCANFDControllerType AControllerType, TLIBCANFDControllerMode AControllerMode, UInt32 A120OhmConnected);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tslin_transmit_lin_sync(IntPtr ADeviceHandle, ref TLIBLIN ALIN, UInt32 ATimeoutMS);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tslin_transmit_lin_async(IntPtr ADeviceHandle, ref TLIBLIN ALIN);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        internal static extern UInt32 tsfifo_receive_lin_msgs(IntPtr ADeviceHandle, IntPtr ALINBuffer, ref Int32 ABufferSize, CHANNEL_INDEX AChn, READ_TX_RX_DEF ATxRx);  //ACANBuffers: PLIN
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tsfifo_clear_lin_receive_buffers(IntPtr ADeviceHandle, CHANNEL_INDEX AChn);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        internal static extern UInt32 tsfifo_receive_fastlin_msgs(IntPtr ADeviceHandle, IntPtr AFastLINBuffer, ref Int32 ABufferSize, CHANNEL_INDEX AChn, READ_TX_RX_DEF ATxRx);  //ACANBuffers: PFastLIN
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tsfifo_clear_fastlin_receive_buffers(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIndex);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tscan_get_error_description(UInt32 ACode, ref IntPtr ADesc);

        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tscan_register_event_connected(TTSCANConnectedCallback_Win32 ACallback);

        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tscan_register_event_disconnected(TTSCANConnectedCallback_Win32 ACallback);

        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tscan_unregister_event_connected(TTSCANConnectedCallback_Win32 ACallback);

        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tscan_unregister_event_disconnected(TTSCANConnectedCallback_Win32 ACallback);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static unsafe Int32 tsccp_apply_read_data_package(IntPtr ADeviceHandle, UInt32 AMasterCRO, UInt32 ASlaveDTO, int ATimeoutMS);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static unsafe Int32 tsccp_read_data_package(IntPtr ADeviceHandle, byte AChn, Byte AIsStd,
                                         Byte isFirstPackage, Byte ACTRNum,
                                         UInt32 AMasterCRO, UInt32 ASlaveDTO,
                                         Byte* pData, int dataCnt, int ATimeoutMS);
        //LIN
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tslin_config_baudrate(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIdx, double ARateKbps, LIN_PROTOCOL AProtocol);

        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tslin_config_baudrate_verbose(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIdx, double ARateKbps, LIN_PROTOCOL AProtocol,bool AKeepLowLevelIDLEMode);

        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tslin_set_schedule_table(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIdx, byte ASchIndex);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tslin_stop_lin_channel(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIdx);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tslin_set_node_functiontype(
              IntPtr ADeviceHandle,
              CHANNEL_INDEX AChnIdx,
              T_LIN_NODE_FUNCTION AFunctionType //0:MasterNode;1:SlaveNode;2:MonitorNode
            );
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern unsafe UInt32 tstp_lin_master_request(
              IntPtr ADeviceHandle,
              CHANNEL_INDEX AChnIdx,
              byte ANAD,
              byte* AData,
              UInt16 ADataNum,
              UInt32 ATimeoutMs
            );
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern unsafe UInt32 tstp_lin_master_tranceive_sync(    //request and get response
      IntPtr ADeviceHandle,
              CHANNEL_INDEX AChnIdx,
              byte AReqNAD,
              byte* AReqData,
              int AReqDataNum,
      byte* AResNAD,
      byte* AResData,
      int* AResDataNum,
      UInt32 ATimeoutMS
    );
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tstp_lin_master_request_intervalms(
                      IntPtr ADeviceHandle,
                      CHANNEL_INDEX AChnIdx,
                      byte AData
                     );
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tslin_clear_schedule_tables(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIdx);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tstp_lin_reset(IntPtr ADeviceHandle, UInt32 AChnIdx);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tstp_lin_slave_response_intervalms(IntPtr ADeviceHandle,
              CHANNEL_INDEX AChnIdx,
              byte AData);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tstp_lin_tp_para_default(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIdx, UInt16 AReqIntervalMs,
                UInt16 AResIntervalMs, UInt16 AResRetryTime);

        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tstp_lin_tp_para_special(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIdx, UInt16 AReqIntervalMs,
                UInt16 AResIntervalMs, UInt16 AResRetryTime);

        //lin_diag_service_layer
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern unsafe int tsdiag_lin_read_data_by_identifier(IntPtr ADeviceHandle,
                             CHANNEL_INDEX AChnIdx,
                             byte ANAD,
                             UInt16 AId,
                             byte* AResNAD,
                             byte* AResData,
                             int* AResDataNum,
                             UInt32 ATimeoutMS);   //ServiceID:0x22

        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern unsafe int tsdiag_lin_write_data_by_identifier(IntPtr ADeviceHandle,
                             CHANNEL_INDEX AChnIdx,
                             byte ANAD,
                             UInt16 AId,
                             byte* AReqData,
                             int AReqDataNum,
                             byte* AResNAD,
                             byte* AResData,
                             int* AResDataNum,
                             UInt32 ATimeoutMS);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern unsafe int tsdiag_lin_session_control(IntPtr ADeviceHandle,
                                                                                         CHANNEL_INDEX AChnIdx,
                                                                                         byte ANAD,
                                                                                         byte ASession,
                                                                                         UInt32 ATimeoutMS);
        //Service ID：0x19
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern unsafe int tsdiag_lin_fault_memory_read(IntPtr ADeviceHandle,
                                                                                             CHANNEL_INDEX AChnIdx,
                                                                                             byte ANAD,
                                                                                             UInt16 data_length,
                                                                                             byte* AData,
                                                                                            UInt32 ATimeoutMS);
        //ServiceID：0x14
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern unsafe int tsdiag_lin_fault_memory_clear(IntPtr ADeviceHandle,
                                                                                               CHANNEL_INDEX AChnIdx,
                                                                                                byte ANAD,
                                                                                                UInt16 data_length,
                                                                                                byte* AData,
                                                                                                UInt32 ATimeoutMS);

        //CAN Diagnostic
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int tsdiag_can_create(ref int pDiagModuleIndex,
                              CHANNEL_INDEX AChnIndex,
                              Byte ASupportFDCAN,
                              Byte AMaxDLC,
                              UInt32 ARequestID,
                              Boolean ARequestIDIsStd,
                              UInt32 AResponseID,
                              Boolean AResponseIDIsStd,
                              UInt32 AFunctionID,
                              Boolean AFunctionIDIsStd);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int tsdiag_can_delete(int ADiagModuleIndex);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void tsdiag_can_delete_all();
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int tsdiag_can_attach_to_tscan_tool(int ADiagModuleIndex, IntPtr ACANToolHandle);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int tstp_can_register_tx_completed_recall(int ADiagModuleIndex, N_USData_TranslateCompleted_Recall ATxcompleted);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int tstp_can_register_rx_completed_recall(int ADiagModuleIndex, N_USData_TranslateCompleted_Recall ARxcompleted);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern unsafe int tstp_can_send_functional(int ADiagModuleIndex, byte* AReqDataArray, int AReqDataSize);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern unsafe int tstp_can_send_request(int ADiagModuleIndex, byte* AReqDataArray, int AReqDataSize);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern unsafe int tstp_can_request_and_get_response(int ADiagModuleIndex, byte* AReqDataArray, int AReqDataSize, byte* AResponseDataArray, ref int AResponseDataSize);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int tsdiag_can_session_control(int ADiagModuleIndex, byte ASubSession);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int tsdiag_can_routine_control(int ADiagModuleIndex, byte ARoutineControlType, UInt16 ARoutintID);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int tsdiag_can_communication_control(int ADiagModuleIndex, byte AControlType);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern unsafe int tsdiag_can_security_access_request_seed(int ADiagModuleIndex, int ALevel, byte* ARecSeed, ref int ARecSeedSize);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern unsafe int tsdiag_can_security_access_send_key(int ADiagModuleIndex, int ALevel, byte* AKeyValue, int AKeySize);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int tsdiag_can_request_download(int ADiagModuleIndex, UInt32 AMemAddr, UInt32 AMemSize);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int tsdiag_can_request_upload(int ADiagModuleIndex, UInt32 AMemAddr, UInt32 AMemSize);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern unsafe int tsdiag_can_transfer_data(int ADiagModuleIndex, byte* ASourceDatas, int ADataSize, int AReqCase);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int tsdiag_can_request_transfer_exit(int ADiagModuleIndex);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern unsafe int tsdiag_can_write_data_by_identifier(int ADiagModuleIndex, UInt16 ADataIdentifier, byte* AWriteData, int AWriteDataSize);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern unsafe int tsdiag_can_read_data_by_identifier(int ADiagModuleIndex, UInt16 ADataIdentifier, byte* AReturnArray, ref int AReturnArraySize);

        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        //arg[0] ADiagModuleIndex : None
        //arg[1] AChnIndex : None
        public static extern int tsdiag_set_channel(int ADiagModuleIndex, int AChnIndex);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        //arg[0] ADiagModuleIndex : None
        //arg[1] AFDMode : None
        //arg[2] AMaxLength : None
        public static extern int tsdiag_set_fdmode(int ADiagModuleIndex, bool AFDMode, int AMaxLength);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        //arg[0] ADiagModuleIndex : None
        //arg[1] ARequestID : None
        //arg[2] AIsStandard : None
        public static extern int tsdiag_set_request_id(int ADiagModuleIndex, int ARequestID, bool AIsStandard);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        //arg[0] ADiagModuleIndex : None
        //arg[1] ARequestID : None
        //arg[2] AIsStandard : None
        public static extern int tsdiag_set_response_id(int ADiagModuleIndex, int ARequestID, bool AIsStandard);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        //arg[0] ADiagModuleIndex : None
        //arg[1] ARequestID : None
        //arg[2] AIsStandard : None
        public static extern int tsdiag_set_function_id(int ADiagModuleIndex, int ARequestID, bool AIsStandard);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        //arg[0] ADiagModuleIndex : None
        //arg[1] ASTMin : None
        public static extern int tsdiag_set_stmin(int ADiagModuleIndex, int ASTMin);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        //arg[0] ADiagModuleIndex : None
        //arg[1] ABlockSize : None
        public static extern int tsdiag_set_blocksize(int ADiagModuleIndex, int ABlockSize);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        //arg[0] ADiagModuleIndex : None
        //arg[1] AMaxLength : None
        public static extern int tsdiag_set_maxlength(int ADiagModuleIndex, int AMaxLength);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        //arg[0] ADiagModuleIndex : None
        //arg[1] AFCDelay : None
        public static extern int tsdiag_set_fcdelay(int ADiagModuleIndex, int AFCDelay);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        //arg[0] ADiagModuleIndex : None
        //arg[1] AFilledByte : None
        public static extern int tsdiag_set_filled_byte(int ADiagModuleIndex, byte AFilledByte);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        //arg[0] ADiagModuleIndex : None
        //arg[1] ATimeMs : None
        public static extern int tsdiag_set_p2_timeout(int ADiagModuleIndex, int ATimeMs);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        //arg[0] ADiagModuleIndex : None
        //arg[1] ATimeMs : None
        public static extern int tsdiag_set_p2_extended(int ADiagModuleIndex, int ATimeMs);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        //arg[0] ADiagModuleIndex : None
        //arg[1] ATimeMs : None
        public static extern int tsdiag_set_s3_servertime(int ADiagModuleIndex, int ATimeMs);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        //arg[0] ADiagModuleIndex : None
        //arg[1] ATimeMs : None
        public static extern int tsdiag_set_s3_clienttime(int ADiagModuleIndex, int ATimeMs);

        public static int tsdiag_can_security_access_request_seed_dontnet(int ADiagModuleIndex, int ALevel, ref UInt32 ARecSeed)
        {
            int ARefSize = 4;
            UInt32 tmpSeedValue = 0;
            unsafe
            {
                byte* pSeed = (byte*)(&tmpSeedValue);
                int ret = tsdiag_can_security_access_request_seed(ADiagModuleIndex, ALevel, pSeed, ref ARefSize);
                ARecSeed = tmpSeedValue;
                return ret;
            }
        }
        public static int tsdiag_can_security_access_send_key_dontnet(int ADiagModuleIndex, int ALevel, UInt32 AKeyValue)
        {
            unsafe
            {
                byte* pKeyValue = (byte*)(&AKeyValue);
                return tsdiag_can_security_access_send_key(ADiagModuleIndex, ALevel, pKeyValue, 4);
            }
        }

        /// <summary>
        /// 功能：查询当前设备的信息
        /// 前置条件：调用此函数之前必须执行TSCAN_ScanDevices扫描当前在线的设备
        /// </summary>
        /// <param name="ADeviceIndex"></param>
        /// <param name="AFManufacturer"></param>
        /// <param name="AFProduct"></param>
        /// <param name="AFSerial"></param>
        /// <returns></returns>
        public static UInt32 GetDeviceInfo(
                UInt32 ADeviceIndex,
                ref string AFManufacturer,
                ref string AFProduct,
                ref string AFSerial
                )
        {
            IntPtr ptr1 = (IntPtr)0;
            IntPtr ptr2 = (IntPtr)0;
            IntPtr ptr3 = (IntPtr)0;
            UInt32 ret = tscan_get_device_info(
                    ADeviceIndex,
                    ref ptr1,
                    ref ptr2,
                    ref ptr3
                    );
            if (ret == 0)
            {
                AFManufacturer = (string)Marshal.PtrToStringAnsi(ptr1);
                AFProduct = (string)Marshal.PtrToStringAnsi(ptr2);
                AFSerial = (string)Marshal.PtrToStringAnsi(ptr3);
            }
            return ret;
        }
        public static string TSCAN_GetTSCANErrorDescription(UInt32 ACode)
        {
            IntPtr ADesc = (IntPtr)0;
            if (tscan_get_error_description(ACode, ref ADesc) != 0)
                return "";
            else
            {
                return Marshal.PtrToStringAnsi(ADesc);
            }
        }

        public static Boolean ReceiveCANMsg(IntPtr ADeviceHandle, out TLIBCAN ACANMsg, int ATimeoutMs, CHANNEL_INDEX AChn = CHANNEL_INDEX.CHN1, READ_TX_RX_DEF AOnlyRx = READ_TX_RX_DEF.ONLY_RX_MESSAGES)
        {
            IntPtr pCANMsg = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(TLIBCAN)));
            DateTime start = System.DateTime.Now;
            TimeSpan diff;
            Boolean ret = false;
            ACANMsg = new TLIBCAN();
            int bufferSize;
            try
            {
                do
                {
                    bufferSize = 1;
                    if ((tsfifo_receive_can_msgs(ADeviceHandle, pCANMsg, ref bufferSize, AChn, AOnlyRx) == 0) && (bufferSize > 0))
                    {
                        ACANMsg = (TLIBCAN)(Marshal.PtrToStructure(pCANMsg, typeof(TLIBCAN)));
                        ret = true;
                        break;
                    }
                    Thread.Sleep(1);
                    diff = System.DateTime.Now - start;
                } while (diff.TotalMilliseconds < (ATimeoutMs));
            }
            finally
            {
                Marshal.FreeHGlobal(pCANMsg);
            }
            return ret;
        }

        /// <summary>
        /// 通过读取设备内部缓存，读取接收数据
        /// </summary>
        /// <param name="ADeviceHandle">设备句柄</param>
        /// <param name="ACANMsgBuffer">数据Buffer，用于存储读取到的报文，该Buffer需要函数调用方创建</param>
        /// <param name="ACANBufferSize">消息Buffer的大小</param>
        /// <param name="AChn">目标通道：对于多通道设备，本函数选择读取哪一个通道的数据，该参数可以为空，默认为通道1</param>
        /// <param name="ATxRx">==0:仅仅接收Rx报文；>0: Tx Rx报文都读取回来，该参数可以为空，默认为只接收Rx报文</param>
        /// <returns>返回实际读取到的报文数量，如果没有任何报文，则返回值为0</returns>
        public static int ReceiveCANMsgList(IntPtr ADeviceHandle, ref TLIBCAN[] ACANMsgBuffer, int ACANBufferSize, CHANNEL_INDEX AChn = CHANNEL_INDEX.CHN1, READ_TX_RX_DEF ATxRx = READ_TX_RX_DEF.ONLY_RX_MESSAGES)
        {
            IntPtr pCANMsg = Marshal.AllocHGlobal((IntPtr)(Marshal.SizeOf(typeof(TLIBCAN)) * ACANBufferSize));
            DateTime start = System.DateTime.Now;
            int retNum = ACANBufferSize;
            try
            {
                tsfifo_receive_can_msgs(ADeviceHandle, pCANMsg, ref retNum, AChn, ATxRx);
                for (int i = 0; i < retNum; i++)
                {
                    ACANMsgBuffer[i] = new TLIBCAN();
                    ACANMsgBuffer[i] = (TLIBCAN)Marshal.PtrToStructure((IntPtr)(pCANMsg + Marshal.SizeOf(typeof(TLIBCAN)) * i), typeof(TLIBCAN));
                }
                return retNum;
            }
            finally
            {
                Marshal.FreeHGlobal(pCANMsg);
            }
        }
        public static Boolean ReceiveCANFDMsg(IntPtr ADeviceHandle, out TLIBCANFD ACANMsg, int ATimeoutMs, CHANNEL_INDEX AChn = 0, READ_TX_RX_DEF ARxTx = READ_TX_RX_DEF.ONLY_RX_MESSAGES)
        {
            IntPtr pCANMsg = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(TLIBCANFD)));
            DateTime start = System.DateTime.Now;
            TimeSpan diff;
            Boolean ret = false;
            ACANMsg = new TLIBCANFD();
            int bufferSize;
            try
            {
                do
                {
                    bufferSize = 1;
                    if ((tsfifo_receive_canfd_msgs(ADeviceHandle, pCANMsg, ref bufferSize, AChn, ARxTx) == 0) && (bufferSize > 0))
                    {
                        ACANMsg = (TLIBCANFD)(Marshal.PtrToStructure(pCANMsg, typeof(TLIBCANFD)));
                        ret = true;
                        break;
                    }
                    Thread.Sleep(1);
                    diff = System.DateTime.Now - start;
                } while (diff.TotalMilliseconds < (ATimeoutMs));
            }
            finally
            {
                Marshal.FreeHGlobal(pCANMsg);
            }
            return ret;
        }

        /// <summary>
        /// 通过读取设备内部缓存，读取接收数据
        /// </summary>
        /// <param name="ADeviceHandle">设备句柄</param>
        /// <param name="ACANMsgBuffer">数据Buffer，用于存储读取到的报文，该Buffer需要函数调用方创建</param>
        /// <param name="ACANBufferSize">消息Buffer的大小</param>
        /// <param name="AChn">目标通道：对于多通道设备，本函数选择读取哪一个通道的数据，该参数可以为空，默认为通道1</param>
        /// <param name="ATxRx">==0:仅仅接收Rx报文；>0: Tx Rx报文都读取回来，该参数可以为空，默认为只接收Rx报文</param>
        /// <returns>返回实际读取到的报文数量，如果没有任何报文，则返回值为0</returns>
        public static int ReceiveCANFDMsgList(IntPtr ADeviceHandle, ref TLIBCANFD[] ACANMsgBuffer, int ACANBufferSize, CHANNEL_INDEX AChn = CHANNEL_INDEX.CHN1, READ_TX_RX_DEF ARxTx = READ_TX_RX_DEF.ONLY_RX_MESSAGES)
        {
            IntPtr pCANMsg = Marshal.AllocHGlobal((IntPtr)(Marshal.SizeOf(typeof(TLIBCANFD)) * ACANBufferSize));
            DateTime start = System.DateTime.Now;
            int retNum = ACANBufferSize;
            try
            {
                if (tsfifo_receive_canfd_msgs(ADeviceHandle, pCANMsg, ref retNum, AChn, ARxTx) == 0)
                {
                    for (int i = 0; i < retNum; i++)
                    {
                        ACANMsgBuffer[i] = new TLIBCANFD();
                        ACANMsgBuffer[i] = (TLIBCANFD)Marshal.PtrToStructure((IntPtr)(pCANMsg + Marshal.SizeOf(typeof(TLIBCANFD)) * i), typeof(TLIBCANFD));
                    }
                }
                else
                    retNum = 0;
                return retNum;
            }
            finally
            {
                Marshal.FreeHGlobal(pCANMsg);
            }
        }

        public static Boolean ReceiveLINMsg(IntPtr ADeviceHandle, out TLIBLIN ALINMsg, int ATimeoutMs, CHANNEL_INDEX AChn = CHANNEL_INDEX.CHN1, READ_TX_RX_DEF ATxRx = READ_TX_RX_DEF.ONLY_RX_MESSAGES)
        {
            IntPtr pMsg = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(TLIBLIN)));
            DateTime start = System.DateTime.Now;
            TimeSpan diff;
            Boolean ret = false;
            ALINMsg = new TLIBLIN();
            int bufferSize;
            try
            {
                do
                {
                    bufferSize = 1;
                    if (tsfifo_receive_lin_msgs(ADeviceHandle, pMsg, ref bufferSize, AChn, ATxRx) == 0 && (bufferSize > 0))
                    {
                        ALINMsg = (TLIBLIN)(Marshal.PtrToStructure(pMsg, typeof(TLIBLIN)));
                        ret = true;
                        break;
                    }
                    Thread.Sleep(1);
                    diff = System.DateTime.Now - start;
                } while (diff.TotalMilliseconds < (ATimeoutMs));
            }
            finally
            {
                Marshal.FreeHGlobal(pMsg);
            }
            return ret;
        }

        public static int ReceiveLINMsgList(IntPtr ADeviceHandle, ref TLIBLIN[] ALINMsgBuffer, int ALINBufferSize, CHANNEL_INDEX AChn = CHANNEL_INDEX.CHN1, READ_TX_RX_DEF ATxRx = READ_TX_RX_DEF.ONLY_RX_MESSAGES)
        {
            IntPtr pMsg = Marshal.AllocHGlobal((IntPtr)(Marshal.SizeOf(typeof(TLIBLIN)) * ALINBufferSize));
            DateTime start = System.DateTime.Now;
            int retNum = ALINBufferSize;
            try
            {
                if (tsfifo_receive_lin_msgs(ADeviceHandle, pMsg, ref retNum, AChn, ATxRx) == 0)
                {
                    for (int i = 0; i < retNum; i++)
                    {
                        ALINMsgBuffer[i] = new TLIBLIN();
                        ALINMsgBuffer[i] = (TLIBLIN)Marshal.PtrToStructure((IntPtr)(pMsg + Marshal.SizeOf(typeof(TLIBLIN)) * i), typeof(TLIBLIN));
                    }
                }
                else
                    retNum = 0;
                return retNum;
            }
            finally
            {
                Marshal.FreeHGlobal(pMsg);
            }
        }
        public static Boolean ReceiveFastLINMsg(IntPtr ADeviceHandle, out TLIBLIN ALINMsg, int ATimeoutMs, CHANNEL_INDEX AChn = CHANNEL_INDEX.CHN1, READ_TX_RX_DEF AOnlyRx = READ_TX_RX_DEF.ONLY_RX_MESSAGES)
        {
            IntPtr pMsg = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(TLIBLIN)));
            DateTime start = System.DateTime.Now;
            TimeSpan diff;
            Boolean ret = false;
            ALINMsg = new TLIBLIN();
            int bufferSize;
            try
            {
                do
                {
                    bufferSize = 1;
                    if ((tsfifo_receive_fastlin_msgs(ADeviceHandle, pMsg, ref bufferSize, AChn, AOnlyRx) == 0) && (bufferSize > 0))
                    {
                        ALINMsg = (TLIBLIN)(Marshal.PtrToStructure(pMsg, typeof(TLIBLIN)));
                        ret = true;
                        break;
                    }
                    Thread.Sleep(1);
                    diff = System.DateTime.Now - start;
                } while (diff.TotalMilliseconds < (ATimeoutMs));
            }
            finally
            {
                Marshal.FreeHGlobal(pMsg);
            }
            return ret;
        }

        public static int ReceiveFastLINMsgList(IntPtr ADeviceHandle, ref TLIBLIN[] ALINMsgBuffer, int ALINBufferSize, CHANNEL_INDEX AChn = CHANNEL_INDEX.CHN1, READ_TX_RX_DEF AOnlyRx = READ_TX_RX_DEF.ONLY_RX_MESSAGES)
        {
            IntPtr pMsg = Marshal.AllocHGlobal((IntPtr)(Marshal.SizeOf(typeof(TLIBLIN)) * ALINBufferSize));
            DateTime start = System.DateTime.Now;
            int retNum = ALINBufferSize;
            try
            {
                if (tsfifo_receive_fastlin_msgs(ADeviceHandle, pMsg, ref retNum, AChn, AOnlyRx) == 0)
                {
                    for (int i = 0; i < retNum; i++)
                    {
                        ALINMsgBuffer[i] = new TLIBLIN();
                        ALINMsgBuffer[i] = (TLIBLIN)Marshal.PtrToStructure((IntPtr)(pMsg + Marshal.SizeOf(typeof(TLIBLIN)) * i), typeof(TLIBLIN));
                    }
                }
                else
                    retNum = 0;
                return retNum;
            }
            finally
            {
                Marshal.FreeHGlobal(pMsg);
            }
        }

        //flexray
        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tsflexray_set_controller_frametrigger(IntPtr Handle, int ANodeIndex, ref TLibFlexray_controller_config AControllerConfig, int[] AFrameLengthArray, int AFrameNum, TLibTrigger_def[] AFrameTrigger, int AFrameTriggerNum, int ATimeoutMs);
        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tsflexray_start_net(IntPtr Handle, int channel, int ATimeoutMs);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tsflexray_stop_net(IntPtr Handle, int channel, int ATimeoutMs);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        internal static extern uint tsfifo_receive_flexray_msgs(IntPtr Handle, IntPtr FRbuffer, ref int size, byte chn, byte ARxTx);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tsflexray_transmit_sync(IntPtr Handle, ref TLIBFlexray frmsg, int ATimeoutMs);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tsflexray_transmit_async(IntPtr Handle, ref TLIBFlexray frmsg);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tsfifo_clear_flexray_receive_buffers(IntPtr Handle, int channel);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tsfifo_read_flexray_buffer_frame_count(IntPtr Handle, int channel, ref int ACount);
        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tsfifo_read_flexray_tx_buffer_frame_count(IntPtr Handle, int channel, ref int ACount);
        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tsfifo_read_flexray_rx_buffer_frame_count(IntPtr Handle, int channel, ref int ACount);
        public static TLIBFlexray[] ReceiveFRMsgList(IntPtr ADeviceHandle, ref int ACANBufferSize, byte AChn, byte ATxRx)
        {
            TLIBFlexray[] AFRMsgBuffer = new TLIBFlexray[ACANBufferSize];
            IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)(Marshal.SizeOf(typeof(TLIBFlexray)) * ACANBufferSize));
            DateTime now = DateTime.Now;
            //int ABufferSize = ACANBufferSize;
            try
            {
                tsfifo_receive_flexray_msgs(ADeviceHandle, intPtr, ref ACANBufferSize, AChn, ATxRx);
                for (int i = 0; i < ACANBufferSize; i++)
                {
                    AFRMsgBuffer[i] = default(TLIBFlexray);
                    AFRMsgBuffer[i] = (TLIBFlexray)Marshal.PtrToStructure(intPtr + Marshal.SizeOf(typeof(TLIBFlexray)) * i, typeof(TLIBFlexray));
                }

                return AFRMsgBuffer;
            }
            finally
            {
                Marshal.FreeHGlobal(intPtr);
            }
        }

        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tsflexray_register_event_flexray(IntPtr ADeviceHandle, TFlexrayQueueEvent_Win32 ACallback);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tsflexray_unregister_event_flexray(IntPtr ADeviceHandle, TFlexrayQueueEvent_Win32 ACallback);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tsflexray_register_pretx_event_flexray(IntPtr ADeviceHandle, TFlexrayQueueEvent_Win32 ACallback);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tsflexray_unregister_pretx_event_flexray(IntPtr ADeviceHandle, TFlexrayQueueEvent_Win32 ACallback);

        //LIN  schedule function
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tslin_active_frame_in_schedule_table(IntPtr ADeviceHandle, int channel,byte AID,int AIndex);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tslin_deactive_frame_in_schedule_table(IntPtr ADeviceHandle, int channel, byte AID, int AIndex);

        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tslin_batch_set_schedule_start(IntPtr ADeviceHandle, int channelidx);

        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tslin_batch_set_schedule_end(IntPtr ADeviceHandle, int channelidx);

        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tslin_batch_add_schedule_frame(IntPtr ADeviceHandle, int channelidx,ref TLIBLIN ALIN ,byte ADelayMs);

        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tslin_clear_schedule_tables(IntPtr ADeviceHandle, int channelidx);

        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tslin_start_lin_channel(IntPtr ADeviceHandle, int channelidx);


        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tslin_stop_lin_channel(IntPtr ADeviceHandle, int channelidx);

        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tslin_switch_idle_schedule_table(IntPtr ADeviceHandle, int channelidx);
        
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tslin_switch_normal_schedule_table(IntPtr ADeviceHandle, int channelidx,int ASchIndex);
        [DllImport(TSCANDLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 tslin_switch_runtime_schedule_table(IntPtr ADeviceHandle, int channelidx);

#endif
    }
}

