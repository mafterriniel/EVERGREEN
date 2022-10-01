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
using System.Data.Entity.Validation;
using System.Data.Entity;
namespace Weighing_System_v._1c._0
{
    public partial class mfr_vtrans : MetroForm, IClass.IForm, IClass.IDb_m
    {

        public mfr_vtrans()
        {
            InitializeComponent();

            //cbo_type.Items.Clear(); cbo_type.Items.Add("-- Select Transaction Type --"); cbo_type.SelectedIndex = 0; cbo_type.Items.AddRange(new string[] { "Delivery - In", "Delivery - Out", "Finished Product", "Transfer" });
            //cbo_cat.Items.Clear(); cbo_cat.Items.Add("-- Select Category -- "); cbo_cat.Items.AddRange(db.Categories.Where(a => a.is_active == true).Select(a => a.name).ToArray());

            //cbo_type.SelectedIndex = 0;
            //cbo_cat.SelectedIndex = 0;

            txt_gr.Output = "0";
            txt_tr.Output = "0";
            lbl_dt_gr.Text = "";
            lbl_dt_tr.Text = "";
            lbl_w_in.Text = "";
            lbl_w_out.Text = "";
            lbl_stn_name.Text = "";
            dt_reg_dt.CustomFormat = "MMM-dd-yyyy"; dt_reg_dt.Format = DateTimePickerFormat.Custom;
            for (int i = 0; i <= 23; i++) { cbo_reg_h.Items.Add(String.Format("{0:00}", i)); }
            for (int i = 0; i <= 59; i++) { cbo_reg_m.Items.Add(String.Format("{0:00}", i)); }
            cbo_reg_h.SelectedIndex = DateTime.Now.Hour;
            cbo_reg_m.SelectedIndex = DateTime.Now.Minute;
            dt_reg_dt.ValueChanged += new EventHandler(this.compute_time);
            cbo_reg_h.SelectedIndexChanged += new EventHandler(this.compute_time);
            cbo_reg_m.SelectedIndexChanged += new EventHandler(this.compute_time);
            //this.Load += new EventHandler(this.load);
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
            this.btn_save.Click -= new System.EventHandler(this.save);
            this.btn_save.Click += new System.EventHandler(this.save);
            this.btn_cancel.Click -= new System.EventHandler(this.cancel);
            this.btn_cancel.Click += new System.EventHandler(this.cancel);
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

        public void load(object sender, EventArgs e)
        {
            using (sys.domain.DAL.DBContext dbx = new sys.domain.DAL.DBContext(global.main_conn_str))
            {
                cbo_clnt.Items.Clear(); cbo_clnt.Items.Add("-- Select client -- "); cbo_clnt.Items.AddRange(dbx.Clients.Where(a => a.is_active == true).Select(a => a.name).ToArray()); //cbo_clnt.Items.Add("-- Add new -- ");
                cbo_mate.Items.Clear(); cbo_mate.Items.Add("-- Select commodity --"); cbo_mate.Items.AddRange(dbx.Raw_materials.Where(a => a.is_active == true).Select(a => a.description).ToArray()); //cbo_mate.Items.Add("-- Add new -- ");
                cbo_origin.Items.Clear(); cbo_origin.Items.Add("-- Select origin --"); cbo_origin.Items.AddRange(dbx.Origins.Where(a => a.is_active == true).Select(a => a.origin_name).ToArray()); //cbo_origin.Items.Add("-- Add new -- ");
                txt_driver.AutoCompleteMode = AutoCompleteMode.SuggestAppend; txt_driver.AutoCompleteCustomSource.Clear(); txt_driver.AutoCompleteSource = AutoCompleteSource.CustomSource; txt_driver.AutoCompleteCustomSource.AddRange(dbx.Drivers.Select(a => a.driver_name).ToArray());
                txt_checker.AutoCompleteMode = AutoCompleteMode.SuggestAppend; txt_checker.AutoCompleteCustomSource.Clear(); txt_checker.AutoCompleteSource = AutoCompleteSource.CustomSource; txt_checker.AutoCompleteCustomSource.AddRange(dbx.Checkers.Select(a => a.checker_name).ToArray());

                cbo_clnt.SelectedIndex = 0;
                cbo_mate.SelectedIndex = 0;
                cbo_origin.SelectedIndex = 0;
                set_handlers();
            }
            if (!_is_loaded) return;
            //lbl_stn_name.Text = global.station != null ? global.station.station_name : "N/A";
            txt_in_time.Text = "--:--";
            txt_out_time.Text = "--:--";
            if (is_New)
            {
                lbl_w_in.Text = global.logged_in_user == null ? null : global.logged_in_user.full_name;
                this.Text = "New transaction";
            }
            else
            {
                view();
                lbl_w_out.Text = global.logged_in_user.full_name;
                this.Text = "Transaction >  " + txt_rec_no.Text;
            }

        }

        public void back(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void closing(object sender, EventArgs e)
        {
            GC.SuppressFinalize(this);
            GC.Collect();
            GC.Collect();
        }

        public long s_id { get; set; }

        public bool is_New { get; set; }

        private System.Nullable<Double> in_wt = 0;
        private System.Nullable<DateTime> dt_in;
        private System.Nullable<DateTime> dt_out;
        public void view()
        {
            using (sys.domain.DAL.DBContext dbx = new sys.domain.DAL.DBContext(global.main_conn_str))
            {
                var t = dbx.Transactions.Where(a => a.transaction_id == s_id).FirstOrDefault();
                if (t == null) { MetroMessageBox.Show(this.owner, "Selected transaction not found or was already deleted.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop); this.Close(); }

                in_wt = t.in_wt;
                dt_in = t.dt_in;
                dt_out = t.dt_out;
                txt_rec_no.Text = t.receipt_no;
                txt_tscale_no.Text = t.truckscale_no;
                txt_gt_pass.Text = t.gate_pass;
                txt_pno1.Text = t.license_plate;
                txt_driver.Text = t.driver_name;
                cbo_clnt.Text = t.client != null ? t.client.name : "-- Select client";
                cbo_mate.Text = t.raw_material != null ? t.raw_material.description : "-- Select client -- ";
                cbo_origin.Text = t.origin != null ? t.origin.origin_name : "-- Select origin -- ";
                txt_rmrks.Text = t.remarks;

                dt_reg_dt.Value = t.reg_dt.HasValue ? t.reg_dt.Value : new DateTime();

                cbo_reg_h.SelectedIndex = dt_reg_dt.Value.Hour;
                cbo_reg_m.SelectedIndex = dt_reg_dt.Value.Minute;

                txt_in_time.Text = t.dt_in.HasValue ? t.dt_in.Value.ToString("hh:mm tt") : "--:--";
                txt_w_time.Text = t.waiting_time_str;
                txt_out_time.Text = t.dt_out.HasValue ? t.dt_out.Value.ToString("hh:mm tt") : "--:--";
                txt_e_time.Text = t.elapsed_time_str;
                txt_checker.Text = t.checker_name;
                //txt_rmrks.Text = transaction.remarks;
                //txt_checker.Text = transaction.checker_name;
                //txt_wt_dec.Text = transaction.wt_declared_in_dr.HasValue ? transaction.wt_declared_in_dr.Value.ToString("#,##0") : "0";
                //txt_tally_no.Text = transaction.series_no;
                //txt_MOTO.Text = transaction.MOTO;
                //txt_premium.Text = transaction.premium;
                //txt_other.Text = transaction.other;
                //txt_pp.Text = transaction.pp_phr;
                //txt_itag.Text = transaction.init_tag;
                //txt_ftag.Text = transaction.final_tag;
                //txt_wt_tag.Text = transaction.wt_per_tag.HasValue ? transaction.wt_per_tag.Value.ToString("#,##0") : "0";
                //txt_pllt_cnt.Text = transaction.pallet_count.HasValue ? transaction.pallet_count.Value.ToString("#,##0") : "0";
                //txt_mc.Text = transaction.moisture.HasValue ? transaction.moisture.Value.ToString("#,##0.00") : "0.00";
                //txt_po_num.Text = transaction.po_no;
                //txt_gr_num.Text = transaction.gross_wt.ToString("####0");

                if (t.in_offline == true) { lbl_on_dev_in.Text = "OFFLINE"; lbl_on_dev_in.Style = MetroColorStyle.Red; } else { lbl_on_dev_in.Text = "ONLINE"; lbl_on_dev_in.Style = MetroColorStyle.Blue; }
                if (t.out_offline == true) { lbl_on_dev_out.Text = "OFFLINE"; lbl_on_dev_out.Style = MetroColorStyle.Red; } else { lbl_on_dev_out.Text = "ONLINE"; lbl_on_dev_out.Style = MetroColorStyle.Blue; }
                txt_gr.Output = t.in_wt.Value.ToString();
                txt_tr.Output = t.out_wt.Value.ToString();
                txt_net.Output = t.net_wt.Value.ToString();

                lbl_dt_gr.Text = t.dt_in.HasValue ? t.dt_in.Value.ToString("MMM-dd-yyyy hh:mm tt") : "";
                lbl_dt_tr.Text = t.dt_out.HasValue ? t.dt_out.Value.ToString("MMM-dd-yyyy hh:mm tt") : "";
                lbl_w_in.Text = t.weigher_in_name;
                lbl_w_out.Text = t.weigher_out_name;

                pb_img_1.Image = t.image_1_view?? null;
                pb_img_2.Image = t.image_2_view?? null;
                lbl_rpt_c.Text = t.re_print_ctr.Value.ToString();
            }
        }

        public void save(object sender, EventArgs e)
        {
            var usr = global.logged_in_user;
             var p = usr.permissions.Where(a => a.role.description == sys.domain.Enums.roles.WEIGHING.ToString()).FirstOrDefault();
            if (p.permission == 0 || p.permission ==1)
            {
                MetroMessageBox.Show(this.owner, "Unable to save. please contact your administrator.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop); 
            }

            Cursor.Current = Cursors.WaitCursor;
            using (sys.domain.DAL.DBContext dbx = new sys.domain.DAL.DBContext(global.main_conn_str))
            {
                dbx.current_user = global.logged_in_user;
                var t = is_New ? new sys.domain.trns.Transactions() : dbx.Transactions.Where(a => a.transaction_id == s_id).FirstOrDefault();
                t.gr_no = txt_gr_num.Text.Trim();
                t.weigher_in = is_New ? global.logged_in_user == null ? null : global.logged_in_user.user_code : t.weigher_in;
                t.weigher_out = is_New ? null : global.logged_in_user.user_code;
                t.re_print_ctr = 0;
                t.dt_stamp = is_New ? DateTime.Now : t.dt_stamp;
                t.receipt_no = is_New ? "" : t.receipt_no;
                t.gate_pass = txt_gt_pass.Text.Trim();
                t.license_plate = txt_pno1.Text.Trim();
                t.driver_name = txt_driver.Text.Trim();
                t._client = cbo_clnt.Text;
                t._origin = cbo_origin.Text;
                t.checker_name = txt_checker.Text;
                t._commodity = cbo_mate.Text;
                t.reg_dt = new DateTime(dt_reg_dt.Value.Year, dt_reg_dt.Value.Month, dt_reg_dt.Value.Day) + new TimeSpan(Convert.ToInt32(cbo_reg_h.Text), Convert.ToInt32(cbo_reg_m.Text), 0);
                t.remarks = txt_rmrks.Text.Trim();
                t.truckscale_no = txt_tscale_no.Text;
                //transaction.remarks = txt_rmrks.Text.Trim();
                //transaction.checker_name = txt_checker.Text.Trim();
                //transaction._wt_dc = txt_wt_dec.Text.Trim();
                //transaction.series_no = txt_tally_no.Text.Trim();
                //transaction.MOTO = txt_MOTO.Text.Trim();
                //transaction.premium = txt_premium.Text.Trim();
                //transaction.other = txt_other.Text.Trim();
                //transaction.pp_phr = txt_pp.Text.Trim();
                //transaction.init_tag = txt_itag.Text.Trim();
                //transaction.final_tag = txt_ftag.Text.Trim();
                //transaction._pallet_count = txt_pllt_cnt.Text.Trim();
                //transaction._wt_per_tag = txt_wt_tag.Text.Trim();
                //transaction._moisture = txt_mc.Text.Trim();
                //transaction.po_no = txt_po_num.Text.Trim();
                t.WEIGHING_STATE = sys.domain.Validation.TransactionValidation.WEIGHIN_STATE.UPDATE;
                t.VALIDATE = true;
                try
                {
                    if (is_New) { dbx.Entry(t).State = EntityState.Added; dbx.Transactions.Add(t); } else { dbx.Entry(t).State = EntityState.Modified;  } dbx.SaveChanges(); ;

                    //if (is_New) { sys.domain.procedures.upd_r_no(db, transaction); }
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    MetroMessageBox.Show(this.owner, "Editing Complete.", "", MessageBoxButtons.OK, MessageBoxIcon.Information); this.Close();
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
                    MetroMessageBox.Show(this.owner, vERR.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Stop, msgbox_h); return;
                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(this.owner, ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        public void cancel(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        //private void txt_dev_OutputChanged(object sender, EventArgs e)
        //{

        //    double dev_wt = Convert.ToDouble(txt_dev.Output == "" ? "0" : txt_dev.Output);
        //    switch (is_New)
        //    {
        //        case true:
        //            txt_gr.Output = txt_dev.Output;
        //            break;
        //        case false:

        //            if (in_wt >= dev_wt)
        //            {
        //                txt_gr.Output = in_wt.ToString();
        //                lbl_dt_tr.Text = "";
        //                lbl_dt_gr.Text = dt_in.HasValue ? dt_in.Value.ToString("MMM-dd-yyyy hh:mm tt") : "";
        //                txt_tr.Output = dev_wt.ToString();
        //            }
        //            if (in_wt <= dev_wt)
        //            {
        //                txt_gr.Output = dev_wt.ToString();
        //                lbl_dt_gr.Text = "";
        //                lbl_dt_tr.Text = dt_in.HasValue ? dt_in.Value.ToString("MMM-dd-yyyy hh:mm tt") : "";
        //                txt_tr.Output = in_wt.ToString();
        //            }

        //            txt_net.Output = (Convert.ToDouble(txt_gr.Output) - Convert.ToDouble(txt_tr.Output)).ToString();
        //            break;
        //    }
        //}


        private void metroLabel4_Click(object sender, EventArgs e)
        {

        }

        private void dt_b_fr_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {

        }

        private void cbo_mate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_add_mate_Click(object sender, EventArgs e)
        {
            mfr_mate mfrm = new mfr_mate(); mfrm.is_loaded = true; mfrm.is_New = true; mfrm.owner = this.owner;
            using (sys.domain.DAL.DBContext dbx = new sys.domain.DAL.DBContext(global.main_conn_str))
            { if (mfrm.ShowDialog(this) == DialogResult.OK) cbo_mate.Items.Clear(); cbo_mate.Items.Add("-- Select commodity --"); cbo_mate.Items.AddRange(dbx.Raw_materials.Where(a => a.is_active == true).Select(a => a.description).ToArray()); }
        }

        private void btn_clnt_add_Click(object sender, EventArgs e)
        {

            mfr_clnts mfrm = new mfr_clnts(); mfrm.is_loaded = true; mfrm.is_New = true; mfrm.owner = this.owner;
            using (sys.domain.DAL.DBContext dbx = new sys.domain.DAL.DBContext(global.main_conn_str))
            { if (mfrm.ShowDialog(this) == DialogResult.OK) cbo_clnt.Items.Clear(); cbo_clnt.Items.Add("-- Select client -- "); cbo_clnt.Items.AddRange(dbx.Clients.Where(a => a.is_active == true).Select(a => a.name).ToArray()); }
        }

        private void btn_org_add_Click(object sender, EventArgs e)
        {
            mfr_org mfrm = new mfr_org(); mfrm.is_loaded = true; mfrm.is_New = true; mfrm.owner = this.owner;
            using (sys.domain.DAL.DBContext dbx = new sys.domain.DAL.DBContext(global.main_conn_str))
            { if (mfrm.ShowDialog(this) == DialogResult.OK) cbo_origin.Items.Clear(); cbo_origin.Items.Add("-- Select origin --"); cbo_origin.Items.AddRange(dbx.Origins.Where(a => a.is_active == true).Select(a => a.origin_name).ToArray()); }
        }

        private void compute_time(object sender, EventArgs e)
        {
            System.Nullable<DateTime> nw = is_New ? DateTime.Now : dt_in;

            DateTime dt_reg = new DateTime(dt_reg_dt.Value.Year, dt_reg_dt.Value.Month, dt_reg_dt.Value.Day) + new TimeSpan(Convert.ToInt16(cbo_reg_h.Text), Convert.ToInt16(cbo_reg_m.Text), 0);
            TimeSpan w_time = nw.Value - dt_reg;
            double d_w = w_time.Days;
            double hr_w = (w_time.Days * 24) + w_time.Hours;
            double mn_w = w_time.Minutes;
            txt_w_time.Text = (hr_w.ToString() + " hrs. & " + mn_w.ToString("0") + " min.").Trim();

            if (!is_New)
            {
                if (dt_out.HasValue)
                {
                    TimeSpan e_time = dt_out.Value - nw.Value;
                    d_w = e_time.Days;
                    hr_w = (e_time.Days * 24) + e_time.Hours;
                    mn_w = e_time.Minutes;
                    txt_e_time.Text = (hr_w.ToString() + " hrs. & " + mn_w.ToString("0") + " min.").Trim();
                }
            }
        }

        private void htmlToolTip1_Popup(object sender, PopupEventArgs e)
        {

        }


        public void key_down(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void dt_reg_dt_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
