namespace HexagonalArchitecture.Domain.Adapters.Authorization
{
    public interface IPasswordHasher
    {
        string HashPassword(string password, out byte[] salt);
        bool VerifyPassword(string password, string salt, string hash);
    }
}
