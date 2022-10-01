using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sys.domain.Repositories
{
    public class UserRepository 
    {
    
        public  sys.domain.adm.Users log_in(string uid, string pwd,connection_string conn)
        {
            cl2_g3n_._crpt0MD5 crypter = new cl2_g3n_._crpt0MD5("JOJO");
            using (DAL.DBContext dbx = new DAL.DBContext(conn))
            { 
                string encrypted_pwd = crypter.EncryptData(pwd);
                sys.domain.adm.Users user = null;
                user= dbx.Users.Where(a => a.login_id == uid.Trim() && a.login_pwd == encrypted_pwd).FirstOrDefault();

                if (user == null) throw new Exception("* Invalid user");

                sys.domain.AuditTrails.create_log(dbx, user, AuditTrails.actions.User_logged_in);

                return user;
            }
        }

        public  void log_out(sys.domain.adm.Users user,connection_string conn)
        {
            using (DAL.DBContext dbx = new DAL.DBContext(conn))
            {
                sys.domain.AuditTrails.create_log(dbx, user, AuditTrails.actions.User_logged_out);
            }
        }

        public  void create(sys.domain.adm.Users user, connection_string conn,sys.domain.adm.Users current_user)
        {
            using (sys.domain.DAL.DBContext dbx = new sys.domain.DAL.DBContext(conn))
            {

            }
        }

        public  void update(sys.domain.adm.Users user,connection_string conn,sys.domain.adm.Users current_user)
        {

        }

        public  void delete(sys.domain.adm.Users user, connection_string conn,sys.domain.adm.Users current_user)
        {

        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
