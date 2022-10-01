namespace Weighing_System_v._1c._0
{
    partial class mfr_sttngs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mfr_sttngs));
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.btn_cancel = new MetroFramework.Controls.MetroButton();
            this.btn_dbs_n = new MetroFramework.Controls.MetroButton();
            this.tab_ops_child = new MetroFramework.Controls.MetroTabControl();
            this.tab_trns_pending = new MetroFramework.Controls.MetroTabPage();
            this.cbo_dev = new MetroFramework.Controls.MetroComboBox();
            this.cbo_pty = new MetroFramework.Controls.MetroComboBox();
            this.cbo_br = new MetroFramework.Controls.MetroComboBox();
            this.cbo_hndshke = new MetroFramework.Controls.MetroComboBox();
            this.cbo_sbits = new MetroFramework.Controls.MetroComboBox();
            this.cbo_dbits = new MetroFramework.Controls.MetroComboBox();
            this.cbo_prt = new MetroFramework.Controls.MetroComboBox();
            this.tab_trns_mgmt = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.txt_refno = new MetroFramework.Controls.MetroTextBox();
            this.btn_show_adv_fltr = new MetroFramework.Controls.MetroButton();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txt_ip1 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txt_ip2 = new MetroFramework.Controls.MetroTextBox();
            this.label2 = new MetroFramework.Controls.MetroLabel();
            this.txt_time_out = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel1.SuspendLayout();
            this.tab_ops_child.SuspendLayout();
            this.tab_trns_pending.SuspendLayout();
            this.tab_trns_mgmt.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.btn_cancel);
            this.metroPanel1.Controls.Add(this.btn_dbs_n);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 453);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(441, 41);
            this.metroPanel1.TabIndex = 3;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(324, 6);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(110, 29);
            this.btn_cancel.Style = MetroFramework.MetroColorStyle.Black;
            this.btn_cancel.TabIndex = 67;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseSelectable = true;
            this.btn_cancel.UseStyleColors = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_dbs_n
            // 
            this.btn_dbs_n.Location = new System.Drawing.Point(208, 6);
            this.btn_dbs_n.Name = "btn_dbs_n";
            this.btn_dbs_n.Size = new System.Drawing.Size(110, 29);
            this.btn_dbs_n.Style = MetroFramework.MetroColorStyle.Black;
            this.btn_dbs_n.TabIndex = 66;
            this.btn_dbs_n.Text = "Apply";
            this.btn_dbs_n.UseSelectable = true;
            this.btn_dbs_n.UseStyleColors = true;
            this.btn_dbs_n.Click += new System.EventHandler(this.btn_dbs_n_Click);
            // 
            // tab_ops_child
            // 
            this.tab_ops_child.Controls.Add(this.tab_trns_pending);
            this.tab_ops_child.Controls.Add(this.tab_trns_mgmt);
            this.tab_ops_child.Controls.Add(this.metroTabPage1);
            this.tab_ops_child.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_ops_child.ItemSize = new System.Drawing.Size(200, 30);
            this.tab_ops_child.Location = new System.Drawing.Point(20, 60);
            this.tab_ops_child.Name = "tab_ops_child";
            this.tab_ops_child.SelectedIndex = 2;
            this.tab_ops_child.Size = new System.Drawing.Size(441, 393);
            this.tab_ops_child.Style = MetroFramework.MetroColorStyle.Yellow;
            this.tab_ops_child.TabIndex = 74;
            this.tab_ops_child.Tag = "File Maintenance";
            this.tab_ops_child.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tab_ops_child.UseSelectable = true;
            // 
            // tab_trns_pending
            // 
            this.tab_trns_pending.Controls.Add(this.cbo_dev);
            this.tab_trns_pending.Controls.Add(this.cbo_pty);
            this.tab_trns_pending.Controls.Add(this.cbo_br);
            this.tab_trns_pending.Controls.Add(this.cbo_hndshke);
            this.tab_trns_pending.Controls.Add(this.cbo_sbits);
            this.tab_trns_pending.Controls.Add(this.cbo_dbits);
            this.tab_trns_pending.Controls.Add(this.cbo_prt);
            this.tab_trns_pending.HorizontalScrollbarBarColor = true;
            this.tab_trns_pending.HorizontalScrollbarHighlightOnWheel = false;
            this.tab_trns_pending.HorizontalScrollbarSize = 10;
            this.tab_trns_pending.Location = new System.Drawing.Point(4, 34);
            this.tab_trns_pending.Name = "tab_trns_pending";
            this.tab_trns_pending.Size = new System.Drawing.Size(433, 355);
            this.tab_trns_pending.TabIndex = 0;
            this.tab_trns_pending.Text = "Serial Communication Settings";
            this.tab_trns_pending.VerticalScrollbarBarColor = true;
            this.tab_trns_pending.VerticalScrollbarHighlightOnWheel = false;
            this.tab_trns_pending.VerticalScrollbarSize = 10;
            // 
            // cbo_dev
            // 
            this.cbo_dev.FormattingEnabled = true;
            this.cbo_dev.IntegralHeight = false;
            this.cbo_dev.ItemHeight = 23;
            this.cbo_dev.Location = new System.Drawing.Point(114, 207);
            this.cbo_dev.MaxDropDownItems = 10;
            this.cbo_dev.Name = "cbo_dev";
            this.cbo_dev.Size = new System.Drawing.Size(201, 29);
            this.cbo_dev.Style = MetroFramework.MetroColorStyle.Green;
            this.cbo_dev.TabIndex = 84;
            this.cbo_dev.ToolTipMessage = "";
            this.cbo_dev.UseSelectable = true;
            // 
            // cbo_pty
            // 
            this.cbo_pty.FormattingEnabled = true;
            this.cbo_pty.IntegralHeight = false;
            this.cbo_pty.ItemHeight = 23;
            this.cbo_pty.Location = new System.Drawing.Point(113, 102);
            this.cbo_pty.MaxDropDownItems = 10;
            this.cbo_pty.Name = "cbo_pty";
            this.cbo_pty.Size = new System.Drawing.Size(201, 29);
            this.cbo_pty.Style = MetroFramework.MetroColorStyle.Green;
            this.cbo_pty.TabIndex = 83;
            this.cbo_pty.ToolTipMessage = "";
            this.cbo_pty.UseSelectable = true;
            // 
            // cbo_br
            // 
            this.cbo_br.FormattingEnabled = true;
            this.cbo_br.IntegralHeight = false;
            this.cbo_br.ItemHeight = 23;
            this.cbo_br.Location = new System.Drawing.Point(113, 67);
            this.cbo_br.MaxDropDownItems = 10;
            this.cbo_br.Name = "cbo_br";
            this.cbo_br.Size = new System.Drawing.Size(201, 29);
            this.cbo_br.Style = MetroFramework.MetroColorStyle.Green;
            this.cbo_br.TabIndex = 82;
            this.cbo_br.ToolTipMessage = "";
            this.cbo_br.UseSelectable = true;
            // 
            // cbo_hndshke
            // 
            this.cbo_hndshke.FormattingEnabled = true;
            this.cbo_hndshke.IntegralHeight = false;
            this.cbo_hndshke.ItemHeight = 23;
            this.cbo_hndshke.Location = new System.Drawing.Point(114, 242);
            this.cbo_hndshke.MaxDropDownItems = 10;
            this.cbo_hndshke.Name = "cbo_hndshke";
            this.cbo_hndshke.Size = new System.Drawing.Size(201, 29);
            this.cbo_hndshke.Style = MetroFramework.MetroColorStyle.Green;
            this.cbo_hndshke.TabIndex = 81;
            this.cbo_hndshke.ToolTipMessage = "";
            this.cbo_hndshke.UseSelectable = true;
            this.cbo_hndshke.Visible = false;
            // 
            // cbo_sbits
            // 
            this.cbo_sbits.FormattingEnabled = true;
            this.cbo_sbits.IntegralHeight = false;
            this.cbo_sbits.ItemHeight = 23;
            this.cbo_sbits.Location = new System.Drawing.Point(114, 172);
            this.cbo_sbits.MaxDropDownItems = 10;
            this.cbo_sbits.Name = "cbo_sbits";
            this.cbo_sbits.Size = new System.Drawing.Size(201, 29);
            this.cbo_sbits.Style = MetroFramework.MetroColorStyle.Green;
            this.cbo_sbits.TabIndex = 80;
            this.cbo_sbits.ToolTipMessage = "";
            this.cbo_sbits.UseSelectable = true;
            // 
            // cbo_dbits
            // 
            this.cbo_dbits.FormattingEnabled = true;
            this.cbo_dbits.IntegralHeight = false;
            this.cbo_dbits.ItemHeight = 23;
            this.cbo_dbits.Location = new System.Drawing.Point(114, 137);
            this.cbo_dbits.MaxDropDownItems = 10;
            this.cbo_dbits.Name = "cbo_dbits";
            this.cbo_dbits.Size = new System.Drawing.Size(201, 29);
            this.cbo_dbits.Style = MetroFramework.MetroColorStyle.Green;
            this.cbo_dbits.TabIndex = 79;
            this.cbo_dbits.ToolTipMessage = "";
            this.cbo_dbits.UseSelectable = true;
            // 
            // cbo_prt
            // 
            this.cbo_prt.FormattingEnabled = true;
            this.cbo_prt.IntegralHeight = false;
            this.cbo_prt.ItemHeight = 23;
            this.cbo_prt.Location = new System.Drawing.Point(113, 32);
            this.cbo_prt.MaxDropDownItems = 10;
            this.cbo_prt.Name = "cbo_prt";
            this.cbo_prt.Size = new System.Drawing.Size(201, 29);
            this.cbo_prt.Style = MetroFramework.MetroColorStyle.Green;
            this.cbo_prt.TabIndex = 78;
            this.cbo_prt.ToolTipMessage = "";
            this.cbo_prt.UseSelectable = true;
            // 
            // tab_trns_mgmt
            // 
            this.tab_trns_mgmt.Controls.Add(this.metroLabel10);
            this.tab_trns_mgmt.Controls.Add(this.txt_refno);
            this.tab_trns_mgmt.Controls.Add(this.btn_show_adv_fltr);
            this.tab_trns_mgmt.HorizontalScrollbarBarColor = true;
            this.tab_trns_mgmt.HorizontalScrollbarHighlightOnWheel = false;
            this.tab_trns_mgmt.HorizontalScrollbarSize = 10;
            this.tab_trns_mgmt.Location = new System.Drawing.Point(4, 34);
            this.tab_trns_mgmt.Name = "tab_trns_mgmt";
            this.tab_trns_mgmt.Padding = new System.Windows.Forms.Padding(1);
            this.tab_trns_mgmt.Size = new System.Drawing.Size(433, 355);
            this.tab_trns_mgmt.TabIndex = 1;
            this.tab_trns_mgmt.Text = "Reference No.";
            this.tab_trns_mgmt.VerticalScrollbarBarColor = true;
            this.tab_trns_mgmt.VerticalScrollbarHighlightOnWheel = false;
            this.tab_trns_mgmt.VerticalScrollbarSize = 10;
            // 
            // metroLabel10
            // 
            this.metroLabel10.AsButtonColor = MetroFramework.MetroColorStyle.Default;
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel10.Location = new System.Drawing.Point(4, 18);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(92, 19);
            this.metroLabel10.TabIndex = 72;
            this.metroLabel10.Text = "Reference No.";
            // 
            // txt_refno
            // 
            this.txt_refno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            // 
            // 
            // 
            this.txt_refno.CustomButton.Image = null;
            this.txt_refno.CustomButton.Location = new System.Drawing.Point(156, 2);
            this.txt_refno.CustomButton.Name = "";
            this.txt_refno.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_refno.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_refno.CustomButton.TabIndex = 1;
            this.txt_refno.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_refno.CustomButton.UseSelectable = true;
            this.txt_refno.CustomButton.Visible = false;
            this.txt_refno.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txt_refno.Lines = new string[0];
            this.txt_refno.Location = new System.Drawing.Point(133, 15);
            this.txt_refno.MaxLength = 60;
            this.txt_refno.Name = "txt_refno";
            this.txt_refno.PasswordChar = '\0';
            this.txt_refno.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_refno.SelectedText = "";
            this.txt_refno.SelectionLength = 0;
            this.txt_refno.SelectionStart = 0;
            this.txt_refno.ShortcutsEnabled = true;
            this.txt_refno.Size = new System.Drawing.Size(180, 26);
            this.txt_refno.TabIndex = 71;
            this.txt_refno.ToolTipMessage = "";
            this.txt_refno.UseSelectable = true;
            this.txt_refno.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.txt_refno.WaterMarkFont = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_refno.Leave += new System.EventHandler(this.txt_refno_Leave);
            // 
            // btn_show_adv_fltr
            // 
            this.btn_show_adv_fltr.Location = new System.Drawing.Point(843, 18);
            this.btn_show_adv_fltr.Name = "btn_show_adv_fltr";
            this.btn_show_adv_fltr.Size = new System.Drawing.Size(137, 26);
            this.btn_show_adv_fltr.TabIndex = 70;
            this.btn_show_adv_fltr.Text = "Show advance filter";
            this.btn_show_adv_fltr.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.label2);
            this.metroTabPage1.Controls.Add(this.txt_time_out);
            this.metroTabPage1.Controls.Add(this.metroLabel2);
            this.metroTabPage1.Controls.Add(this.txt_ip2);
            this.metroTabPage1.Controls.Add(this.metroLabel1);
            this.metroTabPage1.Controls.Add(this.txt_ip1);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 34);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(433, 355);
            this.metroTabPage1.TabIndex = 2;
            this.metroTabPage1.Text = "Camera Settings";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AsButtonColor = MetroFramework.MetroColorStyle.Default;
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel1.Location = new System.Drawing.Point(5, 20);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(65, 19);
            this.metroLabel1.TabIndex = 74;
            this.metroLabel1.Text = "Camera 1";
            // 
            // txt_ip1
            // 
            this.txt_ip1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            // 
            // 
            // 
            this.txt_ip1.CustomButton.Image = null;
            this.txt_ip1.CustomButton.Location = new System.Drawing.Point(156, 2);
            this.txt_ip1.CustomButton.Name = "";
            this.txt_ip1.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_ip1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_ip1.CustomButton.TabIndex = 1;
            this.txt_ip1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_ip1.CustomButton.UseSelectable = true;
            this.txt_ip1.CustomButton.Visible = false;
            this.txt_ip1.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txt_ip1.Lines = new string[0];
            this.txt_ip1.Location = new System.Drawing.Point(134, 17);
            this.txt_ip1.MaxLength = 60;
            this.txt_ip1.Name = "txt_ip1";
            this.txt_ip1.PasswordChar = '\0';
            this.txt_ip1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_ip1.SelectedText = "";
            this.txt_ip1.SelectionLength = 0;
            this.txt_ip1.SelectionStart = 0;
            this.txt_ip1.ShortcutsEnabled = true;
            this.txt_ip1.Size = new System.Drawing.Size(180, 26);
            this.txt_ip1.TabIndex = 73;
            this.txt_ip1.ToolTipMessage = "";
            this.txt_ip1.UseSelectable = true;
            this.txt_ip1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.txt_ip1.WaterMarkFont = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // metroLabel2
            // 
            this.metroLabel2.AsButtonColor = MetroFramework.MetroColorStyle.Default;
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel2.Location = new System.Drawing.Point(5, 52);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(67, 19);
            this.metroLabel2.TabIndex = 76;
            this.metroLabel2.Text = "Camera 2";
            // 
            // txt_ip2
            // 
            this.txt_ip2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            // 
            // 
            // 
            this.txt_ip2.CustomButton.Image = null;
            this.txt_ip2.CustomButton.Location = new System.Drawing.Point(156, 2);
            this.txt_ip2.CustomButton.Name = "";
            this.txt_ip2.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_ip2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_ip2.CustomButton.TabIndex = 1;
            this.txt_ip2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_ip2.CustomButton.UseSelectable = true;
            this.txt_ip2.CustomButton.Visible = false;
            this.txt_ip2.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txt_ip2.Lines = new string[0];
            this.txt_ip2.Location = new System.Drawing.Point(134, 49);
            this.txt_ip2.MaxLength = 60;
            this.txt_ip2.Name = "txt_ip2";
            this.txt_ip2.PasswordChar = '\0';
            this.txt_ip2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_ip2.SelectedText = "";
            this.txt_ip2.SelectionLength = 0;
            this.txt_ip2.SelectionStart = 0;
            this.txt_ip2.ShortcutsEnabled = true;
            this.txt_ip2.Size = new System.Drawing.Size(180, 26);
            this.txt_ip2.TabIndex = 75;
            this.txt_ip2.ToolTipMessage = "";
            this.txt_ip2.UseSelectable = true;
            this.txt_ip2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.txt_ip2.WaterMarkFont = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // label2
            // 
            this.label2.AsButtonColor = MetroFramework.MetroColorStyle.Default;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(5, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 19);
            this.label2.TabIndex = 78;
            this.label2.Text = "Time Out";
            // 
            // txt_time_out
            // 
            this.txt_time_out.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            // 
            // 
            // 
            this.txt_time_out.CustomButton.Image = null;
            this.txt_time_out.CustomButton.Location = new System.Drawing.Point(156, 2);
            this.txt_time_out.CustomButton.Name = "";
            this.txt_time_out.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_time_out.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_time_out.CustomButton.TabIndex = 1;
            this.txt_time_out.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_time_out.CustomButton.UseSelectable = true;
            this.txt_time_out.CustomButton.Visible = false;
            this.txt_time_out.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txt_time_out.Lines = new string[0];
            this.txt_time_out.Location = new System.Drawing.Point(134, 81);
            this.txt_time_out.MaxLength = 60;
            this.txt_time_out.Name = "txt_time_out";
            this.txt_time_out.PasswordChar = '\0';
            this.txt_time_out.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_time_out.SelectedText = "";
            this.txt_time_out.SelectionLength = 0;
            this.txt_time_out.SelectionStart = 0;
            this.txt_time_out.ShortcutsEnabled = true;
            this.txt_time_out.Size = new System.Drawing.Size(180, 26);
            this.txt_time_out.TabIndex = 77;
            this.txt_time_out.ToolTipMessage = "";
            this.txt_time_out.UseSelectable = true;
            this.txt_time_out.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.txt_time_out.WaterMarkFont = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // mfr_sttngs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 514);
            this.ControlBox = false;
            this.Controls.Add(this.tab_ops_child);
            this.Controls.Add(this.metroPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "mfr_sttngs";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "System Settings";
            this.metroPanel1.ResumeLayout(false);
            this.tab_ops_child.ResumeLayout(false);
            this.tab_trns_pending.ResumeLayout(false);
            this.tab_trns_mgmt.ResumeLayout(false);
            this.tab_trns_mgmt.PerformLayout();
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTabControl tab_ops_child;
        private MetroFramework.Controls.MetroTabPage tab_trns_pending;
        private MetroFramework.Controls.MetroComboBox cbo_dev;
        private MetroFramework.Controls.MetroComboBox cbo_pty;
        private MetroFramework.Controls.MetroComboBox cbo_br;
        private MetroFramework.Controls.MetroComboBox cbo_hndshke;
        private MetroFramework.Controls.MetroComboBox cbo_sbits;
        private MetroFramework.Controls.MetroComboBox cbo_dbits;
        private MetroFramework.Controls.MetroComboBox cbo_prt;
        private MetroFramework.Controls.MetroTabPage tab_trns_mgmt;
        private MetroFramework.Controls.MetroButton btn_show_adv_fltr;
        private MetroFramework.Controls.MetroButton btn_dbs_n;
        private MetroFramework.Controls.MetroTextBox txt_refno;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroButton btn_cancel;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txt_ip2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txt_ip1;
        private MetroFramework.Controls.MetroLabel label2;
        private MetroFramework.Controls.MetroTextBox txt_time_out;

    }
}