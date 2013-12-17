using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Scrumbags
{
    public partial class Home : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //Check if their is a Session atm. Else a big no no
            if (Session["id"] == null)
            {
                Server.Transfer("Login.aspx", true);
            } 
            
            try
            {
                if (!Page.IsPostBack)
                {
                    SlotsDataGrid.DataSource = DBQueries.getSlots(Session["id"].ToString());
                    SlotsDataGrid.DataBind();
                }
            }
            catch (Exception ex)
            {
                Label errorMessageLabel = (Label)Page.Master.FindControl("errorMessageLabel");

                errorMessageLabel.Text = "An error occured while retrieving your slots:";
                errorMessageLabel.Text += "\n\n";
                errorMessageLabel.Text = ex.Message;
            }
            // Use this statement to check if the user is an Admin
            //if ((bool)Session["isAdmin"])
            //{}
        }

        protected void SlotsDataGrid_OnItemCommand(object sender, DataGridCommandEventArgs e)
        {
            try
            {
                DBQueries.Reserve(int.Parse(Session["id"].ToString()), int.Parse(e.Item.Cells[7].Text));
                SlotsDataGrid.DataSource = DBQueries.getSlots(Session["id"].ToString());
                SlotsDataGrid.DataBind();
            }
            catch (Exception ex)
            {
                Label errorMessageLabel = (Label)Page.Master.FindControl("errorMessageLabel");

                errorMessageLabel.Text = "An error occured while reserving your slots:";
                errorMessageLabel.Text += "\n\n";
                errorMessageLabel.Text = ex.Message;
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

        protected void SlotsDataGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.AlternatingItem:

                case ListItemType.Item:
                    if (e.Item.Cells[6].Text.Equals("SubHeading"))
                    {
                        DateTime myDate = DateTime.Parse(e.Item.Cells[0].Text.ToString());
                        e.Item.Cells[1].Text = myDate.DayOfWeek.ToString() + " " + myDate.Day + " " + returnMonth(myDate.Month).ToString().ToLower();

                        //De breedte van de toegevoegde subheader
                        e.Item.Cells[1].ColumnSpan = e.Item.Cells.Count;
                        e.Item.Cells[1].CssClass = "DayRow";

                        //De overigge cellen verwijderen
                        for (int i = e.Item.Cells.Count - 1; i > 1; i--)
                            e.Item.Cells.RemoveAt(i);
                    }
                    break;
                default:
                    break;
            }
        }

        protected void SlotsDataGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SlotsDataGrid.DataSource = DBQueries.getSlots(Session["id"].ToString());
            }
            catch (Exception ex)
            {
                Label errorMessageLabel = (Label)Page.Master.FindControl("errorMessageLabel");

                errorMessageLabel.Text = "An error occured while retrieving your slots:";
                errorMessageLabel.Text += "\n\n";
                errorMessageLabel.Text = ex.Message;
            }
            SlotsDataGrid.DataBind();
        }
    }
}