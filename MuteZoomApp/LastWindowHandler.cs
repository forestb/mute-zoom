using System;
using System.Diagnostics;

namespace MuteZoomApp
{
    public static class LastWindowHandler
    {
        public static void SetLastWindowActive()
        {
            IntPtr lastWindowHandle = WinApiWrapper.GetWindow(Process.GetCurrentProcess().MainWindowHandle, (uint)WinApiWrapper.GetWindow_Cmd.GW_HWNDNEXT);

            while (true)
            {
                IntPtr temp = WinApiWrapper.GetParent(lastWindowHandle);
                if (temp.Equals(IntPtr.Zero)) break;
                lastWindowHandle = temp;
            }
            ForceForegroundWindow(lastWindowHandle);
        }

        /// <summary>
        /// The system restricts which processes can set the foreground window. We needed to do something clever.
        /// </summary>
        /// <seealso cref="https://stackoverflow.com/questions/19136365/win32-setforegroundwindow-not-working-all-the-time"/>
        /// <seealso cref="https://pinvoke.net/default.aspx/user32.SetForegroundWindow"/>
        /// <param name="hWnd"></param>
        private static void ForceForegroundWindow(IntPtr hWnd)
        {
            uint foregroundThread = WinApiWrapper.GetWindowThreadProcessId(WinApiWrapper.GetForegroundWindow(), IntPtr.Zero);
            uint currentThread = WinApiWrapper.GetCurrentThreadId();

            const int SW_SHOW = 5;

            if (foregroundThread != currentThread)
            {
                WinApiWrapper.AttachThreadInput(foregroundThread, currentThread, true);
                WinApiWrapper.BringWindowToTop(hWnd);
                WinApiWrapper.ShowWindow(hWnd, SW_SHOW);
                WinApiWrapper.AttachThreadInput(foregroundThread, currentThread, false);
            }
            else
            {
                WinApiWrapper.BringWindowToTop(hWnd);
                WinApiWrapper.ShowWindow(hWnd, SW_SHOW);
            }
        }
    }
}
