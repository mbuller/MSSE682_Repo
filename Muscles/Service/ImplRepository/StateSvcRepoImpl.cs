using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Service
{
    public partial class StateSvcRepoImpl : IStateSvc
    {
        public DataRepository<State> StateRepo;

        public StateSvcRepoImpl()
        {
            StateRepo = new DataRepository<State>();
        }
        public void CreateState(State State)
        {
            StateRepo.Insert(State);
        }

        public void RemoveState(State State)
        {
            StateRepo.Delete(State);
        }

        public void ModifyState(State State)
        {
            StateRepo.Update(State);
        }
        public State RetrieveState(String DBColumnName, String StringValue)
        {

            return StateRepo.GetBySpecificKey(DBColumnName, StringValue).FirstOrDefault<State>();
        }
        public State RetrieveState(String DBColumnName, int IntValue)
        {

            return StateRepo.GetBySpecificKey(DBColumnName, IntValue).FirstOrDefault<State>();
        }
        public State RetrieveState(String DBColumnName, int? NullableIntValue)
        {

            return StateRepo.GetBySpecificKey(DBColumnName, NullableIntValue).FirstOrDefault<State>();
        }
        public ICollection<State> RetrieveStates(String DBColumnName, int NullableIntValue)
        {
            return StateRepo.GetBySpecificKey(DBColumnName, NullableIntValue).ToList<State>();
        }
        public ICollection<State> RetrieveStates(String DBColumnName, int? NullableIntValue)
        {
            return StateRepo.GetBySpecificKey(DBColumnName, NullableIntValue).ToList<State>();
        }

        public ICollection<State> RetrieveAllStates()
        {
            return StateRepo.GetAll().ToList<State>();
        }
        public void DisposeState()
        {
            StateRepo.Dispose();
        }
    }
}
