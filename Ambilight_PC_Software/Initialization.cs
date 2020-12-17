using System;
using System.Drawing;
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
                    MetroFramework.MetroMessageBox.Show(new MetroFramework.Forms.MetroForm { Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - 400) / 2, (Screen.PrimaryScreen.WorkingArea.Height - 100) / 2) }, "\n\nAn instance of Dynamic Ambilight is already running", "Unable to start", MessageBoxButtons.OK, MessageBoxIcon.None);
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