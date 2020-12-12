using System;
using System.Windows.Forms;

namespace DynamicAmbilight
{
    public partial class DynamicAmbilight
    {
        public DynamicAmbilight()
        {
            InitializeComponent();
            FillComboBoxes();
            Init();
            SelectionCheck();
            ScreenRefreshed += (sender, data) =>
            {
                sw.Stop();
                cnt++;
                prevms += sw.ElapsedMilliseconds;
                if (cnt >= 50) 
                {
                    Default_Timings.Invoke((MethodInvoker)delegate { Default_Timings.Text = "Ms per frame: " + (double)prevms / cnt + "\nFPS: " + (int)(1000 / ((double)prevms / cnt)); });
                    cnt = 0; prevms = 0; 
                }
                sw.Restart();
            };
        }
    }
}
