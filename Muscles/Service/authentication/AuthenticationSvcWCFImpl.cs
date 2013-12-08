using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Service.ServiceReference1;

namespace Service
{
    public partial class AuthenticationSvcWCFImpl : IAuthenticationSvc
    {
        public IUserSvc userSvc;
        ServiceReference1.AuthenticateWCFClient proxy;

        public AuthenticationSvcWCFImpl()
        {
            userSvc = new UserSvcRepoImpl();
            proxy = new AuthenticateWCFClient();
        }
        public bool AuthenticateUser(String UserName, String Password)
        {
           //ServiceReference1.AuthenticateWCFImplClient proxy = new AuthenticateWCFImplClient();
            Boolean b = proxy.Login(UserName, Password);
            return b;
        }

        public bool RegisterUser(String IncommingUserName, String IncommingPassword)
        {
          //  ServiceReference1.AuthenticateWCFImplClient proxy = new AuthenticateWCFImplClient();
            Boolean b =  proxy.Register(IncommingUserName, IncommingPassword);
            return b;
        }
    }
}
