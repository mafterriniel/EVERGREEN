using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace sys.domain.adm
{
    public class Users
    {
        public Users()
        {
            first_name = "";
            last_name = "";
            middle_initial = "";
        }

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Int32 user_id { get; set; }
        [Key]
        [Required(ErrorMessage = "* User code is required")]
        public string user_code { get; set; }
        [Required(ErrorMessage = "* Login id is required")]
        public string login_id { get; set; }
        [Required(ErrorMessage = "* Password is required")]
        public string login_pwd { get; set; }
        [NotMapped]
        //[Compare("login_pwd", ErrorMessage = "* Password Confirmation doesn't match")]
        public string login_pwd_confirmation { get; set; }
        [NotMapped]
        public string crypted_password
        {
            get
            {
                if (login_pwd == string.Empty) return "";
                Classes._crypter crypter = new Classes._crypter("JOJO");
                login_pwd = crypter.DecryptData(login_pwd);
                return login_pwd;
            }
            set
            {
                if (value != string.Empty)
                {
                    Classes._crypter crypter = new Classes._crypter("JOJO");
                    login_pwd = crypter.EncryptData(value);
                }
            }
        }

        [Required(ErrorMessage = "* First name is required")]
        public string first_name { get; set; }
        public string middle_initial { get; set; }
        [Required(ErrorMessage = "* Last name is required")]
        public string last_name { get; set; }
        public string name_suffix { get; set; }
        public string position { get; set; }
        public bool is_active { get; set; }
        public System.Nullable<DateTime> last_login_date { get; set; }
        public string user_reg { get; set; }
        public System.Nullable<DateTime> dt_reg { get; set; }
        public string user_upd { get; set; }
        public System.Nullable<DateTime> dt_upd { get; set; }
        public string contact_num { get; set; }
        public string full_name
        {
            get
            {

                return first_name + " " + middle_initial + "  " + last_name;
            }
        }

        [NotMapped]
        public bool LOGGED_IN { get; set; }
        [NotMapped]
        public bool LOGGED_OUT { get; set; }
        private bool _VALIDATE;
        [NotMapped]
        public bool VALIDATE { get { return _VALIDATE; } set { _VALIDATE = value; } }

        [ForeignKey("weigher_in")]
        public virtual ICollection<sys.domain.trns.Transactions> transactions { get; set; }

        [ForeignKey("user_code")]
        public virtual ICollection<sys.domain.adm.Permissions> permissions { get; set; }

    }
}
