using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Scrumbags
{
    public class DBQueries
    {

        //Checks if user exists
        public static bool UserExists(string email)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM lecturers WHERE email = @email;");
            cmd.Parameters.AddWithValue("@email", email);

            DataTable dt = DBConnection.executeQuery(cmd);

            return dt.Rows.Count == 1;
        }

        //Check if user is already verified
        public static bool userIsVefied(string email)
        {
            SqlCommand cmd = new SqlCommand("SELECT verified FROM lecturers WHERE email = @email;");
            cmd.Parameters.AddWithValue("@email", email);

            DataTable dt = DBConnection.executeQuery(cmd);

            return (bool)dt.Rows[0]["verified"];
        }

        //Get a datatable with all the user data
        public static DataTable getUserTable(string id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM lecturers WHERE id = @id;");
            cmd.Parameters.AddWithValue("@id", id);

            DataTable t = DBConnection.executeQuery(cmd);

            return t;           
        }

        // Register user
        public static void Register(string name, string email, string password)
        {
            string pwhash = Hashing.GetHash(password);

            SqlCommand cmd = new SqlCommand("INSERT INTO lecturers (name, email, password, verified) VALUES (@name, @email, @pwhash, 'false');");
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@pwhash", pwhash);

            DBConnection.executeQuery(cmd);
        }

        //Check capacity availability in slots // Just for extra checking!
        public static bool CheckCapacityInSlots(int slotID)
        {
            DataTable table;
            Object obj;
            int capacity;

            SqlCommand cmd = new SqlCommand("SELECT capacity FROM slots WHERE id = @slotID;");
            cmd.Parameters.AddWithValue("@slotID", slotID);

            table = DBConnection.executeQuery(cmd);
            obj = table.Rows[0]["capacity"];
            capacity = int.Parse(obj.ToString());

            return capacity > 0;
        }

        // Reserve slot
        // Var capacity will be decremented by 1 when reservation is made
        public static void Reserve(int lecturerID, int slotID)
        {
            SqlCommand cmd1 = new SqlCommand("SELECT capacity FROM slots WHERE id = @slotID;");
            cmd1.Parameters.AddWithValue("@slotID", slotID);

            DBConnection.executeQuery(cmd1);
            //DBConnection.executeQuery("INSERT INTO reservations (slot_id, lecturer_id, created_at) VALUES ('" + slotID + "', '" + lecturerID + "', '" + TimeStamp.DateTimeToUnixTimestamp(DateTime.Now) + "')");
            SqlCommand cmd2 = new SqlCommand("INSERT INTO reservations (slot_id, lecturer_id) VALUES (@slotID, @lecturerID);");
            cmd2.Parameters.AddWithValue("@slotID", slotID);
            cmd2.Parameters.AddWithValue("@lecturerID", lecturerID);
            
            DBConnection.executeQuery(cmd2);
        
        }
        public static void UnReserve(int lecturerID, int slotsID)
        {
            DBConnection.executeQuery("DELETE reservations WHERE reservations.slots_id = '" + slotsID + "' AND reservations.lecturerID = '" + lecturerID + "'");
        }

        //Change user password
        public static void changePassword(string email, string password)
        {
            string pwhash = Hashing.GetHash(password);

            SqlCommand cmd = new SqlCommand("UPDATE lecturers SET password= @pwhash + WHERE email= @email;");
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@pwhash", pwhash);

            DBConnection.executeQuery(cmd);
        }

        //Set user to verified in DB
        public static void verifyUser(string email)
        {
            SqlCommand cmd = new SqlCommand("UPDATE lecturers SET verified='1' WHERE email= @email;");
            cmd.Parameters.AddWithValue("@email", email);

            DBConnection.executeQuery(cmd);
        }

        //This Method returns true if the given hash equals the saved hash found in the database. Identified through the emailaddress
        public static bool login(string email, string password)
        {
            string hash = Hashing.GetHash(password);

            SqlCommand cmd = new SqlCommand("SELECT password FROM lecturers WHERE email = @email;");
            cmd.Parameters.AddWithValue("@email", email);

            DataTable t = DBConnection.executeQuery(cmd);

            Object o = null;

            if (t.Rows.Count == 1) //check if he found a password
            {
                o = t.Rows[0]["password"];
            }

            return hash.Equals(o.ToString());
        }

        //Query voor rooster weer te geven per departement (YENS)
        public static DataTable RoosterPerDepartement(string departement)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM slots WHERE departement = @departement;");
            cmd.Parameters.AddWithValue("@departement", departement);

            DataTable depPerRooster = DBConnection.executeQuery(cmd);
            return depPerRooster;
        }

        //Query voor rooster weer te geven per campus (PIET)
        public static DataTable RoosterPerCampus(string campus)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM slots WHERE city = @campus;");
            cmd.Parameters.AddWithValue("@campus", campus);

            DataTable campusPerRooster = DBConnection.executeQuery(cmd);
            return campusPerRooster;
        }

        //Check if a lecturer with the supplied ID exists in the admins table
        public static bool CheckAdmin(string lecturerID)
        {

            SqlCommand cmd = new SqlCommand("SELECT count(*) AS isAdmin FROM admins WHERE lecturer_id = @lecturerID;");
            cmd.Parameters.AddWithValue("@lecturerID", lecturerID);

            DataTable table = DBConnection.executeQuery(cmd);
            Object obj = table.Rows[0]["isAdmin"];
            return (obj.ToString().Equals("1"));
        }

        //Set the site message
        public static void SetSiteMessage(string message)
        {
            SqlCommand cmd = new SqlCommand("UPDATE message SET motd= @message;");
            cmd.Parameters.AddWithValue("@message", message);

            DBConnection.executeQuery(cmd);
        }

        //Get the site message
        public static DataTable GetSiteMessage()
        {
            SqlCommand cmd = new SqlCommand("SELECT motd FROM message");

            DataTable message = DBConnection.executeQuery(cmd);
            return message;
        }



        //Code Pauwel voor de Dataset op te vragen
        public static DataSet getSlots(string lecturerID)
        {
            SqlCommand cmd = new SqlCommand("select * from dbo.slots where dbo. slots.capacity !=0 and dbo.slots.id NOT IN (select dbo.reservations.slot_id from dbo.reservations where dbo.reservations.lecturer_id = @lecturerID);");
            cmd.Parameters.AddWithValue("@lecturerID", lecturerID);

            DataSet ds = DBConnection.executeQueryDataSet(cmd);
            int i = 0;
            string prevDate = "";

            while (i <= ds.Tables[0].Rows.Count - 1)
            {
                DataRow dr = ds.Tables[0].Rows[i];

                // if category field value changes add a new row
                if (dr["date"].ToString() != prevDate)
                {
                    prevDate = dr["date"].ToString();
                    DataRow newrow = ds.Tables[0].NewRow();
                    newrow["city"] = "SubHeading";      // sub heading flag
                    newrow["date"] = dr["date"];  // sub heading text
                    // add row and increment counter to accommodate new row
                    ds.Tables[0].Rows.InsertAt(newrow, i++);
                }
                i++;
            }
            return ds;
        }

        public static DataSet getReservedSlots(string lecturer_id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * from dbo.slots where slots.id IN (select dbo.reservations.slot_id from dbo.reservations where dbo.reservations.lecturer_id = @lecturer_id)");
            cmd.Parameters.AddWithValue("@lecturer_id", lecturer_id);
            DataSet ds = DBConnection.executeQueryDataSet(cmd);

            int i = 0;
            string prevDate = "";

            while (i <= ds.Tables[0].Rows.Count - 1)
            {
                DataRow dr = ds.Tables[0].Rows[i];

                // if category field value changes add a new row
                if (dr["date"].ToString() != prevDate)
                {
                    prevDate = dr["date"].ToString();
                    DataRow newrow = ds.Tables[0].NewRow();
                    newrow["city"] = "SubHeading";      // sub heading flag
                    newrow["date"] = dr["date"];  // sub heading text
                    // add row and increment counter to accommodate new row
                    ds.Tables[0].Rows.InsertAt(newrow, i++);
                }
                i++;
            }
            return ds;
        }
    }
}
