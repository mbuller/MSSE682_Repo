<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewMyTickets.aspx.cs" Inherits="ViewMyTickets" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" submitdisabledcontrols="False">
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

       <h1>View My Tickets</h1> 
        </div>
    <h2>Submitted Tickets</h2>
        
        <asp:ObjectDataSource ID="SubmitterObjectDataSource" runat="server" OnSelecting="SubmitterObjectDataSource_Selecting" SelectMethod="RetrieveTickets" TypeName="Business.TicketMgr" DataObjectTypeName="DAL.Ticket" UpdateMethod="ModifyTicket">
            <SelectParameters>
                <asp:Parameter Name="DBColumnName" Type="String" DefaultValue="Submitter_UserId" />
                <asp:SessionParameter Name="NullableIntValue" SessionField="id" Type="Int32" DefaultValue="" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SubmitterObjectDataSource" AllowPaging="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="TicketId" HeaderText="TicketId" ReadOnly="True" SortExpression="TicketId" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="Headline" HeaderText="Headline" SortExpression="Headline" />
                <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes" />
                <asp:BoundField DataField="Owner_UserId" HeaderText="Owner_UserId" SortExpression="Owner_UserId" ReadOnly="True" />
                <asp:BoundField DataField="Submitter_UserId" HeaderText="Submitter_UserId" SortExpression="Submitter_UserId" ReadOnly="True" />
                <asp:BoundField DataField="TicketState_StateId" HeaderText="TicketState_StateId" SortExpression="TicketState_StateId" ReadOnly="True" />
                <asp:BoundField DataField="TicketOwnerUserName" HeaderText="Owner" SortExpression="TicketOwnerUserName" />
                <asp:BoundField DataField="TicketSubmitterUserName" HeaderText="Submitter" ReadOnly="True" SortExpression="TicketSubmitterUserName" />
                <asp:BoundField DataField="TicketStateName" HeaderText="State" SortExpression="TicketStateName" />
            </Columns>
        </asp:GridView>
        <br />
    <h2>Owned Tickets</h2>
        <p>
            <asp:ObjectDataSource ID="OwnerObjectDataSource" runat="server" SelectMethod="RetrieveTickets" TypeName="Business.TicketMgr" DataObjectTypeName="DAL.Ticket" UpdateMethod="ModifyTicket">
                <SelectParameters>
                    <asp:Parameter DefaultValue="Owner_UserId" Name="DBColumnName" Type="String" />
                    <asp:SessionParameter DefaultValue="" Name="NullableIntValue" SessionField="id" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </p>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="OwnerObjectDataSource" AllowPaging="True">
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="TicketId" HeaderText="TicketId" SortExpression="TicketId" ReadOnly="True" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="Headline" HeaderText="Headline" SortExpression="Headline" />
                <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes" />
                <asp:BoundField DataField="Owner_UserId" HeaderText="Owner_UserId" SortExpression="Owner_UserId" ReadOnly="True" />
                <asp:BoundField DataField="Submitter_UserId" HeaderText="Submitter_UserId" SortExpression="Submitter_UserId" ReadOnly="True" />
                <asp:BoundField DataField="TicketState_StateId" HeaderText="TicketState_StateId" SortExpression="TicketState_StateId" ReadOnly="True" />
                <asp:BoundField DataField="TicketOwnerUserName" HeaderText="Owner" SortExpression="TicketOwnerUserName" />
                <asp:BoundField DataField="TicketSubmitterUserName" HeaderText="Submitter" ReadOnly="True" SortExpression="TicketSubmitterUserName" />
                <asp:BoundField DataField="TicketStateName" HeaderText="State" SortExpression="TicketStateName" />
            </Columns>
        </asp:GridView>
    </form>
    </body>
</html>
