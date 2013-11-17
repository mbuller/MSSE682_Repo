<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchTickets.aspx.cs" Inherits="SearchTickets" %>

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

        <h1>Currently under construction....</h1>
        <h1>Search Tickets</h1>
        
        <br />
    
    &nbsp;
            
        <br />
        <br />
        <table style="width:99%; margin-left: 50px;">
            <tr>
                <td style="width:200px" </td>
                <td>
       
    
        <asp:TextBox ID="TextBox1" runat="server" style="width:100%"></asp:TextBox>
    
    
                </td>
                <td style="width:200px" </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
        <asp:Button ID="Button1" runat="server" Text="Search" />
    
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
