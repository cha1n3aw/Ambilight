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
using MetroFramework.Controls;
using ScreenCapturerNS;
using System.Configuration;

namespace DynamicAmbilight
{
    public partial class DynamicAmbilight : MetroForm
    {
        private int width, height, timing;
        //private bool mode = false; //dx11 or winapi
        private int[] offsets = new int[2] { 0, 0 }; //only for custom resolution
        private readonly Stopwatch sw = new Stopwatch(); //stopwatch is being used once on startup, it determines how much time does one iteration take
        private readonly SerialPort serial = new SerialPort() { Parity = (Parity)Enum.Parse(typeof(Parity), "0", true), DataBits = 8, StopBits = (StopBits)Enum.Parse(typeof(StopBits), "1", true), ReadTimeout = 500, WriteTimeout = 500 };
        private readonly String[] BaudRatesList = new string[8] { "5000000", "2000000", "1000000", "921600", "460800", "230400", "115200", "57600" };
        private readonly IntPtr handle = DLLIMPORTS.GetDesktopWindow();
        private InterpolationMode intrpmode;
        private Thread RGBEffects;

        private Thread SettingsThread(string key, string value)
        {
            Thread settingsthread = new Thread(() => SetSetting(key, value)) { IsBackground = true };
            settingsthread.Start();
            return settingsthread;
        }
        private static void SetSetting(string key, string value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection("appSettings");
        }
        private void Init()
        {
            GetWindowSize();
            FPSChanger.Value = Convert.ToInt32(ConfigurationManager.AppSettings["FPS"]);
            LedsX.Value = Convert.ToInt32(ConfigurationManager.AppSettings["LEDSX"]);
            LedsY.Value = Convert.ToInt32(ConfigurationManager.AppSettings["LEDSY"]);
            UpperOffset.Text = ConfigurationManager.AppSettings["UpperOffset"];
            LowerOffset.Text = ConfigurationManager.AppSettings["LowerOffset"];
            LeftOffset.Text = ConfigurationManager.AppSettings["LeftOffset"];
            RightOffset.Text = ConfigurationManager.AppSettings["RightOffset"];
            CustomWidth.Text = ConfigurationManager.AppSettings["CustomWidth"];
            CustomHeight.Text = ConfigurationManager.AppSettings["CustomHeight"];
        }
        private void GetWindowSize() //gets screen size also considering offsets
        {
            offsets[0] = offsets[1] = 0;
            DLLIMPORTS.RECT windowRect = new DLLIMPORTS.RECT(); //get the size
            DLLIMPORTS.GetWindowRect(handle, ref windowRect);
            width = windowRect.right - windowRect.left;
            height = windowRect.bottom - windowRect.top;
        }
        private void CustomOffsets()
        {
            GetWindowSize();
            width = width - Convert.ToInt32(LeftOffset.Text) - Convert.ToInt32(RightOffset.Text);
            height = height - Convert.ToInt32(UpperOffset.Text) - Convert.ToInt32(LowerOffset.Text);
        }
        private void CustomResolution()
        {
            int customwidth = Convert.ToInt32(CustomWidth.Text);
            int customheight = Convert.ToInt32(CustomHeight.Text);
            if (customheight > 99 && customwidth > 99)
            {
                GetWindowSize();
                offsets[0] = (height - customheight) / 2;
                offsets[1] = (width - customwidth) / 2; 
                width = customwidth;
                height = customheight;
            }
        }
        private void COMPort(bool state)
        {
            if (state)
            {
                SelectionCheck();
                TestButton.Enabled = false;
                if (serial.IsOpen == false) { serial.Open(); while (serial.IsOpen == false) ; }
            }
            else
            {
                TestButton.Enabled = true;
                Thread.Sleep(100);
                serial.Close();
            }
        }
        private void MainCall(bool mode) 
        {
            if (mode == false) while (StartStop.Checked)
            {
                CaptureScreen();
                WakeUp();
                Thread.Sleep(1000 / FPSChanger.Value - timing);
            }
            else while (StartStop.Checked)
            {
                Thread scrcap = new Thread(ScreenCapture) { Priority = ThreadPriority.Highest };
                scrcap.Start();
                WakeUp();
                Thread.Sleep(1000 / FPSChanger.Value);
            }
        }
        private void WakeUp()
        {
            if (PreventAwayMode.Checked) DLLIMPORTS.SetThreadExecutionState(DLLIMPORTS.EXECUTION_STATE.ES_CONTINUOUS | DLLIMPORTS.EXECUTION_STATE.ES_SYSTEM_REQUIRED | DLLIMPORTS.EXECUTION_STATE.ES_DISPLAY_REQUIRED);
            else if (PreventSleep.Checked) DLLIMPORTS.SetThreadExecutionState(DLLIMPORTS.EXECUTION_STATE.ES_CONTINUOUS | DLLIMPORTS.EXECUTION_STATE.ES_SYSTEM_REQUIRED);
        }
        private void ScreenCapture()
        {
            Color color;
            Bitmap bitmap = new Bitmap(width, height);
            Bitmap tempbmp = new Bitmap(LedsX.Value, LedsY.Value);
            Graphics tempbmpgr = Graphics.FromImage(tempbmp);
            Graphics bitmapgr = Graphics.FromImage(bitmap);
            tempbmpgr.InterpolationMode = intrpmode;
            bitmapgr.CopyFromScreen(offsets[1], offsets[0], 0, 0, bitmap.Size); //30ms
            tempbmpgr.DrawImage(bitmap, new Rectangle(0, 0, LedsX.Value, LedsY.Value)); //15-17ms
            for (int y = LedsY.Value - 1; y >= 0; y--)
            {
                color = tempbmp.GetPixel(0, y);
                serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            for (int x = 0; x < LedsX.Value; x++) //these for's take 5-7ms
            {
                color = tempbmp.GetPixel(x, 0);
                serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            for (int y = 0; y < LedsY.Value; y++)
            {
                color = tempbmp.GetPixel(LedsX.Value - 1, y);
                serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            for (int x = LedsX.Value - 1; x >= 0; x--)
            {
                color = tempbmp.GetPixel(x, LedsY.Value - 1);
                serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            GC.Collect();
        }
        private void CaptureScreen()
        {
            Color color;
            Bitmap tempbmp = new Bitmap(LedsX.Value, LedsY.Value);
            Graphics tempbmpgr = Graphics.FromImage(tempbmp);
            Bitmap bmp = ScreenCapturer.MakeScreenshot();
            tempbmpgr.InterpolationMode = intrpmode;
            tempbmpgr.DrawImage(bmp, new Rectangle(0, 0, LedsX.Value, LedsY.Value)); //15-17ms
            for (int y = LedsY.Value - 1; y >= 0; y--)
            {
                color = tempbmp.GetPixel(0, y);
                serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            for (int x = 0; x < LedsX.Value; x++) //these for's take 5-7ms
            {
                color = tempbmp.GetPixel(x, 0);
                serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            for (int y = 0; y < LedsY.Value; y++)
            {
                color = tempbmp.GetPixel(LedsX.Value - 1, y);
                serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            for (int x = LedsX.Value - 1; x >= 0; x--)
            {
                color = tempbmp.GetPixel(x, LedsY.Value - 1);
                serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            GC.Collect();
        }
        private void SelectionCheck()
        {
            if (ComPort.SelectedIndex == -1) ComPort.SelectedIndex = ComPort.Items.Count - 1; //if none selected, then preselect first COM port in list
            if (BaudRate.SelectedIndex == -1) BaudRate.SelectedIndex = BaudRatesList.Length - 5; //if none selected, then preselect 115200 baud
            if (InterpMode.SelectedIndex == -1) InterpMode.SelectedIndex = 7; //if none selected, then preselect Default (the fastest)
            if (CaptureWay.SelectedIndex == -1) CaptureWay.SelectedIndex = 0; //preselect DX11
            if (CaptureArea.SelectedIndex == -1) CaptureArea.SelectedIndex = 0; //preselect fullscreen
            if (AmbilightModes.SelectedIndex == -1) AmbilightModes.SelectedIndex = 0; //preselect single color fade
        }

        //////////////////////////////////////         GUI         /////////////////////////////////////////////////////
        List<MetroButton> buttonlist = new List<MetroButton>();
        public delegate void ColorDelegate(Color clr);
        public void GetColor(Color clr) 
        {
            if (clr != Color.Empty)
            {
                colorarray.Add(clr);
                buttonlist.Add(new MetroButton());
                buttonlist[buttonlist.Count - 1].Style = MetroFramework.MetroColorStyle.Black;
                buttonlist[buttonlist.Count - 1].Theme = MetroFramework.MetroThemeStyle.Dark;
                buttonlist[buttonlist.Count - 1].UseCustomBackColor = true;
                buttonlist[buttonlist.Count - 1].Size = new Size(40, 40);
                buttonlist[buttonlist.Count - 1].Location = new Point(5 + (buttonlist.Count - 1) * 45, 250);
                if (buttonlist.Count == 5) SelectColor.Enabled = false;
                if (colorarray.Count > buttonlist.Count) buttonlist.Remove(buttonlist[buttonlist.Count - 1]);
                else buttonlist[buttonlist.Count - 1].BackColor = colorarray[colorarray.Count - 1];
                buttonlist[buttonlist.Count - 1].Click += new EventHandler(Color_Click);
                ModesTab.Controls.Add(buttonlist[buttonlist.Count - 1]);
            }
        }
        private void Color_Click(object sender, EventArgs e)
        {
            RemoveColor.Show(new Point(MousePosition.X, MousePosition.Y));
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
                ModesTab.Enabled = AreaTab.Enabled = SettingsTab.Enabled = false;
                if (CaptureWay.SelectedIndex == 0)
                {
                    Thread mainthread = new Thread(() => MainCall(false)) { IsBackground = true };
                    mainthread.Start();
                }
                else if (CaptureWay.SelectedIndex == 1)
                {
                    Thread mainthread = new Thread(() => MainCall(true)) { IsBackground = true };
                    mainthread.Start();
                }
            }
            else
            {
                COMPort(false);
                ModesTab.Enabled = AreaTab.Enabled = SettingsTab.Enabled = true;
            }
        }
        private void LEDSHOW_CheckStateChanged(object sender, EventArgs e)
        {
            if (LEDSHOW.Checked)
            {
                COMPort(true);
                HomeTab.Enabled = AreaTab.Enabled = SettingsTab.Enabled = false;
                AmbilightModes.Enabled = false;
                switch (AmbilightModes.SelectedIndex)
                {
                    case 0:
                        RGBEffects = new Thread(FadeInOut) { IsBackground = true, Priority = ThreadPriority.Highest }; 
                        break;
                    case 1:
                        RGBEffects = new Thread(Rainbow) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                    case 2:
                        RGBEffects = new Thread(RainbowCycle) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                    case 3:
                        RGBEffects = new Thread(TheaterChaseRainbow) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                    case 4:
                        RGBEffects = new Thread(FullWhite) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                    case 5:
                        RGBEffects = new Thread(FadeCustom) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                    case 6:
                        RGBEffects = new Thread(CylonBounce) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                    case 7:
                        RGBEffects = new Thread(Twinkle) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                    case 8:
                        RGBEffects = new Thread(TestLEDs) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                }
                RGBEffects.Start();
            }
            else
            {
                RGBEffects.Abort();
                HomeTab.Enabled = AreaTab.Enabled = SettingsTab.Enabled = true;
                AmbilightModes.Enabled = true;
                COMPort(false);
            }
        }
        private void FadeTiming_ValueChanged(object sender, EventArgs e) { fadetiming = FadeTiming.Value; }
        private void TestButton_Click(object sender, EventArgs e)
        {
            COMPort(true);
            if (CaptureWay.SelectedIndex == 0)
            {
                sw.Restart();
                CaptureScreen();
                sw.Stop();
            }
            else
            {
                sw.Restart();
                ScreenCapture();
                sw.Stop();
            }
            COMPort(false);
            timing = Convert.ToInt32(sw.ElapsedMilliseconds);
            FPSChanger.Value = Convert.ToInt32(Math.Floor(1000.0 / timing)); //floors down fps rating, so it will be more likely that there will be only one capturescreen thread running at once
            Default_Timings.Text = "Default: " + FPSChanger.Value + " fps, " + timing + " ms per frame";
        }
        private void RefreshButton_Click(object sender, EventArgs e) { Get_ComPort_Names(); }
        private void ComPort_SelectedIndexChanged_1(object sender, EventArgs e) { if (ComPort.SelectedIndex != -1) serial.PortName = ComPort.Items[ComPort.SelectedIndex].ToString(); }
        private void BaudRate_SelectedIndexChanged_1(object sender, EventArgs e) { if (BaudRate.SelectedIndex != -1) serial.BaudRate = Convert.ToInt32(BaudRate.Items[BaudRate.SelectedIndex]); }
        private void InterpMode_SelectedIndexChanged_1(object sender, EventArgs e) { if (InterpMode.SelectedIndex != -1) intrpmode = (InterpolationMode)InterpMode.Items[InterpMode.SelectedIndex]; }
        private void FPSChanger_ValueChanged(object sender, EventArgs e) { Custom_Timings.Text = "Custom: "  + FPSChanger.Value + " fps, " + 1000 / FPSChanger.Value + " ms per frame"; SetSetting("FPS", FPSChanger.Value.ToString()); }
        private void UpperOffset_TextChanged(object sender, EventArgs e) { if (UpperOffset.Text != "" && CaptureArea.SelectedIndex == 2) { CustomOffsets(); SettingsThread("UpperOffset", UpperOffset.Text); } }
        private void LowerOffset_TextChanged(object sender, EventArgs e) { if (LowerOffset.Text != "" && CaptureArea.SelectedIndex == 2) { CustomOffsets(); SettingsThread("LowerOffset", LowerOffset.Text); } }
        private void LeftOffset_TextChanged(object sender, EventArgs e) { if (LeftOffset.Text != "" && CaptureArea.SelectedIndex == 2) { CustomOffsets(); SettingsThread("LeftOffset", LeftOffset.Text); } }
        private void RightOffset_TextChanged(object sender, EventArgs e) { if (RightOffset.Text != "" && CaptureArea.SelectedIndex == 2) { CustomOffsets(); SettingsThread("RightOffset", RightOffset.Text); } }
        private void CustomWidth_TextChanged(object sender, EventArgs e) { if (CustomWidth.Text != "" && CaptureArea.SelectedIndex == 1) { CustomResolution(); SettingsThread("CustomWidth", CustomWidth.Text); } }
        private void CustomHeight_TextChanged(object sender, EventArgs e) { if (CustomHeight.Text != "" && CaptureArea.SelectedIndex == 1) { CustomResolution(); SettingsThread("CustomHeight", CustomHeight.Text); } }
        private void LedsX_ValueChanged(object sender, EventArgs e) { LedsXLabel.Text = LedsX.Value.ToString(); SettingsThread("LedsX", LedsX.Value.ToString()); }
        private void LedsY_ValueChanged(object sender, EventArgs e) { LedsYLabel.Text = LedsY.Value.ToString(); SettingsThread("LedsY", LedsY.Value.ToString()); }
        private void PreventSleep_CheckedChanged(object sender, EventArgs e) { if (PreventSleep.Checked == true) PreventAwayMode.Enabled = true; else { PreventAwayMode.Checked = false; PreventAwayMode.Enabled = false; } }
        private void CaptureArea_SelectedIndexChanged(object sender, EventArgs e)
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
            }
        }
        private void FillComboBoxes()
        {
            foreach (InterpolationMode interpmode in Enum.GetValues(typeof(InterpolationMode))) if (interpmode != InterpolationMode.Invalid) InterpMode.Items.Add(interpmode); //fetch all possible interpolation modes
            Get_ComPort_Names();
            for (int i = 0; i < BaudRatesList.Length; i++) BaudRate.Items.Add(BaudRatesList[i]);
            CaptureArea.Items.Add("Fullscreen");
            CaptureArea.Items.Add("Custom resolution");
            CaptureArea.Items.Add("Custom offsets");
            ControlTabs.SelectTab(0);
            AmbilightModes.Items.Add("Single Color Fade");
            AmbilightModes.Items.Add("Rainbow");
            AmbilightModes.Items.Add("Rainbow Cycle");
            AmbilightModes.Items.Add("Theater Chase");
            AmbilightModes.Items.Add("Full White");
            AmbilightModes.Items.Add("Multicolor Fade");
            AmbilightModes.Items.Add("Cylon Bounce");
            AmbilightModes.Items.Add("Twinkle");
            AmbilightModes.Items.Add("Test LEDs");
            CaptureWay.Items.Add("DX11");
            CaptureWay.Items.Add("WINAPI");
        }
        public DynamicAmbilight()
        {
            InitializeComponent();
            Init();
            FillComboBoxes();
            SelectionCheck();
        }

        ///////////////////////////////////           LEDS           ///////////////////////////////////////////////////////////////
        List<Color> colorarray = new List<Color>();
        Color[] ledarray = new Color[100]; //should be NumLeds() length
        private int fadetiming = 10;
        private int NumLeds() { return (LedsX.Value + LedsY.Value) * 2; }
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
                WakeUp();
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
            {
                WakeUp();
                for (j = 0; j < 256; j++)
                {
                    for (i = 0; i < NumLeds(); i++) ledarray[i] = Wheel((i + j) & 255);
                    Thread.Sleep(fadetiming);
                    LedShow();
                }
            }
        } 
        public void RainbowCycle()
        {
            int i, j;
            while (LEDSHOW.Checked)
            {
                WakeUp();
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
            {
                WakeUp();
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

        }
        public void FullWhite()
        {
            while (LEDSHOW.Checked)
            {
                WakeUp();
                for (int i = 0; i < NumLeds(); i++) ledarray[i] = Color.FromArgb(255, 255, 255);
                LedShow();
                Thread.Sleep(400);
            }
        }
        public void FadeCustom()
        {
            while (LEDSHOW.Checked && colorarray.Count > 0)
            {
                WakeUp();
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
        }
        public void TestLEDs()
        {
            while (LEDSHOW.Checked && colorarray.Count > 0)
            {
                WakeUp();
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
        }
        public void CylonBounce()
        {
            int EyeSize = 2;
            while (LEDSHOW.Checked && colorarray.Count > 0)
            {
                WakeUp();
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
                WakeUp();
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
