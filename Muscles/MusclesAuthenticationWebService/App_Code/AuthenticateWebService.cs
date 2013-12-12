using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DAL;
using Business;

/// <summary>
/// Summary description for AuthenticateWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class AuthenticateWebService : System.Web.Services.WebService {

    public AuthenticateWebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
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

    [WebMethod]
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
