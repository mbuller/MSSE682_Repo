using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Service
{
    public interface IStateSvc : IService
    {
        void CreateState(State State);
        void RemoveState(State State);
        void ModifyState(State State);
        State RetrieveState(String DBColumnName, String StringValue);
        State RetrieveState(String DBColumnName, int IntValue);
        State RetrieveState(String DBColumnName, int? NullableIntValue);

        ICollection<State> RetrieveStates(String DBColumnName, int? NullableIntValue);
        ICollection<State> RetrieveStates(String DBColumnName, int NullableIntValue);

        ICollection<State> RetrieveAllStates();
        void DisposeState();
    }
}
