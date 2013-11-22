<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reservations.aspx.cs" Inherits="Scrumbags.Reservations" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:HyperLink ID="HomePageHyperLink" runat="server" NavigateUrl="~/Home.aspx">Back to slots</asp:HyperLink>
    
    </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="date" HeaderText="date" SortExpression="date" />
                <asp:BoundField DataField="start" HeaderText="start" SortExpression="start" />
                <asp:BoundField DataField="einde" HeaderText="einde" SortExpression="einde" />
                <asp:BoundField DataField="duration" HeaderText="duration" SortExpression="duration" />
                <asp:BoundField DataField="capacity" HeaderText="capacity" SortExpression="capacity" />
                <asp:BoundField DataField="digital" HeaderText="digital" SortExpression="digital" />
                <asp:BoundField DataField="city" HeaderText="city" SortExpression="city" />
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnections.connectionString %>" SelectCommand="SELECT [date], [start], [einde], [duration], [capacity], [digital], [city], [id] FROM [slots] WHERE id IN (SELECT slot_id FROM reservations  WHERE lecturer_id = @id)">
            <SelectParameters>
                <asp:SessionParameter Name="id" SessionField="id" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
