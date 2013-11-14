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
            if (Request["email"] != null && Request["hash"] != null)
            {

                if (Request["hash"].Equals("aaa")) // vergelijken met hashfunctie
                {
                    //Verify user in database
                    DBQueries.verifyUser(Request["email"]);
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