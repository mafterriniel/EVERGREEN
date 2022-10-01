using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sys.domain.Classes
{
    public static class access_verification
    {
        public static bool verify(sys.domain.adm.Users usr, Enums.roles role, bool ro = false)
        {
            bool res = false;
 
            if (usr == null) { goto end; }
            else
            {
                if (usr.permissions == null) { goto end; } else { if (usr.permissions.Count() == 0)goto end; }
                var p = usr.permissions.Where(a => a.role.description == role.ToString()).FirstOrDefault();
                if (p == null)
                { goto end; }
                else
                {
                    int val = p.permission;
                    if (p.permission == 0) res = false;
                    if (p.permission == 1) if (ro == false) res = false;
                    if (p.permission == 2) res = true;
                }
            }
end:
            if (res == false)
            {
                throw new Exception("Invalid access.");
            }
            else
            {
                return true;
            }
        



        }
    }
}
