<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchTickets.aspx.cs" Inherits="SearchTickets" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
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
