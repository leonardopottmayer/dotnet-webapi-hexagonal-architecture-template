using HexagonalArchitecture.Domain.Logic.Cqrs.Interfaces;

namespace HexagonalArchitecture.Logic.Cqrs.UserCqrs.Definitions.Crud
{
    public class DeleteUserCommand : ICommand<bool>
    {
        public long Id { get; set; }
    }

    public interface IDeleteUserCommandHandler : IDefaultCommandHandler<DeleteUserCommand, bool> { }
}
