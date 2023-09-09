using HexagonalArchitecture.Domain.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalArchitecture.Domain.Models.AuthorizationModels
{
    public class LoginResponseDto
    {
        public UserDto User { get; set; }
        public string Token { get; set; }

        public LoginResponseDto() { }
        public LoginResponseDto(UserDto user, string token)
        {
            User = user;
            Token = token;
        }
    }
}
