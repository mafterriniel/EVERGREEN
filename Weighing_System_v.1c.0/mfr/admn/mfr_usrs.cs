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

namespace Weighing_System_v._1c._0
{
    public partial class mfr_usrs : MetroForm, IClass.IForm, IClass.IDb_m
    {
        sys.domain.adm.Users user;

        public mfr_usrs()
        {
            InitializeComponent();

            tg_active.Checked = true;
            this.Load += new EventHandler(this.load);
            this.KeyDown += new KeyEventHandler(key_down);
        }

        private sys.domain.DAL.DBContext _db = new sys.domain.DAL.DBContext(global.main_conn_str);
        public sys.domain.DAL.DBContext sdb
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

        public sys.domain.adm.Users s_entity { get; set; }

        public void set_handlers()
        {
            this.btn_save.Click -= new System.EventHandler(this.save);
            this.btn_save.Click += new System.EventHandler(this.save);
            this.btn_cancel.Click -= new System.EventHandler(this.cancel);
            this.btn_cancel.Click += new System.EventHandler(this.cancel);
        }

        public void load(object sender, EventArgs e)
        {
            if (!_is_loaded) return;

            set_handlers();
            if (is_New)
            { this.Text = "New user"; user = new sys.domain.adm.Users(); }
            else
            {
                      view();
                      this.Text = "User  >  " + txt_ns.Text;
            }

        }

        public void back(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void closing(object sender, EventArgs e)
        {
            GC.SuppressFinalize(this);
            GC.SuppressFinalize(user);
            GC.Collect();
            GC.Collect();
        }

        public long s_id { get; set; }

        public bool is_New { get; set; }

        public void view()
        {
            using (sys.domain.DAL.DBContext dbx = new sys.domain.DAL.DBContext(global.main_conn_str))
            {
                var usr = dbx.Users.Where(a => a.user_id == s_id)
               .Select(a => new
               {
                   usr = a,
                   role = dbx.Roles.GroupJoin(a.permissions
                   , r => r.role_id, p => p.role_id,
                   (r, p) => new { r, p }).SelectMany(dp => dp.p.DefaultIfEmpty(),
                   (dp, r) => new
                   {
                       description = dp.r.description,
                       permission = dp.p.FirstOrDefault().permission == null ? 0 : dp.p.FirstOrDefault().permission
                   })
               }).FirstOrDefault();

                if (usr == null) { MetroMessageBox.Show(this.owner, "Selected Category not found or was already deleted.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop); this.Close(); return; };

                if (usr != null)
                {
                    txt_c.Text = usr.usr.user_code;
                    txt_lgn.Text = usr.usr.login_id;
                    txt_lgp.Text = global.crypter.DecryptData(usr.usr.login_pwd);
                    txt_clgp.Text = txt_lgp.Text;
                    txt_fn.Text = usr.usr.first_name;
                    txt_mi.Text = usr.usr.middle_initial;
                    txt_ln.Text = usr.usr.last_name;
                    txt_ns.Text = usr.usr.name_suffix;
                    txt_pos.Text = usr.usr.position;
                    txt_con.Text = usr.usr.contact_num;
                    //if (usr.usr.permissions.Count() != 0) return;
                    trkb_w.Value = (int)usr.role.ToList().Where(a => a.description == "WEIGHING").FirstOrDefault().permission;
                    trkb_db.Value = (int)usr.role.ToList().Where(a => a.description == "DATABASE").FirstOrDefault().permission;
                    trk_mgmt.Value = (int)usr.role.ToList().Where(a => a.description == "MANAGEMENT").FirstOrDefault().permission;
                    trk_inv.Value = (int)usr.role.ToList().Where(a => a.description == "INVENTORY").FirstOrDefault().permission;
                    trk_rpt.Value = (int)usr.role.ToList().Where(a => a.description == "REPORTING").FirstOrDefault().permission ;
                    trk_sty.Value = (int)usr.role.ToList().Where(a => a.description == "SECURITIES").FirstOrDefault().permission;
                    trk_stp.Value = (int)usr.role.ToList().Where(a => a.description == "SETTINGS").FirstOrDefault().permission;
                    trk_ofl.Value = (int)usr.role.ToList().Where(a => a.description == "OFFLINE").FirstOrDefault().permission;
                }

            }
        }

        public void save(object sender, EventArgs e)
        {
            StringBuilder sErr = new StringBuilder();
            StringBuilder str_qry = new StringBuilder();

            using (sys.domain.DAL.DBContext dbx = new sys.domain.DAL.DBContext(global.main_conn_str))
            {
                try
                {
                    dbx.current_user = global.logged_in_user;
                    sys.domain.adm.Users entity = new sys.domain.adm.Users();
                    entity = is_New ? new sys.domain.adm.Users() : dbx.Users.Where(a => a.user_id == s_id).FirstOrDefault();
                    entity.user_code = txt_c.Text.Trim();
                    entity.login_id = txt_lgn.Text.Trim();
                    entity.login_pwd = global.crypter.EncryptData(txt_lgp.Text.Trim());
                    entity.login_pwd_confirmation = global.crypter.EncryptData(txt_clgp.Text.Trim());
                    entity.first_name = txt_fn.Text.Trim();
                    entity.last_name = txt_ln.Text.Trim();
                    entity.middle_initial = txt_mi.Text.Trim();
                    entity.name_suffix = txt_ns.Text.Trim();
                    entity.position = txt_pos.Text.Trim();
                    entity.is_active = tg_active.Checked;
                    entity.user_reg = is_New ? global.logged_in_user.user_code : entity.user_reg;
                    entity.dt_reg = is_New ? DateTime.Now : entity.dt_reg;
                    entity.contact_num = txt_con.Text.Trim();
                    if (is_New == false)
                    {
                        entity.user_upd = global.logged_in_user.user_code;
                        entity.dt_upd = DateTime.Now;
                    }

                    foreach (MetroFramework.Controls.MetroTrackBar txt in pnl_d.Controls.OfType<MetroFramework.Controls.MetroTrackBar>().OrderBy(a=>a.TabIndex))
                    {
                        List<sys.domain.adm.Permissions> permissions = new List<sys.domain.adm.Permissions>();
                        sys.domain.adm.Roles rr = dbx.Roles.Where(r2 => r2.description == txt.Text).FirstOrDefault();
                        sys.domain.adm.Permissions pp = is_New ? null: entity.permissions == null ? null : entity.permissions.Where(a=>a.role_id == rr.role_id).FirstOrDefault();
                        if (pp != null)
                        {
                            pp.permission = txt.Value;
                        }
                        else
                        {
                            pp = new sys.domain.adm.Permissions();
                            pp.role_id = rr.role_id;
                            pp.user_id = entity.user_id;
                            pp.user_code = entity.user_code;
                            pp.permission = txt.Value;
                            dbx.Permissions.Add(pp);
                       }
                    }

                    entity.VALIDATE = true;
                    if (is_New) {
                        entity.VALIDATE = true; dbx.Users.Add(entity);
                    }
                    else { dbx.current_user = global.logged_in_user; dbx.Entry(entity).State = System.Data.Entity.EntityState.Modified; }
                    dbx.SaveChanges();
                    
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
