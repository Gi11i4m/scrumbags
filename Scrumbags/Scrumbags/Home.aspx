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
        <br />
        <asp:HyperLink ID="ReservationsHyperLink" runat="server" NavigateUrl="~/Reservations.aspx">Check my reservations</asp:HyperLink>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="date" HeaderText="date" SortExpression="date" />
                <asp:BoundField DataField="start" HeaderText="start" SortExpression="start" />
                <asp:BoundField DataField="einde" HeaderText="einde" SortExpression="einde" />
                <asp:BoundField DataField="duration" HeaderText="duration" SortExpression="duration" />
                <asp:BoundField DataField="capacity" HeaderText="capacity" SortExpression="capacity" />
                <asp:BoundField DataField="digital" HeaderText="digital" SortExpression="digital" ReadOnly="True" />
                <asp:BoundField DataField="city" HeaderText="city" SortExpression="city" />
            </Columns>
            <EmptyDataTemplate>
                jik<br />
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LocalConnection %>" SelectCommand="SELECT [date], [start], [einde], [duration],[capacity], [digital] = CASE [digital] WHEN 1 then 'YES' else 'NO' END,  [city], [id] FROM [slots] "></asp:SqlDataSource>
    </form>
</body>
</html>
