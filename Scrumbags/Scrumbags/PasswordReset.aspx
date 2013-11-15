<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PasswordReset.aspx.cs" Inherits="Scrumbags.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MasterContentPlaceHolder" runat="server">

    <asp:Label ID="emailLabel" AssociatedControlID="emailTextbox" runat="server" CssClass="Labels" />
    <asp:TextBox ID="emailTextbox" TextMode="Email" runat="server" CssClass="Textboxes" />
    <asp:CustomValidator runat="server" ID="emailExistsValidator" ControlToValidate="emailTextbox" onServerValidate="emailExistsValidator_ServerValidate" ErrorMessage="This email address does not exist." Display="Dynamic"/>
    <br />
    <asp:Button ID="resetButton" runat="server" Text="Reset password" onClick="resetButton_Click"/>

</asp:Content>
