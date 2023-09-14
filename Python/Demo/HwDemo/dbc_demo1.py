'''
Author: seven 865762826@qq.com
Date: 2023-09-14 11:23:16
LastEditors: seven 865762826@qq.com
LastEditTime: 2023-09-14 11:33:47
FilePath: \TSMasterAPId:\IDE\libTSCANDemos\Python\Demo\HwDemo\dbc_demo1.py
Description: 这是默认设置,请设置`customMade`, 打开koroFileHeader查看配置 进行设置: https://github.com/OBKoro1/koro1FileHeader/wiki/%E9%85%8D%E7%BD%AE
'''

from libTSCANAPI import *
if __name__ == "__main__":
    configs = [{'FChannel': 0, 'rate_baudrate': 500, 'data_baudrate': 2000, 'enable_120hm': True, 'is_fd': True},
               {'FChannel': 1, 'rate_baudrate': 500, 'data_baudrate': 2000, 'enable_120hm': True, 'is_fd': True},
               {'FChannel': 2, 'rate_baudrate': 500, 'data_baudrate': 2000, 'enable_120hm': True, 'is_fd': True},
               {'FChannel': 3, 'rate_baudrate': 500, 'data_baudrate': 2000, 'enable_120hm': True, 'is_fd': True}]
    pathname = os.path.abspath(__file__)
    hwHandle = TSMasterDevice(configs=configs, hwserial=b'',
                              is_include_tx=False,
                              dbc=r'C:\Program Files (x86)\TOSUN\TSMaster\bin\Data\Demo\Databases\CAN_FD_Powertrain.dbc')
    ACAN1 = hwHandle.db.set_signal_value(AChannel = 0, msg= 0x701, signal_dict= {"FallbackMessage_Byte_06_10": 10000,'FallbackMessage_Byte_00_05': 12345})
    start_time = time.perf_counter()
    while time.perf_counter() - start_time < 2:
        hwHandle.send_msg(ACAN1)
        time.sleep(0.1)
        print(hwHandle.db.get_signal_value(hwHandle.recv(), None))
hwHandle.shut_down()



