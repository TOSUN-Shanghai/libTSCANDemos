/*
 * @Author: seven 865762826@qq.com
 * @Date: 2023-08-14 21:11:27
 * @LastEditors: seven 865762826@qq.com
 * @LastEditTime: 2023-08-25 00:31:48
 * @FilePath: /TSBUS_SocketTools/TSBUS/include/TSCAN.hpp
 * @Description: 这是默认设置,请设置`customMade`, 打开koroFileHeader查看配置 进行设置: https://github.com/OBKoro1/koro1FileHeader/wiki/%E9%85%8D%E7%BD%AE
 */
#pragma once
#include "TSCANDef.hpp"
#include "ASCWriteDef.hpp"

// 初始化调用 TC1018
// 连接 CAN 设备 


// const u8 DLC_DATA_BYTE_CNT[16] = {
//     0, 1, 2, 3, 4, 5, 6, 7,
//     8, 12, 16, 20, 24, 32, 48, 64
// };
u8 get_reallen(u8 len)
{
    u8 ret =0;
    for(ret =0;ret<16;ret++)
    {
        if(len == DLC_DATA_BYTE_CNT[ret])
            return ret;
    }
    return len;
}

u64 canHWHandle = 0;
s32 ini_canbus(size_t const HWHandle,const s32 canCountidx,map<uint64_t, vector<vector<signal_parse>>>& ChnList,const TCANFDQueueEvent_WHandle ACallback)
{
    
    TLibCANFD AMsg;
    memset(&AMsg,0,sizeof(TLibCANFD));
    AMsg.FIdxChn = canCountidx;
    tscan_config_canfd_by_baudrate(HWHandle,(APP_CHANNEL)canCountidx,500,2000,lfdtISOCAN,lfdmNormal,1);
    map<uint64_t,vector<vector<signal_parse>>>::iterator it = ChnList.begin();
    for (int idx=0;it != ChnList.end(); it++,idx++)
    {
        AMsg.FIdentifier = (it->first>>32)&0XFFFFFFFF;
        //FlexrayMsg = (((uint64_t)canid)<<32)+(((uint64_t)canlen)<<24)+((uint64_t)cycletime<<8)+((isfd<<2))+((isbrs<<1))+((isstd));
        s32 len = (it->first>>24)&0XFF;
        AMsg.FDLC = get_reallen(len);
        u8 isfd = (it->first>>2)&0X1;
        u8 isbrs = (it->first>>1)&0X1;
        u8 isstd = (it->first)&0X1;
        u16 Cycletime = (it->first>>8)&0XFFFF;
        AMsg.SetIsFD((isfd==1));
        AMsg.SetStd(isstd==1);
        AMsg.SetIsBRS(isbrs ==1);
        if(Cycletime!=0)
            tscan_add_cyclic_msg_canfd(HWHandle,&AMsg,(float)Cycletime);
        else
            tscan_transmit_canfd_async(HWHandle,&AMsg);
        
    }
    if(canHWHandle != HWHandle)
    {
        canHWHandle = HWHandle;
        tscan_register_pretx_event_canfd_whandle(HWHandle,ACallback);
        // tscan_register_event_canfd_whandle(HWHandle,oncan);
    } 
}
