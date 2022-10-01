using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigiD
{
   
   public partial class LED : UserControl
    {

        private Bitmap[] bmp = new Bitmap[8];
        private int digit_h = 99 ;
        private int digit_w = 78;
        private int align_top = 1;

        public string Acs_pwd { get; set; }  
        private string _Output;
        public string Output
        {
            get
            {
                return _Output;
            }
            set
            {
                _Output = value;
                this.Refresh();
                OnOutputChanged();
            }
        }
     
        public LED()
        {
            InitializeComponent();
            Acs_pwd = "ZakiAndJoan1222";
            _Output = "-16040.5";

        }

        private void LED_Load(object sender, EventArgs e)
        {

            this.Refresh();

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            digit_h = Convert.ToInt32(.99 * Height);
            digit_w = Convert.ToInt32(.1809 * Width);

            bmp[0] = new Bitmap(global::DigiD.Properties.Resources.no_val, digit_w, digit_h);
            bmp[1] = new Bitmap(global::DigiD.Properties.Resources.no_val, digit_w, digit_h);
            bmp[2] = new Bitmap(global::DigiD.Properties.Resources.no_val, digit_w, digit_h);
            bmp[3] = new Bitmap(global::DigiD.Properties.Resources.no_val, digit_w, digit_h);
            bmp[4] = new Bitmap(global::DigiD.Properties.Resources.no_val, digit_w, digit_h);
            bmp[5] = new Bitmap(global::DigiD.Properties.Resources.no_val, digit_w, digit_h);
            bmp[6] = new Bitmap(global::DigiD.Properties.Resources.no_val, digit_w, digit_h);
            bmp[7] = new Bitmap(global::DigiD.Properties.Resources.no_val, digit_w, digit_h);

            if (Acs_pwd != "ZakiAndJoan1222") return;
            int tlength =  _Output.Length;
            int b = tlength - 1;
            for (int i = 0; i <= tlength - 1; i++)
            {

                bmp[b] = digit(_Output[i].ToString());

                b -= 1;
            }

            //e.Graphics.Clear(Color.Transparent);

            e.Graphics.DrawImage(bmp[0], new Point(Convert.ToInt32(this.Width *.8097),Convert.ToInt32(this.Height * .01)));
            e.Graphics.DrawImage(bmp[1], new Point(Convert.ToInt32(this.Width * .6937), Convert.ToInt32(this.Height * .01)));
            e.Graphics.DrawImage(bmp[2], new Point(Convert.ToInt32(this.Width * .5777), Convert.ToInt32(this.Height * .01)));
            e.Graphics.DrawImage(bmp[3], new Point(Convert.ToInt32(this.Width * .4617),Convert.ToInt32(this.Height * .01)));
            e.Graphics.DrawImage(bmp[4], new Point(Convert.ToInt32(this.Width * .3457),Convert.ToInt32(this.Height *.01)));
            e.Graphics.DrawImage(bmp[5], new Point(Convert.ToInt32(this.Width * .2297),Convert.ToInt32(this.Height * .01)));
            e.Graphics.DrawImage(bmp[6], new Point(Convert.ToInt32(this.Width * .1137), Convert.ToInt32(this.Height * .01)));
            e.Graphics.DrawImage(bmp[7], new Point(Convert.ToInt32(this.Width * -.0023), align_top));
            base.OnPaint(e);
        }

        private Bitmap digit(string s)
        {
            Bitmap bmp = new Bitmap(global::DigiD.Properties.Resources.no_val, digit_w, digit_h);
            switch (s)
            {
                case "0": bmp = new Bitmap(global::DigiD.Properties.Resources._0, digit_w, digit_h);
                    break;
                case "1": bmp = new Bitmap(global::DigiD.Properties.Resources.one, digit_w, digit_h);
                    break;
                case "2": bmp = new Bitmap(global::DigiD.Properties.Resources.two, digit_w, digit_h);
                    break;
                case "3": bmp = new Bitmap(global::DigiD.Properties.Resources.three, digit_w, digit_h);
                    break;
                case "4": bmp = new Bitmap(global::DigiD.Properties.Resources.four, digit_w, digit_h);
                    break;
                case "5": bmp = new Bitmap(global::DigiD.Properties.Resources.five, digit_w, digit_h);
                    break;
                case "6": bmp = new Bitmap(global::DigiD.Properties.Resources.six, digit_w, digit_h);
                    break;
                case "7": bmp = new Bitmap(global::DigiD.Properties.Resources.seven, digit_w, digit_h);
                    break;
                case "8": bmp = new Bitmap(global::DigiD.Properties.Resources._8, digit_w, digit_h);
                    break;
                case "9": bmp = new Bitmap(global::DigiD.Properties.Resources.nine, digit_w, digit_h);
                    break;
                case "-": bmp = new Bitmap(global::DigiD.Properties.Resources.minus, digit_w, digit_h);
                    break;
                case ".": bmp = new Bitmap(global::DigiD.Properties.Resources.dot, digit_w, digit_h);
                    break;
            }

            return bmp;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            this.Refresh();
            base.OnSizeChanged(e);
        }

        protected override void OnResize(EventArgs e)
        {
            this.Refresh();
            base.OnResize(e);
        }


        public event System.EventHandler OutputChanged;
        protected virtual void OnOutputChanged()
        {
            if (OutputChanged != null) OutputChanged(this, EventArgs.Empty);
        }   



     
    }


}
