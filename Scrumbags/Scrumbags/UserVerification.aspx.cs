using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Scrumbags
{
    public partial class UserVerification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Request["email"];
            string hash = Request["hash"];

            try
            {
                //Check if parameters are present, user is already verified, user exists and hash is valid
                if (email == null || hash == null)
                {
                    Label errorMessageLabel = (Label)Page.Master.FindControl("errorMessageLabel");
                    errorMessageLabel.Text = "There was a problem processing your request - The supplied link is not correct.";
                }
                else if (DBQueries.userIsVefied(email))
                {
                    Label errorMessageLabel = (Label)Page.Master.FindControl("errorMessageLabel");
                    errorMessageLabel.Text = "Your account has already been verified.";
                }
                else if (DBQueries.UserExists(email) && hash.Equals(Hashing.GetHash(email)))
                {
                    //Verify user in DB
                    DBQueries.verifyUser(email);

                    Label errorMessageLabel = (Label)Page.Master.FindControl("errorMessageLabel");
                    errorMessageLabel.Text = "Your account has been verified. \n You will be redirected automatically ";

                    Response.AppendHeader("REFRESH", "5;URL=Login.aspx");
                }
                else
                {
                    Label errorMessageLabel = (Label)Page.Master.FindControl("errorMessageLabel");
                    errorMessageLabel.Text = "There was a problem processing your request - Your email address does not exist.";
                }
            }
            catch (Exception ex)
            {
                Label errorMessageLabel = (Label)Page.Master.FindControl("errorMessageLabel");

                errorMessageLabel.Text = "An error occured while verifying your account:";
                errorMessageLabel.Text += "\n\n";
                errorMessageLabel.Text = ex.Message;
            }
        }
    }
}
