using HexagonalArchitecture.Domain.Adapters.UserProvider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalArchitecture.Adapter.Rest
{
    public class DefaultController : ControllerBase
    {
        private readonly IUserReference _userReference;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DefaultController(IUserReference userReference, IHttpContextAccessor httpContextAccessor)
        {
            _userReference = userReference;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
