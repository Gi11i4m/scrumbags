<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reservations.aspx.cs" Inherits="Scrumbags.Reservations" MasterPageFile="~/MasterPage.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MasterContentPlaceHolder" runat="server">
    <div class="ContentDiv">
        <asp:DataGrid ID="ReservedSlotsDataGrid" runat="server"
            AutoGenerateColumns="False"
            OnItemDataBound="ReservedSlotsDataGrid_ItemDataBound"
            OnItemCommand="ReservedSlotsDataGrid_OnItemCommand">
            <Columns>
                <asp:BoundColumn DataField="date" Visible="false" />
                <asp:BoundColumn DataField="start" HeaderText="Start" />
                <asp:BoundColumn DataField="einde" HeaderText="End" />
                <asp:BoundColumn DataField="duration" HeaderText="Duration" />
                <asp:BoundColumn DataField="digital" HeaderText="Digital?" />
                <asp:BoundColumn DataField="city" HeaderText="City" />
                <asp:BoundColumn DataField="id" Visible="false" />
                <asp:ButtonColumn HeaderText="Select Slot" ButtonType="PushButton" Text="Annuleer Reservatie" CommandName="SelectSlot" />
            </Columns>
        </asp:DataGrid>
   
    </div>
</asp:Content>
