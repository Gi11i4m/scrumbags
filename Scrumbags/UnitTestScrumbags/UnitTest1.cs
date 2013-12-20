using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scrumbags;

namespace UnitTestScrumbags
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Argument_Nul_Exception_Hashing()
        {
            Hashing.GetHash(null);
        }

        [TestMethod]
        public void Correct_Hashmaker()
        {
            string tohash = "Hallo";
            string expected = "724E873A964A9FEBF2D79D350220919D";
            string actual = Hashing.GetHash(tohash);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Hash_Length_Good()
        {
            int expected = 32;
            string val = "belachelijk";

            string actual = Hashing.GetHash(val);
            Assert.AreEqual(expected, actual.Length);
        }
    }
}
