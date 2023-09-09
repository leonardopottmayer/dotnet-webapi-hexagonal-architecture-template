using HexagonalArchitecture.Domain.Adapters.UserProvider;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalArchitecture.Adapter.Rest.Controllers.v1
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/user")]
    public class UserController : DefaultController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserReference _userReference;
        private readonly IMediator _mediator;

        public UserController(IMediator mediator, IUserReference userReference, IHttpContextAccessor httpContextAccessor) : base(userReference, httpContextAccessor)
        {
            _mediator = mediator;
            _userReference = userReference;
            _httpContextAccessor = httpContextAccessor;
        }

        //[HttpGet]
        //[ProducesResponseType(200, Type = typeof(IEnumerable<UserDto>))]
        //public async Task<IActionResult> GetAllUsers()
        //{
        //    var cmd = new GetAllUsersCommand();

        //    var result = await _mediator.Send(cmd);

        //    return Ok(result);
        //}

        //[HttpGet("{UserId}")]
        //[ProducesResponseType(200, Type = typeof(UserDto))]
        //[ProducesResponseType(404)]
        //public async Task<IActionResult> GetUserById(long userId)
        //{
        //    var cmd = new GetUserByIdCommand()
        //    {
        //        Id = userId
        //    };

        //    var result = await _mediator.Send(cmd);

        //    if (result == null)
        //        return NotFound();

        //    return Ok(result);
        //}

        //[HttpDelete("{UserId}")]
        //[ProducesResponseType(200, Type = typeof(bool))]
        //[ProducesResponseType(404)]
        //public async Task<IActionResult> DeleteUser(long userId)
        //{
        //    var cmd = new DeleteUserCommand()
        //    {
        //        Id = userId
        //    };

        //    var result = await _mediator.Send(cmd);

        //    if (result == false)
        //        return BadRequest();

        //    return Ok(result);
        //}

        //[HttpPost]
        //[ProducesResponseType(201, Type = typeof(long))]
        //[ProducesResponseType(400)]
        //public async Task<IActionResult> CreateUser([FromBody] CreateUserDto user)
        //{
        //    var cmd = new CreateUserCommand()
        //    {
        //        User = user
        //    };

        //    var result = await _mediator.Send(cmd);

        //    if (result < 1)
        //        return BadRequest();

        //    return Ok(result);
        //}

        //[HttpPut("{UserId}")]
        //[ProducesResponseType(200, Type = typeof(bool))]
        //[ProducesResponseType(400)]
        //public async Task<IActionResult> UpdateUser(long userId, [FromBody] UpdateUserDto user)
        //{
        //    var cmd = new UpdateUserCommand()
        //    {
        //        User = user,
        //        UserId = userId
        //    };

        //    var result = await _mediator.Send(cmd);

        //    if (!result)
        //        return BadRequest();

        //    return Ok(result);
        //}
    }
}
