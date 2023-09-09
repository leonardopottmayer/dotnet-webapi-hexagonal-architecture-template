using HexagonalArchitecture.Domain.Adapters.Authorization;
using HexagonalArchitecture.Domain.Exceptions;
using HexagonalArchitecture.Domain.Models.ProductModels;
using HexagonalArchitecture.Logic.Cqrs.AuthorizationCqrs.Definitions;
using HexagonalArchitecture.Logic.Cqrs.UserCqrs.Definitions.Crud;
using MediatR;

namespace HexagonalArchitecture.Logic.Cqrs.AuthorizationCqrs.Impl
{
    public class RegisterUserCommandHandler : AbstractCommandHandler<RegisterUserCommand, long>, IRegisterUserCommandHandler
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMediator _mediator;
        public RegisterUserCommandHandler(IMediator mediator, IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
            _mediator = mediator;
        }
        protected override async Task<long> HandleAsync(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.User.FieldsAreValied())
                throw new BusinessException(2);

            var hashedPassword = _passwordHasher.HashPassword(request.User.Password, out var salt);

            var userToCreate = new CreateUserDto(request.User.Name, request.User.Username, hashedPassword, request.User.Email, Convert.ToBase64String(salt));

            var createUserCmd = new CreateUserCommand()
            {
                User = userToCreate
            };

            var result = await _mediator.Send(createUserCmd);

            return result;
        }
    }
}
