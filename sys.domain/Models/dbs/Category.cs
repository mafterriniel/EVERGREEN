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
    public class Categories
    {
        public Categories()
        {
        }

         [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Int32 category_id { get; set; }
         [Key]
        public string category_code { get; set; }
        public string name { get; set; }
        public string unit_of_ms { get; set; }
        public double price { get; set; }
        public bool is_active { get; set; }
        public string user_reg { get; set; }
        public System.Nullable<DateTime> dt_reg { get; set; }
        public string user_upd { get; set; }
        public System.Nullable<DateTime> dt_upd { get; set; }

        [ForeignKey("category_code")]
        public virtual ICollection<dbs.Raw_materials> raw_materials { get; set; }


    }
}
