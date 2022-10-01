using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace sys.domain.ViewModels
{
    public class w_in_list
    {
        public bool selected { get; set; }
        public System.Nullable<Int64> transaction_id { get; set; }
        public string receipt_no { get; set; }
        public string license_plate { get; set; }
        public System.Nullable<DateTime> dt_in { get; set; }
        public System.Nullable<Double> in_wt { get; set; }
        public string client_name { get; set; }
        public string commodity { get; set; }
        public string origin { get; set; }
        public string driver_name { get; set; }
        public string weigher_in { get; set; }
    }
    public class w_out_list
    {
        public bool selected { get; set; }
        public System.Nullable<Int64> transaction_id { get; set; }
        public string receipt_no { get; set; }
        public string license_plate { get; set; }
        public System.Nullable<DateTime> dt_in { get; set; }
        public System.Nullable<DateTime> dt_out { get; set; }
        public System.Nullable<Double> in_wt { get; set; }
        public System.Nullable<Double> out_wt { get; set; }
        [NotMapped]
        public Double gross_wt
        {
            get
            {
                Double _in_wt = 0;
                Double _out_wt = 0;
                if (in_wt.HasValue) _in_wt = in_wt.Value;
                if (out_wt.HasValue) _out_wt = out_wt.Value;
                return _in_wt > _out_wt ? _in_wt : _out_wt;
            }
        }

        [NotMapped]
        public Double tare_wt
        {
            get
            {
                Double _in_wt = 0;
                Double _out_wt = 0;
                if (in_wt.HasValue) _in_wt = in_wt.Value;
                if (out_wt.HasValue) _out_wt = out_wt.Value;
                return _in_wt < _out_wt ? _in_wt : _out_wt;
            }
        }

        public System.Nullable<Double> net_wt { get; set; }
        public Nullable<System.DateTime> reg_dt { get; set; }
        public string waiting_time { get; set; }
        public string elapsed_time { get; set; }
        public string client_name { get; set; }
        public string commodity { get; set; }
        public string origin_name { get; set; }
        public string origin { get; set; }
        public string driver_name { get; set; }
        public string weigher_in { get; set; }
        public string weigher_out { get; set; }
        public string waiting_time_str
        {
            get
            {
                if (waiting_time == null) return "--:--";
                string hr_w = waiting_time!=null? waiting_time.ToString().Split(".".ToCharArray())[0] : "0";
                string mn_w = waiting_time!=null ? waiting_time.ToString().Split(".".ToCharArray())[1] : "0";
                return hr_w + " hrs. & " + mn_w + " mins.";
            }
        }

        public string elapsed_time_str
        {
            get
            {
                if (elapsed_time == null) return "--:--";
                string hr_w = elapsed_time != null ? elapsed_time.ToString().Split(".".ToCharArray())[0] : "0";
                string mn_w = elapsed_time != null ? elapsed_time.ToString().Split(".".ToCharArray())[1] : "0";
                return hr_w + " hrs. & " + mn_w + " mins.";
            }
        }


    }

 
}
