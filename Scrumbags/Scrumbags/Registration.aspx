<%@ Page Title="Registration Page" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Scrumbags.Registration" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MasterContentPlaceHolder" runat="server">
    <h1>Registration page</h1>
    <div id="registrationDiv">
        <asp:Label ID="firstNameLabel" AssociatedControlID="firstNameTextbox" runat="server" CssClass="Labels" />
        <asp:TextBox ID="firstNameTextbox" runat="server" CssClass="Textboxes" />
        <asp:RequiredFieldValidator ID="firstNameValidator" runat="server" ControlToValidate="firstNameTextbox" CssClass="Errormessage" ErrorMessage="First name is required." Display="Dynamic" />
        <asp:RegularExpressionValidator ID="firstNameRegexValidator" runat="server" ControlToValidate="firstNameTextbox" CssClass="Errormessage" ErrorMessage="First name can only contain letters" ValidationExpression="^[A-z][-A-z]+$" />
        <br />

        <asp:Label ID="lastNameLabel" AssociatedControlID="lastNameTextbox" runat="server" CssClass="Labels"></asp:Label>
        <asp:TextBox ID="lastNameTextbox" runat="server" CssClass="Textboxes" />
        <asp:RequiredFieldValidator ID="lastNameValidator" runat="server" ControlToValidate="lastNameTextbox" CssClass="Errormessage" ErrorMessage="Last name is required." Display="Dynamic" />
        <asp:RegularExpressionValidator ID="lastNameRegexValidator" runat="server" ControlToValidate="lastNameTextbox" CssClass="Errormessage" ErrorMessage="Last name can only contain letters" ValidationExpression="^[A-z][- A-z]+$" />
        <br />

        <asp:Label ID="emailLabel" AssociatedControlID="emailTextbox" runat="server" CssClass="Labels"></asp:Label>
        <asp:TextBox ID="emailTextbox" runat="server" TextMode="Email" CssClass="Textboxes" />
        <asp:RequiredFieldValidator ID="emailValidator" runat="server" ControlToValidate="emailTextbox" CssClass="Errormessage" ErrorMessage="Email is required." Display="Dynamic" />
        <asp:CustomValidator ID="emailExistsValidator" runat="server" ErrorMessage="This email address is already in use" ControlToValidate="emailTextbox" onServerValidate="emailExistsValidator_ServerValidate" Display="Dynamic" />
        <br />

        <asp:Label ID="password1Label" AssociatedControlID="password1Textbox" runat="server" CssClass="Labels"></asp:Label>
        <asp:TextBox ID="password1Textbox" runat="server" TextMode="Password" CssClass="Textboxes" />
        <asp:RequiredFieldValidator ID="pw1Validator" runat="server" ControlToValidate="password1Textbox" CssClass="Errormessage" ErrorMessage="Password is required" Display="Dynamic" />
        <br />

        <asp:Label ID="password2Label" AssociatedControlID="password2Textbox" runat="server" CssClass="Labels"></asp:Label>
        <asp:TextBox ID="password2Textbox" runat="server" TextMode="Password" CssClass="Textboxes" />
        <asp:CompareValidator ID="CompareValidator" runat="server" ControlToValidate="password2Textbox" ControlToCompare="password1Textbox" CssClass="Errormessage" ErrorMessage="Passwords do not match." Display="Dynamic" />
    </div>
    <br />
    <asp:Button ID="submitButton" runat="server" Text="Register" OnClick="submitButton_Click" />
</asp:Content>
