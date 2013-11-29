using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Scrumbags
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            firstNameLabel.Text = "First Name";
            lastNameLabel.Text = "Last Name";
            emailLabel.Text = "Email address";
            password1Label.Text = "Password";
            password2Label.Text = "Repeat password";
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            string name = lastNameTextbox.Text + " " + firstNameTextbox.Text;
            string email = emailTextbox.Text;

            if (Page.IsValid)
            {
                //Add user to DB
                DBQueries.Register(name, emailTextbox.Text, password1Textbox.Text); //email normaliseren

                //Send verification email
                String subject = "Scrumbags - Account creation";
                String body = "Dear " + name + ",\n\n" +
                "You recently created an accounton our site.\n" +
                "Please use the following link to verify your account: " +
                "http://scrumbags.somee.com/UserVerification?email=" + email + "&hash=" + Hashing.GetHash(email); //juiste adres invullen!!
                MailingRegistration mailsender = new MailingRegistration(email, subject, body);
                mailsender.Send();

                //Redirect to loginpage
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Your account has been created, an email has been sent to your email address to verify your account');</script>");
                Response.AppendHeader("REFRESH", "1;URL=Login.aspx");
            }
        }

        protected void emailExistsValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //Check if email already exists, invalidate page if it does
            args.IsValid = !DBQueries.userExists(emailTextbox.Text);
        }
    }
}