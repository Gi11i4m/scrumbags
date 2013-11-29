using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Scrumbags
{
    public partial class UserSettings : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //Check if there is a session, else transfer them to the default page
            if (Session["id"] == null)
            {
                Server.Transfer("Default.aspx", true);
            }

            newPassword1Label.Text = "New password";
            newPassword2Label.Text = "Repeat new password";
            oldPasswordLabel.Text = "Enter your old password";

            if (DBQueries.CheckAdmin(Session["id"].ToString()))
            {
                //jwz
            }
        }

        //Check if a new password is being set
        //Then check if the supplied password is correct, if not invalidates the page
        protected void passwordValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = DBQueries.login(ViewState["email"].ToString(), oldPasswordTextbox.Text);
            
        }

        //Changes the userpassword in DB
        protected void changePasswordButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                DBQueries.changePassword(ViewState["email"].ToString(), newPassword1Textbox.Text);

                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Your new password has been set.');</script>");
            }
        }
    }
}