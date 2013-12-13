using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Scrumbags
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private static Random generator = new Random(Convert.ToInt32(TimeStamp.DateTimeToUnixTimestamp(DateTime.Now)));

        protected void Page_Load(object sender, EventArgs e)
        {
            emailLabel.Text = "Email address";
        }

        protected void resetButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    String email = emailTextbox.Text;

                    //Generate new password
                    String range = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!&$#*@_-";
                    char[] charray = new char[8];

                    for (int i = 0; i < 8; i++)
                    {
                        charray[i] = range[generator.Next(range.Length)];
                    }

                    String password = new string(charray);

                    //Send new password to email address 
                    String subject = "Scrumbags - Password reset";
                    String body = "Dear,\n " +
                    "You recently requested a password reset on our site.\n" +
                    "This is your new password: " + password;
                    MailSender mailsender = new MailSender(email, subject, body);
                    mailsender.Send();
                    emailLabel.Text = password;

                    //Save new password in DB
                    DBQueries.changePassword(email, password);

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Your new password has been sent to your email address');</script>");
                    Response.AppendHeader("REFRESH", "1;URL=Login.aspx");
                }
            }
            catch (HttpException ex)
            {
                ((Label)Page.Master.FindControl("errorMessageLabel")).Text = ex.Message;
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                ((Label)Page.Master.FindControl("errorMessageLabel")).Text = ex.Message;
            }
            catch (IndexOutOfRangeException ex)
            {
                ((Label)Page.Master.FindControl("errorMessageLabel")).Text = ex.Message;
            }
            catch (Exception ex)
            {
                ((Label)Page.Master.FindControl("errorMessageLabel")).Text = ex.Message;
            }
        }

        protected void emailExistsValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //Check if email exists, invalidate page if not
            args.IsValid = DBQueries.UserExists(emailTextbox.Text);
        }
    }
}