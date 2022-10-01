using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sys.domain
{
    public class AuditTrails
    {
        public enum actions
        {
            Dummy,
            Online_weigh_in,
            Offline_weigh_in,
            Online_weigh_out,
            Offline_weigh_out,
            Modified,
            Deleted,
            Re_printed,
            Viewed,
            User_created,
            User_modified,
            User_deleted,
            User_logged_in,
            User_logged_out
        }
        public static void create_log(DAL.DBContext db, System.Data.Entity.Infrastructure.DbEntityEntry entityEntry)
        {
            sys.domain.trns.Transactions t = entityEntry.Entity as sys.domain.trns.Transactions; sys.domain.adm.Users u = entityEntry.Entity as sys.domain.adm.Users;
            var tl = new sys.domain.adm.logs();
            tl.log_dt = DateTime.Now;
            tl.log_type = entityEntry.Entity is sys.domain.trns.Transactions ? "Transaction" : "User";
            tl.action_id = get_action(db, entityEntry).action_id;
            tl.user_name = db.current_user.full_name;
            tl.record_no = entityEntry.Entity is sys.domain.trns.Transactions ? t.receipt_no : u.user_code;

            StringBuilder lg_details = new StringBuilder();

            if (entityEntry.Entity is sys.domain.trns.Transactions)
            {
                if (t.WEIGHING_STATE == sys.domain.Validation.TransactionValidation.WEIGHIN_STATE.UPDATE)
                {
                    sys.domain.trns.Transactions orig = new sys.domain.trns.Transactions();

                    cl2_init.stp settings = new cl2_init.stp { acspp = "mijochanel122208" };
                    sys.domain.connection_string main_conn_str = new sys.domain.connection_string { datasource = settings.INI_SERVERNAME, catalog = settings.INI_CATALOG, user_id = settings.INI_SQLUID, password = settings.INI_SQLPWD, integrated_security = false };
                    using (sys.domain.DAL.DBContext dbx2 = new sys.domain.DAL.DBContext(main_conn_str))
                    {
                        orig = dbx2.Transactions.Where(a => a.transaction_id == t.transaction_id).ToList().FirstOrDefault();
                        orig.client = dbx2.Clients.Where(a => a.client_code == orig.client_code).FirstOrDefault();
                        orig.origin = dbx2.Origins.Where(a => a.origin_code == orig.origin_code).FirstOrDefault();
                        orig.raw_material = dbx2.Raw_materials.Where(a => a.mate_code == orig.mate_code).FirstOrDefault();
                   


                    if (orig.license_plate != t.license_plate) lg_details.AppendLine("License plate:" + orig.license_plate + "->" + t.license_plate + ";");
                    if (orig.gate_pass != t.gate_pass) lg_details.AppendLine("D.R. number:" + orig.gate_pass + "->" + t.gate_pass + ";");
                    if (orig.driver_name != t.driver_name) lg_details.AppendLine("Driver name:" + orig.driver_name + "->" + t.driver_name + ";");
                    if (orig.client_name != t._client) lg_details.AppendLine("Client name:" + orig.client_name + "->" + t._client + ";");
                    if (orig.origin_name != t._origin) lg_details.AppendLine("Origin:" + orig.origin_name + "->" + t._origin + ";");
                    if (orig.mate_desc != t._commodity) lg_details.AppendLine("Commodity:" + orig.mate_desc + "->" + t._commodity + ";");
                   
                    if (orig.remarks != t.remarks) lg_details.AppendLine("remarks:" + orig.remarks + "->" + t.remarks + ";");
                    if (orig.reg_dt != t.reg_dt) lg_details.AppendLine("Reg. date:" + orig.reg_dt + "->" + t.reg_dt + ";");
                    if (orig.checker_name != t.checker_name) lg_details.AppendLine("Cheker:" + orig.checker_name + "->" + t.checker_name + ";");
                    if (orig.truckscale_no != t.truckscale_no) lg_details.AppendLine("Truckscale no.:" + orig.truckscale_no + "->" + t.truckscale_no + ";");
                    }
                }

            }
            tl.details = lg_details.ToString();
            tl.comments = "";
            db.Entry(tl).State = EntityState.Added;
            db.Logs.Add(tl);
        }

        private static sys.domain.adm.Actions get_action(DAL.DBContext db, System.Data.Entity.Infrastructure.DbEntityEntry entityEntry)
        {
            sys.domain.adm.Actions action = new sys.domain.adm.Actions();

            if (entityEntry.Entity is sys.domain.trns.Transactions)
            {
                sys.domain.trns.Transactions t = entityEntry.Entity as sys.domain.trns.Transactions;
                if (entityEntry.State == EntityState.Added && t.in_offline == false) { action = db.Actions.Where(a => a.description == "Online weigh-in").FirstOrDefault(); goto end; }
                if (entityEntry.State == EntityState.Added && t.in_offline == true) { action = db.Actions.Where(a => a.description == "Offline weigh-in").FirstOrDefault(); goto end; }

                if (entityEntry.State == EntityState.Modified && t.WEIGHING_STATE == Validation.TransactionValidation.WEIGHIN_STATE.WEIGH_IN && t.in_offline == false) { action = db.Actions.Where(a => a.description == "Online weigh-out").FirstOrDefault(); goto end; }
                if (entityEntry.State == EntityState.Modified && t.WEIGHING_STATE == Validation.TransactionValidation.WEIGHIN_STATE.WEIGH_OUT && t.in_offline == true) { action = db.Actions.Where(a => a.description == "Offline weigh-out").FirstOrDefault(); goto end; }
                if (entityEntry.State == EntityState.Modified && t.REPRINT == true) { action = db.Actions.Where(a => a.description == "Re-printed").FirstOrDefault(); goto end; }

                if (entityEntry.State == EntityState.Modified) { action = db.Actions.Where(a => a.description == "Modified").FirstOrDefault(); goto end; }
                if (entityEntry.State == EntityState.Deleted) { action = db.Actions.Where(a => a.description == "Deleted").FirstOrDefault(); goto end; }
            }

            if (entityEntry.Entity is sys.domain.adm.Users)
            {
                sys.domain.adm.Users u = entityEntry.Entity as sys.domain.adm.Users;

                if (u.LOGGED_IN) { action = db.Actions.Where(a => a.description == "User logged-in").FirstOrDefault(); goto end; }
                if (u.LOGGED_OUT) { action = db.Actions.Where(a => a.description == "User logged-out").FirstOrDefault(); goto end; }
                if (entityEntry.State == EntityState.Added) { action = db.Actions.Where(a => a.description == "User created").FirstOrDefault(); goto end; }
                if (entityEntry.State == EntityState.Modified) { action = db.Actions.Where(a => a.description == "User modified").FirstOrDefault(); goto end; }
                if (entityEntry.State == EntityState.Deleted) { action = db.Actions.Where(a => a.description == "User deleted").FirstOrDefault(); goto end; }
            }

        end:
            return action;
        }

        public static void create_log(DAL.DBContext db, sys.domain.adm.Users user, actions action)
        {

        }

        public static void create_log(DAL.DBContext db, sys.domain.trns.Transactions trns, actions action)
        {

        }
    }
}
