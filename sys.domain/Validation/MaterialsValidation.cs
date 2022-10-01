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
    public class MaterialsValidation
    {
        public static List<DbValidationError> Validate(DBContext db, System.Data.Entity.Infrastructure.DbEntityEntry entityEntry)
        {
            sys.domain.dbs.Raw_materials t = entityEntry.Entity as sys.domain.dbs.Raw_materials;
            StringBuilder eRR = new StringBuilder();
            List<DbValidationError> result = new List<DbValidationError>();
            //System.Text.RegularExpressions.Regex mtch;

            if (t.mate_code != string.Empty)
            {
                if (entityEntry.State == EntityState.Added) if (db.Raw_materials.Where(EF_expressions.wh_n_mat_c(t.mate_code)).Count() != 0) eRR.AppendLine("* Code already exists.");
                if (entityEntry.State == EntityState.Modified) if (db.Raw_materials.Where(EF_expressions.wh_e_mat_c(t.mate_code, t.material_id)).Count() != 0) eRR.AppendLine("* Code already exists.");
            }

            if (t.description != string.Empty)
            {
                if (entityEntry.State == EntityState.Added) if (db.Raw_materials.Where(EF_expressions.wh_n_mat_d(t.description)).Count() != 0) eRR.AppendLine("* Description already exists.");
                if (entityEntry.State == EntityState.Modified) if (db.Raw_materials.Where(EF_expressions.wh_e_mat_d(t.description, t.material_id)).Count() != 0) eRR.AppendLine("* Description already exists.");
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
