using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weighing_System_v._1c._0
{
    class mfrTrns_codes
    {
//        using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using MetroFramework.Forms;
//using MetroFramework;
//using System.Data.Entity.Validation;
//namespace Weighing_System_v._1c._0
//{
//    public partial class mfr_trans : MetroForm, IClass.IForm, IClass.IDb_m
//    {
//        private sys.domain.trns.Transactions transaction;

//        public mfr_trans()
//        {
//            InitializeComponent();

//            cbo_type.Items.Clear(); cbo_type.Items.Add("-- Select Transaction Type --"); cbo_type.SelectedIndex = 0; cbo_type.Items.AddRange(new string[] { "Delivery - In", "Delivery - Out", "Finished Product", "Transfer" });
//            cbo_clnt.Items.Clear(); cbo_clnt.Items.Add("-- Select Client -- "); cbo_clnt.Items.AddRange(db.Clients.Where(a => a.is_active == true).Select(a => a.name).ToArray());
//            cbo_cat.Items.Clear(); cbo_cat.Items.Add("-- Select Category -- "); cbo_cat.Items.AddRange(db.Categories.Where(a => a.is_active == true).Select(a => a.name).ToArray());

//            cbo_type.SelectedIndex = 0;
//            cbo_clnt.SelectedIndex = 0;
//            cbo_cat.SelectedIndex = 0;

//            txt_dev.Output = "0";
//            txt_gr.Output = "0";
//            txt_tr.Output = "0";
//            txt_in_tr_h.Output = "0";
//            txt_out_tr_h.Output = "0";
//            txt_adj.Output = "0";
//            txt_net.Output = "0";
//            lbl_dt_gr.Text = "";
//            lbl_dt_tr.Text = "";
//            lbl_dt_t_in.Text = "";
//            lbl_dt_t_out.Text = "";
//            lbl_w_in.Text = "";
//            lbl_w_out.Text = "";
//            lbl_stn_name.Text = "";


//            this.Load += new EventHandler(this.load);
//        }

//        private sys.domain.DAL.DBContext _db = new sys.domain.DAL.DBContext(global.main_conn_str);
//        public sys.domain.DAL.DBContext db
//        {
//            get
//            {
//                return _db;
//            }
//            set
//            {
//                _db = value;
//            }
//        }

//        private bool _is_loaded;
//        public bool is_loaded
//        {
//            get
//            {
//                return _is_loaded;
//            }
//            set
//            {
//                _is_loaded = value;
//            }
//        }

//        public void set_handlers()
//        {
//            cbo_cat.SelectedIndexChanged += new System.EventHandler(cbo_cat_SelectedIndexChanged);
//            rdo_raw.CheckedChanged += new System.EventHandler(cbo_cat_SelectedIndexChanged);
//            txt_dev.OutputChanged += new System.EventHandler(txt_dev_OutputChanged);
//            this.btn_save.Click -= new System.EventHandler(this.save);
//            this.btn_save.Click += new System.EventHandler(this.save);
//            this.btn_cancel.Click -= new System.EventHandler(this.cancel);
//            this.btn_cancel.Click += new System.EventHandler(this.cancel);
//        }

//        private mfr_mn _owner;
//        public mfr_mn owner
//        {
//            get
//            {
//                return _owner;
//            }
//            set
//            {
//                _owner = value;
//            }
//        }

//        public void load(object sender, EventArgs e)
//        {
//            set_handlers();

//            if (!_is_loaded) return;
//            txt_stn_c.Text = global.station != null ? global.station.station_code : "N/A";
//            lbl_stn_name.Text = global.station != null ? global.station.station_name : "N/A";
//            clock2.start();
//            if (is_New)
//            {
//                transaction = new sys.domain.trns.Transactions();
//                lbl_w_in.Text = global.logged_in_user.full_name;
//                this.Text = "New transaction";
//            }
//            else
//            {
//                transaction = db.Transactions.Where(a => a.transaction_id == s_id).FirstOrDefault();
//                if (transaction == null) { MetroMessageBox.Show(this.owner, "Selected record not found or was already deleted.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop); this.Close(); return; };
//                view();
//                lbl_w_out.Text = global.logged_in_user.full_name;
//                this.Text = "Transaction >  " + transaction.receipt_no;
//            }
//            //cbo_cat_SelectedIndexChanged(null, null);

//        }

//        public void back(object sender, EventArgs e)
//        {
//            throw new NotImplementedException();
//        }

//        public void closing(object sender, EventArgs e)
//        {
//            GC.SuppressFinalize(this);
//            GC.SuppressFinalize(transaction);
//            GC.Collect();
//            GC.Collect();
//        }

//        public long s_id { get; set; }

//        public bool is_New { get; set; }

//        public void view()
//        {
//            transaction = db.Transactions.Where(a => a.transaction_id == s_id).FirstOrDefault();
//            if (transaction == null) { MetroMessageBox.Show(this.owner, "Selected transaction not found or was already deleted.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop); this.Close(); }

//            switch (transaction.t_type)
//            {
//                case "P": cbo_type.SelectedIndex = 1; break;
//                case "S": cbo_type.SelectedIndex = 2; break;
//                case "F": cbo_type.SelectedIndex = 3; break;
//                case "T": cbo_type.SelectedIndex = 4; break;
//            }

//            txt_stn_c.Text = transaction.station_code;
//            txt_rec_no.Text = transaction.receipt_no;
//            txt_pno1.Text = transaction.license_plate_in;
//            cbo_clnt.Text = transaction.client != null ? transaction.client.name : "";
//            rdo_raw.Checked = transaction.mate_type == "R" ? true : false;

//            var category = transaction.mate_type == "R" ? transaction.raw_material != null ? transaction.raw_material.category : null : transaction.product != null ? transaction.product.category : null;
//            cbo_cat.Text = category != null ? category.name : "";
//            cbo_mate.Text = transaction.mate_type == "R" ? transaction.raw_material != null ? transaction.raw_material.description : "-- Select Commodity -- " : transaction.product != null ? transaction.product.description : "-- Select Commodity -- ";
//            txt_mc.Text = transaction.moisture.ToString();
//            txt_dr.Text = transaction.dr_no;
//            txt_cont.Text = transaction.container_no;
//            txt_rmrks.Text = transaction.remarks;
//            txt_wh.Text = transaction.warehouse_no1;
//            txt_driver.Text = transaction.driver_name;
//            //txt_bales.Text = transaction
//            txt_gr.Output = transaction.in_wt.ToString();
//            lbl_dt_gr.Text = transaction.dt_in.HasValue ? transaction.dt_in.Value.ToString("MMM-dd-yyyy hh:mm tt") : "";

//            lbl_w_in.Text = transaction.user_in != null ? transaction.user_in.full_name : "";
//        }

//        public void save(object sender, EventArgs e)
//        {
//            StringBuilder sErr = new StringBuilder();
//            StringBuilder str_qry = new StringBuilder();
//            System.Text.RegularExpressions.Regex mtch;
//            System.Text.RegularExpressions.MatchCollection mtches;
//            double dev_wt = Convert.ToDouble(txt_dev.Output);
//            double net_wt = Convert.ToDouble(txt_net.Output);
//            string plate_no = is_New ? txt_pno1.Text.Trim() : txt_pno2.Text.Trim();

//            string moisture = txt_mc.Text;
//            if (moisture == string.Empty) { moisture = "0.000"; txt_mc.Text = moisture; }
//            //System.Text.RegularExpressions.Regex mtch = new System.Text.RegularExpressions.Regex("^\\-?[0-9]{1,3}(\\,[0-9]{3})*(\\.[0-9]+)?$|^[0-9]+(\\.[0-9]+)?$");
//            //System.Text.RegularExpressions.MatchCollection mtches = mtch.Matches(moisture);
//            //if (mtches.Count == 0) { sErr.AppendLine("* Invalid moisture."); };

//            string number_of_bales = txt_bales.Text.Trim();
//            if (number_of_bales == string.Empty) { number_of_bales = "0"; txt_bales.Text = number_of_bales; }
//            mtch = new System.Text.RegularExpressions.Regex("^\\-?[0-9]{1,3}(\\,[0-9]{3})*(\\.[0-9]+)?$|^[0-9]+(\\.[0-9]+)?$");
//            mtches = mtch.Matches(number_of_bales);
//            if (mtches.Count == 0) { sErr.AppendLine("* Number of bales must be numeric."); };

//            string trans_type = "";
//            switch (cbo_type.SelectedIndex)
//            {
//                case 0: trans_type = ""; break;
//                case 1: trans_type = "P"; break;
//                case 2: trans_type = "S"; break;
//                case 3: trans_type = "F"; break;
//                case 4: trans_type = "T"; break;
//            }

//            str_qry.AppendLine("DECLARE @ID nvarchar(20) set @ID = '" + s_id + "'");
//            str_qry.AppendLine("DECLARE @TRANSTYPE varchar(1) set @TRANSTYPE = '" + trans_type + "'");
//            str_qry.AppendLine("DECLARE @MATE_TYPE varchar(1) set @MATE_TYPE = '" + (rdo_raw.Checked == true ? "R" : "F").ToString() + "'");
//            str_qry.AppendLine("DECLARE @STATION varchar(15) set @STATION = '" + global.station.station_code + "'");
//            str_qry.AppendLine("DECLARE @PLATENO nvarchar(20) set @PLATENO = '" + plate_no + "'");
//            str_qry.AppendLine("DECLARE @DEV_WT numeric(10,3) set @DEV_WT = '" + dev_wt + "'");
//            str_qry.AppendLine("DECLARE @NET_WT numeric(10,3) set @NET_WT ='" + net_wt + "'");
//            str_qry.AppendLine("DECLARE @MATE varchar(60) set @MATE = '" + cbo_mate.Text + "'");
//            str_qry.AppendLine("DECLARE @CLIENT varchar(60) set @CLIENT = '" + cbo_clnt.Text + "'");
//            str_qry.AppendLine("DECLARE @ERROR varchar(MAX) set @ERROR = ''");
//            str_qry.AppendLine("IF @STATION = '' SET @ERROR = @ERROR + CHAR(13)+CHAR(10) + '* No station was selected.';");
//            str_qry.AppendLine("IF @TRANSTYPE = '' SET @ERROR = @ERROR + CHAR(13)+CHAR(10) + '* Transaction type is required.';");
//            str_qry.AppendLine("IF @PLATENO = '' SET @ERROR = @ERROR + CHAR(13)+CHAR(10) + '* Plate Number is required.';");
//            str_qry.AppendLine("IF @DEV_WT = 0 SET @ERROR = @ERROR + CHAR(13)+CHAR(10) + '* No weight detected.';");
//            str_qry.AppendLine("IF @MATE = '' BEGIN SET @ERROR = @ERROR + CHAR(13)+CHAR(10) + '* Commodity is required.' END");
//            str_qry.AppendLine("ELSE");
//            str_qry.AppendLine("BEGIN");
//            str_qry.AppendLine("if @MATE_TYPE = 'R'");
//            str_qry.AppendLine("BEGIN if (select count(*) from Raw_materials where [description] = @MATE) = 0 SET @ERROR = @ERROR + CHAR(13)+CHAR(10) + '* Selected commodity not found.'; END");
//            str_qry.AppendLine("else");
//            str_qry.AppendLine("BEGIN if (select count(*) from products where [description] = @MATE) = 0 SET @ERROR = @ERROR + CHAR(13)+CHAR(10) + '* Selected commodity not found.'; END");
//            str_qry.AppendLine("END;");
//            //BEGIN if (select count(*) from Raw_materials where [description] = @MATE) = 0 SET @ERROR = @ERROR + CHAR(13)+CHAR(10) + '* Selected material not found.';END;");
//            str_qry.AppendLine("IF @CLIENT = '' BEGIN SET @ERROR = @ERROR + CHAR(13)+CHAR(10) + '* Supplier/Customer is required.' END");
//            str_qry.AppendLine("ELSE BEGIN if (select count(*) from Clients where [name] = @CLIENT) = 0 SET @ERROR = @ERROR + CHAR(13)+CHAR(10) + '* Supplier/Customer  not found.';END;");
//            str_qry.AppendLine("IF @ID = '0'");
//            str_qry.AppendLine("BEGIN");
//            str_qry.AppendLine("if (select count(*) from Transactions where [license_plate_in] = @PLATENO and [dt_out] is null) > 0 SET @ERROR = @ERROR + CHAR(13)+CHAR(10) + '* Plate number already added to pending transactions.';");
//            str_qry.AppendLine("END;");
//            str_qry.AppendLine("ELSE");
//            str_qry.AppendLine("BEGIN");
//            str_qry.AppendLine("IF @NET_WT= 0 SET @ERROR = @ERROR + CHAR(13)+CHAR(10) + '* Net weight is invalid';");
//            str_qry.AppendLine("END;");
//            str_qry.AppendLine("If @ERROR <> ''");
//            str_qry.AppendLine("BEGIN");
//            str_qry.AppendLine("Set @ERROR = substring(@ERROR,3,LEN(@ERROR)-2)");
//            str_qry.AppendLine("RAISERROR(@ERROR ,11,1)");
//            str_qry.AppendLine("END");

//            Clipboard.SetText(str_qry.ToString());
//            sys.domain.connection_string cs = new sys.domain.connection_string { datasource = "TSI_LAPTOP2\\SQLEXPRESS", catalog = "8DR", user_id = "sa", password = "1", integrated_security = false };
//            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(cs.connection);
//            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
//            if (conn.State == ConnectionState.Open) { conn.Close(); }; conn.Open();
//            try { cmd = new System.Data.SqlClient.SqlCommand(str_qry.ToString(), conn); cmd.ExecuteNonQuery(); conn.Close(); conn.Dispose(); cmd.Dispose(); }
//            catch (Exception ex) { sErr.AppendLine(ex.Message); conn.Close(); conn.Dispose(); }

//            mtch = new System.Text.RegularExpressions.Regex(Environment.NewLine);
//            int msgbox_h = mtch.Matches(sErr.ToString()).Count * 35;
//            msgbox_h = msgbox_h <= 160 ? 160 : msgbox_h;
//            if (sErr.Length > 0) { MetroMessageBox.Show(this.owner, sErr.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Stop, msgbox_h); return; }

//            //var refno =db.Ref_nos;
//            switch (trans_type)
//            {
//                case "P": transaction.receipt_no = global.station.station_code + db.Ref_nos.Select(a => a.purchase_id).First(); break;
//                case "S": transaction.receipt_no = global.station.station_code + db.Ref_nos.Select(a => a.sales_id).First(); break;
//                case "F": transaction.receipt_no = global.station.station_code + db.Ref_nos.Select(a => a.finished_id).First(); break;
//                case "T": transaction.receipt_no = global.station.station_code + db.Ref_nos.Select(a => a.transfer_id).First(); break;
//            }

//            transaction.container_no = txt_cont.Text.Trim();
//            var clnt = db.Clients.Where(a => a.name == cbo_clnt.Text).FirstOrDefault();
//            if (clnt != null) transaction.client_code = clnt.client_code;

//            transaction.mate_type = rdo_raw.Checked == true ? "R" : "F";
//            if (rdo_raw.Checked == true)
//            {
//                var q = db.Raw_materials.Where(a => a.description == cbo_mate.Text).FirstOrDefault();
//                if (q != null) { transaction.mate_code = q.mate_code; transaction.price = q.price; }
//            }

//            if (rdo_fin.Checked == true)
//            {
//                var q = db.Products.Where(a => a.description == cbo_mate.Text).FirstOrDefault();
//                if (q != null) { transaction.mate_code = q.prod_code; transaction.price = q.price; }
//            }

//            transaction.moisture = Convert.ToDouble(moisture);
//            transaction.warehouse_no1 = txt_wh.Text.Trim();
//            transaction.dr_no = txt_dr.Text.Trim();
//            transaction.remarks = txt_rmrks.Text.Trim();
//            transaction.station_code = global.station.station_code;
//            transaction.dt_stamp = DateTime.Now;
//            transaction.t_type = trans_type;
//            transaction.driver_name = txt_driver.Text.ToString();
//            transaction.fee = global.settings.W_FEE;
//            switch (is_New)
//            {
//                case true:
//                    transaction.dt_in = DateTime.Now;
//                    transaction.license_plate_in = plate_no;
//                    transaction.in_wt = Convert.ToDouble(txt_dev.Output);
//                    transaction.weigher_in = global.logged_in_user.user_code;
//                    transaction.re_print_ctr = 0;
//                    transaction.f_paid = false;
//                    db.Transactions.Add(transaction);

//                    var ref_no = db.Ref_nos.First();
//                    Double id = 0;
                   
//                    switch (trans_type)
//                    {
//                        case "P": Double.TryParse(ref_no.purchase_id, out id); ref_no.purchase_id = String.Format("{0:0000000}", id + 1); ; break;
//                        case "S": Double.TryParse(ref_no.sales_id, out id); ref_no.sales_id = String.Format("{0:0000000}", id + 1); ; break;
//                        case "F": Double.TryParse(ref_no.finished_id, out id); ref_no.finished_id = String.Format("{0:0000000}", id + 1); ; break;
//                        case "T": Double.TryParse(ref_no.transfer_id, out id); ref_no.transfer_id = String.Format("{0:0000000}", id + 1); ; break;
//                    }

//                    try
//                    {
//                        db.SaveChanges();
//                    }
//                    catch (DbEntityValidationException ex)
//                    {
//                        StringBuilder vERR = new StringBuilder();

//                        foreach (var validationResults in db.GetValidationErrors())
//                        {
//                            foreach (var error in validationResults.ValidationErrors)
//                            {
//                               vERR.AppendLine(  error.PropertyName + "  " +  error.ErrorMessage);
//                            }
//                        }

//                        msgbox_h = msgbox_h <= 160 ? 160 : msgbox_h;
//                        MetroMessageBox.Show(this.Owner, vERR.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Stop, msgbox_h); return;
                 

//                        //foreach (var s in ex.EntityValidationErrors)
//                        //{
//                        //    MessageBox.Show(s.ValidationErrors.ToString());
//                        //}
//                            return;
//                    }
//                    catch (Exception ex)
//                    {
//                        msgbox_h = msgbox_h <= 160 ? 160 : msgbox_h;
//                        MetroMessageBox.Show(this.owner, ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Stop, msgbox_h); return;
//                    }

//                    break;
//                case false:
//                    transaction.dt_out = DateTime.Now;
//                    transaction.license_plate_in = txt_pno1.Text.Trim();
//                    transaction.license_plate_out = txt_pno2.Text.Trim();
//                    transaction.out_wt = Convert.ToDouble(txt_dev.Output);
//                    transaction.net_wt = Convert.ToDouble(txt_net.Output);
//                    transaction.weigher_out = global.logged_in_user.user_code;
//                    db.SaveChanges();
//                    break;
//            }

//            this.DialogResult = System.Windows.Forms.DialogResult.OK;

//            MetroMessageBox.Show(this.owner, is_New ? "Weigh-in Complete" : "Weigh-out Complete.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop); this.Close();

//        }

//        public void cancel(object sender, EventArgs e)
//        {
//            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
//            this.Close();
//        }

//        private void cbo_cat_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            cbo_mate.Items.Clear();
//            cbo_mate.Items.Add("-- Select Commodity -- ");
//            cbo_mate.SelectedIndex = 0;

//            var cat = db.Categories.Where(a => a.name == cbo_cat.Text).FirstOrDefault();
//            if (cat != null)
//            {
//                switch (rdo_raw.Checked)
//                {
//                    case true:
//                        cbo_mate.Items.AddRange(db.Raw_materials.Where(a => a.is_active == true && a.category_code == cat.category_code).Select(a => a.description).ToArray());
//                        break;
//                    case false:
//                        cbo_mate.Items.AddRange(db.Products.Where(a => a.is_active == true && a.category_code == cat.category_code).Select(a => a.description).ToArray());
//                        break;
//                }
//            }
//        }

//        private void txt_dev_OutputChanged(object sender, EventArgs e)
//        {
//            System.Nullable<Double> in_wt = transaction.in_wt;
//            double dev_wt = Convert.ToDouble(txt_dev.Output == "" ? "0" : txt_dev.Output);
//            switch (is_New)
//            {
//                case true:
//                    txt_gr.Output = txt_dev.Output;
//                    break;
//                case false:

//                    if (in_wt >= dev_wt)
//                    {
//                        txt_gr.Output = in_wt.ToString();
//                        lbl_dt_tr.Text = "";
//                        lbl_dt_gr.Text = transaction.dt_in.HasValue ? transaction.dt_in.Value.ToString("MMM-dd-yyyy hh:mm tt") : "";
//                        txt_tr.Output = dev_wt.ToString();
//                    }
//                    if (in_wt <= dev_wt)
//                    {
//                        txt_gr.Output = dev_wt.ToString();
//                        lbl_dt_gr.Text = "";
//                        lbl_dt_tr.Text = transaction.dt_in.HasValue ? transaction.dt_in.Value.ToString("MMM-dd-yyyy hh:mm tt") : "";
//                        txt_tr.Output = in_wt.ToString();
//                    }

//                    txt_net.Output = (Convert.ToDouble(txt_gr.Output) - Convert.ToDouble(txt_tr.Output)).ToString();
//                    break;
//            }
//        }

//        private void metroTextBox2_Click(object sender, EventArgs e)
//        {

//        }

//        private void metroTextBox2_TextChanged(object sender, EventArgs e)
//        {
//            txt_dev.Output = metroTextBox2.Text.ToString();
//        }
//    }
//}

    }
}
