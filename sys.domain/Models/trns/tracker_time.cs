using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sys.domain.trns
{
    public class Tracker_time
    {
        public Tracker_time()
        {

        }
        [Key]
        public int id { get; set; }
        public string time { get; set; }
    }
}
