using AutoMapper;
using HexagonalArchitecture.Domain.Adapters.Data;
using HexagonalArchitecture.Domain.Repositories;
using HexagonalArchitecture.Logic.Cqrs.UserCqrs.Definitions.Crud;

namespace HexagonalArchitecture.Logic.Cqrs.UserCqrs.Impl.Crud
{
    public class UpdateUserCommandHandler : AbstractCommandHandler<UpdateUserCommand, bool>, IUpdateUserCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IDBContext _dbContext;
        public UpdateUserCommandHandler(IMapper mapper, IDBContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        protected override async Task<bool> HandleAsync(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.User.FieldsAreValied())
                throw new ArgumentException();

            var repo = _dbContext.AcquireRepository<IUserRepository>();

            var userToUpdate = await repo.FetchIdAsync(request.UserId);

            userToUpdate.Name = request.User.Name;
            userToUpdate.Username = request.User.Username;
            userToUpdate.Email = request.User.Email;

            var wasUpdated = await repo.UpdateByEntityAsync(userToUpdate, cancellationToken);

            return wasUpdated;
        }
    }
}
