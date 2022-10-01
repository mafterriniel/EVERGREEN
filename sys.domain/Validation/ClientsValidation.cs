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
    public class ClientsValidation
    {
        public static List<DbValidationError> Validate(DBContext db, System.Data.Entity.Infrastructure.DbEntityEntry entityEntry)
        {
            sys.domain.dbs.Clients t = entityEntry.Entity as sys.domain.dbs.Clients;
            StringBuilder eRR = new StringBuilder();
            List<DbValidationError> result = new List<DbValidationError>();
            //System.Text.RegularExpressions.Regex mtch;

            if (t.client_code != string.Empty)
            {
                if (entityEntry.State == EntityState.Added) if (db.Clients.Where(EF_expressions.wh_n_clnt_c(t.client_code)).Count() != 0) eRR.AppendLine("* Code already exists.");
                if (entityEntry.State == EntityState.Modified) if (db.Clients.Where(EF_expressions.wh_e_clnt_c(t.client_code, t.client_id)).Count() != 0) eRR.AppendLine("* Code already exists.");
            }

            if (t.name != string.Empty)
            {
                if (entityEntry.State == EntityState.Added) if (db.Clients.Where(EF_expressions.wh_n_clnt_n(t.name)).Count() != 0) eRR.AppendLine("* Name already exists.");
                if (entityEntry.State == EntityState.Modified) if (db.Clients.Where(EF_expressions.wh_e_clnt_n(t.name, t.client_id)).Count() != 0) eRR.AppendLine("* Name already exists.");
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
