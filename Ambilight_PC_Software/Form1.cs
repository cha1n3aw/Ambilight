using System;
using System.IO.Ports;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Linq;



namespace Ambilight
{
    public partial class Form1 : Form
    {
        private int fps = 1, timing;
        const int timingtests = 5; //startup tests amount
        private readonly Stopwatch sw = new Stopwatch(); //stopwatch is being used once on startup, it determines how much time does one iteration take
        private readonly String[] BaudRatesList = new string[8] { "5000000", "2000000", "1000000", "921600‬", "460800", "230400", "115200", "57600" };
        private SerialPort serial = new SerialPort() { Parity = (Parity)Enum.Parse(typeof(Parity), "0", true), DataBits = 8, StopBits = (StopBits)Enum.Parse(typeof(StopBits), "1", true), ReadTimeout = 500, WriteTimeout = 500 };
        Thread thread;
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
            intrp.InterpolationMode = InterpolationMode.Bicubic;
            Graphics.FromImage(srcbmp).CopyFromScreen(0, 0, 0, 0, srcbmp.Size);
            for (int y = 1200; y > 0; y -= 60) //no corners are interpolated (because they were captured in horizontal part)
            {
                intrp.DrawImage(srcbmp, new Rectangle(0, 0, 1, 1), 0, y, 30, 60, GraphicsUnit.Pixel); ; //interp left vertical border
                color = tempbmp.GetPixel(0, 0); //gets the color of interpolated 1x1 bitmap
                serial.Write(new byte[] { color.G, color.R, color.B }, 0, 3); //not R G B due to weird ws2812b G R B bytes layout
            }
            for (int x = 0; x < 1920; x += 60) //both horizontal borders are interpolated, no corners are interpolated
            {
                intrp.DrawImage(srcbmp, new Rectangle(0, 0, 1, 1), x, 355, 60, 30, GraphicsUnit.Pixel); //interp upper horizontal border
                color = tempbmp.GetPixel(0, 0); //gets the color of interpolated 1x1 bitmap
                serial.Write(new byte[] { color.G, color.R, color.B }, 0, 3);
            }
            for (int y = 0; y < 1200; y += 60) //no corners are interpolated (because they were captured in horizontal part)
            {
                intrp.DrawImage(srcbmp, new Rectangle(0, 0, 1, 1), 1860, y, 30, 60, GraphicsUnit.Pixel); //interp right vertical border
                color = tempbmp.GetPixel(0, 0); //gets the color of interpolated 1x1 bitmap
                serial.Write(new byte[] { color.G, color.R, color.B }, 0, 3);
            }
            for (int x = 1920; x > 0; x -= 60) //both horizontal borders are interpolated, no corners are interpolated
            { 
                intrp.DrawImage(srcbmp, new Rectangle(0, 0, 1, 1), x, 1140, 60, 30, GraphicsUnit.Pixel); //interp lower horizontal border
                color = tempbmp.GetPixel(0, 0); //gets the color of interpolated 1x1 bitmap
                serial.Write(new byte[] { color.G, color.R, color.B }, 0, 3);
            }
            GC.Collect(); //manual exec of garbage collection, prevents RAM overflow (its god damn fast on 20+ fps)
            Thread.Sleep(0); //to let other threads do their job, in case this thread is alive for too long
        }
        private void Start_Clicked(object sender, EventArgs e)
        {
            if (serial.IsOpen == false) { serial.Open(); while (serial.IsOpen == false); };
            thread = new Thread(Main); //starts up a new thread, which is forever alive (ot till the Abort() will be executed)
            if (!((thread.ThreadState & (System.Threading.ThreadState.Stopped | System.Threading.ThreadState.Unstarted)) == 0)) thread.Start(); //kinda useless check, it makes no sense but imo this check should be here :)
        }
        private void Abort_Clicked(object sender, EventArgs e) //stop capturing and interpolating screen
        {
            thread.Abort();
            Thread.Sleep(100);
            serial.Close();
        }
        private void FPS_Spinbox_Changed(object sender, EventArgs e) //spinbox to set custom fps, just an easy feature
        {
            fps = Convert.ToInt32(FPS_Spinbox.Value);
            Custom_Timings.Text = "Custom: " + 1000 / fps + " ms per frame, " + fps + " fps";
        }
        private void ComPortName_Selection_Changed(object sender, EventArgs e) //choose desired COM port online from list of availaible ports
        { 
            serial.PortName = SelectComPort.Items[SelectComPort.SelectedIndex].ToString(); 
        }

        private void BaudRate_Selection_Changed(object sender, EventArgs e)
        {
            serial.BaudRate = Convert.ToInt32(SelectBaudRate.Items[SelectBaudRate.SelectedIndex]);
        }

        private void Test_Clicked(object sender, EventArgs e)
        {
            if (this.SelectComPort.SelectedIndex == -1) SelectComPort.SetSelected(0, true); //if none selected, then preselect first COM port in list (so timing checks wont fail)
            if (this.SelectBaudRate.SelectedIndex == -1) SelectBaudRate.SetSelected(7, true); //if none selected, then preselect lowest baudrate 57600 (so timing checks wont fail)
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

        public Form1()
        {
            InitializeComponent();
            foreach (string comportname in SerialPort.GetPortNames()) SelectComPort.Items.Add(comportname); //fetch comports that present in system
            for (int i = 0; i < BaudRatesList.Length; i++) SelectBaudRate.Items.Add(BaudRatesList[i]);
        }
    }
}
