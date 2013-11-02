using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class User
    {
        public User(
            int UserId,
            String UserName,
            String Password)
        {
            this.UserId = UserId;
            this.UserName = UserName;
            this.Password = Password;
        }
        public User(
            int UserId,
            String UserName)
        {
            this.UserId = UserId;
            this.UserName = UserName;
            this.Password = "Password";
        }

        public User(
            String UserName,
            String Password)
        {
            this.UserName = UserName;
            this.Password = Password;
        }

        public User(
            String UserName)
        {
            this.UserId = UserId;
            this.UserName = UserName;
            this.Password = "Password";
        }

        public bool validate()
        {
            if (UserId < 0)
            {
                return false;
            }
            if (UserName == null)
            {
                return false;
            }
            if (Password == null)
            {
                return false;
            }
            return true;
        }
        public bool validateUnitTest()
        {
            if (UserName == null)
            {
                return false;
            }
            
            return true;
        }

    }
}
