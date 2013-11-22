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
            logoutButton.Visible = !MasterContentPlaceHolder.Page.Title.Equals("Login");
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