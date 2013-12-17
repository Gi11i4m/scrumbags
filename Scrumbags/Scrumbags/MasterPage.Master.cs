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
            bool isOutsideSessionPage = MasterContentPlaceHolder.Page.Title.Equals("Login") ||
                                MasterContentPlaceHolder.Page.Title.Equals("Registration") ||
                                MasterContentPlaceHolder.Page.Title.Equals("Password Reset");
            logoutButton.Visible = !isOutsideSessionPage;
            HomeHyperLink.Visible = !isOutsideSessionPage;
            ReservationsHyperLink.Visible = !isOutsideSessionPage;
            UserSettingsHyperLink.Visible = !isOutsideSessionPage;
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
    }
}