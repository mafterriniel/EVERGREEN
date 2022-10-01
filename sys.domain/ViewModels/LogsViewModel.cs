using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sys.domain.ViewModels
{
    public class log_lst
    {
        public bool selected { get; set; }
        public long id { get; set; }
        public System.Nullable<DateTime> log_dt { get; set; }
        public string log_type { get; set; }
        public string action_desc { get; set; }
        public string record_no { get; set; }
        public string details { get; set; }
        public string comments { get; set; }
        public string user_name { get; set; }
    }
}
