using AutoMapper;
using HexagonalArchitecture.Domain.Adapters.Data;
using HexagonalArchitecture.Domain.Repositories;
using HexagonalArchitecture.Logic.Cqrs.UserCqrs.Definitions.Crud;

namespace HexagonalArchitecture.Logic.Cqrs.UserCqrs.Impl.Crud
{
    public class DeleteUserCommandHandler : AbstractCommandHandler<DeleteUserCommand, bool>, IDeleteUserCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IDBContext _dbContext;
        public DeleteUserCommandHandler(IMapper mapper, IDBContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        protected override async Task<bool> HandleAsync(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == 0)
            {
                throw new ArgumentException();
            }

            var repo = _dbContext.AcquireRepository<IUserRepository>();

            var UserToDelete = await repo.FetchIdAsync(request.Id, cancellationToken);

            var wasDeleted = await repo.DeleteByEntityAsync(UserToDelete, cancellationToken);

            return wasDeleted;
        }
    }
}
