using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Business;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void UserName_TextChanged(object sender, EventArgs e)
    {
        

    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        string username = UserNameTextBox.Text;
        string password = PasswordTextBox.Text;
        bool allowAccess = new AuthenticationMgr().AuthenticateUser(username, password);
        if (allowAccess == true)
        {
            User user1 = new UserMgr().RetrieveUser("UserName", username);

            if (user1 != null)
            {
                Session["user"] = user1;
                Session["id"] = user1.UserId;
                Session["username"] = user1.UserName;
                Response.Redirect("/Restricted/Home.aspx");
            }
            else
                Response.Redirect("/Login.aspx");
        }
        //Response.BufferOutput = true;
        Response.Redirect("/Login.aspx");
    }
}