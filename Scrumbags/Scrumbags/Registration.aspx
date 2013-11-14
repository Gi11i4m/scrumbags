<%@ Page Title="Verify account" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Scrumbags.Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MasterContentPlaceHolder" runat="server">
    <h1>Registration page</h1>
    <div id="registrationDiv">
        <asp:Label ID="firstNameLabel" AssociatedControlID="firstNameInput" runat="server" CssClass="Labels"></asp:Label>
        <asp:TextBox ID="firstNameInput" runat="server" CssClass="Textboxs" />
        <asp:RequiredFieldValidator ID="firstNameValidator" runat="server" ControlToValidate="firstNameInput" CssClass="Errormessage" ErrorMessage="First name is required." Display="Dynamic" />
        <asp:RegularExpressionValidator ID="firstNameRegexValidator" runat="server" ControlToValidate="firstNameInput" CssClass="Errormessage" ErrorMessage="First name can only contain letters" ValidationExpression="^[A-z][-A-z]+$" />
        <br />

        <asp:Label ID="lastNameLabel" AssociatedControlID="lastNameInput" runat="server" CssClass="Labels"></asp:Label>
        <asp:TextBox ID="lastNameInput" runat="server" CssClass="Textboxs" />
        <asp:RequiredFieldValidator ID="lastNameValidator" runat="server" ControlToValidate="lastNameInput" CssClass="Errormessage" ErrorMessage="Last name is required." Display="Dynamic" />
        <asp:RegularExpressionValidator ID="lastNameRegexValidator" runat="server" ControlToValidate="lastNameInput" CssClass="Errormessage" ErrorMessage="Last name can only contain letters" ValidationExpression="^[A-z][- A-z]+$" />
        <br />

        <asp:Label ID="emailLabel" AssociatedControlID="emailInput" runat="server" CssClass="Labels"></asp:Label>
        <asp:TextBox ID="emailInput" runat="server" TextMode="Email" CssClass="Textboxs" />
        <asp:RequiredFieldValidator ID="emailValidator" runat="server" ControlToValidate="emailInput" CssClass="Errormessage" ErrorMessage="Email is required." Display="Dynamic" />
        <br />

        <asp:Label ID="password1Label" AssociatedControlID="password1Input" runat="server" CssClass="Labels"></asp:Label>
        <asp:TextBox ID="password1Input" runat="server" TextMode="Password" CssClass="Textboxs" />
        <asp:RequiredFieldValidator ID="pw1Validator" runat="server" ControlToValidate="password1Input" CssClass="Errormessage" ErrorMessage="Password is required" Display="Dynamic" />
        <br />

        <asp:Label ID="password2Label" AssociatedControlID="password2Input" runat="server" CssClass="Labels"></asp:Label>
        <asp:TextBox ID="password2Input" runat="server" TextMode="Password" CssClass="Textboxs" />
        <asp:CompareValidator ID="CompareValidator" runat="server" ControlToValidate="password1Input" ControlToCompare="password2Input" CssClass="Errormessage" ErrorMessage="Passwords do not match." Display="Dynamic" />
    </div>
    <br />
    <br />
    <asp:Button ID="submitButton" runat="server" Text="Register" OnClick="submitButton_Click" />
</asp:Content>
