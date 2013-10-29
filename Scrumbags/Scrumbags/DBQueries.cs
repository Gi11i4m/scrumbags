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
            DBConnection.executeQuery("INSERT INTO lecturers (id, name, email, password) VALUES (1, " + name + "," + email + "," + password + ");");
        }
    }
}