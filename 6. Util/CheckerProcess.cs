using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace IntelligentFactory
{
    public class CheckerProcess
    {
        /// <summary>
        /// 찾아야 할 캡션
        /// </summary>
        static string _requiredString;

        /// <summary>
        /// Contains signatures for C++ DLLs using interop.
        /// </summary>
        //internal static class NativeMethods
        public static class NativeMethods
        {
            /// <summary>
            /// 현재 실행중인 윈도우의 상태를 보여준다.
            /// </summary>
            /// <param name="hWnd"></param>
            /// <param name="nCmdShow"></param>
            /// <returns></returns>
            [DllImport("user32.dll")]
            public static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

            /// <summary>
            /// 선택한 윈도우를 뒤에 숨어있었으면 앞으로, 최소화상태였으면 원래상태로 되돌려놓으며 활성화시킨다.
            /// </summary>
            /// <param name="hWnd"></param>
            /// <returns></returns>
            [DllImport("user32.dll")]
            public static extern bool SetForegroundWindow(IntPtr hWnd);

            /// <summary>
            /// EnumWindows 함수는 모든 최상위 윈도우를 검색해서 그 핸들을 콜백함수로 전달하되
            /// 모든 윈도우를 다 찾거나 콜백함수가 FALSE를 리턴할 때까지 검색을 계속한다.
            /// 콜백함수는 검색된 윈도우의 핸들을 전달받으므로 모든 윈도우에 대해 모든 작업을 다 할 수 있다.
            /// EnumWindows 함수는 차일드 윈도우는 검색에서 제외된다.
            /// 단 시스템이 생성한 일부 최상위 윈도우는 WS_CHILD 스타일을 가지고 있더라도 예외적으로 검색에 포함된다.
            /// </summary>
            /// <param name="lpEnumFunc">EnumWindows의 실행 결과를 받아줄 콜백함수이다. EnumWindows는 이 함수 결과가 false가 될 때까지 계속 윈도우를 검색하게 된다.</param>
            /// <param name="lParam"></param>
            /// <returns></returns>
            [DllImport("user32.dll")]
            public static extern bool EnumWindows(EnumWindowsProcDel lpEnumFunc, Int32 lParam);

            /// <summary>
            /// HWND 값을 이용하여 프로세스 ID를 알려주는 함수이다.
            /// </summary>
            /// <param name="hWnd"></param>
            /// <param name="lpdwProcessId"></param>
            /// <returns></returns>
            [DllImport("user32.dll")]
            public static extern int GetWindowThreadProcessId(IntPtr hWnd, ref Int32 lpdwProcessId);

            /// <summary>
            /// 윈도우의 캡션을 가져온다.
            /// </summary>
            /// <param name="hWnd"></param>
            /// <param name="lpString"></param>
            /// <param name="nMaxCount"></param>
            /// <returns></returns>
            [DllImport("user32.dll")]
            public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, Int32 nMaxCount);

            /// <summary>
            /// 윈도우 해당 프로세스를 최상단에 위치하도록 하는 함수이다.
            /// </summary>
            /// <param name="hwnd"></param>
            /// <returns></returns>
            [DllImport("user32.dll")]
            public static extern int BringWindwToTop(IntPtr hwnd);

            /// <summary>
            /// 컨트롤 크기 및 위치, 표시 Level를 변경할때 사용하는 함수이다.
            /// </summary>
            /// <param name="hWnd"></param>
            /// <param name="hWndlnsertAfter"></param>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <param name="cx"></param>
            /// <param name="cy"></param>
            /// <param name="uFlags"></param>
            /// <returns></returns>
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndlnsertAfter, int x, int y, int cx, int cy, uint uFlags);

            /// <summary>
            /// 프로세스 화면을 최소화 여부를 확인 한다.
            /// </summary>
            /// <param name="hWnd"></param>
            /// <returns></returns>
            [DllImport("user32.dll")]
            public static extern bool IsIconic(IntPtr hWnd);

            /// <summary>
            /// 프로세스 화면을 최소화 한다.
            /// </summary>
            /// <param name="hWnd"></param>
            /// <param name="nCmdShow"></param>
            /// <returns></returns>
            [DllImport("user32.dll")]
            public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

            public const int SW_MINIMIZE = 6;
            public const int SW_RESTORE = 9;

            //윈도우의 상태를 normal로 하게 하는 상수
            public const int SW_SHOWNORMAL = 1;

            [DllImport("user32.dll")]
            private static extern IntPtr GetForegroundWindow();         // 최상위 윈도우 핸들 가져오기
        }

        /// <summary>
        /// EnumWindows의 실행 결과를 받아줄 콜백함수이다.
        /// EnumWindows는 이 함수 결과가 false가 될 때까지 계속 윈도우를 검색하게 된다.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public delegate bool EnumWindowsProcDel(IntPtr hWnd, Int32 lParam);

        /// <summary>
        /// Perform finding and showing of running window.
        /// 모든 실행중인 윈도우를 검색하며 찾고자 하는 캡션의 윈도우를 발견하면 활성화시킨다.
        /// </summary>
        /// <returns>Bool, which is important and must be kept to match up
        /// with system call.</returns>
        static private bool EnumWindowsProc(IntPtr hWnd, Int32 lParam)
        {
            int processId = 0;
            NativeMethods.GetWindowThreadProcessId(hWnd, ref processId);

            StringBuilder caption = new StringBuilder(1024);
            NativeMethods.GetWindowText(hWnd, caption, 1024); //방금 검색한 윈도우의 캡션을 가져온다.

            //찾을 윈도우명과 가져온 캡션이 일치한다면,
            if (processId == lParam && (caption.ToString().IndexOf(_requiredString, StringComparison.OrdinalIgnoreCase) != -1))
            {
                //윈도우를 normal 상태로 바꾸고 제일 앞으로 가져온다.
                NativeMethods.ShowWindowAsync(hWnd, NativeMethods.SW_SHOWNORMAL);
                NativeMethods.SetForegroundWindow(hWnd);
            }
            return true; //왜 계속 true만 반환해야 할까???
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="forceTitle">찾으려는 윈도우의 캡션, 즉 프로그램 타이틀</param>
        /// <returns>해당 캡션의 윈도우가 이미 실행중이라면 False,
        /// 처음 실행하는 것이라면 True를 반환한다.</returns>
        static public bool IsExecuteProcess(string strTitle, string strExeName)
        {
            _requiredString = strTitle;
            //먼저 실행파일의 이름으로 이름이 같은 프로세스를 검색해본다.
            foreach (Process proc in Process.GetProcessesByName(strExeName))
            {
                if (proc.Id != Process.GetCurrentProcess().Id)
                {
                    NativeMethods.EnumWindows(new EnumWindowsProcDel(EnumWindowsProc), proc.Id);

                    return false;
                }
            }

            return true;
        }
    }
}
