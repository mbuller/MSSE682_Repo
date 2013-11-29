using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IAuthenticationSvc : IService
    {
        bool AuthenticateUser(String UserName, String Password);
        bool RegisterUser(String UserName, String password);
    }
}
