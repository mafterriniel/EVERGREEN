using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Data.Entity;
using sys.domain.DAL;
using System.ComponentModel;

namespace sys.domain.Validation
{
    public static class TransactionValidation
    {
        public enum WEIGHIN_STATE
        {
            WEIGH_IN,WEIGH_OUT,UPDATE,NONE
        }

        public enum TICKET_STATE
        {
            WEIGH_IN,WEIGH_OUT,ALL
        }

        public static List<DbValidationError> Validate(DBContext db, System.Data.Entity.Infrastructure.DbEntityEntry entityEntry)
        {
           
          
            sys.domain.trns.Transactions t = entityEntry.Entity as sys.domain.trns.Transactions;

            var orig = db.Transactions.Where(a => a.transaction_id == t.transaction_id).FirstOrDefault();
            //System.Windows.Forms.MessageBox.Show(orig.license_plate);
            StringBuilder eRR = new StringBuilder();
            List<DbValidationError> result = new List<DbValidationError>();
            if (t.VALIDATE)
            {
                if (entityEntry.State == EntityState.Added) t.receipt_no = db.Ref_nos.Select(a => a.trans_id).First();

                if (t.WEIGHING_STATE == WEIGHIN_STATE.WEIGH_IN || t.WEIGHING_STATE == WEIGHIN_STATE.WEIGH_OUT)
                {
                    if (entityEntry.State == EntityState.Added) if (t.in_wt == 0) eRR.AppendLine("* Weight is invalid.");
                    if (entityEntry.State == EntityState.Modified) if (t.out_wt == 0) { eRR.AppendLine("* Weight is invalid."); } else { if (t.net_wt == 0) eRR.AppendLine("* Net weight is invalid."); }
                    if (entityEntry.State == EntityState.Added) if (db.Transactions.Where(a => a.license_plate == t.license_plate && a.dt_out == null).Count() != 0) eRR.AppendLine("* Plate number already exists in pending transactions.");
                    if (entityEntry.State == EntityState.Modified) if (db.Transactions.Where(a => a.license_plate == t.license_plate && a.dt_out == null && a.transaction_id != t.transaction_id).Count() != 0) eRR.AppendLine("* Plate number already exists in pending transactions.");
                }

                if (t._client == String.Empty)
                { eRR.AppendLine("* No client was selected."); }
                { var c1 = db.Clients.Where(a => a.name == t._client).FirstOrDefault(); if (c1 != null) { t.client_code = c1.client_code; } else { eRR.AppendLine("* Selected client was not found."); };}

                if (t._commodity == String.Empty)
                { eRR.AppendLine("* No commodity type was selected."); }
                else
                { var m1 = db.Raw_materials.Where(a => a.description == t._commodity).FirstOrDefault(); if (m1 != null) { t.mate_code = m1.mate_code; } else { eRR.AppendLine("* Selected commodity was not found."); };}

                if (t._origin == String.Empty)
                { eRR.AppendLine("* No Origin was selected."); }
                { var o1 = db.Origins.Where(a => a.origin_name == t._origin).FirstOrDefault(); if (o1 != null) { t.origin_code = o1.origin_code; } else { eRR.AppendLine("* Selected origin was not found."); };}

                TimeSpan w_time = t.dt_in.Value - t.reg_dt.Value;
                if (w_time.TotalHours < 0) { eRR.AppendLine("* Waiting time is invalid. Registration time is later than time-in"); }
                else
                {
                    double d_w = w_time.Days;
                    double hr_w = (w_time.Days * 24) + w_time.Hours;
                    double mn_w = w_time.Minutes;
                    t.waiting_time = hr_w.ToString() + "." + mn_w.ToString();
                }

                if (entityEntry.State == EntityState.Modified)
                {
                   if (t.WEIGHING_STATE == WEIGHIN_STATE.WEIGH_OUT)
                   {
                    TimeSpan e_time = t.dt_out.Value - t.dt_in.Value;
                    if (e_time.TotalHours < 0)
                    { eRR.AppendLine("* Elapsed time is invalid. Time-in is later than time-out"); }
                    else
                    {
                        double d_w = e_time.Days;
                        double hr_w = (e_time.Days * 24) + e_time.Hours;
                        double mn_w = e_time.Minutes;
                        t.elapsed_time = hr_w.ToString() + "." + mn_w.ToString();
                    }

                   }
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
                sys.domain.trns.Transactions t = entityEntry.Entity as sys.domain.trns.Transactions;
                /// log creation ///
                AuditTrails.create_log(db, entityEntry);
                if (t.VALIDATE)
                {
                    /// cloning transaction to trashed table on delete state ///
                    if (entityEntry.State == EntityState.Deleted)
                    {
                        var td = new sys.domain.trns.Trashed();

                        PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(td);
                        foreach (PropertyDescriptor prop in properties)
                        {
                            td.GetType().GetProperty(prop.Name).SetValue(td, t.GetType().GetProperty(prop.Name).GetValue(t, null));
                        }
                        db.Trashed.Add(td);
                    }
                    /// setting tracker date to previous day if time falls below 0:00 to 6:00 AM ///
                    if (entityEntry.State == EntityState.Added)
                    {
                        //Datetime fr = new

                        //DateTime fr = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day) + new TimeSpan(6, 1, 0);
                        //DateTime to = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(1) + new TimeSpan(6, 0, 0);

                        //if (t.dt_in >= fr && t.dt_in <= to)
                        //{
                        //    t.tracker_dt = new DateTime(t.dt_in.Value.Year, t.dt_in.Value.Month, t.dt_in.Value.Day) + new TimeSpan(t.dt_in.Value.Hour, 0, 0);
                        //}

                        tracker_property tp1 = get_tracker_col(t.dt_in.Value);
                        t.dt_in_col = tp1.tracker_col;
                        t.tracker_dt = tp1.tracker_date;
                    }

                    var chkr = db.Checkers.Where(a => a.checker_name == t.checker_name).FirstOrDefault();
                    if (chkr== null)
                    {
                        chkr = new dbs.Checkers();
                        chkr.checker_name = t.checker_name;
                        db.Checkers.Add(chkr);
                        db.Entry(chkr).State = EntityState.Added;
                    }

                    if (t.WEIGHING_STATE == WEIGHIN_STATE.WEIGH_OUT && db.Entry(t).State == EntityState.Modified)
                    {
                        tracker_property tp2 = get_tracker_col(t.dt_out.Value);
                        t.dt_out_col = tp2.tracker_col;
                    }
                    

                    tracker_property tp3 = get_tracker_col(t.reg_dt.Value,true);
                    t.time_reg_col = tp3.tracker_col;

                    /// saving new driver encoded///
                    if (t.driver_name != String.Empty)
                    {
                        if (db.Drivers.Where(a => a.driver_name == t.driver_name.Trim()).Count() == 0)
                        {
                            var n_drvr = new sys.domain.dbs.Drivers();
                            n_drvr.driver_name = t.driver_name.Trim();
                            n_drvr.license_plate = t.license_plate;
                            db.Drivers.Add(n_drvr);
                        }
                    }

                    /// saving new checker encoded///
                    if (string.IsNullOrEmpty(t.checker_name) == false)
                    {
                        if (db.Checkers.Where(a => a.checker_name == t.checker_name.Trim()).Count() == 0)
                        {
                            var n_chkr = new sys.domain.dbs.Checkers();
                            n_chkr.checker_name = t.checker_name.Trim();
                            db.Checkers.Add(n_chkr);
                        }
                    }

                    /// updating the reference for transaction ///
                    if (entityEntry.State == EntityState.Added)
                    {
                        var ref_no = db.Ref_nos.First(); Double id = 0;
                        ref_no.ShouldValidateEntry = true;
                        switch (t.t_type)
                        {
                            case "P": Double.TryParse(ref_no.purchase_id, out id); ref_no.purchase_id = String.Format("{0:0000000}", id + 1); break;
                            case "S": Double.TryParse(ref_no.sales_id, out id); ref_no.sales_id = String.Format("{0:0000000}", id + 1); break;
                            case "F": Double.TryParse(ref_no.finished_id, out id); ref_no.finished_id = String.Format("{0:0000000}", id + 1); ; break;
                            case "T": Double.TryParse(ref_no.transfer_id, out id); ref_no.transfer_id = String.Format("{0:0000000}", id + 1); break;
                            default: Double.TryParse(ref_no.trans_id, out id); ref_no.trans_id = String.Format("{0:0000000}", id + 1); break;
                        }
                        db.Entry(ref_no).State = EntityState.Modified;
                    }
                }
                /// add 1 value to re-print counter ///
                if (t.REPRINT)
                {
                    t.re_print_ctr += 1;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public class tracker_property
        {
            public int tracker_col { get; set; }
            public DateTime tracker_date { get; set; }
        }
        private static tracker_property get_tracker_col(DateTime dt_in,bool is_reg = false)
        {
            DateTime tracker_date =dt_in.Date;
            TimeSpan tracker_time = new TimeSpan(dt_in.Hour, 0, 0);

            TimeSpan timein = new TimeSpan(dt_in.Hour,dt_in.Minute,dt_in.Second);
            TimeSpan Bracket = new TimeSpan(6, 0, 0);

            int col = 1;
            if (timein <= Bracket)
            {
                if (is_reg)
                {
                    col = 1;
                }
                else
                {
                    switch (timein.Hours)
                    {
                        case 0: col = 19; break;
                        case 1: col = 20; break;
                        case 2: col = 21; break;
                        case 3: col = 22; break;
                        case 4: col = 23; break;
                        case 5: col = 24; break;
                        case 6: col = 25; break;
                    }
                }
                tracker_date = tracker_date.AddDays(-1) + tracker_time;
            }
            else
            {
                switch (timein.Hours)
                {
                    case 6: col = 1; break;
                    case 7: col = 2; break;
                    case 8: col = 3; break;
                    case 9: col = 4; break;
                    case 10: col = 5; break;
                    case 11: col = 6; break;
                    case 12: col = 7; break;
                    case 13: col = 8; break;
                    case 14: col = 9; break;
                    case 15: col = 10; break;
                    case 16: col = 11; break;
                    case 17: col = 12; break;
                    case 18: col = 13; break;
                    case 19: col = 14; break;
                    case 20: col = 15; break;
                    case 21: col = 16; break;
                    case 22: col = 17; break;
                    case 23: col = 18; break;
                }
                tracker_date = tracker_date + tracker_time;
            }

            tracker_property tp = new tracker_property();
            tp.tracker_col = col;
            tp.tracker_date = tracker_date;

            return tp;
        }
    }
}
