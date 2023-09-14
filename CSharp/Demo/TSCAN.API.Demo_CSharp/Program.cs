using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TSCANDLL_CSHARP
{
    static class Program
    {
        public static frmTSCANDemo mainFormObj;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainFormObj = new frmTSCANDemo();
            Application.Run(mainFormObj);
        }
    }
}
