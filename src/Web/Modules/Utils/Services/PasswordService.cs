using System;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Web.Modules.Utils.Interfaces;

namespace Web.Modules.Utils.Services
{
    public class PasswordService : IPasswordService
    {
        public string HashPassword(string password, string salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
              password: password,
              salt: Encoding.ASCII.GetBytes(salt),
              prf: KeyDerivationPrf.HMACSHA1,
              iterationCount: 10000,
              numBytesRequested: 256 / 8));

            return hashed;
        }

        public string RandomPassword(int passwordLength)
        {
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";

            Random random = new Random();

            char[] chars = new char[passwordLength];

            for (int i = 0; i < passwordLength; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }

            return new string(chars);
        }
    }
}