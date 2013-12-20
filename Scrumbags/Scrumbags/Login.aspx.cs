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
            passwordResetLinkButton.Text = "Reset password";
            newUserLinkButton.Text = "New user";
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    String emailInput = emailTextBox.Text.ToLower();
                    String passwordInput = passwordTextBox.Text;

                    if (DBQueries.login(emailInput, passwordInput))
                    {
                        if (DBQueries.userIsVefied(emailInput))
                        {
                            Session["id"] = DBQueries.getLoggedInUserID(emailInput);
                            Response.Redirect("Home.aspx", true);
                        }
                        else
                        {
                            loginErrorMessageLabel.Text = "Your account hasn't been verified yet, please check your email.";
                        }
                    }
                    else
                    {
                        loginErrorMessageLabel.Text = "Wrong username or password.";
                    }
                }
            }
	    catch (Exception error)
            {
                string err = "Shit broke ~Girmi";
                err += "\n\n";
                err += error.Message;

                //NOG TOE TE VOEGEN AAN LABEL
                loginErrorMessageLabel.Text = err;
            }
        }

        protected void passwordResetLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("PasswordReset.aspx");
            }
            catch (Exception error)
            {
                string err = "Shit broke ~Girmi";
                err += "\n\n";
                err += error.Message;

                //NOG TOE TE VOEGEN AAN LABEL
                loginErrorMessageLabel.Text = err;
            }
        }

        protected void newUserLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Registration.aspx");
            }
            catch (Exception error)
            {
                string err = "Shit broke ~Girmi";
                err += "\n\n";
                err += error.Message;

                //NOG TOE TE VOEGEN AAN LABEL
                loginErrorMessageLabel.Text = err;
            }
        }
    }
}