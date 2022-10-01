using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;
using System.Data.Sql;
using Transitions;
using System.Data.Entity.Core.Objects;
using System.Threading;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;
using System.Data.Entity.Validation;
using System.Data.Entity;
namespace Weighing_System_v._1c._0
{
    public partial class mfr_mn2 : MetroForm, IClass.IForm, IClass.IPaging
    {
        public mfr_mn2()
        {
            sys.domain.Classes.custom_culture.setCustomCulture();
            InitializeComponent();
            set_pagination_event_handlers();
            set_handlers();

            this.Load += new System.EventHandler(load);
            this.KeyDown += new KeyEventHandler(key_down);
            this.FormClosing +=new System.Windows.Forms.FormClosingEventHandler(this.closing);
        }

        private void init_login()
        {
            pnl_login.Size = main_tab.Size;
            pnl_login.Top = main_tab.Top;
            pnl_login.Left = main_tab.Left;
            //main_tab.Visible = false;
            pnl_con.Height = 0;
            pnl_usr.Visible = false;
            main_tab.Enabled = false;
            txt_uid.Text = "";
            txt_pwd.Text = "";
            global.settings.INI_CONN_TYPE = "SQL";
            global.settings.INI_CATALOG = "EVERGREEN";
            global.settings._iniS();
            txt_svr_nme.Text = global.settings.INI_SERVERNAME;
            txt_svr_db.Text = global.settings.INI_CATALOG;
            txt_svr_id.Text = global.settings.INI_SQLUID;
            txt_svr_pwd.Text = global.settings.INI_SQLPWD;
            btn_sttngs.Enabled = false;
        }

