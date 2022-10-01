using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sys.domain.trns
{
    public class Ref_no
    {
        [Key]
        public Int32 ref_no_id { get; set; }
        public string purchase_id { get; set; }
        public string sales_id { get; set; }
        public string finished_id { get; set; }
        public string transfer_id { get; set; }
        public string voucher_no { get; set; }
        public string trans_id { get; set; }
        [NotMapped]
        public bool ShouldValidateEntry { get; set; }
    }
}
