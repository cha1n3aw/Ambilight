namespace Ambilight
{
    partial class Dynamic_Ambilight
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dynamic_Ambilight));
            this.StartStopButton = new System.Windows.Forms.Button();
            this.Default_Timings = new System.Windows.Forms.Label();
            this.Custom_Timings = new System.Windows.Forms.Label();
            this.FPS_Spinbox = new System.Windows.Forms.NumericUpDown();
            this.TestButton = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.Tray_Icon = new System.Windows.Forms.NotifyIcon(this.components);
            this.InterpMode = new System.Windows.Forms.ComboBox();
            this.BaudRate = new System.Windows.Forms.ComboBox();
            this.ComPort = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.FPS_Spinbox)).BeginInit();
            this.SuspendLayout();
            // 
            // StartStopButton
            // 
            this.StartStopButton.BackColor = System.Drawing.Color.LemonChiffon;
            this.StartStopButton.FlatAppearance.BorderSize = 0;
            this.StartStopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartStopButton.Font = new System.Drawing.Font("Neo Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartStopButton.ForeColor = System.Drawing.Color.Black;
            this.StartStopButton.Location = new System.Drawing.Point(166, 78);
            this.StartStopButton.Name = "StartStopButton";
            this.StartStopButton.Size = new System.Drawing.Size(72, 27);
            this.StartStopButton.TabIndex = 0;
            this.StartStopButton.Text = "Start";
            this.StartStopButton.UseVisualStyleBackColor = false;
            this.StartStopButton.Click += new System.EventHandler(this.Start_Stop_Clicked);
            // 
            // Default_Timings
            // 
            this.Default_Timings.AutoSize = true;
            this.Default_Timings.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Default_Timings.ForeColor = System.Drawing.Color.LemonChiffon;
            this.Default_Timings.Location = new System.Drawing.Point(9, 108);
            this.Default_Timings.Name = "Default_Timings";
            this.Default_Timings.Size = new System.Drawing.Size(54, 18);
            this.Default_Timings.TabIndex = 2;
            this.Default_Timings.Text = "Default:";
            // 
            // Custom_Timings
            // 
            this.Custom_Timings.AutoSize = true;
            this.Custom_Timings.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Custom_Timings.ForeColor = System.Drawing.Color.LemonChiffon;
            this.Custom_Timings.Location = new System.Drawing.Point(9, 126);
            this.Custom_Timings.Name = "Custom_Timings";
            this.Custom_Timings.Size = new System.Drawing.Size(58, 18);
            this.Custom_Timings.TabIndex = 6;
            this.Custom_Timings.Text = "Custom:";
            // 
            // FPS_Spinbox
            // 
            this.FPS_Spinbox.BackColor = System.Drawing.Color.LemonChiffon;
            this.FPS_Spinbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FPS_Spinbox.Font = new System.Drawing.Font("Neo Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FPS_Spinbox.ForeColor = System.Drawing.Color.Black;
            this.FPS_Spinbox.Location = new System.Drawing.Point(12, 12);
            this.FPS_Spinbox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FPS_Spinbox.Name = "FPS_Spinbox";
            this.FPS_Spinbox.Size = new System.Drawing.Size(70, 26);
            this.FPS_Spinbox.TabIndex = 7;
            this.FPS_Spinbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FPS_Spinbox.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.FPS_Spinbox.ValueChanged += new System.EventHandler(this.FPS_Spinbox_Changed);
            // 
            // TestButton
            // 
            this.TestButton.BackColor = System.Drawing.Color.LemonChiffon;
            this.TestButton.FlatAppearance.BorderSize = 0;
            this.TestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TestButton.Font = new System.Drawing.Font("Neo Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestButton.ForeColor = System.Drawing.Color.Black;
            this.TestButton.Location = new System.Drawing.Point(166, 45);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(72, 27);
            this.TestButton.TabIndex = 11;
            this.TestButton.Text = "Test\r\n";
            this.TestButton.UseVisualStyleBackColor = false;
            this.TestButton.Click += new System.EventHandler(this.Test_Clicked);
            // 
            // RefreshButton
            // 
            this.RefreshButton.BackColor = System.Drawing.Color.LemonChiffon;
            this.RefreshButton.FlatAppearance.BorderSize = 0;
            this.RefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshButton.Font = new System.Drawing.Font("Neo Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshButton.ForeColor = System.Drawing.Color.Black;
            this.RefreshButton.Location = new System.Drawing.Point(166, 12);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(72, 27);
            this.RefreshButton.TabIndex = 12;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = false;
            this.RefreshButton.Click += new System.EventHandler(this.Refresh_Clicked);
            // 
            // Tray_Icon
            // 
            this.Tray_Icon.BalloonTipText = "Click to restore";
            this.Tray_Icon.BalloonTipTitle = "Hey, I\'m here!";
            this.Tray_Icon.Icon = ((System.Drawing.Icon)(resources.GetObject("Tray_Icon.Icon")));
            this.Tray_Icon.Text = "Dynamic Ambilight";
            this.Tray_Icon.Visible = true;
            this.Tray_Icon.BalloonTipClicked += new System.EventHandler(this.Tray_Icon_BalloonTipClicked);
            this.Tray_Icon.Click += new System.EventHandler(this.Tray_Icon_Click);
            // 
            // InterpMode
            // 
            this.InterpMode.AllowDrop = true;
            this.InterpMode.BackColor = System.Drawing.Color.LemonChiffon;
            this.InterpMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InterpMode.Font = new System.Drawing.Font("Neo Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InterpMode.ForeColor = System.Drawing.Color.Black;
            this.InterpMode.FormattingEnabled = true;
            this.InterpMode.Location = new System.Drawing.Point(12, 78);
            this.InterpMode.Name = "InterpMode";
            this.InterpMode.Size = new System.Drawing.Size(148, 27);
            this.InterpMode.TabIndex = 14;
            this.InterpMode.Text = "INTERPOLATION";
            this.InterpMode.SelectedIndexChanged += new System.EventHandler(this.InterpMode_SelectedIndexChanged);
            // 
            // BaudRate
            // 
            this.BaudRate.AllowDrop = true;
            this.BaudRate.BackColor = System.Drawing.Color.LemonChiffon;
            this.BaudRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BaudRate.Font = new System.Drawing.Font("Neo Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaudRate.ForeColor = System.Drawing.Color.Black;
            this.BaudRate.FormattingEnabled = true;
            this.BaudRate.Location = new System.Drawing.Point(12, 45);
            this.BaudRate.Name = "BaudRate";
            this.BaudRate.Size = new System.Drawing.Size(148, 27);
            this.BaudRate.TabIndex = 15;
            this.BaudRate.Text = "BAUDRATE";
            this.BaudRate.SelectedIndexChanged += new System.EventHandler(this.BaudRate_SelectedIndexChanged);
            // 
            // ComPort
            // 
            this.ComPort.AllowDrop = true;
            this.ComPort.BackColor = System.Drawing.Color.LemonChiffon;
            this.ComPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComPort.Font = new System.Drawing.Font("Neo Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComPort.ForeColor = System.Drawing.Color.Black;
            this.ComPort.FormattingEnabled = true;
            this.ComPort.ItemHeight = 19;
            this.ComPort.Location = new System.Drawing.Point(88, 12);
            this.ComPort.Name = "ComPort";
            this.ComPort.Size = new System.Drawing.Size(72, 27);
            this.ComPort.TabIndex = 16;
            this.ComPort.Text = "COM";
            this.ComPort.SelectedIndexChanged += new System.EventHandler(this.ComPort_SelectedIndexChanged);
            // 
            // Dynamic_Ambilight
            // 
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(248, 149);
            this.Controls.Add(this.ComPort);
            this.Controls.Add(this.BaudRate);
            this.Controls.Add(this.InterpMode);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.TestButton);
            this.Controls.Add(this.FPS_Spinbox);
            this.Controls.Add(this.Custom_Timings);
            this.Controls.Add(this.Default_Timings);
            this.Controls.Add(this.StartStopButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Dynamic_Ambilight";
            ((System.ComponentModel.ISupportInitialize)(this.FPS_Spinbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartStopButton;
        private System.Windows.Forms.Label Default_Timings;
        private System.Windows.Forms.Label Custom_Timings;
        private System.Windows.Forms.NumericUpDown FPS_Spinbox;
        private System.Windows.Forms.Button TestButton;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.NotifyIcon Tray_Icon;
        private System.Windows.Forms.ComboBox InterpMode;
        private System.Windows.Forms.ComboBox BaudRate;
        private System.Windows.Forms.ComboBox ComPort;
    }
}

