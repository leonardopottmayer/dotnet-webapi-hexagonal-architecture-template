using HexagonalArchitecture.Domain.Adapters.Rest;
using HexagonalArchitecture.Domain.Exceptions;
using HexagonalArchitecture.Domain.Models.AuthorizationModels;
using HexagonalArchitecture.Logic.Cqrs.AuthorizationCqrs.Definitions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HexagonalArchitecture.Adapter.Rest.Controllers.Authorization
{
    [Route("api/authentication")]
    public class AuthorizationController : ControllerBase
    {
        private readonly ILogger<AuthorizationController> _logger;
        private readonly IMediator _mediator;

        public AuthorizationController(ILogger<AuthorizationController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("register")]
        [ProducesResponseType(201, Type = typeof(ISuccessApiResponse<long>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto user)
        {
            var cmd = new RegisterUserCommand()
            {
                User = user
            };

            var result = await _mediator.Send(cmd);

            if (result < 1)
                throw new BusinessException(1);

            return Ok(result);
        }

        [HttpPost("login")]
        [ProducesResponseType(201, Type = typeof(ISuccessApiResponse<LoginResponseDto>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Login([FromBody] LoginUserDto loginData)
        {
            var cmd = new LoginUserCommand()
            {
                UserData = loginData
            };

            var result = await _mediator.Send(cmd);

            if (result == null)
                throw new BusinessException(4);

            return Ok(result);
        }
    }
}
