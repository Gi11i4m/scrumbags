using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Scrumbags_Project
{
    public class DBConnection
    {
        public static DataTable executeGetQuery(string query)
        {
            ListBox resultListBox = new ListBox();

            object[] response = new object[10];
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalConnection"].ConnectionString);
            //con.Open();
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = query;
            //cmd.Connection = con;
            //SqlDataReader dataReader = cmd.ExecuteReader();

            //while (dataReader.Read())
            //{
            //    resultListBox.Items.Add(dataReader[0] + " | " + dataReader[1]);
            //}

            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable dt = new DataTable();
            dt.Load(dr);
            //GridView1.DataSource = dt;
            //GridView1.DataBind();

            conn.Close();

            return dt;
        }

        public static void executeQuery(string query)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalConnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = con;
            con.Close();
        }
    }
}