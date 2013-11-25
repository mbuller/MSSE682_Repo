using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewMyTickets : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("/Login.aspx");
        }


    }

    protected void SubmitterObjectDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ListUsersObjectDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {

    }
}