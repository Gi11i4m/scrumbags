<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PasswordReset.aspx.cs" Inherits="Scrumbags.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MasterContentPlaceHolder" runat="server">
    <asp:Label ID="emailLabel" AssociatedControlID="emailTexbox" runat="server" Text="Label" CssClass="Labels">Email address</asp:Label>
    <asp:TextBox ID="emailTexbox" TextMode="Email" runat="server" CssClass="Textboxs" />
    <br />
    <asp:Button ID="resetButton" runat="server" Text="Reset password" onClick="resetButton_Click"/>
</asp:Content>
