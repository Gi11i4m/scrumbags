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
            passwordResetLinkButton.Text = "Reset je wachtwoord";
            newUserLinkButton.Text = "Nieuwe gebruiker";
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
                            DataTable t = DBConnection.executeQuery("SELECT id FROM lecturers WHERE email = '" + emailInput + "'");
                            Object o = t.Rows[0]["id"];
                            Session["id"] = o.ToString();
                            Response.Redirect("Home.aspx", true);
                        }
                        else
                        {
                            // TO DO: Label Error een message geven om account nog te verifi�ren
                        }
                    }
                    else
                    {
                        // TO DO: Label Error een message geven met foute login gegevens ofzo
                    }
                }
            }
            catch (Exception error)
            {
                string err = "Shit broke ~Girmi";
                err += "\n\n";
                err += error.Message;

                //NOG TOE TE VOEGEN AAN LABEL
                ((Label)Page.Master.FindControl("errorMessageLabel")).Text = err;
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
                ((Label)Page.Master.FindControl("errorMessageLabel")).Text = err;
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
                ((Label)Page.Master.FindControl("errorMessageLabel")).Text = err;
            }
        }
    }
}
