using AutoMapper;
using HexagonalArchitecture.Domain.Adapters.Data;
using HexagonalArchitecture.Domain.Entities;
using HexagonalArchitecture.Domain.Repositories;
using HexagonalArchitecture.Logic.Cqrs.SystemLogCqrs.Definitions.Crud;

namespace HexagonalArchitecture.Logic.Cqrs.SystemLogCqrs.Impl.Crud
{
    public class CreateSystemLogCommandHandler : AbstractCommandHandler<CreateSystemLogCommand, long>, ICreateSystemLogCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IDBContext _dbContext;

        public CreateSystemLogCommandHandler(IMapper mapper, IDBContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        protected override async Task<long> HandleAsync(CreateSystemLogCommand request, CancellationToken cancellationToken)
        {
            var repo = _dbContext.AcquireRepository<ISystemLogRepository>();

            var logToCreate = _mapper.Map<SystemLog>(request.SystemLog);

            var systemLogId = await repo.CreateAsync(logToCreate, cancellationToken);

            return systemLogId;
        }
    }
}
