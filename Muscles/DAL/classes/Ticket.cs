using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class Ticket
    {
        public Ticket() { }

        public Ticket(
            int TicketId,
            String Description,
            String Headline,
            String Notes,
            Nullable<int> Owner_UserId,
            Nullable<int> Submitter_UserId,
            Nullable<int> TicketState_StateId)
        {
            this.TicketId = TicketId;
            this.Description = Description;
            this.Headline = Headline;
            this.Notes = Notes;
            this.Owner_UserId = Owner_UserId;
            this.Submitter_UserId = Submitter_UserId;
            this.TicketState_StateId = TicketState_StateId;
        }

        public Ticket(
        String Description,
        String Headline,
        String Notes,
        Nullable<int> Owner_UserId,
        Nullable<int> Submitter_UserId,
        Nullable<int> TicketState_StateId)
        {
            this.Description = Description;
            this.Headline = Headline;
            this.Notes = Notes;
            this.Owner_UserId = Owner_UserId;
            this.Submitter_UserId = Submitter_UserId;
            this.TicketState_StateId = TicketState_StateId;
        }

        public Ticket(
        int TicketId,
        String Description,
        String Headline,
        String Notes)
        {
            this.TicketId = TicketId;
            this.Description = Description;
            this.Headline = Headline;
            this.Notes = Notes;
        }

        public Ticket(
        String Description,
        String Headline,
        String Notes)
        {
            this.Description = Description;
            this.Headline = Headline;
            this.Notes = Notes;
        }

        public Ticket(
        int TicketId,
        String Description,
        String Headline,
        String Notes,
        Nullable<int> Submitter_UserId,
        Nullable<int> TicketState_StateId)
        {
            this.TicketId = TicketId;
            this.Description = Description;
            this.Headline = Headline;
            this.Notes = Notes;
            this.Owner_UserId = Submitter_UserId;
            this.Submitter_UserId = Submitter_UserId;
            this.TicketState_StateId = TicketState_StateId;
        }

        public Ticket(
        String Description,
        String Headline,
        String Notes,
        Nullable<int> Submitter_UserId,
        Nullable<int> TicketState_StateId)
        {
            this.Description = Description;
            this.Headline = Headline;
            this.Notes = Notes;
            this.Owner_UserId = Submitter_UserId;
            this.Submitter_UserId = Submitter_UserId;
            this.TicketState_StateId = TicketState_StateId;
        }

        public bool validate()
        {
            if (TicketId < 0)
            {
                return false;
            }
            if (Description == null)
            {
                return false;
            }
            if (Headline == null)
            {
                return false;
            }
            if (Notes == null)
            {
                return false;
            }
            if (Owner_UserId == null || Owner_UserId < 0)
            {
                return false;
            }
            if (Submitter_UserId == null || Submitter_UserId < 0)
            {
                return false;
            }
            if (TicketState_StateId == null || TicketState_StateId < 0)
            {
                return false;
            }

            return true;
        }

        public bool validateUnitTest()
        {

            if (Description == null)
            {
                return false;
            }
            if (Headline == null)
            {
                return false;
            }
            if (Notes == null)
            {
                return false;
            }
         
            return true;
        }

    }
}
