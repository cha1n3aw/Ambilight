using NAudio.CoreAudioApi;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace DynamicAmbilight
{
    public partial class DynamicAmbilight
    {
        private Color[] LedArray = new Color[100]; //should be NumLeds() length
        private int NumLeds() { return (LedsX.Value + LedsY.Value) * 2; }
        private void LedShow() { Color clr; for (int i = 0; i < LedArray.Length; i++) { clr = LedArray[i]; SerialPort.Write(new byte[] { clr.R, clr.G, clr.B }, 0, 3); } }
        private Color Wheel(int WheelPos)
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
        private Color GetBlendedColor(int number)
        {
            if (number >= LedsX.Value / 2 && number < LedsX.Value + LedsY.Value / 2) return Color.FromArgb(Convert.ToInt32(10.2 * (number - 16)), 255, 0); //Convert.ToInt32(255 - 5.1 * (15 - number))
            else if (number >= LedsX.Value + LedsY.Value / 2 && number < LedsX.Value + LedsY.Value + LedsX.Value / 2) return Color.FromArgb(255, Convert.ToInt32(255 - 10.2 * (number - 41)), 0);
            else if (LedsX.Value + LedsY.Value + LedsX.Value / 2 <= number && number < LedsX.Value * 2 + LedsY.Value + LedsY.Value / 2) return Color.FromArgb(255, Convert.ToInt32(255 - 10.2 * (NumLeds() - LedsY.Value / 2 - number)), 0);
            else if (number < LedsX.Value / 2) return Color.FromArgb(Convert.ToInt32(10.2 * (15 - number)), 255, 0); //Convert.ToInt32(255 - 5.1 * (15 - number))
            else return Color.FromArgb(Convert.ToInt32(10.2 * (NumLeds() - 1 + (NumLeds() / 4 - LedsY.Value / 2) - number)), 255, 0);
        }
        private int GetSelectedColorsCount()
        {
            int count = 0;
            ColorSelection.Invoke((MethodInvoker)delegate { count = ColorSelection.Items.Count; });
            return count;
        }
        private object GetSelectedObject()
        {
            object obj = null;
            ColorSelection.Invoke((MethodInvoker)delegate { obj = ColorSelection.SelectedItem; });
            return obj;
        }
        private ComboBox.ObjectCollection GetObjects()
        {
            ComboBox.ObjectCollection obj = null;
            ColorSelection.Invoke((MethodInvoker)delegate { obj = ColorSelection.Items; });
            return obj;
        }
        private void HappyNewYear()
        {
            while (StartStop.Checked)
            {
                for (int itt = 0; itt < 4; itt++)
                {
                    WakeUp();
                    for (int i = 0; i < LedArray.Length; i++)
                    {
                        if (i % 16 < 4 && itt == 0) LedArray[i] = Color.Green;
                        else if (i % 16 < 8 && itt == 1) LedArray[i] = Color.Red;
                        else if (i % 16 < 12 && itt == 2) LedArray[i] = Color.Yellow;
                        else if (i % 16 < 16 && itt == 3) LedArray[i] = Color.Blue;
                    }
                    LedShow();
                    Thread.Sleep(1000);
                } 
            }
        }
        private void SingleColor()
        {
            while (StartStop.Checked && GetSelectedObject() != null)
            {
                WakeUp();
                for (int i = 0; i < LedArray.Length; i++) LedArray[i] = Color.FromArgb(Convert.ToInt32(((Color)GetSelectedObject()).R * Timing / 1000), Convert.ToInt32(((Color)GetSelectedObject()).G * Timing / 1000), Convert.ToInt32(((Color)GetSelectedObject()).B * Timing / 1000));
                LedShow();
                Thread.Sleep(500);
            }
        }
        private void FadeInOut()
        {
            while (StartStop.Checked && GetSelectedObject() != null)
            {
                WakeUp();
                for (int k = 0; k < 256; k++) //Fade IN
                {
                    for (int i = 0; i < LedArray.Length; i++) LedArray[i] = Color.FromArgb(Convert.ToInt32((k / 255d) * ((Color)GetSelectedObject()).R), Convert.ToInt32((k / 255d) * ((Color)GetSelectedObject()).G), Convert.ToInt32((k / 255d) * ((Color)GetSelectedObject()).B));
                    LedShow();
                    Thread.Sleep((int)Timing);
                }
                for (int k = 255; k > -1; k--) //Fade OUT
                {
                    for (int i = 0; i < LedArray.Length; i++) LedArray[i] = Color.FromArgb(Convert.ToInt32((k / 255d) * ((Color)GetSelectedObject()).R), Convert.ToInt32((k / 255d) * ((Color)GetSelectedObject()).G), Convert.ToInt32((k / 255d) * ((Color)GetSelectedObject()).B));
                    LedShow();
                    Thread.Sleep((int)Timing);
                }
            }
        }
        private void Rainbow()
        {
            int i, j;
            while (StartStop.Checked)
            {
                WakeUp();
                for (j = 0; j < 256; j++)
                {
                    for (i = 0; i < NumLeds(); i++) LedArray[i] = Wheel((i + j) & 255);
                    Thread.Sleep((int)Timing);
                    LedShow();
                }
            }
        }
        private void Sparkle()
        {
            int i;
            for (i = 0; i < NumLeds(); i++) LedArray[i] = Color.Black;
            while (StartStop.Checked && GetSelectedObject() != null)
            {
                WakeUp();
                Random rnd = new Random();
                int pixel = rnd.Next(0, NumLeds() - 1);
                LedArray[pixel] = (Color)GetSelectedObject();
                LedShow();
                Thread.Sleep((int)Timing);
                LedArray[pixel] = Color.Black;
            }
        }
        private void TheaterChaseRainbow()
        {
            while (StartStop.Checked)
            {
                WakeUp();
                for (int j = 0; j < 256; j++)
                {     // cycle all 256 colors in the wheel
                    for (int q = 0; q < 3; q++)
                    {
                        for (int i = 0; i < NumLeds() - 3; i += 3) LedArray[i + q] = Wheel((i + j) % 255);    //turn every third pixel on
                        LedShow();
                        Thread.Sleep((int)Timing);
                        for (int i = 0; i < NumLeds() - 3; i += 3) LedArray[i + q] = Color.Empty;        //turn every third pixel off
                    }
                }
            }

        }
        private void FullWhite()
        {
            while (StartStop.Checked)
            {
                WakeUp();
                for (int i = 0; i < NumLeds(); i++) LedArray[i] = Color.FromArgb(255, 255, 255);
                LedShow();
                Thread.Sleep(400);
            }
        }
        private void MultiColorFade()
        {
            while (StartStop.Checked && GetSelectedObject() != null)
            {
                WakeUp();
                for (int j = 0; j < GetSelectedColorsCount(); j++)
                {
                    for (int k = 0; k < 256; k++)
                    {
                        for (int i = 0; i < LedArray.Length; i++) LedArray[i] = Color.FromArgb(Convert.ToInt32((k / 255d) * ((Color)GetObjects()[j]).R), Convert.ToInt32((k / 255d) * ((Color)GetObjects()[j]).G), Convert.ToInt32((k / 255d) * ((Color)GetObjects()[j]).B));
                        LedShow();
                        Thread.Sleep((int)Timing);
                    }
                    for (int k = 255; k >= 0; k = k - 2)
                    {
                        for (int i = 0; i < LedArray.Length; i++) LedArray[i] = Color.FromArgb(Convert.ToInt32((k / 255d) * ((Color)GetObjects()[j]).R), Convert.ToInt32((k / 255d) * ((Color)GetObjects()[j]).G), Convert.ToInt32((k / 255d) * ((Color)GetObjects()[j]).B));
                        LedShow();
                        Thread.Sleep((int)Timing);
                    }
                }
            }
        }
        private void TestLEDs()
        {
            while (StartStop.Checked && GetSelectedObject() != null)
            {
                WakeUp();
                for (int i = 0; i < GetSelectedColorsCount(); i++)
                    for (int j = 0; j < NumLeds(); j++)
                    {
                        for (int k = 0; k < NumLeds(); k++)
                            if (k != j) LedArray[k] = Color.Black;
                            else LedArray[k] = (Color)GetObjects()[i];
                        LedShow();
                        Thread.Sleep((int)Timing);
                    }
            }
        }
        private void CylonBounce()
        {
            int EyeSize = 2;
            while (StartStop.Checked && GetSelectedObject() != null)
            {
                WakeUp();
                for (int i = 0; i < NumLeds() - EyeSize - 1; i++)
                {
                    for (int k = 0; k < NumLeds(); k++) LedArray[k] = Color.Black;
                    LedArray[i] = Color.FromArgb(((Color)GetSelectedObject()).R / 10, ((Color)GetSelectedObject()).G / 10, ((Color)GetSelectedObject()).B / 10);
                    for (int j = 1; j <= EyeSize; j++) LedArray[i + j] = (Color)GetSelectedObject();
                    LedArray[i + EyeSize + 1] = Color.FromArgb(((Color)GetSelectedObject()).R / 10, ((Color)GetSelectedObject()).G / 10, ((Color)GetSelectedObject()).B / 10);
                    LedShow();
                    Thread.Sleep((int)Timing);
                }
                Thread.Sleep((int)Timing * 2);
                for (int i = NumLeds() - EyeSize - 2; i > -1; i--)
                {
                    for (int k = 0; k < NumLeds(); k++) LedArray[k] = Color.Black;
                    LedArray[i] = Color.FromArgb(((Color)GetSelectedObject()).R / 10, ((Color)GetSelectedObject()).G / 10, ((Color)GetSelectedObject()).B / 10);
                    for (int j = 1; j <= EyeSize; j++) LedArray[i + j] = (Color)GetSelectedObject();
                    LedArray[i + EyeSize + 1] = Color.FromArgb(((Color)GetSelectedObject()).R / 10, ((Color)GetSelectedObject()).G / 10, ((Color)GetSelectedObject()).B / 10);
                    LedShow();
                    Thread.Sleep((int)Timing);
                }
                Thread.Sleep((int)Timing * 2);
            }
        }
        private void Twinkle()
        {
            int Count = 10;
            while (StartStop.Checked && GetSelectedObject() != null)
            {
                WakeUp();
                Random random = new Random();
                for (int k = 0; k < NumLeds(); k++) LedArray[k] = Color.Black;
                LedShow();
                for (int i = 0; i < Count; i++)
                {
                    LedArray[random.Next(NumLeds() - 1)] = (Color)GetObjects()[random.Next(GetSelectedColorsCount() - 1)];
                    LedShow();
                    Thread.Sleep((int)Timing);
                }
                Thread.Sleep((int)Timing * 10);
            }
        }
        private void AudioPeakMeter()
        {
            int num = 0;
            MMDevice device;
            MMDeviceEnumerator devEnum = new MMDeviceEnumerator();
            AudioInputs.Invoke(new Action(() => num = AudioInputs.SelectedIndex));
            if (UseDefaultAudio.Checked) device = devEnum.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            else device = devEnum.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active)[num];
            while (StartStop.Checked && GetSelectedObject() != null)
            {
                WakeUp();
                int leftVolume = Convert.ToInt32(device.AudioMeterInformation.PeakValues[0] * NumLeds() / 2);
                int rightVolume = Convert.ToInt32(device.AudioMeterInformation.PeakValues[1] * NumLeds() / 2);
                for (int i = LedsX.Value / 2 - 1; i >= 0; i--) if (LedsX.Value / 2 - 1 - i < leftVolume) LedArray[i] = (Color)GetSelectedObject(); else LedArray[i] = Color.Black;
                for (int i = NumLeds() - 1; i > NumLeds() - LedsY.Value - (LedsX.Value / 2) - 1; i--) if (NumLeds() - 1 - i < leftVolume - (LedsX.Value / 2)) LedArray[i] = (Color)GetSelectedObject(); else LedArray[i] = Color.Black;
                for (int i = LedsX.Value / 2; i < NumLeds() - LedsY.Value - (LedsX.Value / 2); i++) if (i - LedsX.Value / 2 < rightVolume) LedArray[i] = (Color)GetSelectedObject(); else LedArray[i] = Color.Black;
                LedShow();
                Thread.Sleep((int)Timing);
            }
        }
        private void MultiColorAudioPeakMeter()
        {
            MMDevice device;
            MMDeviceEnumerator devEnum = new MMDeviceEnumerator();
            if (UseDefaultAudio.Checked) device = devEnum.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            else device = (MMDevice)AudioInputs.SelectedItem;
            while (StartStop.Checked)
            {
                WakeUp();
                int leftVolume = Convert.ToInt32(device.AudioMeterInformation.PeakValues[0] * NumLeds() / 2);
                int rightVolume = Convert.ToInt32(device.AudioMeterInformation.PeakValues[1] * NumLeds() / 2);
                for (int i = LedsX.Value / 2 - 1; i >= 0; i--) if (LedsX.Value / 2 - 1 - i < leftVolume) LedArray[i] = GetBlendedColor(i); else LedArray[i] = Color.Black;
                for (int i = NumLeds() - 1; i > NumLeds() - LedsY.Value - (LedsX.Value / 2) - 1; i--) if (NumLeds() - 1 - i < leftVolume - (LedsX.Value / 2)) LedArray[i] = GetBlendedColor(i); else LedArray[i] = Color.Black;
                for (int i = LedsX.Value / 2; i < NumLeds() - LedsY.Value - (LedsX.Value / 2); i++) if (i - LedsX.Value / 2 < rightVolume) LedArray[i] = GetBlendedColor(i); else LedArray[i] = Color.Black;
                LedShow();
                Thread.Sleep((int)Timing);
            }
        }
        private void FadeAudioPeakMeter()
        {
            int num = 0;
            MMDevice device;
            MMDeviceEnumerator devEnum = new MMDeviceEnumerator();
            AudioInputs.Invoke(new Action(() => num = AudioInputs.SelectedIndex));
            if (UseDefaultAudio.Checked) device = devEnum.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            else device = devEnum.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active)[num];
            while (StartStop.Checked)
            {
                WakeUp();
                int leftVolume = Convert.ToInt32(device.AudioMeterInformation.PeakValues[0] * NumLeds() / 2);
                int rightVolume = Convert.ToInt32(device.AudioMeterInformation.PeakValues[1] * NumLeds() / 2);
                for (int i = LedsX.Value / 2 - 1; i >= 0; i--) LedArray[i] = GetBlendedColor(leftVolume);
                for (int i = NumLeds() - 1; i > NumLeds() - LedsY.Value - (LedsX.Value / 2) - 1; i--) LedArray[i] = GetBlendedColor(leftVolume);
                for (int i = LedsX.Value / 2; i < NumLeds() - LedsY.Value - (LedsX.Value / 2); i++) LedArray[i] = GetBlendedColor(rightVolume);
                LedShow();
                Thread.Sleep((int)Timing);
            }
        }
        private void ColorWipe()
        {
            WakeUp();
            for (int i = 0; i < LedArray.Length; i++) LedArray[i] = Color.Black;
            while (StartStop.Checked && GetSelectedObject() != null)
            {
                WakeUp();
                for (int i = 0; i < GetSelectedColorsCount(); i++)
                {
                    for (int j = 0; j < NumLeds(); j++) { LedArray[j] = (Color)GetObjects()[i]; LedShow(); Thread.Sleep((int)Timing); }
                    Thread.Sleep((int)Timing);
                }
            } 
        }
        private void BouncingBall()
        {
            Stopwatch sww = new Stopwatch();
            while (StartStop.Checked && GetSelectedObject() != null)
            {
                WakeUp();
                for (int c = 0; c < GetSelectedColorsCount(); c++)
                {
                    double[] damp = new double[2] { Convert.ToDouble(new Random().Next(80, 98)) / 100d, Convert.ToDouble(new Random().Next(81, 98)) / 100d };
                    double gravity = -9.81;
                    double impactonstart = Math.Sqrt(-2 * gravity);
                    sww.Restart();
                    double[] height = new double[2];
                    double[] lastbounce = new double[2];
                    double[] impact = new double[2] { impactonstart, impactonstart};
                    long[] ClockTimeSinceLastBounce = new long[2] { sww.ElapsedMilliseconds, sww.ElapsedMilliseconds };
                    while (impact[0] > 0.1 || impact[1] > 0.1)
                    {
                        for (int i = 0; i < LedArray.Length; i++) LedArray[i] = Color.Black;
                        for (int i = 0; i < 2; i++) lastbounce[i] = sww.ElapsedMilliseconds - ClockTimeSinceLastBounce[i];
                        for (int i = 0; i < 2; i++) height[i] = 0.5 * gravity * Math.Pow(lastbounce[i] / 1000, 2.0) + impact[i] * lastbounce[i] / 1000;
                        for (int i = 0; i < 2; i++)
                            if (height[i] < 0)
                            {
                                height[i] = 0;
                                impact[i] = damp[i] * impact[i];
                                ClockTimeSinceLastBounce[i] = sww.ElapsedMilliseconds;
                            }
                        LedArray[(int)(height[0] * LedsY.Value) + 32] = (Color)GetObjects()[c];
                        LedArray[NumLeds() - 1 - (int)(height[1] * LedsY.Value)] = (Color)GetObjects()[c];
                        LedShow();
                    }
                    sww.Stop();
                }
            }
        }
    }
}