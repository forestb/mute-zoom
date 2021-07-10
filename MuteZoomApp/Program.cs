using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;
using Wrappers.MuteZoomApp;

namespace MuteZoomApp
{
    class Program
    {
        static async Task Main(string[] args)
        {          
            Console.WriteLine("Hello World!");

            FindZoomWindowAndMute();

            LastWindowHandler.SetLastWindowActive();
        }

        private static void FindZoomWindowAndMute()
        {
            const string ZOOM_MEETING_WINDOW_TITLE = "Zoom Meeting";

            foreach (KeyValuePair<IntPtr, string> window in OpenWindowGetter.GetOpenWindows())
            {
                IntPtr handle = window.Key;
                string title = window.Value;

                if (title.ToLower().Contains(ZOOM_MEETING_WINDOW_TITLE.ToLower()))
                {
                    // Before sending inputs, you must bring the Window to the foreground. This has the
                    // added benefit of always quickly being able to find the Zoom window.
                    BringWindowToFrontAndActivate(handle);

                    SendToggleMuteKeyboardShortcut();
                }
            }
        }

        private static void BringWindowToFrontAndActivate(IntPtr handle)
        {
            OpenWindowGetter.SetForegroundWindow(handle);
            OpenWindowGetter.SetActiveWindow(handle);
        }

        private static void SendToggleMuteKeyboardShortcut()
        {
            var inputSim = new InputSimulator();
            inputSim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.MENU, VirtualKeyCode.VK_A);
        }
    }
}
