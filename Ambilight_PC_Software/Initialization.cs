using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DynamicAmbilight
{
    static class Initialization
    {
        [STAThread]
        static void Main()
        {
            GuidAttribute attribute = (GuidAttribute)typeof(Initialization).Assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0];
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
                DynamicAmbilight AmbilightInstance = new DynamicAmbilight();
                Application.Run(AmbilightInstance);
            } 
        }
    }
}