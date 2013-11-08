using System;
using System.Collections.Generic;
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
            
            emailLabel.Text = "Email adres";
            passwordLabel.Text = "Password";
            RegisterHyperlink.Text = "Register";
        }
        protected void submitButton_Click(object sender, EventArgs e)
        {
            if (DBQueries.login(emailInput.Text, Hashing.GetHash(passwordInput.Text)))
            {
                //navigatie naar volgende pagina
            }
            else
            {
                //error melding, ga ik nu nog niet doen er is geen test data
            }
        }
    }
}