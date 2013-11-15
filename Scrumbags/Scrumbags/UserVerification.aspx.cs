using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Scrumbags
{
    public partial class UserVerification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Beveiligen!!
            string email = Request["email"];
            string hash = Request["hash"];

            //Check if parameters are present, user exists and hash is valid
            if (email != null && hash != null && DBQueries.userExists(email) && hash.Equals(Hashing.GetHash(email)))
            {
                //Verify user in DB
                DBQueries.verifyUser(email);

                messageLabel.Text = "Your account has been verified. \n You will be redirected automatically ";
                Response.AppendHeader("REFRESH", "5;URL=Login.aspx");

            }
            else
            {
                messageLabel.Text = "There was a problem processing your request. (Invalid parameters)"; //Redirect?
            }
        }
    }
}