<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Scrumbags.Login" MasterPageFile="~/MasterPage.Master" Title="Login Page" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MasterContentPlaceHolder" runat="server">
    <asp:Label ID="emailLabel" AssociatedControlID="emailTextBox" runat="server" Text="Email"></asp:Label><asp:TextBox ID="emailTextBox" Text="Email" runat="server" /><br />
    <asp:Label ID="passwordLabel" AssociatedControlID="passwordTextBox" runat="server" Text="Password"></asp:Label><asp:TextBox ID="passwordTextBox" TextMode="Password" runat="server" /><br />
    <asp:LinkButton ID="passwordResetLinkButton" runat="server" Text="Reset your password" OnClick="passwordResetLinkButton_Click" />
</asp:Content>