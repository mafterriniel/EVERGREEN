using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weighing_System_v._1c._0.IClass
{
    public  interface IForm
    {
        void set_handlers();
        void load(object sender, EventArgs e);
        void back(object sender, EventArgs e);
        void closing(object sender, EventArgs e);
        void key_down(object sender, System.Windows.Forms.KeyEventArgs e);
        bool is_loaded { get; set; }
        mfr_mn2 owner { get; set; }
    }

}
