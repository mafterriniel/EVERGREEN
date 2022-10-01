using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sys.domain.ViewModels
{
    public class mate_lst
    {
        public bool selected { get; set; }
        public System.Nullable<Int64> id { get; set; }
        public string mate_code { get; set; }
        public string description { get; set; }
        public string price { get; set; }
        public bool is_active { get; set; }
    }
}
