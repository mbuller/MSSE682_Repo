using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Service;

namespace ServiceUnitTest
{
    [TestClass]
    public class IAdressSvcTest
    {
        /// <summary>
        /// Create State using State Repository Service
        /// </summary>
        [TestMethod]
        public void TestStateRepoSvcCreate()
        {
            State State1 = new State("SvcStateNameCreate");

            SvcFactory GetFactory = SvcFactory.GetInstance();
            IStateSvc StateSvc = (IStateSvc)GetFactory.GetService("StateSvcRepoImpl");
            StateSvc.CreateState(State1);
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Remove State using State Repository Service
        /// </summary>
        [TestMethod]
        public void TestStateRepoSvcRemove()
        {
            State State1 = new State("SvcStateNameRemove");

            var GetFactory = SvcFactory.GetInstance();
            IStateSvc StateSvc = (IStateSvc)GetFactory.GetService("StateSvcRepoImpl");
            StateSvc.CreateState(State1);

            StateSvc.RemoveState(State1);
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Modify State using State Repository Service
        /// </summary>
        [TestMethod]
        public void TestStateRepoSvcModify()
        {
            State State1 = new State("ErrorIfSeen");

            var GetFactory = SvcFactory.GetInstance();
            IStateSvc StateSvc = (IStateSvc)GetFactory.GetService("StateSvcRepoImpl");
            StateSvc.CreateState(State1);

            State1.StateName = "SvcStateNameModify_" + State1.StateId;

            StateSvc.ModifyState(State1);
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Retrieve State using State Repository Service
        /// </summary>
        [TestMethod]
        public void TestStateRepoSvcRetrieve()
        {
            State State1 = new State("SvcStateNameRetr");

            var GetFactory = SvcFactory.GetInstance();
            IStateSvc StateSvc = (IStateSvc)GetFactory.GetService("StateSvcRepoImpl");
            StateSvc.CreateState(State1);

            State State2 = StateSvc.RetrieveState("StateName", "SvcStateNameRetr");

            Assert.IsTrue(State2.validateUnitTests());
        }


        /// <summary>
        /// Retrieve All States using State Repository Service
        /// </summary>
        [TestMethod]
        public void testStateSvcRepoRetrieveAll()
        {
            State State1 = new State("SvcStateNameRetrAll");

            var StateRepo = new DataRepository<State>();
            var GetFactory = SvcFactory.GetInstance();
            IStateSvc StateSvc = (IStateSvc)GetFactory.GetService("StateSvcRepoImpl");
            StateSvc.CreateState(State1);


            List<State> myList = StateSvc.RetrieveAllStates().ToList<State>();
            Assert.IsTrue(myList.Count > 0);
        }

    }

    [TestClass]
    public class IUserSvcTest
    {
        /// <summary>
        /// Create User using User Repository Service
        /// </summary>
        [TestMethod]
        public void TestUserRepoSvcCreate()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();

            var userIdVal = (db.Users.Max(id => (int?)id.UserId) >= 0) ? (db.Users.Max(id => id.UserId) + 1) : 1;

            User User1 = new User("SvcUserNameCreate_" + userIdVal);

            var GetFactory = SvcFactory.GetInstance();
            IUserSvc UserSvc = (IUserSvc)GetFactory.GetService("UserSvcRepoImpl");
            UserSvc.CreateUser(User1);
        }

        /// <summary>
        /// Remove User using User Repository Service
        /// </summary>
        [TestMethod]
        public void TestUserRepoSvcRemove()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();

            var userIdVal = (db.Users.Max(id => (int?)id.UserId) >= 0) ? (db.Users.Max(id => id.UserId) + 1) : 1;

            User User1 = new User("SvcUserNameRemove_" + userIdVal);
            var GetFactory = SvcFactory.GetInstance();
            IUserSvc UserSvc = (IUserSvc)GetFactory.GetService("UserSvcRepoImpl");
            UserSvc.CreateUser(User1);

            UserSvc.RemoveUser(User1);

        }

        /// <summary>
        /// Modify User using User Repository Service
        /// </summary>
        [TestMethod]
        public void TestUserRepoSvcModify()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();

            var userIdVal = (db.Users.Max(id => (int?)id.UserId) >= 0) ? (db.Users.Max(id => id.UserId) + 1) : 1;

            User User1 = new User("ErrorIfSeen_" + userIdVal);

            var GetFactory = SvcFactory.GetInstance();
            IUserSvc UserSvc = (IUserSvc)GetFactory.GetService("UserSvcRepoImpl");
            UserSvc.CreateUser(User1);

            User1.UserName = "SvcUserNameModify_" + userIdVal + User1.UserId;

            UserSvc.ModifyUser(User1);
        }

