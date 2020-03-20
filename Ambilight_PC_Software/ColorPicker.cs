using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;
using MetroFramework.Forms;
using static DynamicAmbilight.DynamicAmbilight;

namespace DynamicAmbilight
{
    public partial class ColorPicker : MetroForm
    {
        ColorDelegate d;
        Color color = Color.Empty;
        Bitmap DrawArea = new Bitmap(400, 400);
        Bitmap DrawRectangle = new Bitmap(400, 25);
        public ColorPicker(ColorDelegate sender)
        {
            InitializeComponent();
            pictureBox1.Image = DrawArea;
            FadeGray.Image = DrawRectangle;
            Graphics g = Graphics.FromImage(DrawArea);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            DrawColorWheel(g, Color.Gray, 0, 0, 396, 396);
            Graphics dr = Graphics.FromImage(DrawRectangle);
            dr.SmoothingMode = SmoothingMode.AntiAlias;
            DrawRect(dr, 0, 0, 400, 25);
            foreach (PropertyInfo color in typeof(Color).GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public)) ColorCB.Items.Add(color.Name);
            d = sender;
        }
        private void DrawRect(Graphics gr, int xmin, int ymin, int wid, int hgt)
        {
            gr.FillRectangle(new LinearGradientBrush(new Point(xmin, ymin), new Point(wid, hgt), Color.FromArgb(0, 0, 0), Color.FromArgb(255, 255, 255)), new Rectangle(xmin, ymin, wid, hgt));
        }
        private void DrawColorWheel(Graphics gr, Color outline_color, int xmin, int ymin, int wid, int hgt)
        {
            GraphicsPath RoundPath = new GraphicsPath();
            RoundPath.AddEllipse(new Rectangle(xmin, ymin, wid, hgt));
            RoundPath.Flatten(new Matrix(), 0.1f);
            float num_pts = (RoundPath.PointCount - 1) / 6;
            Color[] surround_colors = new Color[RoundPath.PointCount];
            int index = 0;
            InterpolateColors(surround_colors, ref index, 1 * num_pts, 255, 255, 0, 0, 255, 255, 0, 255);
            InterpolateColors(surround_colors, ref index, 2 * num_pts, 255, 255, 0, 255, 255, 0, 0, 255);
            InterpolateColors(surround_colors, ref index, 3 * num_pts, 255, 0, 0, 255, 255, 0, 255, 255);
            InterpolateColors(surround_colors, ref index, 4 * num_pts, 255, 0, 255, 255, 255, 0, 255, 0);
            InterpolateColors(surround_colors, ref index, 5 * num_pts, 255, 0, 255, 0, 255, 255, 255, 0);
            InterpolateColors(surround_colors, ref index, RoundPath.PointCount, 255, 255, 255, 0, 255, 255, 0, 0);
            using (PathGradientBrush path_brush = new PathGradientBrush(RoundPath))
            {
                path_brush.CenterColor = Color.White;
                path_brush.SurroundColors = surround_colors;
                gr.FillPath(path_brush, RoundPath);
                using (Pen thick_pen = new Pen(outline_color, 2)) gr.DrawPath(thick_pen, RoundPath);
            }
        }
        private void InterpolateColors(Color[] surround_colors, ref int index, float stop_pt, int from_a, int from_r, int from_g, int from_b, int to_a, int to_r, int to_g, int to_b)
        {
            int num_pts = (int)stop_pt - index;
            float a = from_a, r = from_r, g = from_g, b = from_b;
            float da = (to_a - from_a) / (num_pts - 1);
            float dr = (to_r - from_r) / (num_pts - 1);
            float dg = (to_g - from_g) / (num_pts - 1);
            float db = (to_b - from_b) / (num_pts - 1);
            for (int i = 0; i < num_pts; i++)
            {
                surround_colors[index++] =  Color.FromArgb((int)a, (int)r, (int)g, (int)b);
                a += da;
                r += dr;
                g += dg;
                b += db;
            }
        }
        private void PickColor_Click(object sender, EventArgs e)
        {
            d(color);
            this.Close();
        }
        private void PickColorBox_Clicked(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ((e.Location.X - 198) * (e.Location.X - 198) + (e.Location.Y - 198) * (e.Location.Y - 198)) < (197*197)) { color = DrawArea.GetPixel(e.Location.X, e.Location.Y); PickColor.BackColor = color; PickColor.ForeColor = Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B); }
        }
        private void FadeGray_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { color = DrawRectangle.GetPixel(e.Location.X, e.Location.Y); PickColor.BackColor = color; PickColor.ForeColor = Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B); }
        }
        private void ColorCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            color = Color.FromName(ColorCB.SelectedItem.ToString());
            PickColor.BackColor = color;
            PickColor.ForeColor = Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);
        }

        private void ColorCB_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = e.Bounds;
            if (e.Index >= 0)
            {
                string n = ((ComboBox)sender).Items[e.Index].ToString();
                Font f = new Font("Arial", 9, FontStyle.Regular);
                Color c = Color.FromName(n);
                Brush b = new SolidBrush(c);
                g.DrawString(n, f, Brushes.Black, rect.X, rect.Top);
                g.FillRectangle(b, rect.X + 110, rect.Y + 5, rect.Width - 10, rect.Height - 10);
            }
        }
    }
}
