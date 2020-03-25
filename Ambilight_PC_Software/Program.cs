using System;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DynamicAmbilight.DynamicAmbilight());
        }
    }
}
