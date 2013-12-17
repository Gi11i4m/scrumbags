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
            LogoutHyperLink.Visible = !isOutsideSessionPage;
            HomeHyperLink.Visible = !isOutsideSessionPage;
            ReservationsHyperLink.Visible = !isOutsideSessionPage;
            UserSettingsHyperLink.Visible = !isOutsideSessionPage;
        }
    }
}