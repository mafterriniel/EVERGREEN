using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sys.domain.dbs
{
   public class Drivers
    {
       public Drivers()
       {

       }
       [NotMapped]
        public bool selected { get; set; }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
       [Key]
        public long driver_id {get; set; }
        public string driver_name { get; set; }
        public string license_plate { get; set; }


    }
}
