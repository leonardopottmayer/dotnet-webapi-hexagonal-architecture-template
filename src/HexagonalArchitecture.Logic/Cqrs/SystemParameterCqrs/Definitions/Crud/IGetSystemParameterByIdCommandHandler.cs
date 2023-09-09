using HexagonalArchitecture.Domain.Entities;
using HexagonalArchitecture.Domain.Logic.Cqrs.Interfaces;

namespace HexagonalArchitecture.Logic.Cqrs.SystemParameterCqrs.Definitions.Crud
{
    public class GetSystemParameterByIdCommand : ICommand<SystemParameter>
    {
        public long Id { get; set; }
    }

    public interface IGetSystemParameterByIdCommandHandler : IDefaultCommandHandler<GetSystemParameterByIdCommand, SystemParameter> { }
}
