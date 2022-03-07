using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Company.API.DataLayer.Helper
{
    public class PasswordHelper
    {
        public static byte[] StringToPassword(string password)
        {
            using var hash = SHA256.Create();
            var enc = Encoding.UTF8;
            return hash.ComputeHash(enc.GetBytes(password));
        }

        public static bool Authentication(string password, byte[] hashpassword)
        {
            using var hash = SHA256.Create();
            var enc = Encoding.UTF8;
            var bytepassword = hash.ComputeHash(enc.GetBytes(password));
            return hashpassword.SequenceEqual(bytepassword);
        }
    }
}
