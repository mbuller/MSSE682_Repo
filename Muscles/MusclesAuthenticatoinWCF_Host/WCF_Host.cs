using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusclesAuthenticationWCF;
using System.ServiceModel;

namespace MusclesAuthenticatoinWCF_Host
{
    class WCF_Host
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Out.WriteLine("Starting Host");
                ServiceHost host = new ServiceHost(typeof(MusclesAuthenticationWCF.AuthenticateWCFImpl));
                host.Open();
                Console.Out.WriteLine("Service started; enter Return to exit application");
                Console.ReadLine();
                host.Close();
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
                Console.ReadLine();
            }

        }
    }
}
