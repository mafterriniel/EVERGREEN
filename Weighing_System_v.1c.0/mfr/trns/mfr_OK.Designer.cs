namespace Weighing_System_v._1c._0
{
    partial class mfr_OK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mfr_OK));
            this.pnl_d = new MetroFramework.Controls.MetroPanel();
            this.btn_ok = new MetroFramework.Controls.MetroButton();
            this.btn_re_print = new MetroFramework.Controls.MetroButton();
            this.txt_id = new MetroFramework.Controls.MetroTextBox();
            this.pnl_d.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_d
            // 
            this.pnl_d.Controls.Add(this.btn_ok);
            this.pnl_d.Controls.Add(this.btn_re_print);
            this.pnl_d.Controls.Add(this.txt_id);
            this.pnl_d.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_d.HorizontalScrollbarBarColor = true;
            this.pnl_d.HorizontalScrollbarHighlightOnWheel = false;
            this.pnl_d.HorizontalScrollbarSize = 10;
            this.pnl_d.Location = new System.Drawing.Point(20, 60);
            this.pnl_d.Name = "pnl_d";
            this.pnl_d.Size = new System.Drawing.Size(508, 129);
            this.pnl_d.TabIndex = 2;
            this.pnl_d.VerticalScrollbarBarColor = true;
            this.pnl_d.VerticalScrollbarHighlightOnWheel = false;
            this.pnl_d.VerticalScrollbarSize = 10;
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_ok.Location = new System.Drawing.Point(411, 82);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(94, 44);
            this.btn_ok.TabIndex = 65;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseSelectable = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_re_print
            // 
            this.btn_re_print.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_re_print.Location = new System.Drawing.Point(306, 82);
            this.btn_re_print.Name = "btn_re_print";
            this.btn_re_print.Size = new System.Drawing.Size(94, 44);
            this.btn_re_print.TabIndex = 64;
            this.btn_re_print.Text = "reprint";
            this.btn_re_print.UseSelectable = true;
            this.btn_re_print.Click += new System.EventHandler(this.btn_re_print_Click);
            // 
            // txt_id
            // 
            // 
            // 
            // 
            this.txt_id.CustomButton.Image = null;
            this.txt_id.CustomButton.Location = new System.Drawing.Point(-20, 2);
            this.txt_id.CustomButton.Name = "";
            this.txt_id.CustomButton.Size = new System.Drawing.Size(17, 17);
            this.txt_id.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_id.CustomButton.TabIndex = 1;
            this.txt_id.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_id.CustomButton.UseSelectable = true;
            this.txt_id.CustomButton.Visible = false;
            this.txt_id.Lines = new string[0];
            this.txt_id.Location = new System.Drawing.Point(0, 0);
            this.txt_id.MaxLength = 32767;
            this.txt_id.Name = "txt_id";
            this.txt_id.PasswordChar = '\0';
            this.txt_id.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_id.SelectedText = "";
            this.txt_id.SelectionLength = 0;
            this.txt_id.SelectionStart = 0;
            this.txt_id.ShortcutsEnabled = true;
            this.txt_id.Size = new System.Drawing.Size(0, 22);
            this.txt_id.TabIndex = 60;
            this.txt_id.ToolTipMessage = "";
            this.txt_id.UseSelectable = true;
            this.txt_id.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_id.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mfr_OK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_ok;
            this.ClientSize = new System.Drawing.Size(548, 209);
            this.ControlBox = false;
            this.Controls.Add(this.pnl_d);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "mfr_OK";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Transaction Complete";
            this.pnl_d.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel pnl_d;
        private MetroFramework.Controls.MetroTextBox txt_id;
        private MetroFramework.Controls.MetroButton btn_ok;
        private MetroFramework.Controls.MetroButton btn_re_print;
    }
}