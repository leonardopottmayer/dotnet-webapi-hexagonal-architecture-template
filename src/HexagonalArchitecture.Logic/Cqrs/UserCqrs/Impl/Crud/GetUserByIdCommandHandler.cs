using AutoMapper;
using HexagonalArchitecture.Domain.Adapters.Data;
using HexagonalArchitecture.Domain.Models.UserModels;
using HexagonalArchitecture.Domain.Repositories;
using HexagonalArchitecture.Logic.Cqrs.UserCqrs.Definitions.Crud;

namespace HexagonalArchitecture.Logic.Cqrs.UserCqrs.Impl.Crud
{
    public class GetUserByIdCommandHandler : AbstractCommandHandler<GetUserByIdCommand, UserDto>, IGetUserByIdCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IDBContext _dbContext;
        public GetUserByIdCommandHandler(IMapper mapper, IDBContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        protected override async Task<UserDto> HandleAsync(GetUserByIdCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == 0)
            {
                throw new ArgumentException();
            }

            var repo = _dbContext.AcquireRepository<IUserRepository>();
            var User = await repo.FetchIdAsync(request.Id);

            return _mapper.Map<UserDto>(User);
        }
    }
}
