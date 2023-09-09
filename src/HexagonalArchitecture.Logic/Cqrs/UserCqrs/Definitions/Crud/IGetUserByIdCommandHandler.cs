using HexagonalArchitecture.Domain.Logic.Cqrs.Interfaces;
using HexagonalArchitecture.Domain.Models.UserModels;

namespace HexagonalArchitecture.Logic.Cqrs.UserCqrs.Definitions.Crud
{
    public class GetUserByIdCommand : ICommand<UserDto>
    {
        public long Id { get; set; }
    }

    public interface IGetUserByIdCommandHandler : IDefaultCommandHandler<GetUserByIdCommand, UserDto> { }
}
