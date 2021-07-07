using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;

namespace MuteZoomApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string ZOOM_MEETING_WINDOW_TITLE = "Zoom Meeting";

            Console.WriteLine("Hello World!");

            foreach (KeyValuePair<IntPtr, string> window in OpenWindowGetter.GetOpenWindows())
            {
                IntPtr handle = window.Key;
                string title = window.Value;

                if (title.ToLower().Contains(ZOOM_MEETING_WINDOW_TITLE.ToLower()))
                {
                    FocusOnZoomWindow(handle);

                    SendToggleMuteKeyboardShortcut();
                }
            }
        }

        /// <summary>
        /// Before sending inputs, you must bring the Window to the foreground. This has the 
        /// added benefit of always quickly being able to find the Zoom window.
        /// </summary>
        /// <param name="handle"></param>
        private static void FocusOnZoomWindow(IntPtr handle)
        {
            OpenWindowGetter.SetForegroundWindow(handle);
            OpenWindowGetter.SetActiveWindow(handle);
        }

        /// <summary>
        /// Shortcut to toggle mute/un-mute in Zoom is Alt + A
        /// </summary>
        private static void SendToggleMuteKeyboardShortcut()
        {
            var inputSim = new InputSimulator();
            inputSim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.MENU, VirtualKeyCode.VK_A);
        }
    }
}
