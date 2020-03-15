using System;
using System.IO.Ports;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace Ambilight
{
    public partial class Dynamic_Ambilight : Form
    {
        private int fps = 10, timing;
        private bool state = false;
        const int timingtests = 5; //startup tests amount
        private readonly Stopwatch sw = new Stopwatch(); //stopwatch is being used once on startup, it determines how much time does one iteration take
        private readonly String[] BaudRatesList = new string[8] { "5000000", "2000000", "1000000", "921600", "460800", "230400", "115200", "57600" };
        private SerialPort serial = new SerialPort() { Parity = (Parity)Enum.Parse(typeof(Parity), "0", true), DataBits = 8, StopBits = (StopBits)Enum.Parse(typeof(StopBits), "1", true), ReadTimeout = 500, WriteTimeout = 500 };
        Thread thread;
        InterpolationMode intrpmode;

        private void Main() //this thread is forever alive, it execs capturethread every 1000/fps milliseconds, so stable desired fps can be achieved
        {
            while (true) //also it's used like that 'cause it's easy to call for abort() for this thread
            {
                Thread CaptureThread = new Thread(CaptureScreen);
                CaptureThread.Start();
                Thread.Sleep(1000 / fps); //this acts like a delay between frames, so desired fps will be stable and interping is being done every x milliseconds
            }
        }
        private void CaptureScreen() //this thread captures screen and calls for interp method
        {
            Bitmap srcbmp = new Bitmap(1920, 1200); //custom resolutions are going to be implemented soon
            Bitmap tempbmp = new Bitmap(1, 1);
            Color color;
            Graphics intrp = Graphics.FromImage(tempbmp);
            intrp.InterpolationMode = intrpmode;
            Graphics.FromImage(srcbmp).CopyFromScreen(0, 0, 0, 0, srcbmp.Size);
            int x, y;
            for (y = 1140; y > -1; y -= 60) //no corners are interpolated (because they were captured in horizontal part)
            {
                intrp.DrawImage(srcbmp, new Rectangle(0, 0, 1, 1), 1860, y, 60, 60, GraphicsUnit.Pixel); //interp right vertical border
                color = tempbmp.GetPixel(0, 0); //gets the color of interpolated 1x1 bitmap
                serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            for (x = 1860; x > -1; x -= 60) //both horizontal borders are interpolated, no corners are interpolated
            {
                intrp.DrawImage(srcbmp, new Rectangle(0, 0, 1, 1), x, 0, 60, 60, GraphicsUnit.Pixel); //interp upper horizontal border
                color = tempbmp.GetPixel(0, 0); //gets the color of interpolated 1x1 bitmap
                serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            for (y = 0; y < 1200; y += 60) //no corners are interpolated (because they were captured in horizontal part)
            {
                intrp.DrawImage(srcbmp, new Rectangle(0, 0, 1, 1), 0, y, 60, 60, GraphicsUnit.Pixel); ; //interp left vertical border
                color = tempbmp.GetPixel(0, 0); //gets the color of interpolated 1x1 bitmap
                serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            for (x = 0; x < 1920; x += 60) //both horizontal borders are interpolated, no corners are interpolated
            { 
                intrp.DrawImage(srcbmp, new Rectangle(0, 0, 1, 1), x, 1140, 60, 60, GraphicsUnit.Pixel); //interp lower horizontal border
                color = tempbmp.GetPixel(0, 0); //gets the color of interpolated 1x1 bitmap
                serial.Write(new byte[] { color.R, color.G, color.B }, 0, 3);
            }
            GC.Collect(); //manual exec of garbage collection, prevents RAM overflow (its god damn fast on 20+ fps)
            Thread.Sleep(0); //to let other threads do their job, in case this thread is alive for too long
        }
        private void Start_Stop_Clicked(object sender, EventArgs e)
        {
            if (!state)
            {
                StartStopButton.Text = "Stop";
                Selection_Check();
                ComPort.Enabled = BaudRate.Enabled = InterpMode.Enabled = TestButton.Enabled = false;
                if (serial.IsOpen == false) { serial.Open(); while (serial.IsOpen == false) ; };
                thread = new Thread(Main); //starts up a new thread, which is forever alive (ot till the Abort() will be executed)
                thread.Start();
                state = true;
            }
            else
            {
                thread.Abort();
                ComPort.Enabled = BaudRate.Enabled = InterpMode.Enabled = TestButton.Enabled = true;
                StartStopButton.Text = "Start";
                state = false;
                Thread.Sleep(100);
                serial.Close();
            }
        }
        private void FPS_Spinbox_Changed(object sender, EventArgs e) //spinbox to set custom fps, just an easy feature
        {
            fps = Convert.ToInt32(FPS_Spinbox.Value);
            Custom_Timings.Text = "Custom: " + 1000 / fps + " ms per frame, " + fps + " fps";
        }
        private void Refresh_Clicked(object sender, EventArgs e) { Get_ComPort_Names(); }
        private void Selection_Check()
        {
            if (this.ComPort.SelectedIndex == -1) ComPort.SelectedIndex = ComPort.Items.Count - 1; //if none selected, then preselect first COM port in list
            if (this.BaudRate.SelectedIndex == -1) BaudRate.SelectedIndex = BaudRatesList.Length - 2; //if none selected, then preselect 115200 baud
            if (this.InterpMode.SelectedIndex == -1) InterpMode.SelectedIndex = 0;//if none selected, then preselect Default (the fastest)
        }
        private void Test_Clicked(object sender, EventArgs e)
        {
            Selection_Check();
            serial.Open();
            while (serial.IsOpen == false) ; //waits till the port will open, it takes around 50ms actually
            sw.Restart(); //start timer to check capturescreen timing
            for (int i = 0; i < timingtests; i++) CaptureScreen(); //it performs 5 (or any custom timingtests value) iterations of capturescreen
            sw.Stop();
            serial.Close();
            timing = Convert.ToInt32(sw.ElapsedMilliseconds / timingtests);
            fps = Convert.ToInt32(Math.Floor(1000.0 / timing)); //floors down fps rating, so it will be more likely that there will be only one capturescreen thread running at once
            Default_Timings.Text = "Default: " + timing + " ms per frame, " + fps + " fps";
            if (fps > 0) FPS_Spinbox.Value = fps;
        }
        private void Get_ComPort_Names()
        {
            ComPort.Items.Clear();
            foreach (string comportname in SerialPort.GetPortNames()) ComPort.Items.Add(comportname); //fetch comports that present in system
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (this.WindowState.Equals(FormWindowState.Minimized)) { Hide(); Tray_Icon.ShowBalloonTip(2000); }
        }
        private void Tray_Icon_BalloonTipClicked(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }
        private void Tray_Icon_Click(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }
        private void ComPort_SelectedIndexChanged(object sender, EventArgs e) { if (ComPort.SelectedIndex != -1) serial.PortName = ComPort.Items[ComPort.SelectedIndex].ToString(); }//choose desired COM port online from list of availaible ports
        private void BaudRate_SelectedIndexChanged(object sender, EventArgs e) { if (ComPort.SelectedIndex != -1) serial.BaudRate = Convert.ToInt32(BaudRate.Items[BaudRate.SelectedIndex]); }
        private void InterpMode_SelectedIndexChanged(object sender, EventArgs e) { if (ComPort.SelectedIndex != -1) intrpmode = (InterpolationMode)InterpMode.Items[InterpMode.SelectedIndex]; }
        public Dynamic_Ambilight()
        {
            InitializeComponent();
            foreach (InterpolationMode interpmode in Enum.GetValues(typeof(InterpolationMode))) if (interpmode != InterpolationMode.Invalid) InterpMode.Items.Add(interpmode); //fetch all possible interpolation modes
            Get_ComPort_Names();
            for (int i = 0; i < BaudRatesList.Length; i++) BaudRate.Items.Add(BaudRatesList[i]);
            FPS_Spinbox.Value = fps;
        }
    }
}
