using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Scrumbags
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Server.Transfer("Default.aspx", true);
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBQueries.Reserve(int.Parse(Session["id"].ToString()), int.Parse(GridView1.SelectedRow.Cells[8].Text));
            GridView1.DataBind();

        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Abandon();
                Response.Redirect("Default.aspx", true);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}