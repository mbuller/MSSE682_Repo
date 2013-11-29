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

        public IAuthenticationSvc authenticationSvc;

        public AuthenticationMgr()
        {
            authenticationSvc = (IAuthenticationSvc)GetService("IAuthenticationSvc");
        }

         public bool AuthenticateUser(String UserName, String Password)
        {
            return authenticationSvc.AuthenticateUser(UserName, Password);
          
        }

         public bool RegisterUser(String UserName, String Password)
         {
             return authenticationSvc.RegisterUser(UserName, Password);
             
         }
    }
}
