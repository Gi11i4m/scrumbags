using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Scrumbags
{
    public partial class MasterPageClass : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Visible buttons en links in de banner code verplaatsen naar pagina's
            bool isLoginPage = MasterContentPlaceHolder.Page.Title.Equals("Login");
            logoutButton.Visible = !isLoginPage;
            ReservationsHyperLink.Visible = !isLoginPage;
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Abandon();
                Response.Redirect("Login.aspx", true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void ReservationsHyperLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reservations.aspx");
        }
    }
}