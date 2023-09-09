using HexagonalArchitecture.Domain.Entities;
using HexagonalArchitecture.Domain.Logic.Cqrs.Interfaces;

namespace HexagonalArchitecture.Logic.Cqrs.SystemMessageCqrs.Definitions.Crud
{
    public class GetAllSystemMessagesCommand : ICommand<IEnumerable<SystemMessage>>
    {
    }

    public interface IGetAllSystemMessagesCommandHandler : IDefaultCommandHandler<GetAllSystemMessagesCommand, IEnumerable<SystemMessage>> { }
}
