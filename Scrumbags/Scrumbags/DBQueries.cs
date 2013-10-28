using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scrumbags
{
    public class DBQueries
    {
        public static void Registrate()
        {
            DBConnection.executeQuery("INSERT INTO lecturers");
        }
    }
}