using System;
using System.IO.Ports;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using MetroFramework.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Reflection;
using System.Collections;
using MetroFramework.Controls;

namespace DynamicAmbilight
{
    public partial class DynamicAmbilight : MetroForm
    {
        private int fps = 10, LEDS_X = 32, LEDS_Y = 20, width = 1920, height = 1200, timing;
        private int[] offsets = new int[4] { 0, 0, 0, 0 };
        private readonly Stopwatch sw = new Stopwatch(); //stopwatch is being used once on startup, it determines how much time does one iteration take
        private readonly SerialPort serial = new SerialPort() { Parity = (Parity)Enum.Parse(typeof(Parity), "0", true), DataBits = 8, StopBits = (StopBits)Enum.Parse(typeof(StopBits), "1", true), ReadTimeout = 500, WriteTimeout = 500 };
        private readonly String[] BaudRatesList = new string[8] { "5000000", "2000000", "1000000", "921600", "460800", "230400", "115200", "57600" };
        private Thread CaptureThread;
        private Thread RGBeffects;
        private InterpolationMode intrpmode;
        private readonly IntPtr handle = DLLIMPORTS.GetDesktopWindow();

        private void GetWindowSize() //gets screen size also considering offsets
        {
            for (int i = 0; i < 4; i++) offsets[i] = 0;
            DLLIMPORTS.RECT windowRect = new DLLIMPORTS.RECT(); //get the size
            DLLIMPORTS.GetWindowRect(handle, ref windowRect);
            width = windowRect.right - windowRect.left;
            height = windowRect.bottom - windowRect.top;
        }
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
        private void COMPort(bool state)
        {
            if (state)
            {
                Selection_Check();
                ComPort.Enabled = BaudRate.Enabled = InterpMode.Enabled = TestButton.Enabled = RefreshButton.Enabled = false;
                if (serial.IsOpen == false) { serial.Open(); while (serial.IsOpen == false) ; }
            }
            else
            {
                ComPort.Enabled = BaudRate.Enabled = InterpMode.Enabled = TestButton.Enabled = RefreshButton.Enabled = true;
                Thread.Sleep(100);
                serial.Close();
            }
        }
        private void Main() 
        {
            while (StartStop.Checked) 
            { 
                Thread scrcap = new Thread(ScreenCapture) { Priority = ThreadPriority.Highest }; 
                scrcap.Start(); 
                if (PreventAwayMode.Checked) DLLIMPORTS.SetThreadExecutionState(DLLIMPORTS.EXECUTION_STATE.ES_CONTINUOUS | DLLIMPORTS.EXECUTION_STATE.ES_SYSTEM_REQUIRED | DLLIMPORTS.EXECUTION_STATE.ES_DISPLAY_REQUIRED); 
                else if (PreventSleep.Checked) DLLIMPORTS.SetThreadExecutionState(DLLIMPORTS.EXECUTION_STATE.ES_CONTINUOUS | DLLIMPORTS.EXECUTION_STATE.ES_SYSTEM_REQUIRED); 
                Thread.Sleep(1000 / fps); 
            } 
        }
        private void ScreenCapture()
        {
            Color color;
            Bitmap bitmap = new Bitmap(width, height);
            Bitmap tempbmp = new Bitmap(LEDS_X, LEDS_Y);
            Graphics tempbmpgr = Graphics.FromImage(tempbmp);
            Graphics bitmapgr = Graphics.FromImage(bitmap);
            tempbmpgr.InterpolationMode = intrpmode;
            bitmapgr.CopyFromScreen(offsets[2], offsets[0], 0, 0, bitmap.Size); //30ms
            tempbmpgr.DrawImage(bitmap, new Rectangle(0, 0, LEDS_X, LEDS_Y)); //15-17ms
            for (int x = LEDS_X-1; x >=0; x--) //these for's take 5-7ms
            {
                color = tempbmp.GetPixel(x, LEDS_Y - 1);
                serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            for (int y = LEDS_Y - 1; y >= 0; y--)
            {
                color = tempbmp.GetPixel(0, y);
                serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            for (int x = 0; x < LEDS_X; x++)
            {
                color = tempbmp.GetPixel(x, 0);
                serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            for (int y = 0; y < LEDS_Y; y++)
            {
                color = tempbmp.GetPixel(LEDS_X - 1, y);
                serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            GC.Collect();
        }
        private void Selection_Check()
        {
            if (ComPort.SelectedIndex == -1) ComPort.SelectedIndex = ComPort.Items.Count - 1; //if none selected, then preselect first COM port in list
            if (BaudRate.SelectedIndex == -1) BaudRate.SelectedIndex = BaudRatesList.Length - 5; //if none selected, then preselect 115200 baud
            if (InterpMode.SelectedIndex == -1) InterpMode.SelectedIndex = 7;//if none selected, then preselect Default (the fastest)
        }
        //////////////////////////////////////         GUI         /////////////////////////////////////////////////////
        List<MetroButton> buttonlist = new List<MetroButton>();
        public delegate void ColorDelegate(Color clr);
        public void GetColor(Color clr) 
        { 
            if (clr != Color.Empty) colorarray.Add(clr);
            if (colorarray.Count > buttonlist.Count) buttonlist.Remove(buttonlist[buttonlist.Count - 1]);
            else buttonlist[buttonlist.Count - 1].BackColor = colorarray[colorarray.Count - 1];
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
        private void StartStop_CheckStateChanged(object sender, EventArgs e)
        {
            if (StartStop.Checked)
            {
                COMPort(true);
                CaptureThread = new Thread(Main) { Priority = ThreadPriority.Highest }; //starts up a new thread, which is alive till state will be false
                CaptureThread.Start();
            }
            else
            {
                CaptureThread.Abort();
                COMPort(false);
            }
        }
        private void LEDSHOW_CheckStateChanged(object sender, EventArgs e)
        {
            if (LEDSHOW.Checked)
            {
                AmbilightModes.Enabled = false;
                COMPort(true);
                switch (AmbilightModes.SelectedIndex)
                {
                    case 0:
                        RGBeffects = new Thread(FadeInOut) { Priority = ThreadPriority.Highest };
                        break;
                    case 1:
                        RGBeffects = new Thread(Rainbow) { Priority = ThreadPriority.Highest };
                        break;
                    case 2:
                        RGBeffects = new Thread(RainbowCycle) { Priority = ThreadPriority.Highest };
                        break;
                    case 3:
                        RGBeffects = new Thread(TheaterChaseRainbow) { Priority = ThreadPriority.Highest };
                        break;
                    case 4:
                        RGBeffects = new Thread(FullWhite) { Priority = ThreadPriority.Highest };
                        break;
                    case 5:
                        RGBeffects = new Thread(FadeCustom) { Priority = ThreadPriority.Highest };
                        break;
                    case 6:
                        RGBeffects = new Thread(CylonBounce) { Priority = ThreadPriority.Highest };
                        break;
                    case 7:
                        RGBeffects = new Thread(Twinkle) { Priority = ThreadPriority.Highest };
                        break;
                    case 8:
                        RGBeffects = new Thread(TestLEDs) { Priority = ThreadPriority.Highest };
                        break;
                }
                RGBeffects.Start();
            }
            else
            {
                RGBeffects.Abort();
                COMPort(false);
                AmbilightModes.Enabled = true;
            }
        }
        private void FadeTiming_ValueChanged(object sender, EventArgs e) { fadetiming = FadeTiming.Value; }
        private void TestButton_Click(object sender, EventArgs e)
        {
            COMPort(true);
            sw.Restart(); //start timer to check capturescreen timing
            ScreenCapture();
            sw.Stop();
            COMPort(false);
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
        private void CaptureMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CaptureArea.SelectedIndex == 2)
            {
                CustomWidth.Enabled = CustomHeight.Enabled = false;
                UpperOffset.Enabled = LowerOffset.Enabled = LeftOffset.Enabled = RightOffset.Enabled = true;
                CustomOffsets();
            }
            else
            {
                UpperOffset.Enabled = LowerOffset.Enabled = LeftOffset.Enabled = RightOffset.Enabled = false; 
                for (int i = 0; i < 4; i++) offsets[i] = 0;
                if (CaptureArea.SelectedIndex == 1)
                {
                    CustomWidth.Enabled = CustomHeight.Enabled = true;
                    CustomResolution();
                }
                else { CustomWidth.Enabled = CustomHeight.Enabled = false; GetWindowSize(); }
            }
        }
        private void SelectColor_Click(object sender, EventArgs e)
        {
            if (buttonlist.Count < 6)
            {
                ColorPicker colorpicker = new ColorPicker(new ColorDelegate(GetColor));
                colorpicker.Show();
                buttonlist.Add(new MetroButton());
                buttonlist[buttonlist.Count - 1].Style = MetroFramework.MetroColorStyle.Black;
                buttonlist[buttonlist.Count - 1].Theme = MetroFramework.MetroThemeStyle.Dark;
                buttonlist[buttonlist.Count - 1].UseCustomBackColor = true;
                buttonlist[buttonlist.Count - 1].Size = new Size(40, 40);
                buttonlist[buttonlist.Count - 1].Location = new Point(5 + (buttonlist.Count - 1) * 45, 250); 
                ModesTab.Controls.Add(buttonlist[buttonlist.Count - 1]);
                if (buttonlist.Count == 5) SelectColor.Enabled = false;
            }
        }
        private void FillComboBoxes()
        {
            foreach (InterpolationMode interpmode in Enum.GetValues(typeof(InterpolationMode))) if (interpmode != InterpolationMode.Invalid) InterpMode.Items.Add(interpmode); //fetch all possible interpolation modes
            Get_ComPort_Names();
            for (int i = 0; i < BaudRatesList.Length; i++) BaudRate.Items.Add(BaudRatesList[i]);
            CaptureArea.Items.Add("Fullscreen");
            CaptureArea.SelectedIndex = 0;
            CaptureArea.Items.Add("Custom resolution");
            CaptureArea.Items.Add("Custom offsets");
            FPSChanger.Value = fps;
            ControlTabs.SelectTab(0);
            AmbilightModes.Items.Add("Single Color Fade");
            AmbilightModes.SelectedIndex = 0;
            AmbilightModes.Items.Add("Rainbow");
            AmbilightModes.Items.Add("Rainbow Cycle");
            AmbilightModes.Items.Add("Theater Chase");
            AmbilightModes.Items.Add("Full White");
            AmbilightModes.Items.Add("Multicolor Fade");
            AmbilightModes.Items.Add("Cylon Bounce");
            AmbilightModes.Items.Add("Twinkle");
            AmbilightModes.Items.Add("Test LEDs");
        }
        public DynamicAmbilight()
        {
            InitializeComponent();
            FillComboBoxes();
        }
        ///////////////////////////////////           LEDS           ///////////////////////////////////////////////////////////////
        List<Color> colorarray = new List<Color>();
        Color[] ledarray = new Color[104]; //should be NumLeds() length
        private int fadetiming = 10;
        private int NumLeds() { return (LEDS_X + LEDS_Y) * 2; }
        private void LedShow() { Color clr; for (int i = 0; i < ledarray.Length; i++) { clr = ledarray[i]; serial.Write(new byte[] { clr.R, clr.G, clr.B }, 0, 3); } }
        Color Wheel(int WheelPos)
        {
            if (WheelPos < 85)
            {
                return Color.FromArgb(WheelPos * 3, 255 - WheelPos * 3, 0);
            }
            else
            {
                if (WheelPos < 170)
                {
                    WheelPos -= 85;
                    return Color.FromArgb(255 - WheelPos * 3, 0, WheelPos * 3);
                }
                else
                {
                    WheelPos -= 170;
                    return Color.FromArgb(0, WheelPos * 3, 255 - WheelPos * 3);
                }
            }
        }
        public void FadeInOut()
        {
            while (LEDSHOW.Checked && colorarray.Count > 0)
            {
                for (int k = 0; k < 256; k++) //Fade IN
                {
                    for (int i = 0; i < ledarray.Length; i++) ledarray[i] = Color.FromArgb(Convert.ToInt32((k / 255d) * colorarray[0].R), Convert.ToInt32((k / 255d) * colorarray[0].G), Convert.ToInt32((k / 255d) * colorarray[0].B));
                    LedShow();
                    Thread.Sleep(fadetiming);
                }
                for (int k = 255; k > -1; k--) //Fade OUT
                {
                    for (int i = 0; i < ledarray.Length; i++) ledarray[i] = Color.FromArgb(Convert.ToInt32((k / 255d) * colorarray[0].R), Convert.ToInt32((k / 255d) * colorarray[0].G), Convert.ToInt32((k / 255d) * colorarray[0].B));
                    LedShow();
                    Thread.Sleep(fadetiming);
                }
            }
        }
        public void Rainbow()
        {
            int i, j;
            while (LEDSHOW.Checked)
                for (j = 0; j < 256; j++)
                {
                    for (i = 0; i < NumLeds(); i++) ledarray[i] = Wheel((i + j) & 255);
                    Thread.Sleep(fadetiming);
                    LedShow();
                }
        } 
        public void RainbowCycle()
        {
            int i, j;
            while (LEDSHOW.Checked)
            {
                for (j = 0; j < 256 * 5; j++)
                {
                    for (i = 0; i < NumLeds(); i++) ledarray[i] = Wheel((i * 256 / NumLeds() + j) & 255);
                    Thread.Sleep(fadetiming);
                    LedShow();
                }
            }
        }
        public void TheaterChaseRainbow()
        {
            while (LEDSHOW.Checked)
                for (int j = 0; j < 256; j++)
                {     // cycle all 256 colors in the wheel
                    for (int q = 0; q < 3; q++)
                    {
                        for (int i = 0; i < NumLeds() - 3; i += 3) ledarray[i + q] = Wheel((i + j) % 255);    //turn every third pixel on
                        LedShow();
                        Thread.Sleep(fadetiming);
                        for (int i = 0; i < NumLeds() - 3; i += 3) ledarray[i + q] = Color.Empty;        //turn every third pixel off
                    }
                }

        }
        public void FullWhite()
        {
            while (LEDSHOW.Checked)
            {
                for (int i = 0; i < NumLeds(); i++) ledarray[i] = Color.FromArgb(255, 255, 255);
                LedShow();
                Thread.Sleep(400);
            }
        }

        public void FadeCustom()
        {
            while (LEDSHOW.Checked && colorarray.Count > 0)
                for (int j = 0; j < colorarray.Count; j++)
                {
                    for (int k = 0; k < 256; k++)
                    {
                        for (int i = 0; i < ledarray.Length; i++) ledarray[i] = Color.FromArgb(Convert.ToInt32((k / 255d) * colorarray[j].R), Convert.ToInt32((k / 255d) * colorarray[j].G), Convert.ToInt32((k / 255d) * colorarray[j].B));
                        LedShow();
                        Thread.Sleep(fadetiming);
                    }
                    for (int k = 255; k >= 0; k = k - 2)
                    {
                        for (int i = 0; i < ledarray.Length; i++) ledarray[i] = Color.FromArgb(Convert.ToInt32((k / 255d) * colorarray[j].R), Convert.ToInt32((k / 255d) * colorarray[j].G), Convert.ToInt32((k / 255d) * colorarray[j].B));
                        LedShow();
                        Thread.Sleep(fadetiming);
                    }
                }
        }
        public void TestLEDs()
        {
            while (LEDSHOW.Checked && colorarray.Count > 0)
                for (int i = 0; i < colorarray.Count; i++)
                    for (int j = 0; j < NumLeds(); j++)
                    {
                        for (int k = 0; k < NumLeds(); k++)
                            if (k != j) ledarray[k] = Color.Black;
                            else ledarray[k] = colorarray[i];
                        LedShow();
                        Thread.Sleep(fadetiming);
                    }
        }
        public void CylonBounce()
        {
            int EyeSize = 2;
            while (LEDSHOW.Checked && colorarray.Count > 0)
            {
                for (int i = 0; i < NumLeds() - EyeSize - 1; i++)
                {
                    for (int k = 0; k < NumLeds(); k++) ledarray[k] = Color.Black;
                    ledarray[i] = Color.FromArgb(colorarray[0].R / 10, colorarray[0].G / 10, colorarray[0].B / 10);
                    for (int j = 1; j <= EyeSize; j++) ledarray[i + j] = colorarray[0];
                    ledarray[i + EyeSize + 1] = Color.FromArgb(colorarray[0].R / 10, colorarray[0].G / 10, colorarray[0].B / 10);
                    LedShow();
                    Thread.Sleep(fadetiming);
                }
                Thread.Sleep(fadetiming * 2);
                for (int i = NumLeds() - EyeSize - 2; i > -1; i--)
                {
                    for (int k = 0; k < NumLeds(); k++) ledarray[k] = Color.Black;
                    ledarray[i] = Color.FromArgb(colorarray[0].R / 10, colorarray[0].G / 10, colorarray[0].B / 10);
                    for (int j = 1; j <= EyeSize; j++) ledarray[i + j] = colorarray[0];
                    ledarray[i + EyeSize + 1] = Color.FromArgb(colorarray[0].R/10, colorarray[0].G / 10, colorarray[0].B / 10);
                    LedShow();
                    Thread.Sleep(fadetiming);
                }
                Thread.Sleep(fadetiming * 2);
            }
        }
        public void Twinkle()
        {
            int Count = 10;
            while (LEDSHOW.Checked && colorarray.Count > 0)
            {
                var random = new Random();
                for (int k = 0; k < NumLeds(); k++) ledarray[k] = Color.Black;
                LedShow();
                for (int i = 0; i < Count; i++)
                {
                    ledarray[random.Next(NumLeds() - 1)] = colorarray[random.Next(colorarray.Count - 1)];
                    LedShow();
                    Thread.Sleep(fadetiming);
                }
                Thread.Sleep(fadetiming*10);
            }
        }
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


/*
 * public const int SRCCOPY = 0x00CC0020;
             [DllImport("user32.dll")]
             public static extern IntPtr GetForegroundWindow();
             [DllImport("user32.dll")]
             public static extern IntPtr FindWindow(string className, string windowName);
             [DllImport("user32.dll")]
             public static extern IntPtr GetWindowDC(IntPtr hWnd);
             [DllImport("user32.dll")]
             public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);
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
 * private void Processes_SelectedIndexChanged(object sender, EventArgs e) { CaptureArea.Enabled = true; }
        private void CaptureArea_Switched(object sender, EventArgs e)
        {
            if (!CaptureArea.Checked) handle = DLLIMPORTS.GetDesktopWindow();
            else handle = DLLIMPORTS.FindWindow(AllProcesslist[Processes.SelectedIndex].MainWindowTitle, AllProcesslist[Processes.SelectedIndex].ProcessName);
        }
        foreach (Process Proc in AllProcesslist) if (!String.IsNullOrEmpty(Proc.MainWindowTitle)) Processes.Items.Add(Proc.MainWindowTitle);
 * 
        IntPtr hdcSrc = DLLIMPORTS.GetWindowDC(handle); //get the hDC of the target window
        IntPtr hdcDest = DLLIMPORTS.CreateCompatibleDC(hdcSrc);  //create a device context we can copy to
        IntPtr hBitmap = DLLIMPORTS.CreateCompatibleBitmap(hdcSrc, width, height);  //create a bitmap we can copy it to, // using GetDeviceCaps to get the width/height
        IntPtr hOld = DLLIMPORTS.SelectObject(hdcDest, hBitmap); //select the bitmap object
        DLLIMPORTS.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, DLLIMPORTS.SRCCOPY); // bitblt over
        Bitmap bitmap = Bitmap.FromHbitmap(hBitmap); //get a .NET image object for it

        DLLIMPORTS.DeleteObject(hBitmap); // free up the Bitmap object
        DLLIMPORTS.DeleteDC(hdcDest); // clean up 
        DLLIMPORTS.ReleaseDC(handle, hdcSrc);
        DLLIMPORTS.SelectObject(hdcDest, hOld); // restore selection
        bitmap.Dispose();

        Texture2DDescription textureDesc = new Texture2DDescription
        {
            CpuAccessFlags = CpuAccessFlags.Read,
            BindFlags = BindFlags.None,
            Format = Format.B8G8R8A8_UNorm,
            Width = 1920,
            Height = 1200,
            OptionFlags = ResourceOptionFlags.None,
            MipLevels = 1,
            ArraySize = 1,
            SampleDescription = { Count = 1, Quality = 0 },
            Usage = ResourceUsage.Staging
        }; // Create Staging texture CPU-accessible
        private void ScreenCapture()
        {
            Bitmap bitmap = new Bitmap(1920, 1200, PixelFormat.Format32bppArgb); //Create Drawing.Bitmap
            try //Try to get duplicated frame within given time is ms
            {
                Factory1 factory = new Factory1();
                
                Adapter1 adapter = factory.GetAdapter1(0); //Get first adapter
                
                SharpDX.Direct3D11.Device device = new SharpDX.Direct3D11.Device(adapter); //Get device from adapter

                Texture2D screenTexture = new Texture2D(device, textureDesc);

                OutputDuplication duplicatedOutput = adapter.GetOutput(0).QueryInterface<Output1>().DuplicateOutput(device); // Duplicate the output, Get front buffer of the adapter

                duplicatedOutput.AcquireNextFrame(10, out OutputDuplicateFrameInformation duplicateFrameInformation, out SharpDX.DXGI.Resource screenResource);
                
                using (var screenTexture2D = screenResource.QueryInterface<Texture2D>()) device.ImmediateContext.CopyResource(screenTexture2D, screenTexture); //copy resource into memory that can be accessed by the CPU

                var mapSource = device.ImmediateContext.MapSubresource(screenTexture, 0, MapMode.Read, SharpDX.Direct3D11.MapFlags.None); // Get the desktop capture texture
                
                var mapDest = bitmap.LockBits(new Rectangle(0, 0, 1920, 1200), ImageLockMode.WriteOnly, bitmap.PixelFormat); //Copy pixels from screen capture Texture to GDI bitmap
                var sourcePtr = mapSource.DataPointer;
                var destPtr = mapDest.Scan0;
                for (int y = 0; y < 1200; y++)
                {
                    Utilities.CopyMemory(destPtr, sourcePtr, 1920 * 4); //Copy a single line 
                    sourcePtr = IntPtr.Add(sourcePtr, mapSource.RowPitch); //Advance pointers
                    destPtr = IntPtr.Add(destPtr, mapDest.Stride);
                }
                bitmap.UnlockBits(mapDest); //Release source and dest locks
                device.ImmediateContext.UnmapSubresource(screenTexture, 0);
                screenResource.Dispose();
                duplicatedOutput.ReleaseFrame();
                ///////////////////////////////////////////////////////////////////////////////////////////
                Color color;
                Graphics srcintrp = Graphics.FromImage(bitmap);
                srcintrp.InterpolationMode = intrpmode;
                srcintrp.DrawImage(bitmap, new Rectangle(800, 500, 32, 20)); //15-17ms
                for (int x = 831; x > 799; x--) //831 - 800, these for's take 5-7ms
                {
                    color = bitmap.GetPixel(x, 519);
                    serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
                }
                for (int y = 519; y > 499; y--) //800
                {
                    color = bitmap.GetPixel(800, y);
                    serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
                }
                for (int x = 800; x < 832; x++) //800 - 831
                {
                    color = bitmap.GetPixel(x, 500);
                    serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
                }
                for (int y = 500; y < 520; y++) //831
                {
                    color = bitmap.GetPixel(831, y);
                    serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
                }
            }
            catch (SharpDXException e)
            {
                if (e.ResultCode.Code != SharpDX.DXGI.ResultCode.fadetimingTimeout.Result.Code)
                {
                    //Trace.TraceError(e.Message);
                    //Trace.TraceError(e.StackTrace);
                }
            }
            bitmap.Dispose();
            GC.Collect(); //manual exec of garbage collection, prevents RAM overflow (its god damn fast on 20+ fps)
        }
 
        public static void CaptureScreen()
        {
            // # of graphics card adapter
            const int numAdapter = 0;

            // # of output device (i.e. monitor)
            const int numOutput = 1;

            // Create DXGI Factory1
            var factory = new Factory1();
            var adapter = factory.GetAdapter1(numAdapter);

            // Create device from Adapter
            var device = new SharpDX.Direct3D11.Device(adapter);

            // Get DXGI.Output
            var output = adapter.GetOutput(numOutput);
            var output1 = output.QueryInterface<Output1>();

            // Width/Height of desktop to capture
            int width =  1920;
            int height = 1200;

            // Create Staging texture CPU-accessible
            var textureDesc = new Texture2DDescription
            {
                CpuAccessFlags = CpuAccessFlags.Read,
                BindFlags = BindFlags.None,
                Format = Format.B8G8R8A8_UNorm,
                Width = width,
                Height = height,
                OptionFlags = ResourceOptionFlags.None,
                MipLevels = 1,
                ArraySize = 1,
                SampleDescription = { Count = 1, Quality = 0 },
                Usage = ResourceUsage.Staging
            };
            var screenTexture = new Texture2D(device, textureDesc);

            // Duplicate the output
            var duplicatedOutput = output1.DuplicateOutput(device);

            bool captureDone = false;
            Bitmap bitmap = null;

            for (int i = 0; !captureDone; i++)
            {
                try
                {
                    SharpDX.DXGI.Resource screenResource;
                    OutputDuplicateFrameInformation duplicateFrameInformation;

                    // Try to get duplicated frame within given time
                    duplicatedOutput.AcquireNextFrame(10000, out duplicateFrameInformation, out screenResource);

                    if (i > 0)
                    {
                        // copy resource into memory that can be accessed by the CPU
                        using (var screenTexture2D = screenResource.QueryInterface<Texture2D>())
                            device.ImmediateContext.CopyResource(screenTexture2D, screenTexture);

                        // Get the desktop capture texture
                        var mapSource = device.ImmediateContext.MapSubresource(screenTexture, 0, MapMode.Read, SharpDX.Direct3D11.MapFlags.None);

                        // Create Drawing.Bitmap
                        bitmap = new System.Drawing.Bitmap(width, height, PixelFormat.Format32bppArgb);
                        var boundsRect = new System.Drawing.Rectangle(0, 0, width, height);

                        // Copy pixels from screen capture Texture to GDI bitmap
                        var mapDest = bitmap.LockBits(boundsRect, ImageLockMode.WriteOnly, bitmap.PixelFormat);
                        var sourcePtr = mapSource.DataPointer;
                        var destPtr = mapDest.Scan0;
                        for (int y = 0; y < height; y++)
                        {
                            // Copy a single line 
                            Utilities.CopyMemory(destPtr, sourcePtr, width * 4);

                            // Advance pointers
                            sourcePtr = IntPtr.Add(sourcePtr, mapSource.RowPitch);
                            destPtr = IntPtr.Add(destPtr, mapDest.Stride);
                        }

                        // Release source and dest locks
                        bitmap.UnlockBits(mapDest);
                        device.ImmediateContext.UnmapSubresource(screenTexture, 0);

                        // Capture done
                        captureDone = true;
                    }

                    screenResource.Dispose();
                    duplicatedOutput.ReleaseFrame();

                }
                catch (SharpDXException e)
                {
                    if (e.ResultCode.Code != SharpDX.DXGI.ResultCode.fadetimingTimeout.Result.Code)
                    {
                        throw e;
                    }
                }
            }

            duplicatedOutput.Dispose();
            screenTexture.Dispose();
            output1.Dispose();
            output.Dispose();
            device.Dispose();
            adapter.Dispose();
            factory.Dispose();
            /*
            Color color;
            Graphics srcintrp = Graphics.FromImage(bitmap);
            srcintrp.InterpolationMode = InterpolationMode.HighQualityBicubic;
            srcintrp.DrawImage(bitmap, new Rectangle(800, 500, 32, 20)); //15-17ms
            for (int x = 831; x > 799; x--) //831 - 800, these for's take 5-7ms
            {
                color = bitmap.GetPixel(x, 519);
                //serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            for (int y = 519; y > 499; y--) //800
            {
                color = bitmap.GetPixel(800, y);
                //serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            for (int x = 800; x < 832; x++) //800 - 831
            {
                color = bitmap.GetPixel(x, 500);
                //serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            for (int y = 500; y < 520; y++) //831
            {
                color = bitmap.GetPixel(831, y);
                //serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            
    





    private void CaptureScreen() //this thread captures screen and calls for interp method
        {
            Color color;
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            Bitmap srcbmp = new Bitmap(bounds.Width, bounds.Height); //custom resolutions are going to be implemented soon 
            Graphics srcintrp = Graphics.FromImage(srcbmp);
            srcintrp.InterpolationMode = intrpmode;
            srcintrp.CopyFromScreen(0, 0, 0, 0, srcbmp.Size); //30ms

            if (method)
            {
                srcintrp.DrawImage(srcbmp, new Rectangle(800, 500, 32, 20)); //15-17ms
            }
            else
            {
                srcintrp.DrawImage(srcbmp, new Rectangle(800, 500, 32, 1), 0, 0, 1920, 30, GraphicsUnit.Pixel); //800 - 831
                srcintrp.DrawImage(srcbmp, new Rectangle(832, 500, 1, 20), 1890, 0, 30, 1200, GraphicsUnit.Pixel); //832
                srcintrp.DrawImage(srcbmp, new Rectangle(800, 520, 32, 1), 0, 1170, 1920, 30, GraphicsUnit.Pixel); //800 - 831
                srcintrp.DrawImage(srcbmp, new Rectangle(800, 500, 1, 20), 0, 0, 30, 1200, GraphicsUnit.Pixel); //800
            }
            for (int x = 831; x > 799; x--) //831 - 800, these for's take 5-7ms
            {
                color = srcbmp.GetPixel(x, 519);
                serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            for (int y = 519; y > 499; y--) //800
            {
                color = srcbmp.GetPixel(800, y);
                serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            for (int x = 800; x < 832; x++) //800 - 831
            {
                color = srcbmp.GetPixel(x, 500);
                serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            for (int y = 500; y < 520; y++) //831
            {
                color = srcbmp.GetPixel(831, y);
                serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            GC.Collect(); //manual exec of garbage collection, prevents RAM overflow (its god damn fast on 20+ fps)
            Thread.Sleep(0); //to let other threads do their job, in case this thread is alive for too long
        }
        */
