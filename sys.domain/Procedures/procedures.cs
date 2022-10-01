using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace sys.domain
{
    public static class procedures
    {
        public static System.Nullable<Int64>[] del_dg_row(ref MetroFramework.Controls.MetroGrid dg, string cll_nme)
        {
            try
            {
                dg.EndEdit();
                System.Nullable<Int64>[] id_s = (from System.Windows.Forms.DataGridViewRow d in dg.Rows
                                                 where d.Cells["selected"].Value.Equals(true)
                                                 select Convert.ToInt64(d.Cells[cll_nme].Value)).Cast<System.Nullable<Int64>>().ToArray();

                if (id_s.Count() == 0) return null;
                if (System.Windows.Forms.MessageBox.Show("Selected record is unrecoverable once deleted? Do you wish to proceed", "",
                    System.Windows.Forms.MessageBoxButtons.YesNo,
                    System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return null;

                foreach (long i in id_s)
                {
                    var dr = (from System.Windows.Forms.DataGridViewRow d in dg.Rows where d.Cells[cll_nme].Value.ToString() == i.ToString() select d).FirstOrDefault();
                    if (dr != null) dg.Rows.Remove((System.Windows.Forms.DataGridViewRow)dr);
                }
                return id_s;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public static IQueryable<sys.domain.trns.Transactions> list_trans(DAL.DBContext db, System.Nullable<DateTime> dfr, System.Nullable<DateTime> dto, string hrF = null, string hrT = null, string clnt = null, string cmdty = null, string origin = null, string pno = null,bool tracker=false)
        {
            IQueryable<sys.domain.trns.Transactions> res;

            if (hrT == "24:00") hrT = "23:59";
            
            if (dfr.HasValue)
            {
                dfr = new DateTime(dfr.Value.Year, dfr.Value.Month, dfr.Value.Day) + new TimeSpan(Convert.ToInt16(hrF.ToString().Split(":".ToCharArray())[0]),Convert.ToInt16(hrF.ToString().Split(":".ToCharArray())[1]), 0);
                dto = new DateTime(dto.Value.Year, dto.Value.Month, dto.Value.Day) + new TimeSpan(Convert.ToInt16(hrT.ToString().Split(":".ToCharArray())[0]), 59, 0);
            }

            Expression<Func<sys.domain.trns.Transactions, bool>> wh_dt_in_range = a => a.dt_in >= dfr && a.dt_in <= dto;
            Expression<Func<sys.domain.trns.Transactions, bool>> wh_dt_out_range = a => a.dt_out >= dfr && a.dt_out <= dto;
            Expression<Func<sys.domain.trns.Transactions, bool>> pending = a => a.dt_out == null;
           
            //wh_dt_out_range = null;

            //a.dt_out.Value.Year >= dfr.Value.Year &&
            //a.dt_out.Value.Month >= dfr.Value.Month &&
            //a.dt_out.Value.Day >= dfr.Value.Day &&
            //a.dt_out.Value.Hour >= dfr.Value.Hour &&
            //a.dt_out.Value.Minute >= dfr.Value.Minute &&
            //a.dt_out.Value.Year >= dto.Value.Year &&
            //a.dt_out.Value.Month >= dto.Value.Month &&
            //a.dt_out.Value.Day >= dto.Value.Day &&
            //a.dt_out.Value.Hour >= dto.Value.Hour &&
            //a.dt_out.Value.Minute >= dto.Value.Minute;
            Expression<Func<sys.domain.trns.Transactions, bool>> wh_hr_range = a => a.dt_out.Value.Hour >= Convert.ToInt32(hrF) && a.dt_out.Value.Hour <= Convert.ToInt32(hrT);
            Expression<Func<sys.domain.trns.Transactions, bool>> wh_tracker_dt = a => a.tracker_dt.Value >= dfr && a.tracker_dt <= dto;
            Expression<Func<sys.domain.trns.Transactions, bool>> wh_clnt = a => a.client.name.Equals(clnt);
            Expression<Func<sys.domain.trns.Transactions, bool>> wh_origin = a => a.origin.origin_name == origin;
            Expression<Func<sys.domain.trns.Transactions, bool>> wh_cmdty = a => a.raw_material.description == cmdty;
            Expression<Func<sys.domain.trns.Transactions, bool>> wh_pno = a => a.license_plate == pno;

            res = db.Transactions;
            if (tracker == true)
            {
                if (dfr != null) { res = res.Where(wh_tracker_dt); }
            }
            else
            {
                if (dfr != null) { res = res.Where(wh_dt_in_range); } else { res = res.Where(pending); }
            }
            if (clnt != null) res = res.Where(wh_clnt);
            if (origin != null) res = res.Where(wh_origin);
            if (cmdty != null) res = res.Where(wh_cmdty);
            if (pno != null) res = res.Where(wh_pno);
            return res;
        }

        public static IQueryable<sys.domain.dbs.Clients> lst_clnts(DAL.DBContext db, System.Nullable<Boolean> is_active = null)
        {
            IQueryable<sys.domain.dbs.Clients> res;

            Expression<Func<sys.domain.dbs.Clients, bool>> wh_is_actve = a => a.is_active == is_active;
            Expression<Func<sys.domain.dbs.Clients, bool>> wh_is_supplier = a => a.is_supplier == true;

            res = db.Clients;
            res.Where(wh_is_supplier);
            if (is_active != null) res.Where(wh_is_actve);

            return res;
        }

        public static IQueryable<sys.domain.dbs.Raw_materials> lst_mats(DAL.DBContext db, System.Nullable<Boolean> is_active = null)
        {
            IQueryable<sys.domain.dbs.Raw_materials> res;

            Expression<Func<sys.domain.dbs.Raw_materials, bool>> wh_is_actve = a => a.is_active == is_active;

            res = db.Raw_materials;
            if (is_active != null) res.Where(wh_is_actve);

            return res;
        }

        public static IQueryable<sys.domain.dbs.Origins> lst_orgs(DAL.DBContext db, System.Nullable<Boolean> is_active = null)
        {
            IQueryable<sys.domain.dbs.Origins> res;

            Expression<Func<sys.domain.dbs.Origins, bool>> wh_is_actve = a => a.is_active == is_active;

            res = db.Origins;
            if (is_active != null) res.Where(wh_is_actve);

            return res;
        }

        public static IQueryable<sys.domain.dbs.Drivers> lst_drvrs(DAL.DBContext db,System.Nullable<Boolean> is_active = null)
        {
            IQueryable<sys.domain.dbs.Drivers> res;

            //Expression<Func<sys.domain.dbs.Drivers, bool>> wh_is_actve = a => a.is_active == is_active;

            res = db.Drivers;

            return res;
        }

        public static IQueryable<sys.domain.adm.Users> lst_usrs(DAL.DBContext db,System.Nullable<Boolean> is_active = null)
        {
            IQueryable<sys.domain.adm.Users> res;

            //Expression<Func<sys.domain.dbs.Drivers, bool>> wh_is_actve = a => a.is_active == is_active;

            res = db.Users;

            return res;
        }

        public static IQueryable<sys.domain.adm.logs> lst_logs(DAL.DBContext db,  System.Nullable<DateTime> dfr, System.Nullable<DateTime> dto, string hrF = null, string hrT = null, string action = null, string ltype = null, string user_name = null)
        {
            IQueryable<sys.domain.adm.logs> res;
            if (hrT == "24:00") hrT = "23:59";
            
            if (dfr.HasValue)
            {
                dfr = new DateTime(dfr.Value.Year, dfr.Value.Month, dfr.Value.Day) + new TimeSpan(Convert.ToInt16(hrF.ToString().Split(":".ToCharArray())[0]),Convert.ToInt16(hrF.ToString().Split(":".ToCharArray())[1]), 0);
                dto = new DateTime(dto.Value.Year, dto.Value.Month, dto.Value.Day) + new TimeSpan(Convert.ToInt16(hrT.ToString().Split(":".ToCharArray())[0]), 59, 0);
            }

            var acxn = db.Actions.Where(a=>a.description == action.Trim()).FirstOrDefault();

            if (user_name == String.Empty) user_name = null;
            Expression<Func<sys.domain.adm.logs, bool>> wh_dt_out_range = a => a.log_dt >= dfr && a.log_dt <= dto;
            Expression<Func<sys.domain.adm.logs, bool>> wh_action = a => a.action_id== acxn.action_id;
            Expression<Func<sys.domain.adm.logs, bool>> wh_user = a => a.user_name == user_name;
            Expression<Func<sys.domain.adm.logs, bool>> wh_type = a => a.log_type == ltype;
            //Expression<Func<sys.domain.dbs.Drivers, bool>> wh_is_actve = a => a.is_active == is_active;
            res = db.Logs;
            if (dfr != null) { res = res.Where(wh_dt_out_range); }
            if (acxn != null) res = res.Where(wh_action);
            if (user_name !=null) res = res.Where(wh_user);
            if (ltype != null) res = res.Where(wh_type);

            return res;
        }
 
      
    }
}
