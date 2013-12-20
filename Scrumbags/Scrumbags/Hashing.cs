using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Scrumbags
{
    public static class Hashing
    {
        // Dit is zonder seed. ge moet zelf eens zien hoe ge met seeds wilt werken.
        // ge kunt ne seed late genereren door een andere functie en die bij het creeeren mee geven.
        // of een 2e methode toevoegen hier ApplyHashWithSeed.
        private const int ITERATIONS = 25;
        public static string GetHash(string input)
        {
            // Apply hash 25 times for added security
            for (int i = 0; i <= ITERATIONS; i++)
            {
                ApplyHash(ref input);
            }
            return input;
        }

        private static void ApplyHash(ref string input)
        {
            //UNIT TESTED!!!!!
            //This Method creates a MD5 hash using the input string
                MD5 md5 = MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hash = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                input = sb.ToString();
        }
    }
}