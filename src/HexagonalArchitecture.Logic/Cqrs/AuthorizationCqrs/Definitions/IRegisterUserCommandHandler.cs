using HexagonalArchitecture.Domain.Logic.Cqrs.Interfaces;
using HexagonalArchitecture.Domain.Models.AuthorizationModels;

namespace HexagonalArchitecture.Logic.Cqrs.AuthorizationCqrs.Definitions
{
    public class RegisterUserCommand : ICommand<long>
    {
        public RegisterUserDto User { get; set; }
    }

    public interface IRegisterUserCommandHandler : IDefaultCommandHandler<RegisterUserCommand, long> { }
}
