<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>User Login</h1>
        <p>
            User Name&nbsp;
        <asp:TextBox ID="UserNameTextBox" runat="server"></asp:TextBox>
        </p>
            Password&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
       
            <br />
        <br />
       
            <asp:Button ID="LoginButton" runat="server" OnClick="LoginButton_Click" Text="Login" />
        &nbsp;&nbsp;
            <asp:Button ID="CancelButton" runat="server" Text="Cancel" />
        
        <br />
        <br />
        <a href="Register.aspx">click here</a>
        
        to register a new user</form>
</body>
</html>
