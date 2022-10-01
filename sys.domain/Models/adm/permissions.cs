using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace sys.domain.adm
{
   public class Permissions
    {
     
       public Permissions()
       {
           permission = 0;
       }
         [Key]
       public Int32 permission_id { get; set; }
       public System.Nullable<Int32> user_id { get; set; }
       public string user_code { get; set; }
       public Int16 role_id { get; set; }
       public Int32 permission { get; set; }

       [ForeignKey("role_id")]
       public virtual sys.domain.adm.Roles role { get; set; }

    }
}
