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
         public static string connectionString = "LocalConnection";
         //public static string connectionString = "CloudConnection";

        public static DataTable executeQuery(string query)
        {
            try
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
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static DataTable executeQuery(SqlCommand cmd)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionString].ConnectionString);
            
            cmd.Connection = conn;

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
            try
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
            catch (Exception ex)
            {
                return null; // TODO whut?
                // Moet dit nie verder doorgethrowed worden naar de front-end?
            }
        }

        public static DataSet executeQueryDataSet(SqlCommand cmd)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalConnection"].ConnectionString);

            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            return ds;
        }
    }
}
