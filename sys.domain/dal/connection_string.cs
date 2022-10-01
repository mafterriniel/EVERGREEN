using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sys.domain
{
   public class connection_string
    {
       public string connection
       {
           get
           {
               return "Data source = " + datasource +
                      ";initial catalog=" + catalog +
                      ";user id=" + user_id +
                      ";password=" + password +
                      ";integrated security=" + integrated_security.ToString() +
                       ";MultipleActiveResultSets=true";
            }
       }

        public string provider { get; set; }
        public string datasource { get; set; }
        public string catalog { get; set; }
        public string user_id { get; set; }
        public string password { get; set; }
        public bool integrated_security { get; set; }
        public string custom_string { get; set; }


    }
}
