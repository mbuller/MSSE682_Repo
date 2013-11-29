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
       
        bool registeredUser = new AuthenticationMgr().RegisterUser(username, password);
        if (registeredUser == true)
        {
          
            Response.Redirect("/Login.aspx");
        }
        else
            Response.Redirect("/Register.aspx");
    }
}