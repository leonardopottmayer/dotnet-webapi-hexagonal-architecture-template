using HexagonalArchitecture.Domain.Entities;
using HexagonalArchitecture.Domain.Logic.Cqrs.Interfaces;

namespace HexagonalArchitecture.Logic.Cqrs.SystemParameterCqrs.Definitions.Crud
{
    public class GetAllSystemParametersCommand : ICommand<IEnumerable<SystemParameter>>
    {
    }

    public interface IGetAllSystemParametersCommandHandler : IDefaultCommandHandler<GetAllSystemParametersCommand, IEnumerable<SystemParameter>> { }
}
