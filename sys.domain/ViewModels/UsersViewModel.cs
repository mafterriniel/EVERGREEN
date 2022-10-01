using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sys.domain.ViewModels
{
    public class usr_lst
    {
        public bool selected { get; set; }
        public System.Nullable<Int64> id { get; set; }
        public string user_code { get; set; }
        public string first_name { get; set; }
        public string middle_initial { get; set; }
        public string last_name { get; set; }
        public string name_suffix { get; set; }
        public string login_id { get; set; }
        public string full_name
        {
            get
            {

                return first_name + " " + middle_initial + "  " + last_name;
            }
        }
        public string position { get; set; }
        public string contact_num { get; set; }
       
        public bool is_active { get; set; }
    }
}
