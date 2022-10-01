using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sys.domain.ViewModels
{
    public class orgn_lst
    {
        public bool selected { get; set; }
        public System.Nullable<Int64> id { get; set; }
        public string origin_code { get; set; }
        public string origin_name { get; set; }
        public bool is_active { get; set; }
    }
}
