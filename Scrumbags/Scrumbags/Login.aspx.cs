using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Scrumbags
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loginButton.Text = "Log in";
            passwordResetLinkButton.Text = "Reset your password";
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                String emailInput = emailTextBox.Text;
                String passwordInput = passwordTextBox.Text;

                if (DBQueries.login(emailInput, passwordInput))
                {
                    DataTable t = DBConnection.executeQuery("SELECT id FROM lecturers WHERE email = '" + emailInput + "'");
                    Object o = t.Rows[0]["id"];
                    Session["id"] = o.ToString();
                    Response.Redirect("Home.aspx", true);
                }
                else
                {
                    // ERROR
                }
            }
        }

        protected void passwordResetLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("PasswordReset.aspx");
        }

        protected void newUserLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }
    }
}