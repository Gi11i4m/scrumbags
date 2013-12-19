<%@ Page Title="Reservation Page" Language="C#" AutoEventWireup="true" CodeBehind="Reservations.aspx.cs" Inherits="Scrumbags.Reservations" MasterPageFile="~/MasterPage.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MasterContentPlaceHolder" runat="server">
    <div class="TableDiv">
        <asp:GridView ID="ReservedSlotsDataGrid" runat="server" 
            AutoGenerateColumns="False" 
            DataKeyNames="id" 
            OnSelectedIndexChanged="ReservedSlotsDataGrid_SelectedIndexChanged"
            HeaderStyle-CssClass="TableTitle">
            <Columns>                
                <asp:BoundField DataField="date" HeaderText="Date" SortExpression="date" />
                <asp:BoundField DataField="start" HeaderText="Start" SortExpression="start" />
                <asp:BoundField DataField="einde" HeaderText="End" SortExpression="einde" />
                <asp:BoundField DataField="duration" HeaderText="Duration" SortExpression="duration" />
                <asp:BoundField DataField="capacity" HeaderText="Capacity" SortExpression="capacity" />
                <asp:BoundField DataField="digital" HeaderText="Digital?" SortExpression="digital" />
                <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
                <asp:BoundField DataField="id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:CommandField ShowSelectButton="True" ButtonType="Button" SelectText="Remove" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LocalConnection %>" SelectCommand="SELECT [date], [start], [einde], [duration], [capacity], [digital], [city], [id] FROM [slots] WHERE id IN (SELECT slot_id FROM reservations  WHERE lecturer_id = @id)">
            <SelectParameters>
                <asp:SessionParameter Name="id" SessionField="id" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>