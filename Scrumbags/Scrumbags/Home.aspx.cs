﻿using System;
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
            //Check if their is a Session atm. Else a big no no
            if (Session["id"] == null)
            {
                Server.Transfer("Default.aspx", true);
            }

            if (!Page.IsPostBack)
            {
                SlotsDataGrid.DataSource = DBQueries.getSlots();
                SlotsDataGrid.DataBind();
            }
           
            
            
            
            
            // Use this statement to check if the user is an Admin
            //if ((bool)Session["isAdmin"])
            //{}
        }

        protected void SlotsDataGrid_OnItemCommand(object sender, DataGridCommandEventArgs e)
        {
            DBQueries.Reserve(int.Parse(Session["id"].ToString()), int.Parse(e.Item.Cells[7].Text));
            SlotsDataGrid.DataSource = DBQueries.getSlots();
            SlotsDataGrid.DataBind();
            
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
                        e.Item.Cells[1].Text = myDate.DayOfWeek.ToString() + " " + myDate.Day + " " + myDate.Month;
                        
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


        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Abandon();
                Response.Redirect("Login.aspx", true);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        protected void gvEmp_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SelectSlots")
            { }
        }

        protected void SlotsDataGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            SlotsDataGrid.DataSource = DBQueries.getSlots();
            SlotsDataGrid.DataBind();
            Label1.Text = "blap";
        }

       
    }
}