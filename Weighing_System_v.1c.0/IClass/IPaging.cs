using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weighing_System_v._1c._0.IClass
{
    interface IPaging
    {
        void list(object sender, EventArgs e);
        void set_dg();
        int pageindex { get; set; }
        int pagesize { get; set; }
        int pagelimit { get; set; }
        int total_page { get; set; }

        void set_pagination_event_handlers();

        void browse_page(int pg_num);

        void next_page(object sender, EventArgs e);

        void prev_page(object sender, EventArgs e);

        void proceed(object sender, EventArgs e);

        void refresh(object sender, EventArgs e);

        void search(object sender, EventArgs e);

    }
}