        private void init_ops()
        {
            dt_b_fr.Format = DateTimePickerFormat.Custom;
            dt_b_fr.CustomFormat = "MMM-dd-yyyy";
            dt_b_t.Format = DateTimePickerFormat.Custom;
            dt_b_t.CustomFormat = "MMM-dd-yyyy";

            cbo_fltr_hrF.Items.Clear(); cbo_fltr_hrF.Items.Add("00:00"); for (int i = 0; i <= 24; i++) { cbo_fltr_hrF.Items.Add(string.Format("{0:00}", i) + ":00"); }; cbo_fltr_hrF.IntegralHeight = false; cbo_fltr_hrF.MaxDropDownItems = 10;
            cbo_fltr_hrT.Items.Clear(); cbo_fltr_hrT.Items.Add("00:00"); for (int i = 0; i <= 24; i++) { cbo_fltr_hrT.Items.Add(string.Format("{0:00}", i) + ":00"); }; cbo_fltr_hrT.IntegralHeight = false; cbo_fltr_hrT.MaxDropDownItems = 10;
            cbo_fltr_hrF.SelectedIndex = 0;
            cbo_fltr_hrT.SelectedIndex = cbo_fltr_hrT.Items.Count - 1;

         

            txt_srch_trns.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_srch_trns.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_srch_trns.CharacterCasing = CharacterCasing.Upper;
            txt_srch_trns.TextChanged += new System.EventHandler(search);


            dg_trns.ColumnHeadersHeight = 50;
            dg_trns.RowHeadersVisible = false;
            dg_trns.AllowUserToAddRows = false;
            dg_trns.AllowUserToDeleteRows = false;
            dg_trns.AllowUserToOrderColumns = false;
            dg_trns.AllowUserToResizeRows = false;
            dg_trns.AllowUserToResizeColumns = false;
            dg_trns.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dg_trns.RowTemplate.Height = 25;

            pnl_adv_fltr.Height = dg_trns.Height;
            tab_ops.Controls.Add(pnl_pg_nav);
            pnl_pg_nav.BringToFront();
            dg_trns.BringToFront();

            tab_ops.Controls.Add(pnl_adv_fltr);
            pnl_adv_fltr.Dock = DockStyle.None;
            pnl_adv_fltr.Left = this.Width;
            pnl_adv_fltr.Top = tab_ops_child.Top + tab_ops_child.Height; ;
            pnl_adv_fltr.BringToFront();
            pnl_adv_fltr.Height = dg_trns.Height;

            btn_w_in.Click -= new System.EventHandler(proceed); btn_w_in.Click += new System.EventHandler(proceed);
            btn_w_out.Click -= new System.EventHandler(proceed); btn_w_out.Click += new System.EventHandler(proceed);
            btn_w_del.Click -= new System.EventHandler(proceed); btn_w_del.Click += new System.EventHandler(proceed);
            btn_t_mod.Click -= new System.EventHandler(proceed); btn_t_mod.Click += new System.EventHandler(proceed);
            btn_t_del.Click -= new System.EventHandler(proceed); btn_t_del.Click += new System.EventHandler(proceed);
            btn_t_prnt.Click -= new System.EventHandler(proceed); btn_t_prnt.Click += new System.EventHandler(proceed);
            btn_gen_adv.Click -= new System.EventHandler(refresh); btn_gen_adv.Click += new System.EventHandler(refresh);
            btn_show_adv_fltr.Click -= new System.EventHandler(btn_show_adv_fltr_Click); btn_show_adv_fltr.Click  += new System.EventHandler(btn_show_adv_fltr_Click);
            btn_xp.Click -= new System.EventHandler(this.proceed); btn_xp.Click += new System.EventHandler(this.proceed);

            this.dg_trns.CellClick -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_CellClick); this.dg_trns.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_CellClick);
            this.dg_trns.CellDoubleClick -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_CellDoubleClick); this.dg_trns.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_CellDoubleClick);
            this.main_tab.SelectedIndexChanged -= new System.EventHandler(this.main_tab_SelectedIndexChanged); this.main_tab.SelectedIndexChanged += new System.EventHandler(this.main_tab_SelectedIndexChanged);
            this.main_tab.Selecting -= new TabControlCancelEventHandler(this.main_tab_Selecting); this.main_tab.Selecting += new TabControlCancelEventHandler(this.main_tab_Selecting);

        }

        private void init_dbs()
        {
            cbo_tbl.Items.Clear(); cbo_tbl.Items.AddRange(new string[] { "--  Select Table --", "Suppliers", "Commodities", "Origins" }); cbo_tbl.SelectedIndex = 0;
            this.cbo_tbl.SelectedIndexChanged -= new System.EventHandler(this.cbo_tbl_SelectedIndexChanged); this.cbo_tbl.SelectedIndexChanged += new System.EventHandler(this.cbo_tbl_SelectedIndexChanged);
            this.dg_db.CellClick -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_CellClick); this.dg_db.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_CellClick);
            this.dg_db.CellDoubleClick -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_CellDoubleClick); this.dg_db.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_CellDoubleClick);

            txt_srch_db.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_srch_db.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_srch_db.CharacterCasing = CharacterCasing.Upper;
            txt_srch_db.TextChanged += new System.EventHandler(search);

            dg_db.RowHeadersVisible = false;
            dg_db.AllowUserToAddRows = false;
            dg_db.AllowUserToDeleteRows = false;
            dg_db.AllowUserToOrderColumns = false;
            dg_db.AllowUserToResizeRows = false;
            dg_db.AllowUserToResizeColumns = false;
            dg_db.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dg_db.RowTemplate.Height = 25;

            btn_dbs_n.Click -= proceed; btn_dbs_n.Click += proceed;
            btn_dbs_e.Click -= proceed; btn_dbs_e.Click += proceed;
            btn_dbs_del.Click -= proceed; btn_dbs_del.Click += proceed;

        }

        private void init_rpts()
        {
            cbo_rpt_type.Items.Clear();
            cbo_rpt_type.Items.AddRange(new string[] { "--Select Report Type--", "General Report", "Daily Tracker" });
            cbo_rpt_type.SelectedIndex = 0;
        }

        private void init_adm()
        {
            dg_admn.ColumnHeadersHeight = 50;
            dg_admn.RowHeadersVisible = false;
            dg_admn.AllowUserToAddRows = false;
            dg_admn.AllowUserToDeleteRows = false;
            dg_admn.AllowUserToOrderColumns = false;
            dg_admn.AllowUserToResizeRows = false;
            dg_admn.AllowUserToResizeColumns = false;
            dg_admn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dg_admn.RowTemplate.Height = 25;

            tab_adm_child.SelectedIndex = 0;
            this.tab_ops_child.SelectedIndexChanged -= new System.EventHandler(this.tab_trans_SelectedIndexChanged); this.tab_ops_child.SelectedIndexChanged += new System.EventHandler(this.tab_trans_SelectedIndexChanged);
            this.tab_adm_child.SelectedIndexChanged -= new System.EventHandler(this.refresh); this.tab_adm_child.SelectedIndexChanged += new System.EventHandler(this.refresh);
            this.btn_usr_n.Click -= new System.EventHandler(this.proceed); this.btn_usr_n.Click += new System.EventHandler(this.proceed);
            this.btn_usr_e.Click -= new System.EventHandler(this.proceed); this.btn_usr_e.Click += new System.EventHandler(this.proceed);
            this.btn_usr_d.Click -= new System.EventHandler(this.proceed); this.btn_usr_d.Click += new System.EventHandler(this.proceed);
            this.btn_adm_lg_refresh.Click -= new System.EventHandler(this.refresh); this.btn_adm_lg_refresh.Click += new System.EventHandler(this.refresh);
            this.dg_admn.CellClick -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_CellClick); this.dg_admn.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_CellClick);
            this.dg_admn.CellDoubleClick -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_CellDoubleClick); this.dg_admn.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_CellDoubleClick);

            dt_adm_fr.Format = DateTimePickerFormat.Custom;
            dt_adm_fr.CustomFormat = "MMM-dd-yyyy";
            dt_adm_to.Format = DateTimePickerFormat.Custom;
            dt_adm_to.CustomFormat = "MMM-dd-yyyy";

            cbo_adm_hr_fr.Items.Clear(); cbo_adm_hr_fr.Items.Add("00:00"); for (int i = 0; i <= 24; i++) { cbo_adm_hr_fr.Items.Add(string.Format("{0:00}", i) + ":00"); }; cbo_adm_hr_fr.IntegralHeight = false; cbo_adm_hr_fr.MaxDropDownItems = 10;
            cbo_adm_hr_to.Items.Clear(); cbo_adm_hr_to.Items.Add("00:00"); for (int i = 0; i <= 24; i++) { cbo_adm_hr_to.Items.Add(string.Format("{0:00}", i) + ":00"); }; cbo_adm_hr_to.IntegralHeight = false; cbo_adm_hr_to.MaxDropDownItems = 10;
            cbo_adm_type.Items.Clear(); cbo_adm_type.Items.AddRange(new string[] { "-- Select type --", "Transaction", "User" }); cbo_adm_type.SelectedIndex = 0;
        }

        private bool _is_loaded;
        public bool is_loaded
        {
            get
            {
                return _is_loaded;
            }
            set
            {
                _is_loaded = value;
            }
        }

        public void set_handlers()
        {

        }

        private mfr_mn2 _owner;
        public mfr_mn2 owner
        {
            get
            {
                return _owner;
            }
            set
            {
                _owner = value;
            }
        }

        private void main_tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (main_tab.SelectedTab.Name == tab_ops.Name || main_tab.SelectedTab.Name == tab_rpts.Name)
            {
                pnl_adv_fltr.Height = dg_trns.Height;
                pnl_adv_fltr.Dock = DockStyle.None;
               
                tab_ops.Controls.Add(pnl_adv_fltr);
                tab_ops.Controls.Add(pnl_pg_nav);
                pnl_pg_nav.BringToFront();
                dg_trns.BringToFront();
                pnl_adv_fltr.BringToFront();
                using (sys.domain.DAL.DBContext dbx = new sys.domain.DAL.DBContext(global.main_conn_str))
                {
                    cbo_fltr_sup.Items.Clear(); cbo_fltr_sup.Items.Add("-- Select Supplier --"); cbo_fltr_sup.Items.AddRange(dbx.Clients.Where(a => a.is_supplier == true).Select(a => a.name).OrderBy(a=> a).ToArray()); cbo_fltr_sup.IntegralHeight = false; cbo_fltr_sup.MaxDropDownItems = 10; cbo_fltr_sup.SelectedIndex = 0;
                    cbo_fltr_com.Items.Clear(); cbo_fltr_com.Items.Add("-- Select Commodity --"); cbo_fltr_com.Items.AddRange(dbx.Raw_materials.Select(a => a.description).OrderBy(a=>a).ToArray()); cbo_fltr_com.IntegralHeight = false; cbo_fltr_com.MaxDropDownItems = 10; cbo_fltr_com.SelectedIndex = 0;
                    cbo_fltr_orgn.Items.Clear(); cbo_fltr_orgn.Items.Add("-- Select Origin --"); cbo_fltr_orgn.Items.AddRange(dbx.Origins.Select(a => a.origin_name).OrderBy(a=> a).ToArray()); cbo_fltr_orgn.IntegralHeight = false; cbo_fltr_orgn.MaxDropDownItems = 10; cbo_fltr_orgn.SelectedIndex = 0;
                }
            }

            if (main_tab.SelectedTab.Name == tab_dbs.Name)
            {
                tab_dbs.Controls.Add(pnl_pg_nav);
                pnl_pg_nav.BringToFront();
            }

            if (main_tab.SelectedTab.Name == tab_rpts.Name)
            {
                pnl_adv_fltr_container.Controls.Add(pnl_adv_fltr);
                pnl_adv_fltr.Dock = DockStyle.Fill;
                pnl_adv_fltr.BringToFront();
                pnl_adv_fltr.Height = dg_trns.Height;
            }

            if (main_tab.SelectedTab.Name == tab_admin.Name)
            {
                tab_admin.Controls.Add(pnl_pg_nav);
                pnl_pg_nav.BringToFront();
                dg_admn.BringToFront();

                using (sys.domain.DAL.DBContext dbx = new sys.domain.DAL.DBContext(global.main_conn_str))
                {
                    cbo_action.Items.Clear(); cbo_action.Items.Add("-- Select Activity --"); cbo_action.Items.AddRange(dbx.Actions.Select(a => a.description).ToArray());
                    txt_adm_uname.AutoCompleteCustomSource.Clear(); txt_adm_uname.AutoCompleteMode = AutoCompleteMode.SuggestAppend; txt_adm_uname.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txt_adm_uname.AutoCompleteCustomSource.AddRange(dbx.Users.Select(a => a.first_name + " " + a.middle_initial + " " + a.last_name).ToArray());
                }

                cbo_action.SelectedIndex = 0;
                cbo_adm_hr_fr.SelectedIndex = 0;
                cbo_adm_hr_to.SelectedIndex = cbo_adm_hr_to.Items.Count - 1;
            }

            refresh(null, null);
        }

        public void load(object sender, EventArgs e)
        {
            int left = (Screen.PrimaryScreen.Bounds.Width / 2) - (pnl_login_window.Width / 2)-10;
            pnl_login_window.Left = left;
            init_login();

            // List<sys.domain.trns.Transactions> lst_t = new List<sys.domain.trns.Transactions>();
            // using (sys.domain.DAL.DBContext dbx = new sys.domain.DAL.DBContext(global.main_conn_str))
            // {
            //     lst_t = dbx.Transactions.Select(a => a).ToList();
            // }

            // ExcelExport.ExportExcel xls = new ExcelExport.ExportExcel();
            // xls.lbl = lbl_lgn_msg;
            // xls.transaction_records = lst_t;

            // xls.excel_file_path = "D:\\Delivery_tracker.xlsx";
            //await xls.update_excel_delivery_tracker();
            //xls.excel_file_path = "D:\\master_sheet.xlsx";
            //await xls.update_master_list(); 


            //Console.WriteLine(xls.work_sheet.Range["B3"].Value);
            //xls.releaseObjects();

        }

        public void back(object sender, EventArgs e)
        {

        }

        public void closing(object sender, EventArgs e)
        {
            if (global.logged_in_user == null) return;
            btn_log_out_Click(null, null);
        }

        public void list(object sender, EventArgs e)
        {
            if (!is_loaded) return;
            using (sys.domain.DAL.DBContext dbx = new sys.domain.DAL.DBContext(global.main_conn_str))
            {
                //////  Operations
                IEnumerable<sys.domain.trns.Transactions> t = null;
                if (main_tab.SelectedTab.Name == tab_ops.Name)
                {
                    switch (tab_ops_child.SelectedIndex)
                    {
                        case 0: if (ALLOW_W_LST == false) return; t = sys.domain.procedures.list_trans(dbx, null, null); break;
                        case 1: if (ALLOW_MGMT_LST == false) return;
                            if (pnl_adv_fltr.Left == this.Width)
                            { t = sys.domain.procedures.list_trans(dbx, dt_b_fr.Value, dt_b_t.Value, cbo_fltr_hrF.Text, cbo_fltr_hrT.Text); }
                            else
                            { t = sys.domain.procedures.list_trans(dbx, dt_b_fr.Value, dt_b_t.Value, cbo_fltr_hrF.Text, cbo_fltr_hrT.Text, null, cbo_fltr_sup.SelectedIndex != 0 ? cbo_fltr_sup.Text : null, cbo_fltr_com.SelectedIndex != 0 ? cbo_fltr_com.Text : null, cbo_fltr_orgn.SelectedIndex != 0 ? cbo_fltr_orgn.Text : null); }
                            break;
                    }

                    total_page = t.Count();
                }

                //////  Database
                if (main_tab.SelectedTab.Name == tab_dbs.Name)
                {
                    if (ALLOW_DB_LST == false) return;
                    switch (cbo_tbl.SelectedIndex)
                    {
                        case 1:
                            var clnts = sys.domain.procedures.lst_clnts(dbx, null);
                            total_page = clnts.Count(); break;
                        case 2:
                            var rmats = dbx.Raw_materials.Select(a => a).ToList();
                            total_page = rmats.Count(); break;
                        case 3:
                            var orgs = dbx.Origins.Select(a => a).ToList();
                            total_page = orgs.Count(); break;
                    }
                }

                if (main_tab.SelectedTab.Name == tab_admin.Name)
                {
                    if (ALLOW_USR_LST == false) return;
                    if (tab_adm_child.SelectedTab.Name == pg_adm_accnts.Name)
                    {
                        var v = sys.domain.procedures.lst_usrs(dbx, null);
                        total_page = v.Count();
                    }

                    if (tab_adm_child.SelectedTab.Name == pg_adm_logs.Name)
                    {
                        var v = sys.domain.procedures.lst_logs(dbx, dt_adm_fr.Value, dt_adm_to.Value, cbo_adm_hr_fr.Text, cbo_adm_hr_to.Text, cbo_action.Text, cbo_adm_type.SelectedIndex == 0 ? null : cbo_adm_type.Text, txt_adm_uname.Text);
                        total_page = v.Count();
                    }
                }
            }

            pageindex = 1;
            pagesize = Convert.ToInt32(cbo_p_size.Text.Trim());
            txt_total.Text = total_page.ToString();
            int pageover = (total_page % pagesize);
            pagelimit = (total_page / pagesize) + (pageover > 0 ? 1 : 0);
        }

        public void set_dg()
        {
            //////  Operations
            if (main_tab.SelectedTab.Name == tab_ops.Name)
            {
                foreach (DataGridViewColumn col in dg_trns.Columns)
                {
                    if (col.Name == "selected") { col.HeaderText = ""; col.Width = 60; col.Visible = true; col.ReadOnly = false; } else { col.ReadOnly = true; col.Visible = false; };
                    if (col.Name == "receipt_no") { col.HeaderText = "Receipt No."; col.Width = 90; col.Visible = tab_ops_child.SelectedIndex != 0 ? true : false; };
                    if (col.Name == "dt_in") { col.HeaderText = "Date & Time In"; col.DefaultCellStyle.Format = "MMM-dd-yyyy hh:mm:tt"; col.Width = 150; col.Visible = true; };
                    if (col.Name == "dt_out") { col.HeaderText = "Date & Time Out"; col.DefaultCellStyle.Format = "MMM-dd-yyyy hh:mm:tt"; col.Width = 150; col.Visible = true; };
                    if (col.Name == "license_plate") { col.HeaderText = "Plate Number"; col.Width = 100; col.Visible = true; };
                    if (col.Name == "reg_dt") { col.HeaderText = "Registration date & time"; col.DefaultCellStyle.Format = "MMM-dd-yyyy hh:mm:tt"; col.Width = 150; col.Visible = true; };
                    if (col.Name == "in_wt") { col.HeaderText = "Inbound Wt. (Kg.)"; col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; col.DefaultCellStyle.Format = "#,##0"; col.Width = 100; col.Visible = tab_ops_child.SelectedIndex == 0 ? true : false; };
                    if (col.Name == "gross_wt") { col.HeaderText = "Gross (Kg.)"; col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; col.DefaultCellStyle.Format = "#,##0"; col.Width = 100; col.Visible = true; };
                    if (col.Name == "tare_wt") { col.HeaderText = "Tare (Kg.)"; col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; col.DefaultCellStyle.Format = "#,##0"; col.Width = 100; col.Visible = true; };
                    if (col.Name == "net_wt") { col.HeaderText = "Net (Kg.)"; col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; col.DefaultCellStyle.Format = "#,##0"; col.Width = 100; col.Visible = true; };
                    if (col.Name == "waiting_time_str") { col.HeaderText = "Waiting time"; col.Width = 130; col.Visible = true; };
                    if (col.Name == "elapsed_time_str") { col.HeaderText = "Elapsed time"; col.Width = 130; col.Visible = true; };
                    if (col.Name == "commodity") { col.HeaderText = "Commodity"; col.Width = 200; col.Visible = true; };
                    if (col.Name == "client_name") { col.HeaderText = "Supplier"; col.Width = 200; col.Visible = true; };
                    if (col.Name == "origin") { col.HeaderText = "Origin"; col.Width = 200; col.Visible = true; };
                    if (col.Name == "driver_name") { col.HeaderText = "Driver's name"; col.Width = 180; col.Visible = true; };
                    if (col.Name == "weigher_in") { col.HeaderText = "Weigher In"; col.Width = 180; col.Visible = true; };
                    if (col.Name == "weigher_out") { col.HeaderText = "Weigher Out"; col.Width = 180; col.Visible = true; };
                }
            }
            //////  Database
            if (main_tab.SelectedTab.Name == tab_dbs.Name)
            {
                switch (cbo_tbl.SelectedIndex)
                {
                    case 0:
                        break;
                    case 1:
                        foreach (DataGridViewColumn col in dg_db.Columns)
                        {
                            if (col.Name == "selected") { col.HeaderText = ""; col.Width = 60; col.Visible = true; col.ReadOnly = false; } else { col.ReadOnly = true; col.Visible = false; };
                            if (col.Name == "client_code") { col.HeaderText = "Code"; col.Width = 200; col.Visible = true; };
                            if (col.Name == "name") { col.HeaderText = "Name"; col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; col.Visible = true; };
                            if (col.Name == "addr") { col.HeaderText = "Address"; col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; col.Visible = true; };
                            if (col.Name.Trim() == "is_active".Trim()) { col.HeaderText = "Active"; col.Width = 60; col.Visible = true; };
                        }
                        break;
                    case 2:
                        foreach (DataGridViewColumn col in dg_db.Columns)
                        {
                            if (col.Name == "selected") { col.HeaderText = ""; col.Width = 60; col.Visible = true; col.ReadOnly = false; } else { col.ReadOnly = true; col.Visible = false; };
                            if (col.Name == "mate_code") { col.HeaderText = "Code"; col.Width = 200; col.Visible = true; };
                            if (col.Name == "description") { col.HeaderText = "Description"; col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; col.Visible = true; };
                            if (col.Name.Trim() == "is_active".Trim()) { col.HeaderText = "Active"; col.Width = 60; col.Visible = true; };
                        }
                        break;
                    case 3:
                        foreach (DataGridViewColumn col in dg_db.Columns)
                        {
                            if (col.Name == "selected") { col.HeaderText = ""; col.Width = 60; col.Visible = true; col.ReadOnly = false; } else { col.ReadOnly = true; col.Visible = false; };
                            if (col.Name == "origin_code") { col.HeaderText = "Code"; col.Width = 200; col.Visible = true; };
                            if (col.Name == "origin_name") { col.HeaderText = "Name"; col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; col.Visible = true; };
                            if (col.Name.Trim() == "is_active".Trim()) { col.HeaderText = "Active"; col.Width = 60; col.Visible = true; };
                        }
                        break;
                }
            }


            ///// ADMIN
            if (main_tab.SelectedTab.Name == tab_admin.Name)
            {
                switch (tab_adm_child.SelectedIndex)
                {
                    case 0:
                        foreach (DataGridViewColumn col in dg_admn.Columns)
                        {
                            if (col.Name == "selected") { col.HeaderText = ""; col.Width = 60; col.Visible = true; col.ReadOnly = false; } else { col.ReadOnly = true; col.Visible = false; };
                            if (col.Name == "user_code") { col.HeaderText = "User Code"; col.Width = 200; col.Visible = true; };
                            if (col.Name == "full_name") { col.HeaderText = "Full name"; col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; col.Visible = true; };
                            if (col.Name == "position") { col.HeaderText = "Position"; col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; col.Visible = true; };
                            if (col.Name == "is_active".Trim()) { col.HeaderText = "Active"; col.Width = 60; col.Visible = true; };
                            if (col.Name == "contact_num") { col.HeaderText = "Contact No."; col.Width = 100; col.Visible = true; };
                        }
                        break;
                    case 1:
                        foreach (DataGridViewColumn col in dg_admn.Columns)
                        {
                            if (col.Name == "selected") { col.HeaderText = ""; col.Width = 60; col.Visible = false; col.ReadOnly = false; } else { col.ReadOnly = true; col.Visible = false; };
                            if (col.Name == "log_dt") { col.HeaderText = "Log date & Time"; col.Width = 180; col.Visible = true; };
                            if (col.Name == "log_type") { col.HeaderText = "Type"; col.Width = 150; col.Visible = true; };
                            if (col.Name == "action_desc") { col.HeaderText = "Activity"; col.Width = 150; col.Visible = true; };
                            if (col.Name == "record_no") { col.HeaderText = "Record"; col.Width = 120; col.Visible = true; };
                            if (col.Name == "details") { col.HeaderText = "Details"; col.Width = 80; col.Visible = true; };
                            if (col.Name == "comments") { col.HeaderText = "comments"; col.Width = 80; col.Visible = true; };
                            if (col.Name == "user_name".Trim()) { col.HeaderText = "User"; col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; ; col.Visible = true; };

                        }
                        break;
                }
            }
        }

        #region "pagination"

        public int pageindex { get; set; }
        public int pagesize { get; set; }
        public int pagelimit { get; set; }

        public int total_page { get; set; }

        public void set_pagination_event_handlers()
        {
            cbo_p_size.SelectedIndex = 0;
            this.cbo_p_size.SelectedIndexChanged += new System.EventHandler(this.refresh);
            this.cbo_p_size.SelectedIndexChanged -= new System.EventHandler(this.refresh);
            this.txt_srch_db.TextChanged -= new System.EventHandler(this.search);
            this.txt_srch_db.TextChanged += new System.EventHandler(this.search);
            this.btn_prev_pg.Click -= new System.EventHandler(this.prev_page);
            this.btn_prev_pg.Click += new System.EventHandler(this.prev_page);
            this.btn_next_pg.Click -= new System.EventHandler(this.next_page);
            this.btn_next_pg.Click += new System.EventHandler(this.next_page);
        }

        public void browse_page(int pg_num)
        {
            if (!is_loaded) return;
            pageindex = pg_num;
            pagesize = Convert.ToInt32(cbo_p_size.Text.Trim());

            int currentsize = (pagesize) * (pg_num - 1);
            //txt_display.Text = (currentsize + Convert.ToInt32(cbo_p_size.Text)).ToString();

            using (sys.domain.DAL.DBContext dbx = new sys.domain.DAL.DBContext(global.main_conn_str))
            {
                //////  Operations
                if (main_tab.SelectedTab.Name == tab_ops.Name)
                {
                    dg_trns.DataSource = null;
                    dg_trns.Rows.Clear();
                    dg_trns.Columns.Clear();
                    dg_trns.HorizontalScrollingOffset = 1;
                    dg_trns.Refresh();
                    txt_srch_trns.AutoCompleteCustomSource.Clear();
                    if (main_tab.SelectedTab.Name == tab_ops.Name)
                    {
                        switch (tab_ops_child.SelectedIndex)
                        {
                            case 0: if (ALLOW_W_LST == false) return; var t1 = sys.domain.procedures.list_trans(dbx, null, null).Select(sys.domain.EF_expressions.w_in_list_selector); dg_trns.DataSource = t1.ToList().ToDataTable();
                                txt_srch_trns.AutoCompleteCustomSource.AddRange(t1.Select(a => a.license_plate).ToArray()); txt_srch_trns.AutoCompleteCustomSource.AddRange(t1.Select(a => a.receipt_no).ToArray()); break;
                            case 1: if (ALLOW_MGMT_LST == false) return;
                                var t2 = sys.domain.procedures.list_trans(dbx, dt_b_fr.Value, dt_b_t.Value, cbo_fltr_hrF.Text, cbo_fltr_hrT.Text, cbo_fltr_sup.SelectedIndex != 0 ? cbo_fltr_sup.Text : null, cbo_fltr_com.SelectedIndex != 0 ? cbo_fltr_com.Text : null, cbo_fltr_orgn.SelectedIndex != 0 ? cbo_fltr_orgn.Text : null).Select(sys.domain.EF_expressions.w_out_list_selector); dg_trns.DataSource = t2.ToList().ToDataTable();
                                txt_srch_trns.AutoCompleteCustomSource.AddRange(t2.Select(a => a.license_plate).ToArray()); txt_srch_trns.AutoCompleteCustomSource.AddRange(t2.Select(a => a.receipt_no).ToArray()); 
                                lbl_total_wt.Text = dg_trns.Rows.Cast<DataGridViewRow>().Sum(a => Convert.ToDouble(a.Cells["net_wt"].Value)).ToString("#,##0 Kg.");
                                break;

                        }

                    }
                    txt_display.Text = dg_trns.Rows.Count == 0 ? "--" : dg_trns.Rows.Count.ToString();
                    lbl_db_src.Text = dg_trns.Rows.Count == 0 ? "--" : dg_trns.Rows.Count.ToString();

                }

                //////  Database
                if (main_tab.SelectedTab.Name == tab_dbs.Name)
                {
                    dg_db.DataSource = null;
                    dg_db.Rows.Clear();
                    dg_db.Columns.Clear();
                    if (ALLOW_DB_LST == false) return;
                    switch (cbo_tbl.SelectedIndex)
                    {
                        case 1:
                            var clnts = sys.domain.procedures.lst_clnts(dbx, null).Select(sys.domain.EF_expressions.clnt_lst_selector).ToList();
                            dg_db.DataSource = clnts.ToList().ToDataTable();
                            txt_srch_db.AutoCompleteCustomSource.Clear(); txt_srch_db.AutoCompleteCustomSource.AddRange(clnts.Select(a => a.name).ToArray());
                            total_page = dg_db.Rows.Count;
                            break;
                        case 2:
                            var rmats = sys.domain.procedures.lst_mats(dbx, null).Select(sys.domain.EF_expressions.mats_lst_selector).ToList();
                            dg_db.DataSource = rmats.ToList().ToDataTable();
                            txt_srch_db.AutoCompleteCustomSource.Clear(); txt_srch_db.AutoCompleteCustomSource.AddRange(rmats.Select(a => a.description).ToArray());
                            total_page = dg_db.Rows.Count;
                            break;
                        case 3:
                            var orgs = sys.domain.procedures.lst_orgs(dbx, null).Select(sys.domain.EF_expressions.orgn_lst_selector).ToList();
                            dg_db.DataSource = orgs.ToList().ToDataTable();
                            txt_srch_db.AutoCompleteCustomSource.Clear(); txt_srch_db.AutoCompleteCustomSource.AddRange(orgs.Select(a => a.origin_name).ToArray());
                            total_page = dg_db.Rows.Count;
                            break;
                    }
                    txt_display.Text = dg_db.Rows.Count == 0 ? "--" : dg_db.Rows.Count.ToString();
                    lbl_db_src.Text = dg_db.Rows.Count == 0 ? "--" : dg_db.Rows.Count.ToString();
                }

                ///// ADMIN
                if (main_tab.SelectedTab.Name == tab_admin.Name)
                {

                    switch (tab_adm_child.SelectedIndex)
                    {
                        case 0:
                            if (ALLOW_USR_LST == false) return;
                            var v = sys.domain.procedures.lst_usrs(dbx, null).Select(sys.domain.EF_expressions.usr_lst_selector).ToList();
                            dg_admn.DataSource = v.ToDataTable();
                            //txt_srch_db.AutoCompleteCustomSource.Clear(); txt_srch_db.AutoCompleteCustomSource.AddRange(v.Select(a => a.full_name).ToArray());
                            total_page = v.Count();
                            break;
                        case 1:
                            if (ALLOW_USR_LST == false) return;
                            var v2 = sys.domain.procedures.lst_logs(dbx, dt_adm_fr.Value, dt_adm_to.Value, cbo_adm_hr_fr.Text, cbo_adm_hr_to.Text, cbo_action.Text, cbo_adm_type.SelectedIndex == 0 ? null : cbo_adm_type.Text, txt_adm_uname.Text).Select(sys.domain.EF_expressions.log_lst_selector).ToList();
                            dg_admn.DataSource = v2.ToDataTable();
                            total_page = v2.Count();
                            break;
                    }

                    txt_display.Text = dg_admn.Rows.Count == 0 ? "--" : dg_admn.Rows.Count.ToString();
                    lbl_db_src.Text = dg_admn.Rows.Count == 0 ? "--" : dg_admn.Rows.Count.ToString();
                }
            }

            set_dg();
            dg_CellClick(null, null);
        
        }

        public void next_page(object sender, EventArgs e)
        {
            pageindex = pageindex == pagelimit ? pagelimit : pageindex + 1;
            browse_page(pageindex);
        }

        public void prev_page(object sender, EventArgs e)
        {
            pageindex = pageindex == 1 ? 1 : pageindex - 1;
            browse_page(pageindex);
        }

        #endregion

        public void proceed(object sender, EventArgs e)
        {
            try
            {
                using (sys.domain.DAL.DBContext dbx = new sys.domain.DAL.DBContext(global.main_conn_str))
                {
                    dbx.current_user = global.logged_in_user;
                    MetroFramework.Controls.MetroButton ctrl = (MetroFramework.Controls.MetroButton)sender;

                    if (main_tab.SelectedTab.Name == tab_ops.Name)
                    {
                        if (ctrl.Text == btn_w_in.Text || ctrl.Text == btn_w_out.Text)
                        {
                            bool is_new = ctrl.Name == btn_w_out.Name ? false : true;
                            if (!is_new) { if (dg_trns.Rows.Count == 0) return; if (dg_trns.CurrentRow == null) return; }
                            mfr_trans mfrc = new mfr_trans();
                            mfrc.s_id = !is_new ? Convert.ToInt64(dg_trns.CurrentRow.Cells["transaction_id"].Value) : 0;
                            mfrc.is_New = is_new;
                            mfrc.is_loaded = true;
                            mfrc.owner = this;
                            mfrc.load(null, null);
                            mfrc.StartPosition = FormStartPosition.CenterScreen;
                            if (mfrc.ShowDialog(this) == DialogResult.OK)
                            gen_method.clear_mem(new object[] { mfrc });
                            { browse_page(pageindex); };
                           
                           
                        }

                        if (ctrl.Text == btn_w_del.Text || ctrl.Text == btn_t_del.Name)
                        {
                            List<System.Windows.Forms.DataGridViewRow> drw = new List<System.Windows.Forms.DataGridViewRow>();
                            drw = (List<System.Windows.Forms.DataGridViewRow>)dg_trns.Rows.Cast<System.Windows.Forms.DataGridViewRow>()
                            .Where(r => (bool)r.Cells["selected"].Value == true).ToList();

                            if (drw.Count == 0) return;

                            var usr = global.logged_in_user;
                            var p = usr.permissions.Where(a => a.role.description == sys.domain.Enums.roles.MANAGEMENT.ToString()).FirstOrDefault();
                            if (p.permission == 0 || p.permission == 1)
                            {
                                MetroMessageBox.Show(this, "Unable to delete. please contact your administrator.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }

                            System.Nullable<Int64>[] ids = sys.domain.procedures.del_dg_row(ref dg_trns, "transaction_id"); if (ids == null) return;
                            var ts = dbx.Transactions.Where(a => ids.Contains(a.transaction_id));

                            foreach (var t in ts) { dbx.Entry(t).State = EntityState.Deleted; dbx.Transactions.Remove(t); dbx.current_user = global.logged_in_user; dbx.Configuration.ValidateOnSaveEnabled = true; }; dbx.SaveChanges();
                            list(null, null); browse_page(pageindex);
                            MetroMessageBox.Show(this, "Deleting complete", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        if (ctrl.Name == btn_t_mod.Name)
                        {
                            if (dg_trns.Rows.Count == 0) return;
                            if (dg_trns.CurrentRow == null) return;

                            var usr = global.logged_in_user;
                            var p = usr.permissions.Where(a => a.role.description == sys.domain.Enums.roles.WEIGHING.ToString()).FirstOrDefault();
                            if (p.permission == 0 || p.permission == 1)
                            {
                                MetroMessageBox.Show(this, "Unable to open. please contact your administrator.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }

                            mfr_vtrans mfrc = new mfr_vtrans();
                            mfrc.s_id = Convert.ToInt64(dg_trns.CurrentRow.Cells["transaction_id"].Value);
                            mfrc.is_New = false;
                            mfrc.is_loaded = true;
                            mfrc.owner = this;
                            mfrc.load(null, null);
                            mfrc.StartPosition = FormStartPosition.CenterScreen;
                            if (mfrc.ShowDialog(this) == DialogResult.OK)
                            gen_method.clear_mem(new object[] { mfrc });
                            { browse_page(pageindex); };
                        }

                        if (ctrl.Name == btn_t_prnt.Name)
                        {
                            if (dg_trns.Rows.Count == 0) return;
                            if (dg_trns.CurrentRow == null) return;

                            sys.domain.Validation.TransactionValidation.TICKET_STATE ticket_state = sys.domain.Validation.TransactionValidation.TICKET_STATE.WEIGH_IN;

                            if (MetroMessageBox.Show(this, "Do you want to proceed reprinting of ticket?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                            long transaction_id = Convert.ToInt64(dg_trns.CurrentRow.Cells["transaction_id"].Value.ToString());

                            var t = dbx.Transactions.Where(a => a.transaction_id == transaction_id).FirstOrDefault();
                            //sys.domain.Validation.TransactionValidation.TICKET_STATE state=sys.domain.Validation.TransactionValidation.TICKET_STATE.WEIGH_IN;

                            if (t.dt_out == null) ticket_state = sys.domain.Validation.TransactionValidation.TICKET_STATE.WEIGH_IN;
                            if (t.dt_out != null)
                            {
                                mfr_rprnt_tkt mfrrt = new mfr_rprnt_tkt();
                                if (mfrrt.ShowDialog() == System.Windows.Forms.DialogResult.Cancel) return;
                                ticket_state = mfrrt.ticket_state;
                            }

                            sys.domain.ReportsClass.print_ticket(transaction_id, global.main_conn_str, ticket_state);

                           t.REPRINT = true; dbx.Entry(t).State = EntityState.Modified; dbx.SaveChanges();
                        }

                        if (ctrl.Name == btn_xp.Name)
                        {
                            if (MetroMessageBox.Show(this, "Do you want to proceed exporting ticket to PDF?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                            long transaction_id = Convert.ToInt64(dg_trns.CurrentRow.Cells["transaction_id"].Value.ToString());

                            var t = dbx.Transactions.Where(a => a.transaction_id == transaction_id).FirstOrDefault();

                            sys.domain.ReportsClass.export_to_pdf(t.transaction_id.Value, global.main_conn_str, sys.domain.Validation.TransactionValidation.TICKET_STATE.WEIGH_OUT);
                            gen_method.clear_mem(new object[] { t });
                            MetroMessageBox.Show(this,"Exporting comlete", "", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                        }
                    }

                    if (main_tab.SelectedTab.Name == tab_dbs.Name)
                    {
                        if (cbo_tbl.SelectedIndex == 0)
                        { MetroFramework.MetroMessageBox.Show(this, "Please select a table to proceed.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; };

                        if (ctrl.Text == btn_dbs_n.Text || ctrl.Text == btn_dbs_e.Text)
                        {
                            if (ctrl.Text == btn_dbs_e.Text)
                            {
                                if (dg_db.Rows.Count == 0) return;
                                if (dg_db.CurrentRow == null) return;
                            };

                            switch (cbo_tbl.SelectedIndex)
                            {
                                case 0: break;
                                case 1:
                                    mfr_clnts mfrc = new mfr_clnts();
                                    mfrc.is_loaded = true; mfrc.is_New = ctrl.Name == btn_dbs_n.Name ? true : false; mfrc.owner = this;
                                    mfrc.s_id = ctrl.Name == btn_dbs_n.Name ? 0 : (long)dg_db.CurrentRow.Cells["id"].Value;
                                    if (mfrc.ShowDialog(this) == DialogResult.OK) { browse_page(pageindex); }; break;
                                case 2:
                                    mfr_mate mfrm = new mfr_mate();
                                    mfrm.is_loaded = true; mfrm.is_New = ctrl.Name == btn_dbs_n.Name ? true : false; mfrm.owner = this;
                                    mfrm.s_id = ctrl.Name == btn_dbs_n.Name ? 0 : (long)dg_db.CurrentRow.Cells["id"].Value;
                                    if (mfrm.ShowDialog(this) == DialogResult.OK) { browse_page(pageindex); }; break;
                                case 3:
                                    mfr_org mfro = new mfr_org();
                                    mfro.is_loaded = true; mfro.is_New = ctrl.Name == btn_dbs_n.Name ? true : false; mfro.owner = this;
                                    mfro.s_id = ctrl.Name == btn_dbs_n.Name ? 0 : (long)dg_db.CurrentRow.Cells["id"].Value;
                                    if (mfro.ShowDialog(this) == DialogResult.OK) { browse_page(pageindex); }; break;
                            }
                        }

                        if (ctrl.Text == btn_dbs_del.Text)
                        {
                            System.Nullable<Int64>[] ids = sys.domain.procedures.del_dg_row(ref dg_db, "id");

                            if (ids == null) return;

                            switch (cbo_tbl.SelectedIndex)
                            {
                                case 0: break;
                                case 1: dbx.Clients.RemoveRange(dbx.Clients.Where(a => ids.Contains(a.client_id))); break;
                                case 2: dbx.Raw_materials.RemoveRange(dbx.Raw_materials.Where(a => ids.Contains(a.material_id))); break;
                                case 3: dbx.Origins.RemoveRange(dbx.Origins.Where(a => ids.Contains(a.origin_id))); break;
                            }
                            dbx.SaveChanges();

                            list(null, null);
                            browse_page(pageindex);
                            MetroMessageBox.Show(this, "Deleting complete", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    #region "ADM"
                    if (main_tab.SelectedTab.Name == tab_admin.Name)
                    {

                        if (ctrl.Name == btn_usr_n.Name || ctrl.Name == btn_usr_e.Name)
                        {
                            if (ctrl.Name == btn_usr_e.Name)
                            {
                                if (dg_admn.Rows.Count == 0) return;
                                if (dg_admn.CurrentRow == null) return;
                            };

                            mfr_usrs mfr = new mfr_usrs();
                            mfr.is_loaded = true; mfr.is_New = ctrl.Name == btn_usr_n.Name ? true : false; mfr.owner = this;
                            mfr.s_id = ctrl.Name == mfr.Name ? 0 : (long)dg_admn.CurrentRow.Cells["id"].Value;
                            if (mfr.ShowDialog(this) == DialogResult.OK) { browse_page(pageindex); };
                        }

                        if (ctrl.Name == btn_usr_d.Name)
                        {
                            System.Nullable<Int64>[] ids = sys.domain.procedures.del_dg_row(ref dg_admn, "id");

                            if (ids == null) return;
                            dbx.Users.RemoveRange(dbx.Users.Where(a => ids.Contains(a.user_id)));
                            dbx.SaveChanges();

                            list(null, null);
                            browse_page(pageindex);
                            MetroMessageBox.Show(this, "Deleting complete", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    #endregion
                }
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder vERR = new StringBuilder();
                foreach (var validationResults in ex.EntityValidationErrors)
                {
                    foreach (var error in validationResults.ValidationErrors)
                    {
                        vERR.AppendLine(error.ErrorMessage);
                    }
                }
                System.Text.RegularExpressions.Regex mtch = new System.Text.RegularExpressions.Regex(Environment.NewLine); int msgbox_h = mtch.Matches(vERR.ToString()).Count * 35; msgbox_h = msgbox_h <= 160 ? 160 : msgbox_h;
                MetroMessageBox.Show(this, vERR.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Stop, msgbox_h); return;
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        public void refresh(object sender, EventArgs e)
        {
            list(null, null);
            browse_page(1);
        }

        public void search(object sender, EventArgs e)
        {
            MetroFramework.Controls.MetroGrid dg = new MetroFramework.Controls.MetroGrid();

            if (main_tab.SelectedTab.Name == tab_ops.Name)
            {

                gen_method.srch_db(ref dg_trns, txt_srch_trns.Text.Trim(), "license_plate", "receipt_no");


            }
            if (main_tab.SelectedTab.Name == tab_dbs.Name)
            {

            }
            if (main_tab.SelectedTab.Name == tab_admin.Name)
            {

            }
        }

        private void btn_w_in_Click(object sender, EventArgs e)
        {

        }

        #region "Database"

        private void cbo_tbl_SelectedIndexChanged(object sender, EventArgs e)
        {
            list(null, null);
            browse_page(1);
        }

        private void txt_db_srch_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region "Operation"
        private void tab_trans_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (tab_ops_child.SelectedIndex == 0)
            {
                Transitions.Transition t = new Transitions.Transition(new Transitions.TransitionType_EaseInEaseOut(500));
                t.add(pnl_adv_fltr, "Left", this.Width);
                t.run();
                btn_show_adv_fltr.Text = "Show advance filter";
            }

            if (tab_ops_child.SelectedIndex == 1)
            {
              
            }

            list(null, null);
            browse_page(pageindex);
        }

        void btn_show_adv_fltr_Click(object sender, EventArgs e)
        {
            if (main_tab.SelectedTab.Name == tab_ops.Name)
            {
                Transitions.Transition t = new Transitions.Transition(new Transitions.TransitionType_EaseInEaseOut(500));
                if (pnl_adv_fltr.Left == this.Width)
                {
                    t.add(pnl_adv_fltr, "Left", this.Width - pnl_adv_fltr.Width - 20 - 30);
                    btn_show_adv_fltr.Text = "Hide advance filter";
                }
                else
                {
                    t.add(pnl_adv_fltr, "Left", this.Width);
                    btn_show_adv_fltr.Text = "Show advance filter";
                }
                t.run();
            }

        }

        #endregion

        #region"Login"
        private void btn_con_Click(object sender, EventArgs e)
        {
            if (pnl_con.Height == 0)
            {
                Transitions.Transition.run(pnl_con, "Height", 197, new Transitions.TransitionType_EaseInEaseOut(500));
            }
            else
            {
                Transitions.Transition.run(pnl_con, "Height", 0, new Transitions.TransitionType_EaseInEaseOut(500));
            }
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor; lbl_lgn_msg.Text = "";
            //MessageBox.Show(global.main_conn_str.connection);
            using (sys.domain.DAL.DBContext dbx = new sys.domain.DAL.DBContext(global.main_conn_str))
            {
                try
                {
                    string encrypted_pwd = global.crypter.EncryptData(txt_pwd.Text.Trim());
                    var usrs = dbx.Users.Where(a => a.login_id == txt_uid.Text.Trim() && a.login_pwd == encrypted_pwd).FirstOrDefault();

                    global.logged_in_user = usrs; if (global.logged_in_user == null) { lbl_lgn_msg.Text = "Login failed. "; return; }
                    global.logged_in_user.VALIDATE = false; global.logged_in_user.LOGGED_IN = true; global.logged_in_user.VALIDATE = false; dbx.Entry(global.logged_in_user).State = EntityState.Modified; dbx.current_user = global.logged_in_user; dbx.SaveChanges();
                    //global.station = db.Stations.Where(a => a.is_selected == true).FirstOrDefault();

                    btn_sttngs.Enabled = true;
                    init_ops();
                    init_dbs();
                    init_adm();
                    init_rpts();
                    is_loaded = true;
                    set_usr_acs(global.logged_in_user);
                    main_tab.SelectedTab = tab_ops;
                    main_tab_SelectedIndexChanged(null, null);
                    tab_ops_child.SelectedIndex = 0;

                }
                catch (DbEntityValidationException ex)
                {
                    StringBuilder vERR = new StringBuilder();
                    foreach (var validationResults in ex.EntityValidationErrors)
                    {
                        foreach (var error in validationResults.ValidationErrors)
                        {
                            vERR.AppendLine(error.ErrorMessage);
                        }
                    }
                    System.Text.RegularExpressions.Regex mtch = new System.Text.RegularExpressions.Regex(Environment.NewLine); int msgbox_h = mtch.Matches(vERR.ToString()).Count * 35; msgbox_h = msgbox_h <= 160 ? 160 : msgbox_h;
                    Clipboard.SetText(vERR.ToString());
                    lbl_lgn_msg.Text = vERR.ToString();
                    return;
                }
                catch (Exception ex)
                {
                    lbl_lgn_msg.Text = ex.Message;
                    return;
                }

                //upd_company_users();

                Transition t = new Transition(new TransitionType_EaseInEaseOut(1000));
                t.add(pnl_login, "Left", 0 - pnl_login.Width);
                t.run();
                t.TransitionCompletedEvent += t_TransitionCompletedEvent;
            }
        }

        void t_TransitionCompletedEvent(object sender, Transition.Args e)
        {
            txt_pwd.Text = "";
            pnl_login.Visible = false;
            pnl_usr.Visible = true;
            lbl_user.Text = global.logged_in_user.full_name;
            main_tab.Enabled = true;
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            lbl_user.Text = "";
            pnl_login.Visible = true;
            pnl_usr.Visible = false;
         
            using (sys.domain.DAL.DBContext dbx = new sys.domain.DAL.DBContext(global.main_conn_str))
            {
                global.logged_in_user.LOGGED_OUT = true;
                global.logged_in_user.VALIDATE = false;
                dbx.Entry(global.logged_in_user).State = EntityState.Modified;
                dbx.current_user = global.logged_in_user;
                dbx.SaveChanges();
                global.logged_in_user = null;

            }
            main_tab.Enabled = false;
            Transition t = new Transition(new TransitionType_EaseInEaseOut(1000));
            t.add(pnl_login, "Left", main_tab.Left);
            t.run();
        }

        #endregion

        private void btn_gen_adv_Click(object sender, EventArgs e)
        {
            if (main_tab.SelectedTab.Name == tab_rpts.Name)
            {
                using (sys.domain.DAL.DBContext dbx = new sys.domain.DAL.DBContext(global.main_conn_str))
                {
                    if (cbo_rpt_type.SelectedIndex == 1)
                    {
                        sys.domain.ReportsClass.print_gen(
                        sys.domain.procedures.list_trans(dbx,
                        dt_b_fr.Value,
                        dt_b_t.Value, 
                        cbo_fltr_hrF.Text, 
                        cbo_fltr_hrT.Text,
                        cbo_fltr_sup.SelectedIndex != 0 ? cbo_fltr_sup.Text : null, 
                        cbo_fltr_com.SelectedIndex != 0 ? cbo_fltr_com.Text : null, 
                        cbo_fltr_orgn.SelectedIndex != 0 ? cbo_fltr_orgn.Text : null)
                        .OrderBy(a => a.transaction_id).ToTraceQuery(),
                        global.main_conn_str,ref CrViewer);
                    }
                    if (cbo_rpt_type.SelectedIndex == 2)
                    {
                        sys.domain.ReportsClass.print_tracker(
                            sys.domain.procedures.list_trans(dbx,
                            dt_b_fr.Value,
                            dt_b_t.Value,
                            cbo_fltr_hrF.Text,
                            cbo_fltr_hrT.Text,
                            cbo_fltr_sup.SelectedIndex != 0 ? cbo_fltr_sup.Text : null,
                            cbo_fltr_com.SelectedIndex != 0 ? cbo_fltr_com.Text : null,
                            cbo_fltr_orgn.SelectedIndex != 0 ? cbo_fltr_orgn.Text : null,null,true)
                            .OrderBy(a => a.transaction_id).ToTraceQuery(),
                            global.main_conn_str, ref CrViewer);
                    }

                }
            }
        }

        private async void btn_excel_export_Click(object sender, EventArgs e)
        {
            if (CrViewer.ReportSource == null) return;

            List<sys.domain.trns.Transactions> ts = new List<sys.domain.trns.Transactions>();
            using (sys.domain.DAL.DBContext dbx = new sys.domain.DAL.DBContext(global.main_conn_str))
            {
                ts = sys.domain.procedures.list_trans(dbx, dt_b_fr.Value, dt_b_t.Value, cbo_fltr_hrF.Text, cbo_fltr_hrT.Text, cbo_fltr_sup.SelectedIndex != 0 ? cbo_fltr_sup.Text : null, cbo_fltr_com.SelectedIndex != 0 ? cbo_fltr_com.Text : null, cbo_fltr_orgn.SelectedIndex != 0 ? cbo_fltr_orgn.Text : null).OrderBy(a => a.transaction_id).ToList();
            }

            if (cbo_rpt_type.SelectedIndex == 1)
            {
                 if (MetroMessageBox.Show(this, "Do you want to proceed reprinting of ticket?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                 Cursor.Current = Cursors.WaitCursor;
                
                ExcelExport.ExportExcel xls = new ExcelExport.ExportExcel();
                xls.excel_file_path = System.Windows.Forms.Application.StartupPath + "\\ExcelFile\\" + "master_sheet.xlsx";
                xls.transaction_records = ts;
                await xls.update_master_sheet();

               MetroMessageBox.Show(this,  "Export Complete.", "", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }

            if (cbo_rpt_type.SelectedIndex == 2)
            {
                if (MetroMessageBox.Show(this, "Do you want to proceed reprinting of ticket?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
               Cursor.Current = Cursors.WaitCursor;
                ExcelExport.ExportExcel xls = new ExcelExport.ExportExcel();
                xls.excel_file_path = System.Windows.Forms.Application.StartupPath + "\\ExcelFile\\" + "Delivery_tracker.xlsx";
                xls.transaction_records = ts;
                await xls.update_excel_delivery_tracker();

                MetroMessageBox.Show(this, "Export Complete.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ALLOW_DB_LST;
        private bool ALLOW_W_LST;
        private bool ALLOW_MGMT_LST;
        private bool ALLOW_USR_LST;
        private void set_usr_acs(sys.domain.adm.Users usr)
        {
            if (usr == null) return;

            ALLOW_W_LST = false; btn_w_in.Enabled = false; btn_w_out.Enabled = false; btn_w_del.Enabled = false;
            ALLOW_MGMT_LST = false; btn_t_mod.Enabled = false; btn_t_prnt.Enabled = false; btn_t_del.Enabled = false;
            ALLOW_DB_LST = false; btn_dbs_n.Enabled = false; btn_dbs_e.Enabled = false; btn_dbs_del.Enabled = false;
            ALLOW_USR_LST = false; btn_usr_n.Enabled = false; btn_usr_e.Enabled = false; btn_usr_d.Enabled = false;
            btn_sttngs.Enabled = false;

            var p = usr.permissions.Where(a => a.role.description == sys.domain.Enums.roles.WEIGHING.ToString()).FirstOrDefault();
            if (p != null)
            {
                ALLOW_W_LST = p.permission == 2 ? true : p.permission == 1 ? true : false;
                btn_w_in.Enabled = p.permission == 2 ? true : false;
                btn_w_out.Enabled = p.permission == 2 ? true : false;
                btn_w_del.Enabled = p.permission == 2 ? true : false;
            }
            p = usr.permissions.Where(a => a.role.description == sys.domain.Enums.roles.MANAGEMENT.ToString()).FirstOrDefault();
            if (p != null)
            {
                ALLOW_MGMT_LST = p.permission == 2 ? true : p.permission == 1 ? true : false;
                btn_t_mod.Enabled = p.permission == 2 ? true : p.permission == 1 ? true : false;
                btn_t_prnt.Enabled = p.permission == 2 ? true : p.permission == 1 ? true : false;
                btn_t_del.Enabled = p.permission == 2 ? true : p.permission == 1 ? true : false;
                btn_show_adv_fltr.Enabled = p.permission == 2 ? true : p.permission == 1 ? true : false;
            }

            p = usr.permissions.Where(a => a.role.description == sys.domain.Enums.roles.DATABASE.ToString()).FirstOrDefault();
            if (p != null)
            {
                ALLOW_DB_LST = p.permission == 2 ? true : p.permission == 1 ? true : false;
                btn_dbs_n.Enabled = p.permission == 2 ? true : false;
                btn_dbs_e.Enabled = p.permission == 2 ? true : false;
                btn_dbs_del.Enabled = p.permission == 2 ? true : false;
                cbo_tbl.Enabled = p.permission == 2 ? true : false;
            }
            p = usr.permissions.Where(a => a.role.description == sys.domain.Enums.roles.SECURITIES.ToString()).FirstOrDefault();
            if (p != null)
            {
                ALLOW_USR_LST = p.permission == 2 ? true : p.permission == 1 ? true : false;
                btn_usr_n.Enabled = p.permission == 2 ? true : false;
                btn_usr_e.Enabled = p.permission == 2 ? true : false;
                btn_usr_d.Enabled = p.permission == 2 ? true : false;
            }
            p = usr.permissions.Where(a => a.role.description == sys.domain.Enums.roles.SETTINGS.ToString()).FirstOrDefault();
            if (p != null) { btn_sttngs.Enabled = p.permission == 2 ? true : false; }
            p = usr.permissions.Where(a => a.role.description == sys.domain.Enums.roles.REPORTING.ToString()).FirstOrDefault();
            if (p != null) { pnl_adv_fltr_container.Enabled = p.permission != 1 ? false : true; }
        }

        public void key_down(object sender, KeyEventArgs e)
        {
            global.select_next_control(this, e);
        }

        private void main_tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            switch (main_tab.SelectedIndex)
            {
                case 0:
                    //try
                    //{
                    //    if (!sys.domain.Classes.access_verification.verify(global.logged_in_user, sys.domain.Enums.roles.WEIGHING)) return;
                    //}
                    //catch (Exception ex)
                    //{
                    //    tab_ops_child.DisableTab(tab_trns_pending);

                    //    if (is_loaded) MetroMessageBox.Show(this, ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Stop); return;
                    //}
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }

        private void btn_sttngs_Click(object sender, EventArgs e)
        {
            mfr_sttngs mfr = new mfr_sttngs();
            mfr.owner = this;
            mfr.ShowDialog();
        }

        private void tab_adm_child_SelectedIndexChanged(object sender, EventArgs e)
        {
            Transitions.Transition t = new Transitions.Transition(new Transitions.TransitionType_EaseInEaseOut(500));
            if (tab_adm_child.SelectedTab.Name == pg_adm_accnts.Name)
            {
                t.add(pnl_adm_log_details, "Width", 0);
            }

            if (tab_adm_child.SelectedTab.Name == pg_adm_logs.Name)
            {
                t.add(pnl_adm_log_details, "Width", 300);
            }
            t.run();
        }

        private void dg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MetroFramework.Controls.MetroGrid dg = new MetroFramework.Controls.MetroGrid();

            if (main_tab.SelectedTab.Name == tab_ops.Name) dg = dg_trns;
            if (main_tab.SelectedTab.Name == tab_dbs.Name) dg = dg_db;
            if (main_tab.SelectedTab.Name == tab_admin.Name) dg = dg_admn;

            lbl_db_sr.Text = dg_admn.Rows.Count == 0 ? "--" : "1";
            if (dg.Rows.Count == 0) return; if (dg.CurrentRow == null) return;
            lbl_db_sr.Text = (dg.CurrentRow.Index + 1).ToString();

            if (dg.Name == dg_admn.Name)
            {
                if (tab_adm_child.SelectedTab.Name ==pg_adm_logs.Name)
                {
                    txt_log_details.Text = dg.CurrentRow.Cells["details"].Value.ToString();
                    txt_log_comments.Text = dg.CurrentRow.Cells["comments"].Value.ToString();
                }
              
            }
        }

        private void dg_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MetroFramework.Controls.MetroGrid dg = new MetroFramework.Controls.MetroGrid();

            if (main_tab.SelectedTab.Name == tab_ops.Name) dg = dg_trns;
            if (main_tab.SelectedTab.Name == tab_dbs.Name) dg = dg_db;
            if (main_tab.SelectedTab.Name == tab_admin.Name) dg = dg_admn;

            if (dg.Name == dg_trns.Name)
            {
                if (dg.Rows.Count == 0) return; if (dg.CurrentRow == null) return;
                proceed(tab_ops_child.SelectedIndex == 0 ? btn_w_out : btn_t_mod, null);
            }

            if (dg.Name == dg_db.Name)
            {
                if (dg.Rows.Count == 0) return; if (dg.CurrentRow == null) return;
                proceed(btn_dbs_e, null);
            }

            if (dg.Name == dg_admn.Name)
            {
                if (tab_adm_child.SelectedTab.Name == pg_adm_accnts.Name)
                {
                    if (dg.Rows.Count == 0) return; if (dg.CurrentRow == null) return;
                    proceed(btn_usr_e, null);
                }
            }
        }

        private void txt_uid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt == true) return;
            if (e.Control == true) return;
            if (e.Shift == true) return;

            if (e.KeyCode == Keys.Enter)
            {
                txt_pwd.Focus();
            }
        }

        private void txt_pwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt == true) return;
            if (e.Control == true) return;
            if (e.Shift == true) return;

            if (e.KeyCode == Keys.Enter)
            {
                btn_submit_Click(null, null);
            }
        }

        private void btn_adm_lg_refresh_Click(object sender, EventArgs e)
        {

        }

        private void btn_svr_apply_Click(object sender, EventArgs e)
        {
            global.settings.INI_SERVERNAME = txt_svr_nme.Text;
            global.settings.INI_SQLUID = txt_svr_id.Text;
            global.settings.INI_SQLPWD = txt_svr_pwd.Text;
            global.settings._iniS();
        }

        private void mfr_mn2_Load(object sender, EventArgs e)
        {

        }

        private void btn_t_prnt_Click(object sender, EventArgs e)
        {

        }

 
     
    }

    public static class Iext
    {
        public static string ToTraceQuery<T>(this IQueryable<T> query)
        {
            ObjectQuery<T> objectQuery = GetQueryFromQueryable(query);

            var result = objectQuery.ToTraceString();
            foreach (var parameter in objectQuery.Parameters)
            {
                var name = "@" + parameter.Name;
                var value = "'" + parameter.Value.ToString() + "'";
                result = result.Replace(name, value);
            }

            return result;
        }

        private static System.Data.Entity.Core.Objects.ObjectQuery<T> GetQueryFromQueryable<T>(IQueryable<T> query)
        {
            var internalQueryField = query.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).Where(f => f.Name.Equals("_internalQuery")).FirstOrDefault();
            var internalQuery = internalQueryField.GetValue(query);
            var objectQueryField = internalQuery.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).Where(f => f.Name.Equals("_objectQuery")).FirstOrDefault();
            return objectQueryField.GetValue(internalQuery) as System.Data.Entity.Core.Objects.ObjectQuery<T>;
        }

        public static string ToTraceString<T>(this IQueryable<T> query)
        {
            ObjectQuery<T> objectQuery = GetQueryFromQueryable(query);

            var traceString = new StringBuilder();

            traceString.AppendLine(objectQuery.ToTraceString());
            traceString.AppendLine();

            foreach (var parameter in objectQuery.Parameters)
            {
                traceString.AppendLine(parameter.Name + " [" + parameter.ParameterType.FullName + "] = " + parameter.Value);
            }

            return traceString.ToString();
        }
    }
}
