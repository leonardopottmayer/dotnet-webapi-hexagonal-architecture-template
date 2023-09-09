using HexagonalArchitecture.Domain.Logic.Cqrs.Interfaces;
using HexagonalArchitecture.Domain.Models.AuthorizationModels;

namespace HexagonalArchitecture.Logic.Cqrs.AuthorizationCqrs.Definitions
{
    public class LoginUserCommand : ICommand<LoginResponseDto>
    {
        public LoginUserDto UserData { get; set; }
    }

    public interface ILoginUserCommandHandler : IDefaultCommandHandler<LoginUserCommand, LoginResponseDto> { }
}
