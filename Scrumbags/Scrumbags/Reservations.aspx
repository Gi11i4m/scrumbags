<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reservations.aspx.cs" Inherits="Scrumbags.Reservations" MasterPageFile="~/MasterPage.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MasterContentPlaceHolder" runat="server">
    <div>
        <asp:HyperLink ID="HomePageHyperLink" runat="server" NavigateUrl="~/Home.aspx">Back to slots</asp:HyperLink>    
    </div>
        <asp:DataGrid ID="ReservedSlotsDataGrid" runat="server"
            AutoGenerateColumns="False"
            OnItemDataBound="ReservedSlotsDataGrid_ItemDataBound"
            OnItemCommand="ReservedSlotsDataGrid_OnItemCommand">
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
</asp:Content>