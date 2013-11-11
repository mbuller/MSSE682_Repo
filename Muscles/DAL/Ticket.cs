//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ticket
    {
        public int TicketId { get; set; }
        public string Description { get; set; }
        public string Headline { get; set; }
        public string Notes { get; set; }
        public Nullable<int> Owner_UserId { get; set; }
        public Nullable<int> Submitter_UserId { get; set; }
        public Nullable<int> TicketState_StateId { get; set; }
        public string TicketOwnerUserName { get; set; }
        public string TicketSubmitterUserName { get; set; }
        public string TicketStateName { get; set; }
    
        public virtual User Owner { get; set; }
        public virtual User Submitter { get; set; }
        public virtual State State { get; set; }
    }
}