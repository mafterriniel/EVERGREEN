using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sys.domain.ViewModels
{
    public class clnt_lst
    {
        public bool selected { get; set; }
        public System.Nullable<Int64> id { get; set; }
        public string client_code { get; set; }
        public string name { get; set; }
        public string municipality { get; set; }
        public string addr { get; set; }
        public bool is_active { get; set; }
    }
}
