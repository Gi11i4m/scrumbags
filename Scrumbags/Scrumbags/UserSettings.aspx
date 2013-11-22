<%@ Page Title="User-settings Page" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UserSettings.aspx.cs" Inherits="Scrumbags.UserSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="MasterContentPlaceHolder" runat="server">
    <div>
        <h1>User-settings Page</h1>
        <div>
            <asp:Label ID="firstNameLabel" AssociatedControlID="firstNameTextbox" runat="server" CssClass="Labels" />
            <asp:TextBox ID="firstNameTextbox" runat="server" CssClass="Textboxes" />
            <asp:RequiredFieldValidator ID="firstNameValidator" Validationgroup="personalInfo" runat="server" ControlToValidate="firstNameTextbox" CssClass="Errormessage" ErrorMessage="First name is required." Display="Dynamic" />
            <asp:RegularExpressionValidator ID="firstNameRegexValidator" Validationgroup="personalInfo" runat="server" ControlToValidate="firstNameTextbox" CssClass="Errormessage" ErrorMessage="First name can only contain letters" ValidationExpression="^[A-z][-A-z]+$" />
            <br />

            <asp:Label ID="lastNameLabel" AssociatedControlID="lastNameTextbox" runat="server" CssClass="Labels"></asp:Label>
            <asp:TextBox ID="lastNameTextbox" runat="server" CssClass="Textboxes" />
            <asp:RequiredFieldValidator ID="lastNameValidator" Validationgroup="personalInfo" runat="server" ControlToValidate="lastNameTextbox" CssClass="Errormessage" ErrorMessage="Last name is required." Display="Dynamic" />
            <asp:RegularExpressionValidator ID="lastNameRegexValidator" Validationgroup="personalInfo" runat="server" ControlToValidate="lastNameTextbox" CssClass="Errormessage" ErrorMessage="Last name can only contain letters" ValidationExpression="^[A-z][- A-z]+$" />
            <br />

            <asp:Label ID="emailLabel" AssociatedControlID="emailTextbox" runat="server" CssClass="Labels"></asp:Label>
            <asp:TextBox ID="emailTextbox" runat="server" TextMode="Email" CssClass="Textboxes" />
            <asp:RequiredFieldValidator ID="emailValidator" Validationgroup="personalInfo" runat="server" ControlToValidate="emailTextbox" CssClass="Errormessage" ErrorMessage="Email is required." Display="Dynamic" />
            <asp:CustomValidator ID="emailInUseValidator" Validationgroup="personalInfo" runat="server" ErrorMessage="This email address is already in use" ControlToValidate="emailTextbox" OnServerValidate="emailInUseValidator_ServerValidate" Display="Dynamic" />
            <br />
            <asp:Button ID="saveSettingsButton" Validationgroup="personalInfo" runat="server" Text="Save settings" onClick="saveSettingsButton_Click"/>
        </div>

        <div>
            <asp:Label ID="newPassword1Label" AssociatedControlID="newPassword1Textbox" runat="server" CssClass="Labels"></asp:Label>
            <asp:TextBox ID="newPassword1Textbox" runat="server" TextMode="Password" CssClass="Textboxes" />
            <br />

            <asp:Label ID="newPassword2Label" AssociatedControlID="newPassword2Textbox" runat="server" CssClass="Labels"></asp:Label>
            <asp:TextBox ID="newPassword2Textbox" runat="server" TextMode="Password" CssClass="Textboxes" />
            <asp:CompareValidator ID="CompareValidator"  Validationgroup="passwords"  runat="server" ControlToValidate="newPassword2Textbox" ControlToCompare="newPassword1Textbox" CssClass="Errormessage" ErrorMessage="Passwords do not match." Display="Dynamic" />
            <br />

            <asp:Label ID="oldPasswordLabel" AssociatedControlID="oldPasswordTextbox" runat="server" CssClass="Labels"></asp:Label>
            <asp:TextBox ID="oldPasswordTextbox" runat="server" TextMode="Password" CssClass="Textboxes" />
            <asp:CustomValidator ID="passwordValidator" Validationgroup="passwords" runat="server" ControlToValidate="oldPasswordTextbox" ErrorMessage="The supplied password is incorrect" OnServerValidate="passwordValidator_ServerValidate" ValidateEmptyText="True" Display="Dynamic"></asp:CustomValidator>
            <br />
            <asp:Button ID="changePasswordButton" Validationgroup="passwords" runat="server" Text="Change password" OnClick="changePasswordButton_Click" />
            <br />
        </div>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </div>


</asp:Content>
