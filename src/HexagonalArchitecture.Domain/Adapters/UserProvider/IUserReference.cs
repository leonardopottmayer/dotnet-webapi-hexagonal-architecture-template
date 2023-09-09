using HexagonalArchitecture.Domain.Models.UserModels;

namespace HexagonalArchitecture.Domain.Adapters.UserProvider
{
    public interface IUserReference
    {
        UserReferenceData User { get; }
    }
}
