using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Scrumbags
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //Check if there is a session, else transfer them to the default page
            //if (Session["id"] == null)
            //{
            //    Server.Transfer("Default.aspx", true);
            //}

            Session["id"] = 1157;

            firstNameLabel.Text = "First Name";
            lastNameLabel.Text = "Last Name";
            emailLabel.Text = "Email address";
            newPassword1Label.Text = "New password";
            newPassword2Label.Text = "Repeat new password";
            oldPasswordLabel.Text = "Enter your old password";

            if (!IsPostBack)
            {
                fillUserFields();
            }

            if (DBQueries.CheckAdmin(Session["id"].ToString()))
            {
                //jwz
            }
        }

        //Fill the fields with the info of the current user
        private void fillUserFields()
        {
            DataTable table = DBQueries.getUserTable(Session["id"].ToString());

            String[] name = table.Rows[0]["name"].ToString().Split(' ');
            String firstname = name[1];
            String lastName = name[0];
            ViewState["email"] = table.Rows[0]["email"].ToString();

            firstNameTextbox.Text = firstname;
            lastNameTextbox.Text = lastName;
            emailTextbox.Text = ViewState["email"].ToString();
        }

        //Check if email already exists, invalidate page if it does, except if it's the users own email address
        protected void emailInUseValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (emailTextbox.Text.Equals(ViewState["email"].ToString()))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = !DBQueries.userExists(emailTextbox.Text);
            }

        }

        //Check if a new password is being set
        //Then check if the supplied password is correct, if not invalidates the page
        protected void passwordValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (newPassword1Textbox.Text.Equals(String.Empty))
            {
                args.IsValid = true;
            }
            else if (DBQueries.login(ViewState["email"].ToString(), oldPasswordTextbox.Text))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void changePasswordButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                DBQueries.changePassword(ViewState["email"].ToString(), newPassword1Textbox.Text);

                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Your new password has been set.');</script>");
            }


        }

        protected void saveSettingsButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                String name = lastNameTextbox.Text + firstNameTextbox.Text;
                DBQueries.changeUserSettings(Session["id"].ToString(), name, emailTextbox.Text);

                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Your settings have been changed.');</script>");
            }


        }
    }
}