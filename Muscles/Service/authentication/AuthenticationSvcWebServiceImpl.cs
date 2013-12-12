using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service
{
    class AuthenticationSvcWebServiceImpl : IAuthenticationSvc
    {

        public IUserSvc userSvc;
        public AuthenticateWebService.AuthenticateWebService ws; //= new AuthenticateWebService.AuthenticateWebService();

        public AuthenticationSvcWebServiceImpl()
        {
            userSvc = new UserSvcRepoImpl();
            ws = new AuthenticateWebService.AuthenticateWebService();
            
        }
        public bool AuthenticateUser(String UserName, String Password)
        {
           //ServiceReference1.AuthenticateWCFImplClient proxy = new AuthenticateWCFImplClient();
            Boolean b = ws.Login(UserName, Password);
            return b;
        }

        public bool RegisterUser(String IncommingUserName, String IncommingPassword)
        {
          //  ServiceReference1.AuthenticateWCFImplClient proxy = new AuthenticateWCFImplClient();
            Boolean b =  ws.Register(IncommingUserName, IncommingPassword);
            return b;
        }

    }
}
