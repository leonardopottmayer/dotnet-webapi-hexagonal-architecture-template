using HexagonalArchitecture.Domain.Logic.Cqrs.Interfaces;
using HexagonalArchitecture.Domain.Models.UserModels;

namespace HexagonalArchitecture.Logic.Cqrs.UserCqrs.Definitions.Crud
{
    public class GetAllUsersCommand : ICommand<IEnumerable<UserDto>>
    {
    }

    public interface IGetAllUsersCommandHandler : IDefaultCommandHandler<GetAllUsersCommand, IEnumerable<UserDto>> { }
}
