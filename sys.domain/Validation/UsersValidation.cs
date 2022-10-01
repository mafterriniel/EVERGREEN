using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Data.Entity;
using sys.domain.DAL;

namespace sys.domain.Validation
{
    public class UsersValdation
    {
        public static List<DbValidationError> Validate(DBContext db, System.Data.Entity.Infrastructure.DbEntityEntry entityEntry)
        {
            sys.domain.adm.Users t = entityEntry.Entity as sys.domain.adm.Users;
            StringBuilder eRR = new StringBuilder();
            List<DbValidationError> result = new List<DbValidationError>();
            //System.Text.RegularExpressions.Regex mtch;
            if (t.VALIDATE)
            {
                if (t.user_code != string.Empty)
                {
                    if (entityEntry.State == EntityState.Added) if (db.Users.Where(EF_expressions.wh_n_usr_c(t.user_code)).Count() != 0) eRR.AppendLine("* Code already exists.");
                    if (entityEntry.State == EntityState.Modified) if (db.Users.Where(EF_expressions.wh_e_usr_c(t.user_code, t.user_id)).Count() != 0) eRR.AppendLine("* Code already exists.");
                }

                if (t.full_name != string.Empty)
                {
                    if (entityEntry.State == EntityState.Added) if (db.Users.Where(EF_expressions.wh_n_usr_n(t.first_name, t.middle_initial, t.last_name)).Count() != 0) eRR.AppendLine("* Name already exists.");
                    if (entityEntry.State == EntityState.Modified) if (db.Users.Where(EF_expressions.wh_e_usr_n(t.first_name, t.middle_initial, t.last_name, t.user_id)).Count() != 0) eRR.AppendLine("* Name already exists.");
                }

                if (t.login_id != string.Empty)
                {
                    if (entityEntry.State == EntityState.Added) if (db.Users.Where(EF_expressions.wh_usr_n_lgid(t.login_id)).Count() != 0) eRR.AppendLine("* login id already exists.");
                    if (entityEntry.State == EntityState.Modified) if (db.Users.Where(EF_expressions.wh_usr_e_lgid(t.login_id, t.user_id)).Count() != 0) eRR.AppendLine("* login id already exists.");
                }

                if (t.login_pwd != string.Empty)
                {
                    if (t.login_pwd != t.login_pwd_confirmation) { eRR.AppendLine("* Password Confirmation doesn't match"); }
                }
            }
            System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
            txt.Text = eRR.ToString();
            for (int i = 0; i <= txt.Lines.Count() - 1; i++)
            {
                string tl = txt.Lines[i].ToString();
                if (tl != string.Empty) result.Add(new DbValidationError("", tl));
            }

            return result;
        }

        public static void validationOK(DBContext db, System.Data.Entity.Infrastructure.DbEntityEntry entityEntry)
        {
            try
            {
                sys.domain.adm.Users t = entityEntry.Entity as sys.domain.adm.Users;

                AuditTrails.create_log(db, entityEntry);

                if  (entityEntry.State == EntityState.Deleted)
                {   
                    db.Permissions.RemoveRange(db.Permissions.Where(a => a.user_code == t.user_code));
                }

                if (t.VALIDATE)
                {
                     
                }

                t.LOGGED_IN = false;
                t.LOGGED_OUT = false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}
