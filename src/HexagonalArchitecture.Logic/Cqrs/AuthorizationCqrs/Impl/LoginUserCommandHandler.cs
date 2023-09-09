using AutoMapper;
using HexagonalArchitecture.Domain.Adapters.Authorization;
using HexagonalArchitecture.Domain.Adapters.Data;
using HexagonalArchitecture.Domain.Adapters.SystemInfoProvider;
using HexagonalArchitecture.Domain.Exceptions;
using HexagonalArchitecture.Domain.Models.AuthorizationModels;
using HexagonalArchitecture.Domain.Models.UserModels;
using HexagonalArchitecture.Domain.Repositories;
using HexagonalArchitecture.Logic.Cqrs.AuthorizationCqrs.Definitions;

namespace HexagonalArchitecture.Logic.Cqrs.AuthorizationCqrs.Impl
{
    public class LoginUserCommandHandler : AbstractCommandHandler<LoginUserCommand, LoginResponseDto>, ILoginUserCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IDBContext _dbContext;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;
        private readonly ISystemInfoReference _systemInfoReference;

        public LoginUserCommandHandler(IMapper mapper, IDBContext dbContext, IPasswordHasher passwordHasher, ITokenService tokenService, ISystemInfoReference systemInfoReference)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
            _systemInfoReference = systemInfoReference;
        }

        protected override async Task<LoginResponseDto> HandleAsync(LoginUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.UserData.FieldsAreValied())
                throw new ArgumentException();

            var userRepo = _dbContext.AcquireRepository<IUserRepository>();

            var user = await userRepo.GetUserByUsername(request.UserData.Username);

            if (user == null)
                throw new KeyNotFoundException();

            var verifiedPassword = _passwordHasher.VerifyPassword(request.UserData.Password, user.PasswordSalt, user.Password);

            if (verifiedPassword == false)
                throw new BusinessException(3);

            var token = _tokenService.CreateToken(user);

            var obj = new LoginResponseDto()
            {
                Token = token,
                User = _mapper.Map<UserDto>(user)
            };

            return obj;
        }
    }
}
