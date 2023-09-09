using HexagonalArchitecture.Domain.Logic.Cqrs.Interfaces;
using HexagonalArchitecture.Domain.Models.SystemLogModels;

namespace HexagonalArchitecture.Logic.Cqrs.SystemLogCqrs.Definitions.Crud
{
    public class CreateSystemLogCommand : ICommand<long>
    {
        public CreateSystemLogDto SystemLog { get; set; }
    }

    public interface ICreateSystemLogCommandHandler : IDefaultCommandHandler<CreateSystemLogCommand, long> { }
}
