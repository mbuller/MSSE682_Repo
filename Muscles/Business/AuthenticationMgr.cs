using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Service;


namespace Business
{
    public class AuthenticationMgr : Manager
    {
        public int USER_NAME_MIN = 1;
        public int USER_NAME_MAX = 20;
        public int PASSWORD_MIN = 1;
        public int PASSWORD_MAX = 20;

        public IAuthenticationSvc authenticationSvc;

        public AuthenticationMgr()
        {
            authenticationSvc = (IAuthenticationSvc)GetService("IAuthenticationSvc");
        }

         public bool AuthenticateUser(String UserName, String Password)
        {
            UserName = UserName.Trim();
            Password = Password.Trim();
            if ((UserName.Length < USER_NAME_MIN) || (UserName.Length > USER_NAME_MAX ||
                Password.Length < PASSWORD_MIN) || (Password.Length > PASSWORD_MAX))
                return false;
            else
                return authenticationSvc.AuthenticateUser(UserName, Password);
          
        }

         public bool RegisterUser(String UserName, String Password)
         {
             UserName = UserName.Trim();
             Password = Password.Trim();
             if ((UserName.Length < USER_NAME_MIN) || (UserName.Length > USER_NAME_MAX ||
                 Password.Length < PASSWORD_MIN) || (Password.Length > PASSWORD_MAX))
                 return false;
             else
                return authenticationSvc.RegisterUser(UserName, Password);
             
         }
    }
}
