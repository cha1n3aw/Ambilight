using System;
using System.IO.Ports;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using MetroFramework.Forms;
using System.Runtime.InteropServices;

namespace Dynamic_Ambilight
{
    public partial class Dynamic_Ambilight : MetroForm
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);
        [FlagsAttribute]
        public enum EXECUTION_STATE : uint { ES_AWAYMODE_REQUIRED = 0x00000040, ES_CONTINUOUS = 0x80000000, ES_DISPLAY_REQUIRED = 0x00000002, ES_SYSTEM_REQUIRED = 0x00000001 }
        private int fps = 10, LEDS_X = 32, LEDS_Y = 20, width = 1920, height = 1200, timing;
        private int[] offsets = new int[4] { 0, 0, 0, 0 };
        private bool state = false;
        private readonly Stopwatch sw = new Stopwatch(); //stopwatch is being used once on startup, it determines how much time does one iteration take
        private readonly SerialPort serial = new SerialPort() { Parity = (Parity)Enum.Parse(typeof(Parity), "0", true), DataBits = 8, StopBits = (StopBits)Enum.Parse(typeof(StopBits), "1", true), ReadTimeout = 500, WriteTimeout = 500 };
        private readonly String[] BaudRatesList = new string[8] { "5000000", "2000000", "1000000", "921600", "460800", "230400", "115200", "57600" };
        private readonly Process[] AllProcesslist = Process.GetProcesses();
        Thread thread;
        InterpolationMode intrpmode;
        IntPtr handle = DLLIMPORTS.GetDesktopWindow();

        private void GetWindowSize() //gets screen size also considering offsets
        {
            for (int i = 0; i < 4; i++) offsets[i] = 0;
            DLLIMPORTS.RECT windowRect = new DLLIMPORTS.RECT(); //get the size
            DLLIMPORTS.GetWindowRect(handle, ref windowRect);
            width = windowRect.right - windowRect.left;
            height = windowRect.bottom - windowRect.top;
        }
        private void Main() 
        {
            while (state) 
            { 
                Thread scrcap = new Thread(ScreenCapture) { Priority = ThreadPriority.Highest }; 
                scrcap.Start(); 
                if (PreventAwayMode.Checked) SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS | EXECUTION_STATE.ES_SYSTEM_REQUIRED | EXECUTION_STATE.ES_DISPLAY_REQUIRED); 
                else if (PreventSleep.Checked) SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS | EXECUTION_STATE.ES_SYSTEM_REQUIRED); 
                Thread.Sleep(1000 / fps); 
            } 
        }
        private void ScreenCapture()
        {
            Color color;
            Bitmap bitmap = new Bitmap(width, height);
            Graphics srcintrp = Graphics.FromImage(bitmap);
            srcintrp.InterpolationMode = intrpmode;
            srcintrp.CopyFromScreen(offsets[2], offsets[0], 0, 0, bitmap.Size); //30ms
            srcintrp.DrawImage(bitmap, new Rectangle(width/2, height/2, LEDS_X, LEDS_Y)); //15-17ms
            for (int x = width/2+LEDS_X-1; x >= width/2; x--) //these for's take 5-7ms
            {
                color = bitmap.GetPixel(x, height/2+LEDS_Y-1);
                serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            for (int y = height/2+LEDS_Y - 1; y >= height/2; y--)
            {
                color = bitmap.GetPixel(width/2, y);
                serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            for (int x = width/2; x < width/2+LEDS_X; x++)
            {
                color = bitmap.GetPixel(x, height/2);
                serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            for (int y = height/2; y < height/2+LEDS_Y; y++)
            {
                color = bitmap.GetPixel(width/2+LEDS_X-1, y);
                serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            GC.Collect();
            Thread.Sleep(0);
        }
        private void Selection_Check()
        {
            if (ComPort.SelectedIndex == -1) ComPort.SelectedIndex = ComPort.Items.Count - 1; //if none selected, then preselect first COM port in list
            if (BaudRate.SelectedIndex == -1) BaudRate.SelectedIndex = BaudRatesList.Length - 5; //if none selected, then preselect 115200 baud
            if (InterpMode.SelectedIndex == -1) InterpMode.SelectedIndex = 7;//if none selected, then preselect Default (the fastest)
        }
        private void Get_ComPort_Names()
        {
            ComPort.Items.Clear();
            foreach (string comportname in SerialPort.GetPortNames()) ComPort.Items.Add(comportname); //fetch comports that present in system
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (WindowState == FormWindowState.Minimized) { Hide(); Tray_Icon.BalloonTipTitle = "Hey, I'm here!"; Tray_Icon.BalloonTipText = "Click here to restore"; Tray_Icon.ShowBalloonTip(1000); }
        }
        private void Tray_Icon_BalloonTipClicked(object sender, EventArgs e) { Show(); WindowState = FormWindowState.Normal; }
        private void Tray_Icon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized) { Show(); WindowState = FormWindowState.Normal; }
            else if (WindowState == FormWindowState.Normal) WindowState = FormWindowState.Minimized;
        }
        private void StartStopButton_Click(object sender, EventArgs e)
        {
            if (!state)
            {
                state = true;
                StartStopButton.Text = "Stop";
                Selection_Check();
                ComPort.Enabled = BaudRate.Enabled = InterpMode.Enabled = TestButton.Enabled = RefreshButton.Enabled = false;
                if (serial.IsOpen == false) { serial.Open(); while (serial.IsOpen == false); }
                thread = new Thread(Main) { Priority = ThreadPriority.Highest }; //starts up a new thread, which is alive till state will be false
                thread.Start();
            }
            else
            {
                state = false;
                thread.Abort();
                ComPort.Enabled = BaudRate.Enabled = InterpMode.Enabled = TestButton.Enabled = RefreshButton.Enabled = true;
                StartStopButton.Text = "Start";
                Thread.Sleep(100);
                serial.Close();  
            }
        }
        private void TestButton_Click(object sender, EventArgs e)
        {
            Selection_Check();
            serial.Open();
            while (serial.IsOpen == false) ; //waits till the port will open, it takes around 50ms actually
            sw.Restart(); //start timer to check capturescreen timing
            ScreenCapture();
            sw.Stop();
            serial.Close();
            timing = Convert.ToInt32(sw.ElapsedMilliseconds);
            fps = Convert.ToInt32(Math.Floor(1000.0 / timing)); //floors down fps rating, so it will be more likely that there will be only one capturescreen thread running at once
            Default_Timings.Text = "Default: " + fps + " fps, " + timing + " ms per frame";
            if (fps > 0) FPSChanger.Value = fps;
        }
        private void RefreshButton_Click(object sender, EventArgs e) { Get_ComPort_Names(); }
        private void ComPort_SelectedIndexChanged_1(object sender, EventArgs e) { if (ComPort.SelectedIndex != -1) serial.PortName = ComPort.Items[ComPort.SelectedIndex].ToString(); }
        private void BaudRate_SelectedIndexChanged_1(object sender, EventArgs e) { if (BaudRate.SelectedIndex != -1) serial.BaudRate = Convert.ToInt32(BaudRate.Items[BaudRate.SelectedIndex]); }
        private void InterpMode_SelectedIndexChanged_1(object sender, EventArgs e) { if (InterpMode.SelectedIndex != -1) intrpmode = (InterpolationMode)InterpMode.Items[InterpMode.SelectedIndex]; }
        private void FPSChanger_ValueChanged(object sender, EventArgs e) { fps = FPSChanger.Value; Custom_Timings.Text = "Custom: "  + fps + " fps, " + 1000 / fps + " ms per frame"; }
        private void UpperOffset_TextChanged(object sender, EventArgs e) { if (UpperOffset.Text != "") { offsets[0] = Convert.ToInt32(UpperOffset.Text); CustomOffsets(); } }
        private void LowerOffset_TextChanged(object sender, EventArgs e) { if (LowerOffset.Text != "") { offsets[1] = Convert.ToInt32(LowerOffset.Text); CustomOffsets(); } }
        private void LeftOffset_TextChanged(object sender, EventArgs e) { if (LeftOffset.Text != "") { offsets[2] = Convert.ToInt32(LeftOffset.Text); CustomOffsets(); } }
        private void RightOffset_TextChanged(object sender, EventArgs e) { if (RightOffset.Text != "") { offsets[3] = Convert.ToInt32(RightOffset.Text); CustomOffsets(); } }
        private void CustomWidth_TextChanged(object sender, EventArgs e) { if (CustomWidth.Text != "") { width = Convert.ToInt32(CustomWidth.Text); CustomResolution(); } }
        private void CustomHeight_TextChanged(object sender, EventArgs e) { if (CustomHeight.Text != "") { height = Convert.ToInt32(CustomHeight.Text); CustomResolution(); } }
        private void LedsX_ValueChanged(object sender, EventArgs e) { LEDS_X = LedsX.Value; metroLabel9.Text = LedsX.Value.ToString(); }
        private void LedsY_ValueChanged(object sender, EventArgs e) { LEDS_Y = LedsY.Value; metroLabel8.Text = LedsY.Value.ToString(); }
        private void PreventSleep_CheckedChanged(object sender, EventArgs e) { if (PreventSleep.Checked == true) PreventAwayMode.Enabled = true; else { PreventAwayMode.Checked = false; PreventAwayMode.Enabled = false; } }

        private void CustomOffsets()
        {
            GetWindowSize();
            offsets[0] = Convert.ToInt32(UpperOffset.Text);
            offsets[1] = Convert.ToInt32(LowerOffset.Text);
            offsets[2] = Convert.ToInt32(LeftOffset.Text);
            offsets[3] = Convert.ToInt32(RightOffset.Text);
            width = width - offsets[2] - offsets[3];
            height = height - offsets[0] - offsets[1];
        }
        private void CustomResolution()
        {
            int customwidth = Convert.ToInt32(CustomWidth.Text);
            int customheight = Convert.ToInt32(CustomHeight.Text);
            if (customheight > 99 && customwidth > 99)
            {
                GetWindowSize(); Debug.WriteLine(height.ToString()); Debug.WriteLine(width.ToString());
                offsets[0] = (height - customheight) / 2;
                offsets[2] = (width - customwidth) / 2; Debug.WriteLine(offsets[0].ToString()); Debug.WriteLine(offsets[2].ToString());
                width = customwidth;
                height = customheight; Debug.WriteLine(height.ToString()); Debug.WriteLine(width.ToString());
            }
        }
        private void CaptureMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CaptureMode.SelectedIndex == 2)
            {
                CustomWidth.Enabled = CustomHeight.Enabled = false;
                UpperOffset.Enabled = LowerOffset.Enabled = LeftOffset.Enabled = RightOffset.Enabled = true;
                CustomOffsets();
            }
            else
            {
                UpperOffset.Enabled = LowerOffset.Enabled = LeftOffset.Enabled = RightOffset.Enabled = false; 
                for (int i = 0; i < 4; i++) offsets[i] = 0;
                if (CaptureMode.SelectedIndex == 1)
                {
                    CustomWidth.Enabled = CustomHeight.Enabled = true;
                    CustomResolution();
                }
                else { CustomWidth.Enabled = CustomHeight.Enabled = false; GetWindowSize(); }
            }
        }   
        
        public Dynamic_Ambilight()
        {
            InitializeComponent();
            foreach (InterpolationMode interpmode in Enum.GetValues(typeof(InterpolationMode))) if (interpmode != InterpolationMode.Invalid) InterpMode.Items.Add(interpmode); //fetch all possible interpolation modes
            Get_ComPort_Names();
            for (int i = 0; i < BaudRatesList.Length; i++) BaudRate.Items.Add(BaudRatesList[i]);
            CaptureMode.Items.Add("Fullscreen");
            CaptureMode.SelectedIndex = 0;
            CaptureMode.Items.Add("Custom resolution");
            CaptureMode.Items.Add("Custom offsets");
            FPSChanger.Value = fps;
            ControlTabs.SelectTab(0);
        }

        private class DLLIMPORTS
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int left;
                public int top;
                public int right;
                public int bottom;
            }
            [DllImport("user32.dll")]
            public static extern IntPtr GetForegroundWindow();
            [DllImport("user32.dll")]
            public static extern IntPtr FindWindow(string className, string windowName);
            [DllImport("user32.dll")]
            public static extern IntPtr GetDesktopWindow();
            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowDC(IntPtr hWnd);
            [DllImport("user32.dll")]
            public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);
            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rect);
            public const int SRCCOPY = 0x00CC0020;
            [DllImport("gdi32.dll")]
            public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hObjectSource, int nXSrc, int nYSrc, int dwRop);
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth, int nHeight);
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
            [DllImport("gdi32.dll")]
            public static extern bool DeleteDC(IntPtr hDC);
            [DllImport("gdi32.dll")]
            public static extern bool DeleteObject(IntPtr hObject);
            [DllImport("gdi32.dll")]
            public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
        }
    }
}
