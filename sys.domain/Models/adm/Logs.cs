using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace sys.domain.adm
{
   public class logs
    {

       public logs()
       {
       }
       [Key]
       [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
       public long log_id { get; set; }
       public System.Nullable<DateTime> log_dt { get; set; }
       public string log_type { get; set; }
       public Int32 action_id { get; set; }
       public string record_no { get; set; }
       public string details { get; set; }
       public string user_name { get; set; }
       public string comments { get; set; }

       //[ForeignKey("receipt_no")]
       //public virtual sys.domain.trns.Transactions transaction { get; set; }

       [ForeignKey("action_id")]
       public virtual sys.domain.adm.Actions action { get; set; }
       [NotMapped]
       public string action_desc { get { return action == null ? "" : action.description; } }

    }
}
