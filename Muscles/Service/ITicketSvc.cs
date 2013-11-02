using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Service
{
    public interface ITicketSvc : IService
    {
        void CreateTicket(Ticket Ticket);
        void RemoveTicket(Ticket Ticket);
        void ModifyTicket(Ticket Ticket);
        Ticket RetrieveTicket(String DBColumnName, String StringValue);
        Ticket RetrieveTicket(String DBColumnName, int IntValue);
        Ticket RetrieveTicket(String DBColumnName, int? NullableIntValue);

        ICollection<Ticket> RetrieveTickets(String DBColumnName, int? NullableIntValue);
        ICollection<Ticket> RetrieveTickets(String DBColumnName, int NullableIntValue);

        ICollection<Ticket> RetrieveAllTickets();
        void DisposeTicket();
    }
}
