using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sys.domain.Classes
{
    public class custom_culture
    {
        public static  void setCustomCulture()
        {
            System.Globalization.CultureInfo customCulture = new System.Globalization.CultureInfo("en-PH",true);
            customCulture.DateTimeFormat.SetAllDateTimePatterns(new string[] { "dd/MMM/yyyy HH:mm" }, 'd');
            customCulture.DateTimeFormat.ShortDatePattern = "dd/MMM/yyyy";
            customCulture.DateTimeFormat.LongDatePattern = "dd/MMM/yyyy";
            customCulture.DateTimeFormat.ShortTimePattern = "HH:mm:ss";
            customCulture.DateTimeFormat.LongTimePattern = "HH:mm:ss";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = customCulture;
        }
    }
}
