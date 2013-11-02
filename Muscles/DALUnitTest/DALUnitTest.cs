using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using DAL;
using System.Collections.Generic;

namespace DALUnitTest
{
    [TestClass]
    public class StateTest
    {
        /// <summary>
        /// test valid State using validate
        /// </summary>
        [TestMethod]
        public void testStateValidateTrue()
        {
            State state1 = new State(1, "ASSIGN");

            Assert.IsTrue(state1.validate());

        }
        /// <summary>
        /// test valid State using validate
        /// </summary>
        [TestMethod]
        public void testStateValidateFalse()
        {
            State state1 = new State();

            Assert.IsFalse(state1.validate());

        }

        /// <summary>
        /// Add State using entities
        /// </summary>
        [TestMethod]
        public void testStateAdd()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();

            State state1 = new State("AddToDB");

            db.States.Add(state1);
            db.SaveChanges();
            Assert.IsTrue(state1.validate());
        }

        /// <summary>
        /// Delete State using entities
        /// </summary>
        [TestMethod]
        public void testStateDelete()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();

            State state1 = new State("DeleteFromDB");

            db.States.Add(state1);
            db.SaveChanges();

            State state2 = (from a in db.States where a.StateName == "DeleteFromDB" select a).Single();
            db.States.Remove(state2);
            db.SaveChanges();
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Insert State using repository
        /// </summary>
        [TestMethod]
        public void testStateInsertUsingRepository()
        {
            var StateRepo = new DataRepository<State>();
            State state1 = new State("stateNameInsRepo");
            StateRepo.Insert(state1);
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Retrieve All States using repository
        /// </summary>
        [TestMethod]
        public void testStateRetrieveAllUsingRepository()
        {
            var StateRepo = new DataRepository<State>();
            State state1 = new State("stateNameRetAllRepo");
            StateRepo.Insert(state1);
            List<State> myList = StateRepo.GetAll().ToList<State>();
            Assert.IsTrue(myList.Count > 0);
        }

        /// <summary>
        /// Retrieve State using repository
        /// </summary>
        [TestMethod]
        public void testStateRetrieveOneUsingRepository()
        {
            var StateRepo = new DataRepository<State>();
            State state1 = new State("stateNameRetRepo");
            StateRepo.Insert(state1);
            State state2 = StateRepo.GetBySpecificKey("StateName", "stateNameRetRepo").FirstOrDefault<State>();
            Assert.IsTrue(state2.validate());
        }

        /// <summary>
        /// Delete State using Repository
        /// </summary>
        [TestMethod]
        public void testStateDeletetUsingRepository()
        {
            var StateRepo = new DataRepository<State>();
            State state1 = new State("stateNameDelRepo");
            StateRepo.Insert(state1);
            StateRepo.Insert(state1);

            StateRepo.Delete(state1);
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Modify State using Repository
        /// </summary>
        [TestMethod]
        public void testStateModifyUsingRepository()
        {
            var StateRepo = new DataRepository<State>();
            State state1 = new State("stateNameModRepo");
            StateRepo.Insert(state1);
            state1.StateName = "stateNameModRepo2";
            StateRepo.Update(state1);
            Assert.IsTrue(true);
        }

    }

    [TestClass]
    public class UserTest
    {
        /// <summary>
        /// test valid User using validate
        /// </summary>
        [TestMethod]
        public void testUserValidateTrue()
        {
            User user1 = new User(1, "userName");

            Assert.IsTrue(user1.validate());

        }
        /// <summary>
        /// test valid User using validate
        /// </summary>
        [TestMethod]
        public void testUserValidateFalse()
        {
            User user1 = new User();

            Assert.IsFalse(user1.validate());

        }

        /// <summary>
        /// Add User using entities
        /// </summary>
        [TestMethod]
        public void testUsereAdd()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();

            var userIdVal = (db.Users.Max(id => (int?)id.UserId) >= 0) ? (db.Users.Max(id => id.UserId) + 1) : 1;

            User user1 = new User("AddToDB_" + userIdVal);

            db.Users.Add(user1);
            db.SaveChanges();
            Assert.IsTrue(user1.validate());
        }

        /// <summary>
        /// Delete User using entities
        /// </summary>
        [TestMethod]
        public void testUserDelete()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();
            var userIdVal = (db.Users.Max(id => (int?)id.UserId) >= 0) ? (db.Users.Max(id => id.UserId) + 1) : 1;

            User user1 = new User("DeleteFromDB_" + userIdVal);

            db.Users.Add(user1);
            db.SaveChanges();

            db.Users.Remove(user1);
            db.SaveChanges();
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Insert User using repository
        /// </summary>
        [TestMethod]
        public void testUserInsertUsingRepository()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();
            var userIdVal = (db.Users.Max(id => (int?)id.UserId) >= 0) ? (db.Users.Max(id => id.UserId) + 1) : 1;

            var UserRepo = new DataRepository<User>();

            User user1 = new User("userNameInsRepo_" + userIdVal);
            UserRepo.Insert(user1);
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Retrieve All Users using repository
        /// </summary>
        [TestMethod]
        public void testUserRetrieveAllUsingRepository()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();
            var userIdVal = (db.Users.Max(id => (int?)id.UserId) >= 0) ? (db.Users.Max(id => id.UserId) + 1) : 1;

            var UserRepo = new DataRepository<User>();
            User user1 = new User("userNameRetAllRepo_" + userIdVal);
            UserRepo.Insert(user1);
            List<User> myList = UserRepo.GetAll().ToList<User>();
            Assert.IsTrue(myList.Count > 0);
        }

