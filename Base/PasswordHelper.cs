using System.Security.Cryptography;
using System.Text;
using System;

namespace AquaTherm.Base
{
    public static class PasswordHelper
    {
        public static string Hash(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hashBytes);
            }
        }
    }

}
