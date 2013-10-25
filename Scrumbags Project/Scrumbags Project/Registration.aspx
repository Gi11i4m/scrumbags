<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Scrumbags_Project.REg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Page</title>
</head>
<body>
    <h1>Registration page</h1>

    <form id="form1" runat="server">
        <div>
            <asp:Label ID="errorMessage" runat="server"></asp:Label>
            <div>
                <asp:ValidationSummary ID="validationSummary" runat="server" HeaderText="There were errors on the page:" />
            </div>
            <table>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="firstNameValidator" runat="server" ControlToValidate="firstNameInput" ErrorMessage="First name is required.">
                        * </asp:RequiredFieldValidator></td>
                    <td>
                        <asp:Label ID="firstNameLabel" AssociatedControlID="firstNameInput" runat="server"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="firstNameInput" runat="server" /></td>
                    <td>
                         <asp:RegularExpressionValidator ID="firstNameRegexValidator" runat="server" ControlToValidate="firstNameInput" ErrorMessage="ID must be 6-10 letters." ValidationExpression="[a-zA-Z]{6,10}" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="lastNameValidator" runat="server" ControlToValidate="lastNameInput" ErrorMessage="Last name is required.">
                        * </asp:RequiredFieldValidator></td>
                    <td>
                        <asp:Label ID="lastNameLabel" AssociatedControlID="lastNameInput" runat="server"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="lastNameInput" runat="server" /></td>
                </tr>

                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="emailValidator" runat="server" ControlToValidate="emailInput" ErrorMessage="Email is required.">
                        * </asp:RequiredFieldValidator></td>
                    <td>
                        <asp:Label ID="emailLabel" AssociatedControlID="emailInput" runat="server"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="emailInput" runat="server" TextMode="Email" /></td>
                </tr>

                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="pw1Validator" runat="server" ControlToValidate="password1Input" ErrorMessage="Password is required">
                        * </asp:RequiredFieldValidator></td>
                    <td>
                        <asp:Label ID="password1Label" AssociatedControlID="password1Input" runat="server"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="password1Input" runat="server" TextMode="Password" /></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="password2Label" AssociatedControlID="password2Input" runat="server"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="password2Input" runat="server" TextMode="Password" /></td>
                    <td>
                        <asp:CompareValidator ID="CompareValidator" runat="server" ControlToValidate="password1Input" ControlToCompare="password2Input" ErrorMessage="Passwords do not match." />
                    </td>

                </tr>
            </table>
        </div>
        <br />
        <asp:Button ID="submitButton" runat="server" Text="Register" />
    </form>
</body>
</html>
