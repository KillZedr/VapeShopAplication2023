using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordHasher
{
    public static class PasswordHasher
    {
        private static string saltString = "ahfdj12314sahjfjka";
        public static byte[] PBKDF2Hash(string input)
        {
            var salt = Encoding.ASCII.GetBytes(saltString);
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(input, salt, iterations: 500);
            return pbkdf2.GetBytes(20);
        }
    }
}
