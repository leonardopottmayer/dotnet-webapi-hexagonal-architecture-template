using HexagonalArchitecture.Domain.Contracts;

namespace HexagonalArchitecture.Domain.Models.ProductModels
{
    public class CreateUserDto : IValidableFields
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string Email { get; set; }
        public CreateUserDto(string name, string username, string password, string email, string passwordSalt)
        {
            Name = name;
            Username = username;
            Password = password;
            Email = email;
            PasswordSalt = passwordSalt;
        }

        public bool FieldsAreValied()
        {
            bool isValid = true;

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
