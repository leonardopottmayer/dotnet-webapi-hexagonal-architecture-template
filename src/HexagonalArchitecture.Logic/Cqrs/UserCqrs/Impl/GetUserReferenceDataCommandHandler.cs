using AutoMapper;
using HexagonalArchitecture.Domain.Adapters.Data;
using HexagonalArchitecture.Domain.Models.UserModels;
using HexagonalArchitecture.Domain.Repositories;
using HexagonalArchitecture.Logic.Cqrs.UserCqrs.Definitions;
using HexagonalArchitecture.Logic.Cqrs.UserCqrs.Definitions.Crud;

namespace HexagonalArchitecture.Logic.Cqrs.UserCqrs.Impl.Crud
{
    public class GetUserReferenceDataCommandHandler : AbstractCommandHandler<GetUserReferenceDataCommand, UserReferenceData>, IGetUserReferenceDataCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IDBContext _dbContext;
        public GetUserReferenceDataCommandHandler(IMapper mapper, IDBContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        protected override async Task<UserReferenceData> HandleAsync(GetUserReferenceDataCommand request, CancellationToken cancellationToken)
        {
            var userRepo = _dbContext.AcquireRepository<IUserRepository>();
            var user = await userRepo.FetchIdAsync(request.UserId);

            return _mapper.Map<UserReferenceData>(user);
        }
    }
}
