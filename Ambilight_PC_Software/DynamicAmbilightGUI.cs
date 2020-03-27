using System;
using System.IO.Ports;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using MetroFramework.Forms;
using System.Collections.Generic;
using MetroFramework.Controls;

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
                buttonlist[buttonlist.Count - 1].Size = new Size(40, 40);
                buttonlist[buttonlist.Count - 1].Location = new Point((buttonlist.Count - 1) * 45, 215);
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
                AreaTab.Enabled = SettingsTab.Enabled = AmbilightModes.Enabled = TestButton.Enabled = false;
                switch (AmbilightModes.SelectedIndex)
                {
                    case 0: if (CaptureWay.SelectedIndex == 0) RGBEffects = new Thread(() => MainCall(false)) { IsBackground = true, Priority = ThreadPriority.Highest };
                            else if (CaptureWay.SelectedIndex == 1) RGBEffects = new Thread(() => MainCall(true)) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                    case 1:
                        RGBEffects = new Thread(FadeInOut) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                    case 2:
                        RGBEffects = new Thread(Rainbow) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                    case 3:
                        RGBEffects = new Thread(RainbowCycle) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                    case 4:
                        RGBEffects = new Thread(TheaterChaseRainbow) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                    case 5:
                        RGBEffects = new Thread(FullWhite) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                    case 6:
                        RGBEffects = new Thread(FadeCustom) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                    case 7:
                        RGBEffects = new Thread(CylonBounce) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                    case 8:
                        RGBEffects = new Thread(Twinkle) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                    case 9:
                        RGBEffects = new Thread(TestLEDs) { IsBackground = true, Priority = ThreadPriority.Highest };
                        break;
                }
                RGBEffects.Start();     
            }
            else
            {
                if (AmbilightModes.SelectedIndex != 0) RGBEffects.Abort();
                AreaTab.Enabled = SettingsTab.Enabled = AmbilightModes.Enabled = TestButton.Enabled = true;
                COMPort(false);
            }
        }
        private void TestButton_Click(object sender, EventArgs e)
        {
            COMPort(true);
            if (CaptureWay.SelectedIndex == 0)
            {
                sw.Restart();
                DXCapture();
                sw.Stop();
            }
            else
            {
                sw.Restart();
                WINAPICapture();
                sw.Stop();
            }
            COMPort(false);
            timing = Convert.ToInt32(sw.ElapsedMilliseconds);
            FPSChanger.Value = Convert.ToInt32(Math.Floor(1000.0 / timing)); //floors down fps rating, so it will be more likely that there will be only one capturescreen thread running at once
            Default_Timings.Text = "Default: " + FPSChanger.Value + " fps, " + timing + " ms per frame";
        }
        private void RefreshButton_Click(object sender, EventArgs e) { Get_ComPort_Names(); }
        private void ComPort_SelectedIndexChanged(object sender, EventArgs e) { if (ComPort.SelectedIndex != -1) serial.PortName = ComPort.Items[ComPort.SelectedIndex].ToString(); }
        private void BaudRate_SelectedIndexChanged(object sender, EventArgs e) { if (BaudRate.SelectedIndex != -1) serial.BaudRate = Convert.ToInt32(BaudRate.Items[BaudRate.SelectedIndex]); }
        private void InterpMode_SelectedIndexChanged(object sender, EventArgs e) { if (InterpMode.SelectedIndex != -1) intrpmode = (InterpolationMode)InterpMode.Items[InterpMode.SelectedIndex]; }
        private void FPSChanger_ValueChanged(object sender, EventArgs e) { Custom_Timings.Text = "Custom: "  + FPSChanger.Value + " fps, " + 1000 / FPSChanger.Value + " ms per frame"; }
        private void UpperOffset_TextChanged(object sender, EventArgs e) { if (UpperOffset.Text != "" && CaptureArea.SelectedIndex == 2) CustomOffsets(); }
        private void LowerOffset_TextChanged(object sender, EventArgs e) { if (LowerOffset.Text != "" && CaptureArea.SelectedIndex == 2) CustomOffsets(); }
        private void LeftOffset_TextChanged(object sender, EventArgs e) { if (LeftOffset.Text != "" && CaptureArea.SelectedIndex == 2)  CustomOffsets(); } 
        private void RightOffset_TextChanged(object sender, EventArgs e) { if (RightOffset.Text != "" && CaptureArea.SelectedIndex == 2)  CustomOffsets(); } 
        private void CustomWidth_TextChanged(object sender, EventArgs e) { if (CustomWidth.Text != "" && CaptureArea.SelectedIndex == 1)  CustomResolution(); } 
        private void CustomHeight_TextChanged(object sender, EventArgs e) { if (CustomHeight.Text != "" && CaptureArea.SelectedIndex == 1)  CustomResolution(); } 
        private void LedsX_ValueChanged(object sender, EventArgs e) { LedsXLabel.Text = LedsX.Value.ToString(); }
        private void LedsY_ValueChanged(object sender, EventArgs e) { LedsYLabel.Text = LedsY.Value.ToString(); }
        private void PreventSleep_CheckStateChanged(object sender, EventArgs e) { if (PreventSleep.Checked == true) PreventAwayMode.Enabled = true; else { PreventAwayMode.Checked = false; PreventAwayMode.Enabled = false; } }
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
            AmbilightModes.Items.Add("Dynamic Ambilight");
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
            FillComboBoxes();
            Init();
            SelectionCheck();
        }
    }
}