        /// <summary>
        /// Retrieve User using User Repository Service
        /// </summary>
        [TestMethod]
        public void TestUserRepoSvcRetrieve()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();

            var userIdVal = (db.Users.Max(id => (int?)id.UserId) >= 0) ? (db.Users.Max(id => id.UserId) + 1) : 1;

            User User1 = new User("SvcUserNameRetr_" + userIdVal);

            var GetFactory = SvcFactory.GetInstance();
            IUserSvc UserSvc = (IUserSvc)GetFactory.GetService("UserSvcRepoImpl");
            UserSvc.CreateUser(User1);

            User User2 = UserSvc.RetrieveUser("UserName", "SvcUserNameRetr_" + userIdVal);

            Assert.IsTrue(User2.validateUnitTest());
        }


        /// <summary>
        /// Retrieve All Users using User Repository Service
        /// </summary>
        [TestMethod]
        public void testUserSvcRepoRetrieveAll()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();

            var userIdVal = (db.Users.Max(id => (int?)id.UserId) >= 0) ? (db.Users.Max(id => id.UserId) + 1) : 1;

            User User1 = new User("SvcUserNameRetAll_" + userIdVal);

            var UserRepo = new DataRepository<User>();
            var GetFactory = SvcFactory.GetInstance();
            IUserSvc UserSvc = (IUserSvc)GetFactory.GetService("UserSvcRepoImpl");
            UserSvc.CreateUser(User1);


