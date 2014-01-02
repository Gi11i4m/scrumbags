using System;
using System.Data;
using System.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scrumbags;
using System.Data.SqlClient;

namespace UnitTestScrumbags
{
    [TestClass]
    public class UnitTestDatabaseQueries
    {
        [TestMethod]
        public void TestUserExists()
        {
            string email = "tim.acke@artesis.be";
            bool actual = DBQueries.UserExists(email);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void TestNegativeUserExists()
        {
            string email = "bart.dewever@ap.be";
            bool actual = DBQueries.UserExists(email);

            Assert.IsFalse(actual);
        }

        [ExpectedException(typeof (SqlException))]
        [TestMethod]
        public void TestExceptionUserExists()
        {
            string email = null;
            bool actual = DBQueries.UserExists(email);
        }

        [TestMethod]
        public void TestUserIsVefied()
        {
            string email = "tim.acke@artesis.be";
            bool actual = DBQueries.userIsVefied(email);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void TestGetUserTable()
        {
            //
        }

        [TestMethod]
        public void TestRegister()
        {
            string name = "test1";
            string email = "test1@email.be";
            string password = "1234";

            DBQueries.Register(name, email, password);

            //Select statement to check if user is made

            DataTable dt = DBConnection.executeQuery("SELECT * FROM lecturers WHERE name ='" + name + "' AND email = '" + email + "' AND password = '" + Hashing.GetHash(password) + "' ");
            
            Assert.AreEqual(1, dt.Rows.Count);
        }

        [TestMethod]
        public void TestCheckCapacityInSlots()
        {
            int slotId = 2;
            bool actual = DBQueries.CheckCapacityInSlots(slotId);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void TestReserve()
        {
            DBQueries.Reserve(1157,2);
        }

        [TestMethod]
        public void TestUnReserve()
        {
            DBQueries.UnReserve(1157, 2);
        }

        [TestMethod]
        public void TestChangePassword()
        {
            string email = "test1@email.be";
            string newPwd = "5678";
            DBQueries.changePassword(email, newPwd);
            
            //Login to check if worked
            bool actual = DBQueries.login(email, newPwd);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void TestVerifyUser()
        {
            string email = "test1@email.be";
            DBQueries.verifyUser(email);

            bool actual = DBQueries.userIsVefied(email);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void TestGetLoggedInUserId()
        {
            string email = "tim.acke@artesis.be";
            int actual = DBQueries.getLoggedInUserID(email);
            int expected = 1157;

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestLogin()
        {
            string email = "tim.acke@artesis.be";
            string password = "1234";

            bool actual = DBQueries.login(email, password);

            Assert.IsTrue(actual);

        }

        [TestMethod]
        public void TestCheckAdmin()
        {
            string lecturerId = "1157"; // ID from user 'tim.acke@artesis.be' which is an admin

            bool actual = DBQueries.CheckAdmin(lecturerId);
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSetSiteMessage()
        {
            string message = "Test message!";
            DBQueries.SetSiteMessage(message);

            string actual = DBQueries.GetSiteMessage();

            Assert.AreEqual(message, actual);
        }

        [TestMethod]
        public void TestGetSiteMessage()
        {
            string message = "Test message!";
            string actual = DBQueries.GetSiteMessage();

            Assert.AreEqual(message, actual);
        }

        [TestMethod]
        public void TestgetSlots()
        {
            //User 1157, city = *, digital = *,, '*' means All
            DataSet slots = DBQueries.getSlots("1157", "*", "*");

            DataRow dr = slots.Tables[0].Rows[1];

            Assert.AreEqual("antwerpen",dr["city"]);
        }

        [TestMethod]
        public void TestgetReservedSlots()
        {
            //User 1157, city = *, digital = *,, '*' means All
            DataSet slots = DBQueries.getSlots("1157", "*", "*");

            DataRow dr = slots.Tables[0].Rows[1];

            Assert.AreEqual("antwerpen", dr["city"]);
        }
    }
}
