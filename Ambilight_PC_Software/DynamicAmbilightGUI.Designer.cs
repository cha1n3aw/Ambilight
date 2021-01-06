namespace DynamicAmbilight
{
    partial class DynamicAmbilight
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DynamicAmbilight));
            this.Tray_Icon = new System.Windows.Forms.NotifyIcon(this.components);
            this.SettingsTab = new MetroFramework.Controls.MetroTabPage();
            this.CaptureArea = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel18 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel16 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel14 = new MetroFramework.Controls.MetroLabel();
            this.LeftOffset = new MetroFramework.Controls.MetroTextBox();
            this.LowerOffset = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.RightOffset = new MetroFramework.Controls.MetroTextBox();
            this.CustomHeight = new MetroFramework.Controls.MetroTextBox();
            this.UpperOffset = new MetroFramework.Controls.MetroTextBox();
            this.UpperOffsetLabel = new MetroFramework.Controls.MetroLabel();
            this.metroLabel15 = new MetroFramework.Controls.MetroLabel();
            this.CustomWidth = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.DefAudioInput = new MetroFramework.Controls.MetroLabel();
            this.UseDefaultAudio = new MetroFramework.Controls.MetroToggle();
            this.AudioInputs = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.CapturedMonitor = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.CapturedDevice = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.LedsY = new MetroFramework.Controls.MetroTrackBar();
            this.LedsX = new MetroFramework.Controls.MetroTrackBar();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.ComPort = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.BaudRate = new MetroFramework.Controls.MetroComboBox();
            this.InterpMode = new MetroFramework.Controls.MetroComboBox();
            this.HomeTab = new MetroFramework.Controls.MetroTabPage();
            this.ColorSelection = new MetroFramework.Controls.MetroComboBox();
            this.PrevAwayMode = new MetroFramework.Controls.MetroLabel();
            this.PreventSleep = new MetroFramework.Controls.MetroToggle();
            this.PrevSleep = new MetroFramework.Controls.MetroLabel();
            this.PreventAwayMode = new MetroFramework.Controls.MetroToggle();
            this.StartUpLabel = new MetroFramework.Controls.MetroLabel();
            this.SelectColor = new MetroFramework.Controls.MetroButton();
            this.metroLabel19 = new MetroFramework.Controls.MetroLabel();
            this.AmbilightModes = new MetroFramework.Controls.MetroComboBox();
            this.FadeTiming = new MetroFramework.Controls.MetroTrackBar();
            this.StartStop = new MetroFramework.Controls.MetroToggle();
            this.Default_Timings = new MetroFramework.Controls.MetroLabel();
            this.ControlTabs = new MetroFramework.Controls.MetroTabControl();
            this.TrayIconMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolTip = new MetroFramework.Components.MetroToolTip();
            this.BlackStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.SettingsTab.SuspendLayout();
            this.HomeTab.SuspendLayout();
            this.ControlTabs.SuspendLayout();
            this.TrayIconMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlackStyleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // Tray_Icon
            // 
            this.Tray_Icon.Icon = ((System.Drawing.Icon)(resources.GetObject("Tray_Icon.Icon")));
            this.Tray_Icon.Text = "Dynamic Ambilight";
            this.Tray_Icon.Visible = true;
            this.Tray_Icon.BalloonTipClicked += new System.EventHandler(this.Tray_Icon_BalloonTipClicked);
            this.Tray_Icon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Tray_Icon_MouseDoubleClick);
            // 
            // SettingsTab
            // 
            this.SettingsTab.AutoScroll = true;
            this.SettingsTab.Controls.Add(this.metroLabel8);
            this.SettingsTab.Controls.Add(this.metroLabel7);
            this.SettingsTab.Controls.Add(this.CaptureArea);
            this.SettingsTab.Controls.Add(this.metroLabel18);
            this.SettingsTab.Controls.Add(this.metroLabel16);
            this.SettingsTab.Controls.Add(this.metroLabel14);
            this.SettingsTab.Controls.Add(this.LeftOffset);
            this.SettingsTab.Controls.Add(this.LowerOffset);
            this.SettingsTab.Controls.Add(this.metroLabel12);
            this.SettingsTab.Controls.Add(this.RightOffset);
            this.SettingsTab.Controls.Add(this.CustomHeight);
            this.SettingsTab.Controls.Add(this.UpperOffset);
            this.SettingsTab.Controls.Add(this.UpperOffsetLabel);
            this.SettingsTab.Controls.Add(this.metroLabel15);
            this.SettingsTab.Controls.Add(this.CustomWidth);
            this.SettingsTab.Controls.Add(this.metroLabel13);
            this.SettingsTab.Controls.Add(this.metroLabel6);
            this.SettingsTab.Controls.Add(this.DefAudioInput);
            this.SettingsTab.Controls.Add(this.UseDefaultAudio);
            this.SettingsTab.Controls.Add(this.AudioInputs);
            this.SettingsTab.Controls.Add(this.metroLabel5);
            this.SettingsTab.Controls.Add(this.CapturedMonitor);
            this.SettingsTab.Controls.Add(this.metroLabel4);
            this.SettingsTab.Controls.Add(this.CapturedDevice);
            this.SettingsTab.Controls.Add(this.metroLabel11);
            this.SettingsTab.Controls.Add(this.metroLabel10);
            this.SettingsTab.Controls.Add(this.LedsY);
            this.SettingsTab.Controls.Add(this.LedsX);
            this.SettingsTab.Controls.Add(this.metroLabel3);
            this.SettingsTab.Controls.Add(this.metroLabel2);
            this.SettingsTab.Controls.Add(this.ComPort);
            this.SettingsTab.Controls.Add(this.metroLabel1);
            this.SettingsTab.Controls.Add(this.BaudRate);
            this.SettingsTab.Controls.Add(this.InterpMode);
            this.SettingsTab.HorizontalScrollbar = true;
            this.SettingsTab.HorizontalScrollbarBarColor = false;
            this.SettingsTab.HorizontalScrollbarHighlightOnWheel = false;
            this.SettingsTab.HorizontalScrollbarSize = 10;
            this.SettingsTab.Location = new System.Drawing.Point(4, 38);
            this.SettingsTab.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.Size = new System.Drawing.Size(242, 230);
            this.SettingsTab.Style = MetroFramework.MetroColorStyle.Black;
            this.SettingsTab.TabIndex = 1;
            this.SettingsTab.Text = "Settings";
            this.SettingsTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.SettingsTab.VerticalScrollbar = true;
            this.SettingsTab.VerticalScrollbarBarColor = true;
            this.SettingsTab.VerticalScrollbarHighlightOnWheel = true;
            this.SettingsTab.VerticalScrollbarSize = 10;
            // 
            // CaptureArea
            // 
            this.CaptureArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CaptureArea.FormattingEnabled = true;
            this.CaptureArea.ItemHeight = 23;
            this.CaptureArea.Location = new System.Drawing.Point(2, 94);
            this.CaptureArea.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CaptureArea.Name = "CaptureArea";
            this.CaptureArea.Size = new System.Drawing.Size(222, 29);
            this.CaptureArea.Style = MetroFramework.MetroColorStyle.Black;
            this.CaptureArea.TabIndex = 94;
            this.CaptureArea.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.CaptureArea.UseSelectable = true;
            this.CaptureArea.SelectedIndexChanged += new System.EventHandler(this.CaptureArea_SelectedIndexChanged);
            // 
            // metroLabel18
            // 
            this.metroLabel18.AutoSize = true;
            this.metroLabel18.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel18.Location = new System.Drawing.Point(53, 134);
            this.metroLabel18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel18.Name = "metroLabel18";
            this.metroLabel18.Size = new System.Drawing.Size(125, 19);
            this.metroLabel18.TabIndex = 98;
            this.metroLabel18.Text = "Custom Resolution";
            this.metroLabel18.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel16
            // 
            this.metroLabel16.AutoSize = true;
            this.metroLabel16.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel16.Location = new System.Drawing.Point(2, 72);
            this.metroLabel16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel16.Name = "metroLabel16";
            this.metroLabel16.Size = new System.Drawing.Size(90, 19);
            this.metroLabel16.TabIndex = 93;
            this.metroLabel16.Text = "Capture Area";
            this.metroLabel16.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel14
            // 
            this.metroLabel14.AutoSize = true;
            this.metroLabel14.Enabled = false;
            this.metroLabel14.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel14.Location = new System.Drawing.Point(129, 247);
            this.metroLabel14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel14.Name = "metroLabel14";
            this.metroLabel14.Size = new System.Drawing.Size(41, 19);
            this.metroLabel14.TabIndex = 87;
            this.metroLabel14.Text = "Right";
            this.metroLabel14.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // LeftOffset
            // 
            // 
            // 
            // 
            this.LeftOffset.CustomButton.Image = null;
            this.LeftOffset.CustomButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LeftOffset.CustomButton.Location = new System.Drawing.Point(28, 1);
            this.LeftOffset.CustomButton.Name = "";
            this.LeftOffset.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.LeftOffset.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.LeftOffset.CustomButton.TabIndex = 1;
            this.LeftOffset.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.LeftOffset.CustomButton.UseSelectable = true;
            this.LeftOffset.CustomButton.Visible = false;
            this.LeftOffset.Enabled = false;
            this.LeftOffset.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.LeftOffset.Lines = new string[0];
            this.LeftOffset.Location = new System.Drawing.Point(174, 218);
            this.LeftOffset.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LeftOffset.MaxLength = 32767;
            this.LeftOffset.Name = "LeftOffset";
            this.LeftOffset.PasswordChar = '\0';
            this.LeftOffset.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.LeftOffset.SelectedText = "";
            this.LeftOffset.SelectionLength = 0;
            this.LeftOffset.SelectionStart = 0;
            this.LeftOffset.ShortcutsEnabled = true;
            this.LeftOffset.Size = new System.Drawing.Size(50, 23);
            this.LeftOffset.Style = MetroFramework.MetroColorStyle.Black;
            this.LeftOffset.TabIndex = 91;
            this.LeftOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LeftOffset.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.LeftOffset.UseSelectable = true;
            this.LeftOffset.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.LeftOffset.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // LowerOffset
            // 
            // 
            // 
            // 
            this.LowerOffset.CustomButton.Image = null;
            this.LowerOffset.CustomButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LowerOffset.CustomButton.Location = new System.Drawing.Point(27, 1);
            this.LowerOffset.CustomButton.Name = "";
            this.LowerOffset.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.LowerOffset.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.LowerOffset.CustomButton.TabIndex = 1;
            this.LowerOffset.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.LowerOffset.CustomButton.UseSelectable = true;
            this.LowerOffset.CustomButton.Visible = false;
            this.LowerOffset.Enabled = false;
            this.LowerOffset.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.LowerOffset.Lines = new string[0];
            this.LowerOffset.Location = new System.Drawing.Point(54, 247);
            this.LowerOffset.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LowerOffset.MaxLength = 32767;
            this.LowerOffset.Name = "LowerOffset";
            this.LowerOffset.PasswordChar = '\0';
            this.LowerOffset.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.LowerOffset.SelectedText = "";
            this.LowerOffset.SelectionLength = 0;
            this.LowerOffset.SelectionStart = 0;
            this.LowerOffset.ShortcutsEnabled = true;
            this.LowerOffset.Size = new System.Drawing.Size(49, 23);
            this.LowerOffset.Style = MetroFramework.MetroColorStyle.Black;
            this.LowerOffset.TabIndex = 90;
            this.LowerOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LowerOffset.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.LowerOffset.UseSelectable = true;
            this.LowerOffset.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.LowerOffset.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.Enabled = false;
            this.metroLabel12.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel12.Location = new System.Drawing.Point(3, 247);
            this.metroLabel12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(46, 19);
            this.metroLabel12.TabIndex = 85;
            this.metroLabel12.Text = "Lower";
            this.metroLabel12.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // RightOffset
            // 
            // 
            // 
            // 
            this.RightOffset.CustomButton.Image = null;
            this.RightOffset.CustomButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RightOffset.CustomButton.Location = new System.Drawing.Point(28, 1);
            this.RightOffset.CustomButton.Name = "";
            this.RightOffset.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.RightOffset.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.RightOffset.CustomButton.TabIndex = 1;
            this.RightOffset.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.RightOffset.CustomButton.UseSelectable = true;
            this.RightOffset.CustomButton.Visible = false;
            this.RightOffset.Enabled = false;
            this.RightOffset.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.RightOffset.Lines = new string[0];
            this.RightOffset.Location = new System.Drawing.Point(174, 247);
            this.RightOffset.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.RightOffset.MaxLength = 32767;
            this.RightOffset.Name = "RightOffset";
            this.RightOffset.PasswordChar = '\0';
            this.RightOffset.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.RightOffset.SelectedText = "";
            this.RightOffset.SelectionLength = 0;
            this.RightOffset.SelectionStart = 0;
            this.RightOffset.ShortcutsEnabled = true;
            this.RightOffset.Size = new System.Drawing.Size(50, 23);
            this.RightOffset.Style = MetroFramework.MetroColorStyle.Black;
            this.RightOffset.TabIndex = 92;
            this.RightOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RightOffset.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.RightOffset.UseSelectable = true;
            this.RightOffset.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.RightOffset.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // CustomHeight
            // 
            // 
            // 
            // 
            this.CustomHeight.CustomButton.Image = null;
            this.CustomHeight.CustomButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CustomHeight.CustomButton.Location = new System.Drawing.Point(28, 1);
            this.CustomHeight.CustomButton.Name = "";
            this.CustomHeight.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.CustomHeight.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.CustomHeight.CustomButton.TabIndex = 1;
            this.CustomHeight.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.CustomHeight.CustomButton.UseSelectable = true;
            this.CustomHeight.CustomButton.Visible = false;
            this.CustomHeight.Enabled = false;
            this.CustomHeight.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.CustomHeight.Lines = new string[0];
            this.CustomHeight.Location = new System.Drawing.Point(174, 156);
            this.CustomHeight.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CustomHeight.MaxLength = 32767;
            this.CustomHeight.Name = "CustomHeight";
            this.CustomHeight.PasswordChar = '\0';
            this.CustomHeight.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.CustomHeight.SelectedText = "";
            this.CustomHeight.SelectionLength = 0;
            this.CustomHeight.SelectionStart = 0;
            this.CustomHeight.ShortcutsEnabled = true;
            this.CustomHeight.Size = new System.Drawing.Size(50, 23);
            this.CustomHeight.Style = MetroFramework.MetroColorStyle.Black;
            this.CustomHeight.TabIndex = 96;
            this.CustomHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CustomHeight.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.CustomHeight.UseSelectable = true;
            this.CustomHeight.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.CustomHeight.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // UpperOffset
            // 
            // 
            // 
            // 
            this.UpperOffset.CustomButton.Image = null;
            this.UpperOffset.CustomButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UpperOffset.CustomButton.Location = new System.Drawing.Point(27, 1);
            this.UpperOffset.CustomButton.Name = "";
            this.UpperOffset.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.UpperOffset.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.UpperOffset.CustomButton.TabIndex = 1;
            this.UpperOffset.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.UpperOffset.CustomButton.UseSelectable = true;
            this.UpperOffset.CustomButton.Visible = false;
            this.UpperOffset.Enabled = false;
            this.UpperOffset.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.UpperOffset.Lines = new string[0];
            this.UpperOffset.Location = new System.Drawing.Point(54, 218);
            this.UpperOffset.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.UpperOffset.MaxLength = 32767;
            this.UpperOffset.Name = "UpperOffset";
            this.UpperOffset.PasswordChar = '\0';
            this.UpperOffset.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.UpperOffset.SelectedText = "";
            this.UpperOffset.SelectionLength = 0;
            this.UpperOffset.SelectionStart = 0;
            this.UpperOffset.ShortcutsEnabled = true;
            this.UpperOffset.Size = new System.Drawing.Size(49, 23);
            this.UpperOffset.Style = MetroFramework.MetroColorStyle.Black;
            this.UpperOffset.TabIndex = 89;
            this.UpperOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UpperOffset.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.UpperOffset.UseSelectable = true;
            this.UpperOffset.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.UpperOffset.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // UpperOffsetLabel
            // 
            this.UpperOffsetLabel.AutoSize = true;
            this.UpperOffsetLabel.Enabled = false;
            this.UpperOffsetLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.UpperOffsetLabel.Location = new System.Drawing.Point(3, 218);
            this.UpperOffsetLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UpperOffsetLabel.Name = "UpperOffsetLabel";
            this.UpperOffsetLabel.Size = new System.Drawing.Size(47, 19);
            this.UpperOffsetLabel.TabIndex = 84;
            this.UpperOffsetLabel.Text = "Upper";
            this.UpperOffsetLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel15
            // 
            this.metroLabel15.AutoSize = true;
            this.metroLabel15.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel15.Location = new System.Drawing.Point(62, 192);
            this.metroLabel15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel15.Name = "metroLabel15";
            this.metroLabel15.Size = new System.Drawing.Size(104, 19);
            this.metroLabel15.TabIndex = 88;
            this.metroLabel15.Text = "Custom Offsets";
            this.metroLabel15.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // CustomWidth
            // 
            // 
            // 
            // 
            this.CustomWidth.CustomButton.Image = null;
            this.CustomWidth.CustomButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CustomWidth.CustomButton.Location = new System.Drawing.Point(28, 1);
            this.CustomWidth.CustomButton.Name = "";
            this.CustomWidth.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.CustomWidth.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.CustomWidth.CustomButton.TabIndex = 1;
            this.CustomWidth.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.CustomWidth.CustomButton.UseSelectable = true;
            this.CustomWidth.CustomButton.Visible = false;
            this.CustomWidth.Enabled = false;
            this.CustomWidth.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.CustomWidth.Lines = new string[0];
            this.CustomWidth.Location = new System.Drawing.Point(53, 156);
            this.CustomWidth.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CustomWidth.MaxLength = 32767;
            this.CustomWidth.Name = "CustomWidth";
            this.CustomWidth.PasswordChar = '\0';
            this.CustomWidth.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.CustomWidth.SelectedText = "";
            this.CustomWidth.SelectionLength = 0;
            this.CustomWidth.SelectionStart = 0;
            this.CustomWidth.ShortcutsEnabled = true;
            this.CustomWidth.Size = new System.Drawing.Size(50, 23);
            this.CustomWidth.Style = MetroFramework.MetroColorStyle.Black;
            this.CustomWidth.TabIndex = 95;
            this.CustomWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CustomWidth.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.CustomWidth.UseSelectable = true;
            this.CustomWidth.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.CustomWidth.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.Enabled = false;
            this.metroLabel13.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel13.Location = new System.Drawing.Point(129, 218);
            this.metroLabel13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(32, 19);
            this.metroLabel13.TabIndex = 86;
            this.metroLabel13.Text = "Left";
            this.metroLabel13.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel6.Location = new System.Drawing.Point(2, 444);
            this.metroLabel6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(81, 19);
            this.metroLabel6.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel6.TabIndex = 83;
            this.metroLabel6.Text = "Audio input";
            this.metroLabel6.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // DefAudioInput
            // 
            this.DefAudioInput.AutoSize = true;
            this.DefAudioInput.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.DefAudioInput.Location = new System.Drawing.Point(2, 507);
            this.DefAudioInput.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DefAudioInput.Name = "DefAudioInput";
            this.DefAudioInput.Size = new System.Drawing.Size(130, 19);
            this.DefAudioInput.Style = MetroFramework.MetroColorStyle.Black;
            this.DefAudioInput.TabIndex = 82;
            this.DefAudioInput.Text = "Default Audio Input";
            this.DefAudioInput.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // UseDefaultAudio
            // 
            this.UseDefaultAudio.AutoSize = true;
            this.UseDefaultAudio.Checked = true;
            this.UseDefaultAudio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseDefaultAudio.DisplayStatus = false;
            this.UseDefaultAudio.Location = new System.Drawing.Point(174, 509);
            this.UseDefaultAudio.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.UseDefaultAudio.Name = "UseDefaultAudio";
            this.UseDefaultAudio.Size = new System.Drawing.Size(50, 17);
            this.UseDefaultAudio.Style = MetroFramework.MetroColorStyle.Black;
            this.UseDefaultAudio.TabIndex = 81;
            this.UseDefaultAudio.Text = "On";
            this.UseDefaultAudio.UseSelectable = true;
            // 
            // AudioInputs
            // 
            this.AudioInputs.BackColor = System.Drawing.SystemColors.WindowText;
            this.AudioInputs.Enabled = false;
            this.AudioInputs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AudioInputs.FormattingEnabled = true;
            this.AudioInputs.ItemHeight = 23;
            this.AudioInputs.Location = new System.Drawing.Point(2, 466);
            this.AudioInputs.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.AudioInputs.Name = "AudioInputs";
            this.AudioInputs.Size = new System.Drawing.Size(222, 29);
            this.AudioInputs.Style = MetroFramework.MetroColorStyle.Black;
            this.AudioInputs.TabIndex = 80;
            this.AudioInputs.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.AudioInputs.UseSelectable = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.Location = new System.Drawing.Point(2, 390);
            this.metroLabel5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(119, 19);
            this.metroLabel5.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel5.TabIndex = 32;
            this.metroLabel5.Text = "Captured monitor";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // CapturedMonitor
            // 
            this.CapturedMonitor.BackColor = System.Drawing.Color.Black;
            this.CapturedMonitor.Enabled = false;
            this.CapturedMonitor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CapturedMonitor.FormattingEnabled = true;
            this.CapturedMonitor.ItemHeight = 23;
            this.CapturedMonitor.Location = new System.Drawing.Point(2, 412);
            this.CapturedMonitor.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CapturedMonitor.Name = "CapturedMonitor";
            this.CapturedMonitor.Size = new System.Drawing.Size(222, 29);
            this.CapturedMonitor.Style = MetroFramework.MetroColorStyle.Black;
            this.CapturedMonitor.TabIndex = 31;
            this.CapturedMonitor.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.CapturedMonitor.UseSelectable = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(2, 336);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(108, 19);
            this.metroLabel4.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel4.TabIndex = 30;
            this.metroLabel4.Text = "Captured device";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // CapturedDevice
            // 
            this.CapturedDevice.BackColor = System.Drawing.Color.Black;
            this.CapturedDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CapturedDevice.FormattingEnabled = true;
            this.CapturedDevice.ItemHeight = 23;
            this.CapturedDevice.Location = new System.Drawing.Point(2, 359);
            this.CapturedDevice.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CapturedDevice.Name = "CapturedDevice";
            this.CapturedDevice.Size = new System.Drawing.Size(222, 29);
            this.CapturedDevice.Style = MetroFramework.MetroColorStyle.Black;
            this.CapturedDevice.TabIndex = 29;
            this.CapturedDevice.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.CapturedDevice.UseSelectable = true;
            this.CapturedDevice.SelectedIndexChanged += new System.EventHandler(this.CapturedDeviceSelectedIndexChanged);
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel11.Location = new System.Drawing.Point(2, 580);
            this.metroLabel11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(87, 19);
            this.metroLabel11.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel11.TabIndex = 28;
            this.metroLabel11.Text = "Vertical LEDs";
            this.metroLabel11.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel10.Location = new System.Drawing.Point(2, 536);
            this.metroLabel10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(106, 19);
            this.metroLabel10.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel10.TabIndex = 27;
            this.metroLabel10.Text = "Horizontal LEDs";
            this.metroLabel10.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // LedsY
            // 
            this.LedsY.BackColor = System.Drawing.Color.Transparent;
            this.LedsY.ForeColor = System.Drawing.Color.Black;
            this.LedsY.Location = new System.Drawing.Point(2, 602);
            this.LedsY.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LedsY.Maximum = 60;
            this.LedsY.Minimum = 1;
            this.LedsY.Name = "LedsY";
            this.LedsY.Size = new System.Drawing.Size(222, 20);
            this.LedsY.TabIndex = 24;
            this.LedsY.Tag = "";
            this.LedsY.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.LedsY.Value = 18;
            this.LedsY.ValueChanged += new System.EventHandler(this.LedsY_ValueChanged);
            // 
            // LedsX
            // 
            this.LedsX.BackColor = System.Drawing.Color.Transparent;
            this.LedsX.ForeColor = System.Drawing.Color.Black;
            this.LedsX.Location = new System.Drawing.Point(2, 559);
            this.LedsX.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LedsX.Maximum = 60;
            this.LedsX.Minimum = 1;
            this.LedsX.Name = "LedsX";
            this.LedsX.Size = new System.Drawing.Size(222, 20);
            this.LedsX.TabIndex = 23;
            this.LedsX.Tag = "";
            this.LedsX.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.LedsX.Value = 32;
            this.LedsX.ValueChanged += new System.EventHandler(this.LedsX_ValueChanged);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(2, 281);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(127, 19);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel3.TabIndex = 13;
            this.metroLabel3.Text = "Interpolation mode";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(2, 9);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(64, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel2.TabIndex = 12;
            this.metroLabel2.Text = "Baudrate";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // ComPort
            // 
            this.ComPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComPort.FormattingEnabled = true;
            this.ComPort.ItemHeight = 23;
            this.ComPort.Location = new System.Drawing.Point(117, 31);
            this.ComPort.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ComPort.Name = "ComPort";
            this.ComPort.Size = new System.Drawing.Size(107, 29);
            this.ComPort.Style = MetroFramework.MetroColorStyle.Black;
            this.ComPort.TabIndex = 5;
            this.ComPort.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ComPort.UseSelectable = true;
            this.ComPort.SelectedIndexChanged += new System.EventHandler(this.ComPort_SelectedIndexChanged);
            this.ComPort.Click += new System.EventHandler(this.ComPort_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(153, 9);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(71, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel1.TabIndex = 11;
            this.metroLabel1.Text = "COM Port";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // BaudRate
            // 
            this.BaudRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BaudRate.FormattingEnabled = true;
            this.BaudRate.ItemHeight = 23;
            this.BaudRate.Location = new System.Drawing.Point(2, 31);
            this.BaudRate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.BaudRate.Name = "BaudRate";
            this.BaudRate.Size = new System.Drawing.Size(111, 29);
            this.BaudRate.Style = MetroFramework.MetroColorStyle.Black;
            this.BaudRate.TabIndex = 6;
            this.BaudRate.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.BaudRate.UseSelectable = true;
            this.BaudRate.SelectedIndexChanged += new System.EventHandler(this.BaudRate_SelectedIndexChanged);
            // 
            // InterpMode
            // 
            this.InterpMode.BackColor = System.Drawing.Color.Black;
            this.InterpMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InterpMode.FormattingEnabled = true;
            this.InterpMode.ItemHeight = 23;
            this.InterpMode.Location = new System.Drawing.Point(2, 304);
            this.InterpMode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.InterpMode.Name = "InterpMode";
            this.InterpMode.Size = new System.Drawing.Size(222, 29);
            this.InterpMode.Style = MetroFramework.MetroColorStyle.Black;
            this.InterpMode.TabIndex = 7;
            this.InterpMode.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.InterpMode.UseSelectable = true;
            this.InterpMode.SelectedIndexChanged += new System.EventHandler(this.InterpMode_SelectedIndexChanged);
            // 
            // HomeTab
            // 
            this.HomeTab.Controls.Add(this.ColorSelection);
            this.HomeTab.Controls.Add(this.PrevAwayMode);
            this.HomeTab.Controls.Add(this.PreventSleep);
            this.HomeTab.Controls.Add(this.PrevSleep);
            this.HomeTab.Controls.Add(this.PreventAwayMode);
            this.HomeTab.Controls.Add(this.StartUpLabel);
            this.HomeTab.Controls.Add(this.SelectColor);
            this.HomeTab.Controls.Add(this.metroLabel19);
            this.HomeTab.Controls.Add(this.AmbilightModes);
            this.HomeTab.Controls.Add(this.FadeTiming);
            this.HomeTab.Controls.Add(this.StartStop);
            this.HomeTab.Controls.Add(this.Default_Timings);
            this.HomeTab.HorizontalScrollbarBarColor = true;
            this.HomeTab.HorizontalScrollbarHighlightOnWheel = false;
            this.HomeTab.HorizontalScrollbarSize = 10;
            this.HomeTab.Location = new System.Drawing.Point(4, 38);
            this.HomeTab.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.HomeTab.Name = "HomeTab";
            this.HomeTab.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.HomeTab.Size = new System.Drawing.Size(242, 230);
            this.HomeTab.TabIndex = 0;
            this.HomeTab.Text = "Home";
            this.HomeTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.HomeTab.VerticalScrollbarBarColor = true;
            this.HomeTab.VerticalScrollbarHighlightOnWheel = false;
            this.HomeTab.VerticalScrollbarSize = 10;
            // 
            // ColorSelection
            // 
            this.ColorSelection.BackColor = System.Drawing.SystemColors.WindowText;
            this.ColorSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColorSelection.FormattingEnabled = true;
            this.ColorSelection.ItemHeight = 23;
            this.ColorSelection.Location = new System.Drawing.Point(2, 94);
            this.ColorSelection.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ColorSelection.Name = "ColorSelection";
            this.ColorSelection.Size = new System.Drawing.Size(184, 29);
            this.ColorSelection.Style = MetroFramework.MetroColorStyle.Black;
            this.ColorSelection.TabIndex = 80;
            this.ColorSelection.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ColorSelection.UseSelectable = true;
            this.ColorSelection.SelectedIndexChanged += new System.EventHandler(this.ColorSelection_SelectedIndexChanged);
            this.ColorSelection.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ColorDeletionPressed);
            this.ColorSelection.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ColorDeletionReleased);
            // 
            // PrevAwayMode
            // 
            this.PrevAwayMode.AutoSize = true;
            this.PrevAwayMode.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.PrevAwayMode.Location = new System.Drawing.Point(2, 183);
            this.PrevAwayMode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PrevAwayMode.Name = "PrevAwayMode";
            this.PrevAwayMode.Size = new System.Drawing.Size(126, 19);
            this.PrevAwayMode.Style = MetroFramework.MetroColorStyle.Black;
            this.PrevAwayMode.TabIndex = 70;
            this.PrevAwayMode.Text = "Prevent awaymode";
            this.PrevAwayMode.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // PreventSleep
            // 
            this.PreventSleep.AutoSize = true;
            this.PreventSleep.DisplayStatus = false;
            this.PreventSleep.Location = new System.Drawing.Point(190, 161);
            this.PreventSleep.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.PreventSleep.Name = "PreventSleep";
            this.PreventSleep.Size = new System.Drawing.Size(50, 17);
            this.PreventSleep.Style = MetroFramework.MetroColorStyle.Black;
            this.PreventSleep.TabIndex = 67;
            this.PreventSleep.Text = "Off";
            this.PreventSleep.UseSelectable = true;
            this.PreventSleep.CheckStateChanged += new System.EventHandler(this.PreventSleep_CheckStateChanged);
            // 
            // PrevSleep
            // 
            this.PrevSleep.AutoSize = true;
            this.PrevSleep.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.PrevSleep.Location = new System.Drawing.Point(2, 159);
            this.PrevSleep.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PrevSleep.Name = "PrevSleep";
            this.PrevSleep.Size = new System.Drawing.Size(91, 19);
            this.PrevSleep.Style = MetroFramework.MetroColorStyle.Black;
            this.PrevSleep.TabIndex = 68;
            this.PrevSleep.Text = "Prevent sleep";
            this.PrevSleep.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // PreventAwayMode
            // 
            this.PreventAwayMode.AutoSize = true;
            this.PreventAwayMode.DisplayStatus = false;
            this.PreventAwayMode.Enabled = false;
            this.PreventAwayMode.Location = new System.Drawing.Point(190, 184);
            this.PreventAwayMode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.PreventAwayMode.Name = "PreventAwayMode";
            this.PreventAwayMode.Size = new System.Drawing.Size(50, 17);
            this.PreventAwayMode.Style = MetroFramework.MetroColorStyle.Black;
            this.PreventAwayMode.TabIndex = 69;
            this.PreventAwayMode.Text = "Off";
            this.PreventAwayMode.UseSelectable = true;
            // 
            // StartUpLabel
            // 
            this.StartUpLabel.AutoSize = true;
            this.StartUpLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.StartUpLabel.Location = new System.Drawing.Point(2, 136);
            this.StartUpLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.StartUpLabel.Name = "StartUpLabel";
            this.StartUpLabel.Size = new System.Drawing.Size(64, 19);
            this.StartUpLabel.Style = MetroFramework.MetroColorStyle.Black;
            this.StartUpLabel.TabIndex = 65;
            this.StartUpLabel.Text = "Start Up!";
            this.StartUpLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // SelectColor
            // 
            this.SelectColor.Location = new System.Drawing.Point(190, 94);
            this.SelectColor.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SelectColor.Name = "SelectColor";
            this.SelectColor.Size = new System.Drawing.Size(50, 29);
            this.SelectColor.Style = MetroFramework.MetroColorStyle.Black;
            this.SelectColor.TabIndex = 62;
            this.SelectColor.Text = "Pick";
            this.SelectColor.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.SelectColor.UseSelectable = true;
            this.SelectColor.Click += new System.EventHandler(this.SelectColor_Click);
            // 
            // metroLabel19
            // 
            this.metroLabel19.AutoSize = true;
            this.metroLabel19.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel19.Location = new System.Drawing.Point(6, 9);
            this.metroLabel19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel19.Name = "metroLabel19";
            this.metroLabel19.Size = new System.Drawing.Size(108, 19);
            this.metroLabel19.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel19.TabIndex = 63;
            this.metroLabel19.Text = "Ambilight Mode";
            this.metroLabel19.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // AmbilightModes
            // 
            this.AmbilightModes.BackColor = System.Drawing.SystemColors.WindowText;
            this.AmbilightModes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AmbilightModes.FormattingEnabled = true;
            this.AmbilightModes.ItemHeight = 23;
            this.AmbilightModes.Location = new System.Drawing.Point(2, 31);
            this.AmbilightModes.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.AmbilightModes.Name = "AmbilightModes";
            this.AmbilightModes.Size = new System.Drawing.Size(238, 29);
            this.AmbilightModes.Style = MetroFramework.MetroColorStyle.Black;
            this.AmbilightModes.TabIndex = 61;
            this.AmbilightModes.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.AmbilightModes.UseSelectable = true;
            this.AmbilightModes.SelectedIndexChanged += new System.EventHandler(this.AmbilightModes_SelectedIndexChanged);
            // 
            // FadeTiming
            // 
            this.FadeTiming.BackColor = System.Drawing.Color.Transparent;
            this.FadeTiming.ForeColor = System.Drawing.Color.Black;
            this.FadeTiming.Location = new System.Drawing.Point(2, 66);
            this.FadeTiming.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.FadeTiming.Maximum = 1000;
            this.FadeTiming.MouseWheelBarPartitions = 1;
            this.FadeTiming.Name = "FadeTiming";
            this.FadeTiming.Size = new System.Drawing.Size(238, 21);
            this.FadeTiming.TabIndex = 60;
            this.FadeTiming.Tag = "";
            this.FadeTiming.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTiming.Value = 100;
            this.FadeTiming.ValueChanged += new System.EventHandler(this.FadeTimingValueChanged);
            // 
            // StartStop
            // 
            this.StartStop.AutoSize = true;
            this.StartStop.DisplayStatus = false;
            this.StartStop.Location = new System.Drawing.Point(190, 138);
            this.StartStop.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.StartStop.Name = "StartStop";
            this.StartStop.Size = new System.Drawing.Size(50, 17);
            this.StartStop.Style = MetroFramework.MetroColorStyle.Black;
            this.StartStop.TabIndex = 59;
            this.StartStop.Text = "Off";
            this.StartStop.UseSelectable = true;
            this.StartStop.CheckStateChanged += new System.EventHandler(this.StartStop_CheckStateChanged);
            // 
            // Default_Timings
            // 
            this.Default_Timings.AutoSize = true;
            this.Default_Timings.Location = new System.Drawing.Point(2, 209);
            this.Default_Timings.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Default_Timings.Name = "Default_Timings";
            this.Default_Timings.Size = new System.Drawing.Size(96, 19);
            this.Default_Timings.TabIndex = 10;
            this.Default_Timings.Text = "Press Start Up!";
            this.Default_Timings.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // ControlTabs
            // 
            this.ControlTabs.Controls.Add(this.HomeTab);
            this.ControlTabs.Controls.Add(this.SettingsTab);
            this.ControlTabs.HotTrack = true;
            this.ControlTabs.Location = new System.Drawing.Point(0, 63);
            this.ControlTabs.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ControlTabs.Name = "ControlTabs";
            this.ControlTabs.SelectedIndex = 1;
            this.ControlTabs.Size = new System.Drawing.Size(250, 272);
            this.ControlTabs.Style = MetroFramework.MetroColorStyle.Black;
            this.ControlTabs.TabIndex = 17;
            this.ControlTabs.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ControlTabs.UseSelectable = true;
            // 
            // TrayIconMenu
            // 
            this.TrayIconMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.TrayIconMenu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TrayIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.TrayIconMenu.Name = "TrayIconMenu";
            this.TrayIconMenu.ShowImageMargin = false;
            this.TrayIconMenu.Size = new System.Drawing.Size(81, 70);
            this.TrayIconMenu.Style = MetroFramework.MetroColorStyle.Black;
            this.TrayIconMenu.TabStop = true;
            this.TrayIconMenu.Text = "Ambilight";
            this.TrayIconMenu.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TrayIconMenu.UseSelectable = true;
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(80, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.StartStopFromTrayClicked);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(80, 22);
            this.openToolStripMenuItem.Text = "Hide";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenFromTrayClicked);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(80, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitFromTrayClicked);
            // 
            // ToolTip
            // 
            this.ToolTip.Style = MetroFramework.MetroColorStyle.Black;
            this.ToolTip.StyleManager = null;
            this.ToolTip.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // BlackStyleManager
            // 
            this.BlackStyleManager.Owner = this;
            this.BlackStyleManager.Style = MetroFramework.MetroColorStyle.Black;
            this.BlackStyleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Enabled = false;
            this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel7.Location = new System.Drawing.Point(117, 156);
            this.metroLabel7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(50, 19);
            this.metroLabel7.TabIndex = 99;
            this.metroLabel7.Text = "Height";
            this.metroLabel7.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Enabled = false;
            this.metroLabel8.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel8.Location = new System.Drawing.Point(2, 156);
            this.metroLabel8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(46, 19);
            this.metroLabel8.TabIndex = 100;
            this.metroLabel8.Text = "Width";
            this.metroLabel8.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // DynamicAmbilight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 336);
            this.ContextMenuStrip = this.TrayIconMenu;
            this.Controls.Add(this.ControlTabs);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "DynamicAmbilight";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Text = "Dynamic Ambilight";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TopMost = true;
            this.SettingsTab.ResumeLayout(false);
            this.SettingsTab.PerformLayout();
            this.HomeTab.ResumeLayout(false);
            this.HomeTab.PerformLayout();
            this.ControlTabs.ResumeLayout(false);
            this.TrayIconMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BlackStyleManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon Tray_Icon;
        private MetroFramework.Controls.MetroTabPage SettingsTab;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroTrackBar LedsY;
        private MetroFramework.Controls.MetroTrackBar LedsX;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroComboBox ComPort;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox BaudRate;
        private MetroFramework.Controls.MetroComboBox InterpMode;
        private MetroFramework.Controls.MetroTabPage HomeTab;
        private MetroFramework.Controls.MetroLabel Default_Timings;
        private MetroFramework.Controls.MetroTabControl ControlTabs;
        private MetroFramework.Controls.MetroLabel StartUpLabel;
        private MetroFramework.Controls.MetroButton SelectColor;
        private MetroFramework.Controls.MetroLabel metroLabel19;
        private MetroFramework.Controls.MetroComboBox AmbilightModes;
        private MetroFramework.Controls.MetroTrackBar FadeTiming;
        private MetroFramework.Controls.MetroLabel PrevAwayMode;
        private MetroFramework.Controls.MetroToggle PreventSleep;
        private MetroFramework.Controls.MetroLabel PrevSleep;
        private MetroFramework.Controls.MetroToggle PreventAwayMode;
        private MetroFramework.Controls.MetroToggle StartStop;
        private MetroFramework.Controls.MetroComboBox ColorSelection;
        private MetroFramework.Controls.MetroContextMenu TrayIconMenu;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private MetroFramework.Components.MetroToolTip ToolTip;
        private MetroFramework.Components.MetroStyleManager BlackStyleManager;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroComboBox CapturedDevice;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroComboBox CapturedMonitor;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel DefAudioInput;
        private MetroFramework.Controls.MetroToggle UseDefaultAudio;
        private MetroFramework.Controls.MetroComboBox AudioInputs;
        private MetroFramework.Controls.MetroComboBox CaptureArea;
        private MetroFramework.Controls.MetroLabel metroLabel18;
        private MetroFramework.Controls.MetroLabel metroLabel16;
        private MetroFramework.Controls.MetroLabel metroLabel14;
        private MetroFramework.Controls.MetroTextBox LeftOffset;
        private MetroFramework.Controls.MetroTextBox LowerOffset;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroTextBox RightOffset;
        private MetroFramework.Controls.MetroTextBox CustomHeight;
        private MetroFramework.Controls.MetroTextBox UpperOffset;
        private MetroFramework.Controls.MetroLabel UpperOffsetLabel;
        private MetroFramework.Controls.MetroLabel metroLabel15;
        private MetroFramework.Controls.MetroTextBox CustomWidth;
        private MetroFramework.Controls.MetroLabel metroLabel13;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel7;
    }
}

