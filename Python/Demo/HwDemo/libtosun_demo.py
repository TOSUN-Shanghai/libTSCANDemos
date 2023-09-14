'''
Author: seven 865762826@qq.com
Date: 2023-09-14 11:23:16
LastEditors: seven 865762826@qq.com
LastEditTime: 2023-09-14 11:30:47
FilePath: \TSMasterAPId:\IDE\libTSCANDemos\Python\Demo\HwDemo\libtosun_demo.py
Description: 这是默认设置,请设置`customMade`, 打开koroFileHeader查看配置 进行设置: https://github.com/OBKoro1/koro1FileHeader/wiki/%E9%85%8D%E7%BD%AE
'''
from libTSCANAPI import *

configs = [{'FChannel': 0, 'rate_baudrate': 500, 'data_baudrate': 2000, 'enable_120hm': True, 'is_fd': True},
           {'FChannel': 1, 'rate_baudrate': 500, 'data_baudrate': 2000, 'enable_120hm': True, 'is_fd': True},
           {'FChannel': 2, 'rate_baudrate': 500, 'data_baudrate': 2000, 'enable_120hm': True, 'is_fd': True},
           {'FChannel': 3, 'rate_baudrate': 500, 'data_baudrate': 2000, 'enable_120hm': True, 'is_fd': True}]

hwhandle = TSMasterDevice(configs=configs, is_include_tx=True, hwserial=b"")

msg = TLIBCAN(FIdxChn=3, FDLC=8, FIdentifier=0X1, FProperties=1, FData=[1, 2, 3, 4, 5, 6, 7, 8])

hwhandle.send_msg(msg)

pDiagModuleIndex = u8(0)  # 为c类型 传入的为指针，可以随意赋值，运行下方函数后，会对其赋值

hwhandle.tsdiag_can_create(pDiagModuleIndex, 3, 0, 8, 0x123, True, 0X456, True, 0X789, True)

# r 为函数执行返回值，为0表示执行成功
# 非0 可以使用 hwhandle.tscan_get_error_description(r)获取错误信息
sendData = (u8*2)(0x10,0x02)

r, respond_data = hwhandle.tstp_can_request_and_get_response(pDiagModuleIndex, sendData)

print(list(respond_data))

hwhandle.shut_down()

