<%@ Page Title="Registration" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Scrumbags.Registration" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MasterContentPlaceHolder" runat="server">
    <div class="DivWithBackground">
        <h1>Registration page</h1>
        <div id="registrationDiv">
            <asp:Label ID="firstNameLabel" AssociatedControlID="firstNameTextbox" runat="server" CssClass="Labels" />
            <asp:TextBox ID="firstNameTextbox" runat="server" CssClass="Textboxes" />
            <asp:RequiredFieldValidator ID="firstNameValidator" runat="server" ControlToValidate="firstNameTextbox" CssClass="Errormessage" Display="Dynamic" ErrorMessage="First name is required." />
            <asp:RegularExpressionValidator ID="firstNameRegexValidator" runat="server" ControlToValidate="firstNameTextbox" CssClass="Errormessage" Display="Dynamic" ErrorMessage="First name can only contain letters" ValidationExpression="^[A-z][-A-z]+$" />
            <br />

            <asp:Label ID="lastNameLabel" AssociatedControlID="lastNameTextbox" runat="server" CssClass="Labels"></asp:Label>
            <asp:TextBox ID="lastNameTextbox" runat="server" CssClass="Textboxes" />
            <asp:RequiredFieldValidator ID="lastNameValidator" runat="server" ControlToValidate="lastNameTextbox" CssClass="Errormessage" Display="Dynamic" ErrorMessage="Last name is required." />
            <asp:RegularExpressionValidator ID="lastNameRegexValidator" runat="server" ControlToValidate="lastNameTextbox" CssClass="Errormessage" Display="Dynamic" ErrorMessage="Last name can only contain letters" ValidationExpression="^[A-z][- A-z]+$" />
            <br /><br />

            <asp:Label ID="emailLabel" AssociatedControlID="emailTextbox" runat="server" CssClass="Labels"></asp:Label>
            <asp:TextBox ID="emailTextbox" runat="server" TextMode="Email" CssClass="Textboxes" />
            <asp:RequiredFieldValidator ID="emailValidator" runat="server" ControlToValidate="emailTextbox" CssClass="Errormessage" Display="Dynamic" ErrorMessage="Email is required." />
            <asp:CustomValidator ID="emailExistsValidator" runat="server" CssClass="Errormessage" Display="Dynamic" ErrorMessage="This email address is already in use" ControlToValidate="emailTextbox" onServerValidate="emailExistsValidator_ServerValidate" />
            <br /><br />

            <asp:Label ID="password1Label" AssociatedControlID="password1Textbox" runat="server" CssClass="Labels"></asp:Label>
            <asp:TextBox ID="password1Textbox" runat="server" TextMode="Password" CssClass="Textboxes" />
            <asp:RequiredFieldValidator ID="pw1Validator" runat="server" ControlToValidate="password1Textbox" CssClass="Errormessage" Display="Dynamic" ErrorMessage="Password is required" />
            <br />

            <asp:Label ID="password2Label" AssociatedControlID="password2Textbox" runat="server" CssClass="Labels"></asp:Label>
            <asp:TextBox ID="password2Textbox" runat="server" TextMode="Password" CssClass="Textboxes" />
            <asp:RequiredFieldValidator ID="pw2Valdator" runat="server" ControlToValidate="password2Textbox" CssClass="Errormessage" Display="Dynamic" ErrorMessage="Repeat your password" />
            <asp:CompareValidator ID="CompareValidator" runat="server" ControlToValidate="password2Textbox" ControlToCompare="password1Textbox" ValidateEmptyText="True" CssClass="Errormessage" Display="Dynamic" ErrorMessage="Passwords do not match." />
        </div>
        <br />
        <asp:Button ID="submitButton" runat="server" Text="Register" OnClick="submitButton_Click" />
    </div>
</asp:Content>
