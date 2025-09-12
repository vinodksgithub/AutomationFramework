using System;
using System.Security.Cryptography;
using System.Text;

namespace EnvConfigurations.SecureStorage
{
    public static class SecureStorage
    {
        // Encrypt plain text → returns Base64 string
        public static string Encrypt(string plainText)
        {
            byte[] data = Encoding.UTF8.GetBytes(plainText);

            // Protect using CurrentUser scope (only this Windows user can decrypt it)
            byte[] encrypted = ProtectedData.Protect(data, null, DataProtectionScope.CurrentUser);

            return Convert.ToBase64String(encrypted);
        }

        // Decrypt Base64 string → returns plain text
        public static string Decrypt(string cipherText)
        {
            byte[] data = Convert.FromBase64String(cipherText);

            byte[] decrypted = ProtectedData.Unprotect(data, null, DataProtectionScope.CurrentUser);

            return Encoding.UTF8.GetString(decrypted);
        }
    }
}