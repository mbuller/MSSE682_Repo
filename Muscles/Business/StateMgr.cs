using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Service;


namespace Business
{
    public class StateMgr : Manager
    {
        public IStateSvc stateSvc;
        public ITicketSvc ticketSvc;

        public StateMgr()
        {
            stateSvc = (IStateSvc)GetService("StateSvcRepoImpl");
            ticketSvc = (ITicketSvc)GetService("TicketSvcRepoImpl");
        }

        public void CreateState(State state)
        {
            //    IStateSvc stateSvc = (IStateSvc)GetService("StateSvcRepoImpl");
            stateSvc.CreateState(state);
        }

        public void RemoveState(State state)
        {
            //    IStateSvc stateSvc = (IStateSvc)GetService("StateSvcRepoImpl");

            List<Ticket> ticketsCollecton = ticketSvc.RetrieveTickets("TicketState_StateId", (int?)state.StateId).ToList<Ticket>();
            foreach (Ticket _ticket in ticketsCollecton)
            {
                _ticket.TicketState_StateId = null;
                ticketSvc.ModifyTicket(_ticket);
            }

            stateSvc.RemoveState(state);

        }

        public void ModifyState(State state)
        {
            //    IStateSvc stateSvc = (IStateSvc)GetService("StateSvcRepoImpl");
            stateSvc.ModifyState(state);
        }

        public State RetrieveState(String DBColumnName, String StringValue)
        {
            //    IStateSvc stateSvc = (IStateSvc)GetService("StateSvcRepoImpl");
            return stateSvc.RetrieveState(DBColumnName, StringValue);
        }
        public State RetrieveState(String DBColumnName, int IntValue)
        {
            //    IStateSvc stateSvc = (IStateSvc)GetService("StateSvcRepoImpl");
            return stateSvc.RetrieveState(DBColumnName, IntValue);
        }
        public State RetrieveState(String DBColumnName, int? NullableIntValue)
        {
            //    IStateSvc stateSvc = (IStateSvc)GetService("StateSvcRepoImpl");
            return stateSvc.RetrieveState(DBColumnName, NullableIntValue);
        }
        public ICollection<State> RetrieveAllStates()
        {
            //   IStateSvc stateSvc = (IStateSvc)GetService("StateSvcRepoImpl");
            return stateSvc.RetrieveAllStates();
        }
        public void DisposeState()
        {
            //    IStateSvc stateSvc = (IStateSvc)GetService("StateSvcRepoImpl");
            stateSvc.DisposeState();
        }
    }
}
