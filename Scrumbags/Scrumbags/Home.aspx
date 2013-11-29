<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Home.aspx.cs" Inherits="Scrumbags.Home" MasterPageFile="~/MasterPage.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MasterContentPlaceHolder" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:HyperLink ID="ReservationsHyperLink" runat="server" NavigateUrl="~/Reservations.aspx">Check my reservations</asp:HyperLink>
    <div style="margin-left: 40px">
        <asp:DataGrid ID="SlotsDataGrid" runat="server"
            AutoGenerateColumns="False"
            OnItemDataBound="SlotsDataGrid_ItemDataBound"
            OnItemCommand="SlotsDataGrid_OnItemCommand">
            <Columns>
                <asp:BoundColumn DataField="date" Visible="false" />
                <asp:BoundColumn DataField="start" HeaderText="Start hour" />
                <asp:BoundColumn DataField="einde" HeaderText="End hour" />
                <asp:BoundColumn DataField="duration" HeaderText="duration" />
                <asp:BoundColumn DataField="capacity" HeaderText="Teachers needed" />
                <asp:BoundColumn DataField="digital" HeaderText="Digital?" />
                <asp:BoundColumn DataField="city" HeaderText="City" />
                <asp:BoundColumn DataField="id" Visible="false" />
                <asp:ButtonColumn HeaderText="Select Slot" ButtonType="PushButton" Text="Select" CommandName="SelectSlot" />
            </Columns>
        </asp:DataGrid>
    </div>
</asp:Content>
