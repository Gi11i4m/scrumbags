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
            try
            {
                //Beveiligen!!
                string email = Request["email"];
                string hash = Request["hash"];

                //Check if parameters are present, user is already verified, user exists and hash is valid
                if (email == null || hash == null)
                {
                    messageLabel.Text = "There was a problem processing your request - The supplied link is not correct.";
                }
                else if (DBQueries.userIsVefied(email))
                {
                    messageLabel.Text = "Your account has already been verified.";
                }
                else if (DBQueries.UserExists(email) && hash.Equals(Hashing.GetHash(email)))
                {
                    //Verify user in DB
                    DBQueries.verifyUser(email);

                    messageLabel.Text = "Your account has been verified. \n You will be redirected automatically ";
                    Response.AppendHeader("REFRESH", "5;URL=Login.aspx");
                }
                else
                {
                    messageLabel.Text = "There was a problem processing your request - Your email address does not exist."; //Redirect?
                }
            }
            catch (System.Reflection.TargetInvocationException ex)
            {
                ((Label)Page.Master.FindControl("errorMessageLabel")).Text = ex.Message;
            }
            catch (ArgumentNullException ex)
            {
                ((Label)Page.Master.FindControl("errorMessageLabel")).Text = ex.Message;
            }
            catch (EncoderFallbackException ex)
            {
                ((Label)Page.Master.FindControl("errorMessageLabel")).Text = ex.Message;
            }
            catch (Exception ex)
            {
                ((Label)Page.Master.FindControl("errorMessageLabel")).Text = ex.Message;
            }
        }
    }
}
