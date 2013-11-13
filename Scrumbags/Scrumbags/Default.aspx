<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Scrumbags.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Login Page</title>
    <link href="StyleSheet.css" rel="stylesheet" />    
</head>
<body>
    <form id="form1" runat="server">
        <h1>Login page</h1>
        <asp:Label ID="errorMessage" runat="server"></asp:Label>
            <div>
                <asp:ValidationSummary ID="validationSummary" runat="server" HeaderText="There were errors on the page:" CssClass="Errors"/>
            </div>
        <div>          
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="emailInput" ErrorMessage="Email is required">
                                * </asp:RequiredFieldValidator>
                                <asp:Label ID="emailLabel" AssociatedControlID="emailInput" runat="server" CssClass="Labels"></asp:Label>
                                <asp:TextBox ID="emailInput" runat="server" CssClass="Textboxs" />
        
                <br />

                <asp:RequiredFieldValidator ID="pwField" runat="server" ControlToValidate="passwordInput" ErrorMessage="Password is required">
                                * </asp:RequiredFieldValidator>
                                <asp:Label ID="passwordLabel" AssociatedControlID="passwordInput" runat="server" CssClass="Labels"></asp:Label>
                                <asp:TextBox ID="passwordInput" runat="server" TextMode="Password" CssClass="Textboxs" />

                <br /><br />
                 <asp:Button ID="submitButton" runat="server" Text="Register" OnClick="submitButton_Click" />                 
                <br />
                <asp:HyperLink ID="RegisterHyperlink" runat="server" CssClass="Hyperlink" NavigateUrl ="~/Registration.aspx"></asp:HyperLink>
            </div>
        </div>
    </form>
</body>
</html>
