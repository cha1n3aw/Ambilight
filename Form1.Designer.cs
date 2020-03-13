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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FPS_Spinbox = new System.Windows.Forms.NumericUpDown();
            this.SelectComPort = new System.Windows.Forms.ListBox();
            this.SelectBaudRate = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Default:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Custom:";
            // 
            // FPS_Spinbox
            // 
            this.FPS_Spinbox.Location = new System.Drawing.Point(15, 12);
            this.FPS_Spinbox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FPS_Spinbox.Name = "FPS_Spinbox";
            this.FPS_Spinbox.Size = new System.Drawing.Size(77, 20);
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
            this.SelectComPort.Location = new System.Drawing.Point(15, 38);
            this.SelectComPort.Name = "SelectComPort";
            this.SelectComPort.Size = new System.Drawing.Size(77, 30);
            this.SelectComPort.Sorted = true;
            this.SelectComPort.TabIndex = 8;
            this.SelectComPort.SelectedIndexChanged += new System.EventHandler(this.ComPortName_Selection_Changed);
            // 
            // SelectBaudRate
            // 
            this.SelectBaudRate.FormattingEnabled = true;
            this.SelectBaudRate.Location = new System.Drawing.Point(258, 12);
            this.SelectBaudRate.Name = "SelectBaudRate";
            this.SelectBaudRate.Size = new System.Drawing.Size(95, 95);
            this.SelectBaudRate.TabIndex = 9;
            this.SelectBaudRate.SelectedIndexChanged += new System.EventHandler(this.BaudRate_Selection_Changed);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Custom:";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(514, 246);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SelectBaudRate);
            this.Controls.Add(this.SelectComPort);
            this.Controls.Add(this.FPS_Spinbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.FPS_Spinbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown FPS_Spinbox;
        private System.Windows.Forms.ListBox SelectComPort;
        private System.Windows.Forms.ListBox SelectBaudRate;
        private System.Windows.Forms.Label label3;
    }
}

