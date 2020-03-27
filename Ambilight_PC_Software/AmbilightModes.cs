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
        public void FadeInOut()
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
        public void Rainbow()
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
        public void RainbowCycle()
        {
            int i, j;
            while (StartStop.Checked)
            {
                WakeUp();
                for (j = 0; j < 256 * 5; j++)
                {
                    for (i = 0; i < NumLeds(); i++) ledarray[i] = Wheel((i * 256 / NumLeds() + j) & 255);
                    Thread.Sleep(FadeTiming.Value);
                    LedShow();
                }
            }
        }
        public void TheaterChaseRainbow()
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
        public void FullWhite()
        {
            while (StartStop.Checked)
            {
                WakeUp();
                for (int i = 0; i < NumLeds(); i++) ledarray[i] = Color.FromArgb(255, 255, 255);
                LedShow();
                Thread.Sleep(400);
            }
        }
        public void FadeCustom()
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
        public void TestLEDs()
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
        public void CylonBounce()
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
        public void Twinkle()
        {
            int Count = 10;
            while (StartStop.Checked && colorarray.Count > 0)
            {
                WakeUp();
                var random = new Random();
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
    }
}