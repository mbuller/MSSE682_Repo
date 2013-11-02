using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Service
{
    public partial class UserSvcRepoImpl : IUserSvc
    {
        public DataRepository<User> UserRepo;

        public UserSvcRepoImpl()
        {
            UserRepo = new DataRepository<User>();
        }
        public void CreateUser(User User)
        {
            UserRepo.Insert(User);
        }

        public void RemoveUser(User User)
        {
            UserRepo.Delete(User);
        }

        public void ModifyUser(User User)
        {
            UserRepo.Update(User);
        }
        public User RetrieveUser(String DBColumnName, String StringValue)
        {

            return UserRepo.GetBySpecificKey(DBColumnName, StringValue).FirstOrDefault<User>();
        }
        public User RetrieveUser(String DBColumnName, int IntValue)
        {

            return UserRepo.GetBySpecificKey(DBColumnName, IntValue).FirstOrDefault<User>();
        }
        public User RetrieveUser(String DBColumnName, int? NullableIntValue)
        {

            return UserRepo.GetBySpecificKey(DBColumnName, NullableIntValue).FirstOrDefault<User>();
        }
        public ICollection<User> RetrieveUsers(String DBColumnName, int NullableIntValue)
        {
            return UserRepo.GetBySpecificKey(DBColumnName, NullableIntValue).ToList<User>();
        }
        public ICollection<User> RetrieveUsers(String DBColumnName, int? NullableIntValue)
        {
            return UserRepo.GetBySpecificKey(DBColumnName, NullableIntValue).ToList<User>();
        }

        public ICollection<User> RetrieveAllUsers()
        {
            return UserRepo.GetAll().ToList<User>();
        }
        public void DisposeUser()
        {
            UserRepo.Dispose();
        }
    }
}

