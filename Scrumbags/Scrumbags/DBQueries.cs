using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scrumbags
{
    public class DBQueries
    {
        public static void Register(string name, string email, string password)
        {
            //password eerst nog hashen!!
            DBConnection.executeQuery("INSERT INTO lecturers (name, email, password) VALUES ('" + name + "','" + email + "','" + password + "')");
        }

        public static void changePassword(string email, string password)
        {
            //password nog hashen
            DBConnection.executeQuery("UPDATE lecturers SET password='" + password +  "' WHERE email='" + email + "'");
        }
    }
}