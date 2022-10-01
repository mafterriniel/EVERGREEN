using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sys.domain.trns
{
    public class Trashed
    {
        public Trashed()
        {

        }
        [NotMapped]
        public bool selected { get; set; }

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public System.Nullable<Int64> transaction_id { get; set; }
        [Key]
        public string receipt_no { get; set; }
        public Nullable<System.DateTime> dt_in { get; set; }
        public Nullable<System.DateTime> dt_out { get; set; }
        public string license_plate { get; set; }
        public string container_no { get; set; }
        public string client_code { get; set; }
        public string mate_code { get; set; }
        public string origin_code { get; set; }
        public Nullable<Double> in_wt { get; set; }
        public Nullable<Double> out_wt { get; set; }
        public Nullable<Double> net_wt { get; set; }
        public Nullable<System.DateTime> reg_dt { get; set; }
        public string waiting_time { get; set; }
        public string elapsed_time { get; set; }
        public string DNNo { get; set; }
        public string dr_no { get; set; }
        public string dn_no { get; set; }
        public string gate_pass { get; set; }
        public string remarks { get; set; }
        public string driver_name { get; set; }
        public string weigher_in { get; set; }
        public string weigher_out { get; set; }
        public Nullable<int> re_print_ctr { get; set; }
        public string station_code { get; set; }
        public string check_code { get; set; }
        public string checker_name { get; set; }
        public Nullable<decimal> wt_declared_in_dr { get; set; }
        public Nullable<decimal> wt_diff_vs_ts { get; set; }
        public string series_no { get; set; }
        public string MOTO { get; set; }
        public string premium { get; set; }
        public string other { get; set; }
        public string pp_phr { get; set; }
        public string init_tag { get; set; }
        public string final_tag { get; set; }
        //[RegularExpression("^\\-?[0-9]{1,3}(\\,[0-9]{3})*(\\.[0-9]+)?$|^[0-9]+(\\.[0-9]+)?$",ErrorMessage="Number of pallets must be numeric")]
        public Nullable<decimal> pallet_count { get; set; }
        public Nullable<decimal> wt_per_tag { get; set; }
        public Nullable<decimal> moisture { get; set; }
        public string po_no { get; set; }
        public string gr_no { get; set; }
        public string t_type { get; set; }
        public System.Nullable<DateTime> tracker_dt { get; set; }
        public Nullable<Int32> tracker_col { get; set; }
        public System.Nullable<Boolean> in_offline { get; set; } 
        public System.Nullable<Boolean>out_offline {get;set;}
        public Nullable<DateTime> dt_stamp { get; set; }
    


    }
}
