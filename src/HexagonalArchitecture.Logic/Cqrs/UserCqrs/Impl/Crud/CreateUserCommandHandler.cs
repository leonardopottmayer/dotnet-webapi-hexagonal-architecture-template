using AutoMapper;
using HexagonalArchitecture.Domain.Adapters.Data;
using HexagonalArchitecture.Domain.Entities;
using HexagonalArchitecture.Domain.Exceptions;
using HexagonalArchitecture.Domain.Repositories;
using HexagonalArchitecture.Logic.Cqrs.UserCqrs.Definitions.Crud;

namespace HexagonalArchitecture.Logic.Cqrs.UserCqrs.Impl.Crud
{
    public class CreateUserCommandHandler : AbstractCommandHandler<CreateUserCommand, long>, ICreateUserCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IDBContext _dbContext;
        public CreateUserCommandHandler(IMapper mapper, IDBContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        protected override async Task<long> HandleAsync(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.User.FieldsAreValied())
                throw new BusinessException(2);

            var repo = _dbContext.AcquireRepository<IUserRepository>();

            var UserToCreate = _mapper.Map<User>(request.User);

            var UserId = await repo.CreateAsync(UserToCreate, cancellationToken);

            return UserId;
        }
    }
}
