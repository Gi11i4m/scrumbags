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
        //public static string connectionString = "LocalConnection";
        public static string connectionString = "CloudConnection";

        public static DataTable executeQuery(string query)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionString].ConnectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable dt = new DataTable();
            dt.Load(dr);
            conn.Close();

            return dt;
        }
    }
}