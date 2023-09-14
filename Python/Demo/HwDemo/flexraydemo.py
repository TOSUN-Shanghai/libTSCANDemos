from typing import Type

from libTSCANAPI import *

chn0 = 0
chn1 = 1
handle = c_size_t(0)
initialize_lib_tscan(True, True,False)
ret = tsapp_connect(b"", handle)
print(ret)
fr_config = TLibFlexray_controller_config(is_open_a=True, is_open_b=True, enable100_b=True, is_show_nullframe=False,
                                          is_Bridging=True)

fr_trigger = (TLibTrigger_def * 3)()
'''(1,0,1)'''
fr_trigger[0].frame_idx = 0
fr_trigger[0].slot_id = 1
fr_trigger[0].cycle_code = 1
fr_trigger[0].config_byte = 0x33
fr_trigger[0].recv = 0
'''(3,0,4)'''
fr_trigger[1].frame_idx = 0
fr_trigger[1].slot_id = 3
fr_trigger[1].cycle_code = 4
fr_trigger[1].config_byte = 0x23
fr_trigger[1].recv = 0
'''(3,3,4)'''
fr_trigger[2].frame_idx = 0
fr_trigger[2].slot_id = 3
fr_trigger[2].cycle_code = 7
fr_trigger[2].config_byte = 0x23
fr_trigger[2].recv = 0

fr_trigger1 = (TLibTrigger_def * 2)()
'''(2,0,4)'''
fr_trigger1[0].frame_idx = 0
fr_trigger1[0].slot_id = 2
fr_trigger1[0].cycle_code = 4
fr_trigger1[0].config_byte = 0x33
fr_trigger1[0].recv = 0
'''(4,0,4)'''
fr_trigger1[1].frame_idx = 1
fr_trigger1[1].slot_id = 4
fr_trigger1[1].cycle_code = 4
fr_trigger1[1].config_byte = 0x33
fr_trigger1[1].recv = 0

FrameLengthArray = (c_int * 3)(32, 32, 32)

ret = tsflexray_set_controller_frametrigger(handle, chn0, fr_config, FrameLengthArray, 3, fr_trigger, 3, 1000)

ret = tsflexray_set_controller_frametrigger(handle, chn1, fr_config, FrameLengthArray, 3, fr_trigger1, 2, 1000)
print(ret)
tsflexray_start_net(handle, chn0, 1000)
tsflexray_start_net(handle, chn1, 1000)

print("rx ")

time.sleep(2)

# tsfifo_clear_flexray_receive_buffers(handle, 0)
time.sleep(1)


def recv():
    flexrat_2 = (TLIBFlexray * 100)()
    size = c_int(100)
    tsfifo_receive_flexray_msgs(handle, flexrat_2, size, 0, 1)
    for i in flexrat_2:
        string = ''
        for index in range(i.FActualPayloadLength):
            string += hex(i.FData[index]) + ' '
        print(i.FTimeUs, ' ', i.FSlotId, ' ', i.FCycleNumber, ' ', ('tx' if i.FDir else 'rx'), "  ", string)


while 1:
    key = input()
    if key == 'q':
        break
    elif key == '1':
        recv()
    elif key == '2':
        flexray_1 = TLIBFlexray(FSlotId=3, FCycleNumber=4, FData=[1, 2, 3, 4, 5, 6, 7])
        ret =  tsapp_transmit_flexray_async(handle, flexray_1)
        print(ret)
tsflexray_stop_net(handle, chn0, 1000)
tsflexray_stop_net(handle, chn1, 1000)

tsapp_disconnect_all()
time.sleep(1)
