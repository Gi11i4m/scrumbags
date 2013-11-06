<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Scrumbags.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Registration Page</title>
    <link href="StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <%-- <asp:Content ID="Content1" ContentPlaceHolderId="C1" runat="server"> --%>
    <h1>Registration page</h1>

    <form id="form1" runat="server">
        <div>
            <asp:Label ID="errorMessage" runat="server"></asp:Label>
            <div>
                <asp:ValidationSummary ID="validationSummary" runat="server" HeaderText="There were errors on the page:" CssClass="Errors"/>
            </div>
            <div id="registrationDiv">
                        <asp:RequiredFieldValidator ID="firstNameValidator" runat="server" ControlToValidate="firstNameInput" ErrorMessage="First name is required.">
                        * </asp:RequiredFieldValidator>
                        <asp:Label ID="firstNameLabel" AssociatedControlID="firstNameInput" runat="server" CssClass="Labels"></asp:Label>
                        <asp:TextBox ID="firstNameInput" runat="server" CssClass="Textboxs" />
                         <asp:RegularExpressionValidator ID="firstNameRegexValidator" runat="server" ControlToValidate="firstNameInput" ErrorMessage="First name can only contain letters" ValidationExpression="^[A-z][-A-z]+$" />
                    
                        <br />
               
                        <asp:RequiredFieldValidator ID="lastNameValidator" runat="server" ControlToValidate="lastNameInput" ErrorMessage="Last name is required.">
                        * </asp:RequiredFieldValidator>
                        <asp:Label ID="lastNameLabel" AssociatedControlID="lastNameInput" runat="server" CssClass="Labels"></asp:Label>
                        <asp:TextBox ID="lastNameInput" runat="server" CssClass="Textboxs" />
                         <asp:RegularExpressionValidator ID="lastNameRegexValidator" runat="server" ControlToValidate="lastNameInput" ErrorMessage="Last name can only contain letters" ValidationExpression="^[A-Z][- A-z]+$" />

                        <br />

                        <asp:RequiredFieldValidator ID="emailValidator" runat="server" ControlToValidate="emailInput" ErrorMessage="Email is required.">
                        * </asp:RequiredFieldValidator>
                        <asp:Label ID="emailLabel" AssociatedControlID="emailInput" runat="server" CssClass="Labels"></asp:Label>
                        <asp:TextBox ID="emailInput" runat="server" TextMode="Email" CssClass="Textboxs" />

                        <br />

                        <asp:RequiredFieldValidator ID="pw1Validator" runat="server" ControlToValidate="password1Input" ErrorMessage="Password is required">
                        * </asp:RequiredFieldValidator>
                        <asp:Label ID="password1Label" AssociatedControlID="password1Input" runat="server" CssClass="Labels"></asp:Label>
                        <asp:TextBox ID="password1Input" runat="server" TextMode="Password" CssClass="Textboxs" />

                        <br />
                        &nbsp;&nbsp;
                        <asp:Label ID="password2Label" AssociatedControlID="password2Input" runat="server" CssClass="Labels"></asp:Label>
                        <asp:TextBox ID="password2Input" runat="server" TextMode="Password" CssClass="Textboxs" />
                        <asp:CompareValidator ID="CompareValidator" runat="server" ControlToValidate="password1Input" ControlToCompare="password2Input" ErrorMessage="Passwords do not match." />
            </div>
        <br /><br />
        <asp:Button ID="submitButton" runat="server" Text="Register" OnClick="submitButton_Click" />
        </div>
    </form>
    <%-- </asp:Content> --%>
</body>
</html>
