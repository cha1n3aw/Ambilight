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
            this.metroLabel18 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel17 = new MetroFramework.Controls.MetroLabel();
            this.CustomHeight = new MetroFramework.Controls.MetroTextBox();
            this.CustomWidth = new MetroFramework.Controls.MetroTextBox();
            this.CaptureArea = new MetroFramework.Controls.MetroComboBox();
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
            this.LedsXLabel = new MetroFramework.Controls.MetroLabel();
            this.LedsYLabel = new MetroFramework.Controls.MetroLabel();
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
            this.ColorSelection = new MetroFramework.Controls.MetroComboBox();
            this.DefAudioInput = new MetroFramework.Controls.MetroLabel();
            this.UseDefaultAudio = new MetroFramework.Controls.MetroToggle();
            this.AudioInputs = new MetroFramework.Controls.MetroComboBox();
            this.PrevAwayMode = new MetroFramework.Controls.MetroLabel();
            this.PreventSleep = new MetroFramework.Controls.MetroToggle();
            this.PrevSleep = new MetroFramework.Controls.MetroLabel();
            this.PreventAwayMode = new MetroFramework.Controls.MetroToggle();
            this.StartUpLabel = new MetroFramework.Controls.MetroLabel();
            this.SelectColor = new MetroFramework.Controls.MetroButton();
            this.TimingLabel = new MetroFramework.Controls.MetroLabel();
            this.metroLabel19 = new MetroFramework.Controls.MetroLabel();
            this.AmbilightModes = new MetroFramework.Controls.MetroComboBox();
            this.FadeTiming = new MetroFramework.Controls.MetroTrackBar();
            this.StartStop = new MetroFramework.Controls.MetroToggle();
            this.Default_Timings = new MetroFramework.Controls.MetroLabel();
            this.ControlTabs = new MetroFramework.Controls.MetroTabControl();
            this.AreaTab = new MetroFramework.Controls.MetroTabPage();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.TrayIconMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsTab.SuspendLayout();
            this.HomeTab.SuspendLayout();
            this.ControlTabs.SuspendLayout();
            this.AreaTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.TrayIconMenu.SuspendLayout();
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
            // metroLabel18
            // 
            this.metroLabel18.AutoSize = true;
            this.metroLabel18.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel18.Location = new System.Drawing.Point(0, 54);
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
            this.metroLabel17.Location = new System.Drawing.Point(101, 80);
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
            this.CustomHeight.CustomButton.Location = new System.Drawing.Point(54, 1);
            this.CustomHeight.CustomButton.Name = "";
            this.CustomHeight.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.CustomHeight.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.CustomHeight.CustomButton.TabIndex = 1;
            this.CustomHeight.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.CustomHeight.CustomButton.UseSelectable = true;
            this.CustomHeight.CustomButton.Visible = false;
            this.CustomHeight.Enabled = false;
            this.CustomHeight.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.CustomHeight.Lines = new string[] {
        "0"};
            this.CustomHeight.Location = new System.Drawing.Point(143, 76);
            this.CustomHeight.MaxLength = 32767;
            this.CustomHeight.Name = "CustomHeight";
            this.CustomHeight.PasswordChar = '\0';
            this.CustomHeight.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.CustomHeight.SelectedText = "";
            this.CustomHeight.SelectionLength = 0;
            this.CustomHeight.SelectionStart = 0;
            this.CustomHeight.ShortcutsEnabled = true;
            this.CustomHeight.Size = new System.Drawing.Size(76, 23);
            this.CustomHeight.Style = MetroFramework.MetroColorStyle.Black;
            this.CustomHeight.TabIndex = 55;
            this.CustomHeight.Text = "0";
            this.CustomHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CustomHeight.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.CustomHeight.UseSelectable = true;
            this.CustomHeight.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.CustomHeight.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // CustomWidth
            // 
            // 
            // 
            // 
            this.CustomWidth.CustomButton.Image = null;
            this.CustomWidth.CustomButton.Location = new System.Drawing.Point(59, 1);
            this.CustomWidth.CustomButton.Name = "";
            this.CustomWidth.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.CustomWidth.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.CustomWidth.CustomButton.TabIndex = 1;
            this.CustomWidth.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.CustomWidth.CustomButton.UseSelectable = true;
            this.CustomWidth.CustomButton.Visible = false;
            this.CustomWidth.Enabled = false;
            this.CustomWidth.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.CustomWidth.Lines = new string[] {
        "0"};
            this.CustomWidth.Location = new System.Drawing.Point(0, 76);
            this.CustomWidth.MaxLength = 32767;
            this.CustomWidth.Name = "CustomWidth";
            this.CustomWidth.PasswordChar = '\0';
            this.CustomWidth.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.CustomWidth.SelectedText = "";
            this.CustomWidth.SelectionLength = 0;
            this.CustomWidth.SelectionStart = 0;
            this.CustomWidth.ShortcutsEnabled = true;
            this.CustomWidth.Size = new System.Drawing.Size(81, 23);
            this.CustomWidth.Style = MetroFramework.MetroColorStyle.Black;
            this.CustomWidth.TabIndex = 54;
            this.CustomWidth.Text = "0";
            this.CustomWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CustomWidth.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.CustomWidth.UseSelectable = true;
            this.CustomWidth.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.CustomWidth.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // CaptureArea
            // 
            this.CaptureArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CaptureArea.FormattingEnabled = true;
            this.CaptureArea.ItemHeight = 23;
            this.CaptureArea.Location = new System.Drawing.Point(0, 22);
            this.CaptureArea.Name = "CaptureArea";
            this.CaptureArea.Size = new System.Drawing.Size(219, 29);
            this.CaptureArea.Style = MetroFramework.MetroColorStyle.Black;
            this.CaptureArea.TabIndex = 53;
            this.CaptureArea.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.CaptureArea.UseSelectable = true;
            this.CaptureArea.SelectedIndexChanged += new System.EventHandler(this.CaptureArea_SelectedIndexChanged);
            // 
            // metroLabel16
            // 
            this.metroLabel16.AutoSize = true;
            this.metroLabel16.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel16.Location = new System.Drawing.Point(0, 0);
            this.metroLabel16.Name = "metroLabel16";
            this.metroLabel16.Size = new System.Drawing.Size(90, 19);
            this.metroLabel16.TabIndex = 52;
            this.metroLabel16.Text = "Capture Area";
            this.metroLabel16.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // RightOffset
            // 
            // 
            // 
            // 
            this.RightOffset.CustomButton.Image = null;
            this.RightOffset.CustomButton.Location = new System.Drawing.Point(54, 1);
            this.RightOffset.CustomButton.Name = "";
            this.RightOffset.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.RightOffset.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.RightOffset.CustomButton.TabIndex = 1;
            this.RightOffset.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.RightOffset.CustomButton.UseSelectable = true;
            this.RightOffset.CustomButton.Visible = false;
            this.RightOffset.Enabled = false;
            this.RightOffset.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.RightOffset.Lines = new string[] {
        "0"};
            this.RightOffset.Location = new System.Drawing.Point(143, 226);
            this.RightOffset.MaxLength = 32767;
            this.RightOffset.Name = "RightOffset";
            this.RightOffset.PasswordChar = '\0';
            this.RightOffset.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.RightOffset.SelectedText = "";
            this.RightOffset.SelectionLength = 0;
            this.RightOffset.SelectionStart = 0;
            this.RightOffset.ShortcutsEnabled = true;
            this.RightOffset.Size = new System.Drawing.Size(76, 23);
            this.RightOffset.Style = MetroFramework.MetroColorStyle.Black;
            this.RightOffset.TabIndex = 50;
            this.RightOffset.Text = "0";
            this.RightOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RightOffset.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.RightOffset.UseSelectable = true;
            this.RightOffset.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.RightOffset.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // LeftOffset
            // 
            // 
            // 
            // 
            this.LeftOffset.CustomButton.Image = null;
            this.LeftOffset.CustomButton.Location = new System.Drawing.Point(54, 1);
            this.LeftOffset.CustomButton.Name = "";
            this.LeftOffset.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.LeftOffset.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.LeftOffset.CustomButton.TabIndex = 1;
            this.LeftOffset.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.LeftOffset.CustomButton.UseSelectable = true;
            this.LeftOffset.CustomButton.Visible = false;
            this.LeftOffset.Enabled = false;
            this.LeftOffset.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.LeftOffset.Lines = new string[] {
        "0"};
            this.LeftOffset.Location = new System.Drawing.Point(143, 197);
            this.LeftOffset.MaxLength = 32767;
            this.LeftOffset.Name = "LeftOffset";
            this.LeftOffset.PasswordChar = '\0';
            this.LeftOffset.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.LeftOffset.SelectedText = "";
            this.LeftOffset.SelectionLength = 0;
            this.LeftOffset.SelectionStart = 0;
            this.LeftOffset.ShortcutsEnabled = true;
            this.LeftOffset.Size = new System.Drawing.Size(76, 23);
            this.LeftOffset.Style = MetroFramework.MetroColorStyle.Black;
            this.LeftOffset.TabIndex = 49;
            this.LeftOffset.Text = "0";
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
            this.LowerOffset.CustomButton.Location = new System.Drawing.Point(54, 1);
            this.LowerOffset.CustomButton.Name = "";
            this.LowerOffset.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.LowerOffset.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.LowerOffset.CustomButton.TabIndex = 1;
            this.LowerOffset.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.LowerOffset.CustomButton.UseSelectable = true;
            this.LowerOffset.CustomButton.Visible = false;
            this.LowerOffset.Enabled = false;
            this.LowerOffset.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.LowerOffset.Lines = new string[] {
        "0"};
            this.LowerOffset.Location = new System.Drawing.Point(143, 168);
            this.LowerOffset.MaxLength = 32767;
            this.LowerOffset.Name = "LowerOffset";
            this.LowerOffset.PasswordChar = '\0';
            this.LowerOffset.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.LowerOffset.SelectedText = "";
            this.LowerOffset.SelectionLength = 0;
            this.LowerOffset.SelectionStart = 0;
            this.LowerOffset.ShortcutsEnabled = true;
            this.LowerOffset.Size = new System.Drawing.Size(76, 23);
            this.LowerOffset.Style = MetroFramework.MetroColorStyle.Black;
            this.LowerOffset.TabIndex = 48;
            this.LowerOffset.Text = "0";
            this.LowerOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LowerOffset.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.LowerOffset.UseSelectable = true;
            this.LowerOffset.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.LowerOffset.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // UpperOffset
            // 
            // 
            // 
            // 
            this.UpperOffset.CustomButton.Image = null;
            this.UpperOffset.CustomButton.Location = new System.Drawing.Point(54, 1);
            this.UpperOffset.CustomButton.Name = "";
            this.UpperOffset.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.UpperOffset.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.UpperOffset.CustomButton.TabIndex = 1;
            this.UpperOffset.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.UpperOffset.CustomButton.UseSelectable = true;
            this.UpperOffset.CustomButton.Visible = false;
            this.UpperOffset.Enabled = false;
            this.UpperOffset.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.UpperOffset.Lines = new string[] {
        "0"};
            this.UpperOffset.Location = new System.Drawing.Point(143, 139);
            this.UpperOffset.MaxLength = 32767;
            this.UpperOffset.Name = "UpperOffset";
            this.UpperOffset.PasswordChar = '\0';
            this.UpperOffset.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.UpperOffset.SelectedText = "";
            this.UpperOffset.SelectionLength = 0;
            this.UpperOffset.SelectionStart = 0;
            this.UpperOffset.ShortcutsEnabled = true;
            this.UpperOffset.Size = new System.Drawing.Size(76, 23);
            this.UpperOffset.Style = MetroFramework.MetroColorStyle.Black;
            this.UpperOffset.TabIndex = 47;
            this.UpperOffset.Text = "0";
            this.UpperOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UpperOffset.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.UpperOffset.UseSelectable = true;
            this.UpperOffset.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.UpperOffset.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel15
            // 
            this.metroLabel15.AutoSize = true;
            this.metroLabel15.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel15.Location = new System.Drawing.Point(0, 111);
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
            this.metroLabel13.Location = new System.Drawing.Point(0, 197);
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
            this.UpperOffsetLabel.Location = new System.Drawing.Point(0, 139);
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
            this.metroLabel12.Location = new System.Drawing.Point(0, 168);
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
            this.metroLabel14.Location = new System.Drawing.Point(0, 226);
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
            this.SettingsTab.Controls.Add(this.LedsXLabel);
            this.SettingsTab.Controls.Add(this.LedsYLabel);
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
            this.SettingsTab.Size = new System.Drawing.Size(219, 264);
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
            this.metroLabel11.Location = new System.Drawing.Point(0, 205);
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
            this.metroLabel10.Location = new System.Drawing.Point(0, 161);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(134, 19);
            this.metroLabel10.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel10.TabIndex = 27;
            this.metroLabel10.Text = "Horizontal side LEDs";
            this.metroLabel10.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // LedsXLabel
            // 
            this.LedsXLabel.AutoSize = true;
            this.LedsXLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LedsXLabel.Location = new System.Drawing.Point(196, 183);
            this.LedsXLabel.Name = "LedsXLabel";
            this.LedsXLabel.Size = new System.Drawing.Size(23, 19);
            this.LedsXLabel.Style = MetroFramework.MetroColorStyle.Black;
            this.LedsXLabel.TabIndex = 26;
            this.LedsXLabel.Text = "32";
            this.LedsXLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // LedsYLabel
            // 
            this.LedsYLabel.AutoSize = true;
            this.LedsYLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LedsYLabel.Location = new System.Drawing.Point(198, 227);
            this.LedsYLabel.Name = "LedsYLabel";
            this.LedsYLabel.Size = new System.Drawing.Size(21, 19);
            this.LedsYLabel.Style = MetroFramework.MetroColorStyle.Black;
            this.LedsYLabel.TabIndex = 25;
            this.LedsYLabel.Text = "18";
            this.LedsYLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // LedsY
            // 
            this.LedsY.BackColor = System.Drawing.Color.Transparent;
            this.LedsY.ForeColor = System.Drawing.Color.Black;
            this.LedsY.Location = new System.Drawing.Point(0, 227);
            this.LedsY.Maximum = 60;
            this.LedsY.Minimum = 1;
            this.LedsY.Name = "LedsY";
            this.LedsY.Size = new System.Drawing.Size(190, 19);
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
            this.LedsX.Location = new System.Drawing.Point(0, 183);
            this.LedsX.Maximum = 60;
            this.LedsX.Minimum = 1;
            this.LedsX.Name = "LedsX";
            this.LedsX.Size = new System.Drawing.Size(190, 19);
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
            this.metroLabel3.Location = new System.Drawing.Point(0, 107);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(127, 19);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel3.TabIndex = 13;
            this.metroLabel3.Text = "Interpolation mode";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(167, 21);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(52, 29);
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
            this.metroLabel2.Location = new System.Drawing.Point(0, 53);
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
            this.ComPort.Location = new System.Drawing.Point(0, 21);
            this.ComPort.Name = "ComPort";
            this.ComPort.Size = new System.Drawing.Size(161, 29);
            this.ComPort.Style = MetroFramework.MetroColorStyle.Black;
            this.ComPort.TabIndex = 5;
            this.ComPort.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ComPort.UseSelectable = true;
            this.ComPort.SelectedIndexChanged += new System.EventHandler(this.ComPort_SelectedIndexChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(0, 0);
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
            this.BaudRate.Location = new System.Drawing.Point(0, 75);
            this.BaudRate.Name = "BaudRate";
            this.BaudRate.Size = new System.Drawing.Size(219, 29);
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
            this.InterpMode.Location = new System.Drawing.Point(0, 129);
            this.InterpMode.Name = "InterpMode";
            this.InterpMode.Size = new System.Drawing.Size(219, 29);
            this.InterpMode.Style = MetroFramework.MetroColorStyle.Black;
            this.InterpMode.TabIndex = 7;
            this.InterpMode.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.InterpMode.UseSelectable = true;
            this.InterpMode.SelectedIndexChanged += new System.EventHandler(this.InterpMode_SelectedIndexChanged);
            // 
            // HomeTab
            // 
            this.HomeTab.Controls.Add(this.ColorSelection);
            this.HomeTab.Controls.Add(this.DefAudioInput);
            this.HomeTab.Controls.Add(this.UseDefaultAudio);
            this.HomeTab.Controls.Add(this.AudioInputs);
            this.HomeTab.Controls.Add(this.PrevAwayMode);
            this.HomeTab.Controls.Add(this.PreventSleep);
            this.HomeTab.Controls.Add(this.PrevSleep);
            this.HomeTab.Controls.Add(this.PreventAwayMode);
            this.HomeTab.Controls.Add(this.StartUpLabel);
            this.HomeTab.Controls.Add(this.SelectColor);
            this.HomeTab.Controls.Add(this.TimingLabel);
            this.HomeTab.Controls.Add(this.metroLabel19);
            this.HomeTab.Controls.Add(this.AmbilightModes);
            this.HomeTab.Controls.Add(this.FadeTiming);
            this.HomeTab.Controls.Add(this.StartStop);
            this.HomeTab.Controls.Add(this.Default_Timings);
            this.HomeTab.HorizontalScrollbarBarColor = true;
            this.HomeTab.HorizontalScrollbarHighlightOnWheel = false;
            this.HomeTab.HorizontalScrollbarSize = 10;
            this.HomeTab.Location = new System.Drawing.Point(4, 38);
            this.HomeTab.Name = "HomeTab";
            this.HomeTab.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.HomeTab.Size = new System.Drawing.Size(219, 264);
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
            this.ColorSelection.Location = new System.Drawing.Point(0, 84);
            this.ColorSelection.Name = "ColorSelection";
            this.ColorSelection.Size = new System.Drawing.Size(163, 29);
            this.ColorSelection.Style = MetroFramework.MetroColorStyle.Black;
            this.ColorSelection.TabIndex = 80;
            this.ColorSelection.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ColorSelection.UseSelectable = true;
            this.ColorSelection.SelectedIndexChanged += new System.EventHandler(this.ColorSelection_SelectedIndexChanged);
            this.ColorSelection.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ColorDeletionPressed);
            this.ColorSelection.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ColorDeletionReleased);
            // 
            // DefAudioInput
            // 
            this.DefAudioInput.AutoSize = true;
            this.DefAudioInput.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.DefAudioInput.Location = new System.Drawing.Point(0, 185);
            this.DefAudioInput.Name = "DefAudioInput";
            this.DefAudioInput.Size = new System.Drawing.Size(130, 19);
            this.DefAudioInput.Style = MetroFramework.MetroColorStyle.Black;
            this.DefAudioInput.TabIndex = 79;
            this.DefAudioInput.Text = "Default Audio Input";
            this.DefAudioInput.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // UseDefaultAudio
            // 
            this.UseDefaultAudio.AutoSize = true;
            this.UseDefaultAudio.Checked = true;
            this.UseDefaultAudio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseDefaultAudio.DisplayStatus = false;
            this.UseDefaultAudio.Location = new System.Drawing.Point(169, 188);
            this.UseDefaultAudio.Name = "UseDefaultAudio";
            this.UseDefaultAudio.Size = new System.Drawing.Size(50, 17);
            this.UseDefaultAudio.Style = MetroFramework.MetroColorStyle.Black;
            this.UseDefaultAudio.TabIndex = 78;
            this.UseDefaultAudio.Text = "On";
            this.UseDefaultAudio.UseSelectable = true;
            this.UseDefaultAudio.CheckStateChanged += new System.EventHandler(this.UseDefaultAudio_CheckedStateChanged);
            // 
            // AudioInputs
            // 
            this.AudioInputs.BackColor = System.Drawing.SystemColors.WindowText;
            this.AudioInputs.Enabled = false;
            this.AudioInputs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AudioInputs.FormattingEnabled = true;
            this.AudioInputs.ItemHeight = 23;
            this.AudioInputs.Location = new System.Drawing.Point(0, 211);
            this.AudioInputs.Name = "AudioInputs";
            this.AudioInputs.Size = new System.Drawing.Size(219, 29);
            this.AudioInputs.Style = MetroFramework.MetroColorStyle.Black;
            this.AudioInputs.TabIndex = 76;
            this.AudioInputs.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.AudioInputs.UseSelectable = true;
            // 
            // PrevAwayMode
            // 
            this.PrevAwayMode.AutoSize = true;
            this.PrevAwayMode.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.PrevAwayMode.Location = new System.Drawing.Point(0, 162);
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
            this.PreventSleep.Location = new System.Drawing.Point(169, 142);
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
            this.PrevSleep.Location = new System.Drawing.Point(0, 139);
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
            this.PreventAwayMode.Location = new System.Drawing.Point(169, 165);
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
            this.StartUpLabel.Location = new System.Drawing.Point(0, 116);
            this.StartUpLabel.Name = "StartUpLabel";
            this.StartUpLabel.Size = new System.Drawing.Size(64, 19);
            this.StartUpLabel.Style = MetroFramework.MetroColorStyle.Black;
            this.StartUpLabel.TabIndex = 65;
            this.StartUpLabel.Text = "Start Up!";
            this.StartUpLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // SelectColor
            // 
            this.SelectColor.Location = new System.Drawing.Point(169, 84);
            this.SelectColor.Name = "SelectColor";
            this.SelectColor.Size = new System.Drawing.Size(50, 29);
            this.SelectColor.Style = MetroFramework.MetroColorStyle.Black;
            this.SelectColor.TabIndex = 62;
            this.SelectColor.Text = "Pick";
            this.SelectColor.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.SelectColor.UseSelectable = true;
            this.SelectColor.Click += new System.EventHandler(this.SelectColor_Click);
            // 
            // TimingLabel
            // 
            this.TimingLabel.AutoSize = true;
            this.TimingLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.TimingLabel.Location = new System.Drawing.Point(0, 57);
            this.TimingLabel.Name = "TimingLabel";
            this.TimingLabel.Size = new System.Drawing.Size(50, 19);
            this.TimingLabel.Style = MetroFramework.MetroColorStyle.Black;
            this.TimingLabel.TabIndex = 64;
            this.TimingLabel.Text = "Timing";
            this.TimingLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel19
            // 
            this.metroLabel19.AutoSize = true;
            this.metroLabel19.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel19.Location = new System.Drawing.Point(0, 0);
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
            this.AmbilightModes.Location = new System.Drawing.Point(0, 22);
            this.AmbilightModes.Name = "AmbilightModes";
            this.AmbilightModes.Size = new System.Drawing.Size(219, 29);
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
            this.FadeTiming.Location = new System.Drawing.Point(56, 57);
            this.FadeTiming.Maximum = 1000;
            this.FadeTiming.Name = "FadeTiming";
            this.FadeTiming.Size = new System.Drawing.Size(163, 21);
            this.FadeTiming.TabIndex = 60;
            this.FadeTiming.Tag = "";
            this.FadeTiming.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTiming.Value = 10;
            // 
            // StartStop
            // 
            this.StartStop.AutoSize = true;
            this.StartStop.DisplayStatus = false;
            this.StartStop.Location = new System.Drawing.Point(169, 119);
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
            this.Default_Timings.Location = new System.Drawing.Point(0, 243);
            this.Default_Timings.Name = "Default_Timings";
            this.Default_Timings.Size = new System.Drawing.Size(96, 19);
            this.Default_Timings.TabIndex = 10;
            this.Default_Timings.Text = "Press Start Up!";
            this.Default_Timings.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // ControlTabs
            // 
            this.ControlTabs.Controls.Add(this.HomeTab);
            this.ControlTabs.Controls.Add(this.AreaTab);
            this.ControlTabs.Controls.Add(this.SettingsTab);
            this.ControlTabs.HotTrack = true;
            this.ControlTabs.Location = new System.Drawing.Point(11, 63);
            this.ControlTabs.Name = "ControlTabs";
            this.ControlTabs.SelectedIndex = 0;
            this.ControlTabs.Size = new System.Drawing.Size(227, 306);
            this.ControlTabs.Style = MetroFramework.MetroColorStyle.Black;
            this.ControlTabs.TabIndex = 17;
            this.ControlTabs.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ControlTabs.UseSelectable = true;
            // 
            // AreaTab
            // 
            this.AreaTab.Controls.Add(this.CaptureArea);
            this.AreaTab.Controls.Add(this.metroLabel18);
            this.AreaTab.Controls.Add(this.metroLabel16);
            this.AreaTab.Controls.Add(this.metroLabel14);
            this.AreaTab.Controls.Add(this.LeftOffset);
            this.AreaTab.Controls.Add(this.metroLabel17);
            this.AreaTab.Controls.Add(this.LowerOffset);
            this.AreaTab.Controls.Add(this.metroLabel12);
            this.AreaTab.Controls.Add(this.RightOffset);
            this.AreaTab.Controls.Add(this.CustomHeight);
            this.AreaTab.Controls.Add(this.UpperOffset);
            this.AreaTab.Controls.Add(this.UpperOffsetLabel);
            this.AreaTab.Controls.Add(this.metroLabel15);
            this.AreaTab.Controls.Add(this.CustomWidth);
            this.AreaTab.Controls.Add(this.metroLabel13);
            this.AreaTab.HorizontalScrollbarBarColor = true;
            this.AreaTab.HorizontalScrollbarHighlightOnWheel = false;
            this.AreaTab.HorizontalScrollbarSize = 10;
            this.AreaTab.Location = new System.Drawing.Point(4, 38);
            this.AreaTab.Name = "AreaTab";
            this.AreaTab.Size = new System.Drawing.Size(219, 264);
            this.AreaTab.Style = MetroFramework.MetroColorStyle.Black;
            this.AreaTab.TabIndex = 3;
            this.AreaTab.Text = "Area";
            this.AreaTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.AreaTab.VerticalScrollbarBarColor = true;
            this.AreaTab.VerticalScrollbarHighlightOnWheel = false;
            this.AreaTab.VerticalScrollbarSize = 10;
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = null;
            this.metroStyleManager1.Style = MetroFramework.MetroColorStyle.Black;
            this.metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // TrayIconMenu
            // 
            this.TrayIconMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TrayIconMenu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TrayIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.TrayIconMenu.Name = "TrayIconMenu";
            this.TrayIconMenu.ShowImageMargin = false;
            this.TrayIconMenu.Size = new System.Drawing.Size(156, 92);
            this.TrayIconMenu.Style = MetroFramework.MetroColorStyle.Black;
            this.TrayIconMenu.TabStop = true;
            this.TrayIconMenu.Text = "Ambilight";
            this.TrayIconMenu.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TrayIconMenu.UseSelectable = true;
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.StartStopFromTrayClicked);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Hide";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenFromTrayClicked);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitFromTrayClicked);
            // 
            // DynamicAmbilight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 371);
            this.Controls.Add(this.ControlTabs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DynamicAmbilight";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Text = "Dynamic Ambilight";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.SettingsTab.ResumeLayout(false);
            this.SettingsTab.PerformLayout();
            this.HomeTab.ResumeLayout(false);
            this.HomeTab.PerformLayout();
            this.ControlTabs.ResumeLayout(false);
            this.AreaTab.ResumeLayout(false);
            this.AreaTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.TrayIconMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon Tray_Icon;
        private MetroFramework.Controls.MetroTabPage SettingsTab;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroLabel LedsXLabel;
        private MetroFramework.Controls.MetroLabel LedsYLabel;
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
        private MetroFramework.Controls.MetroLabel Default_Timings;
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
        private MetroFramework.Controls.MetroComboBox CaptureArea;
        private MetroFramework.Controls.MetroLabel metroLabel16;
        private MetroFramework.Controls.MetroTabPage AreaTab;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroLabel StartUpLabel;
        private MetroFramework.Controls.MetroButton SelectColor;
        private MetroFramework.Controls.MetroLabel TimingLabel;
        private MetroFramework.Controls.MetroLabel metroLabel19;
        private MetroFramework.Controls.MetroComboBox AmbilightModes;
        private MetroFramework.Controls.MetroTrackBar FadeTiming;
        private MetroFramework.Controls.MetroLabel PrevAwayMode;
        private MetroFramework.Controls.MetroToggle PreventSleep;
        private MetroFramework.Controls.MetroLabel PrevSleep;
        private MetroFramework.Controls.MetroToggle PreventAwayMode;
        private MetroFramework.Controls.MetroToggle StartStop;
        private MetroFramework.Controls.MetroLabel DefAudioInput;
        private MetroFramework.Controls.MetroToggle UseDefaultAudio;
        private MetroFramework.Controls.MetroComboBox AudioInputs;
        private MetroFramework.Controls.MetroComboBox ColorSelection;
        private MetroFramework.Controls.MetroContextMenu TrayIconMenu;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

