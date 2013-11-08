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
            DBConnection.executeQuery("INSERT INTO lecturers (name, email, password) VALUES ('" + name + "','" + email + "','" + password + "')");
        }

        public static void verifyUser(string email)
        {
            DBConnection.executeQuery("UPDATE lecturers SET verified=true WHERE email=" + email + ";");
        }
    }
}