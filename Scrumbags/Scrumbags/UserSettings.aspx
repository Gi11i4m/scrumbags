<%@ Page Title="Settings" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UserSettings.aspx.cs" Inherits="Scrumbags.UserSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="MasterContentPlaceHolder" runat="server">
    <div class="DivWithBackground">
        <h1>Settings</h1>
        <asp:Label ID="newPassword1Label" AssociatedControlID="newPassword1Textbox" runat="server" CssClass="Labels"></asp:Label>
        <asp:TextBox ID="newPassword1Textbox" runat="server" TextMode="Password" CssClass="Textboxes" />
        <asp:RequiredFieldValidator ID="newPassword1Validator" ControlToValidate="newPassword1Textbox" runat="server" ErrorMessage="Please enter a new password" ValidationGroup="passwordControls" Display="Dynamic"></asp:RequiredFieldValidator>
        <br />

        <asp:Label ID="newPassword2Label" AssociatedControlID="newPassword2Textbox" runat="server" CssClass="Labels"></asp:Label>
        <asp:TextBox ID="newPassword2Textbox" runat="server" TextMode="Password" CssClass="Textboxes" />
        <asp:RequiredFieldValidator ID="newPassword2Validator" runat="server" ControlToValidate="newPassword2Textbox" CssClass="Errormessage" ErrorMessage="Repeat your password" ValidationGroup="passwordControls" Display="Dynamic" />
        <asp:CompareValidator ID="passwordsCompareValidator" runat="server" ControlToValidate="newPassword2Textbox" ControlToCompare="newPassword1Textbox" CssClass="Errormessage" ErrorMessage="Passwords do not match." ValidationGroup="passwordControls" Display="Dynamic" />
        <br /><br />

        <asp:Label ID="oldPasswordLabel" AssociatedControlID="oldPasswordTextbox" runat="server" CssClass="Labels"></asp:Label>
        <asp:TextBox ID="oldPasswordTextbox" runat="server" TextMode="Password" CssClass="Textboxes" />
        <asp:RequiredFieldValidator ID="oldPasswordValidator" runat="server" ControlToValidate="oldPasswordTextbox" ErrorMessage="Please enter your old password" ValidationGroup="passwordControls" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:CustomValidator ID="oldPasswordCorrectValidator" runat="server" ControlToValidate="oldPasswordTextbox" ErrorMessage="The supplied password is incorrect" OnServerValidate="passwordValidator_ServerValidate" ValidationGroup="passwordControls" Display="Dynamic"></asp:CustomValidator>
        <br /><br />
        <asp:Button ID="changePasswordButton" runat="server" Text="Change password" OnClick="changePasswordButton_Click" ValidationGroup="passwordControls" />
        <br />
    </div>
    <br />
    <div class="DivWithBackgroundHidable">
        <asp:Literal ID="siteMessageHeaderLiteral" runat="server"><h1 class="HidableControl">Site message</h1></asp:Literal>
        <asp:TextBox ID="siteMessageTextbox" runat="server" TextMode="multiline" Rows="5" Width="300 px" CssClass="HidableControl"></asp:TextBox>
        <br /><br />
        <asp:Button ID="submitSiteMessageButton" runat="server" Text="Set message" OnClick="submitSiteMessageButton_Click" CssClass="HidableControl"/>
    </div>
</asp:Content>
