namespace DynamicAmbilight
{
    partial class ColorPicker
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorPicker));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PickColor = new MetroFramework.Controls.MetroButton();
            this.FadeGray = new System.Windows.Forms.PictureBox();
            this.ColorCB = new MetroFramework.Controls.MetroComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FadeGray)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(23, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 400);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PickColorBox_Clicked);
            // 
            // PickColor
            // 
            this.PickColor.BackColor = System.Drawing.Color.Black;
            this.PickColor.Cursor = System.Windows.Forms.Cursors.Default;
            this.PickColor.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.PickColor.Location = new System.Drawing.Point(330, 500);
            this.PickColor.Name = "PickColor";
            this.PickColor.Size = new System.Drawing.Size(93, 29);
            this.PickColor.Style = MetroFramework.MetroColorStyle.Black;
            this.PickColor.TabIndex = 1;
            this.PickColor.TabStop = false;
            this.PickColor.Text = "Pick";
            this.PickColor.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.PickColor.UseCustomBackColor = true;
            this.PickColor.UseCustomForeColor = true;
            this.PickColor.UseSelectable = true;
            this.PickColor.Click += new System.EventHandler(this.PickColor_Click);
            // 
            // FadeGray
            // 
            this.FadeGray.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FadeGray.Location = new System.Drawing.Point(23, 469);
            this.FadeGray.Name = "FadeGray";
            this.FadeGray.Size = new System.Drawing.Size(400, 25);
            this.FadeGray.TabIndex = 2;
            this.FadeGray.TabStop = false;
            this.FadeGray.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FadeGray_MouseClick);
            // 
            // ColorCB
            // 
            this.ColorCB.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ColorCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColorCB.FormattingEnabled = true;
            this.ColorCB.ItemHeight = 23;
            this.ColorCB.Location = new System.Drawing.Point(23, 500);
            this.ColorCB.Name = "ColorCB";
            this.ColorCB.Size = new System.Drawing.Size(301, 29);
            this.ColorCB.Style = MetroFramework.MetroColorStyle.Black;
            this.ColorCB.TabIndex = 3;
            this.ColorCB.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ColorCB.UseSelectable = true;
            this.ColorCB.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ColorCB_DrawItem);
            this.ColorCB.SelectedIndexChanged += new System.EventHandler(this.ColorCB_SelectedIndexChanged);
            // 
            // ColorPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 554);
            this.Controls.Add(this.ColorCB);
            this.Controls.Add(this.FadeGray);
            this.Controls.Add(this.PickColor);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ColorPicker";
            this.ShowIcon = false;
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Text = "Color Picker";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FadeGray)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroButton PickColor;
        private System.Windows.Forms.PictureBox FadeGray;
        private MetroFramework.Controls.MetroComboBox ColorCB;
    }
}