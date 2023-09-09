using HexagonalArchitecture.Domain.Adapters.Authorization;
using HexagonalArchitecture.Domain.Adapters.UserProvider;
using HexagonalArchitecture.Domain.Models.UserModels;
using HexagonalArchitecture.Logic.Cqrs.UserCqrs.Definitions;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace HexagonalArchitecture.Adapter.UserProvider
{
    public class UserReference : IUserReference
    {
        private ClaimsPrincipal _claimsPrincipal { get; set; }
        private readonly ITokenService _tokenService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMediator _mediator;
        public UserReferenceData User { get; private set; }

        public UserReference(IMediator mediator, IHttpContextAccessor httpContextAccessor, ITokenService tokenService)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
            _tokenService = tokenService;

            if (_httpContextAccessor.HttpContext == null)
            {
                _claimsPrincipal = null;
                User = null;
            }
            else
            {
                CreateUserReference();
            }
        }

        private string GetTokenFromRequest()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            return token;
        }

        private void SetClaimsPrincipal()
        {
            var token = GetTokenFromRequest();

            _claimsPrincipal = _tokenService.GetTokenClaimsPrincipal(token);
        }

        private void CreateUserReference()
        {
            SetClaimsPrincipal();

            long userId = Convert.ToInt64(_claimsPrincipal.Claims.FirstOrDefault(claim => claim.Type == "sub")?.Value);

            SetUserData(userId);
        }

        private async void SetUserData(long userId)
        {
            var cmd = new GetUserReferenceDataCommand()
            {
                UserId = userId
            };

            var result = await _mediator.Send(cmd);

            User = result;
        }
    }
}
