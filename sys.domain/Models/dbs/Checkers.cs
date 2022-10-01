using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sys.domain.dbs
{
    public class Checkers
    {
        public Checkers()
        {

        }

        [NotMapped]
        public bool selected { get; set; }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public long checker_id { get; set; }
        public string checker_name { get; set; }
    }
}
