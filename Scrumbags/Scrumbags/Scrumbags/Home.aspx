<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Scrumbags.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:Button ID="LogoutButton" runat="server" OnClick="LogoutButton_Click" Text="Log out" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:HyperLink ID="ReservationsHyperLink" runat="server" NavigateUrl="~/Reservations.aspx">Check my reservations</asp:HyperLink>
        <div style="margin-left: 40px">
            <asp:datagrid ID ="SlotsDataGrid" runat="server" 
        AutoGenerateColumns="False" 
        OnItemDataBound="SlotsDataGrid_ItemDataBound"
                onItemCommand="SlotsDataGrid_OnItemCommand">
                <Columns>
                    <asp:BoundColumn DataField="date" Visible="false" />
                    <asp:BoundColumn DataField="start" HeaderText="Start hour" />
                    <asp:BoundColumn DataField ="einde" HeaderText="End hour" />
                    <asp:BoundColumn DataField="duration" HeaderText="duration" />
                    <asp:BoundColumn DataField="capacity" HeaderText="Teachers needed" />
                    <asp:BoundColumn DataField="digital" HeaderText="Digital?" />
                    <asp:BoundColumn DataField="city" HeaderText="City" />
                    <asp:BoundColumn DataField="id" Visible="false" />
                    <asp:ButtonColumn HeaderText="Select Slot" ButtonType="PushButton" Text="Select" CommandName="SelectSlot" />
                </Columns>
            </asp:datagrid>
        </div>
    
    
    </form>
</body>
</html>
