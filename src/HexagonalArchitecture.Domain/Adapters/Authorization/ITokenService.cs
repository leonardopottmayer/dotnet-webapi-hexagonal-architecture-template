using HexagonalArchitecture.Domain.Entities;
using System.Security.Claims;

namespace HexagonalArchitecture.Domain.Adapters.Authorization
{
    public interface ITokenService
    {
        string CreateToken(User user, UserType userType = UserType.Default);
        ClaimsPrincipal GetTokenClaimsPrincipal(string token);
    }
}
