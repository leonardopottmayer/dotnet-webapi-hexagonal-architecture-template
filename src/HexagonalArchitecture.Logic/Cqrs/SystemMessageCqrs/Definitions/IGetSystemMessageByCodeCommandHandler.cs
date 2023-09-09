using HexagonalArchitecture.Domain.Entities;
using HexagonalArchitecture.Domain.Logic.Cqrs.Interfaces;

namespace HexagonalArchitecture.Logic.Cqrs.SystemMessageCqrs.Definitions.Crud
{
    public class GetSystemMessageByCodeCommand : ICommand<SystemMessage>
    {
        public long Code { get; set; }
    }

    public interface IGetSystemMessageByCodeCommandHandler : IDefaultCommandHandler<GetSystemMessageByCodeCommand, SystemMessage> { }
}
