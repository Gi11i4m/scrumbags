using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Scrumbags_Project
{
    public partial class REg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            firstNameLabel.Text = "First Name: ";
            lastNameLabel.Text = "Last Name: ";
            emailLabel.Text = "Email address: ";
            password1Label.Text = "Password: ";
            password2Label.Text = "Repeat password: ";
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {

        }
    }
}