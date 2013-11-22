<%@ Page Title="User-settings Page" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UserSettings.aspx.cs" Inherits="Scrumbags.UserSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="MasterContentPlaceHolder" runat="server">
    <div>
        <h1>User-settings Page</h1>

        <div>
            <asp:Label ID="newPassword1Label" AssociatedControlID="newPassword1Textbox" runat="server" CssClass="Labels"></asp:Label>
            <asp:TextBox ID="newPassword1Textbox" runat="server" TextMode="Password" CssClass="Textboxes" />
            <asp:RequiredFieldValidator ID="newPassword1Validator" runat="server" ErrorMessage="Please enter a new password"></asp:RequiredFieldValidator>
            <br />

            <asp:Label ID="newPassword2Label" AssociatedControlID="newPassword2Textbox" runat="server" CssClass="Labels"></asp:Label>
            <asp:TextBox ID="newPassword2Textbox" runat="server" TextMode="Password" CssClass="Textboxes" />
            <asp:CompareValidator ID="passwordsCompareValidator" runat="server" ControlToValidate="newPassword2Textbox" ControlToCompare="newPassword1Textbox" CssClass="Errormessage" ErrorMessage="Passwords do not match." Display="Dynamic" />
            <br />

            <asp:Label ID="oldPasswordLabel" AssociatedControlID="oldPasswordTextbox" runat="server" CssClass="Labels"></asp:Label>
            <asp:TextBox ID="oldPasswordTextbox" runat="server" TextMode="Password" CssClass="Textboxes" />
            <asp:RequiredFieldValidator ID="oldPasswordValidator" runat="server" ErrorMessage="Please enter your old password"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="oldPasswordExistsValidator"" runat="server" ControlToValidate="oldPasswordTextbox" ErrorMessage="The supplied password is incorrect" OnServerValidate="passwordValidator_ServerValidate" Display="Dynamic"></asp:CustomValidator>
            <br />
            <asp:Button ID="changePasswordButton" runat="server" Text="Change password" OnClick="changePasswordButton_Click" />
            <br />
        </div>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </div>


</asp:Content>
