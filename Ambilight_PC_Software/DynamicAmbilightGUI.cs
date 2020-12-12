using System;
using System.IO.Ports;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using MetroFramework.Forms;
using System.Collections.Generic;
using MetroFramework.Controls;
using NAudio.CoreAudioApi;

namespace DynamicAmbilight
{
    public partial class DynamicAmbilight : MetroForm
    {
        private Thread RGBEffects;
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
                buttonlist[buttonlist.Count - 1].Size = new Size(20, 20);
                buttonlist[buttonlist.Count - 1].Location = new Point((buttonlist.Count - 1) * 25, 280);
                if (buttonlist.Count == 5) SelectColor.Enabled = false;
                if (colorarray.Count > buttonlist.Count) buttonlist.Remove(buttonlist[buttonlist.Count - 1]);
                else buttonlist[buttonlist.Count - 1].BackColor = colorarray[colorarray.Count - 1];
                buttonlist[buttonlist.Count - 1].Click += new EventHandler(Color_Click);
                HomeTab.Controls.Add(buttonlist[buttonlist.Count - 1]);
            }
        }
        private void Color_Click(object sender, EventArgs e) { RemoveColor.Show(new Point(MousePosition.X, MousePosition.Y)); }
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
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            SettingsThread(SettingsList());
            if (e.CloseReason == CloseReason.WindowsShutDown) return;
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
                AreaTab.Enabled = SettingsTab.Enabled = AmbilightModes.Enabled = false;
                switch (AmbilightModes.SelectedIndex)
                {
                    case 0: 
                        RGBEffects = new Thread(DXCapture) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                    case 1:
                        RGBEffects = new Thread(Rainbow) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                    case 2:
                        RGBEffects = new Thread(SingleColor) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                    case 3:
                        RGBEffects = new Thread(FadeInOut) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                    case 4:
                        RGBEffects = new Thread(Sparkle) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                    case 5:
                        RGBEffects = new Thread(TheaterChaseRainbow) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                    case 6:
                        RGBEffects = new Thread(FullWhite) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                    case 7:
                        RGBEffects = new Thread(FadeCustom) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                    case 8:
                        RGBEffects = new Thread(CylonBounce) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                    case 9:
                        RGBEffects = new Thread(Twinkle) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                    case 10:
                        RGBEffects = new Thread(TestLEDs) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                    case 11:
                        RGBEffects = new Thread(AudioPeakMeter) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                    case 12:
                        RGBEffects = new Thread(MultiColorAudioPeakMeter) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                    case 13:
                        RGBEffects = new Thread(FadeAudioPeakMeter) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                    case 14:
                        RGBEffects = new Thread(ColorWipe) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                    case 15:
                        RGBEffects = new Thread(BouncingBall) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                }
                RGBEffects.Start();     
            }
            else
            {
                if (AmbilightModes.SelectedIndex != 0)
                {
                    RGBEffects.Abort();
                    while (!(RGBEffects.ThreadState == ThreadState.Aborted)); 
                    COMPort(false);
                }
                AreaTab.Enabled = SettingsTab.Enabled = AmbilightModes.Enabled = true;
            }
        }
        private void RefreshButton_Click(object sender, EventArgs e) { Get_ComPort_Names(); }
        private void ComPort_SelectedIndexChanged(object sender, EventArgs e) { if (ComPort.SelectedIndex != -1) serial.PortName = ComPort.Items[ComPort.SelectedIndex].ToString(); }
        private void BaudRate_SelectedIndexChanged(object sender, EventArgs e) { if (BaudRate.SelectedIndex != -1) serial.BaudRate = Convert.ToInt32(BaudRate.Items[BaudRate.SelectedIndex]); }
        private void InterpMode_SelectedIndexChanged(object sender, EventArgs e) { if (InterpMode.SelectedIndex != -1) intrpmode = (InterpolationMode)InterpMode.Items[InterpMode.SelectedIndex]; }
        private void LedsX_ValueChanged(object sender, EventArgs e) { LedsXLabel.Text = LedsX.Value.ToString(); }
        private void LedsY_ValueChanged(object sender, EventArgs e) { LedsYLabel.Text = LedsY.Value.ToString(); }
        private void PreventSleep_CheckStateChanged(object sender, EventArgs e) { if (PreventSleep.Checked == true) PreventAwayMode.Enabled = true; else { PreventAwayMode.Checked = false; PreventAwayMode.Enabled = false; } }
        private void CaptureArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CaptureArea.SelectedIndex == 2)
            {
                CustomWidth.Enabled = CustomHeight.Enabled = false;
                UpperOffset.Enabled = LowerOffset.Enabled = LeftOffset.Enabled = RightOffset.Enabled = true;
            }
            else
            {
                UpperOffset.Enabled = LowerOffset.Enabled = LeftOffset.Enabled = RightOffset.Enabled = false; 
                if (CaptureArea.SelectedIndex == 1)
                {
                    CustomWidth.Enabled = CustomHeight.Enabled = true;
                }
                else { CustomWidth.Enabled = CustomHeight.Enabled = false; }
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
        private void UseDefaultAudio_CheckedStateChanged(object sender, EventArgs e)
        {
            if (UseDefaultAudio.Checked) AudioInputs.Enabled = false;
            else AudioInputs.Enabled = true;
        }
        private void AmbilightModes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AmbilightModes.SelectedIndex != 10 && AmbilightModes.SelectedIndex != 11 && AmbilightModes.SelectedIndex != 12) UseDefaultAudio.Enabled = AudioInputs.Enabled = false;
            else UseDefaultAudio.Enabled = AudioInputs.Enabled = true;
        }
        private void FillComboBoxes()
        {
            ControlTabs.SelectTab(0);
            Get_ComPort_Names();
            foreach (InterpolationMode interpmode in Enum.GetValues(typeof(InterpolationMode))) if (interpmode != InterpolationMode.Invalid) InterpMode.Items.Add(interpmode); //fetch all possible interpolation modes
            foreach (MMDevice dev in new MMDeviceEnumerator().EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active)) AudioInputs.Items.Add(dev);
            for (int i = 0; i < BaudRatesList.Length; i++) BaudRate.Items.Add(BaudRatesList[i]);
            CaptureArea.Items.Add("Fullscreen");
            CaptureArea.Items.Add("Custom resolution");
            CaptureArea.Items.Add("Custom offsets");
            AmbilightModes.Items.Add("Dynamic Ambilight");
            AmbilightModes.Items.Add("Rainbow");
            AmbilightModes.Items.Add("Single Color");
            AmbilightModes.Items.Add("Single Color Fade");
            AmbilightModes.Items.Add("Sparkle");
            AmbilightModes.Items.Add("Theater Chase");
            AmbilightModes.Items.Add("Full White");
            AmbilightModes.Items.Add("Multicolor Fade");
            AmbilightModes.Items.Add("Cylon Bounce");
            AmbilightModes.Items.Add("Twinkle");
            AmbilightModes.Items.Add("Test LEDs");
            AmbilightModes.Items.Add("Single Color VU Meter");
            AmbilightModes.Items.Add("Multicolor VU Meter");
            AmbilightModes.Items.Add("Fade VU Meter");
            AmbilightModes.Items.Add("Multicolor Wipe");
            AmbilightModes.Items.Add("Bouncing Ball");
        }
    }
}