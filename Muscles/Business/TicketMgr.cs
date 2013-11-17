using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Service;


namespace Business
{
    public class TicketMgr : Manager
    {
        public ITicketSvc ticketSvc;
        public IUserSvc userSvc;
        public IStateSvc stateSvc;

        public TicketMgr()
        {
            ticketSvc = (ITicketSvc)GetService("TicketSvcRepoImpl");
            userSvc = (IUserSvc)GetService("UserSvcRepoImpl");
            stateSvc = (IStateSvc)GetService("StateSvcRepoImpl");
        }

        public void CreateTicket(Ticket ticket)
        {
            //    ITicketSvc ticketSvc = (ITicketSvc)GetService("TicketSvcRepoImpl");
            if (ticket.Owner_UserId != null)
            {
                User owner = userSvc.RetrieveUser("UserId", (int)ticket.Owner_UserId);

                if (owner.UserName != null)
                    ticket.TicketOwnerUserName = owner.UserName;
            }
            if (ticket.Submitter_UserId != null)
            {
                User submitter = userSvc.RetrieveUser("UserId", (int)ticket.Submitter_UserId);

                if (submitter.UserName != null)
                    ticket.TicketSubmitterUserName = submitter.UserName;
            }
            if (ticket.TicketState_StateId != null)
            {
                State stateName = stateSvc.RetrieveState("StateId", (int)ticket.TicketState_StateId);

                if (stateName.StateName != null)
                    ticket.TicketStateName = stateName.StateName;
            }
            ticketSvc.CreateTicket(ticket);
        }

        public void RemoveTicket(Ticket ticket)
        {
            //    ITicketSvc ticketSvc = (ITicketSvc)GetService("TicketSvcRepoImpl");


            ticketSvc.RemoveTicket(ticket);

        }

        public void ModifyTicket(Ticket ticket)
        {
            //    ITicketSvc ticketSvc = (ITicketSvc)GetService("TicketSvcRepoImpl");
            if (ticket.Owner_UserId != null)
            {
                User owner = userSvc.RetrieveUser("UserId", (int)ticket.Owner_UserId);
                
                if (owner.UserName != null)
                    ticket.TicketOwnerUserName = owner.UserName;
            }
           /* if (ticket.Submitter_UserId != null)
            {
                User submitter = userSvc.RetrieveUser("UserId", (int)ticket.Submitter_UserId);

                if (submitter.UserName != null)
                    ticket.TicketSubmitterUserName = submitter.UserName;
            }*/
            if (ticket.TicketState_StateId != null)
            {
                State stateName = stateSvc.RetrieveState("StateId", (int)ticket.TicketState_StateId);

                if (stateName.StateName != null)
                    ticket.TicketStateName = stateName.StateName;
            }
            ticketSvc.ModifyTicket(ticket);
        }

        public Ticket RetrieveTicket(String DBColumnName, String StringValue)
        {
            //    ITicketSvc ticketSvc = (ITicketSvc)GetService("TicketSvcRepoImpl");
            return ticketSvc.RetrieveTicket(DBColumnName, StringValue);
        }
        public Ticket RetrieveTicket(String DBColumnName, int IntValue)
        {
            //    ITicketSvc ticketSvc = (ITicketSvc)GetService("TicketSvcRepoImpl");
            return ticketSvc.RetrieveTicket(DBColumnName, IntValue);
        }
        public Ticket RetrieveTicket(String DBColumnName, int? NullableIntValue)
        {
            //    ITicketSvc ticketSvc = (ITicketSvc)GetService("TicketSvcRepoImpl");
            return ticketSvc.RetrieveTicket(DBColumnName, NullableIntValue);
        }
        public ICollection<Ticket> RetrieveTickets(String DBColumnName, int IntValue)
        {
            //    ITicketSvc ticketSvc = (ITicketSvc)GetService("TicketSvcRepoImpl");
            return ticketSvc.RetrieveTickets(DBColumnName, IntValue);
        }
        public ICollection<Ticket> RetrieveTickets(String DBColumnName, int? NullableIntValue)
        {
            //    ITicketSvc ticketSvc = (ITicketSvc)GetService("TicketSvcRepoImpl");
            return ticketSvc.RetrieveTickets(DBColumnName, NullableIntValue);
        }
        public ICollection<Ticket> RetrieveAllTickets()
        {
            //   ITicketSvc ticketSvc = (ITicketSvc)GetService("TicketSvcRepoImpl");
            return ticketSvc.RetrieveAllTickets();
        }
        public void DisposeTicket()
        {
            //    ITicketSvc ticketSvc = (ITicketSvc)GetService("TicketSvcRepoImpl");
            ticketSvc.DisposeTicket();
        }
    }
}
