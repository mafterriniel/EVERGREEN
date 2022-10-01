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
namespace Weighing_System_v._1c._0
{
    public partial class mfr_admin : Form,IClass.IForm,IClass.IPaging
    {
        IEnumerable<sys.domain.adm.Users> users;
        public mfr_admin()
        {
            InitializeComponent();

            cbo_p_size.SelectedIndex = 0;
            txt_db_srch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_db_srch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_db_srch.CharacterCasing = CharacterCasing.Upper;

            dg.RowHeadersVisible = false;
            dg.AllowUserToAddRows = false;
            dg.AllowUserToDeleteRows = false;
            dg.AllowUserToOrderColumns = false;
            dg.AllowUserToResizeRows = false;
            dg.AllowUserToResizeColumns = false;
            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dg.RowTemplate.Height = 25;

            //metroTabControl1.SelectedIndex = 0;
            this.Load += new EventHandler(load);
        }
        private sys.domain.DAL.DBContext _db = new sys.domain.DAL.DBContext( global.main_conn_str);
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
            this.btn_n.Click -= new System.EventHandler(this.proceed);
            this.btn_n.Click += new System.EventHandler(this.proceed);
            this.btn_e.Click -= new System.EventHandler(this.proceed);
            this.btn_e.Click += new System.EventHandler(this.proceed);
            this.btn_d.Click -= new System.EventHandler(this.proceed);
            this.btn_d.Click += new System.EventHandler(this.proceed);
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
            if (!is_loaded) return;
            set_handlers();
            set_pagination_event_handlers();
            refresh(null,null);
        }

        public void back(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void closing(object sender, EventArgs e)
        {
            GC.SuppressFinalize(this);
            GC.SuppressFinalize(users);
            GC.Collect();
            GC.Collect();
        }

        public void list(object sender, EventArgs e)
        {
            users = db.Users.Select(a => a);
            total_page = users.Count();
            pageindex = 1;
            pagesize = Convert.ToInt32(cbo_p_size.Text.Trim());
            txt_total.Text = total_page.ToString();
            int pageover = (total_page % pagesize);
            pagelimit = (total_page / pagesize) + (pageover > 0 ? 1 : 0);
        }

        public void set_dg()
        {
            foreach (DataGridViewColumn col in dg.Columns)
            {
                if (col.Name == "selected") { col.HeaderText = ""; col.Width = 60; col.Visible = true; col.ReadOnly = false; } else { col.ReadOnly = true; col.Visible = false; };
                if (col.Name == "code") { col.HeaderText = "Code"; col.Width = 200; col.Visible = true; };
                if (col.Name == "full_name") { col.HeaderText = "Full Name"; col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; col.Visible = true; };
                if (col.Name.Trim() == "is_active".Trim()) { col.HeaderText = "Active"; col.Width = 60; col.Visible = true; };
            }
        }
        #region "Pagination"
        public int pageindex { get; set; }
        public int pagesize { get; set; }
        public int pagelimit { get; set; }
        public int total_page { get; set; }

        public void set_pagination_event_handlers()
        {
            this.cbo_p_size.SelectedIndexChanged += new System.EventHandler(this.refresh);
            this.cbo_p_size.SelectedIndexChanged -= new System.EventHandler(this.refresh);
            this.txt_db_srch.TextChanged -= new System.EventHandler(this.search);
            this.txt_db_srch.TextChanged += new System.EventHandler(this.search);
            this.btn_prev_pg.Click -= new System.EventHandler(this.prev_page);
            this.btn_prev_pg.Click += new System.EventHandler(this.prev_page);
            this.btn_next_pg.Click -= new System.EventHandler(this.next_page);
            this.btn_next_pg.Click += new System.EventHandler(this.next_page);
        }

        public void browse_page(int pg_num)
        {
            dg.DataSource = null;
            dg.Rows.Clear();
            dg.Columns.Clear();
            pageindex = pg_num;
            pagesize = Convert.ToInt32(cbo_p_size.Text.Trim());

            int currentsize = (pagesize) * (pg_num - 1);
            txt_display.Text = (currentsize + Convert.ToInt32(cbo_p_size.Text)).ToString();

            var q1= db.Users.OrderBy(a=>a.user_code).Skip(currentsize).Take(pagesize).Select(a => new { selected = false, id = a.user_id, code = a.user_code, full_name = a.first_name + " " + a.middle_initial + " "  + a.last_name, is_active = a.is_active });
            dg.DataSource = q1.ToList().ToDataTable();
            txt_db_srch.AutoCompleteCustomSource.Clear(); txt_db_srch.AutoCompleteCustomSource.AddRange(q1.Select(a=>a.full_name).ToArray());
     
            txt_display.Text = dg.Rows.Count.ToString();
            lbl_db_src.Text = dg.Rows.Count.ToString();
            lbl_db_sr.Text = "1";

            set_dg();
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
           
            MetroFramework.Controls.MetroButton ctrl = (MetroFramework.Controls.MetroButton)sender;
             if (ctrl.Text == btn_n.Text || ctrl.Text == btn_e.Text)
            {

                if (ctrl.Text != btn_n.Text) { if(dg.Rows.Count == 0) return; }
                if (ctrl.Text != btn_n.Text) { if(dg.CurrentRow == null) return; };
                mfr_usrs mfrc = new mfr_usrs();
                mfrc.is_loaded = true;
                mfrc.is_New = ctrl.Text == btn_n.Text ? true : false;
                mfrc.s_id = ctrl.Text == btn_n.Text ? 0 : (int)dg.CurrentRow.Cells["id"].Value;
                mfrc.owner = this.owner;
                mfrc.load(null, null);
                if (mfrc.ShowDialog(this) == DialogResult.OK)
                { browse_page(pageindex); };
            }

            if (ctrl.Text == btn_d.Text)
            {

                dg.EndEdit();
                var qs = (from DataGridViewRow d in dg.Rows where d.Cells["selected"].Value.Equals(true) select d.Cells["id"].Value);

                if (qs.Count() != 0) { if (MetroMessageBox.Show(this.owner, "Selected record is unrecoverable once deleted? Do you wish to proceed", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return; } else { return; };

                List<int> ids = new List<int>();
                foreach (var q in qs)
                {
                    var qi1 = db.Users.Where(a => a.user_id == (int)q).FirstOrDefault();
                    if (qi1 != null)
                    {

                        db.Permissions.RemoveRange(db.Permissions.Where(a => a.user_id == (int)q));
                        db.Users.Remove(qi1);
                    };

                    int i1 = 0; int.TryParse(q.ToString(), out i1); ids.Add(i1);
                }
                foreach (int i in ids)
                {
                    var dr = (from DataGridViewRow d in dg.Rows where d.Cells["id"].Value.ToString() == i.ToString() select d).FirstOrDefault();
                    dg.Rows.Remove((DataGridViewRow)dr);
                    txt_total.Text = (Convert.ToDouble(txt_total.Text) - 1).ToString();
                }
               db.SaveChanges();
               MetroMessageBox.Show(this.owner, "Deleting complete", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        
        public void refresh(object sender, EventArgs e)
        {
            list(null,null);
            browse_page(1);
        }

        public void search(object sender, EventArgs e)
        {
             gen_method.srch_db(ref dg, txt_db_srch.Text.Trim().ToString(), "code", "full_name");
        }



        public void key_down(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}



