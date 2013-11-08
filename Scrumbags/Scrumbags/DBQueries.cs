using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Scrumbags
{
    public class DBQueries
    {
        public static void Register(string name, string email, string password)
        {
            DBConnection.executeQuery("INSERT INTO lecturers (name, email, password) VALUES ('" + name + "','" + email + "','" + password + "')");
        }
        public static Boolean login(string email, string password)
        {

            DataTable t = DBConnection.executeQuery("SELECT password FROM lecturers WHERE email = '" + email + "'");
            Object o = t.Rows[0]["password"];
            return password.Equals( o.ToString());
            
        }
    }
}