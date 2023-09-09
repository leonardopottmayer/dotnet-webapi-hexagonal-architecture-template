using HexagonalArchitecture.Domain.Contracts;

namespace HexagonalArchitecture.Domain.Models.UserModels
{
    public class UpdateUserDto : IValidableFields
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public UpdateUserDto(string name, string username, string email)
        {
            Name = name;
            Username = username;
            Email = email;
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
