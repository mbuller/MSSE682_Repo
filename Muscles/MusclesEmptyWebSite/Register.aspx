<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Register New User</h1>
        <br />
        User Name <asp:TextBox ID="UserNameTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        Password&nbsp;&nbsp;
        <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
        <p>
            <asp:Button ID="RegisterButton" runat="server" OnClick="RegisterButton_Click" Text="Register" />
        &nbsp;&nbsp;
            <asp:Button ID="CancelButton" runat="server" Text="Cancel" />
        </p>
        <p>
            <a href="Login.aspx">click here</a> to login with an already registered name</p>
    </form>
</body>
</html>
