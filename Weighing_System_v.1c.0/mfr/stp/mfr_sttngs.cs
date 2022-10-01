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
    public partial class mfr_sttngs : MetroForm, IClass.IForm
    {
        public mfr_sttngs()
        {
            InitializeComponent();
            init_ports();

            this.Load += new EventHandler(this.load);
            this.KeyDown += new KeyEventHandler(key_down);
        }

        public void set_handlers()
        {
         
        }

        public bool is_loaded
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public mfr_mn2 owner
        {
            get;set;
        }

        public void key_down(object sender, KeyEventArgs e)
        {
            global.select_next_control(this, e);
        }

        public void load(object sender, EventArgs e)
        {
            load_com_stp();
            load_ref_stp();
            load_cam_stp();
        }

        public void back(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void closing(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        //        public void get_prts_lst()
        //        {
        //              var ports = new System.Management.ManagementObjectSearcher( 
        //"Select * from  Win32_PnpEntity ");
        //        //'For Each SP As String In My.Computer.Ports.SerialPortNames
        //        //'    chkPorts.Items.Add(SP)
        //        //'Next

        //            int obj_count = ports.Get().Count -1;

        //            var s = from System.Management.ManagementObject obj in ports.Get() where obj["CAPTION"] != null && obj["CAPTION"].ToString().Contains("(COM")

        //                    cbo_prt.Items.Add(s.FirstOrDefault
        //        }

        public void init_ports()
        {
            cbo_prt.Items.Clear(); cbo_prt.Items.Add("-- Select Port -- ");for (int i = 1; i <= 30; i++) { cbo_prt.Items.Add("COM" +i.ToString());} 
            cbo_br.Items.Clear(); cbo_br.Items.Add("-- Select Baudrate -- ");cbo_br.Items.AddRange(new string[] {"110","300","600","1200","2400","4800","9600","16640","38400","14400","19200","28800","38400","56000","57600","115200"});
            cbo_dbits.Items.Clear(); cbo_dbits.Items.Add("-- Select Databits -- ");cbo_dbits.Items.AddRange(new string[] {"4","5","6","7","8"});
            cbo_sbits.Items.Clear(); cbo_sbits.Items.Add("-- Select Stopbits -- ");cbo_sbits.Items.AddRange(new string[] {"1","1.5","2"});
            cbo_pty.Items.Clear(); cbo_pty.Items.Add("-- Select Parity -- ");cbo_pty.Items.AddRange(new string[] {"Odd","Even","None"});
            cbo_dev.Items.Clear();  cbo_dev.Items.Add("-- Select Device -- ");cbo_dev.Items.AddRange(new string[] {"GSE460","Rinstrum R323", "Rinstrum R323 v2"});
        }

        private void load_com_stp()
        {
            cbo_prt.Text = global.settings.INI_COMMPORTS;
            cbo_br.Text = global.settings.INI_BAUDRATE;
            cbo_dbits.Text = global.settings.INI_DATABITS;
            cbo_sbits.Text = global.settings.INI_STOPBITS;
            cbo_pty.Text = global.settings.INI_PARITY;
            cbo_dev.Text = global.settings.INI_DEV;
        }

        private bool save_com_stp()
        {   global.settings.INI_COMMPORTS = cbo_prt.Text;
            global.settings.INI_BAUDRATE = cbo_br.Text;
            global.settings.INI_DATABITS = cbo_dbits.Text;
            global.settings.INI_STOPBITS = cbo_sbits.Text;
            global.settings.INI_PARITY = cbo_pty.Text;
            global.settings.INI_DEV = cbo_dev.Text;
            global.settings._iniS();
            return true;
        }

        private void load_ref_stp()
        {
            using (sys.domain.DAL.DBContext dbx = new sys.domain.DAL.DBContext(global.main_conn_str))
            {
                txt_refno.Text = dbx.Ref_nos.First().trans_id;
            }
        }

        private bool save_ref_stp()
        {
            //bool result = false;
            using (sys.domain.DAL.DBContext dbx = new sys.domain.DAL.DBContext(global.main_conn_str))
            {
                var refno = dbx.Ref_nos.First();
                refno.ShouldValidateEntry = true;
                refno.trans_id = txt_refno.Text.Trim();
                dbx.Entry(refno).State = EntityState.Modified;

                try
                {
                    dbx.SaveChanges();
                    return true;
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
                    MetroMessageBox.Show(this.owner, vERR.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Stop, msgbox_h); return false;
                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(this.owner, ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }
        }

        private void load_cam_stp()
        {
            txt_ip1.Text = global.settings.CAM_1_IP;
            txt_ip2.Text = global.settings.CAM_2_IP;
            txt_time_out.Text = global.settings.CAM_TIME_OUT;
        }

        private bool save_cam_stp()
        {
            global.settings.CAM_1_IP = txt_ip1.Text;
            global.settings.CAM_2_IP = txt_ip2.Text;
            global.settings.CAM_TIME_OUT = txt_time_out.Text;
            global.settings._iniS();
            return true;
        }

        private void txt_refno_Leave(object sender, EventArgs e)
        {
            int i = 1; int.TryParse(txt_refno.Text.Trim(), out i);
            txt_refno.Text = String.Format("{0:0000000}", i );
        }

        private void btn_dbs_n_Click(object sender, EventArgs e)
        {
            save_com_stp();
            save_cam_stp();
            if (!save_ref_stp()) return;

            MetroMessageBox.Show(owner, "Saving complete", "",MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
