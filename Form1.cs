using System;
using System.IO.Ports;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace WindowsForm1
{
    public partial class Form1 : Form
    {
        private int fps, timing;
        int timingtests = 5; //startup tests amount
        private readonly Stopwatch sw = new Stopwatch(); //stopwatch is being used once on startup, it determines how much time does one iteration take
        //private readonly Random rnd = new Random(); //currently unused, was used as a source of random names for files
        private List<int[]> colorarray = new List<int[]>(); //this list contains int{ r, g, b } arrays
        private SerialPort serial = new SerialPort() { PortName = "COM6", BaudRate = 230400, Parity = (Parity)Enum.Parse(typeof(Parity), "0", true), DataBits = 7, StopBits = (StopBits)Enum.Parse(typeof(StopBits), "1", true), ReadTimeout = 500, WriteTimeout = 500 };
        Thread thread;
        private void Main() //this thread is forever alive, it execs capturethread every 1000/fps milliseconds, so stable desired fps can be achieved
        {
            while (true) //also it's used like that 'cause it's easy to call for abort() for this thread
            {
                Thread CaptureThread = new Thread(CaptureScreen);
                CaptureThread.Start();
                Thread.Sleep(1000/fps); //this acts like a delay between frames, so desired fps will be stable and interping is being done every x milliseconds
            }
        }
        private void Interp(Image srcbmp, int x, int y) //here i'm interping source bmp divided by 40x40 squares
        {
            Bitmap tempbmp = new Bitmap(1, 1); //temporary bitmap used to store 1 pixel
            Color color;
            using (Graphics intrp = Graphics.FromImage(tempbmp))
            {
                intrp.InterpolationMode = InterpolationMode.Bicubic; //setup interpolation mode as bicubic
                intrp.DrawImage(srcbmp, new Rectangle(0, 0, 1, 1), x, y, 40, 40, GraphicsUnit.Pixel); //downscale the image by drawing it on the 1x1 bitmap, downscaling uses bicubic interpolation
                //rectangle fits bitmap, int x int y is for upper left corner, int width int height is for width and height of portion of src img 
            }
            color = tempbmp.GetPixel(0, 0); //gets the color of interpolated 1x1 bitmap
            colorarray.Add(new int[] { color.R, color.G, color.B }); //add int{ r, g, b } to list of int[]
        }
        private void CaptureScreen() //this thread captures screen and calls for interp method
        {
            Bitmap srcbmp = new Bitmap(1920, 1200); //custom resolutions are going to be implemented soon
            Graphics screencapture = Graphics.FromImage(srcbmp);
            screencapture.CopyFromScreen(0, 0, 0, 0, srcbmp.Size);
            for (int x = 0; x < 1920; x+=40) //48 iterations, both horizontal borders are interpolated, all corners are interpolated
            {
                Interp(srcbmp, x, 0); //capture & interp upper horizontal border
                Interp(srcbmp, x, 1160); //capture & interp lower horizontal border
            }
            for (int y = 40; y < 1160; y += 40) //28 iterations, no corners are interpolated (because they were captured in horizontal part)
            {
                Interp(srcbmp, 0, y); //capture & interp left vertical border
                Interp(srcbmp, 1880, y); //capture & interp right vertical border
            }
            //using (TextWriter textwriter = new StreamWriter("RGBvalues.txt")) foreach (int[] i in colorarray) for (int z = 0; z < 3; z++) textwriter.WriteLine(i[z]);
            //textwriter is just a debug feature, it'll be shut down when ill work directly with usb hid packets (or CDC uart)
            foreach (int[] i in colorarray) serial.WriteLine(i[0].ToString() + ":" + i[1].ToString() + ":" + i[2].ToString());
            Thread.Sleep(0); //to let other threads do their job, in case this thread is alive for too long
            GC.Collect(); //manual exec of garbage collection, prevents RAM overflow (its god damn fast on 20+ fps)
        }
        private void button2_Click(object sender, EventArgs e)
        {
            thread = new Thread(Main); //starts up a new thread, which is forever alive (ot till the Abort() will be executed)
            if (!((thread.ThreadState & (System.Threading.ThreadState.Stopped | System.Threading.ThreadState.Unstarted)) == 0)) thread.Start(); //kinda useless check, it makes no sense but imo this check should be here :)
        }
        private void button1_Click(object sender, EventArgs e) //stop capturing and interpolating screen
        {
            thread.Abort();
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e) //spinbox to set custom fps, just an easy feature
        {
            fps = Convert.ToInt32(numericUpDown1.Value);
            label1.Text = "Custom: " + 1000 / fps + " ms per frame, " + fps + " fps";
        }
        public Form1()
        {
            InitializeComponent();
            sw.Restart(); //start timer to check capturescreen timing
            for (int i = 0; i < timingtests; i++) CaptureScreen(); //it performs 5 (or any custom timingtests value) iterations of capturescreen
            sw.Stop();
            timing = Convert.ToInt32(sw.ElapsedMilliseconds/timingtests);
            fps = Convert.ToInt32(Math.Floor(1000.0/timing)); //floors down fps rating, so it will be more likely that there will be only one capturescreen thread running at once
            label2.Text = "Default: " + timing + " ms per frame, " + fps + " fps";
            numericUpDown1.Value = fps;
        }
    }
}
