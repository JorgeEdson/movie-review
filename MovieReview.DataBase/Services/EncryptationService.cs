using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MovieReview.Database.Services
{
    public class EncryptationService
    {
        public string AddCryptography(string paramData)
        {
            byte[] bytesData = Encoding.UTF8.GetBytes(paramData);    
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(bytesData);
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2")); 
                }

                return builder.ToString();
            }
        }
    }
}
