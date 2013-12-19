<%@ Page Title="Home" Language="C#" AutoEventWireup="True" CodeBehind="Home.aspx.cs" Inherits="Scrumbags.Home" MasterPageFile="~/MasterPage.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MasterContentPlaceHolder" runat="server">    
    City?:  
    <asp:DropDownList id="SelectedCity"
                    AutoPostBack="True"
                    OnSelectedIndexChanged="SelectedCity_Selection_Change"
                    runat="server">
        <asp:ListItem Value="Antwerpen"> Antwerpen </asp:ListItem>
        <asp:ListItem Value="Lier"> Lier </asp:ListItem>
        <asp:ListItem Selected="True" Value="*"> All </asp:ListItem>
    </asp:DropDownList> Digital?: 
    <asp:DropDownList id="SelectDigital"
                    AutoPostBack="True"
                    OnSelectedIndexChanged="SelectedDigital_Selection_Change"
                    runat="server">
        <asp:ListItem Value="1"> Yes </asp:ListItem>
        <asp:ListItem Value="0"> No </asp:ListItem>
        <asp:ListItem Selected="True" Value="*"> All </asp:ListItem>
    </asp:DropDownList>

    <div class="TableDiv">
        <asp:DataGrid ID="SlotsDataGrid" runat="server"
            AutoGenerateColumns="False"
            OnItemDataBound="SlotsDataGrid_ItemDataBound"
            OnItemCommand="SlotsDataGrid_OnItemCommand"
            HeaderStyle-CssClass="TableTitle">
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