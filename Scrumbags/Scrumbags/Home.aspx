<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Home.aspx.cs" Inherits="Scrumbags.Home" MasterPageFile="~/MasterPage.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MasterContentPlaceHolder" runat="server">    
    <div class="ContentDiv">
        <asp:DataGrid ID="SlotsDataGrid" runat="server"
            AutoGenerateColumns="False"
            OnItemDataBound="SlotsDataGrid_ItemDataBound"
            OnItemCommand="SlotsDataGrid_OnItemCommand">
            <Columns>
                <asp:BoundColumn DataField="date" Visible="false" />
                <asp:BoundColumn DataField="start" HeaderText="Start" />
                <asp:BoundColumn DataField="einde" HeaderText="End" />
                <asp:BoundColumn DataField="duration" HeaderText="Duration" />
                <asp:BoundColumn DataField="capacity" HeaderText="Teachers needed" />
                <asp:BoundColumn DataField="digital" HeaderText="Digital?" />
                <asp:BoundColumn DataField="city" HeaderText="City" />
                <asp:BoundColumn DataField="id" Visible="false" />
                <asp:ButtonColumn HeaderText="Select Slot" ButtonType="PushButton" Text="Select" CommandName="SelectSlot" />
            </Columns>
        </asp:DataGrid>
    </div>
</asp:Content>