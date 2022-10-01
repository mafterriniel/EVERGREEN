using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace sys.domain.adm
{
   public class Actions
    {

       public Actions()
       {
       }
       [Key]
       [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
       public int action_id{ get; set; }
       public string description { get; set; }

       [ForeignKey("action_id")]
       public virtual ICollection<sys.domain.adm.logs> transaction_logs { get; set; }

    }
}
