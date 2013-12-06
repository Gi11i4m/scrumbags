using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Scrumbags
{
    public partial class Reservations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Server.Transfer("Login.aspx", true);
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DBQueries.DeleteReservation(int.Parse(Session["id"].ToString()), int.Parse(GridView1.SelectedRow.Cells[8].Text), 28);
            //GridView1.DataBind();
        }

        protected void HomePageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx", true);
        }
    }
}