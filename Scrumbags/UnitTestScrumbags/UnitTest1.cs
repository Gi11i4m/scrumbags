using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scrumbags;

namespace UnitTestScrumbags
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DBConnection.executeQuery("SELECT COUNT(*) FROM LECTURERS");
        }
    }
}
