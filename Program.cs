using System;
using System.Threading;
using System.Windows.Forms;

namespace IntelligentFactory
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Mutex mutex = new Mutex(true, "IntelligentVision", out bool bNew);
            if (true)//if (bNew)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                //FormMenu_Main FrmMain = new FormMenu_Main();
                Global iglobal = new Global();
                Application.Run(iglobal.FrmMain);

                mutex.ReleaseMutex();
            }
            else
            {
                IF_Util.ShowMessageBox("Program Already Running", "Check Job Process");

                Application.Exit();
            }
        }
    }
}