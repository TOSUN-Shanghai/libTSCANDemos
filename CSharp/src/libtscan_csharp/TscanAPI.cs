using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace libtscan_csharp
{
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
        public TLibFlexray_controller_config(bool is_open_a, bool is_open_b, byte wakeup_chn, bool enable100_a, bool enable100_b, bool is_show_nullframe, bool connectaabb)
        {
            this.NETWORK_MANAGEMENT_VECTOR_LENGTH = 8;
            this.PAYLOAD_LENGTH_STATIC = 16;
            this.LATEST_TX = 124;
            this.T_S_S_TRANSMITTER = 9;
            this.CAS_RX_LOW_MAX = 87;
            this.SPEED = 0;
            this.WAKE_UP_SYMBOL_RX_WINDOW = 301;
            this.WAKE_UP_PATTERN = 43;
            this.WAKE_UP_SYMBOL_RX_IDLE = 59;
            this.WAKE_UP_SYMBOL_RX_LOW = 55;
            this.WAKE_UP_SYMBOL_TX_IDLE = 180;
            this.WAKE_UP_SYMBOL_TX_LOW = 60;
            this.channelAConnectedNode = (byte)(is_open_a ? 1 : 0);  // 是否启用通道A,0不启动，1启动
            this.channelBConnectedNode = (byte)(is_open_b ? 1 : 0);
            this.channelASymbolTransmitted = 1; // 是否启用通道A的符号传输功能,0不启动，1启动
            this.channelBSymbolTransmitted = 1; // 是否启用通道B的符号传输功能,0不启动，1启动
            this.ALLOW_HALT_DUE_TO_CLOCK = 1;
            this.SINGLE_SLOT_ENABLED = 0; // FALSE_0, TRUE_1
            this.wake_up_idx = wakeup_chn; // 唤醒通道选择， 0_通道A， 1 通道B
            this.ALLOW_PASSIVE_TO_ACTIVE = 2;
            this.COLD_START_ATTEMPTS = 10;
            this.synchFrameTransmitted = 1; // 本节点是否需要发送同步报文
            this.startupFrameTransmitted = 1;  // 本节点是否需要发送启动报文
            this.LISTEN_TIMEOUT = 401202;
            this.LISTEN_NOISE = 2; // 2_16
            this.MAX_WITHOUT_CLOCK_CORRECTION_PASSIVE = 10;
            this.MAX_WITHOUT_CLOCK_CORRECTION_FATAL = 14;
            this.MICRO_PER_CYCLE = 200000;
            this.Macro_Per_Cycle = 5000;
            this.SYNC_NODE_MAX = 8;
            this.MICRO_INITIAL_OFFSET_A = 31;
            this.MICRO_INITIAL_OFFSET_B = 31;
            this.MACRO_INITIAL_OFFSET_A = 11;
            this.MACRO_INITIAL_OFFSET_B = 11;
            this.N_I_T = 44;
            this.OFFSET_CORRECTION_START = 4981;
            this.DELAY_COMPENSATION_A = 1;
            this.DELAY_COMPENSATION_B = 1;
            this.CLUSTER_DRIFT_DAMPING = 2;
            this.DECODING_CORRECTION = 48;
            this.ACCEPTED_STARTUP_RANGE = 212;
            this.MAX_DRIFT = 601;
            this.STATIC_SLOT = 61;
            this.NUMBER_OF_STATIC_SLOTS = 60;
            this.MINISLOT = 10;
            this.NUMBER_OF_MINISLOTS = 129;
            this.DYNAMIC_SLOT_IDLE_PHASE = 0;
            this.ACTION_POINT_OFFSET = 9;
            this.MINISLOT_ACTION_POINT_OFFSET = 3;
            this.OFFSET_CORRECTION_OUT = 378;
            this.RATE_CORRECTION_OUT = 601;
            this.EXTERN_OFFSET_CORRECTION = 0;
            this.EXTERN_RATE_CORRECTION = 0;

            this.REVERS4 = 1;
            //this.config_byte = 0xC;
            this.REVERS0 = 0;
            this.REVERS1 = 0;
            this.REVERS2 = 0;
            this.REVERS3 = 0;
            this.FReserved = 0;
            this.config_byte = (byte)(connectaabb ? 0x3c : 0xc);
            this.config_byte = (byte)(config_byte | (enable100_a ? 0X1 : 0X0) | (enable100_b ? 0X2 : 0X0) | (is_show_nullframe ? 0X40 : 0X0));
        }
    }
    public enum READ_TX_RX_DEF : byte
    {
        ONLY_RX_MESSAGES,
        TX_RX_MESSAGES
    }
    public enum TLIBCANFDControllerType
    {
        lfdtCAN,
        lfdtISOCAN,
        lfdtNonISOCAN
    }
    public enum TLIBCANFDControllerMode
    {
        lfdmNormal,
        lfdmACKOff,
        lfdmRestricted
    }
    public enum LIN_PROTOCOL
    {
        LIN_PROTOCOL_13,
        LIN_PROTOCOL_20,
        LIN_PROTOCOL_21,
        LIN_PROTOCOL_J2602
    }
    public enum T_LIN_NODE_FUNCTION : byte
    {
        T_MASTER_NODE,
        T_SLAVE_NODE,
        T_MONITOR_NODE
    }
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
    public enum TSTATISTICTYPE
    {
        IDX_CAN_STAT_BUSLOAD,
        IDX_CAN_STAT_PEAKLOAD,
        IDX_CAN_STAT_STD_DATA_RATE,
        IDX_CAN_STAT_STD_DATA_ALL,
        IDX_CAN_STAT_EXT_DATA_RATE,
        IDX_CAN_STAT_EXT_DATA_ALL,
        IDX_CAN_STAT_STD_REMOTE_RATE,
        IDX_CAN_STAT_STD_REMOTE_ALL,
        IDX_CAN_STAT_EXT_REMOTE_RATE,
        IDX_CAN_STAT_EXT_REMOTE_ALL,
        IDX_CAN_STAT_ERR_FRAME_RATE,
        IDX_CAN_STAT_ERR_FRAME_ALL
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TLIBCAN
    {
        public byte FIdxChn;

        public byte FProperties;

        public byte FDLC;

        public byte FReserved;

        public int FIdentifier;

        public ulong FTimeUS;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] FData;

        public bool FIsTx
        {
            get
            {
                return (FProperties & 1) != 0;
            }
            set
            {
                if (value)
                {
                    FProperties |= 1;
                    return;
                }

                byte b = 1;
                FProperties &= (byte)(~b);
            }
        }

        public bool FIsLogged
        {
            get
            {
                return (FProperties & 0x40) != 0;
            }
            set
            {
                if (value)
                {
                    FProperties |= 64;
                    return;
                }

                byte b = 64;
                FProperties &= (byte)(~b);
            }
        }

        public bool FIsExt
        {
            get
            {
                return (FProperties & 4) != 0;
            }
            set
            {
                if (value)
                {
                    FProperties |= 4;
                    return;
                }

                byte b = 4;
                FProperties &= (byte)(~b);
            }
        }

        public bool FIsRemote
        {
            get
            {
                return (FProperties & 2) != 0;
            }
            set
            {
                if (value)
                {
                    FProperties |= 2;
                    return;
                }

                byte b = 2;
                FProperties &= (byte)(~b);
            }
        }

        public bool FIsError
        {
            get
            {
                return (FProperties & 0x80) != 0;
            }
            set
            {
                if (value)
                {
                    FProperties |= 128;
                    return;
                }

                byte b = 128;
                FProperties &= (byte)(~b);
            }
        }

        public string GetString()
        {
            string text = "Classic CAN:" + FTimeUS + ":";
            text = ((!FIsTx) ? (text + "Rx: ") : (text + "Tx: "));
            text = text + FIdentifier.ToString("X8") + " ";
            text = text + FDLC + " ";
            for (int i = 0; i < FDLC; i++)
            {
                text += FData[i].ToString("X2");
            }

            return text;
        }

        public TLIBCAN(CHANNEL_INDEX AIdxChn, int AID, bool AIsTx, bool AIsExt, bool AIsRemote, byte ADLC, byte[] ADataArray)
        {
            FIdxChn = (byte)AIdxChn;
            FProperties = 0;
            FIdentifier = AID;
            FDLC = ADLC;
            FTimeUS = 0uL;
            FData = new byte[8];
            int num = ADataArray.Count();
            if (num > 8)
            {
                num = 8;
            }

            for (int i = 0; i < num; i++)
            {
                FData[i] = ADataArray[i];
            }

            FReserved = 0;
            FIsTx = AIsTx;
            FIsError = false;
            FIsExt = AIsExt;
            FIsRemote = AIsRemote;
        }

        public TLIBCAN(CHANNEL_INDEX AIdxChn, int AID, bool AIsTx, bool AIsExt, bool AIsRemote, byte ADLC)
        {
            FIdxChn = (byte)AIdxChn;
            FIdentifier = AID;
            FProperties = 0;
            FDLC = ADLC;
            FTimeUS = 0uL;
            FData = new byte[8];
            FReserved = 0;
            FIsTx = AIsTx;
            FIsError = false;
            FIsExt = AIsExt;
            FIsRemote = AIsRemote;
        }
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TLIBCANFD
    {
        public byte FIdxChn;

        public byte FProperties;

        public byte FDLC;

        public byte FFDProperties;

        public int FIdentifier;

        public ulong FTimeUS;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] FData;

        public static readonly byte[] DLC_DATA_BYTE_CNT = new byte[16]
        {
            0, 1, 2, 3, 4, 5, 6, 7, 8, 12,
            16, 20, 24, 32, 48, 64
        };

        public bool FIsTx
        {
            get
            {
                return (FProperties & 1) != 0;
            }
            set
            {
                if (value)
                {
                    FProperties |= 1;
                    return;
                }

                byte b = 1;
                FProperties &= (byte)(~b);
            }
        }

        public bool FIsLogged
        {
            get
            {
                return (FProperties & 0x40) != 0;
            }
            set
            {
                if (value)
                {
                    FProperties |= 64;
                    return;
                }

                byte b = 64;
                FProperties &= (byte)(~b);
            }
        }

        public bool FIsExt
        {
            get
            {
                return (FProperties & 4) != 0;
            }
            set
            {
                if (value)
                {
                    FProperties |= 4;
                    return;
                }

                byte b = 4;
                FProperties &= (byte)(~b);
            }
        }

        public bool FIsRemote
        {
            get
            {
                return (FProperties & 2) != 0;
            }
            set
            {
                if (value)
                {
                    FProperties |= 2;
                    return;
                }

                byte b = 2;
                FProperties &= (byte)(~b);
            }
        }

        public bool FIsError
        {
            get
            {
                return (FProperties & 0x80) != 0;
            }
            set
            {
                if (value)
                {
                    FProperties |= 128;
                    return;
                }

                byte b = 128;
                FProperties &= (byte)(~b);
            }
        }

        public bool FIsFD
        {
            get
            {
                return (FFDProperties & 1) != 0;
            }
            set
            {
                if (value)
                {
                    FFDProperties |= 1;
                    return;
                }

                byte b = 1;
                FFDProperties &= (byte)(~b);
            }
        }

        public bool FIsBRS
        {
            get
            {
                return (FFDProperties & 2) != 0;
            }
            set
            {
                if (value)
                {
                    FFDProperties |= 2;
                    return;
                }

                byte b = 2;
                FFDProperties &= (byte)(~b);
            }
        }

        public bool FIsESI
        {
            get
            {
                return (FFDProperties & 4) != 0;
            }
            set
            {
                if (value)
                {
                    FFDProperties |= 4;
                    return;
                }

                byte b = 4;
                FFDProperties &= (byte)(~b);
            }
        }

        public string GetString()
        {
            string text = "";
            text = ((!FIsFD) ? ("Classic CAN:" + FTimeUS + ":") : ("FD CAN:" + FTimeUS + ":"));
            text = ((!FIsTx) ? (text + "Rx: ") : (text + "Tx: "));
            text = text + FIdentifier.ToString("X8") + " ";
            text = text + FDLC + " ";
            FDLC &= 15;
            byte[] array = new byte[16]
            {
                0, 1, 2, 3, 4, 5, 6, 7, 8, 12,
                16, 20, 24, 32, 48, 64
            };
            FDLC = array[FDLC];
            for (int i = 0; i < FDLC; i++)
            {
                text += FData[i].ToString("X2");
            }

            return text;
        }

        public void SetStdId(int AId, byte ADLC)
        {
            FIdentifier = AId;
            FDLC = ADLC;
            FProperties &= 251;
        }

        public void SetExtId(int AId, byte ADLC)
        {
            FIdentifier = AId;
            FDLC = ADLC;
            FProperties |= 4;
        }

        public TLIBCANFD(CHANNEL_INDEX AIdxChn, int AID, bool AIsTx, bool AIsExt, bool AIsRemote, byte ADLC, byte[] ADataArray)
        {
            FIdxChn = (byte)AIdxChn;
            FProperties = 0;
            FIdentifier = AID;
            FDLC = ADLC;
            FTimeUS = 0uL;
            FData = new byte[64];
            int num = ADataArray.Count();
            if (num > 64)
            {
                num = 64;
            }

            for (int i = 0; i < num; i++)
            {
                FData[i] = ADataArray[i];
            }

            FFDProperties = 0;
            FIsTx = AIsTx;
            FIsError = false;
            FIsExt = AIsExt;
            FIsRemote = AIsRemote;
        }

        public TLIBCANFD(CHANNEL_INDEX AIdxChn, int AID, bool AIsTx, bool AIsExt, bool AIsRemote, byte ADLC, bool AIsFD = false, bool AIsBRS = false)
        {
            FIdxChn = (byte)AIdxChn;
            FIdentifier = AID;
            FProperties = 0;
            FDLC = ADLC;
            FTimeUS = 0uL;
            FData = new byte[64];
            FFDProperties = 0;
            FIsTx = AIsTx;
            FIsError = false;
            FIsExt = AIsExt;
            FIsRemote = AIsRemote;
            FIsFD = AIsFD;
            FIsBRS = AIsBRS;
        }

        public TLIBCANFD(CHANNEL_INDEX AIdxChn, int AID, bool AIsTx, bool AIsExt, bool AIsRemote, byte ADLC, byte[] ADatas, bool AIsFD = false, bool AIsBRS = false)
        {
            FIdxChn = (byte)AIdxChn;
            FIdentifier = AID;
            FProperties = 0;
            FDLC = ADLC;
            FTimeUS = 0uL;
            FData = ADatas;
            FFDProperties = 0;
            FIsTx = AIsTx;
            FIsError = false;
            FIsExt = AIsExt;
            FIsRemote = AIsRemote;
            FIsFD = AIsFD;
            FIsBRS = AIsBRS;
        }

        private int GetDataLength()
        {
            if (FIsFD)
            {
                if (FDLC >= 16)
                {
                    FDLC = 15;
                }

                return DLC_DATA_BYTE_CNT[FDLC];
            }

            return FDLC;
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TLIBLIN
    {
        public byte FIdxChn;

        public byte FErrStatus;

        public byte FProperties;

        public byte FDLC;

        public byte FIdentifier;

        public byte FChecksum;

        public byte FStatus;

        public ulong FTimeUS;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] FData;

        public bool FIsTx
        {
            get
            {
                return (FProperties & 1) != 0;
            }
            set
            {
                if (value)
                {
                    FProperties |= 1;
                    return;
                }

                byte b = 1;
                FProperties &= (byte)(~b);
            }
        }

        public TLIBLIN(CHANNEL_INDEX AIdxChn, byte AID, byte ADLC, bool AIsTx, byte[] ADataArray)
        {
            FIdxChn = (byte)AIdxChn;
            FProperties = 0;
            FIdentifier = AID;
            FDLC = ADLC;
            FTimeUS = 0uL;
            FData = new byte[8];
            int num = ADataArray.Count();
            if (num > 8)
            {
                num = 8;
            }

            for (int i = 0; i < num; i++)
            {
                FData[i] = ADataArray[i];
            }

            FChecksum = 0;
            FStatus = 0;
            FErrStatus = 0;
            FIsTx = AIsTx;
        }

        public TLIBLIN(CHANNEL_INDEX AIdxChn, byte AID, byte ADLC, bool AIsTx)
        {
            FIdxChn = (byte)AIdxChn;
            FIdentifier = AID;
            FProperties = 0;
            FDLC = ADLC;
            FTimeUS = 0uL;
            FData = new byte[8];
            FChecksum = 0;
            FStatus = 0;
            FErrStatus = 0;
            FIsTx = AIsTx;
        }
    }

    public enum CAN_ISO_TP_RESAULT
    {
        N_OK = 0,
        IDX_ERR_TP_TIMEOUT_AS = 139,
        IDX_ERR_TP_TIMEOUT_AR = 140,
        IDX_ERR_TP_TIMEOUT_BS = 141,
        IDX_ERR_TP_TIMEOUT_CR = 142,
        IDX_ERR_TP_WRONG_SN = 143,
        IDX_ERR_TP_INVALID_FS = 144,
        IDX_ERR_TP_UNEXP_PDU = 145,
        IDX_ERR_TP_WFT_OVRN = 146,
        IDX_ERR_TP_BUFFER_OVFLW = 147,
        IDX_ERR_TP_NOT_IDLE = 148,
        IDX_ERR_TP_ERROR_FROM_CAN_DRIVER = 149
    }
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void TCANQueueEvent_Win32(ref TLIBCAN AData);
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void TCANFDQueueEvent_Win32(ref TLIBCANFD AData);
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void TLINQueueEvent_Win32(ref TLIBLIN AData);
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void TTSCANConnectedCallback_Win32(IntPtr ADevicehandle);
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void N_USData_TranslateCompleted_Recall(int ATpModuleIndex, int AChn, ulong ATimeStamp, IntPtr APayLoad, uint ASize, CAN_ISO_TP_RESAULT AError);
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
    public class TscanAPI
    {
        private const string TSCANDLL_NAME = ".\\libTSCAN.dll";

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern void initialize_lib_tscan(bool AEnableFIFO, bool AEnableErrorFrame, bool AEnableTurbe);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern void finalize_lib_tscan();

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tscan_scan_devices(ref uint ADeviceCount);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tscan_get_device_info(uint ADeviceIndex, ref IntPtr AFManufacturer, ref IntPtr AFProduct, ref IntPtr AFSerial);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern double tscan_get_bus_status(IntPtr ADeviceHandle, CHANNEL_INDEX AChnBase0, TSTATISTICTYPE AIndex);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern void tscan_set_auto_calc_bus_statistics(bool Value);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern void tscan_clear_can_bus_statistic();

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tscan_connect(string ADeviceSerial, ref IntPtr ADeviceHandle);
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

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tscan_disconnect_all_devices();

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tscan_disconnect_by_serial(string ADeviceSerial);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tscan_disconnect_by_handle(IntPtr ADeviceHandle);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tscan_get_error_description(uint ACode, IntPtr ADesc);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tscan_register_event_can(IntPtr ADeviceHandle, TCANQueueEvent_Win32 ACallback);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tscan_unregister_event_can(IntPtr ADeviceHandle, TCANQueueEvent_Win32 ACallback);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tscan_register_event_canfd(IntPtr ADeviceHandle, TCANFDQueueEvent_Win32 ACallback);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tscan_unregister_event_canfd(IntPtr ADeviceHandle, TCANFDQueueEvent_Win32 ACallback);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tslin_register_event_lin(IntPtr ADeviceHandle, TLINQueueEvent_Win32 ACallback);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tslin_unregister_event_lin(IntPtr ADeviceHandle, TLINQueueEvent_Win32 ACallback);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tscan_transmit_can_sync(IntPtr ADeviceHandle, ref TLIBCAN ACAN, uint ATimeoutMS);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tscan_transmit_can_async(IntPtr ADeviceHandle, ref TLIBCAN ACAN);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tscan_add_cyclic_msg_can(IntPtr ADeviceHandle, ref TLIBCAN ACAN, float APeriodMS);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tscan_delete_cyclic_msg_can(IntPtr ADeviceHandle, ref TLIBCAN ACAN);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        internal static extern uint tsfifo_receive_can_msgs(IntPtr ADeviceHandle, IntPtr ACANBuffer, ref int ABufferSize, CHANNEL_INDEX AChn, READ_TX_RX_DEF ATxRx);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tsfifo_clear_can_receive_buffers(IntPtr ADeviceHandle);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int tsfifo_read_can_buffer_frame_count(IntPtr ADeviceHandle, CHANNEL_INDEX AChannel, ref int ACount);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int tsfifo_read_can_tx_buffer_frame_count(IntPtr ADeviceHandle, CHANNEL_INDEX AChannel, ref int ACount);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int tsfifo_read_can_rx_buffer_frame_count(IntPtr ADeviceHandle, CHANNEL_INDEX AChannel, ref int ACount);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int tsfifo_read_canfd_buffer_frame_count(IntPtr ADeviceHandle, CHANNEL_INDEX AChannel, ref int ACount);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int tsfifo_read_canfd_tx_buffer_frame_count(IntPtr ADeviceHandle, CHANNEL_INDEX AChannel, ref int ACount);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int tsfifo_read_canfd_rx_buffer_frame_count(IntPtr ADeviceHandle, CHANNEL_INDEX AChannel, ref int ACount);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tsfifo_read_lin_buffer_datacount(IntPtr ADeviceHandle, CHANNEL_INDEX AChannel, ref int ACount);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tsfifo_read_lin_tx_buffer_frame_count(IntPtr ADeviceHandle, CHANNEL_INDEX AChannel, ref int ACount);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tsfifo_read_lin_rx_buffer_frame_count(IntPtr ADeviceHandle, CHANNEL_INDEX AChannel, ref int ACount);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tsfifo_read_fastlin_buffer_datacount(IntPtr ADeviceHandle, CHANNEL_INDEX AChannel, ref int ACount);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tsfifo_read_fastlin_tx_buffer_frame_count(IntPtr ADeviceHandle, CHANNEL_INDEX AChannel, ref int ACount);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tsfifo_read_fastlin_rx_buffer_frame_count(IntPtr ADeviceHandle, CHANNEL_INDEX AChannel, ref int ACount);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tscan_transmit_canfd_sync(IntPtr ADeviceHandle, ref TLIBCANFD ACANFD, uint ATimeoutMS);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tscan_transmit_canfd_async(IntPtr ADeviceHandle, ref TLIBCANFD ACANFD);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tscan_add_cyclic_msg_canfd(IntPtr ADeviceHandle, ref TLIBCANFD ACANFD, float APeriodMS);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tscan_delete_cyclic_msg_canfd(IntPtr ADeviceHandle, ref TLIBCANFD ACANFD);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        internal static extern uint tsfifo_receive_canfd_msgs(IntPtr ADeviceHandle, IntPtr ACANFDBuffers, ref int ACANFDBufferSize, CHANNEL_INDEX AChn, READ_TX_RX_DEF ATxRx);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tsfifo_clear_canfd_receive_buffers(IntPtr ADeviceHandle, CHANNEL_INDEX channel_index);


        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tsfifo_add_can_canfd_pass_filter(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIdx, int AIdentifier, bool AIsStd);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tsfifo_add_lin_pass_filter(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIdx, int AIdentifier);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tsfifo_delete_can_canfd_pass_filter(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIdx, int AIdentifier);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tsfifo_delete_lin_pass_filter(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIdx, int AIdentifier);


        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tscan_config_can_by_baudrate(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIdx, double ARateKbp, uint A120OhmConnected);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tscan_config_canfd_by_baudrate(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIdx, double AArbRateKbps, double ADataRateKbps, TLIBCANFDControllerType AControllerType, TLIBCANFDControllerMode AControllerMode, uint A120OhmConnected);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tslin_transmit_lin_sync(IntPtr ADeviceHandle, ref TLIBLIN ALIN, uint ATimeoutMS);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tslin_transmit_lin_async(IntPtr ADeviceHandle, ref TLIBLIN ALIN);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        internal static extern uint tsfifo_receive_lin_msgs(IntPtr ADeviceHandle, IntPtr ALINBuffer, ref int ABufferSize, CHANNEL_INDEX AChn, READ_TX_RX_DEF ATxRx);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tsfifo_clear_lin_receive_buffers(IntPtr ADeviceHandle, CHANNEL_INDEX AChn);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        internal static extern uint tsfifo_receive_fastlin_msgs(IntPtr ADeviceHandle, IntPtr AFastLINBuffer, ref int ABufferSize, CHANNEL_INDEX AChn, READ_TX_RX_DEF ATxRx);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tsfifo_clear_fastlin_receive_buffers(IntPtr ADeviceHandle, CHANNEL_INDEX AChn);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tscan_get_error_description(uint ACode, ref IntPtr ADesc);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tscan_register_event_connected(TTSCANConnectedCallback_Win32 ACallback);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tscan_register_event_disconnected(TTSCANConnectedCallback_Win32 ACallback);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tscan_unregister_event_connected(TTSCANConnectedCallback_Win32 ACallback);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tscan_unregister_event_disconnected(TTSCANConnectedCallback_Win32 ACallback);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int tsccp_apply_read_data_package(IntPtr ADeviceHandle, uint AMasterCRO, uint ASlaveDTO, int ATimeoutMS);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public unsafe static extern int tsccp_read_data_package(IntPtr ADeviceHandle, byte AChn, byte AIsStd, byte isFirstPackage, byte ACTRNum, uint AMasterCRO, uint ASlaveDTO, byte* pData, int dataCnt, int ATimeoutMS);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tslin_config_baudrate(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIdx, double ARateKbps, LIN_PROTOCOL AProtocol);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tslin_set_schedule_table(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIdx, byte ASchIndex);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tslin_stop_lin_channel(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIdx);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tslin_set_node_funtiontype(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIdx, T_LIN_NODE_FUNCTION AFunctionType);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public unsafe static extern uint tstp_lin_master_request(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIdx, byte ANAD, byte* AData, ushort ADataNum, uint ATimeoutMs);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tstp_lin_master_request_intervalms(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIdx, byte AData);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tslin_apply_download_new_ldf(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIdx);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tstp_lin_reset(IntPtr ADeviceHandle, uint AChnIdx);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint tstp_lin_slave_response_intervalms(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIdx, byte AData);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public unsafe static extern int tsdiag_lin_read_data_by_identifier(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIdx, byte ANAD, ushort AId, byte* AResNAD, byte* AResData, int* AResDataNum, uint ATimeoutMS);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public unsafe static extern int tsdiag_lin_write_data_by_identifier(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIdx, byte ANAD, ushort AId, byte* AReqData, int AReqDataNum, byte* AResNAD, byte* AResData, int* AResDataNum, uint ATimeoutMS);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int tsdiag_lin_session_control(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIdx, byte ANAD, byte ASession, uint ATimeoutMS);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public unsafe static extern int tsdiag_lin_fault_memory_read(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIdx, byte ANAD, ushort data_length, byte* AData, uint ATimeoutMS);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public unsafe static extern int tsdiag_lin_fault_memory_clear(IntPtr ADeviceHandle, CHANNEL_INDEX AChnIdx, byte ANAD, ushort data_length, byte* AData, uint ATimeoutMS);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int tsdiag_can_create(ref int pDiagModuleIndex, CHANNEL_INDEX AChnIndex, byte ASupportFDCAN, byte AMaxDLC, uint ARequestID, bool ARequestIDIsStd, uint AResponseID, bool AResponseIDIsStd, uint AFunctionID, bool AFunctionIDIsStd);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int tsdiag_can_delete(int ADiagModuleIndex);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern void tsdiag_can_delete_all();

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int tsdiag_can_attach_to_tscan_tool(int ADiagModuleIndex, IntPtr ACANToolHandle);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int tstp_can_register_tx_completed_recall(int ADiagModuleIndex, N_USData_TranslateCompleted_Recall ATxcompleted);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int tstp_can_register_rx_completed_recall(int ADiagModuleIndex, N_USData_TranslateCompleted_Recall ARxcompleted);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public unsafe static extern int tstp_can_send_functional(int ADiagModuleIndex, byte* AReqDataArray, int AReqDataSize);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public unsafe static extern int tstp_can_send_request(int ADiagModuleIndex, byte* AReqDataArray, int AReqDataSize);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public unsafe static extern int tstp_can_request_and_get_response(int ADiagModuleIndex, byte* AReqDataArray, int AReqDataSize, byte* AResponseDataArray, ref int AResponseDataSize);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int tsdiag_can_session_control(int ADiagModuleIndex, byte ASubSession);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int tsdiag_can_routine_control(int ADiagModuleIndex, byte ARoutineControlType, ushort ARoutintID);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int tsdiag_can_communication_control(int ADiagModuleIndex, byte AControlType);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public unsafe static extern int tsdiag_can_security_access_request_seed(int ADiagModuleIndex, int ALevel, byte* ARecSeed, ref int ARecSeedSize);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public unsafe static extern int tsdiag_can_security_access_send_key(int ADiagModuleIndex, int ALevel, byte* AKeyValue, int AKeySize);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int tsdiag_can_request_download(int ADiagModuleIndex, uint AMemAddr, uint AMemSize);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int tsdiag_can_request_upload(int ADiagModuleIndex, uint AMemAddr, uint AMemSize);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public unsafe static extern int tsdiag_can_transfer_data(int ADiagModuleIndex, byte* ASourceDatas, int ADataSize, int AReqCase);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int tsdiag_can_request_transfer_exit(int ADiagModuleIndex);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public unsafe static extern int tsdiag_can_write_data_by_identifier(int ADiagModuleIndex, ushort ADataIdentifier, byte* AWriteData, int AWriteDataSize);

        [DllImport(TSCANDLL_NAME, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public unsafe static extern int tsdiag_can_read_data_by_identifier(int ADiagModuleIndex, ushort ADataIdentifier, byte* AReturnArray, ref int AReturnArraySize);

        public unsafe static int tsdiag_can_security_access_request_seed_dontnet(int ADiagModuleIndex, int ALevel, ref uint ARecSeed)
        {
            int ARecSeedSize = 4;
            uint num = 0u;
            byte* aRecSeed = (byte*)(&num);
            int result = tsdiag_can_security_access_request_seed(ADiagModuleIndex, ALevel, aRecSeed, ref ARecSeedSize);
            ARecSeed = num;
            return result;
        }

        public unsafe static int tsdiag_can_security_access_send_key_dontnet(int ADiagModuleIndex, int ALevel, uint AKeyValue)
        {
            byte* aKeyValue = (byte*)(&AKeyValue);
            return tsdiag_can_security_access_send_key(ADiagModuleIndex, ALevel, aKeyValue, 4);
        }

        public static uint GetDeviceInfo(uint ADeviceIndex, ref string AFManufacturer, ref string AFProduct, ref string AFSerial)
        {
            IntPtr AFManufacturer2 = (IntPtr)0;
            IntPtr AFProduct2 = (IntPtr)0;
            IntPtr AFSerial2 = (IntPtr)0;
            uint num = tscan_get_device_info(ADeviceIndex, ref AFManufacturer2, ref AFProduct2, ref AFSerial2);
            if (num == 0)
            {
                AFManufacturer = Marshal.PtrToStringAnsi(AFManufacturer2);
                AFProduct = Marshal.PtrToStringAnsi(AFProduct2);
                AFSerial = Marshal.PtrToStringAnsi(AFSerial2);
            }

            return num;
        }

        public static string TSCAN_GetTSCANErrorDescription(uint ACode)
        {
            IntPtr ADesc = (IntPtr)0;
            if (tscan_get_error_description(ACode, ref ADesc) != 0)
            {
                return "";
            }

            return Marshal.PtrToStringAnsi(ADesc);
        }

        public static bool ReceiveCANMsg(IntPtr ADeviceHandle, out TLIBCAN ACANMsg, int ATimeoutMs, CHANNEL_INDEX AChn = CHANNEL_INDEX.CHN1, READ_TX_RX_DEF AOnlyRx = READ_TX_RX_DEF.ONLY_RX_MESSAGES)
        {
            IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(TLIBCAN)));
            DateTime now = DateTime.Now;
            bool result = false;
            ACANMsg = default(TLIBCAN);
            try
            {
                do
                {
                    int ABufferSize = 1;
                    if (tsfifo_receive_can_msgs(ADeviceHandle, intPtr, ref ABufferSize, AChn, AOnlyRx) == 0 && ABufferSize > 0)
                    {
                        ACANMsg = (TLIBCAN)Marshal.PtrToStructure(intPtr, typeof(TLIBCAN));
                        result = true;
                        break;
                    }

                    Thread.Sleep(1);
                }
                while ((DateTime.Now - now).TotalMilliseconds < (double)ATimeoutMs);
            }
            finally
            {
                Marshal.FreeHGlobal(intPtr);
            }

            return result;
        }

        public static int ReceiveCANMsgList(IntPtr ADeviceHandle, ref TLIBCAN[] ACANMsgBuffer, int ACANBufferSize, CHANNEL_INDEX AChn = CHANNEL_INDEX.CHN1, READ_TX_RX_DEF ATxRx = READ_TX_RX_DEF.ONLY_RX_MESSAGES)
        {
            IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)(Marshal.SizeOf(typeof(TLIBCAN)) * ACANBufferSize));
            DateTime now = DateTime.Now;
            int ABufferSize = ACANBufferSize;
            try
            {
                tsfifo_receive_can_msgs(ADeviceHandle, intPtr, ref ABufferSize, AChn, ATxRx);
                for (int i = 0; i < ABufferSize; i++)
                {
                    ACANMsgBuffer[i] = default(TLIBCAN);
                    ACANMsgBuffer[i] = (TLIBCAN)Marshal.PtrToStructure(intPtr + Marshal.SizeOf(typeof(TLIBCAN)) * i, typeof(TLIBCAN));
                }

                return ABufferSize;
            }
            finally
            {
                Marshal.FreeHGlobal(intPtr);
            }
        }

        public static bool ReceiveCANFDMsg(IntPtr ADeviceHandle, out TLIBCANFD ACANMsg, int ATimeoutMs, CHANNEL_INDEX AChn = CHANNEL_INDEX.CHN1, READ_TX_RX_DEF ARxTx = READ_TX_RX_DEF.ONLY_RX_MESSAGES)
        {
            IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(TLIBCANFD)));
            DateTime now = DateTime.Now;
            bool result = false;
            ACANMsg = default(TLIBCANFD);
            try
            {
                do
                {
                    int ACANFDBufferSize = 1;
                    if (tsfifo_receive_canfd_msgs(ADeviceHandle, intPtr, ref ACANFDBufferSize, AChn, ARxTx) == 0 && ACANFDBufferSize > 0)
                    {
                        ACANMsg = (TLIBCANFD)Marshal.PtrToStructure(intPtr, typeof(TLIBCANFD));
                        result = true;
                        break;
                    }

                    Thread.Sleep(1);
                }
                while ((DateTime.Now - now).TotalMilliseconds < (double)ATimeoutMs);
            }
            finally
            {
                Marshal.FreeHGlobal(intPtr);
            }

            return result;
        }

        public static TLIBCANFD[] ReceiveCANFDMsgList(IntPtr ADeviceHandle, int ACANBufferSize, CHANNEL_INDEX AChn = CHANNEL_INDEX.CHN1, READ_TX_RX_DEF ARxTx = READ_TX_RX_DEF.ONLY_RX_MESSAGES)
        {
            TLIBCANFD[] ACANMsgBuffer = new TLIBCANFD[ACANBufferSize];
            IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)(Marshal.SizeOf(typeof(TLIBCANFD)) * ACANBufferSize));
            DateTime now = DateTime.Now;
            int ACANFDBufferSize = ACANBufferSize;
            try
            {
                if (tsfifo_receive_canfd_msgs(ADeviceHandle, intPtr, ref ACANFDBufferSize, AChn, ARxTx) == 0)
                {
                    for (int i = 0; i < ACANFDBufferSize; i++)
                    {
                        ACANMsgBuffer[i] = default(TLIBCANFD);
                        ACANMsgBuffer[i] = (TLIBCANFD)Marshal.PtrToStructure(intPtr + Marshal.SizeOf(typeof(TLIBCANFD)) * i, typeof(TLIBCANFD));
                    }
                }
                else
                {
                    ACANFDBufferSize = 0;
                }

                return ACANMsgBuffer;
            }
            finally
            {
                Marshal.FreeHGlobal(intPtr);
            }
        }

        public static bool ReceiveLINMsg(IntPtr ADeviceHandle, out TLIBLIN ALINMsg, int ATimeoutMs, CHANNEL_INDEX AChn = CHANNEL_INDEX.CHN1, READ_TX_RX_DEF ATxRx = READ_TX_RX_DEF.ONLY_RX_MESSAGES)
        {
            IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(TLIBLIN)));
            DateTime now = DateTime.Now;
            bool result = false;
            ALINMsg = default(TLIBLIN);
            try
            {
                do
                {
                    int ABufferSize = 1;
                    if (tsfifo_receive_lin_msgs(ADeviceHandle, intPtr, ref ABufferSize, AChn, ATxRx) == 0 && ABufferSize > 0)
                    {
                        ALINMsg = (TLIBLIN)Marshal.PtrToStructure(intPtr, typeof(TLIBLIN));
                        result = true;
                        break;
                    }

                    Thread.Sleep(1);
                }
                while ((DateTime.Now - now).TotalMilliseconds < (double)ATimeoutMs);
            }
            finally
            {
                Marshal.FreeHGlobal(intPtr);
            }

            return result;
        }

        public static int ReceiveLINMsgList(IntPtr ADeviceHandle, ref TLIBLIN[] ALINMsgBuffer, int ALINBufferSize, CHANNEL_INDEX AChn = CHANNEL_INDEX.CHN1, READ_TX_RX_DEF ATxRx = READ_TX_RX_DEF.ONLY_RX_MESSAGES)
        {
            IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)(Marshal.SizeOf(typeof(TLIBLIN)) * ALINBufferSize));
            DateTime now = DateTime.Now;
            int ABufferSize = ALINBufferSize;
            try
            {
                if (tsfifo_receive_lin_msgs(ADeviceHandle, intPtr, ref ABufferSize, AChn, ATxRx) == 0)
                {
                    for (int i = 0; i < ABufferSize; i++)
                    {
                        ALINMsgBuffer[i] = default(TLIBLIN);
                        ALINMsgBuffer[i] = (TLIBLIN)Marshal.PtrToStructure(intPtr + Marshal.SizeOf(typeof(TLIBLIN)) * i, typeof(TLIBLIN));
                    }
                }
                else
                {
                    ABufferSize = 0;
                }

                return ABufferSize;
            }
            finally
            {
                Marshal.FreeHGlobal(intPtr);
            }
        }
        public static TLibTrigger_def[] create_TLibTrigger_def(UInt16[] data, byte[] frameid, byte[] cyclic, byte[] config)
        {
            TLibTrigger_def[] ret = new TLibTrigger_def[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                ret[i] = new TLibTrigger_def(data[i], frameid[i], cyclic[i], config[i]);
            }
            return ret;
        }
        public static bool ReceiveFastLINMsg(IntPtr ADeviceHandle, out TLIBLIN ALINMsg, int ATimeoutMs, CHANNEL_INDEX AChn = CHANNEL_INDEX.CHN1, READ_TX_RX_DEF AOnlyRx = READ_TX_RX_DEF.ONLY_RX_MESSAGES)
        {
            IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(TLIBLIN)));
            DateTime now = DateTime.Now;
            bool result = false;
            ALINMsg = default(TLIBLIN);
            try
            {
                do
                {
                    int ABufferSize = 1;
                    if (tsfifo_receive_fastlin_msgs(ADeviceHandle, intPtr, ref ABufferSize, AChn, AOnlyRx) == 0 && ABufferSize > 0)
                    {
                        ALINMsg = (TLIBLIN)Marshal.PtrToStructure(intPtr, typeof(TLIBLIN));
                        result = true;
                        break;
                    }

                    Thread.Sleep(1);
                }
                while ((DateTime.Now - now).TotalMilliseconds < (double)ATimeoutMs);
            }
            finally
            {
                Marshal.FreeHGlobal(intPtr);
            }

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ADeviceHandle"> 句柄</param>
        /// <param name="ACANBufferSize"> 接收的数据大小</param>
        /// <param name="AChn">通道</param>
        /// <param name="ATxRx">是否包含TX报文</param>
        /// <returns></returns>
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

        public static int ReceiveFastLINMsgList(IntPtr ADeviceHandle, ref TLIBLIN[] ALINMsgBuffer, int ALINBufferSize, CHANNEL_INDEX AChn = CHANNEL_INDEX.CHN1, READ_TX_RX_DEF AOnlyRx = READ_TX_RX_DEF.ONLY_RX_MESSAGES)
        {
            IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)(Marshal.SizeOf(typeof(TLIBLIN)) * ALINBufferSize));
            DateTime now = DateTime.Now;
            int ABufferSize = ALINBufferSize;
            try
            {
                if (tsfifo_receive_fastlin_msgs(ADeviceHandle, intPtr, ref ABufferSize, AChn, AOnlyRx) == 0)
                {
                    for (int i = 0; i < ABufferSize; i++)
                    {
                        ALINMsgBuffer[i] = default(TLIBLIN);
                        ALINMsgBuffer[i] = (TLIBLIN)Marshal.PtrToStructure(intPtr + Marshal.SizeOf(typeof(TLIBLIN)) * i, typeof(TLIBLIN));
                    }
                }
                else
                {
                    ABufferSize = 0;
                }

                return ABufferSize;
            }
            finally
            {
                Marshal.FreeHGlobal(intPtr);
            }
        }

        private static Flexray_uds flexray_uds_data = new Flexray_uds();
        private static TLIBFlexray req_flexray_msg ;
        private static bool exist_flexray_uds_module = false;
        private static IntPtr flexray_handle;
        public static void create_flexray_uds_module(IntPtr handle,Flexray_uds flexray_Uds)
        {
            flexray_handle = handle;
            flexray_uds_data = flexray_Uds;
            byte[] buf = { (byte)((flexray_uds_data.srcID >> 8) & 0xff), (byte)(flexray_uds_data.srcID & 0xff), (byte)((flexray_uds_data.dstID >> 8) & 0xff), (byte)(flexray_uds_data.dstID & 0xff),0x40 };
            req_flexray_msg = new TLIBFlexray(flexray_uds_data.FIdxChn, flexray_uds_data.FChannelMask, flexray_uds_data.FActualPayloadLength, flexray_uds_data.FReq_CycleNumber, flexray_uds_data.FReq_SlotId, buf);
            exist_flexray_uds_module = true;
        }
        public static bool exist_flexray()
        {
            return exist_flexray_uds_module;
        }
        public static uint tsdiag_flexray_request_and_get_respond(byte[]data,ref byte[]resdata)
        {
            if (exist_flexray_uds_module)
            {
                if (data.Length > (flexray_uds_data.FActualPayloadLength - 8))
                    return 233;//data size is too len

                req_flexray_msg.FData[5] = (byte)data.Length;
                req_flexray_msg.FData[6] = 0;
                req_flexray_msg.FData[7] = (byte)data.Length;
                for (int i = 0; i < data.Length; i++)
                {
                    req_flexray_msg.FData[i+8] = data[i];
                }
                tsfifo_clear_flexray_receive_buffers(flexray_handle, flexray_uds_data.FIdxChn);
                uint ret = tsflexray_transmit_async(flexray_handle, ref req_flexray_msg);
                if (ret != 0)
                { 
                    //resdata = new byte[0];
                    return ret;
                }
                DateTime now = DateTime.Now;
                double time_out_s = 0;
                TimeSpan timeSpan= TimeSpan.Zero;
                while (time_out_s < flexray_uds_data.timeout)
                {
                    timeSpan = DateTime.Now - now;
                    time_out_s = timeSpan.Minutes * 60 * 1000 + timeSpan.Seconds * 1000 + timeSpan.Milliseconds;
                    int ACANBufferSize = 100;
                    TLIBFlexray[] res_msg = ReceiveFRMsgList(flexray_handle, ref ACANBufferSize, flexray_uds_data.FIdxChn, 0);
                    for (int i = 0; i < ACANBufferSize; i++)
                        if (res_msg[i].FSlotId == flexray_uds_data.FRes_SlotId && (res_msg[i].FCycleNumber % flexray_uds_data.FRes_rep_CycleNumber == flexray_uds_data.FRes_base_CycleNumber))
                        {
                            resdata = res_msg[i].FData;
                            return 0;
                        }
                }

            }
            return 232;//flexray not create 
            
        }
        public static void delete_flexray_uds_module()
        {
            //flexray_uds_data = null;
            exist_flexray_uds_module = false;
        }
    }
    public struct Flexray_uds
    {
        public ushort srcID;
        public ushort dstID;
        public byte FIdxChn;
        public byte FChannelMask;
        public byte FActualPayloadLength;
        public UInt16 FReq_SlotId;
        public byte FReq_CycleNumber;
        public UInt16 FRes_SlotId;
        public byte FRes_base_CycleNumber;
        public byte FRes_rep_CycleNumber;
        public int timeout;
        public Flexray_uds(ushort srcID, ushort dstID, byte FIdxChn, byte FChannelMask, byte FActualPayloadLength, UInt16 FReq_SlotId, byte FReq_CycleNumber, UInt16 FRes_SlotId, byte FRes_base_CycleNumber,byte Fres_rep_cycleNumber, int timeout)
        {
            this.srcID = srcID;
            this.dstID = dstID;
            this.FIdxChn= FIdxChn;
            this.FChannelMask = FChannelMask;
            this.FActualPayloadLength = FActualPayloadLength;
            this.FReq_SlotId= FReq_SlotId;
            this.FReq_CycleNumber= FReq_CycleNumber;
            this.FRes_SlotId = FRes_SlotId;
            this.FRes_base_CycleNumber = FRes_base_CycleNumber;
            this.timeout = timeout;
            this.FRes_rep_CycleNumber = Fres_rep_cycleNumber;
        }
    }
}

