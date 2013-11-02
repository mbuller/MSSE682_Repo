using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class State
    {

         public State(
             int StateId,
             String StateName)
                  
        {
            this.StateId = StateId;
            this.StateName = StateName;
        }

         public State(
             int StateId)
         {
             this.StateId = StateId;
         }

         public State(
             String StateName)
         {
             this.StateName = StateName;
         }

         public bool validate()
         {
             if (StateId < 0)
             {
                 return false;
             }
             if (StateName == null)
             {
                 return false;
             }
             return true;
         }
         public bool validateUnitTests()
         {
             if (StateName == null)
             {
                 return false;
             }
             return true;
         }
         

    }
}