        /// <summary>
        /// Retrieve User using repository
        /// </summary>
        [TestMethod]
        public void testUserRetrieveOneUsingRepository()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();
            var userIdVal = (db.Users.Max(id => (int?)id.UserId) >= 0) ? (db.Users.Max(id => id.UserId) + 1) : 1;

            var UserRepo = new DataRepository<User>();
            User user1 = new User("userNameRetRepo_" + userIdVal);
            UserRepo.Insert(user1);
            User user2 = UserRepo.GetBySpecificKey("UserName", "userNameRetRepo_" + userIdVal).FirstOrDefault<User>();
            Assert.IsTrue(user2.validate());
        }

        /// <summary>
        /// Delete User using Repository
        /// </summary>
        [TestMethod]
        public void testUserDeletetUsingRepository()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();
            var userIdVal = (db.Users.Max(id => (int?)id.UserId) >= 0) ? (db.Users.Max(id => id.UserId) + 1) : 1;

            var UserRepo = new DataRepository<User>();
            User user1 = new User("userNameDelRepo_" + userIdVal);
            UserRepo.Insert(user1);
            UserRepo.Insert(user1);

            UserRepo.Delete(user1);
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Modify User using Repository
        /// </summary>
        [TestMethod]
        public void testUserModifyUsingRepository()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();
            var userIdVal = (db.Users.Max(id => (int?)id.UserId) >= 0) ? (db.Users.Max(id => id.UserId) + 1) : 1;

            var UserRepo = new DataRepository<User>();
            User user1 = new User("userNameModRepo_" + userIdVal);
            UserRepo.Insert(user1);
            user1.UserName = "userNameModRepo2_" + userIdVal;
            UserRepo.Update(user1);
            Assert.IsTrue(true);
        }

    }

    [TestClass]
    public class TicketTest
    {
        /// <summary>
        /// test valid Ticket using validate
        /// </summary>
        [TestMethod]
        public void testTicketValidateTrue()
        {
            Ticket ticket1 = new Ticket(1, "description","headline", "Notes", (int?)1, (int?)1, (int?)1);

            Assert.IsTrue(ticket1.validate());

        }

        /// <summary>
        /// test valid User using validate
        /// </summary>
        [TestMethod]
        public void testTicketValidateFalse()
        {
            Ticket ticket1 = new Ticket();

            Assert.IsFalse(ticket1.validate());

        }
        /// <summary>
        /// Add User using entities
        /// </summary>
        [TestMethod]
        public void testTicketAdd()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();

            var StateRepo = new DataRepository<State>();
            State state1 = new State("stateNameRetRepo");
            StateRepo.Insert(state1);
            State state2 = StateRepo.GetBySpecificKey("StateName", "stateNameRetRepo").FirstOrDefault<State>();

            var userIdVal = (db.Users.Max(id => (int?)id.UserId) >= 0) ? (db.Users.Max(id => id.UserId) + 1) : 1;
            var UserRepo = new DataRepository<User>();
            User user1 = new User("userNameRetRepo_" + userIdVal);
            UserRepo.Insert(user1);
            User user2 = UserRepo.GetBySpecificKey("UserName", "userNameRetRepo_" + userIdVal).FirstOrDefault<User>();
           
            var ticketIdVal = (db.Tickets.Max(id => (int?)id.TicketId) >= 0) ? (db.Tickets.Max(id => id.TicketId) + 1) : 1;

            Ticket ticket1 = new Ticket("descriptionAddToDB_" + ticketIdVal,"headlineAddToDB_" + ticketIdVal,"notesAddToDB_" + ticketIdVal,(int?)user2.UserId,(int?)user2.UserId,(int?)state2.StateId);
            //Ticket ticket1 = new Ticket("descriptionAddToDB_" + ticketIdVal, "headlineAddToDB_" + ticketIdVal, "notesAddToDB_" + ticketIdVal);
            db.Tickets.Add(ticket1);
            db.SaveChanges();
            Assert.IsTrue(ticket1.validate());
        }

        /// <summary>
        /// Delete Ticket using entities
        /// </summary>
        [TestMethod]
        public void testTicketDelete()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();
            var ticketIdVal = (db.Tickets.Max(id => (int?)id.TicketId) >= 0) ? (db.Tickets.Max(id => id.TicketId) + 1) : 1;
            Ticket ticket1 = new Ticket("descriptionRemDB_" + ticketIdVal, "headlineRemDB_" + ticketIdVal, "notesRemDB_" + ticketIdVal);

            db.Tickets.Add(ticket1);
            db.SaveChanges();

            db.Tickets.Remove(ticket1);
            db.SaveChanges();
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Insert Ticket using repository
        /// </summary>
        [TestMethod]
        public void testTicketInsertUsingRepository()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();
            var ticketIdVal = (db.Tickets.Max(id => (int?)id.TicketId) >= 0) ? (db.Tickets.Max(id => id.TicketId) + 1) : 1;

            var TicketRepo = new DataRepository<Ticket>();

            Ticket ticket1 = new Ticket("descriptionInsRepo_" + ticketIdVal, "headlineInsRepo_" + ticketIdVal, "notesInsRepo_" + ticketIdVal);
            TicketRepo.Insert(ticket1);
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Retrieve All Tickets using repository
        /// </summary>
        [TestMethod]
        public void testTicketRetrieveAllUsingRepository()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();
            var ticketIdVal = (db.Tickets.Max(id => (int?)id.TicketId) >= 0) ? (db.Tickets.Max(id => id.TicketId) + 1) : 1;

            var TicketRepo = new DataRepository<Ticket>();
            Ticket ticket1 = new Ticket("descriptionRetAllRepo_" + ticketIdVal, "headlineRetAllRepo_" + ticketIdVal, "notesRetAllRepo_" + ticketIdVal);
            TicketRepo.Insert(ticket1);
            List<Ticket> myList = TicketRepo.GetAll().ToList<Ticket>();
            Assert.IsTrue(myList.Count > 0);
        }

        /// <summary>
        /// Retrieve Ticket using repository
        /// </summary>
        [TestMethod]
        public void testTicketRetrieveOneUsingRepository()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();
            var ticketIdVal = (db.Tickets.Max(id => (int?)id.TicketId) >= 0) ? (db.Tickets.Max(id => id.TicketId) + 1) : 1;

            var TicketRepo = new DataRepository<Ticket>();
            Ticket ticket1 = new Ticket("descriptionRetRepo_" + ticketIdVal, "headlineRetRepo_" + ticketIdVal, "notesRetRepo_" + ticketIdVal);
            TicketRepo.Insert(ticket1);
            Ticket ticket2 = TicketRepo.GetBySpecificKey("Description", "descriptionRetRepo_" + ticketIdVal).FirstOrDefault<Ticket>();
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Delete Ticket using Repository
        /// </summary>
        [TestMethod]
        public void testTicketDeletetUsingRepository()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();
            var ticketIdVal = (db.Tickets.Max(id => (int?)id.TicketId) >= 0) ? (db.Tickets.Max(id => id.TicketId) + 1) : 1;

            var TicketRepo = new DataRepository<Ticket>();
            Ticket ticket1 = new Ticket("descriptionDelRepo_" + ticketIdVal, "headlineDelRepo_" + ticketIdVal, "notesDelRepo_" + ticketIdVal);
            TicketRepo.Insert(ticket1);
            TicketRepo.Insert(ticket1);

            TicketRepo.Delete(ticket1);
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Modify Ticket using Repository
        /// </summary>
        [TestMethod]
        public void testTicketModifyUsingRepository()
        {
            bullerMusclesEntities db = new bullerMusclesEntities();
            var ticketIdVal = (db.Tickets.Max(id => (int?)id.TicketId) >= 0) ? (db.Tickets.Max(id => id.TicketId) + 1) : 1;

            var TicketRepo = new DataRepository<Ticket>();
            Ticket ticket1 = new Ticket("descriptionModRepo_" + ticketIdVal, "headlineModRepo_" + ticketIdVal, "notesModRepo_" + ticketIdVal);
            TicketRepo.Insert(ticket1);
            ticket1.Description = "descriptionModRepo2_" + ticketIdVal;
            ticket1.Headline = "headlineModRepo2_" + ticketIdVal;
            ticket1.Notes = "notesModRepo2_" + ticketIdVal;
            TicketRepo.Update(ticket1);
            Assert.IsTrue(true);
        }
    }
}
