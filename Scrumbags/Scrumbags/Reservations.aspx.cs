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
            try
            {
                if (Session["id"] == null)
                {
                    Server.Transfer("Login.aspx", true);
                }
                if (!Page.IsPostBack)
                {
                    ReservedSlotsDataGrid.DataSource = DBQueries.getReservedSlots(Session["id"].ToString());
                    ReservedSlotsDataGrid.DataBind();
                }
            }
            catch (Exception error)
            {
                string err = "Shit broke ~Girmi";
                err += "\n\n";
                err += error.Message;

                //NOG TOE TE VOEGEN AAN LABEL
                ((Label)Page.Master.FindControl("errorMessageLabel")).Text = err;
            }
        }
        protected void ReservedSlotsDataGrid_OnItemCommand(object sender, DataGridCommandEventArgs e)
        {
            try
            {
                DBQueries.UnReserve(int.Parse(Session["id"].ToString()), int.Parse(e.Item.Cells[6].Text));
                ReservedSlotsDataGrid.DataSource = DBQueries.getReservedSlots(Session["id"].ToString());
                ReservedSlotsDataGrid.DataBind();
            }
            catch (Exception error)
            {
                string err = "Shit broke ~Girmi";
                err += "\n\n";
                err += error.Message;

                //NOG TOE TE VOEGEN AAN LABEL
                ((Label)Page.Master.FindControl("errorMessageLabel")).Text = err;
            }
        }

        private string returnMonth(int i)
        {
            switch (i)
            {
                case 1:
                    return "March";
                case 2:
                    return "February";
                case 3:
                    return "March";
                case 4:
                    return "April";
                case 5:
                    return "July";
                case 6:
                    return "June";
                case 7:
                    return "August";
                case 8:
                    return "September";
                case 9:
                    return "September";
                case 10:
                    return "October";
                case 11:
                    return "November";
                case 12:
                    return "December";
                default:
                    return "null";
            }
        }
        /*protected void ReservedSlotsDataGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ReservedSlotsDataGrid.DataSource = DBQueries.getSlots(Session["id"].ToString());
                ReservedSlotsDataGrid.DataBind();
            }
            catch (Exception error)
            {
                string err = "Shit broke ~Girmi";
                err += "\n\n";
                err += error.Message;

                //NOG TOE TE VOEGEN AAN LABEL
                ((Label)Page.Master.FindControl("errorMessageLabel")).Text = err;
            }
        }*/
        protected void ReservedSlotsDataGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            try
            {
                switch (e.Item.ItemType)
                {
                    case ListItemType.AlternatingItem:

                    case ListItemType.Item:
                        if (e.Item.Cells[5].Text.Equals("SubHeading"))
                        {
                            DateTime myDate = DateTime.Parse(e.Item.Cells[0].Text.ToString());
                            e.Item.Cells[1].Text = myDate.DayOfWeek.ToString() + " " + myDate.Day + " " + returnMonth(myDate.Month);

                            //De breedte van de toegevoegde subheader
                            e.Item.Cells[1].ColumnSpan = e.Item.Cells.Count;

                            //De overigge cellen verwijderen
                            for (int i = e.Item.Cells.Count - 1; i > 1; i--)
                                e.Item.Cells.RemoveAt(i);
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception error)
            {
                string err = "Shit broke ~Girmi";
                err += "\n\n";
                err += error.Message;

                //NOG TOE TE VOEGEN AAN LABEL
                ((Label)Page.Master.FindControl("errorMessageLabel")).Text = err;
            }
        }

        protected void HomePageButton_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Home.aspx", true);
            }
            catch (Exception error)
            {
                string err = "Shit broke ~Girmi";
                err += "\n\n";
                err += error.Message;

                //NOG TOE TE VOEGEN AAN LABEL
                ((Label)Page.Master.FindControl("errorMessageLabel")).Text = err;
            }

        }
    }
}
