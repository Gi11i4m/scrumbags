<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PasswordReset.aspx.cs" Inherits="Scrumbags.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        //popup on success, redirect after closing
        function popup() {
            window.open();
        }
    </script>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MasterContentPlaceHolder" runat="server">

    <asp:Label ID="emailLabel" AssociatedControlID="emailTexbox" runat="server" Text="Label" CssClass="Labels">Email address</asp:Label>
    <asp:TextBox ID="emailTexbox" TextMode="Email" runat="server" CssClass="Textboxs" />
    <asp:CustomValidator runat="server" ID="emailExistsValidator" ControlToValidate="emailTextbox" onServerValidate="emailExistsValidator_ServerValidate" ErrorMessage="This email address does not exist." />
    <br />
    <asp:Button ID="resetButton" runat="server" Text="Reset password" onClick="resetButton_Click"/>

</asp:Content>
