<%@ Page Title="Login" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Scrumbags.Login" MasterPageFile="~/MasterPage.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MasterContentPlaceHolder" runat="server">
    <div id="loginContainer">
        <asp:TextBox ID="emailTextBox" placeholder="Email" runat="server" CssClass="Textboxes" /><br />
        <asp:TextBox ID="passwordTextBox" placeholder="Password" TextMode="Password" runat="server" CssClass="Textboxes" /><br />
        <asp:Button ID="loginButton" runat="server" CssClass="Buttons" OnClick="loginButton_Click" /><br />
        <asp:LinkButton ID="passwordResetLinkButton" CssClass="LoginOptionLinks" runat="server" OnClick="passwordResetLinkButton_Click" /><br />
        <asp:LinkButton ID="newUserLinkButton" CssClass="LoginOptionLinks" runat="server" OnClick="newUserLinkButton_Click" />
    </div>
</asp:Content>
