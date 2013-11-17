using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Business;

public partial class CreateTicket : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("/Login.aspx");
        }
    }
  /*  protected void Button1_Click(object sender, EventArgs e)
    {
        Label4.Text = TextBox2.Text;
    }

    protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {

    }

    protected void Page_Init(object sender, EventArgs e)
    {
        DetailsView1.EnableDynamicData(typeof(Ticket));
    }
   */
    protected void SubmitButton_Click(object sender, EventArgs e)
    {        
        string description = DescriptionTextBox.Text;
        string headline = HeadlineTextBox.Text;
        Ticket ticket1 = new Ticket(description, headline);
        User user1 = (User)Session["user"];
        State state1 = new StateMgr().RetrieveState("StateId", 1);
        if (state1 != null)
        {
            ticket1.TicketState_StateId = (int?)state1.StateId;
        }
        ticket1.Owner_UserId = user1.UserId;
        ticket1.Submitter_UserId = user1.UserId;
        //ticket1.Submitter = user1;
        //ticket1.Owner = user1;

        new TicketMgr().CreateTicket(ticket1);
        //Response.BufferOutput = true;
        Response.Redirect("/Restricted/ViewMyTickets.aspx");
    }
}