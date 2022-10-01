using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sys.domain.dbs
{
    public class Clients
    {
       public Clients()
       {
       }

       [NotMapped]
       public bool selected { get; set; }

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Int32 client_id { get; set; }

        [Key]
        [Required(ErrorMessage="* Code is required")]
        public string client_code { get;  set; }

        [Required(ErrorMessage = "* Name is required")]
        public string name { get;  set; }
        public string addr { get; set; }
        public string municipality { get; set; }
        public string contact_person { get; set; }
        public string tel_no { get; set; }
        public string mobile_no { get; set; }
        public bool is_supplier { get; set; }
        public bool is_customer { get; set; }
        public bool is_active { get; set; }
        public string user_reg { get; set; }
        public System.Nullable<DateTime> dt_reg { get; set; }
        public string user_upd { get; set; }
        public System.Nullable<DateTime> dt_upd { get; set; }

        [ForeignKey("client_code")]
        public virtual ICollection<trns.Transactions> transactions { get; set; }
    }
}
