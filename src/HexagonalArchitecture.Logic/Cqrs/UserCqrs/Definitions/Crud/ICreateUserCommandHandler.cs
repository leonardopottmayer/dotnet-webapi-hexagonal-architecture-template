using HexagonalArchitecture.Domain.Logic.Cqrs.Interfaces;
using HexagonalArchitecture.Domain.Models.ProductModels;

namespace HexagonalArchitecture.Logic.Cqrs.UserCqrs.Definitions.Crud
{
    public class CreateUserCommand : ICommand<long>
    {
        public CreateUserDto User { get; set; }
    }

    public interface ICreateUserCommandHandler : IDefaultCommandHandler<CreateUserCommand, long> { }
}
