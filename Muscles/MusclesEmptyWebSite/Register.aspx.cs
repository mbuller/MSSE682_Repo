using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Business;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TextBox1_TextChanged1(object sender, EventArgs e)
    {

    }
    protected void RegisterButton_Click(object sender, EventArgs e)
    {
        string username = UserNameTextBox.Text;
        string password = PasswordTextBox.Text;
        User user1 = new User(username, password);
        User checkUserName = new UserMgr().RetrieveUser("UserName", username);
        if (checkUserName == null)
        {
            new UserMgr().CreateUser(user1);
            //Response.BufferOutput = true;
            Session["user"] = user1;
            Session["id"] = user1.UserId;
            Session["username"] = user1.UserName;
            Response.Redirect("/Restricted/Home.aspx");
        }
        else
            Response.Redirect("/Register.aspx");
    }
}