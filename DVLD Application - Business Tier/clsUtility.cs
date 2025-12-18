using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace BusinessLogicTier
{
    public static class clsUtility
    {
        public static bool ValidateEmailAddress(string EmailAddress)
        {
            EmailAddress = EmailAddress.Trim();
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            return Regex.IsMatch(EmailAddress, pattern);
        }

        public static string GetHashValue(string OriginalValue)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash value from the UTF-8 encoded input string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(OriginalValue));


                // Convert the byte array to a lowercase hexadecimal string
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
