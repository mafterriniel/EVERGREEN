using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weighing_System_v._1c._0.IClass
{
    interface IDb_m
    {
        Int64 s_id { get; set; }
        bool is_New { get; set; }
        void view();
        void save(object sender, EventArgs e);
        void cancel(object sender, EventArgs e);
    }
}
