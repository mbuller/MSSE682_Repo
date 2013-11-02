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

        public TicketMgr()
        {
            ticketSvc = (ITicketSvc)GetService("TicketSvcRepoImpl");
        }

        public void CreateTicket(Ticket ticket)
        {
            //    ITicketSvc ticketSvc = (ITicketSvc)GetService("TicketSvcRepoImpl");
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
