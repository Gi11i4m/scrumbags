using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Scrumbags
{
    public class DBConnection
    {
        public static DataTable executeGetQuery(string query)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable dt = new DataTable();
            dt.Load(dr);
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