using HexagonalArchitecture.Domain.Contracts;

namespace HexagonalArchitecture.Domain.Models.AuthorizationModels
{
    public class LoginUserDto : IValidableFields
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public LoginUserDto() { }
        public LoginUserDto(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public bool FieldsAreValied()
        {
            bool isValid = true;

            if (Username.Trim().Length < 1)
                isValid = false;

            return isValid;
        }

        public dynamic ValidateFields()
        {
            throw new NotImplementedException();
        }
    }
}