            List<User> myList = UserSvc.RetrieveAllUsers().ToList<User>();
            Assert.IsTrue(myList.Count > 0);
        }
    }

    [TestClass]
    public class ITicketSvcTest
    {
        /// <summary>
        /// Create Ticket using Ticket Repository Service
        /// </summary>
        [TestMethod]
        public void TestTicketRepoSvcCreate()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();

            var StateRepo = new DataRepository<State>();
            State state1 = new State("stateName");
            StateRepo.Insert(state1);
            State state2 = StateRepo.GetBySpecificKey("StateName", "stateName").FirstOrDefault<State>();

            var userIdVal = (db.Users.Max(id => (int?)id.UserId) >= 0) ? (db.Users.Max(id => id.UserId) + 1) : 1;
            var UserRepo = new DataRepository<User>();
            User user1 = new User("userName_" + userIdVal);
            UserRepo.Insert(user1);
            User user2 = UserRepo.GetBySpecificKey("UserName", "userName_" + userIdVal).FirstOrDefault<User>();

            var ticketIdVal = (db.Tickets.Max(id => (int?)id.TicketId) >= 0) ? (db.Tickets.Max(id => id.TicketId) + 1) : 1;

            Ticket ticket1 = new Ticket("SvcDescriptionCreate_" + ticketIdVal, "SvcHeadlineCreate_" + ticketIdVal, "SvcNotesCreate_" + ticketIdVal, (int?)user2.UserId, (int?)user2.UserId, (int?)state2.StateId);

            var GetFactory = SvcFactory.GetInstance();
            ITicketSvc TicketSvc = (ITicketSvc)GetFactory.GetService("TicketSvcRepoImpl");
            TicketSvc.CreateTicket(ticket1);
        }

        /// <summary>
        /// Remove Ticket using Ticket Repository Service
        /// </summary>
        [TestMethod]
        public void TestTicketRepoSvcRemove()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();

            var ticketIdVal = (db.Tickets.Max(id => (int?)id.TicketId) >= 0) ? (db.Tickets.Max(id => id.TicketId) + 1) : 1;

            Ticket ticket1 = new Ticket("SvcDescriptionRem_" + ticketIdVal, "SvcHeadlineRem_" + ticketIdVal, "SvcNotesRem_" + ticketIdVal);
            var GetFactory = SvcFactory.GetInstance();
            ITicketSvc TicketSvc = (ITicketSvc)GetFactory.GetService("TicketSvcRepoImpl");
            TicketSvc.CreateTicket(ticket1);

            TicketSvc.RemoveTicket(ticket1);

        }

        /// <summary>
        /// Modify Ticket using Ticket Repository Service
        /// </summary>
        [TestMethod]
        public void TestTicketRepoSvcModify()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();

            var ticketIdVal = (db.Tickets.Max(id => (int?)id.TicketId) >= 0) ? (db.Tickets.Max(id => id.TicketId) + 1) : 1;

            Ticket ticket1 = new Ticket("ErrorIFSeen_" + ticketIdVal, "ErrorIfSeen" + ticketIdVal, "ErrorIfSeen" + ticketIdVal);

            var GetFactory = SvcFactory.GetInstance();
            ITicketSvc TicketSvc = (ITicketSvc)GetFactory.GetService("TicketSvcRepoImpl");
            TicketSvc.CreateTicket(ticket1);

            ticket1.Description = "SvcDescriptionMod_" + ticketIdVal;
            ticket1.Headline = "SvcHeadlineMod_" + ticketIdVal;
            ticket1.Notes = "SvcNotesMod_" + ticketIdVal;
            
            TicketSvc.ModifyTicket(ticket1);
        }

        /// <summary>
        /// Retrieve Ticket using Ticket Repository Service
        /// </summary>
        [TestMethod]
        public void TestTicketRepoSvcRetrieve()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();

            var ticketIdVal = (db.Tickets.Max(id => (int?)id.TicketId) >= 0) ? (db.Tickets.Max(id => id.TicketId) + 1) : 1;

            Ticket ticket1 = new Ticket("SvcDescriptionRet_" + ticketIdVal, "SvcHeadlineRet_" + ticketIdVal, "SvcNotesRet_" + ticketIdVal);

            var GetFactory = SvcFactory.GetInstance();
            ITicketSvc TicketSvc = (ITicketSvc)GetFactory.GetService("TicketSvcRepoImpl");
            TicketSvc.CreateTicket(ticket1);

            Ticket Ticket2 = TicketSvc.RetrieveTicket("Notes", "SvcNotesRet_" + ticketIdVal);

            Assert.IsTrue(Ticket2.validateUnitTest());
        }


        /// <summary>
        /// Retrieve All Tickets using Ticket Repository Service
        /// </summary>
        [TestMethod]
        public void testTicketSvcRepoRetrieveAll()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();

            var ticketIdVal = (db.Tickets.Max(id => (int?)id.TicketId) >= 0) ? (db.Tickets.Max(id => id.TicketId) + 1) : 1;

            Ticket ticket1 = new Ticket("SvcDescriptionRetAll_" + ticketIdVal, "SvcHeadlineRetAll_" + ticketIdVal, "SvcNotesRetAll_" + ticketIdVal);

            var TicketRepo = new DataRepository<Ticket>();
            var GetFactory = SvcFactory.GetInstance();
            ITicketSvc TicketSvc = (ITicketSvc)GetFactory.GetService("TicketSvcRepoImpl");
            TicketSvc.CreateTicket(ticket1);


            List<Ticket> myList = TicketSvc.RetrieveAllTickets().ToList<Ticket>();
            Assert.IsTrue(myList.Count > 0);
        }
    }


}