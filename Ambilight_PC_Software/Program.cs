using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace WinForms_Dynamic_Ambilight
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            GuidAttribute attribute = (GuidAttribute)typeof(Program).Assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0];
            using (Mutex mutex = new Mutex(false, @"Global\" + attribute.Value))
            {
                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show("An instance of Dynamic Ambilight is already running");
                    return;
                }
                GC.Collect();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new DynamicAmbilight.DynamicAmbilight());
            } 
        }
    }
}