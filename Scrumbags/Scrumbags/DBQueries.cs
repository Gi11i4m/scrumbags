using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Scrumbags
{
    public class DBQueries
    {
        // Register user
        public static void Register(string name, string email, string password)
        {
            //password eerst nog hashen!!
            DBConnection.executeQuery("INSERT INTO lecturers (name, email, password) VALUES ('" + name + "','" + email + "','" + password + "')");
        }

        //Check capacity availability in slots // Just for extra checking!
        public static bool CheckCapacityInSlots(int slotID)
        {
            DataTable table;
            Object obj;
            int capacity;

            table = DBConnection.executeQuery("SELECT capacity FROM slots WHERE id = '" + slotID + "'");
            obj = table.Rows[0]["capacity"];
            capacity = int.Parse(obj.ToString());

            return capacity > 0;
        }

        // Reserve slot
        // Var capacity will be decremented by 1 when reservation is made
        public static void Reserve(int lecturerID, int slotID)
        {
            DBConnection.executeQuery("UPDATE slots SET capacity = capacity - 1 WHERE id = '" + slotID + "'");
            DBConnection.executeQuery("INSERT INTO reservations (slot_id, lecturer_id, created_at) VALUES ('" + slotID + "', '" + lecturerID + "', '" + TimeStamp.DateTimeToUnixTimestamp(DateTime.Now) + "')");
        }

        //Change user password
        public static void changePassword(string email, string password)
        {
            //password nog hashen
            DBConnection.executeQuery("UPDATE lecturers SET password='" + password +  "' WHERE email='" + email + "'");
        }

        //Set user to verified in DB
        public static void verifyUser(string email)
        {

        }
        public static Boolean login(string email, string hash)
        {
            //This Method returns true if the given hash equals the saved hash found in the database. Identified through the emailaddress
            DataTable t = DBConnection.executeQuery("SELECT password FROM lecturers WHERE email = '" + email + "'");
            Object o = t.Rows[0]["password"];
            return hash.Equals(o.ToString());

        }
    }
}
