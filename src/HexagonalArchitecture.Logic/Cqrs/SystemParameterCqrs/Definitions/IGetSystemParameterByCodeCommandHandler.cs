using HexagonalArchitecture.Domain.Entities;
using HexagonalArchitecture.Domain.Logic.Cqrs.Interfaces;

namespace HexagonalArchitecture.Logic.Cqrs.SystemParameterCqrs.Definitions.Crud
{
    public class GetSystemParameterByCodeCommand : ICommand<SystemParameter>
    {
        public long Code { get; set; }
    }

    public interface IGetSystemParameterByCodeCommandHandler : IDefaultCommandHandler<GetSystemParameterByCodeCommand, SystemParameter> { }
}
