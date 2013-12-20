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
        //Set the label text at pageload
        protected void Page_Load(object sender, EventArgs e)
        {
            firstNameLabel.Text = "First Name";
            lastNameLabel.Text = "Last Name";
            emailLabel.Text = "Email address";
            password1Label.Text = "Password";
            password2Label.Text = "Repeat password";
        }

        //Submit the registration form
        protected void submitButton_Click(object sender, EventArgs e)
        {
            string name = lastNameTextbox.Text + " " + firstNameTextbox.Text;
            string email = emailTextbox.Text.ToLower(); //normalize email

            if (Page.IsValid)
            {
                //Add user to DB
                try
                {
                    DBQueries.Register(name, emailTextbox.Text, password1Textbox.Text);
                }
                catch (Exception ex)
                {
                    Label errorMessageLabel = (Label)Page.Master.FindControl("errorMessageLabel");

                    errorMessageLabel.Text = "An error occured registering your account:";
                    errorMessageLabel.Text += "\n\n";
                    errorMessageLabel.Text = ex.Message;
                }

                //Send verification email
                String subject = "Scrumbags - Account creation";
                String body = "Dear " + name + ",\n\n" +
                "You recently created an accounton our site.\n" +
                "Please use the following link to verify your account: " +
                "http://localhost:4333/UserVerification.aspx?email=" + email + "&hash=" + Hashing.GetHash(email); //juiste adres invullen!!
                try
                {
                    MailSender mailsender = new MailSender(email, subject, body);
                    mailsender.Send();

                    //Redirect to loginpage
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Your account has been created, an email has been sent to your email address to verify your account');</script>");
                    Response.AppendHeader("REFRESH", "1;URL=Login.aspx");
                }
                catch (Exception ex)
                {
                    Label errorMessageLabel = (Label)Page.Master.FindControl("errorMessageLabel");

                    errorMessageLabel.Text = "An error occured while seding your verification email";
                    errorMessageLabel.Text += "\n\n";
                    errorMessageLabel.Text = ex.Message;
                }
            }
        }

        //Check if email already exists, invalidate page if it does
        protected void emailExistsValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                args.IsValid = !DBQueries.UserExists(emailTextbox.Text);
            }
            catch (Exception ex)
            {
                Label errorMessageLabel = (Label)Page.Master.FindControl("errorMessageLabel");

                errorMessageLabel.Text = "An error occured while registering your account:";
                errorMessageLabel.Text += "\n\n";
                errorMessageLabel.Text = ex.Message;
            }
        }
    }
}