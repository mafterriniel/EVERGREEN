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
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Weighing_System_v._1c._0
{
    public partial class mfr_clnts : MetroForm, IClass.IForm, IClass.IDb_m
    {

        sys.domain.dbs.Clients client;

        public mfr_clnts()
        {
            InitializeComponent();

            tg_active.Checked = true;
            this.Load += new EventHandler(this.load);
            this.KeyDown += new KeyEventHandler(key_down);
        }
        public sys.domain.dbs.Clients s_entity { get; set; }
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
            if (!_is_loaded) return;
            if (is_New)
            { this.Text = "New Supplier"; client = new sys.domain.dbs.Clients(); }
            else
            { view(); this.Text = "Supplier  >  " + txt_d.Text; }
            set_handlers();
        }

        public void back(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void closing(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public long s_id { get; set; }

        public bool is_New { get; set; }

        public void view()
        {
            using (sys.domain.DAL.DBContext dbx = new sys.domain.DAL.DBContext(global.main_conn_str))
            {
                var clnt = dbx.Clients.Where(a => a.client_id == s_id).FirstOrDefault();
                if (clnt == null) { MetroMessageBox.Show(this.owner, "Selected client not found or was already deleted.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop); this.Close(); return; };

                txt_c.Text = clnt.client_code;
                txt_d.Text = clnt.name;
                txt_a.Text = clnt.addr;
                txt_cp.Text = clnt.contact_person;
                txt_cn.Text = clnt.tel_no;
                tg_cust.Checked = (bool)clnt.is_customer;
                tg_sup.Checked = (bool)clnt.is_supplier;
                tg_active.Checked = (bool)clnt.is_active;
            }
        }

        public void save(object sender, EventArgs e)
        {
            using (sys.domain.DAL.DBContext dbx = new sys.domain.DAL.DBContext(global.main_conn_str))
            {

                StringBuilder sErr = new StringBuilder();
                StringBuilder str_qry = new StringBuilder();
                tg_sup.Checked = true;
                //if (tg_cust.Checked == false && tg_sup.Checked == false)
                //{ sErr.AppendLine("* Please check in either of the customer or supplier switch"); }
                try
                {
                    sys.domain.dbs.Clients entity = new sys.domain.dbs.Clients();
                    if (is_New)
                    {
                        entity.client_code = txt_c.Text.Trim();
                        entity.name = txt_d.Text.Trim();
                        entity.addr = txt_a.Text.Trim();
                        entity.contact_person = txt_cp.Text.Trim();
                        entity.tel_no = txt_cn.Text.Trim();
                        entity.is_supplier = tg_sup.Checked;
                        entity.is_active = tg_active.Checked;
                        entity.user_reg = global.logged_in_user.user_code;
                        entity.dt_reg = DateTime.Now;
                        dbx.Entry(entity).State = EntityState.Added; dbx.Clients.Add(entity);
                        dbx.SaveChanges();
                    }
                    else
                    {
                        var new_entity = new sys.domain.dbs.Clients();
                        var old_entity = dbx.Clients.Where(a => a.client_id == s_id).FirstOrDefault();
                        if (old_entity.client_code != txt_c.Text.Trim())
                        {
                            foreach (var mt in old_entity.transactions) { mt.VALIDATE = false; mt.client_code = txt_c.Text.Trim(); };
                            new_entity.client_code = txt_c.Text.Trim();
                            new_entity.name = txt_d.Text.Trim();
                            new_entity.addr = txt_a.Text.Trim();
                            new_entity.contact_person = txt_cp.Text.Trim();
                            new_entity.tel_no = txt_cn.Text.Trim();
                            //new_entity.is_customer = tg_cust.Checked;
                            new_entity.is_supplier = tg_sup.Checked;
                            new_entity.is_active = tg_active.Checked;
                            new_entity.user_reg = old_entity.user_reg;
                            new_entity.dt_reg = old_entity.dt_reg;
                            new_entity.user_upd = global.logged_in_user.user_code;
                            new_entity.dt_upd = DateTime.Now;
                            new_entity.is_active = tg_active.Checked;
                            dbx.Clients.Remove(old_entity);
                            dbx.SaveChanges();
                            dbx.Clients.Add(new_entity);
                            dbx.Entry(new_entity).State = EntityState.Added; dbx.Clients.Add(new_entity);
                            dbx.SaveChanges();
                            entity = new_entity;
                        }
                        else
                        {
                            entity = dbx.Clients.Where(a => a.client_id == s_id).FirstOrDefault();
                            entity.client_code = txt_c.Text.Trim();
                            entity.name = txt_d.Text.Trim();
                            entity.addr = txt_a.Text.Trim();
                            entity.contact_person = txt_cp.Text.Trim();
                            entity.tel_no = txt_cn.Text.Trim();
                            //entity.is_customer = tg_cust.Checked;
                            entity.is_supplier = tg_sup.Checked;
                            entity.is_active = tg_active.Checked;
                            entity.user_upd = global.logged_in_user.user_code;
                            entity.dt_upd = DateTime.Now;
                            dbx.Entry(entity).State = EntityState.Modified;
                            dbx.SaveChanges();
                        }
                    }

                    s_entity = entity;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    MetroMessageBox.Show(this.owner, is_New ? "New record addedd" : "Editing Complete.", "", MessageBoxButtons.OK, MessageBoxIcon.Information); this.Close();
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


        public void key_down(object sender, KeyEventArgs e)
        {
            global.select_next_control(this, e);
        }
    }
}
