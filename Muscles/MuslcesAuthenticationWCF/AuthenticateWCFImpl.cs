using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DAL;
using Business;
using Service;

namespace MusclesAuthenticationWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AuthenticateWCFImpl" in both code and config file together.
    public class AuthenticateWCFImpl : IAuthenticateWCF
    {
     /*   public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        */
        public bool Register(String un, String pw)
        {
            bool registeredUser = false;
            string incommingUN = un;
            string incommingPW = pw;
            Console.WriteLine("(wcf registration): credentials received for " + incommingUN + "...");

            //retrieve a user with set username...
            User checkUserName = new UserMgr().RetrieveUser("UserName", incommingUN);

            //if checkUserName is null, then no user was found iwth the requested username
            //and therefore can be used to create a new user
            if (checkUserName == null)
            {
                User user1 = new User(incommingUN, incommingPW);
                new UserMgr().CreateUser(user1);

                //set registeredUser to true since this wil be returned back to the client
                registeredUser = true;

            }
            if (registeredUser)
                Console.WriteLine("(wcf registration): Registration successful for " + incommingUN + "...");
            else
                Console.WriteLine("(wcf registration): Registration failed for " + incommingUN + "...");

            //return to the client whether we retistered a new user or not
            return registeredUser;
        }

        public bool Login(String un, String pw)
        {

            string loginUN = un;
            string loginPW = pw;
            bool authenticated = false; 

            Console.WriteLine("(wcf login): credentials... " + loginUN + "...");


            User user1 = new UserMgr().RetrieveUser("UserName", loginUN);

            if (user1 != null)
            {
                Console.WriteLine("(wcf login): user found for " + user1.UserName + "...");
                if (user1.UserName == loginUN)
                {
                    if (user1.Password == loginPW)
                    {
                        authenticated = true;
                    }
                }
            }
            if (authenticated)
                Console.WriteLine("(wcf login): access granted for " + loginUN + "...");
            else
                Console.WriteLine("(wcf login): acces denied for " + loginUN + "...");
            return authenticated;

        }
    }
}
