using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sys.domain.dbs
{
    public class Stations
    {
        public Stations() { }


        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Int32 station_id { get; set; }
        [Key]
        public string station_code { get; set; }
        public string station_name { get; set; }
        public string location { get; set; }
        public string signatory { get; set; }
        public string tel_no { get; set; }
        public bool is_selected { get; set; }
        public bool is_active { get; set; }
        public string user_reg { get; set; }
        public System.Nullable<DateTime> dt_reg { get; set; }
        public string user_upd { get; set; }
        public System.Nullable<DateTime> dt_upd { get; set; }

        private string _st_c_n;
        [NotMapped]
        public string st_c_n
        {
            get { return this == null ? "N/A" : station_code + "-" + station_name; }
            set { _st_c_n = value; }
        }

        [ForeignKey("station_code")]
        public virtual ICollection<trns.Transactions> transactions { get; set; }

    }
}