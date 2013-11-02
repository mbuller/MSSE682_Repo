using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Service;
using Business;

namespace BusinessUnitTest
{

    [TestClass]
    public class StateMgrTest
    {
        /// <summary>
        /// Create State using State Mgr
        /// </summary>
        [TestMethod]
        public void TestStateMgrCreate()
        {
            State state1 = new State("StateNameMgrCreate");

            new StateMgr().CreateState(state1);
        }

        /// <summary>
        /// Remove State using State Mgr
        /// </summary>
        [TestMethod]
        public void TestStateMgrRemove()
        {
            State state1 = new State("StateNameMgrRemove");

            new StateMgr().CreateState(state1);

            new StateMgr().RemoveState(state1);

        }

        /// <summary>
        /// Modify State using State Mgr
        /// </summary>
        [TestMethod]
        public void TestStateMgrModify()
        {
            State state1 = new State("StateNameMgrModify");

            new StateMgr().CreateState(state1);

            state1.StateName = "StatenameMgrModify_" + state1.StateId;


            new StateMgr().ModifyState(state1);
        }

        /// <summary>
        /// Retrieve State using State Mgr
        /// </summary>
        [TestMethod]
        public void TestStateMgrRetrieve()
        {
            State state1 = new State("StateNameMgrRetrieve");

            new StateMgr().CreateState(state1);

            State State2 = new StateMgr().RetrieveState("StateName", "StateNameMgrRetrieve");

            Assert.IsTrue(State2.validateUnitTests());
        }


        /// <summary>
        /// Retrieve All States using State Mgr
        /// </summary>
        [TestMethod]
        public void testStateMgrRetrieveAll()
        {
            State state1 = new State("StateNameMgrRetrieveAll");

            new StateMgr().CreateState(state1);


            List<State> myList = new StateMgr().RetrieveAllStates().ToList<State>();
            Assert.IsTrue(myList.Count > 0);
        }

    }

    [TestClass]
    public class UserMgrTest
    {
        /// <summary>
        /// Create User using User Mgr
        /// </summary>
        [TestMethod]
        public void TestUserMgrCreate()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();

            var userIdVal = (db.Users.Max(id => (int?)id.UserId) >= 0) ? (db.Users.Max(id => id.UserId) + 1) : 1;
            User user1 = new User("UserNameMgrCreate_" + userIdVal);

            new UserMgr().CreateUser(user1);
        }

        /// <summary>
        /// Remove User using User Mgr
        /// </summary>
        [TestMethod]
        public void TestUserMgrRemove()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();

            var userIdVal = (db.Users.Max(id => (int?)id.UserId) >= 0) ? (db.Users.Max(id => id.UserId) + 1) : 1;

            User user1 = new User("UserNameMgrRemove_" + userIdVal);
            new UserMgr().CreateUser(user1);

