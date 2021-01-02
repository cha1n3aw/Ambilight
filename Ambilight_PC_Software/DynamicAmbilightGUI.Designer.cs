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
            this.metroLabel19 = new MetroFramework.Controls.MetroLabel();
            this.AmbilightModes = new MetroFramework.Controls.MetroComboBox();
            this.FadeTiming = new MetroFramework.Controls.MetroTrackBar();
            this.StartStop = new MetroFramework.Controls.MetroToggle();
            this.Default_Timings = new MetroFramework.Controls.MetroLabel();
            this.ControlTabs = new MetroFramework.Controls.MetroTabControl();
            this.AreaTab = new MetroFramework.Controls.MetroTabPage();
            this.TrayIconMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FadeTimingTip = new MetroFramework.Components.MetroToolTip();
            this.BlackStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.SettingsTab.SuspendLayout();
            this.HomeTab.SuspendLayout();
            this.ControlTabs.SuspendLayout();
            this.AreaTab.SuspendLayout();
            this.TrayIconMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlackStyleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // Tray_Icon
            // 
            resources.ApplyResources(this.Tray_Icon, "Tray_Icon");
            this.Tray_Icon.BalloonTipClicked += new System.EventHandler(this.Tray_Icon_BalloonTipClicked);
            this.Tray_Icon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Tray_Icon_MouseDoubleClick);
            // 
            // metroLabel18
            // 
            resources.ApplyResources(this.metroLabel18, "metroLabel18");
            this.metroLabel18.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel18.Name = "metroLabel18";
            this.metroLabel18.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.metroLabel18, resources.GetString("metroLabel18.ToolTip"));
            // 
            // metroLabel17
            // 
            resources.ApplyResources(this.metroLabel17, "metroLabel17");
            this.metroLabel17.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel17.Name = "metroLabel17";
            this.metroLabel17.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.metroLabel17, resources.GetString("metroLabel17.ToolTip"));
            // 
            // CustomHeight
            // 
            resources.ApplyResources(this.CustomHeight, "CustomHeight");
            // 
            // 
            // 
            this.CustomHeight.CustomButton.AccessibleDescription = resources.GetString("resource.AccessibleDescription");
            this.CustomHeight.CustomButton.AccessibleName = resources.GetString("resource.AccessibleName");
            this.CustomHeight.CustomButton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("resource.Anchor")));
            this.CustomHeight.CustomButton.AutoSize = ((bool)(resources.GetObject("resource.AutoSize")));
            this.CustomHeight.CustomButton.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("resource.AutoSizeMode")));
            this.CustomHeight.CustomButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("resource.BackgroundImage")));
            this.CustomHeight.CustomButton.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("resource.BackgroundImageLayout")));
            this.CustomHeight.CustomButton.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("resource.Dock")));
            this.CustomHeight.CustomButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("resource.FlatStyle")));
            this.CustomHeight.CustomButton.Font = ((System.Drawing.Font)(resources.GetObject("resource.Font")));
            this.CustomHeight.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.CustomHeight.CustomButton.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.ImageAlign")));
            this.CustomHeight.CustomButton.ImageIndex = ((int)(resources.GetObject("resource.ImageIndex")));
            this.CustomHeight.CustomButton.ImageKey = resources.GetString("resource.ImageKey");
            this.CustomHeight.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode")));
            this.CustomHeight.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location")));
            this.CustomHeight.CustomButton.MaximumSize = ((System.Drawing.Size)(resources.GetObject("resource.MaximumSize")));
            this.CustomHeight.CustomButton.Name = "";
            this.CustomHeight.CustomButton.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("resource.RightToLeft")));
            this.CustomHeight.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size")));
            this.CustomHeight.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.CustomHeight.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex")));
            this.CustomHeight.CustomButton.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.TextAlign")));
            this.CustomHeight.CustomButton.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("resource.TextImageRelation")));
            this.CustomHeight.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.CustomHeight.CustomButton.UseSelectable = true;
            this.CustomHeight.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible")));
            this.CustomHeight.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.CustomHeight.Lines = new string[0];
            this.CustomHeight.MaxLength = 32767;
            this.CustomHeight.Name = "CustomHeight";
            this.CustomHeight.PasswordChar = '\0';
            this.CustomHeight.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.CustomHeight.SelectedText = "";
            this.CustomHeight.SelectionLength = 0;
            this.CustomHeight.SelectionStart = 0;
            this.CustomHeight.ShortcutsEnabled = true;
            this.CustomHeight.Style = MetroFramework.MetroColorStyle.Black;
            this.CustomHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CustomHeight.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.CustomHeight, resources.GetString("CustomHeight.ToolTip"));
            this.CustomHeight.UseSelectable = true;
            this.CustomHeight.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.CustomHeight.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // CustomWidth
            // 
            resources.ApplyResources(this.CustomWidth, "CustomWidth");
            // 
            // 
            // 
            this.CustomWidth.CustomButton.AccessibleDescription = resources.GetString("resource.AccessibleDescription1");
            this.CustomWidth.CustomButton.AccessibleName = resources.GetString("resource.AccessibleName1");
            this.CustomWidth.CustomButton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("resource.Anchor1")));
            this.CustomWidth.CustomButton.AutoSize = ((bool)(resources.GetObject("resource.AutoSize1")));
            this.CustomWidth.CustomButton.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("resource.AutoSizeMode1")));
            this.CustomWidth.CustomButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("resource.BackgroundImage1")));
            this.CustomWidth.CustomButton.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("resource.BackgroundImageLayout1")));
            this.CustomWidth.CustomButton.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("resource.Dock1")));
            this.CustomWidth.CustomButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("resource.FlatStyle1")));
            this.CustomWidth.CustomButton.Font = ((System.Drawing.Font)(resources.GetObject("resource.Font1")));
            this.CustomWidth.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.CustomWidth.CustomButton.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.ImageAlign1")));
            this.CustomWidth.CustomButton.ImageIndex = ((int)(resources.GetObject("resource.ImageIndex1")));
            this.CustomWidth.CustomButton.ImageKey = resources.GetString("resource.ImageKey1");
            this.CustomWidth.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode1")));
            this.CustomWidth.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location1")));
            this.CustomWidth.CustomButton.MaximumSize = ((System.Drawing.Size)(resources.GetObject("resource.MaximumSize1")));
            this.CustomWidth.CustomButton.Name = "";
            this.CustomWidth.CustomButton.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("resource.RightToLeft1")));
            this.CustomWidth.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size1")));
            this.CustomWidth.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.CustomWidth.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex1")));
            this.CustomWidth.CustomButton.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.TextAlign1")));
            this.CustomWidth.CustomButton.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("resource.TextImageRelation1")));
            this.CustomWidth.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.CustomWidth.CustomButton.UseSelectable = true;
            this.CustomWidth.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible1")));
            this.CustomWidth.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.CustomWidth.Lines = new string[0];
            this.CustomWidth.MaxLength = 32767;
            this.CustomWidth.Name = "CustomWidth";
            this.CustomWidth.PasswordChar = '\0';
            this.CustomWidth.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.CustomWidth.SelectedText = "";
            this.CustomWidth.SelectionLength = 0;
            this.CustomWidth.SelectionStart = 0;
            this.CustomWidth.ShortcutsEnabled = true;
            this.CustomWidth.Style = MetroFramework.MetroColorStyle.Black;
            this.CustomWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CustomWidth.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.CustomWidth, resources.GetString("CustomWidth.ToolTip"));
            this.CustomWidth.UseSelectable = true;
            this.CustomWidth.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.CustomWidth.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // CaptureArea
            // 
            resources.ApplyResources(this.CaptureArea, "CaptureArea");
            this.CaptureArea.FormattingEnabled = true;
            this.CaptureArea.Name = "CaptureArea";
            this.CaptureArea.Style = MetroFramework.MetroColorStyle.Black;
            this.CaptureArea.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.CaptureArea, resources.GetString("CaptureArea.ToolTip"));
            this.CaptureArea.UseSelectable = true;
            this.CaptureArea.SelectedIndexChanged += new System.EventHandler(this.CaptureArea_SelectedIndexChanged);
            // 
            // metroLabel16
            // 
            resources.ApplyResources(this.metroLabel16, "metroLabel16");
            this.metroLabel16.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel16.Name = "metroLabel16";
            this.metroLabel16.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.metroLabel16, resources.GetString("metroLabel16.ToolTip"));
            // 
            // RightOffset
            // 
            resources.ApplyResources(this.RightOffset, "RightOffset");
            // 
            // 
            // 
            this.RightOffset.CustomButton.AccessibleDescription = resources.GetString("resource.AccessibleDescription2");
            this.RightOffset.CustomButton.AccessibleName = resources.GetString("resource.AccessibleName2");
            this.RightOffset.CustomButton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("resource.Anchor2")));
            this.RightOffset.CustomButton.AutoSize = ((bool)(resources.GetObject("resource.AutoSize2")));
            this.RightOffset.CustomButton.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("resource.AutoSizeMode2")));
            this.RightOffset.CustomButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("resource.BackgroundImage2")));
            this.RightOffset.CustomButton.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("resource.BackgroundImageLayout2")));
            this.RightOffset.CustomButton.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("resource.Dock2")));
            this.RightOffset.CustomButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("resource.FlatStyle2")));
            this.RightOffset.CustomButton.Font = ((System.Drawing.Font)(resources.GetObject("resource.Font2")));
            this.RightOffset.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            this.RightOffset.CustomButton.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.ImageAlign2")));
            this.RightOffset.CustomButton.ImageIndex = ((int)(resources.GetObject("resource.ImageIndex2")));
            this.RightOffset.CustomButton.ImageKey = resources.GetString("resource.ImageKey2");
            this.RightOffset.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode2")));
            this.RightOffset.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location2")));
            this.RightOffset.CustomButton.MaximumSize = ((System.Drawing.Size)(resources.GetObject("resource.MaximumSize2")));
            this.RightOffset.CustomButton.Name = "";
            this.RightOffset.CustomButton.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("resource.RightToLeft2")));
            this.RightOffset.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size2")));
            this.RightOffset.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.RightOffset.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex2")));
            this.RightOffset.CustomButton.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.TextAlign2")));
            this.RightOffset.CustomButton.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("resource.TextImageRelation2")));
            this.RightOffset.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.RightOffset.CustomButton.UseSelectable = true;
            this.RightOffset.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible2")));
            this.RightOffset.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.RightOffset.Lines = new string[0];
            this.RightOffset.MaxLength = 32767;
            this.RightOffset.Name = "RightOffset";
            this.RightOffset.PasswordChar = '\0';
            this.RightOffset.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.RightOffset.SelectedText = "";
            this.RightOffset.SelectionLength = 0;
            this.RightOffset.SelectionStart = 0;
            this.RightOffset.ShortcutsEnabled = true;
            this.RightOffset.Style = MetroFramework.MetroColorStyle.Black;
            this.RightOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RightOffset.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.RightOffset, resources.GetString("RightOffset.ToolTip"));
            this.RightOffset.UseSelectable = true;
            this.RightOffset.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.RightOffset.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // LeftOffset
            // 
            resources.ApplyResources(this.LeftOffset, "LeftOffset");
            // 
            // 
            // 
            this.LeftOffset.CustomButton.AccessibleDescription = resources.GetString("resource.AccessibleDescription3");
            this.LeftOffset.CustomButton.AccessibleName = resources.GetString("resource.AccessibleName3");
            this.LeftOffset.CustomButton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("resource.Anchor3")));
            this.LeftOffset.CustomButton.AutoSize = ((bool)(resources.GetObject("resource.AutoSize3")));
            this.LeftOffset.CustomButton.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("resource.AutoSizeMode3")));
            this.LeftOffset.CustomButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("resource.BackgroundImage3")));
            this.LeftOffset.CustomButton.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("resource.BackgroundImageLayout3")));
            this.LeftOffset.CustomButton.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("resource.Dock3")));
            this.LeftOffset.CustomButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("resource.FlatStyle3")));
            this.LeftOffset.CustomButton.Font = ((System.Drawing.Font)(resources.GetObject("resource.Font3")));
            this.LeftOffset.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            this.LeftOffset.CustomButton.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.ImageAlign3")));
            this.LeftOffset.CustomButton.ImageIndex = ((int)(resources.GetObject("resource.ImageIndex3")));
            this.LeftOffset.CustomButton.ImageKey = resources.GetString("resource.ImageKey3");
            this.LeftOffset.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode3")));
            this.LeftOffset.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location3")));
            this.LeftOffset.CustomButton.MaximumSize = ((System.Drawing.Size)(resources.GetObject("resource.MaximumSize3")));
            this.LeftOffset.CustomButton.Name = "";
            this.LeftOffset.CustomButton.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("resource.RightToLeft3")));
            this.LeftOffset.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size3")));
            this.LeftOffset.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.LeftOffset.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex3")));
            this.LeftOffset.CustomButton.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.TextAlign3")));
            this.LeftOffset.CustomButton.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("resource.TextImageRelation3")));
            this.LeftOffset.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.LeftOffset.CustomButton.UseSelectable = true;
            this.LeftOffset.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible3")));
            this.LeftOffset.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.LeftOffset.Lines = new string[0];
            this.LeftOffset.MaxLength = 32767;
            this.LeftOffset.Name = "LeftOffset";
            this.LeftOffset.PasswordChar = '\0';
            this.LeftOffset.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.LeftOffset.SelectedText = "";
            this.LeftOffset.SelectionLength = 0;
            this.LeftOffset.SelectionStart = 0;
            this.LeftOffset.ShortcutsEnabled = true;
            this.LeftOffset.Style = MetroFramework.MetroColorStyle.Black;
            this.LeftOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LeftOffset.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.LeftOffset, resources.GetString("LeftOffset.ToolTip"));
            this.LeftOffset.UseSelectable = true;
            this.LeftOffset.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.LeftOffset.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // LowerOffset
            // 
            resources.ApplyResources(this.LowerOffset, "LowerOffset");
            // 
            // 
            // 
            this.LowerOffset.CustomButton.AccessibleDescription = resources.GetString("resource.AccessibleDescription4");
            this.LowerOffset.CustomButton.AccessibleName = resources.GetString("resource.AccessibleName4");
            this.LowerOffset.CustomButton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("resource.Anchor4")));
            this.LowerOffset.CustomButton.AutoSize = ((bool)(resources.GetObject("resource.AutoSize4")));
            this.LowerOffset.CustomButton.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("resource.AutoSizeMode4")));
            this.LowerOffset.CustomButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("resource.BackgroundImage4")));
            this.LowerOffset.CustomButton.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("resource.BackgroundImageLayout4")));
            this.LowerOffset.CustomButton.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("resource.Dock4")));
            this.LowerOffset.CustomButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("resource.FlatStyle4")));
            this.LowerOffset.CustomButton.Font = ((System.Drawing.Font)(resources.GetObject("resource.Font4")));
            this.LowerOffset.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image4")));
            this.LowerOffset.CustomButton.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.ImageAlign4")));
            this.LowerOffset.CustomButton.ImageIndex = ((int)(resources.GetObject("resource.ImageIndex4")));
            this.LowerOffset.CustomButton.ImageKey = resources.GetString("resource.ImageKey4");
            this.LowerOffset.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode4")));
            this.LowerOffset.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location4")));
            this.LowerOffset.CustomButton.MaximumSize = ((System.Drawing.Size)(resources.GetObject("resource.MaximumSize4")));
            this.LowerOffset.CustomButton.Name = "";
            this.LowerOffset.CustomButton.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("resource.RightToLeft4")));
            this.LowerOffset.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size4")));
            this.LowerOffset.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.LowerOffset.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex4")));
            this.LowerOffset.CustomButton.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.TextAlign4")));
            this.LowerOffset.CustomButton.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("resource.TextImageRelation4")));
            this.LowerOffset.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.LowerOffset.CustomButton.UseSelectable = true;
            this.LowerOffset.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible4")));
            this.LowerOffset.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.LowerOffset.Lines = new string[0];
            this.LowerOffset.MaxLength = 32767;
            this.LowerOffset.Name = "LowerOffset";
            this.LowerOffset.PasswordChar = '\0';
            this.LowerOffset.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.LowerOffset.SelectedText = "";
            this.LowerOffset.SelectionLength = 0;
            this.LowerOffset.SelectionStart = 0;
            this.LowerOffset.ShortcutsEnabled = true;
            this.LowerOffset.Style = MetroFramework.MetroColorStyle.Black;
            this.LowerOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LowerOffset.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.LowerOffset, resources.GetString("LowerOffset.ToolTip"));
            this.LowerOffset.UseSelectable = true;
            this.LowerOffset.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.LowerOffset.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // UpperOffset
            // 
            resources.ApplyResources(this.UpperOffset, "UpperOffset");
            // 
            // 
            // 
            this.UpperOffset.CustomButton.AccessibleDescription = resources.GetString("resource.AccessibleDescription5");
            this.UpperOffset.CustomButton.AccessibleName = resources.GetString("resource.AccessibleName5");
            this.UpperOffset.CustomButton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("resource.Anchor5")));
            this.UpperOffset.CustomButton.AutoSize = ((bool)(resources.GetObject("resource.AutoSize5")));
            this.UpperOffset.CustomButton.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("resource.AutoSizeMode5")));
            this.UpperOffset.CustomButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("resource.BackgroundImage5")));
            this.UpperOffset.CustomButton.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("resource.BackgroundImageLayout5")));
            this.UpperOffset.CustomButton.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("resource.Dock5")));
            this.UpperOffset.CustomButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("resource.FlatStyle5")));
            this.UpperOffset.CustomButton.Font = ((System.Drawing.Font)(resources.GetObject("resource.Font5")));
            this.UpperOffset.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image5")));
            this.UpperOffset.CustomButton.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.ImageAlign5")));
            this.UpperOffset.CustomButton.ImageIndex = ((int)(resources.GetObject("resource.ImageIndex5")));
            this.UpperOffset.CustomButton.ImageKey = resources.GetString("resource.ImageKey5");
            this.UpperOffset.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode5")));
            this.UpperOffset.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location5")));
            this.UpperOffset.CustomButton.MaximumSize = ((System.Drawing.Size)(resources.GetObject("resource.MaximumSize5")));
            this.UpperOffset.CustomButton.Name = "";
            this.UpperOffset.CustomButton.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("resource.RightToLeft5")));
            this.UpperOffset.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size5")));
            this.UpperOffset.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.UpperOffset.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex5")));
            this.UpperOffset.CustomButton.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.TextAlign5")));
            this.UpperOffset.CustomButton.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("resource.TextImageRelation5")));
            this.UpperOffset.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.UpperOffset.CustomButton.UseSelectable = true;
            this.UpperOffset.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible5")));
            this.UpperOffset.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.UpperOffset.Lines = new string[0];
            this.UpperOffset.MaxLength = 32767;
            this.UpperOffset.Name = "UpperOffset";
            this.UpperOffset.PasswordChar = '\0';
            this.UpperOffset.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.UpperOffset.SelectedText = "";
            this.UpperOffset.SelectionLength = 0;
            this.UpperOffset.SelectionStart = 0;
            this.UpperOffset.ShortcutsEnabled = true;
            this.UpperOffset.Style = MetroFramework.MetroColorStyle.Black;
            this.UpperOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UpperOffset.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.UpperOffset, resources.GetString("UpperOffset.ToolTip"));
            this.UpperOffset.UseSelectable = true;
            this.UpperOffset.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.UpperOffset.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel15
            // 
            resources.ApplyResources(this.metroLabel15, "metroLabel15");
            this.metroLabel15.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel15.Name = "metroLabel15";
            this.metroLabel15.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.metroLabel15, resources.GetString("metroLabel15.ToolTip"));
            // 
            // metroLabel13
            // 
            resources.ApplyResources(this.metroLabel13, "metroLabel13");
            this.metroLabel13.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.metroLabel13, resources.GetString("metroLabel13.ToolTip"));
            // 
            // UpperOffsetLabel
            // 
            resources.ApplyResources(this.UpperOffsetLabel, "UpperOffsetLabel");
            this.UpperOffsetLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.UpperOffsetLabel.Name = "UpperOffsetLabel";
            this.UpperOffsetLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.UpperOffsetLabel, resources.GetString("UpperOffsetLabel.ToolTip"));
            // 
            // metroLabel12
            // 
            resources.ApplyResources(this.metroLabel12, "metroLabel12");
            this.metroLabel12.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.metroLabel12, resources.GetString("metroLabel12.ToolTip"));
            // 
            // metroLabel14
            // 
            resources.ApplyResources(this.metroLabel14, "metroLabel14");
            this.metroLabel14.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel14.Name = "metroLabel14";
            this.metroLabel14.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.metroLabel14, resources.GetString("metroLabel14.ToolTip"));
            // 
            // SettingsTab
            // 
            resources.ApplyResources(this.SettingsTab, "SettingsTab");
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
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.SettingsTab, resources.GetString("SettingsTab.ToolTip"));
            this.SettingsTab.VerticalScrollbarBarColor = true;
            this.SettingsTab.VerticalScrollbarHighlightOnWheel = false;
            this.SettingsTab.VerticalScrollbarSize = 10;
            // 
            // metroLabel11
            // 
            resources.ApplyResources(this.metroLabel11, "metroLabel11");
            this.metroLabel11.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel11.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.metroLabel11, resources.GetString("metroLabel11.ToolTip"));
            // 
            // metroLabel10
            // 
            resources.ApplyResources(this.metroLabel10, "metroLabel10");
            this.metroLabel10.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel10.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.metroLabel10, resources.GetString("metroLabel10.ToolTip"));
            // 
            // LedsXLabel
            // 
            resources.ApplyResources(this.LedsXLabel, "LedsXLabel");
            this.LedsXLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LedsXLabel.Name = "LedsXLabel";
            this.LedsXLabel.Style = MetroFramework.MetroColorStyle.Black;
            this.LedsXLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.LedsXLabel, resources.GetString("LedsXLabel.ToolTip"));
            // 
            // LedsYLabel
            // 
            resources.ApplyResources(this.LedsYLabel, "LedsYLabel");
            this.LedsYLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LedsYLabel.Name = "LedsYLabel";
            this.LedsYLabel.Style = MetroFramework.MetroColorStyle.Black;
            this.LedsYLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.LedsYLabel, resources.GetString("LedsYLabel.ToolTip"));
            // 
            // LedsY
            // 
            resources.ApplyResources(this.LedsY, "LedsY");
            this.LedsY.BackColor = System.Drawing.Color.Transparent;
            this.LedsY.ForeColor = System.Drawing.Color.Black;
            this.LedsY.Maximum = 60;
            this.LedsY.Minimum = 1;
            this.LedsY.Name = "LedsY";
            this.LedsY.Tag = "";
            this.LedsY.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.LedsY, resources.GetString("LedsY.ToolTip"));
            this.LedsY.Value = 18;
            this.LedsY.ValueChanged += new System.EventHandler(this.LedsY_ValueChanged);
            // 
            // LedsX
            // 
            resources.ApplyResources(this.LedsX, "LedsX");
            this.LedsX.BackColor = System.Drawing.Color.Transparent;
            this.LedsX.ForeColor = System.Drawing.Color.Black;
            this.LedsX.Maximum = 60;
            this.LedsX.Minimum = 1;
            this.LedsX.Name = "LedsX";
            this.LedsX.Tag = "";
            this.LedsX.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.LedsX, resources.GetString("LedsX.ToolTip"));
            this.LedsX.Value = 32;
            this.LedsX.ValueChanged += new System.EventHandler(this.LedsX_ValueChanged);
            // 
            // metroLabel3
            // 
            resources.ApplyResources(this.metroLabel3, "metroLabel3");
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.metroLabel3, resources.GetString("metroLabel3.ToolTip"));
            // 
            // RefreshButton
            // 
            resources.ApplyResources(this.RefreshButton, "RefreshButton");
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.RefreshButton, resources.GetString("RefreshButton.ToolTip"));
            this.RefreshButton.UseSelectable = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // metroLabel2
            // 
            resources.ApplyResources(this.metroLabel2, "metroLabel2");
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.metroLabel2, resources.GetString("metroLabel2.ToolTip"));
            // 
            // ComPort
            // 
            resources.ApplyResources(this.ComPort, "ComPort");
            this.ComPort.FormattingEnabled = true;
            this.ComPort.Name = "ComPort";
            this.ComPort.Style = MetroFramework.MetroColorStyle.Black;
            this.ComPort.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.ComPort, resources.GetString("ComPort.ToolTip"));
            this.ComPort.UseSelectable = true;
            this.ComPort.SelectedIndexChanged += new System.EventHandler(this.ComPort_SelectedIndexChanged);
            // 
            // metroLabel1
            // 
            resources.ApplyResources(this.metroLabel1, "metroLabel1");
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.metroLabel1, resources.GetString("metroLabel1.ToolTip"));
            // 
            // BaudRate
            // 
            resources.ApplyResources(this.BaudRate, "BaudRate");
            this.BaudRate.FormattingEnabled = true;
            this.BaudRate.Name = "BaudRate";
            this.BaudRate.Style = MetroFramework.MetroColorStyle.Black;
            this.BaudRate.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.BaudRate, resources.GetString("BaudRate.ToolTip"));
            this.BaudRate.UseSelectable = true;
            this.BaudRate.SelectedIndexChanged += new System.EventHandler(this.BaudRate_SelectedIndexChanged);
            // 
            // InterpMode
            // 
            resources.ApplyResources(this.InterpMode, "InterpMode");
            this.InterpMode.BackColor = System.Drawing.Color.Black;
            this.InterpMode.FormattingEnabled = true;
            this.InterpMode.Name = "InterpMode";
            this.InterpMode.Style = MetroFramework.MetroColorStyle.Black;
            this.InterpMode.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.InterpMode, resources.GetString("InterpMode.ToolTip"));
            this.InterpMode.UseSelectable = true;
            this.InterpMode.SelectedIndexChanged += new System.EventHandler(this.InterpMode_SelectedIndexChanged);
            // 
            // HomeTab
            // 
            resources.ApplyResources(this.HomeTab, "HomeTab");
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
            this.HomeTab.Controls.Add(this.metroLabel19);
            this.HomeTab.Controls.Add(this.AmbilightModes);
            this.HomeTab.Controls.Add(this.FadeTiming);
            this.HomeTab.Controls.Add(this.StartStop);
            this.HomeTab.Controls.Add(this.Default_Timings);
            this.HomeTab.HorizontalScrollbarBarColor = true;
            this.HomeTab.HorizontalScrollbarHighlightOnWheel = false;
            this.HomeTab.HorizontalScrollbarSize = 10;
            this.HomeTab.Name = "HomeTab";
            this.HomeTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.HomeTab, resources.GetString("HomeTab.ToolTip"));
            this.HomeTab.VerticalScrollbarBarColor = true;
            this.HomeTab.VerticalScrollbarHighlightOnWheel = false;
            this.HomeTab.VerticalScrollbarSize = 10;
            // 
            // ColorSelection
            // 
            resources.ApplyResources(this.ColorSelection, "ColorSelection");
            this.ColorSelection.BackColor = System.Drawing.SystemColors.WindowText;
            this.ColorSelection.FormattingEnabled = true;
            this.ColorSelection.Name = "ColorSelection";
            this.ColorSelection.Style = MetroFramework.MetroColorStyle.Black;
            this.ColorSelection.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.ColorSelection, resources.GetString("ColorSelection.ToolTip"));
            this.ColorSelection.UseSelectable = true;
            this.ColorSelection.SelectedIndexChanged += new System.EventHandler(this.ColorSelection_SelectedIndexChanged);
            this.ColorSelection.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ColorDeletionPressed);
            this.ColorSelection.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ColorDeletionReleased);
            // 
            // DefAudioInput
            // 
            resources.ApplyResources(this.DefAudioInput, "DefAudioInput");
            this.DefAudioInput.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.DefAudioInput.Name = "DefAudioInput";
            this.DefAudioInput.Style = MetroFramework.MetroColorStyle.Black;
            this.DefAudioInput.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.DefAudioInput, resources.GetString("DefAudioInput.ToolTip"));
            // 
            // UseDefaultAudio
            // 
            resources.ApplyResources(this.UseDefaultAudio, "UseDefaultAudio");
            this.UseDefaultAudio.Checked = true;
            this.UseDefaultAudio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseDefaultAudio.DisplayStatus = false;
            this.UseDefaultAudio.Name = "UseDefaultAudio";
            this.UseDefaultAudio.Style = MetroFramework.MetroColorStyle.Black;
            this.FadeTimingTip.SetToolTip(this.UseDefaultAudio, resources.GetString("UseDefaultAudio.ToolTip"));
            this.UseDefaultAudio.UseSelectable = true;
            this.UseDefaultAudio.CheckStateChanged += new System.EventHandler(this.UseDefaultAudio_CheckedStateChanged);
            // 
            // AudioInputs
            // 
            resources.ApplyResources(this.AudioInputs, "AudioInputs");
            this.AudioInputs.BackColor = System.Drawing.SystemColors.WindowText;
            this.AudioInputs.FormattingEnabled = true;
            this.AudioInputs.Name = "AudioInputs";
            this.AudioInputs.Style = MetroFramework.MetroColorStyle.Black;
            this.AudioInputs.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.AudioInputs, resources.GetString("AudioInputs.ToolTip"));
            this.AudioInputs.UseSelectable = true;
            // 
            // PrevAwayMode
            // 
            resources.ApplyResources(this.PrevAwayMode, "PrevAwayMode");
            this.PrevAwayMode.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.PrevAwayMode.Name = "PrevAwayMode";
            this.PrevAwayMode.Style = MetroFramework.MetroColorStyle.Black;
            this.PrevAwayMode.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.PrevAwayMode, resources.GetString("PrevAwayMode.ToolTip"));
            // 
            // PreventSleep
            // 
            resources.ApplyResources(this.PreventSleep, "PreventSleep");
            this.PreventSleep.DisplayStatus = false;
            this.PreventSleep.Name = "PreventSleep";
            this.PreventSleep.Style = MetroFramework.MetroColorStyle.Black;
            this.FadeTimingTip.SetToolTip(this.PreventSleep, resources.GetString("PreventSleep.ToolTip"));
            this.PreventSleep.UseSelectable = true;
            this.PreventSleep.CheckStateChanged += new System.EventHandler(this.PreventSleep_CheckStateChanged);
            // 
            // PrevSleep
            // 
            resources.ApplyResources(this.PrevSleep, "PrevSleep");
            this.PrevSleep.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.PrevSleep.Name = "PrevSleep";
            this.PrevSleep.Style = MetroFramework.MetroColorStyle.Black;
            this.PrevSleep.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.PrevSleep, resources.GetString("PrevSleep.ToolTip"));
            // 
            // PreventAwayMode
            // 
            resources.ApplyResources(this.PreventAwayMode, "PreventAwayMode");
            this.PreventAwayMode.DisplayStatus = false;
            this.PreventAwayMode.Name = "PreventAwayMode";
            this.PreventAwayMode.Style = MetroFramework.MetroColorStyle.Black;
            this.FadeTimingTip.SetToolTip(this.PreventAwayMode, resources.GetString("PreventAwayMode.ToolTip"));
            this.PreventAwayMode.UseSelectable = true;
            // 
            // StartUpLabel
            // 
            resources.ApplyResources(this.StartUpLabel, "StartUpLabel");
            this.StartUpLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.StartUpLabel.Name = "StartUpLabel";
            this.StartUpLabel.Style = MetroFramework.MetroColorStyle.Black;
            this.StartUpLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.StartUpLabel, resources.GetString("StartUpLabel.ToolTip"));
            // 
            // SelectColor
            // 
            resources.ApplyResources(this.SelectColor, "SelectColor");
            this.SelectColor.Name = "SelectColor";
            this.SelectColor.Style = MetroFramework.MetroColorStyle.Black;
            this.SelectColor.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.SelectColor, resources.GetString("SelectColor.ToolTip"));
            this.SelectColor.UseSelectable = true;
            this.SelectColor.Click += new System.EventHandler(this.SelectColor_Click);
            // 
            // metroLabel19
            // 
            resources.ApplyResources(this.metroLabel19, "metroLabel19");
            this.metroLabel19.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel19.Name = "metroLabel19";
            this.metroLabel19.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel19.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.metroLabel19, resources.GetString("metroLabel19.ToolTip"));
            // 
            // AmbilightModes
            // 
            resources.ApplyResources(this.AmbilightModes, "AmbilightModes");
            this.AmbilightModes.BackColor = System.Drawing.SystemColors.WindowText;
            this.AmbilightModes.FormattingEnabled = true;
            this.AmbilightModes.Name = "AmbilightModes";
            this.AmbilightModes.Style = MetroFramework.MetroColorStyle.Black;
            this.AmbilightModes.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.AmbilightModes, resources.GetString("AmbilightModes.ToolTip"));
            this.AmbilightModes.UseSelectable = true;
            this.AmbilightModes.SelectedIndexChanged += new System.EventHandler(this.AmbilightModes_SelectedIndexChanged);
            // 
            // FadeTiming
            // 
            resources.ApplyResources(this.FadeTiming, "FadeTiming");
            this.FadeTiming.BackColor = System.Drawing.Color.Transparent;
            this.FadeTiming.ForeColor = System.Drawing.Color.Black;
            this.FadeTiming.Maximum = 1000;
            this.FadeTiming.MouseWheelBarPartitions = 1;
            this.FadeTiming.Name = "FadeTiming";
            this.FadeTiming.Tag = "";
            this.FadeTiming.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.FadeTiming, resources.GetString("FadeTiming.ToolTip"));
            this.FadeTiming.Value = 100;
            this.FadeTiming.ValueChanged += new System.EventHandler(this.FadeTimingValueChanged);
            // 
            // StartStop
            // 
            resources.ApplyResources(this.StartStop, "StartStop");
            this.StartStop.DisplayStatus = false;
            this.StartStop.Name = "StartStop";
            this.StartStop.Style = MetroFramework.MetroColorStyle.Black;
            this.FadeTimingTip.SetToolTip(this.StartStop, resources.GetString("StartStop.ToolTip"));
            this.StartStop.UseSelectable = true;
            this.StartStop.CheckStateChanged += new System.EventHandler(this.StartStop_CheckStateChanged);
            // 
            // Default_Timings
            // 
            resources.ApplyResources(this.Default_Timings, "Default_Timings");
            this.Default_Timings.Name = "Default_Timings";
            this.Default_Timings.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.Default_Timings, resources.GetString("Default_Timings.ToolTip"));
            // 
            // ControlTabs
            // 
            resources.ApplyResources(this.ControlTabs, "ControlTabs");
            this.ControlTabs.Controls.Add(this.HomeTab);
            this.ControlTabs.Controls.Add(this.AreaTab);
            this.ControlTabs.Controls.Add(this.SettingsTab);
            this.ControlTabs.HotTrack = true;
            this.ControlTabs.Name = "ControlTabs";
            this.ControlTabs.SelectedIndex = 2;
            this.ControlTabs.Style = MetroFramework.MetroColorStyle.Black;
            this.ControlTabs.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.ControlTabs, resources.GetString("ControlTabs.ToolTip"));
            this.ControlTabs.UseSelectable = true;
            // 
            // AreaTab
            // 
            resources.ApplyResources(this.AreaTab, "AreaTab");
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
            this.AreaTab.Name = "AreaTab";
            this.AreaTab.Style = MetroFramework.MetroColorStyle.Black;
            this.AreaTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.AreaTab, resources.GetString("AreaTab.ToolTip"));
            this.AreaTab.VerticalScrollbarBarColor = true;
            this.AreaTab.VerticalScrollbarHighlightOnWheel = false;
            this.AreaTab.VerticalScrollbarSize = 10;
            // 
            // TrayIconMenu
            // 
            resources.ApplyResources(this.TrayIconMenu, "TrayIconMenu");
            this.TrayIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.TrayIconMenu.Name = "TrayIconMenu";
            this.TrayIconMenu.ShowImageMargin = false;
            this.TrayIconMenu.Style = MetroFramework.MetroColorStyle.Black;
            this.TrayIconMenu.TabStop = true;
            this.TrayIconMenu.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this.TrayIconMenu, resources.GetString("TrayIconMenu.ToolTip"));
            this.TrayIconMenu.UseSelectable = true;
            // 
            // startToolStripMenuItem
            // 
            resources.ApplyResources(this.startToolStripMenuItem, "startToolStripMenuItem");
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.StartStopFromTrayClicked);
            // 
            // openToolStripMenuItem
            // 
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenFromTrayClicked);
            // 
            // exitToolStripMenuItem
            // 
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitFromTrayClicked);
            // 
            // FadeTimingTip
            // 
            this.FadeTimingTip.Style = MetroFramework.MetroColorStyle.Black;
            this.FadeTimingTip.StyleManager = null;
            this.FadeTimingTip.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // BlackStyleManager
            // 
            this.BlackStyleManager.Owner = this;
            this.BlackStyleManager.Style = MetroFramework.MetroColorStyle.Black;
            this.BlackStyleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // DynamicAmbilight
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.TrayIconMenu;
            this.Controls.Add(this.ControlTabs);
            this.MaximizeBox = false;
            this.Name = "DynamicAmbilight";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FadeTimingTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.TopMost = true;
            this.SettingsTab.ResumeLayout(false);
            this.SettingsTab.PerformLayout();
            this.HomeTab.ResumeLayout(false);
            this.HomeTab.PerformLayout();
            this.ControlTabs.ResumeLayout(false);
            this.AreaTab.ResumeLayout(false);
            this.AreaTab.PerformLayout();
            this.TrayIconMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BlackStyleManager)).EndInit();
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
        private MetroFramework.Controls.MetroLabel DefAudioInput;
        private MetroFramework.Controls.MetroToggle UseDefaultAudio;
        private MetroFramework.Controls.MetroComboBox AudioInputs;
        private MetroFramework.Controls.MetroComboBox ColorSelection;
        private MetroFramework.Controls.MetroContextMenu TrayIconMenu;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private MetroFramework.Components.MetroToolTip FadeTimingTip;
        private MetroFramework.Components.MetroStyleManager BlackStyleManager;
    }
}

