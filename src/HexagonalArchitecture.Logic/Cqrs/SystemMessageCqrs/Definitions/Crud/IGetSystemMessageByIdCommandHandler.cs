using HexagonalArchitecture.Domain.Entities;
using HexagonalArchitecture.Domain.Logic.Cqrs.Interfaces;

namespace HexagonalArchitecture.Logic.Cqrs.SystemMessageCqrs.Definitions.Crud
{
    public class GetSystemMessageByIdCommand : ICommand<SystemMessage>
    {
        public long Id { get; set; }
    }

    public interface IGetSystemMessageByIdCommandHandler : IDefaultCommandHandler<GetSystemMessageByIdCommand, SystemMessage> { }
}
