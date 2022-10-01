using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using sys.domain;
using System.Data.Entity.Core.Objects;

namespace sys.domain
{
    public class EF_expressions
    {

        public static Expression<Func<sys.domain.adm.Users, bool>> submit_login(string uid, string pwd)
        {
            return p => p.login_id == uid && p.login_pwd == pwd;
        }

        #region "Transactions"
        public static Expression<Func<trns.Transactions, ViewModels.w_in_list>> w_in_list_selector = (a) =>
     new ViewModels.w_in_list
     {
         selected = false,
         transaction_id = a.transaction_id,
         receipt_no = a.receipt_no,
         license_plate = a.license_plate,
         dt_in = a.dt_in,
         in_wt = a.in_wt,
         client_name = a.client.name,
         commodity = a.raw_material == null ? "" : a.raw_material.description,
         origin = a.origin == null ? "" : a.origin.origin_name,
         driver_name = a.driver_name,
         weigher_in = a.user_in.first_name + " " + a.user_in.last_name
     };

        public static Expression<Func<trns.Transactions, ViewModels.w_out_list>> w_out_list_selector = (a) =>
        new ViewModels.w_out_list
        {
            selected = false,
            transaction_id = a.transaction_id,
            receipt_no = a.receipt_no,
            license_plate = a.license_plate,
            dt_in = a.dt_in,
            dt_out = a.dt_out,
            in_wt = a.in_wt,
            out_wt = a.out_wt,
            net_wt = a.net_wt,
            reg_dt = a.reg_dt,
            waiting_time = a.waiting_time,
            elapsed_time = a.elapsed_time,
            client_name = a.client.name,
            commodity = a.raw_material.description,
            origin = a.origin.origin_name,
            driver_name = a.driver_name,
            weigher_in = a.user_in.first_name + " " + a.user_in.last_name,
            weigher_out = a.user_in.first_name + " " + a.user_in.last_name
        };

        public static Expression<Func<sys.domain.trns.Transactions, bool>> wh_dt_in_range(DateTime dfr, DateTime dto)
        {
            return a => a.dt_in >= dfr && a.dt_in <= dto;
        }
        public static Expression<Func<sys.domain.trns.Transactions, bool>> wh_dt_out_range(DateTime dfr, DateTime dto)
        {
            return a => a.dt_out >= dfr && a.dt_out <= dto;
        }
        public static Expression<Func<sys.domain.trns.Transactions, bool>> wh_stn(string stn)
        {
            return a => a.station_code == stn;
        }
        public static Expression<Func<sys.domain.trns.Transactions, bool>> wh_t(string t_t)
        {
            return a => a.t_type == t_t;
        }
        public static Expression<Func<sys.domain.trns.Transactions, bool>> wh_dt(string dt)
        {
            DateTime dfr = new DateTime();
            DateTime dto = new DateTime();
            switch (dt)
            {
                case "Today": dfr = DateTime.Now.Date + new TimeSpan(0, 0, 0); dto = DateTime.Now.Date + new TimeSpan(23, 59, 59); break;
                case "Current month": dfr = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1) + new TimeSpan(0, 0, 0); dto = new DateTime(dfr.Year, dfr.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)) + new TimeSpan(23, 59, 59); break;
                case "Previous month": dfr = DateTime.Now.AddMonths(-1).Date + new TimeSpan(0, 0, 0); dto = new DateTime(dfr.Year, dfr.Month, DateTime.DaysInMonth(dfr.Year, dfr.Month)) + new TimeSpan(23, 59, 59); break;
                case "Current year": dfr = new DateTime(DateTime.Now.Year, 1, 1) + new TimeSpan(0, 0, 0); dto = new DateTime(dfr.Year, dfr.Month, 31) + new TimeSpan(23, 59, 59); break;
                case "Previous year": dfr = new DateTime(DateTime.Now.AddYears(-1).Year, 1, 1) + new TimeSpan(0, 0, 0); dto = new DateTime(dfr.Year, dfr.Month, 31) + new TimeSpan(23, 59, 59); break;
            }

