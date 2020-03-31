using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using ScreenCapturerNS;

namespace DynamicAmbilight
{
    public partial class DynamicAmbilight
    {
        private int width, height, timing;
        private int[] offsets = new int[2] { 0, 0 }; //only for custom resolution
        private readonly Stopwatch sw = new Stopwatch();
        private readonly SerialPort serial = new SerialPort() { Parity = (Parity)Enum.Parse(typeof(Parity), "0", true), DataBits = 8, StopBits = (StopBits)Enum.Parse(typeof(StopBits), "1", true), ReadTimeout = 500, WriteTimeout = 500 };
        private readonly string[] BaudRatesList = new string[8] { "5000000", "2000000", "1000000", "921600", "460800", "230400", "115200", "57600" };
        private InterpolationMode intrpmode;

        private Thread SettingsThread(List<KeyValuePair<string, string>> settingslist)
        {
            Thread settingsthread = new Thread(() => SetSetting(settingslist)) { IsBackground = false };
            settingsthread.Start();
            return settingsthread;
        }
        private static void SetSetting(List<KeyValuePair<string, string>> settingslist)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            foreach (KeyValuePair<string, string> pair in settingslist) configuration.AppSettings.Settings[pair.Key].Value = pair.Value;
            configuration.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection("appSettings");
        }
        private List<KeyValuePair<string, string>> SettingsList()
        {
            var settingslist = new List<KeyValuePair<string, string>>()
            {
            new KeyValuePair<string, string>("FPS", FPSChanger.Value.ToString()),
            new KeyValuePair<string, string>("UpperOffset", UpperOffset.Text),
            new KeyValuePair<string, string>("LowerOffset", LowerOffset.Text),
            new KeyValuePair<string, string>("LeftOffset", LeftOffset.Text),
            new KeyValuePair<string, string>("RightOffset", RightOffset.Text),
            new KeyValuePair<string, string>("CustomWidth", CustomWidth.Text),
            new KeyValuePair<string, string>("CustomHeight", CustomHeight.Text),
            new KeyValuePair<string, string>("LedsX", LedsX.Value.ToString()),
            new KeyValuePair<string, string>("LedsY", LedsY.Value.ToString()),
            new KeyValuePair<string, string>("BaudRate", BaudRate.SelectedIndex.ToString()),
            new KeyValuePair<string, string>("InterpolationMode", InterpMode.SelectedIndex.ToString()),
            new KeyValuePair<string, string>("FadeTiming", FadeTiming.Value.ToString()),
            new KeyValuePair<string, string>("AmbilightModes", AmbilightModes.SelectedIndex.ToString()),
            new KeyValuePair<string, string>("CaptureMode", CaptureWay.SelectedIndex.ToString()),
            new KeyValuePair<string, string>("AudioDevice", AudioInputs.SelectedIndex.ToString()),
            new KeyValuePair<string, string>("CaptureArea", CaptureArea.SelectedIndex.ToString()),
            new KeyValuePair<string, string>("PreventSleep", PreventSleep.Checked.ToString()),
            new KeyValuePair<string, string>("PreventAwayMode", PreventAwayMode.Checked.ToString()),
            };
            return settingslist;
        }
        private void Init()
        {
            SystemEvents.PowerModeChanged += OnPowerChange;
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
            BaudRate.SelectedIndex = Convert.ToInt32(ConfigurationManager.AppSettings["BaudRate"]);
            InterpMode.SelectedIndex = Convert.ToInt32(ConfigurationManager.AppSettings["InterpolationMode"]);
            FadeTiming.Value = Convert.ToInt32(ConfigurationManager.AppSettings["FadeTiming"]);
            AmbilightModes.SelectedIndex = Convert.ToInt32(ConfigurationManager.AppSettings["AmbilightModes"]);
            CaptureWay.SelectedIndex = Convert.ToInt32(ConfigurationManager.AppSettings["CaptureMode"]);
            AudioInputs.SelectedIndex = Convert.ToInt32(ConfigurationManager.AppSettings["AudioDevice"]);
            CaptureArea.SelectedIndex = Convert.ToInt32(ConfigurationManager.AppSettings["CaptureArea"]);
            PreventSleep.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["PreventSleep"]);
            PreventAwayMode.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["PreventAwayMode"]);
        }
        private void OnPowerChange(object s, PowerModeChangedEventArgs e)
        {
            if (e.Mode == PowerModes.Suspend) { StartStop.Checked = false; }
            else if (e.Mode == PowerModes.Resume) { StartStop.Checked = true; }
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
                    DXCapture();
                    WakeUp();
                    Thread.Sleep(1000 / FPSChanger.Value - timing);
                }
            else while (StartStop.Checked)
                {
                    Thread scrcap = new Thread(WINAPICapture) { Priority = ThreadPriority.Highest };
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
        private void WINAPICapture()
        {
            Color color;
            Bitmap bitmap = new Bitmap(width, height);
            Bitmap tempbmp = new Bitmap(LedsX.Value, LedsY.Value);
            Graphics tempbmpgr = Graphics.FromImage(tempbmp);
            Graphics bitmapgr = Graphics.FromImage(bitmap);
            tempbmpgr.InterpolationMode = intrpmode;
            bitmapgr.CopyFromScreen(offsets[1], offsets[0], 0, 0, bitmap.Size); //30ms
            tempbmpgr.DrawImage(bitmap, new Rectangle(0, 0, LedsX.Value, LedsY.Value)); //15-17ms
            for (int x = 0; x < LedsX.Value; x++) //these for's take 5-7ms
            {
                color = tempbmp.GetPixel(x, LedsY.Value - 1);
                serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            for (int y = LedsY.Value - 1; y >= 0; y--)
            {
                color = tempbmp.GetPixel(LedsX.Value - 1, y);
                serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            for (int x = LedsX.Value - 1; x >= 0; x--)
            {
                color = tempbmp.GetPixel(x, 0);
                serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            for (int y = 0; y < LedsY.Value; y++)
            {
                color = tempbmp.GetPixel(0, y);
                serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            GC.Collect();
        }
        private void DXCapture()
        {
            Color color;
            Bitmap tempbmp = new Bitmap(LedsX.Value, LedsY.Value);
            Graphics tempbmpgr = Graphics.FromImage(tempbmp);
            Bitmap bmp = ScreenCapturer.MakeScreenshot();
            tempbmpgr.InterpolationMode = intrpmode;
            tempbmpgr.DrawImage(bmp, new Rectangle(0, 0, LedsX.Value, LedsY.Value));
            for (int x = 0; x < LedsX.Value; x++) //these for's take 5-7ms
            {
                color = tempbmp.GetPixel(x, LedsY.Value - 1);
                serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            for (int y = LedsY.Value - 1; y >= 0; y--)
            {
                color = tempbmp.GetPixel(LedsX.Value - 1, y);
                serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            for (int x = LedsX.Value - 1; x >= 0; x--)
            {
                color = tempbmp.GetPixel(x, 0);
                serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            for (int y = 0; y < LedsY.Value; y++)
            {
                color = tempbmp.GetPixel(0, y);
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
            if (AudioInputs.SelectedIndex == -1) AudioInputs.SelectedIndex = 1; //preselect second audio input
        }
    }
}