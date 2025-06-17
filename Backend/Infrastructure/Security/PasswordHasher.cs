using Library.Application.Interfaces;
using System;
using System.Text;
using System.Security.Cryptography;

namespace Library.Infrastructure.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            return hashedPassword == HashPassword(providedPassword);
        }

    }
}
