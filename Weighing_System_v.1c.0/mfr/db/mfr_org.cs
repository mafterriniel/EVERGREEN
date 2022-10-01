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
    public partial class mfr_org : MetroForm, IClass.IForm, IClass.IDb_m
    {
        public sys.domain.dbs.Origins origin;

        public sys.domain.dbs.Origins s_entity { get; set; }
        public mfr_org()
        {
            InitializeComponent();
            tg_active.Checked = true;
            this.Load += new EventHandler(this.load);
            this.KeyDown += new KeyEventHandler(key_down);
        }

        private sys.domain.DAL.DBContext _db = new sys.domain.DAL.DBContext(global.main_conn_str);
        public sys.domain.DAL.DBContext db
        {
            get
            {
                return _db;
            }
            set
            {
                _db = value;
            }
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
            if (!_is_loaded) return;
            if (is_New)
            { this.Text = "New Origin"; }
            else
            { view(); this.Text = "Origin  >  " + txt_c.Text; }

            set_handlers();
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

        public void view()
        {
            using (sys.domain.DAL.DBContext dbx = new sys.domain.DAL.DBContext(global.main_conn_str))
            {
                var c = dbx.Origins.Where(a => a.origin_id == s_id).FirstOrDefault();
                if (c == null) { MetroMessageBox.Show(this.owner, "* Selected record does not exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop); this.Close(); return; };

                txt_c.Text = c.origin_code;
                txt_d.Text = c.origin_name;
                tg_active.Checked = (bool)c.is_active;
            }
        }

        public void save(object sender, EventArgs e)
        {

            using (sys.domain.DAL.DBContext dbx = new sys.domain.DAL.DBContext(global.main_conn_str))
            {
                try
                {
                    sys.domain.dbs.Origins entity = new sys.domain.dbs.Origins();
                    if (is_New)
                    {
                        entity.origin_code = txt_c.Text.Trim();
                        entity.origin_name = txt_d.Text.Trim();
                        entity.dt_reg = DateTime.Now;
                        entity.user_reg = global.logged_in_user == null ? null : global.logged_in_user.user_code;
                        entity.is_active = tg_active.Checked;
                        dbx.Origins.Add(entity);
                        dbx.SaveChanges();
                    }
                    else
                    {
                        var new_entity = new sys.domain.dbs.Origins();
                        var old_entity = dbx.Origins.Where(a => a.origin_id == s_id).FirstOrDefault();
                        if (old_entity.origin_code != txt_c.Text.Trim())
                        {
                            foreach (var mt in old_entity.transactions) { mt.VALIDATE = false; mt.origin_code = txt_c.Text.Trim(); };
                            new_entity.origin_code = txt_c.Text.Trim();
                            new_entity.origin_name = txt_d.Text.Trim();
                            new_entity.user_reg = old_entity.user_reg;
                            new_entity.dt_reg = old_entity.dt_upd;
                            new_entity.user_upd = global.logged_in_user == null ? null : global.logged_in_user.user_code;
                            new_entity.dt_upd = DateTime.Now;
                            new_entity.is_active = tg_active.Checked;
                            dbx.Origins.Remove(old_entity);
                            dbx.SaveChanges();
                            dbx.Origins.Add(new_entity);
                            dbx.Entry(new_entity).State = EntityState.Added; dbx.Origins.Add(new_entity);
                            dbx.SaveChanges();
                            entity = new_entity;
                        }
                        else
                        {
                            entity = dbx.Origins.Where(a => a.origin_id == s_id).FirstOrDefault();
                            entity.origin_code = txt_c.Text.Trim();
                            entity.origin_name = txt_d.Text.Trim();
                            entity.user_upd = global.logged_in_user == null ? null : global.logged_in_user.user_code;
                            entity.dt_upd = DateTime.Now;
                            entity.is_active = tg_active.Checked;
                            entity.user_upd = global.logged_in_user.user_code;
                            entity.dt_upd = DateTime.Now;
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
