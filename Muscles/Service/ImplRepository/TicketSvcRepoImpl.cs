using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Service
{
    public partial class TicketSvcRepoImpl : ITicketSvc
    {
        public DataRepository<Ticket> TicketRepo;

        public TicketSvcRepoImpl()
        {
            TicketRepo = new DataRepository<Ticket>();
        }
        public void CreateTicket(Ticket Ticket)
        {
            TicketRepo.Insert(Ticket);
        }

        public void RemoveTicket(Ticket Ticket)
        {
            TicketRepo.Delete(Ticket);
        }

        public void ModifyTicket(Ticket Ticket)
        {
            TicketRepo.Update(Ticket);
        }
        public Ticket RetrieveTicket(String DBColumnName, String StringValue)
        {

            return TicketRepo.GetBySpecificKey(DBColumnName, StringValue).FirstOrDefault<Ticket>();
        }
        public Ticket RetrieveTicket(String DBColumnName, int IntValue)
        {

            return TicketRepo.GetBySpecificKey(DBColumnName, IntValue).FirstOrDefault<Ticket>();
        }
        public Ticket RetrieveTicket(String DBColumnName, int? NullableIntValue)
        {

            return TicketRepo.GetBySpecificKey(DBColumnName, NullableIntValue).FirstOrDefault<Ticket>();
        }
        public ICollection<Ticket> RetrieveTickets(String DBColumnName, int NullableIntValue)
        {
            return TicketRepo.GetBySpecificKey(DBColumnName, NullableIntValue).ToList<Ticket>();
        }
        public ICollection<Ticket> RetrieveTickets(String DBColumnName, int? NullableIntValue)
        {
            return TicketRepo.GetBySpecificKey(DBColumnName, NullableIntValue).ToList<Ticket>();
        }

        public ICollection<Ticket> RetrieveAllTickets()
        {
            return TicketRepo.GetAll().ToList<Ticket>();
        }
        public void DisposeTicket()
        {
            TicketRepo.Dispose();
        }
    }
}