            new UserMgr().RemoveUser(user1);

        }

        /// <summary>
        /// Modify User using User Mgr
        /// </summary>
        [TestMethod]
        public void TestUserMgrModify()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();

            var userIdVal = (db.Users.Max(id => (int?)id.UserId) >= 0) ? (db.Users.Max(id => id.UserId) + 1) : 1;

            User user1 = new User("ErrorIfSeen" + userIdVal);

            new UserMgr().CreateUser(user1);

            user1.UserName = "UserNameMgrModify_" + userIdVal + user1.UserId;

            new UserMgr().ModifyUser(user1);
        }

        /// <summary>
        /// Retrieve User using User Mgr
        /// </summary>
        [TestMethod]
        public void TestUserMgrRetrieve()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();

            var userIdVal = (db.Users.Max(id => (int?)id.UserId) >= 0) ? (db.Users.Max(id => id.UserId) + 1) : 1;

            User user1 = new User("UserNameMgrRetrieve_" + userIdVal);

            new UserMgr().CreateUser(user1);

            User User2 = new UserMgr().RetrieveUser("Username", "UserNameMgrRetrieve_" + userIdVal);

            Assert.IsTrue(User2.validateUnitTest());
        }


        /// <summary>
        /// Retrieve All Users using User Mgr
        /// </summary>
        [TestMethod]
        public void testUserMgrRetrieveAll()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();

            var userIdVal = (db.Users.Max(id => (int?)id.UserId) >= 0) ? (db.Users.Max(id => id.UserId) + 1) : 1;

            User user1 = new User("UserNameMgrRetieveAll_" + userIdVal);

            new UserMgr().CreateUser(user1);


            List<User> myList = new UserMgr().RetrieveAllUsers().ToList<User>();
            Assert.IsTrue(myList.Count > 0);
        }
    }

    [TestClass]
    public class TicketMgrTest
    {
        /// <summary>
        /// Create Ticket using Ticket Mgr
        /// </summary>
        [TestMethod]
        public void TestTicketMgrCreate()
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

            Ticket ticket1 = new Ticket("DescriptionMgrCreate_" + ticketIdVal, "HeadlineMgrCreate_" + ticketIdVal, "NotesMgrCreate_" + ticketIdVal, (int?)user2.UserId, (int?)user2.UserId, (int?)state2.StateId);

            new TicketMgr().CreateTicket(ticket1);
        }

        /// <summary>
        /// Remove Ticket using Ticket Mgr
        /// </summary>
        [TestMethod]
        public void TestTicketMgrRemove()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();

            var ticketIdVal = (db.Tickets.Max(id => (int?)id.TicketId) >= 0) ? (db.Tickets.Max(id => id.TicketId) + 1) : 1;

            Ticket ticket1 = new Ticket("DescriptionMgrRemove_" + ticketIdVal, "HeadlineMgrRemove_" + ticketIdVal, "NotesMgrRemove_" + ticketIdVal);
            new TicketMgr().CreateTicket(ticket1);

            new TicketMgr().RemoveTicket(ticket1);

        }

        /// <summary>
        /// Modify Ticket using Ticket Mgr
        /// </summary>
        [TestMethod]
        public void TestTicketMgrModify()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();

            var ticketIdVal = (db.Tickets.Max(id => (int?)id.TicketId) >= 0) ? (db.Tickets.Max(id => id.TicketId) + 1) : 1;

            Ticket ticket1 = new Ticket("Description-ErrorIfSeen_" + ticketIdVal, "Headline-ErrorIfSeen_" + ticketIdVal, "Notes-ErrorIfSeen_" + ticketIdVal);

            new TicketMgr().CreateTicket(ticket1);

            ticket1.Description = "DescriptionMgrModify" + ticketIdVal + ticket1.TicketId;
            ticket1.Headline = "HeadlineMgrModify_" + ticketIdVal + ticket1.TicketId;
            ticket1.Notes = "NotesMgrModify_" + ticketIdVal + ticket1.TicketId;

            new TicketMgr().ModifyTicket(ticket1);
        }

        /// <summary>
        /// Retrieve Ticket using Ticket Mgr
        /// </summary>
        [TestMethod]
        public void TestTicketMgrRetrieve()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();

            var ticketIdVal = (db.Tickets.Max(id => (int?)id.TicketId) >= 0) ? (db.Tickets.Max(id => id.TicketId) + 1) : 1;

            Ticket ticket1 = new Ticket("DescriptionMgrRetrieve_" + ticketIdVal, "HeadlineMgrRetrieve_" + ticketIdVal, "NotesMgrRetrive_" + ticketIdVal);

            new TicketMgr().CreateTicket(ticket1);

            Ticket ticket2 = new TicketMgr().RetrieveTicket("Notes", "NotesMgrRetrive_" + ticketIdVal);

            Assert.IsTrue(ticket2.validateUnitTest());
        }


        /// <summary>
        /// Retrieve All Users using Ticket Mgr
        /// </summary>
        [TestMethod]
        public void testTicketMgrRetrieveAll()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();

            var ticketIdVal = (db.Tickets.Max(id => (int?)id.TicketId) >= 0) ? (db.Tickets.Max(id => id.TicketId) + 1) : 1;

            Ticket ticket1 = new Ticket("DescriptionMgrRetrieve_" + ticketIdVal, "HeadlineMgrRetrieve_" + ticketIdVal, "NotesMgrRetrive_" + ticketIdVal);

            new TicketMgr().CreateTicket(ticket1);


            List<Ticket> myList = new TicketMgr().RetrieveAllTickets().ToList<Ticket>();
            Assert.IsTrue(myList.Count > 0);
        }
    }

}
