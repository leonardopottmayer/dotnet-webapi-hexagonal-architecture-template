using HexagonalArchitecture.Domain.Adapters.Data;
using HexagonalArchitecture.Domain.Entities;
using HexagonalArchitecture.Domain.Repositories;
using HexagonalArchitecture.Logic.Cqrs.SystemMessageCqrs.Definitions.Crud;

namespace HexagonalArchitecture.Logic.Cqrs.ProductCqrs.Impl.Crud
{
    public class GetSystemMessageByIdCommandHandler : AbstractCommandHandler<GetSystemMessageByIdCommand, SystemMessage>, IGetSystemMessageByIdCommandHandler
    {
        private readonly IDBContext _dbContext;
        public GetSystemMessageByIdCommandHandler(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected override async Task<SystemMessage> HandleAsync(GetSystemMessageByIdCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == 0)
            {
                throw new ArgumentException();
            }

            var repo = _dbContext.AcquireRepository<ISystemMessageRepository>();
            var systemMessage = await repo.FetchIdAsync(request.Id);

            return systemMessage;
        }
    }
}
