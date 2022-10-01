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
    public enum custom_state
    {
        INBOUND_ONLINE, INBOUND_OFFLINE, OUTBOUND_ONLINE, OUTBOUND_OFFLINE, MODIFIED, DELETED
    }


    public class Transactions
    {
        public Transactions()
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
        public string truckscale_no { get; set; }

        [Required(ErrorMessage = "* License plate is required.")]
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
        public Nullable<Int32> time_reg_col { get; set; }
        public Nullable<Int32> dt_in_col { get; set; }
        public Nullable<Int32> dt_out_col { get; set; }
        public System.Nullable<Boolean> in_offline { get; set; }
        public System.Nullable<Boolean> out_offline { get; set; }
        public Nullable<DateTime> dt_stamp { get; set; }
        public byte[] image_1 { get; set; }
        public byte[] image_2 { get; set; }

        [NotMapped]
        public System.Drawing.Image image_1_view
        {
            get
            {
                if (image_1 == null ) return null;
                if (image_1.Count() == 0) return null;
                System.IO.MemoryStream ms = new System.IO.MemoryStream(image_1);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                return img;
            }
        }

        [NotMapped]
        public System.Drawing.Image image_2_view
        {
            get
            {
                if (image_2 == null) return null;
                if (image_2.Count() == 0) return null;
                System.IO.MemoryStream ms = new System.IO.MemoryStream(image_2);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                return img;
            }
        }

        [NotMapped]
        public sys.domain.Validation.TransactionValidation.WEIGHIN_STATE WEIGHING_STATE { get; set; }
        [NotMapped]
        public bool REPRINT { get; set; }
        [NotMapped]
        public bool VALIDATE { get; set; }
        [NotMapped]
        public bool LOG_COMMENTS { get; set; }
        /// <summary>
        /// / custom fields
        /// </summary>

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

        public Double adj
        {
            get
            {
                Double _in_t_h = 0;
                Double _out_t_h = 0;
                Double _adj = 0;


                _adj = _in_t_h - _out_t_h;

                return _adj;
            }
        }

        [NotMapped]
        public Double total_net
        {
            get
            {
                Double _in_t_h = 0;
                Double _out_t_h = 0;
                Double _adj = 0;
                Double _net = 0;


                _adj = _in_t_h - _out_t_h;

                _net = (gross_wt - tare_wt) - _adj;

                return _net;
            }
        }

        [NotMapped]
        public System.Nullable<DateTime> gross_dt
        {
            get
            {
                Double _in_wt = 0;
                Double _out_wt = 0;
                if (in_wt.HasValue) _in_wt = in_wt.Value;
                if (out_wt.HasValue) _out_wt = out_wt.Value;
                return _in_wt > _out_wt ? dt_in : dt_out;
            }
        }

        [NotMapped]
        public System.Nullable<DateTime> tare_dt
        {
            get
            {
                Double _in_wt = 0;
                Double _out_wt = 0;
                if (in_wt.HasValue) _in_wt = in_wt.Value;
                if (out_wt.HasValue) _out_wt = out_wt.Value;
                return _in_wt < _out_wt ? dt_in : dt_out;
            }
        }

        [NotMapped]
        public string waiting_time_str
        {
            get
            {

                if (waiting_time == null) return "--:--";
                string hr_w = waiting_time != null ? waiting_time.ToString().Split(".".ToCharArray())[0].Trim() : "0";
                string mn_w = waiting_time != null ? waiting_time.ToString().Split(".".ToCharArray())[1].Trim() : "0";
                return hr_w + " hrs. & " + mn_w + " mins.";
            }
        }

        [NotMapped]
        public string elapsed_time_str
        {
            get
            {
                if (elapsed_time == null) return "--:--";
                string hr_w = elapsed_time != null ? elapsed_time.ToString().Split(".".ToCharArray())[0].Trim() : "0";
                string mn_w = elapsed_time != null ? elapsed_time.ToString().Split(".".ToCharArray())[1].Trim() : "0";
                return hr_w + " hrs. & " + mn_w + " mins.";
            }
        }


        /// <summary>
        ///  Sub tables
        /// </summary>
        ///      

        [ForeignKey("client_code")]
        public virtual dbs.Clients client { get; set; }
        [NotMapped]
        public string client_name { get { return client == null ? "" : client.name; } }

        [ForeignKey("mate_code")]
        public virtual dbs.Raw_materials raw_material { get; set; }
        [NotMapped]
        public string mate_desc { get { return raw_material == null ? "" : raw_material.description; } }

        [ForeignKey("weigher_in")]
        public virtual adm.Users user_in { get; set; }
        [NotMapped]
        public string weigher_in_name { get { return user_in == null ? "" : user_in.full_name; } }

        [ForeignKey("weigher_out")]
        public virtual adm.Users user_out { get; set; }
        [NotMapped]
        public string weigher_out_name { get { return user_out == null ? "" : user_out.full_name; } }

        [ForeignKey("station_code")]
        public virtual dbs.Stations station { get; set; }
        [NotMapped]
        public string station_name { get { return station == null ? "" : station.station_name; } }

        [ForeignKey("origin_code")]
        public virtual dbs.Origins origin { get; set; }
        [NotMapped]
        public string origin_name { get { return origin == null ? "" : origin.origin_name; } }

        [NotMapped]
        public string _commodity { get; set; }
        [NotMapped]
        public string _client { get; set; }
        [NotMapped]
        public string _moisture { get; set; }
        [NotMapped]
        public string _wt_dc { get; set; }
        [NotMapped]
        public string _pallet_count { get; set; }
        [NotMapped]
        public string _wt_per_tag { get; set; }
        [NotMapped]
        public string _origin { get; set; }


        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    DbContext db = validationContext;

        //}


    }
}
