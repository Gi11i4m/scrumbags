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
            string email = Request["email"];
            string hash = Request["hash"];

            //Beveiligen!!
            if (email != null && hash != null)
            {
                string emailhash = Hashing.GetHash(email);

                //Verify if the suupplied hash is valid
                if (hash.Equals("aaa")) 
                {
                    //Check of user bestaat en nog niet verified is
                    //Verify user in database
                    DBQueries.verifyUser(email);
                    messageLabel.Text = "Your account has been verified. \n You will be redirected automatically";
                    Response.AppendHeader("REFRESH", "5;URL=login.aspx"); 
                }
                else
                {
                    messageLabel.Text = "Something went wrong while processing your request."; //Redirect?
                }
            }
            else
            {
                messageLabel.Text = "Something went wrong while processing your request."; //Redirect?
            }
        }
    }
}