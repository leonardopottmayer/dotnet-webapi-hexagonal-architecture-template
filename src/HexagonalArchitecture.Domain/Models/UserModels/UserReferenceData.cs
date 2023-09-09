namespace HexagonalArchitecture.Domain.Models.UserModels
{
    public class UserReferenceData
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public UserReferenceData(long id, string name, string username, string email)
        {
            Id = id;
            Name = name;
            Username = username;
            Email = email;
        }
    }
}
