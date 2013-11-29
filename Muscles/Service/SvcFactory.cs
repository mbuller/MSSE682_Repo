using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Service
{
    public class SvcFactory
    {
        private SvcFactory() { }
        private static SvcFactory svcFactory = new SvcFactory();
        public static SvcFactory GetInstance() { return svcFactory; }

        /**
         * 
         *  return appropriate Service
         */
        public IService GetService(String service)
        {
            IService ReturnService;

            switch (service)
            {
                case "StateSvcRepoImpl":
                    ReturnService = (IService)new StateSvcRepoImpl();
                    break;
                case "UserSvcRepoImpl":
                    ReturnService = (IService)new UserSvcRepoImpl();
                    break;
                case "TicketSvcRepoImpl":
                    ReturnService = (IService)new TicketSvcRepoImpl();
                    break;
                case "IAuthenticationSvc":
                    ReturnService = (IService)new AuthenticationSvcSocketImpl();
                    //ReturnService = (IService)new AuthenticationSvcRepoImpl();
                    
                    break;
                default:
                    ReturnService = null;
                    throw new System.ArgumentException("Unimplemented Service type in SvcFactory " + ReturnService);

            }

            return ReturnService;

        }
    }
}
