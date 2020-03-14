namespace Ambilight
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Default_Timings = new System.Windows.Forms.Label();
            this.Custom_Timings = new System.Windows.Forms.Label();
            this.FPS_Spinbox = new System.Windows.Forms.NumericUpDown();
            this.SelectComPort = new System.Windows.Forms.ListBox();
            this.SelectBaudRate = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FPS_Spinbox)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(98, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 56);
            this.button2.TabIndex = 0;
            this.button2.Text = "Start";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Start_Clicked);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(178, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 56);
            this.button1.TabIndex = 3;
            this.button1.Text = "Stop";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Abort_Clicked);
            // 
            // label2
            // 
            this.Default_Timings.AutoSize = true;
            this.Default_Timings.Location = new System.Drawing.Point(13, 77);
            this.Default_Timings.Name = "label2";
            this.Default_Timings.Size = new System.Drawing.Size(44, 13);
            this.Default_Timings.TabIndex = 2;
            this.Default_Timings.Text = "Default:";
            // 
            // label1
            // 
            this.Custom_Timings.AutoSize = true;
            this.Custom_Timings.Location = new System.Drawing.Point(12, 90);
            this.Custom_Timings.Name = "label1";
            this.Custom_Timings.Size = new System.Drawing.Size(45, 13);
            this.Custom_Timings.TabIndex = 6;
            this.Custom_Timings.Text = "Custom:";
            // 
            // FPS_Spinbox
            // 
            this.FPS_Spinbox.Location = new System.Drawing.Point(18, 12);
            this.FPS_Spinbox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FPS_Spinbox.Name = "FPS_Spinbox";
            this.FPS_Spinbox.Size = new System.Drawing.Size(74, 20);
            this.FPS_Spinbox.TabIndex = 7;
            this.FPS_Spinbox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FPS_Spinbox.ValueChanged += new System.EventHandler(this.FPS_Spinbox_Changed);
            // 
            // SelectComPort
            // 
            this.SelectComPort.FormattingEnabled = true;
            this.SelectComPort.Location = new System.Drawing.Point(258, 12);
            this.SelectComPort.Name = "SelectComPort";
            this.SelectComPort.Size = new System.Drawing.Size(77, 56);
            this.SelectComPort.Sorted = true;
            this.SelectComPort.TabIndex = 8;
            this.SelectComPort.SelectedIndexChanged += new System.EventHandler(this.ComPortName_Selection_Changed);
            // 
            // SelectBaudRate
            // 
            this.SelectBaudRate.FormattingEnabled = true;
            this.SelectBaudRate.Location = new System.Drawing.Point(341, 12);
            this.SelectBaudRate.Name = "SelectBaudRate";
            this.SelectBaudRate.Size = new System.Drawing.Size(95, 56);
            this.SelectBaudRate.TabIndex = 9;
            this.SelectBaudRate.SelectedIndexChanged += new System.EventHandler(this.BaudRate_Selection_Changed);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(18, 38);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(74, 30);
            this.button3.TabIndex = 11;
            this.button3.Text = "Test\r\n";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Test_Clicked);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(448, 116);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.SelectBaudRate);
            this.Controls.Add(this.SelectComPort);
            this.Controls.Add(this.FPS_Spinbox);
            this.Controls.Add(this.Custom_Timings);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Default_Timings);
            this.Controls.Add(this.button2);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.FPS_Spinbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Default_Timings;
        private System.Windows.Forms.Label Custom_Timings;
        private System.Windows.Forms.NumericUpDown FPS_Spinbox;
        private System.Windows.Forms.ListBox SelectComPort;
        private System.Windows.Forms.ListBox SelectBaudRate;
        private System.Windows.Forms.Button button3;
    }
}

