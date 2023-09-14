using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace TSCANDLL_CSHARP
{
    // 定义存放数据和线程方法的类:
    public delegate void CyclicEventHandler(int AIntervalTime);
    /// <summary>
    /// 多线程回调函数
    /// </summary>
    public class ThreadProc
    {
        private Boolean terminateThread = false;
        private Boolean threadIsRunning = false;
        private int intervalTime = 10;
        private CyclicEventHandler cyclicFunction = null;
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        extern static int GetTickCount();

        public ThreadProc(int AMinIntervalMs)
        {
            if (AMinIntervalMs > 0)
            {
                intervalTime = AMinIntervalMs;
            }
        }
        public void ThreadMethod()
        {
            terminateThread = false;
            threadIsRunning = true;
            Stopwatch stopWatchObj = new Stopwatch();
            stopWatchObj.Start();
            while (terminateThread == false)
            {
                //Spin(stopWatchObj, intervalTime);
                if (cyclicFunction != null)
                {
                    cyclicFunction(intervalTime);
                }
            }
            stopWatchObj.Stop();

            threadIsRunning = false;
        }

        void Spin(Stopwatch w, int duration)
        {
            var current = w.ElapsedMilliseconds;
            while ((w.ElapsedMilliseconds - current) < duration)  
                Thread.SpinWait(1);
        }

        public void startThread(CyclicEventHandler ACyclicFunc)
        {
            if (threadIsRunning == false)
            {
                cyclicFunction = ACyclicFunc;
                Thread myThread = new Thread(ThreadMethod);   //ThreadStart 委托
                myThread.Start();
            }
        }

        public void stopThread()
        {
            terminateThread = true;
            while (threadIsRunning)
            {
                Thread.Sleep(10);
            }
        }
    }
}
