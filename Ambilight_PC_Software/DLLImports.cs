using System;
using System.Runtime.InteropServices;

namespace DynamicAmbilight
{
    public partial class DynamicAmbilight
    {
        private readonly IntPtr handle = DLLIMPORTS.GetDesktopWindow();
        private class DLLIMPORTS : DynamicAmbilight
        {
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);
            [FlagsAttribute]
            public enum EXECUTION_STATE : uint { ES_AWAYMODE_REQUIRED = 0x00000040, ES_CONTINUOUS = 0x80000000, ES_DISPLAY_REQUIRED = 0x00000002, ES_SYSTEM_REQUIRED = 0x00000001 }
            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int left;
                public int top;
                public int right;
                public int bottom;
            }
            [DllImport("user32.dll")]
            public static extern IntPtr GetDesktopWindow();
            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rect);
        }
    }
}