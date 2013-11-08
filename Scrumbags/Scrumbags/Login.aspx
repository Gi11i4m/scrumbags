<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Scrumbags.Login" MasterPageFile="~/MasterPage.Master" Title="Login Page" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MasterContentPlaceHolder" runat="server">
    <asp:Label ID="emailLabel" runat="server" Text="Email"></asp:Label><br />
    <asp:Label ID="passwordLabel" runat="server" Text="Password"></asp:Label><br />
    <asp:LinkButton ID="passwordResetLinkButton" runat="server" Text="Reset your password" OnClick="passwordResetLinkButton_Click"></asp:LinkButton>
</asp:Content>