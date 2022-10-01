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
    public class RefnoValidation
    {
        public static List<DbValidationError> Validate(DBContext db, System.Data.Entity.Infrastructure.DbEntityEntry entityEntry)
        {
            sys.domain.trns.Ref_no t = entityEntry.Entity as sys.domain.trns.Ref_no;
            StringBuilder eRR = new StringBuilder();
            List<DbValidationError> result = new List<DbValidationError>();

            if (t.ShouldValidateEntry == false) return result;
            
            int tid = 1; bool is_numeric = int.TryParse(t.trans_id.Trim(), out tid);

            if (!is_numeric) eRR.AppendLine("Reference number should a valid numeric value");

            var cnt = db.Transactions.Where(a => a.receipt_no == t.trans_id).Count(); if (cnt >0) eRR.AppendLine("* Reference number already exists.");


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
