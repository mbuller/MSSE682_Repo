using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticaitonWCFConsole.ServiceReference1;

namespace AuthenticaitonWCFConsole
{
    class AuthenticationWCF_Client
    {
        static void Main(string[] args)
        {

            ServiceReference1.LoginWCFImplClient proxy = new LoginWCFImplClient()
;
            while (true)
            {
                //String s = proxy.Hello("JohnUN", "DoePW");
                Console.Out.WriteLine("Enter user name");

                String un = Console.ReadLine();
                Console.Out.WriteLine("Enter pw");

                String pw = Console.ReadLine();
                Boolean b = proxy.Login(un, pw);
                Console.Out.WriteLine(b);
                //Console.ReadLine();
            }
        }
    }
}