            return a => a.dt_out >= dfr && a.dt_in <= dto;
        }
        public static Expression<Func<sys.domain.trns.Transactions, bool>> wh_id(long id)
        {
            return a => a.transaction_id == id;
        }
        #endregion

        #region "Suppliers"
        public static Expression<Func<dbs.Clients, ViewModels.clnt_lst>> clnt_lst_selector = (a) =>
     new ViewModels.clnt_lst
     {
         selected = false,
         id = a.client_id,
         client_code = a.client_code,
         name = a.name,
         municipality = a.municipality,
         is_active = a.is_active
     };
        public static Expression<Func<dbs.Clients, bool>> wh_n_clnt_c(string c)
        {
            return p => p.client_code == c.Trim();
        }
        public static Expression<Func<dbs.Clients, bool>> wh_e_clnt_c(string c, long id)
        {
            return p => p.client_code == c.Trim() && p.client_id != id;
        }

        public static Expression<Func<dbs.Clients, bool>> wh_n_clnt_n(string n)
        {
            return p => p.name == n.Trim();
        }
        public static Expression<Func<dbs.Clients, bool>> wh_e_clnt_n(string n, long id)
        {
            return p => p.name == n.Trim() && p.client_id != id;
        }
        #endregion

        #region "Materials"
        public static Expression<Func<dbs.Raw_materials, ViewModels.mate_lst>> mats_lst_selector = (a) =>
     new ViewModels.mate_lst
     {
         selected = false,
         id = a.material_id,
         mate_code = a.mate_code,
         description = a.description,
         is_active = a.is_active
     };
        public static Expression<Func<dbs.Raw_materials, bool>> wh_n_mat_c(string c)
        {
            return p => p.mate_code == c.Trim();
        }
        public static Expression<Func<dbs.Raw_materials, bool>> wh_e_mat_c(string c, long id)
        {
            return p => p.mate_code == c.Trim() && p.material_id != id;
        }

        public static Expression<Func<dbs.Raw_materials, bool>> wh_n_mat_d(string n)
        {
            return p => p.description == n.Trim();
        }
        public static Expression<Func<dbs.Raw_materials, bool>> wh_e_mat_d(string n, long id)
        {
            return p => p.description == n.Trim() && p.material_id != id;
        }

        #endregion

        #region "Origin"
        public static Expression<Func<dbs.Origins, ViewModels.orgn_lst>> orgn_lst_selector = (a) =>
     new ViewModels.orgn_lst
     {
         selected = false,
         id = a.origin_id,
         origin_code = a.origin_code,
         origin_name = a.origin_name,
         is_active = a.is_active
     };
        public static Expression<Func<dbs.Origins, bool>> wh_n_org_c(string c)
        {
            return p => p.origin_code == c.Trim();
        }
        public static Expression<Func<dbs.Origins, bool>> wh_e_org_c(string c, long id)
        {
            return p => p.origin_code == c.Trim() && p.origin_id != id;
        }

        public static Expression<Func<dbs.Origins, bool>> wh_n_org_n(string n)
        {
            return p => p.origin_name == n.Trim();
        }
        public static Expression<Func<dbs.Origins, bool>> wh_e_org_n(string n, long id)
        {
            return p => p.origin_name == n.Trim() && p.origin_id != id;
        }
        #endregion

        #region "Users"
        public static Expression<Func<adm.Users, ViewModels.usr_lst>> usr_lst_selector = (a) =>
new ViewModels.usr_lst
{
    selected = false,
    id = a.user_id,
    user_code = a.user_code,
   first_name = a.first_name,
    middle_initial  = a.middle_initial,
    last_name = a.last_name,
    name_suffix = a.name_suffix,
    login_id = a.login_id,
    position = a.position,
    contact_num = a.contact_num,
    is_active = a.is_active
};

        public static Expression<Func<adm.Users, bool>> wh_n_usr_c(string c)
        {
            return p => p.user_code == c.Trim();
        }
        public static Expression<Func<adm.Users, bool>> wh_e_usr_c(string c, long id)
        {
            return p => p.user_code == c.Trim() && p.user_id != id;
        }

        public static Expression<Func<adm.Users, bool>> wh_n_usr_n(string fn,string mn,string ln)
        {
            return p => p.first_name == fn && p.middle_initial == mn && p.last_name == ln;
        }
        public static Expression<Func<adm.Users, bool>> wh_e_usr_n(string fn,string mn,string ln, long id)
        {
            return p => p.first_name == fn && p.middle_initial == mn && p.last_name == ln && p.user_id != id;
        }

        public static Expression<Func<adm.Users, bool>> wh_usr_n_lgid(string n)
        {
            return p => p.login_id == n.Trim();
        }
        public static Expression<Func<adm.Users, bool>> wh_usr_e_lgid(string n, long id)
        {
            return p => p.login_id == n.Trim() && p.user_id != id;
        }

        #endregion

        #region"Logs"
        public static Expression<Func<adm.logs, ViewModels.log_lst>> log_lst_selector = (a) =>
new ViewModels.log_lst
{
    selected = false,
    id = a.log_id,
    log_dt=a.log_dt,
    log_type= a.log_type,
    action_desc = a.action.description,
    record_no = a.record_no,
    details = a.details,
    comments = a.comments,
    user_name = a.user_name
};


        #endregion
        //public static void Delete<T>(Expression<Func<T, bool>> expression) where T : class, new();


        //     public virtual T Update(T obj, Expression<Func<T, bool>> match)
        //{
        //     using (var context = new PluralSightContext())
        //     {
        //        if (obj == null)
        //           return null;

        //         T existing = context.Set<T>().SingleOrDefault(match        if (existing != null)
        //         {
        //              context.Entry(existing).CurrentValues.SetValues(obj);                    
        //              context.SaveChanges();
        //         }
        //         return existing;
        //      }
        //}
    }
}
