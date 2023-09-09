using AutoMapper;
using HexagonalArchitecture.Domain.Adapters.Data;
using HexagonalArchitecture.Domain.Models.UserModels;
using HexagonalArchitecture.Domain.Repositories;
using HexagonalArchitecture.Logic.Cqrs.UserCqrs.Definitions.Crud;

namespace HexagonalArchitecture.Logic.Cqrs.UserCqrs.Impl.Crud
{
    public class GetAllUsersCommandHandler : AbstractCommandHandler<GetAllUsersCommand, IEnumerable<UserDto>>, IGetAllUsersCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IDBContext _dbContext;
        public GetAllUsersCommandHandler(IMapper mapper, IDBContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        protected override async Task<IEnumerable<UserDto>> HandleAsync(GetAllUsersCommand request, CancellationToken cancellationToken)
        {
            var repo = _dbContext.AcquireRepository<IUserRepository>();
            var User = await repo.FetchAsync();

            return _mapper.Map<List<UserDto>>(User);
        }
    }
}
