<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAllTickets.aspx.cs" Inherits="ViewAllTickets" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title></title>
</head>
<body>
    <form id="form1" runat="server">
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

        <h1>View All Tickets</h1>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="DAL.Ticket" SelectMethod="RetrieveAllTickets" TypeName="Business.TicketMgr" UpdateMethod="ModifyTicket" OnSelecting="ObjectDataSource1_Selecting"></asp:ObjectDataSource>
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="TicketId" HeaderText="TicketId" SortExpression="TicketId" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="Headline" HeaderText="Headline" SortExpression="Headline" />
                <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes" />
                <asp:BoundField DataField="Owner_UserId" HeaderText="Owner_UserId" SortExpression="Owner_UserId" />
                <asp:BoundField DataField="Submitter_UserId" HeaderText="Submitter_UserId" SortExpression="Submitter_UserId" />
                <asp:BoundField DataField="TicketState_StateId" HeaderText="TicketState_StateId" SortExpression="TicketState_StateId" />
                <asp:BoundField DataField="TicketOwnerUserName" HeaderText="TicketOwnerUserName" SortExpression="TicketOwnerUserName" />
                <asp:BoundField DataField="TicketSubmitterUserName" HeaderText="TicketSubmitterUserName" SortExpression="TicketSubmitterUserName" />
                <asp:BoundField DataField="TicketStateName" HeaderText="TicketStateName" SortExpression="TicketStateName" />
            </Columns>
        </asp:GridView>
        <br />

    </form>
</body>
</html>
