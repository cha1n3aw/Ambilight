using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using SharpDX;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using Device = SharpDX.Direct3D11.Device;
using MapFlags = SharpDX.Direct3D11.MapFlags;

namespace DynamicAmbilight
{
    public partial class DynamicAmbilight
    {
        private event EventHandler<EventArgs> ScreenRefreshed;
        private long cnt = 0, prevms = 0;
        private readonly Stopwatch sw = new Stopwatch();
        private SerialPort serial = new SerialPort() { Parity = (Parity)Enum.Parse(typeof(Parity), "0", true), DataBits = 8, StopBits = (StopBits)Enum.Parse(typeof(StopBits), "1", true), ReadTimeout = 500, WriteTimeout = 500 };
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
            System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            foreach (KeyValuePair<string, string> pair in settingslist) configuration.AppSettings.Settings[pair.Key].Value = pair.Value;
            configuration.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection("appSettings");
        }
        private List<KeyValuePair<string, string>> SettingsList()
        {
            var settingslist = new List<KeyValuePair<string, string>>()
            {
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
        private void COMPort(bool state)
        {
            if (state && !serial.IsOpen) { serial.Open(); while (serial.IsOpen == false) ; Debug.WriteLine("SERIAL OPENED"); }
            else { serial.Close(); while (serial.IsOpen == true) ; Debug.WriteLine("SERIAL CLOSED"); }
        }
        private void WakeUp()
        {
            if (PreventAwayMode.Checked) DLLIMPORTS.SetThreadExecutionState(DLLIMPORTS.EXECUTION_STATE.ES_CONTINUOUS | DLLIMPORTS.EXECUTION_STATE.ES_SYSTEM_REQUIRED | DLLIMPORTS.EXECUTION_STATE.ES_DISPLAY_REQUIRED);
            else if (PreventSleep.Checked) DLLIMPORTS.SetThreadExecutionState(DLLIMPORTS.EXECUTION_STATE.ES_CONTINUOUS | DLLIMPORTS.EXECUTION_STATE.ES_SYSTEM_REQUIRED);
        }
        private void DXCapture()
        {
            const int numAdapter = 0; // # of graphics card adapter
            const int numOutput = 0; // # of output device (i.e. monitor)
            var factory = new Factory1(); // Create DXGI Factory1
            var adapter = factory.GetAdapter1(numAdapter); //Console.WriteLine(factory.GetAdapterCount());
            var device = new Device(adapter); // Create device from Adapter //foreach (Adapter adapters in factory.Adapters) Console.WriteLine(adapters.Description.Description);
            var output = adapter.GetOutput(numOutput); // Get DXGI.Output  //foreach (Output outputs in adapter.Outputs) Console.WriteLine(outputs.Description.DeviceName);
            var output1 = output.QueryInterface<Output1>();
            int width = output.Description.DesktopBounds.Right; // Width/Height of desktop to capture
            int height = output.Description.DesktopBounds.Bottom;
            var textureDesc = new Texture2DDescription // Create Staging texture CPU-accessible
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
            var duplicatedOutput = output1.DuplicateOutput(device); // Duplicate the output
            int ledsx = LedsX.Value;
            int ledsy = LedsY.Value;
            int leftoffset = 0, upperoffset = 0, customwidth = width, customheight = height;
            int index = 0;
            CaptureArea.Invoke((MethodInvoker)delegate { index = CaptureArea.SelectedIndex; });
            if (index == 1)
            {
                leftoffset = (width - Convert.ToInt32(CustomWidth.Text)) / 2;
                upperoffset = (height - Convert.ToInt32(CustomHeight.Text)) / 2;
                customwidth = Convert.ToInt32(CustomWidth.Text);
                customheight = Convert.ToInt32(CustomHeight.Text);
            }
            else if (index == 2)
            {
                leftoffset = Convert.ToInt32(LeftOffset.Text);
                upperoffset = Convert.ToInt32(UpperOffset.Text);
                customwidth = width - leftoffset - Convert.ToInt32(RightOffset.Text);
                customheight = height - upperoffset - Convert.ToInt32(LowerOffset.Text);
            }
            bool init = false;
            sw.Start();
            Task.Factory.StartNew(() =>
            {
                while (StartStop.Checked && serial.IsOpen)
                {
                    WakeUp();
                    try
                    {
                        duplicatedOutput.AcquireNextFrame(100, out OutputDuplicateFrameInformation duplicateFrameInformation, out SharpDX.DXGI.Resource screenResource); // Try to get duplicated frame within given time
                        if (init)
                        {
                            using (var screenTexture2D = screenResource.QueryInterface<Texture2D>()) device.ImmediateContext.CopyResource(screenTexture2D, screenTexture); // copy resource into memory that can be accessed by the CPU
                            var mapSource = device.ImmediateContext.MapSubresource(screenTexture, 0, MapMode.Read, MapFlags.None); // Get the desktop capture texture
                            var bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb); // Create Drawing.Bitmap
                            var boundsRect = new Rectangle(0, 0, width, height);
                            var mapDest = bitmap.LockBits(boundsRect, ImageLockMode.WriteOnly, bitmap.PixelFormat); // Copy pixels from screen capture Texture to GDI bitmap
                            var sourcePtr = mapSource.DataPointer;
                            var destPtr = mapDest.Scan0;
                            for (int y = 0; y < height; y++)
                            {
                                Utilities.CopyMemory(destPtr, sourcePtr, width * 4); // Copy a single line 
                                sourcePtr = IntPtr.Add(sourcePtr, mapSource.RowPitch); // Advance pointers
                                destPtr = IntPtr.Add(destPtr, mapDest.Stride);
                            }
                            bitmap.UnlockBits(mapDest); // Release source and dest locks
                            device.ImmediateContext.UnmapSubresource(screenTexture, 0);
                            using (var tempbmp = new Bitmap(ledsx, ledsy, PixelFormat.Format32bppRgb))
                            {
                                Graphics tempbmpgr = Graphics.FromImage(tempbmp);
                                tempbmpgr.InterpolationMode = intrpmode; //nearest nighbour, low, default, bicubic, bilinear, 
                                tempbmpgr.DrawImage(bitmap, new Rectangle(0, 0, ledsx, ledsy), leftoffset, upperoffset, customwidth, customheight, GraphicsUnit.Pixel);
                                Color color;
                                for (int x = 0; x < ledsx; x++) //these for's take 5-7ms
                                {
                                    color = tempbmp.GetPixel(x, ledsy - 1);
                                    serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
                                }
                                for (int y = ledsy - 1; y >= 0; y--)
                                {
                                    color = tempbmp.GetPixel(ledsx - 1, y);
                                    serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
                                }
                                for (int x = ledsx - 1; x >= 0; x--)
                                {
                                    color = tempbmp.GetPixel(x, 0);
                                    serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
                                }
                                for (int y = 0; y < ledsy; y++)
                                {
                                    color = tempbmp.GetPixel(0, y);
                                    serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
                                }
                                ScreenRefreshed?.Invoke(this, EventArgs.Empty);
                                GC.Collect();
                            }
                        }
                        init = true;
                        screenResource.Dispose();
                        duplicatedOutput.ReleaseFrame();
                    }
                    catch (SharpDXException) { }
                }
                if (!StartStop.Checked)
                {
                    sw.Stop();
                    serial.Close();
                    duplicatedOutput.Dispose();
                    screenTexture.Dispose();
                }
            });
            GC.Collect();
        }
        private void SelectionCheck()
        {
            if (ComPort.SelectedIndex == -1) ComPort.SelectedIndex = ComPort.Items.Count - 1; //if none selected, then preselect first COM port in list
            if (BaudRate.SelectedIndex == -1) BaudRate.SelectedIndex = BaudRatesList.Length - 5; //if none selected, then preselect 115200 baud
            if (InterpMode.SelectedIndex == -1) InterpMode.SelectedIndex = 7; //if none selected, then preselect Default (the fastest)
            if (CaptureArea.SelectedIndex == -1) CaptureArea.SelectedIndex = 0; //preselect fullscreen
            if (AmbilightModes.SelectedIndex == -1) AmbilightModes.SelectedIndex = 0; //preselect single color fade
            if (AudioInputs.SelectedIndex == -1) AudioInputs.SelectedIndex = 1; //preselect second audio input
        }
    }
}