<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateTicket.aspx.cs" Inherits="CreateTicket" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

                <table style="width:99%;">
            <tr>
                <td align="center">
                    
                    <a href="/restricted/ViewAllTickets.aspx">View All Tickets</a></td>
                <td align="center">
                    
                    <a href="/restricted/ViewMyTickets.aspx">View My Tickets</a></td>
                <td align="center">
                    
                    <a href="/restricted/CreateTicket.aspx">Create Ticket</a></td>
                <td align="center">
                    
                   <a href="/restricted/SearchTickets.aspx">Search Ticket</a></td>
                <td align="center">
                    
                    <a href="/Logout.aspx">Logout</a></td>
            </tr>
        </table>
    
       <h1> Create New Ticket</h1>
        Submitter:<br />
        <br />
        
    
        Headline:<br />
        <asp:TextBox ID="HeadlineTextBox" runat="server" Height="18px" Width="608px" MaxLength="255"></asp:TextBox>
        <br />
        <br />
        Description:</div>
        <asp:TextBox ID="DescriptionTextBox" runat="server" Height="220px" TextMode="MultiLine" Width="609px"></asp:TextBox>
        <p>
            <asp:Button ID="SubmitButton" runat="server" OnClick="SubmitButton_Click" Text="Submit" />
        &nbsp;&nbsp;
            <asp:Button ID="CancelButton" runat="server" Text="Cancel" />
        </p>
        
    </form>
</body>
</html>
