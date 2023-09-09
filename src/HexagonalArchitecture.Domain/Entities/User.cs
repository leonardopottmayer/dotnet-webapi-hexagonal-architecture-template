namespace HexagonalArchitecture.Domain.Entities
{
    public class User
    {
        public User() { }
        public User(long id, string name, string username, string password, string email, string passwordSalt)
        {
            Id = id;
            Name = name;
            Username = username;
            Password = password;
            Email = email;
            PasswordSalt = passwordSalt;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
    }
}
