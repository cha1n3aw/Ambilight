namespace Dynamic_Ambilight
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
            this.Tray_Icon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ModesTab = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel18 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel17 = new MetroFramework.Controls.MetroLabel();
            this.CustomHeight = new MetroFramework.Controls.MetroTextBox();
            this.CustomWidth = new MetroFramework.Controls.MetroTextBox();
            this.CaptureMode = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel16 = new MetroFramework.Controls.MetroLabel();
            this.RightOffset = new MetroFramework.Controls.MetroTextBox();
            this.LeftOffset = new MetroFramework.Controls.MetroTextBox();
            this.LowerOffset = new MetroFramework.Controls.MetroTextBox();
            this.UpperOffset = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel15 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            this.UpperOffsetLabel = new MetroFramework.Controls.MetroLabel();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel14 = new MetroFramework.Controls.MetroLabel();
            this.SettingsTab = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.LedsY = new MetroFramework.Controls.MetroTrackBar();
            this.LedsX = new MetroFramework.Controls.MetroTrackBar();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.RefreshButton = new MetroFramework.Controls.MetroButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.ComPort = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.BaudRate = new MetroFramework.Controls.MetroComboBox();
            this.InterpMode = new MetroFramework.Controls.MetroComboBox();
            this.HomeTab = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.PreventSleep = new MetroFramework.Controls.MetroToggle();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.PreventAwayMode = new MetroFramework.Controls.MetroToggle();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.FPSChanger = new MetroFramework.Controls.MetroTrackBar();
            this.Default_Timings = new MetroFramework.Controls.MetroLabel();
            this.Custom_Timings = new MetroFramework.Controls.MetroLabel();
            this.StartStopButton = new MetroFramework.Controls.MetroButton();
            this.TestButton = new MetroFramework.Controls.MetroButton();
            this.ControlTabs = new MetroFramework.Controls.MetroTabControl();
            this.ModesTab.SuspendLayout();
            this.SettingsTab.SuspendLayout();
            this.HomeTab.SuspendLayout();
            this.ControlTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tray_Icon
            // 
            this.Tray_Icon.Icon = ((System.Drawing.Icon)(resources.GetObject("Tray_Icon.Icon")));
            this.Tray_Icon.Text = "notifyIcon1";
            this.Tray_Icon.Visible = true;
            this.Tray_Icon.BalloonTipClicked += new System.EventHandler(this.Tray_Icon_BalloonTipClicked);
            this.Tray_Icon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Tray_Icon_MouseDoubleClick);
            // 
            // ModesTab
            // 
            this.ModesTab.Controls.Add(this.metroLabel18);
            this.ModesTab.Controls.Add(this.metroLabel17);
            this.ModesTab.Controls.Add(this.CustomHeight);
            this.ModesTab.Controls.Add(this.CustomWidth);
            this.ModesTab.Controls.Add(this.CaptureMode);
            this.ModesTab.Controls.Add(this.metroLabel16);
            this.ModesTab.Controls.Add(this.RightOffset);
            this.ModesTab.Controls.Add(this.LeftOffset);
            this.ModesTab.Controls.Add(this.LowerOffset);
            this.ModesTab.Controls.Add(this.UpperOffset);
            this.ModesTab.Controls.Add(this.metroLabel15);
            this.ModesTab.Controls.Add(this.metroLabel13);
            this.ModesTab.Controls.Add(this.UpperOffsetLabel);
            this.ModesTab.Controls.Add(this.metroLabel12);
            this.ModesTab.Controls.Add(this.metroLabel14);
            this.ModesTab.HorizontalScrollbarBarColor = true;
            this.ModesTab.HorizontalScrollbarHighlightOnWheel = false;
            this.ModesTab.HorizontalScrollbarSize = 10;
            this.ModesTab.Location = new System.Drawing.Point(4, 38);
            this.ModesTab.Name = "ModesTab";
            this.ModesTab.Size = new System.Drawing.Size(194, 292);
            this.ModesTab.Style = MetroFramework.MetroColorStyle.Black;
            this.ModesTab.TabIndex = 2;
            this.ModesTab.Text = "Modes";
            this.ModesTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ModesTab.VerticalScrollbarBarColor = true;
            this.ModesTab.VerticalScrollbarHighlightOnWheel = false;
            this.ModesTab.VerticalScrollbarSize = 10;
            // 
            // metroLabel18
            // 
            this.metroLabel18.AutoSize = true;
            this.metroLabel18.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel18.Location = new System.Drawing.Point(0, 83);
            this.metroLabel18.Name = "metroLabel18";
            this.metroLabel18.Size = new System.Drawing.Size(125, 19);
            this.metroLabel18.TabIndex = 57;
            this.metroLabel18.Text = "Custom Resolution";
            this.metroLabel18.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel17
            // 
            this.metroLabel17.AutoSize = true;
            this.metroLabel17.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel17.Location = new System.Drawing.Point(87, 109);
            this.metroLabel17.Name = "metroLabel17";
            this.metroLabel17.Size = new System.Drawing.Size(18, 19);
            this.metroLabel17.TabIndex = 56;
            this.metroLabel17.Text = "X";
            this.metroLabel17.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // CustomHeight
            // 
            // 
            // 
            // 
            this.CustomHeight.CustomButton.Image = null;
            this.CustomHeight.CustomButton.Location = new System.Drawing.Point(58, 1);
            this.CustomHeight.CustomButton.Name = "";
            this.CustomHeight.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.CustomHeight.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.CustomHeight.CustomButton.TabIndex = 1;
            this.CustomHeight.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.CustomHeight.CustomButton.UseSelectable = true;
            this.CustomHeight.CustomButton.Visible = false;
            this.CustomHeight.Enabled = false;
            this.CustomHeight.Lines = new string[] {
        "0"};
            this.CustomHeight.Location = new System.Drawing.Point(111, 105);
            this.CustomHeight.MaxLength = 32767;
            this.CustomHeight.Name = "CustomHeight";
            this.CustomHeight.PasswordChar = '\0';
            this.CustomHeight.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.CustomHeight.SelectedText = "";
            this.CustomHeight.SelectionLength = 0;
            this.CustomHeight.SelectionStart = 0;
            this.CustomHeight.ShortcutsEnabled = true;
            this.CustomHeight.Size = new System.Drawing.Size(80, 23);
            this.CustomHeight.Style = MetroFramework.MetroColorStyle.Black;
            this.CustomHeight.TabIndex = 55;
            this.CustomHeight.Text = "0";
            this.CustomHeight.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.CustomHeight.UseSelectable = true;
            this.CustomHeight.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.CustomHeight.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.CustomHeight.TextChanged += new System.EventHandler(this.CustomHeight_TextChanged);
            // 
            // CustomWidth
            // 
            // 
            // 
            // 
            this.CustomWidth.CustomButton.Image = null;
            this.CustomWidth.CustomButton.Location = new System.Drawing.Point(56, 1);
            this.CustomWidth.CustomButton.Name = "";
            this.CustomWidth.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.CustomWidth.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.CustomWidth.CustomButton.TabIndex = 1;
            this.CustomWidth.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.CustomWidth.CustomButton.UseSelectable = true;
            this.CustomWidth.CustomButton.Visible = false;
            this.CustomWidth.Enabled = false;
            this.CustomWidth.Lines = new string[] {
        "0"};
            this.CustomWidth.Location = new System.Drawing.Point(3, 105);
            this.CustomWidth.MaxLength = 32767;
            this.CustomWidth.Name = "CustomWidth";
            this.CustomWidth.PasswordChar = '\0';
            this.CustomWidth.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.CustomWidth.SelectedText = "";
            this.CustomWidth.SelectionLength = 0;
            this.CustomWidth.SelectionStart = 0;
            this.CustomWidth.ShortcutsEnabled = true;
            this.CustomWidth.Size = new System.Drawing.Size(78, 23);
            this.CustomWidth.Style = MetroFramework.MetroColorStyle.Black;
            this.CustomWidth.TabIndex = 54;
            this.CustomWidth.Text = "0";
            this.CustomWidth.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.CustomWidth.UseSelectable = true;
            this.CustomWidth.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.CustomWidth.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.CustomWidth.TextChanged += new System.EventHandler(this.CustomWidth_TextChanged);
            // 
            // CaptureMode
            // 
            this.CaptureMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CaptureMode.FormattingEnabled = true;
            this.CaptureMode.ItemHeight = 23;
            this.CaptureMode.Location = new System.Drawing.Point(3, 40);
            this.CaptureMode.Name = "CaptureMode";
            this.CaptureMode.Size = new System.Drawing.Size(188, 29);
            this.CaptureMode.Style = MetroFramework.MetroColorStyle.Black;
            this.CaptureMode.TabIndex = 53;
            this.CaptureMode.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.CaptureMode.UseSelectable = true;
            this.CaptureMode.SelectedIndexChanged += new System.EventHandler(this.CaptureMode_SelectedIndexChanged);
            // 
            // metroLabel16
            // 
            this.metroLabel16.AutoSize = true;
            this.metroLabel16.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel16.Location = new System.Drawing.Point(0, 18);
            this.metroLabel16.Name = "metroLabel16";
            this.metroLabel16.Size = new System.Drawing.Size(98, 19);
            this.metroLabel16.TabIndex = 52;
            this.metroLabel16.Text = "Capture Mode";
            this.metroLabel16.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // RightOffset
            // 
            // 
            // 
            // 
            this.RightOffset.CustomButton.Image = null;
            this.RightOffset.CustomButton.Location = new System.Drawing.Point(58, 1);
            this.RightOffset.CustomButton.Name = "";
            this.RightOffset.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.RightOffset.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.RightOffset.CustomButton.TabIndex = 1;
            this.RightOffset.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.RightOffset.CustomButton.UseSelectable = true;
            this.RightOffset.CustomButton.Visible = false;
            this.RightOffset.Enabled = false;
            this.RightOffset.Lines = new string[] {
        "0"};
            this.RightOffset.Location = new System.Drawing.Point(111, 261);
            this.RightOffset.MaxLength = 32767;
            this.RightOffset.Name = "RightOffset";
            this.RightOffset.PasswordChar = '\0';
            this.RightOffset.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.RightOffset.SelectedText = "";
            this.RightOffset.SelectionLength = 0;
            this.RightOffset.SelectionStart = 0;
            this.RightOffset.ShortcutsEnabled = true;
            this.RightOffset.Size = new System.Drawing.Size(80, 23);
            this.RightOffset.Style = MetroFramework.MetroColorStyle.Black;
            this.RightOffset.TabIndex = 50;
            this.RightOffset.Text = "0";
            this.RightOffset.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.RightOffset.UseSelectable = true;
            this.RightOffset.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.RightOffset.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.RightOffset.TextChanged += new System.EventHandler(this.RightOffset_TextChanged);
            // 
            // LeftOffset
            // 
            // 
            // 
            // 
            this.LeftOffset.CustomButton.Image = null;
            this.LeftOffset.CustomButton.Location = new System.Drawing.Point(58, 1);
            this.LeftOffset.CustomButton.Name = "";
            this.LeftOffset.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.LeftOffset.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.LeftOffset.CustomButton.TabIndex = 1;
            this.LeftOffset.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.LeftOffset.CustomButton.UseSelectable = true;
            this.LeftOffset.CustomButton.Visible = false;
            this.LeftOffset.Enabled = false;
            this.LeftOffset.Lines = new string[] {
        "0"};
            this.LeftOffset.Location = new System.Drawing.Point(111, 232);
            this.LeftOffset.MaxLength = 32767;
            this.LeftOffset.Name = "LeftOffset";
            this.LeftOffset.PasswordChar = '\0';
            this.LeftOffset.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.LeftOffset.SelectedText = "";
            this.LeftOffset.SelectionLength = 0;
            this.LeftOffset.SelectionStart = 0;
            this.LeftOffset.ShortcutsEnabled = true;
            this.LeftOffset.Size = new System.Drawing.Size(80, 23);
            this.LeftOffset.Style = MetroFramework.MetroColorStyle.Black;
            this.LeftOffset.TabIndex = 49;
            this.LeftOffset.Text = "0";
            this.LeftOffset.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.LeftOffset.UseSelectable = true;
            this.LeftOffset.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.LeftOffset.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.LeftOffset.TextChanged += new System.EventHandler(this.LeftOffset_TextChanged);
            // 
            // LowerOffset
            // 
            // 
            // 
            // 
            this.LowerOffset.CustomButton.Image = null;
            this.LowerOffset.CustomButton.Location = new System.Drawing.Point(58, 1);
            this.LowerOffset.CustomButton.Name = "";
            this.LowerOffset.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.LowerOffset.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.LowerOffset.CustomButton.TabIndex = 1;
            this.LowerOffset.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.LowerOffset.CustomButton.UseSelectable = true;
            this.LowerOffset.CustomButton.Visible = false;
            this.LowerOffset.Enabled = false;
            this.LowerOffset.Lines = new string[] {
        "0"};
            this.LowerOffset.Location = new System.Drawing.Point(111, 203);
            this.LowerOffset.MaxLength = 32767;
            this.LowerOffset.Name = "LowerOffset";
            this.LowerOffset.PasswordChar = '\0';
            this.LowerOffset.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.LowerOffset.SelectedText = "";
            this.LowerOffset.SelectionLength = 0;
            this.LowerOffset.SelectionStart = 0;
            this.LowerOffset.ShortcutsEnabled = true;
            this.LowerOffset.Size = new System.Drawing.Size(80, 23);
            this.LowerOffset.Style = MetroFramework.MetroColorStyle.Black;
            this.LowerOffset.TabIndex = 48;
            this.LowerOffset.Text = "0";
            this.LowerOffset.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.LowerOffset.UseSelectable = true;
            this.LowerOffset.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.LowerOffset.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.LowerOffset.TextChanged += new System.EventHandler(this.LowerOffset_TextChanged);
            // 
            // UpperOffset
            // 
            // 
            // 
            // 
            this.UpperOffset.CustomButton.Image = null;
            this.UpperOffset.CustomButton.Location = new System.Drawing.Point(58, 1);
            this.UpperOffset.CustomButton.Name = "";
            this.UpperOffset.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.UpperOffset.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.UpperOffset.CustomButton.TabIndex = 1;
            this.UpperOffset.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.UpperOffset.CustomButton.UseSelectable = true;
            this.UpperOffset.CustomButton.Visible = false;
            this.UpperOffset.Enabled = false;
            this.UpperOffset.Lines = new string[] {
        "0"};
            this.UpperOffset.Location = new System.Drawing.Point(111, 174);
            this.UpperOffset.MaxLength = 32767;
            this.UpperOffset.Name = "UpperOffset";
            this.UpperOffset.PasswordChar = '\0';
            this.UpperOffset.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.UpperOffset.SelectedText = "";
            this.UpperOffset.SelectionLength = 0;
            this.UpperOffset.SelectionStart = 0;
            this.UpperOffset.ShortcutsEnabled = true;
            this.UpperOffset.Size = new System.Drawing.Size(80, 23);
            this.UpperOffset.Style = MetroFramework.MetroColorStyle.Black;
            this.UpperOffset.TabIndex = 47;
            this.UpperOffset.Text = "0";
            this.UpperOffset.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.UpperOffset.UseSelectable = true;
            this.UpperOffset.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.UpperOffset.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.UpperOffset.TextChanged += new System.EventHandler(this.UpperOffset_TextChanged);
            // 
            // metroLabel15
            // 
            this.metroLabel15.AutoSize = true;
            this.metroLabel15.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel15.Location = new System.Drawing.Point(3, 152);
            this.metroLabel15.Name = "metroLabel15";
            this.metroLabel15.Size = new System.Drawing.Size(104, 19);
            this.metroLabel15.TabIndex = 46;
            this.metroLabel15.Text = "Custom Offsets";
            this.metroLabel15.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.Enabled = false;
            this.metroLabel13.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel13.Location = new System.Drawing.Point(3, 232);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(73, 19);
            this.metroLabel13.TabIndex = 44;
            this.metroLabel13.Text = "Left Offset";
            this.metroLabel13.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // UpperOffsetLabel
            // 
            this.UpperOffsetLabel.AutoSize = true;
            this.UpperOffsetLabel.Enabled = false;
            this.UpperOffsetLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.UpperOffsetLabel.Location = new System.Drawing.Point(3, 174);
            this.UpperOffsetLabel.Name = "UpperOffsetLabel";
            this.UpperOffsetLabel.Size = new System.Drawing.Size(88, 19);
            this.UpperOffsetLabel.TabIndex = 39;
            this.UpperOffsetLabel.Text = "Upper Offset";
            this.UpperOffsetLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.Enabled = false;
            this.metroLabel12.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel12.Location = new System.Drawing.Point(3, 203);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(87, 19);
            this.metroLabel12.TabIndex = 40;
            this.metroLabel12.Text = "Lower Offset";
            this.metroLabel12.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel14
            // 
            this.metroLabel14.AutoSize = true;
            this.metroLabel14.Enabled = false;
            this.metroLabel14.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel14.Location = new System.Drawing.Point(3, 261);
            this.metroLabel14.Name = "metroLabel14";
            this.metroLabel14.Size = new System.Drawing.Size(82, 19);
            this.metroLabel14.TabIndex = 45;
            this.metroLabel14.Text = "Right Offset";
            this.metroLabel14.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // SettingsTab
            // 
            this.SettingsTab.Controls.Add(this.metroLabel11);
            this.SettingsTab.Controls.Add(this.metroLabel10);
            this.SettingsTab.Controls.Add(this.metroLabel9);
            this.SettingsTab.Controls.Add(this.metroLabel8);
            this.SettingsTab.Controls.Add(this.LedsY);
            this.SettingsTab.Controls.Add(this.LedsX);
            this.SettingsTab.Controls.Add(this.metroLabel3);
            this.SettingsTab.Controls.Add(this.RefreshButton);
            this.SettingsTab.Controls.Add(this.metroLabel2);
            this.SettingsTab.Controls.Add(this.ComPort);
            this.SettingsTab.Controls.Add(this.metroLabel1);
            this.SettingsTab.Controls.Add(this.BaudRate);
            this.SettingsTab.Controls.Add(this.InterpMode);
            this.SettingsTab.HorizontalScrollbarBarColor = true;
            this.SettingsTab.HorizontalScrollbarHighlightOnWheel = false;
            this.SettingsTab.HorizontalScrollbarSize = 10;
            this.SettingsTab.Location = new System.Drawing.Point(4, 38);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.Size = new System.Drawing.Size(194, 292);
            this.SettingsTab.TabIndex = 1;
            this.SettingsTab.Text = "Settings";
            this.SettingsTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.SettingsTab.VerticalScrollbarBarColor = true;
            this.SettingsTab.VerticalScrollbarHighlightOnWheel = false;
            this.SettingsTab.VerticalScrollbarSize = 10;
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel11.Location = new System.Drawing.Point(7, 248);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(115, 19);
            this.metroLabel11.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel11.TabIndex = 28;
            this.metroLabel11.Text = "Vertical side LEDs";
            this.metroLabel11.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel10.Location = new System.Drawing.Point(7, 204);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(134, 19);
            this.metroLabel10.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel10.TabIndex = 27;
            this.metroLabel10.Text = "Horizontal side LEDs";
            this.metroLabel10.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.metroLabel9.Location = new System.Drawing.Point(168, 226);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(23, 19);
            this.metroLabel9.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel9.TabIndex = 26;
            this.metroLabel9.Text = "32";
            this.metroLabel9.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.metroLabel8.Location = new System.Drawing.Point(168, 270);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(23, 19);
            this.metroLabel8.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel8.TabIndex = 25;
            this.metroLabel8.Text = "20";
            this.metroLabel8.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // LedsY
            // 
            this.LedsY.BackColor = System.Drawing.Color.Transparent;
            this.LedsY.ForeColor = System.Drawing.Color.Black;
            this.LedsY.Location = new System.Drawing.Point(3, 270);
            this.LedsY.Maximum = 60;
            this.LedsY.Minimum = 1;
            this.LedsY.Name = "LedsY";
            this.LedsY.Size = new System.Drawing.Size(159, 19);
            this.LedsY.TabIndex = 24;
            this.LedsY.Tag = "";
            this.LedsY.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.LedsY.Value = 20;
            this.LedsY.ValueChanged += new System.EventHandler(this.LedsY_ValueChanged);
            // 
            // LedsX
            // 
            this.LedsX.BackColor = System.Drawing.Color.Transparent;
            this.LedsX.ForeColor = System.Drawing.Color.Black;
            this.LedsX.Location = new System.Drawing.Point(3, 226);
            this.LedsX.Maximum = 60;
            this.LedsX.Minimum = 1;
            this.LedsX.Name = "LedsX";
            this.LedsX.Size = new System.Drawing.Size(159, 19);
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
            this.metroLabel3.Location = new System.Drawing.Point(3, 133);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(127, 19);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel3.TabIndex = 13;
            this.metroLabel3.Text = "Interpolation mode";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(133, 37);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(58, 29);
            this.RefreshButton.TabIndex = 2;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.RefreshButton.UseSelectable = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(3, 70);
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
            this.ComPort.Location = new System.Drawing.Point(3, 37);
            this.ComPort.Name = "ComPort";
            this.ComPort.Size = new System.Drawing.Size(124, 29);
            this.ComPort.Style = MetroFramework.MetroColorStyle.Black;
            this.ComPort.TabIndex = 5;
            this.ComPort.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ComPort.UseSelectable = true;
            this.ComPort.SelectedIndexChanged += new System.EventHandler(this.ComPort_SelectedIndexChanged_1);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(3, 16);
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
            this.BaudRate.Location = new System.Drawing.Point(3, 92);
            this.BaudRate.Name = "BaudRate";
            this.BaudRate.Size = new System.Drawing.Size(188, 29);
            this.BaudRate.Style = MetroFramework.MetroColorStyle.Black;
            this.BaudRate.TabIndex = 6;
            this.BaudRate.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.BaudRate.UseSelectable = true;
            this.BaudRate.SelectedIndexChanged += new System.EventHandler(this.BaudRate_SelectedIndexChanged_1);
            // 
            // InterpMode
            // 
            this.InterpMode.BackColor = System.Drawing.Color.Black;
            this.InterpMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InterpMode.FormattingEnabled = true;
            this.InterpMode.ItemHeight = 23;
            this.InterpMode.Location = new System.Drawing.Point(3, 155);
            this.InterpMode.Name = "InterpMode";
            this.InterpMode.Size = new System.Drawing.Size(188, 29);
            this.InterpMode.Style = MetroFramework.MetroColorStyle.Black;
            this.InterpMode.TabIndex = 7;
            this.InterpMode.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.InterpMode.UseSelectable = true;
            this.InterpMode.SelectedIndexChanged += new System.EventHandler(this.InterpMode_SelectedIndexChanged_1);
            // 
            // HomeTab
            // 
            this.HomeTab.Controls.Add(this.metroLabel6);
            this.HomeTab.Controls.Add(this.PreventSleep);
            this.HomeTab.Controls.Add(this.metroLabel5);
            this.HomeTab.Controls.Add(this.PreventAwayMode);
            this.HomeTab.Controls.Add(this.metroLabel4);
            this.HomeTab.Controls.Add(this.FPSChanger);
            this.HomeTab.Controls.Add(this.Default_Timings);
            this.HomeTab.Controls.Add(this.Custom_Timings);
            this.HomeTab.Controls.Add(this.StartStopButton);
            this.HomeTab.Controls.Add(this.TestButton);
            this.HomeTab.HorizontalScrollbarBarColor = true;
            this.HomeTab.HorizontalScrollbarHighlightOnWheel = false;
            this.HomeTab.HorizontalScrollbarSize = 10;
            this.HomeTab.Location = new System.Drawing.Point(4, 38);
            this.HomeTab.Name = "HomeTab";
            this.HomeTab.Size = new System.Drawing.Size(194, 292);
            this.HomeTab.TabIndex = 0;
            this.HomeTab.Text = "Home";
            this.HomeTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.HomeTab.VerticalScrollbarBarColor = true;
            this.HomeTab.VerticalScrollbarHighlightOnWheel = false;
            this.HomeTab.VerticalScrollbarSize = 10;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel6.Location = new System.Drawing.Point(3, 98);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(126, 19);
            this.metroLabel6.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel6.TabIndex = 19;
            this.metroLabel6.Text = "Prevent awaymode";
            this.metroLabel6.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // PreventSleep
            // 
            this.PreventSleep.AutoSize = true;
            this.PreventSleep.DisplayStatus = false;
            this.PreventSleep.Location = new System.Drawing.Point(141, 77);
            this.PreventSleep.Name = "PreventSleep";
            this.PreventSleep.Size = new System.Drawing.Size(50, 17);
            this.PreventSleep.Style = MetroFramework.MetroColorStyle.Black;
            this.PreventSleep.TabIndex = 16;
            this.PreventSleep.Text = "Off";
            this.PreventSleep.UseSelectable = true;
            this.PreventSleep.CheckedChanged += new System.EventHandler(this.PreventSleep_CheckedChanged);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.Location = new System.Drawing.Point(3, 75);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(91, 19);
            this.metroLabel5.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel5.TabIndex = 17;
            this.metroLabel5.Text = "Prevent sleep";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // PreventAwayMode
            // 
            this.PreventAwayMode.AutoSize = true;
            this.PreventAwayMode.DisplayStatus = false;
            this.PreventAwayMode.Enabled = false;
            this.PreventAwayMode.Location = new System.Drawing.Point(141, 100);
            this.PreventAwayMode.Name = "PreventAwayMode";
            this.PreventAwayMode.Size = new System.Drawing.Size(50, 17);
            this.PreventAwayMode.Style = MetroFramework.MetroColorStyle.Black;
            this.PreventAwayMode.TabIndex = 18;
            this.PreventAwayMode.Text = "Off";
            this.PreventAwayMode.UseSelectable = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel4.Location = new System.Drawing.Point(12, 18);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(33, 19);
            this.metroLabel4.TabIndex = 16;
            this.metroLabel4.Text = "FPS";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // FPSChanger
            // 
            this.FPSChanger.BackColor = System.Drawing.Color.Transparent;
            this.FPSChanger.ForeColor = System.Drawing.Color.Black;
            this.FPSChanger.Location = new System.Drawing.Point(3, 40);
            this.FPSChanger.Maximum = 60;
            this.FPSChanger.Minimum = 1;
            this.FPSChanger.Name = "FPSChanger";
            this.FPSChanger.Size = new System.Drawing.Size(188, 21);
            this.FPSChanger.TabIndex = 15;
            this.FPSChanger.Tag = "";
            this.FPSChanger.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FPSChanger.Value = 10;
            this.FPSChanger.ValueChanged += new System.EventHandler(this.FPSChanger_ValueChanged);
            // 
            // Default_Timings
            // 
            this.Default_Timings.AutoSize = true;
            this.Default_Timings.Location = new System.Drawing.Point(-4, 254);
            this.Default_Timings.Name = "Default_Timings";
            this.Default_Timings.Size = new System.Drawing.Size(53, 19);
            this.Default_Timings.TabIndex = 10;
            this.Default_Timings.Text = "Default:";
            this.Default_Timings.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // Custom_Timings
            // 
            this.Custom_Timings.AutoSize = true;
            this.Custom_Timings.Location = new System.Drawing.Point(-4, 273);
            this.Custom_Timings.Name = "Custom_Timings";
            this.Custom_Timings.Size = new System.Drawing.Size(57, 19);
            this.Custom_Timings.TabIndex = 9;
            this.Custom_Timings.Text = "Custom:";
            this.Custom_Timings.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // StartStopButton
            // 
            this.StartStopButton.Location = new System.Drawing.Point(87, 133);
            this.StartStopButton.Name = "StartStopButton";
            this.StartStopButton.Size = new System.Drawing.Size(104, 31);
            this.StartStopButton.TabIndex = 1;
            this.StartStopButton.Text = "Start";
            this.StartStopButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.StartStopButton.UseSelectable = true;
            this.StartStopButton.Click += new System.EventHandler(this.StartStopButton_Click);
            // 
            // TestButton
            // 
            this.TestButton.Location = new System.Drawing.Point(3, 133);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(78, 31);
            this.TestButton.TabIndex = 0;
            this.TestButton.Text = "Test";
            this.TestButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TestButton.UseSelectable = true;
            this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // ControlTabs
            // 
            this.ControlTabs.Controls.Add(this.HomeTab);
            this.ControlTabs.Controls.Add(this.SettingsTab);
            this.ControlTabs.Controls.Add(this.ModesTab);
            this.ControlTabs.Location = new System.Drawing.Point(23, 63);
            this.ControlTabs.Name = "ControlTabs";
            this.ControlTabs.SelectedIndex = 0;
            this.ControlTabs.Size = new System.Drawing.Size(202, 334);
            this.ControlTabs.Style = MetroFramework.MetroColorStyle.Black;
            this.ControlTabs.TabIndex = 17;
            this.ControlTabs.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ControlTabs.UseSelectable = true;
            // 
            // Dynamic_Ambilight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 411);
            this.Controls.Add(this.ControlTabs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dynamic_Ambilight";
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Text = "Dynamic Ambilight";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ModesTab.ResumeLayout(false);
            this.ModesTab.PerformLayout();
            this.SettingsTab.ResumeLayout(false);
            this.SettingsTab.PerformLayout();
            this.HomeTab.ResumeLayout(false);
            this.HomeTab.PerformLayout();
            this.ControlTabs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon Tray_Icon;
        private MetroFramework.Controls.MetroTabPage ModesTab;
        private MetroFramework.Controls.MetroTabPage SettingsTab;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTrackBar LedsY;
        private MetroFramework.Controls.MetroTrackBar LedsX;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroButton RefreshButton;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroComboBox ComPort;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox BaudRate;
        private MetroFramework.Controls.MetroComboBox InterpMode;
        private MetroFramework.Controls.MetroTabPage HomeTab;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroToggle PreventSleep;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroToggle PreventAwayMode;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTrackBar FPSChanger;
        private MetroFramework.Controls.MetroLabel Default_Timings;
        private MetroFramework.Controls.MetroLabel Custom_Timings;
        private MetroFramework.Controls.MetroButton StartStopButton;
        private MetroFramework.Controls.MetroButton TestButton;
        private MetroFramework.Controls.MetroTabControl ControlTabs;
        private MetroFramework.Controls.MetroLabel metroLabel15;
        private MetroFramework.Controls.MetroLabel metroLabel13;
        private MetroFramework.Controls.MetroLabel UpperOffsetLabel;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroLabel metroLabel14;
        private MetroFramework.Controls.MetroTextBox RightOffset;
        private MetroFramework.Controls.MetroTextBox LeftOffset;
        private MetroFramework.Controls.MetroTextBox LowerOffset;
        private MetroFramework.Controls.MetroTextBox UpperOffset;
        private MetroFramework.Controls.MetroLabel metroLabel18;
        private MetroFramework.Controls.MetroLabel metroLabel17;
        private MetroFramework.Controls.MetroTextBox CustomHeight;
        private MetroFramework.Controls.MetroTextBox CustomWidth;
        private MetroFramework.Controls.MetroComboBox CaptureMode;
        private MetroFramework.Controls.MetroLabel metroLabel16;
    }
}

