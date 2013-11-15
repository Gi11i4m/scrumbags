using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Scrumbags
{
    public class DBQueries
    {
        //Checks if user exists
        public static bool userExists(string email)
        {
            DataTable dt = DBConnection.executeQuery("SELECT * FROM lecturers WHERE email = '" + email + "'");

            return dt.Rows.Count == 1;
        }

        // Register user
        public static void Register(string name, string email, string password)
        {
            string pwhash = Hashing.GetHash(password);
            DBConnection.executeQuery("INSERT INTO lecturers (name, email, password) VALUES ('" + name + "','" + email + "','" + pwhash + "')");
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
            //DBConnection.executeQuery("INSERT INTO reservations (slot_id, lecturer_id, created_at) VALUES ('" + slotID + "', '" + lecturerID + "', '" + TimeStamp.DateTimeToUnixTimestamp(DateTime.Now) + "')");
            DBConnection.executeQuery("INSERT INTO reservations (slot_id, lecturer_id) VALUES ('" + slotID + "', '" + lecturerID + "')");
        
        }

        //Change user password
        public static void changePassword(string email, string password)
        {
            string pwhash = Hashing.GetHash(password);
            DBConnection.executeQuery("UPDATE lecturers SET password='" + pwhash +  "' WHERE email='" + email + "'");
        }

        //Set user to verified in DB
        public static void verifyUser(string email)
        {
            DBConnection.executeQuery("UPDATE lecturers SET verified='1' WHERE email='" + email + "'");
        }
        public static Boolean login(string email, string password)
        {
            string hash = Hashing.GetHash(password);
            //This Method returns true if the given hash equals the saved hash found in the database. Identified through the emailaddress
            DataTable t = DBConnection.executeQuery("SELECT password FROM lecturers WHERE email = '" + email + "'");
            Object o = t.Rows[0]["password"];
            return hash.Equals(o.ToString());

        }
    }
}
