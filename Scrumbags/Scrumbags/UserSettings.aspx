<%@ Page Title="Settings" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UserSettings.aspx.cs" Inherits="Scrumbags.UserSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="MasterContentPlaceHolder" runat="server">
    <div class="DivWithBackground">
        <h1>Settings</h1>
        <div>
            <asp:Label ID="newPassword1Label" AssociatedControlID="newPassword1Textbox" runat="server" CssClass="Labels"></asp:Label>
            <asp:TextBox ID="newPassword1Textbox" runat="server" TextMode="Password" CssClass="Textboxes"/>
            <asp:RequiredFieldValidator ID="newPassword1Validator" ControlToValidate="newPassword1Textbox" runat="server" ErrorMessage="Please enter a new password" Validationgroup="passwordControls"  Display="Dynamic"></asp:RequiredFieldValidator>
            <br />

            <asp:Label ID="newPassword2Label" AssociatedControlID="newPassword2Textbox" runat="server" CssClass="Labels"></asp:Label>
            <asp:TextBox ID="newPassword2Textbox" runat="server" TextMode="Password" CssClass="Textboxes"/>
            <asp:RequiredFieldValidator ID="newPassword2Validator" runat="server" ControlToValidate="newPassword2Textbox" CssClass="Errormessage" ErrorMessage="Repeat your password" Validationgroup="passwordControls" Display="Dynamic" />
            <asp:CompareValidator ID="passwordsCompareValidator" runat="server" ControlToValidate="newPassword2Textbox" ControlToCompare="newPassword1Textbox" CssClass="Errormessage" ErrorMessage="Passwords do not match." Validationgroup="passwordControls" Display="Dynamic" />
            <br />

            <asp:Label ID="oldPasswordLabel" AssociatedControlID="oldPasswordTextbox" runat="server" CssClass="Labels"></asp:Label>
            <asp:TextBox ID="oldPasswordTextbox" runat="server" TextMode="Password" CssClass="Textboxes" />
            <asp:RequiredFieldValidator ID="oldPasswordValidator" runat="server" ControlToValidate="oldPasswordTextbox" ErrorMessage="Please enter your old password" Validationgroup="passwordControls" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="oldPasswordCorrectValidator" runat="server" ControlToValidate="oldPasswordTextbox" ErrorMessage="The supplied password is incorrect" OnServerValidate="passwordValidator_ServerValidate" ValidationGroup="passwordControls" Display="Dynamic"></asp:CustomValidator>
            <br />
            <asp:Button ID="changePasswordButton" runat="server" Text="Change password" OnClick="changePasswordButton_Click" Validationgroup="passwordControls"/>
            <br />
        </div>
        <div>
            <asp:TextBox ID="siteMessageTextbox" runat="server" TextMode="multiline"></asp:TextBox>
            <br />
            <asp:Button ID="submitSiteMessageButton" runat="server" Text="Set message" OnClick="submitSiteMessageButton_Click"/>
        </div>
    </div>
</asp:Content>
