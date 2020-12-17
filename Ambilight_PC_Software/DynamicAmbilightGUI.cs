using System;
using System.IO.Ports;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using MetroFramework.Forms;
using NAudio.CoreAudioApi;
using System.Diagnostics;

namespace DynamicAmbilight
{
    public partial class DynamicAmbilight : MetroForm
    {
        private Thread RGBEffects;
        private double Timing = 0;
        private bool ColorDeletion = false;
        public delegate void ColorDelegate(Color clr);
        public void GetColor(Color color) 
        {
            if (color != Color.Empty)
            {
                ColorSelection.Items.Add(color);
                ColorSelection.SelectedIndex = ColorSelection.Items.Count - 1;
            }
        }
        private void RefreshComPorts()
        {
            ComPort.Items.Clear();
            foreach (string comportname in SerialPort.GetPortNames()) ComPort.Items.Add(comportname); //fetch comports that present in system
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (WindowState == FormWindowState.Minimized) { Hide(); openToolStripMenuItem.Text = "Show"; Tray_Icon.BalloonTipTitle = "Hey, I'm here!"; Tray_Icon.BalloonTipText = "Click here to restore"; Tray_Icon.ShowBalloonTip(1000); }
            else openToolStripMenuItem.Text = "Hide";
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
                SelectColor.Enabled = ColorSelection.Enabled = AreaTab.Enabled = SettingsTab.Enabled = AmbilightModes.Enabled = false;
                switch (AmbilightModes.SelectedIndex)
                {
                    case 0:
                        { RGBEffects = new Thread(DXCapture) { IsBackground = true, Priority = ThreadPriority.Highest }; FadeTiming.Enabled = false; }
                        break;
                    case 1:
                        RGBEffects = new Thread(Rainbow) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                    case 2:
                        { RGBEffects = new Thread(SingleColor) { IsBackground = true, Priority = ThreadPriority.Highest }; FadeTiming.Enabled = false; }
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
                        { RGBEffects = new Thread(FullWhite) { IsBackground = true, Priority = ThreadPriority.Highest }; FadeTiming.Enabled = false; }
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
                        { RGBEffects = new Thread(AudioPeakMeter) { IsBackground = true, Priority = ThreadPriority.Highest }; FadeTiming.Enabled = false; }
                    break;
                    case 12:
                        { RGBEffects = new Thread(MultiColorAudioPeakMeter) { IsBackground = true, Priority = ThreadPriority.Highest }; FadeTiming.Enabled = false; }
                        break;
                    case 13:
                        { RGBEffects = new Thread(FadeAudioPeakMeter) { IsBackground = true, Priority = ThreadPriority.Highest }; FadeTiming.Enabled = false; }
                        break;
                    case 14:
                        RGBEffects = new Thread(ColorWipe) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                    case 15:
                        { RGBEffects = new Thread(BouncingBall) { IsBackground = true, Priority = ThreadPriority.Highest }; FadeTiming.Enabled = false; }
                    break;
                }
                RGBEffects.Start();     
            }
            else
            {
                if (AmbilightModes.SelectedIndex != 0)
                {
                    RGBEffects.Abort();
                    while (!(RGBEffects.ThreadState == System.Threading.ThreadState.Aborted)); 
                    COMPort(false);
                }
                else Default_Timings.Text = "Press Start Up!";
                FadeTiming.Enabled = SelectColor.Enabled = ColorSelection.Enabled = AreaTab.Enabled = SettingsTab.Enabled = AmbilightModes.Enabled = true;
            }
        }
        private void RefreshButton_Click(object sender, EventArgs e) { RefreshComPorts(); }
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
                if (CaptureArea.SelectedIndex == 1) CustomWidth.Enabled = CustomHeight.Enabled = true;
                else CustomWidth.Enabled = CustomHeight.Enabled = false;
            }
        }
        private void SelectColor_Click(object sender, EventArgs e) { new ColorPicker(new ColorDelegate(GetColor)).Show(); }
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
            ColorSelection.UseCustomBackColor = false;
            ControlTabs.SelectTab(0);
            RefreshComPorts();
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
        private void ColorSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ColorDeletion)
            {
                ColorSelection.BackColor = (Color)ColorSelection.SelectedItem;
                ColorSelection.UseCustomBackColor = true;
            }
            else
            {
                int i = ColorSelection.SelectedIndex;
                Debug.WriteLine(i);
                ColorSelection.Items.RemoveAt(ColorSelection.SelectedIndex);
                if (ColorSelection.Items.Count < 1) ColorSelection.UseCustomBackColor = false;
                else if (ColorSelection.Items.Count <= i) ColorSelection.BackColor = (Color)ColorSelection.Items[i - 1];
                else ColorSelection.BackColor = (Color)ColorSelection.Items[i]; 
            }
        }
        private void ColorDeletionPressed(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Delete && !ColorDeletion) ColorDeletion = true; }
        private void ColorDeletionReleased(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Delete && ColorDeletion) ColorDeletion = false; }
        private void StartStopFromTrayClicked(object sender, EventArgs e)
        {
            if(!StartStop.Checked)
            {
                StartStop.Checked = true;
                startToolStripMenuItem.Text = "Stop";
            }
            else
            {
                StartStop.Checked = false;
                startToolStripMenuItem.Text = "Start";
            }
        }
        private void OpenFromTrayClicked(object sender, EventArgs e) 
        {
            if (WindowState == FormWindowState.Minimized) { Show(); WindowState = FormWindowState.Normal; }
            else if (WindowState == FormWindowState.Normal) { WindowState = FormWindowState.Minimized; }
        }
        private void ExitFromTrayClicked(object sender, EventArgs e) { Close(); }
        private void FadeTimingValueChanged(object sender, EventArgs e)
        {
            Timing = FadeTiming.Value * FadeTiming.Value / 1000.0;
            if (Timing < 10) FadeTimingTip.SetToolTip(FadeTiming, (Math.Round(Timing, 1)).ToString());
            else FadeTimingTip.SetToolTip(FadeTiming, ((int)Timing).ToString());
        }
    }
}