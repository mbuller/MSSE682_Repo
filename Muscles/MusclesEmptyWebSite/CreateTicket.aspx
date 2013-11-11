<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateTicket.aspx.cs" Inherits="CreateTicket" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
       <h1> Create New Ticket</h1>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Submitter: "></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Owner: "></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Headline:"></asp:Label>
    
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Height="18px" Width="608px" MaxLength="255"></asp:TextBox>
        <br />
        <br />
        Description:</div>
        <asp:TextBox ID="TextBox2" runat="server" Height="220px" TextMode="MultiLine" Width="609px"></asp:TextBox>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
        &nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Cancle" />
        </p>
    </form>
</body>
</html>
