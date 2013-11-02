using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Service
{
    public interface IUserSvc : IService
    {
        void CreateUser(User User);
        void RemoveUser(User User);
        void ModifyUser(User User);
        User RetrieveUser(String DBColumnName, String StringValue);
        User RetrieveUser(String DBColumnName, int IntValue);
        User RetrieveUser(String DBColumnName, int? NullableIntValue);

        ICollection<User> RetrieveUsers(String DBColumnName, int? NullableIntValue);
        ICollection<User> RetrieveUsers(String DBColumnName, int NullableIntValue);

        ICollection<User> RetrieveAllUsers();
        void DisposeUser();
    }
}
