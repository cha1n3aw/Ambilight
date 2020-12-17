using System.Windows.Forms;

namespace DynamicAmbilight
{
    public partial class DynamicAmbilight
    {
        public DynamicAmbilight()
        {
            InitializeComponent();
            Tray_Icon.ContextMenuStrip = TrayIconMenu;
            FillComboBoxes();
            Init();
            SelectionCheck();
            ScreenRefreshed += (sender, data) =>
            {
                sw.Stop();
                cnt++;
                prevms += sw.ElapsedMilliseconds;
                if (cnt >= 30) 
                {
                    Default_Timings.Invoke((MethodInvoker)delegate { Default_Timings.Text = "Ms per frame: " + (int)(prevms / cnt) + "; FPS: " + (int)(1000 / ((double)prevms / cnt)); });
                    cnt = 0; prevms = 0; 
                }
                sw.Restart();
            };
        }
    }
}
