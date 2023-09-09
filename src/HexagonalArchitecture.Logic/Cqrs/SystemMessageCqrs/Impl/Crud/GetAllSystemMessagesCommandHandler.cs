using HexagonalArchitecture.Domain.Adapters.Data;
using HexagonalArchitecture.Domain.Entities;
using HexagonalArchitecture.Domain.Repositories;
using HexagonalArchitecture.Logic.Cqrs.SystemMessageCqrs.Definitions.Crud;

namespace HexagonalArchitecture.Logic.Cqrs.SystemMessageCqrs.Impl.Crud
{
    public class GetAllSystemMessagesCommandHandler : AbstractCommandHandler<GetAllSystemMessagesCommand, IEnumerable<SystemMessage>>, IGetAllSystemMessagesCommandHandler
    {
        private readonly IDBContext _dbContext;
        public GetAllSystemMessagesCommandHandler(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected override async Task<IEnumerable<SystemMessage>> HandleAsync(GetAllSystemMessagesCommand request, CancellationToken cancellationToken)
        {
            var repo = _dbContext.AcquireRepository<ISystemMessageRepository>();
            var systemMessages = await repo.FetchAsync();

            return systemMessages;
        }
    }
}
