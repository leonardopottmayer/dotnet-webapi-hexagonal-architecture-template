using HexagonalArchitecture.Domain.Logic.Cqrs.Interfaces;
using HexagonalArchitecture.Domain.Models.UserModels;

namespace HexagonalArchitecture.Logic.Cqrs.UserCqrs.Definitions.Crud
{
    public class UpdateUserCommand : ICommand<bool>
    {
        public UpdateUserDto User { get; set; }
        public long UserId { get; set; }
    }

    public interface IUpdateUserCommandHandler : IDefaultCommandHandler<UpdateUserCommand, bool> { }
}