/*
private void CaptureScreen()
{
    const int numAdapter = 0; // # of graphics card adapter
    const int numOutput = 0; // # of output device (i.e. monitor)
    Factory1 factory = new Factory1(); // Create DXGI Factory1
    Adapter1 adapter = factory.GetAdapter1(numAdapter);
    Device device = new Device(adapter); // Create device from Adapter
    Output output = adapter.GetOutput(numOutput); // Get DXGI.Output
    Output1 output1 = output.QueryInterface<Output1>();

    // Create Staging texture CPU-accessible
    Texture2DDescription textureDesc = new Texture2DDescription
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
    Texture2D screenTexture = new Texture2D(device, textureDesc);
    // Duplicate the output
    var duplicatedOutput = output1.DuplicateOutput(device);

    bool captureDone = false;
    while(!captureDone)
    {
        SharpDX.DXGI.Resource screenResource;
        OutputDuplicateFrameInformation duplicateFrameInformation;

        // Try to get duplicated frame within given time
        duplicatedOutput.AcquireNextFrame(5, out duplicateFrameInformation, out screenResource);
        try
        {
            // copy resource into memory that can be accessed by the CPU
            using (var screenTexture2D = screenResource.QueryInterface<Texture2D>())
                device.ImmediateContext.CopyResource(screenTexture2D, screenTexture);

            // Get the desktop capture texture
            var mapSource = device.ImmediateContext.MapSubresource(screenTexture, 0, MapMode.Read, MapFlags.None);

            // Create Drawing.Bitmap
            var bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            var boundsRect = new Rectangle(0, 0, width, height);

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


            bitmap.UnlockBits(mapDest); // Release source and dest locks
            device.ImmediateContext.UnmapSubresource(screenTexture, 0);

            bitmap.Save("bitmap.bmp");
            captureDone = true;
            screenResource.Dispose();
            duplicatedOutput.ReleaseFrame();

        }
        catch (SharpDXException e)
        {
            if (e.ResultCode.Code != SharpDX.DXGI.ResultCode.WaitTimeout.Result.Code)
            {
                Debug.WriteLine(e);
                //throw e;
            }
        }
    }
    GC.Collect();
    // Display the texture using system associated viewer
    //Process.Start(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, outputFileName)));
}

class DXCapture
{
    bool ready = false;
    bool Recording = false;
    Task RecordingTask;
    int saveSizeX;
    int saveSizeY;
    int width = 1920;
    int height = 1080;
    int numAdapter;
    int numOutput;
    Factory1 factory;
    Adapter1 adapter;
    SharpDX.Direct3D11.Device device;
    Output output;
    Output1 output1;
    Texture2DDescription texture2DDescription;
    Texture2D screenTexture;
    OutputDuplication duplicatedOutput;
    SharpDX.DXGI.Resource screenResource;


    public DXCapture(int sizeX = 1920, int sizeY = 1080, int numAdapter = 0, int numOutput = 0)
    {
        this.saveSizeX = sizeX;
        this.saveSizeY = sizeY;
        this.numAdapter = numAdapter;
        this.numOutput = numOutput;
        InitDX();
    }

    public void InitDX()
    {
        try
        {
            factory = new SharpDX.DXGI.Factory1();
            adapter = factory.GetAdapter1(numAdapter);
            device = new SharpDX.Direct3D11.Device(adapter);
            output = adapter.GetOutput(numOutput);
            output1 = output.QueryInterface<Output1>();

            // Width/Height of desktop to capture
            width = output.Description.DesktopBounds.Left + output.Description.DesktopBounds.Right;
            height = output.Description.DesktopBounds.Top + output.Description.DesktopBounds.Bottom;

            texture2DDescription = new Texture2DDescription
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

            screenTexture = new Texture2D(device, texture2DDescription);
            duplicatedOutput = output1.DuplicateOutput(device);
            screenResource = null;
            ready = true;
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public void DisposeDX()
    {
        factory.Dispose();
        factory = null;
        adapter.Dispose();
        adapter = null;
        device.Dispose();
        device = null;
        output.Dispose();
        output = null;
        output1.Dispose();
        output1 = null;

        screenTexture.Dispose();
        screenTexture = null;
        duplicatedOutput.Dispose();
        duplicatedOutput = null;
        GC.Collect();
    }

    public void GetShot()
    {

        while(true)
        {
            try
            {
                OutputDuplicateFrameInformation duplicateFrameInformation;

                SharpDX.DXGI.Resource screenResource = null;

                // Try to get duplicated frame within given time
                duplicatedOutput.TryAcquireNextFrame(10, out duplicateFrameInformation, out screenResource);

                // copy resource into memory that can be accessed by the CPU
                using (var screenTexture2D = screenResource.QueryInterface<Texture2D>())
                {
                    device.ImmediateContext.CopyResource(screenTexture2D, screenTexture);
                }
                // Get the desktop capture texture
                var mapSource = device.ImmediateContext.MapSubresource(screenTexture, 0, MapMode.Read, SharpDX.Direct3D11.MapFlags.None);
                var boundsRect = new System.Drawing.Rectangle(0, 0, width, height);

                Task.Factory.StartNew(() =>
                {
                // Create Drawing.Bitmap
                using (var bitmap = new System.Drawing.Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
                    {
                    // Copy pixels from screen capture Texture to GDI bitmap
                    var bitmapData = bitmap.LockBits(boundsRect, ImageLockMode.WriteOnly, bitmap.PixelFormat);
                        var sourcePtr = mapSource.DataPointer;
                        var destinationPtr = bitmapData.Scan0;
                        for (int y = 0; y < height; y++)
                        {
                        // Copy a single line 
                        Utilities.CopyMemory(destinationPtr, sourcePtr, width * 4);

                        // Advance pointers
                        sourcePtr = IntPtr.Add(sourcePtr, mapSource.RowPitch);
                            destinationPtr = IntPtr.Add(destinationPtr, bitmapData.Stride);
                        }

                    // Release source and dest locks
                    bitmap.UnlockBits(bitmapData);

                        device.ImmediateContext.UnmapSubresource(screenTexture, 0);

                    // instant preview in picture box


                    // save the bitmap image
                    // ...
                }

                });// end task bitmap creation

            }
            catch (SharpDXException e)
            {
                if (e.ResultCode.Code == SharpDX.DXGI.ResultCode.AccessLost.Result.Code)
                {
                    Console.WriteLine("Error GetShot ACCESS LOST - relaunch in 2s !");
                    Thread.Sleep(2000);
                    DisposeDX();
                    GC.Collect();
                    InitDX();
                }
                else if (e.ResultCode.Code != SharpDX.DXGI.ResultCode.WaitTimeout.Result.Code)
                {
                    Console.WriteLine("Error GetShot");
                    throw;
                }
            }
            finally
            {
                try
                {
                    // Dispose manually
                    if (screenResource != null)
                    {
                        screenResource.Dispose();
                        screenResource = null;
                        duplicatedOutput.ReleaseFrame();
                    }

                    // force the Garbage Collector to cleanup memory to prevent memory leaks
                    Task.Factory.StartNew(() => { GC.Collect(); });
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error GetShot finally - relaunch in 2s !");
                    Thread.Sleep(2000);
                    DisposeDX();
                    GC.Collect();
                    InitDX();
                }
            }
        }
    }

    public void ScreenShot()
    {
        if (ready)
        {
            GetShot();
        }
    }

    public void StartRecord()
    {
        if (!Recording)
        {
            Recording = true;
            RecordingTask = new Task(() =>
            {
                Stopwatch sww = new Stopwatch();
                while (Recording)
                {
                    sww.Restart();
                    GetShot();
                    sww.Stop();
                    Debug.WriteLine(sww.ElapsedMilliseconds.ToString());
                }

            });

            RecordingTask.Start();
        }

    }

    public void StopRecord()
    {
        Recording = false;
    }

}
*/
/*
public byte[] GetScreenData()
{

    // We want to copy the texture from the back buffer so 
    // we don't hog it.
    Texture2DDescription desc  = new Texture2DDescription
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
    desc.CpuAccessFlags = CpuAccessFlags.Read;
    desc.Usage = ResourceUsage.Staging;
    desc.OptionFlags = ResourceOptionFlags.None;
    desc.BindFlags = BindFlags.None;

    byte[] data = null;

    using (var texture = new Texture2D(DeviceDirect3D, desc))
    {
        DeviceContextDirect3D.CopyResource(BackBuffer, texture);

        using (Surface surface = texture.QueryInterface<Surface>())
        {
            DataStream dataStream;
            var map = surface.Map(SharpDX.DXGI.MapFlags.Read, out dataStream);
            int lines = (int)(dataStream.Length / map.Pitch);
            data = new byte[surface.Description.Width * surface.Description.Height * 4];

            int dataCounter = 0;
            // width of the surface - 4 bytes per pixel.
            int actualWidth = surface.Description.Width * 4;
            for (int y = 0; y < lines; y++)
            {
                for (int x = 0; x < map.Pitch; x++)
                {
                    if (x < actualWidth)
                    {
                        data[dataCounter++] = dataStream.Read<byte>();
                    }
                    else
                    {
                        dataStream.Read<byte>();
                    }
                }
            }
            dataStream.Dispose();
            surface.Unmap();
        }
    }

    return data;
}

*/

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
                if (e.ResultCode.Code != SharpDX.DXGI.ResultCode.FadeTiming.ValueTimeout.Result.Code)
                {
                    //Trace.TraceError(e.Message);
                    //Trace.TraceError(e.StackTrace);
                }
            }
            bitmap.Dispose();
            GC.Collect(); //manual exec of garbage collection, prevents RAM overflow (its god damn fast on 20+ FPSChanger.Value)
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
                    if (e.ResultCode.Code != SharpDX.DXGI.ResultCode.FadeTiming.ValueTimeout.Result.Code)
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
            GC.Collect(); //manual exec of garbage collection, prevents RAM overflow (its god damn fast on 20+ FPSChanger.Value)
            Thread.Sleep(0); //to let other threads do their job, in case this thread is alive for too long
        }
        */
