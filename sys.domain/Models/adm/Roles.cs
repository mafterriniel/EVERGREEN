using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sys.domain.adm
{
  public  class Roles
    {
      [Key]
      public Int16 role_id { get; set; }
      public string description { get; set; }
      public bool is_active { get; set; }
    }
}
