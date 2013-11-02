using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Service;


namespace Business
{
    public class UserMgr : Manager
    {
        public IUserSvc userSvc;
        public ITicketSvc ticketSvc;

        public UserMgr()
        {
            userSvc = (IUserSvc)GetService("UserSvcRepoImpl");
            ticketSvc = (ITicketSvc)GetService("TicketSvcRepoImpl");
        }

        public void CreateUser(User user)
        {
            //    IUserSvc userSvc = (IUserSvc)GetService("UserSvcRepoImpl");
            userSvc.CreateUser(user);
        }

        public void RemoveUser(User user)
        {
            //    IUserSvc userSvc = (IUserSvc)GetService("UserSvcRepoImpl");

            List<Ticket> ticketsSubmitterCollecton = ticketSvc.RetrieveTickets("Submitter_UserId", (int?)user.UserId).ToList<Ticket>();
            foreach (Ticket _ticket in ticketsSubmitterCollecton)
            {
                _ticket.Submitter_UserId = null;
                ticketSvc.ModifyTicket(_ticket);
            }
            
            List<Ticket> ticketsOwnerCollecton = ticketSvc.RetrieveTickets("Owner_UserId", (int?)user.UserId).ToList<Ticket>();
            foreach (Ticket _ticket in ticketsOwnerCollecton)
            {
                _ticket.Owner_UserId = null;
                ticketSvc.ModifyTicket(_ticket);
            }

            userSvc.RemoveUser(user);

        }

        public void ModifyUser(User user)
        {
            //    IUserSvc userSvc = (IUserSvc)GetService("UserSvcRepoImpl");
            userSvc.ModifyUser(user);
        }

        public User RetrieveUser(String DBColumnName, String StringValue)
        {
            //    IUserSvc userSvc = (IUserSvc)GetService("UserSvcRepoImpl");
            return userSvc.RetrieveUser(DBColumnName, StringValue);
        }
        public User RetrieveUser(String DBColumnName, int IntValue)
        {
            //    IUserSvc userSvc = (IUserSvc)GetService("UserSvcRepoImpl");
            return userSvc.RetrieveUser(DBColumnName, IntValue);
        }
        public User RetrieveUser(String DBColumnName, int? NullableIntValue)
        {
            //    IUserSvc userSvc = (IUserSvc)GetService("UserSvcRepoImpl");
            return userSvc.RetrieveUser(DBColumnName, NullableIntValue);
        }
        public ICollection<User> RetrieveAllUsers()
        {
            //   IUserSvc userSvc = (IUserSvc)GetService("UserSvcRepoImpl");
            return userSvc.RetrieveAllUsers();
        }
        public void DisposeUser()
        {
            //    IUserSvc userSvc = (IUserSvc)GetService("UserSvcRepoImpl");
            userSvc.DisposeUser();
        }
    }
}
