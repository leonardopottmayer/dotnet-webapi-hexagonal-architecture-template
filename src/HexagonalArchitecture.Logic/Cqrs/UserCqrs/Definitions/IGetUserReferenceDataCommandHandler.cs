using HexagonalArchitecture.Domain.Logic.Cqrs.Interfaces;
using HexagonalArchitecture.Domain.Models.UserModels;

namespace HexagonalArchitecture.Logic.Cqrs.UserCqrs.Definitions
{
    public class GetUserReferenceDataCommand : ICommand<UserReferenceData>
    {
        public long UserId { get; set; }
    }

    public interface IGetUserReferenceDataCommandHandler : IDefaultCommandHandler<GetUserReferenceDataCommand, UserReferenceData> { }
}
