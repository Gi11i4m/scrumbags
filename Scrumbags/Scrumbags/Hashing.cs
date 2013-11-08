using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Scrumbags
{
    public static class Hashing
    {
        private const int ITERATIONS = 25;
        public static string GetHash(string input)
        {
            for (int i = 0; i <= ITERATIONS; i++)
            {
                ApplyHash(ref input);
            }
            return input;
        }

        private static void ApplyHash(ref string input)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            input = sb.ToString();
        }
    }
}