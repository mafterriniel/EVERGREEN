using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sys.domain.dbs
{
    public class Raw_materials
    {
        public Raw_materials()
        {
            //this.Categories = new HashSet<Categories>();
        }

        
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Int32 material_id { get; set; }
        [Key]
        [Required(ErrorMessage = "* Code is required")]
        public string mate_code { get; set; }
        [Required(ErrorMessage = "* Description is required")]
        public string description { get; set; }
        public string category_code { get; set; }
        public string unit_of_ms { get; set; }
        public double price { get; set; }
        public bool is_active { get; set; }
        public string user_reg { get; set; }
        public System.Nullable<DateTime> dt_reg { get; set; }
        public string user_upd { get; set; }
        public System.Nullable<DateTime> dt_upd { get; set; }

        //[ForeignKey("category_code")]
        //public virtual dbs.Categories category { get; set; }

        [ForeignKey("mate_code")]
        public virtual ICollection<trns.Transactions> transactions { get; set; }
 
    }
}
