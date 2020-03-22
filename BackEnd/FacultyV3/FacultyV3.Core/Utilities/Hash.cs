using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyV3.Core.Utilities
{
    using System.Security.Cryptography;
    using System.Text;

    public class Hash
    {
        private static Hash instance;

        public static Hash Instance
        {
            get
            {
                if (instance == null) return instance = new Hash();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    // It formats the string as two uppercase hexadecimal characters.
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
