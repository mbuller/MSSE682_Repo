<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAllTickets.aspx.cs" Inherits="ViewAllTickets" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>View All Tickets</h1>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="DAL.Ticket" SelectMethod="RetrieveAllTickets" TypeName="Business.TicketMgr" UpdateMethod="ModifyTicket"></asp:ObjectDataSource>
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowEditButton="True" ShowSelectButton="True" />
                <asp:BoundField DataField="TicketId" HeaderText="TicketId" SortExpression="TicketId" />
                <asp:BoundField DataField="Headline" HeaderText="Headline" SortExpression="Headline" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="TicketStateName" HeaderText="State" SortExpression="TicketStateName" />
                <asp:BoundField DataField="TicketOwnerUserName" HeaderText="Owner" SortExpression="TicketOwnerUserName" />
                <asp:BoundField DataField="TicketSubmitterUserName" HeaderText="Submitter" SortExpression="TicketSubmitterUserName" />
                <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes" />
            </Columns>
        </asp:GridView>
        <br />

    </form>
</body>
</html>
