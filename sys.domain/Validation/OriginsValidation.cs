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
    public class OriginsValidation
    {
        public static List<DbValidationError> Validate(DBContext db, System.Data.Entity.Infrastructure.DbEntityEntry entityEntry)
        {
            sys.domain.dbs.Origins t = entityEntry.Entity as sys.domain.dbs.Origins;
            StringBuilder eRR = new StringBuilder();
            List<DbValidationError> result = new List<DbValidationError>();
            //System.Text.RegularExpressions.Regex mtch;

            if (t.origin_code != string.Empty)
            {
                if (entityEntry.State == EntityState.Added) if (db.Origins.Where(EF_expressions.wh_n_org_c(t.origin_code)).Count() != 0) eRR.AppendLine("* Code already exists.");
                if (entityEntry.State == EntityState.Modified) if (db.Origins.Where(EF_expressions.wh_e_org_c(t.origin_code, t.origin_id)).Count() != 0) eRR.AppendLine("* Code already exists.");
            }

            if (t.origin_name != string.Empty)
            {
                if (entityEntry.State == EntityState.Added) if (db.Origins.Where(EF_expressions.wh_n_org_n(t.origin_name)).Count() != 0) eRR.AppendLine("* Name already exists.");
                if (entityEntry.State == EntityState.Modified) if (db.Origins.Where(EF_expressions.wh_e_org_n(t.origin_name, t.origin_id)).Count() != 0) eRR.AppendLine("* Name already exists.");
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
    }
}
