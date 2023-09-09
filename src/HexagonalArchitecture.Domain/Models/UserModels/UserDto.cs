using HexagonalArchitecture.Domain.Contracts;

namespace HexagonalArchitecture.Domain.Models.UserModels
{
    public class UserDto : IValidableFields
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public UserDto() { }
        public UserDto(long id, string name, string username, string email)
        {
            Id = id;
            Name = name;
            Username = username;
            Email = email;
        }

        public bool FieldsAreValied()
        {
            bool isValid = true;

            if (Id == 0)
                isValid = false;
            if (Name.Trim().Length < 1)
                isValid = false;
            if (Username.Trim().Length < 1)
                isValid = false;
            if (Email.Trim().Length < 1)
                isValid = false;

            return isValid;
        }

        public dynamic ValidateFields()
        {
            throw new NotImplementedException();
        }
    }
}
