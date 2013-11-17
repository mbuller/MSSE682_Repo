<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
 
         <h1>Muscles Home Page</h1>

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
    </form>

</body>
</html>
