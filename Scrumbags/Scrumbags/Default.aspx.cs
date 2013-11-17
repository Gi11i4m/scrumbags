using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Scrumbags
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /**DIT ZIJN DE TE GEBRUIKEN COMMANDS OM TE MAILEN.
             * 
            MailingRegistration r = new MailingRegistration("yolan@coeman.net");
            r.Send();*/

            emailLabel.Text = "Email adres";
            passwordLabel.Text = "Password";
            RegisterHyperlink.Text = "Register";
        }
        protected void submitButton_Click(object sender, EventArgs e)
        {
            // Check if user and password match in database
            if (DBQueries.login(emailInput.Text, passwordInput.Text))
            {
                // Get id from database to put in Session Var
                DataTable table = DBConnection.executeQuery("SELECT id FROM lecturers WHERE email = '" + emailInput.Text + "'");
                Object obj = table.Rows[0]["id"];
                Session["id"] = obj.ToString();

                // Check if user is admin
                // If user is admin, Session Var "isAdmin" = true
                Session["isAdmin"] = DBQueries.CheckAdmin(obj.ToString());

                Response.Redirect("Home.aspx", true);
            }
            else
            {
                //error melding, ga ik nu nog niet doen er is geen test data
            }
        }
    }
}