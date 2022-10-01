using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sys.domain.dbs
{
    public class Origins
    {
        public Origins()
        {
        }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long origin_id { get; set; }
        [Key]
        [Required(ErrorMessage = "* Code is required")]
        public string origin_code { get; set; }
        [Required(ErrorMessage = "* Name is required")]
        public string origin_name { get; set; }
        public bool is_active { get; set; }
        public string user_reg { get; set; }
        public System.Nullable<DateTime> dt_reg { get; set; }
        public string user_upd { get; set; }
        public System.Nullable<DateTime> dt_upd { get; set; }

        [ForeignKey("origin_code")]
        public virtual ICollection<trns.Transactions> transactions { get; set; }
    }
}
