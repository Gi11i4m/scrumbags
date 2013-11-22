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
        public static DataTable executeQuery(string query)
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

        //Code pauwel voor een dataset terug te krijgen voor in de datagrid te steken
        public static DataSet executeQueryDataSet(string query)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            return ds;
        }
    }
}