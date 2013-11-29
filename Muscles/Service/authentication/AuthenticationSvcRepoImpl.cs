using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Service
{

    public partial class AuthenticationSvcRepoImpl : IAuthenticationSvc
    {
        public IUserSvc userSvc;
        public AuthenticationSvcRepoImpl()
        {
            userSvc = new UserSvcRepoImpl();
        }
        public bool AuthenticateUser(String UserName, String Password)
        {
            User user1 = userSvc.RetrieveUser("UserName", UserName);

            if (user1 != null)
            {
                if (user1.UserName == UserName)
                {
                    if (user1.Password == Password)
                    {

                        return true;
                    }
                }
            }
            return false;
        }

        public bool RegisterUser(String IncommingUserName, String IncommingPassword)
        {
            string username = IncommingUserName;
            string password = IncommingPassword;
            
            User checkUserName = userSvc.RetrieveUser("UserName", username);

            if (checkUserName == null)
            {
                User user1 = new User(username, password);
                userSvc.CreateUser(user1);

                return true;
            }
            else
                return false;
        }
    }
}
