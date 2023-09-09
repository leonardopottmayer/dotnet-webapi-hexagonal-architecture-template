using HexagonalArchitecture.Domain.Adapters.Authorization;
using System.Security.Cryptography;

namespace HexagonalArchitecture.Adapter.Authorization
{
    public class PasswordHasher : IPasswordHasher
    {
        private const int SaltSize = 32; // Salt size in bytes
        private const int HashSize = 32; // Hash size in bytes
        private const int Iterations = 500000; // PBKDF2 iterations number

        public string HashPassword(string password, out byte[] salt)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                salt = new byte[SaltSize];
                rng.GetBytes(salt);

                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
                {
                    byte[] hash = pbkdf2.GetBytes(HashSize);
                    return Convert.ToBase64String(hash);
                }
            }
        }

        public bool VerifyPassword(string password, string salt, string hash)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            byte[] hashBytes = Convert.FromBase64String(hash);

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, Iterations, HashAlgorithmName.SHA256))
            {
                byte[] testHash = pbkdf2.GetBytes(HashSize);
                for (int i = 0; i < HashSize; i++)
                {
                    if (hashBytes[i] != testHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
