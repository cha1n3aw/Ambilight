using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace DynamicAmbilight
{
    public partial class DynamicAmbilight
    {
        List<Color> colorarray = new List<Color>();
        Color[] ledarray = new Color[100]; //should be NumLeds() length
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
        private Color GetBlendedColor(int number)
        {
            if (number >= LedsX.Value / 2 && number < LedsX.Value + LedsY.Value / 2) return Color.FromArgb(Convert.ToInt32(10.2 * (number - 16)), 255, 0); //Convert.ToInt32(255 - 5.1 * (15 - number))
            else if (number >= LedsX.Value + LedsY.Value / 2 && number < LedsX.Value + LedsY.Value + LedsX.Value / 2) return Color.FromArgb(255, Convert.ToInt32(255 - 10.2 * (number - 41)), 0);
            else if (LedsX.Value + LedsY.Value + LedsX.Value / 2 <= number && number < LedsX.Value * 2 + LedsY.Value + LedsY.Value / 2) return Color.FromArgb(255, Convert.ToInt32(255 - 10.2 * (NumLeds() - LedsY.Value / 2 - number)), 0);
            else if (number < LedsX.Value / 2) return Color.FromArgb(Convert.ToInt32(10.2 * (15 - number)), 255, 0); //Convert.ToInt32(255 - 5.1 * (15 - number))
            else return Color.FromArgb(Convert.ToInt32(10.2 * (NumLeds() - 1 + (NumLeds() / 4 - LedsY.Value / 2) - number)), 255, 0);
        }
        private void SingleColor()
        {
            while (StartStop.Checked && colorarray.Count > 0)
            {
                for (int i = 0; i < ledarray.Length; i++) ledarray[i] = Color.FromArgb(Convert.ToInt32(colorarray[0].R), Convert.ToInt32(colorarray[0].G), Convert.ToInt32(colorarray[0].B));
                LedShow();
                Thread.Sleep(1000);
            }
        }
        private void FadeInOut()
        {
            while (StartStop.Checked && colorarray.Count > 0)
            {
                WakeUp();
                for (int k = 0; k < 256; k++) //Fade IN
                {
                    for (int i = 0; i < ledarray.Length; i++) ledarray[i] = Color.FromArgb(Convert.ToInt32((k / 255d) * colorarray[0].R), Convert.ToInt32((k / 255d) * colorarray[0].G), Convert.ToInt32((k / 255d) * colorarray[0].B));
                    LedShow();
                    Thread.Sleep(FadeTiming.Value);
                }
                for (int k = 255; k > -1; k--) //Fade OUT
                {
                    for (int i = 0; i < ledarray.Length; i++) ledarray[i] = Color.FromArgb(Convert.ToInt32((k / 255d) * colorarray[0].R), Convert.ToInt32((k / 255d) * colorarray[0].G), Convert.ToInt32((k / 255d) * colorarray[0].B));
                    LedShow();
                    Thread.Sleep(FadeTiming.Value);
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
                    for (i = 0; i < NumLeds(); i++) ledarray[i] = Wheel((i + j) & 255);
                    Thread.Sleep(FadeTiming.Value);
                    LedShow();
                }
            }
        }
        private void Sparkle()
        {
            int i;
            for (i = 0; i < NumLeds(); i++) ledarray[i] = Color.Black;
            while (StartStop.Checked && colorarray.Count > 0)
            {
                WakeUp();
                Random rnd = new Random();
                int pixel = rnd.Next(0, NumLeds() - 1);
                ledarray[pixel] = colorarray[0];
                LedShow();
                Thread.Sleep(FadeTiming.Value);
                ledarray[pixel] = Color.Black;
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
                        for (int i = 0; i < NumLeds() - 3; i += 3) ledarray[i + q] = Wheel((i + j) % 255);    //turn every third pixel on
                        LedShow();
                        Thread.Sleep(FadeTiming.Value);
                        for (int i = 0; i < NumLeds() - 3; i += 3) ledarray[i + q] = Color.Empty;        //turn every third pixel off
                    }
                }
            }

        }
        private void FullWhite()
        {
            while (StartStop.Checked)
            {
                WakeUp();
                for (int i = 0; i < NumLeds(); i++) ledarray[i] = Color.FromArgb(255, 255, 255);
                LedShow();
                Thread.Sleep(400);
            }
        }
        private void FadeCustom()
        {
            while (StartStop.Checked && colorarray.Count > 0)
            {
                WakeUp();
                for (int j = 0; j < colorarray.Count; j++)
                {
                    for (int k = 0; k < 256; k++)
                    {
                        for (int i = 0; i < ledarray.Length; i++) ledarray[i] = Color.FromArgb(Convert.ToInt32((k / 255d) * colorarray[j].R), Convert.ToInt32((k / 255d) * colorarray[j].G), Convert.ToInt32((k / 255d) * colorarray[j].B));
                        LedShow();
                        Thread.Sleep(FadeTiming.Value);
                    }
                    for (int k = 255; k >= 0; k = k - 2)
                    {
                        for (int i = 0; i < ledarray.Length; i++) ledarray[i] = Color.FromArgb(Convert.ToInt32((k / 255d) * colorarray[j].R), Convert.ToInt32((k / 255d) * colorarray[j].G), Convert.ToInt32((k / 255d) * colorarray[j].B));
                        LedShow();
                        Thread.Sleep(FadeTiming.Value);
                    }
                }
            }
        }
        private void TestLEDs()
        {
            while (StartStop.Checked && colorarray.Count > 0)
            {
                WakeUp();
                for (int i = 0; i < colorarray.Count; i++)
                    for (int j = 0; j < NumLeds(); j++)
                    {
                        for (int k = 0; k < NumLeds(); k++)
                            if (k != j) ledarray[k] = Color.Black;
                            else ledarray[k] = colorarray[i];
                        LedShow();
                        Thread.Sleep(FadeTiming.Value);
                    }
            }
        }
        private void CylonBounce()
        {
            int EyeSize = 2;
            while (StartStop.Checked && colorarray.Count > 0)
            {
                WakeUp();
                for (int i = 0; i < NumLeds() - EyeSize - 1; i++)
                {
                    for (int k = 0; k < NumLeds(); k++) ledarray[k] = Color.Black;
                    ledarray[i] = Color.FromArgb(colorarray[0].R / 10, colorarray[0].G / 10, colorarray[0].B / 10);
                    for (int j = 1; j <= EyeSize; j++) ledarray[i + j] = colorarray[0];
                    ledarray[i + EyeSize + 1] = Color.FromArgb(colorarray[0].R / 10, colorarray[0].G / 10, colorarray[0].B / 10);
                    LedShow();
                    Thread.Sleep(FadeTiming.Value);
                }
                Thread.Sleep(FadeTiming.Value * 2);
                for (int i = NumLeds() - EyeSize - 2; i > -1; i--)
                {
                    for (int k = 0; k < NumLeds(); k++) ledarray[k] = Color.Black;
                    ledarray[i] = Color.FromArgb(colorarray[0].R / 10, colorarray[0].G / 10, colorarray[0].B / 10);
                    for (int j = 1; j <= EyeSize; j++) ledarray[i + j] = colorarray[0];
                    ledarray[i + EyeSize + 1] = Color.FromArgb(colorarray[0].R / 10, colorarray[0].G / 10, colorarray[0].B / 10);
                    LedShow();
                    Thread.Sleep(FadeTiming.Value);
                }
                Thread.Sleep(FadeTiming.Value * 2);
            }
        }
        private void Twinkle()
        {
            int Count = 10;
            while (StartStop.Checked && colorarray.Count > 0)
            {
                WakeUp();
                Random random = new Random();
                for (int k = 0; k < NumLeds(); k++) ledarray[k] = Color.Black;
                LedShow();
                for (int i = 0; i < Count; i++)
                {
                    ledarray[random.Next(NumLeds() - 1)] = colorarray[random.Next(colorarray.Count - 1)];
                    LedShow();
                    Thread.Sleep(FadeTiming.Value);
                }
                Thread.Sleep(FadeTiming.Value * 10);
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
            while (StartStop.Checked && colorarray.Count > 0)
            {
                WakeUp();
                int leftVolume = Convert.ToInt32(device.AudioMeterInformation.PeakValues[0] * NumLeds() / 2);
                int rightVolume = Convert.ToInt32(device.AudioMeterInformation.PeakValues[1] * NumLeds() / 2);
                for (int i = LedsX.Value / 2 - 1; i >= 0; i--) if (LedsX.Value / 2 - 1 - i < leftVolume) ledarray[i] = colorarray[0]; else ledarray[i] = Color.Black;
                for (int i = NumLeds() - 1; i > NumLeds() - LedsY.Value - (LedsX.Value / 2) - 1; i--) if (NumLeds() - 1 - i < leftVolume - (LedsX.Value / 2)) ledarray[i] = colorarray[0]; else ledarray[i] = Color.Black;
                for (int i = LedsX.Value / 2; i < NumLeds() - LedsY.Value - (LedsX.Value / 2); i++) if (i - LedsX.Value / 2 < rightVolume) ledarray[i] = colorarray[0]; else ledarray[i] = Color.Black;
                LedShow();
                Thread.Sleep(FadeTiming.Value);
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
                for (int i = LedsX.Value / 2 - 1; i >= 0; i--) if (LedsX.Value / 2 - 1 - i < leftVolume) ledarray[i] = GetBlendedColor(i); else ledarray[i] = Color.Black;
                for (int i = NumLeds() - 1; i > NumLeds() - LedsY.Value - (LedsX.Value / 2) - 1; i--) if (NumLeds() - 1 - i < leftVolume - (LedsX.Value / 2)) ledarray[i] = GetBlendedColor(i); else ledarray[i] = Color.Black;
                for (int i = LedsX.Value / 2; i < NumLeds() - LedsY.Value - (LedsX.Value / 2); i++) if (i - LedsX.Value / 2 < rightVolume) ledarray[i] = GetBlendedColor(i); else ledarray[i] = Color.Black;
                LedShow();
                Thread.Sleep(FadeTiming.Value);
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
                for (int i = LedsX.Value / 2 - 1; i >= 0; i--) ledarray[i] = GetBlendedColor(leftVolume);
                for (int i = NumLeds() - 1; i > NumLeds() - LedsY.Value - (LedsX.Value / 2) - 1; i--) ledarray[i] = GetBlendedColor(leftVolume);
                for (int i = LedsX.Value / 2; i < NumLeds() - LedsY.Value - (LedsX.Value / 2); i++) ledarray[i] = GetBlendedColor(rightVolume);
                LedShow();
                Thread.Sleep(FadeTiming.Value);
            }
        }
        private void ColorWipe()
        {
            for (int i = 0; i < ledarray.Length; i++) ledarray[i] = Color.Black;
            while (StartStop.Checked && colorarray.Count > 0)
            for (int i = 0; i < colorarray.Count; i++)
            {
                for (int j = 0; j < NumLeds(); j++) { ledarray[j] = colorarray[i]; LedShow(); Thread.Sleep(FadeTiming.Value); }
                Thread.Sleep(FadeTiming.Value);
            }
        }
        private void BouncingBall()
        {
            while (StartStop.Checked && colorarray.Count > 0)
            {
                for (int c = 0; c < colorarray.Count; c++)
                {
                    double[] damp = new double[2] { Convert.ToDouble(new Random().Next(80, 98)) / 100d, Convert.ToDouble(new Random().Next(81, 98)) / 100d };
                    //double[] damp = new double[2] { 0.85, 0.95 };
                    double gravity = -9.81;
                    double impactonstart = Math.Sqrt(-2 * gravity);
                    sw.Restart();
                    double[] height = new double[2];
                    double[] lastbounce = new double[2];
                    double[] impact = new double[2] { impactonstart, impactonstart};
                    long[] ClockTimeSinceLastBounce = new long[2] { sw.ElapsedMilliseconds, sw.ElapsedMilliseconds };
                    while (impact[0] > 0.1 || impact[1] > 0.1)
                    {
                        for (int i = 0; i < ledarray.Length; i++) ledarray[i] = Color.Black;
                        for (int i = 0; i < 2; i++) lastbounce[i] = sw.ElapsedMilliseconds - ClockTimeSinceLastBounce[i];
                        for (int i = 0; i < 2; i++) height[i] = 0.5 * gravity * Math.Pow(lastbounce[i] / 1000, 2.0) + impact[i] * lastbounce[i] / 1000;
                        for (int i = 0; i < 2; i++)
                            if (height[i] < 0)
                            {
                                height[i] = 0;
                                impact[i] = damp[i] * impact[i];
                                ClockTimeSinceLastBounce[i] = sw.ElapsedMilliseconds;
                            }
                        ledarray[(int)(height[0] * LedsY.Value) + 32] = colorarray[c];
                        ledarray[NumLeds() - 1 - (int)(height[1] * LedsY.Value)] = colorarray[c];
                        LedShow();
                    }
                    sw.Stop();
                }
            }
        }
    }
}