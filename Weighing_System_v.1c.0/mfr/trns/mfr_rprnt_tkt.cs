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
    public partial class mfr_rprnt_tkt : MetroForm
    {

        public mfr_rprnt_tkt()
        {
            InitializeComponent();

            this.Load += new EventHandler(this.load);
        }

        public bool is_new { get; set; }
        public sys.domain.Validation.TransactionValidation.TICKET_STATE state;

        public sys.domain.Validation.TransactionValidation.TICKET_STATE ticket_state { get; set; }

        public sys.domain.trns.Transactions s_entity { get; set; }
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

        public void load(object sender, EventArgs e)
        {
            //if (is_new) btn_re_print.Enabled = false;
        }


        private void btn_in_Click(object sender, EventArgs e)
        {
            ticket_state = sys.domain.Validation.TransactionValidation.TICKET_STATE.WEIGH_IN;
        }

        private void btn_out_Click(object sender, EventArgs e)
        {
            ticket_state = sys.domain.Validation.TransactionValidation.TICKET_STATE.WEIGH_OUT;
        }

        private void btn_all_Click(object sender, EventArgs e)
        {
            ticket_state = sys.domain.Validation.TransactionValidation.TICKET_STATE.ALL;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
