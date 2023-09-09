using HexagonalArchitecture.Domain.Adapters.Data;
using HexagonalArchitecture.Domain.Entities;
using HexagonalArchitecture.Domain.Repositories;
using HexagonalArchitecture.Logic.Cqrs.SystemMessageCqrs.Definitions.Crud;

namespace HexagonalArchitecture.Logic.Cqrs.ProductCqrs.Impl.Crud
{
    public class GetSystemMessageByCodeCommandHandler : AbstractCommandHandler<GetSystemMessageByCodeCommand, SystemMessage>, IGetSystemMessageByCodeCommandHandler
    {
        private readonly IDBContext _dbContext;
        public GetSystemMessageByCodeCommandHandler(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected override async Task<SystemMessage> HandleAsync(GetSystemMessageByCodeCommand request, CancellationToken cancellationToken)
        {
            if (request.Code == 0)
            {
                throw new ArgumentException();
            }

            var repo = _dbContext.AcquireRepository<ISystemMessageRepository>();
            var systemMessage = await repo.GetByCode(request.Code);

            return systemMessage;
        }
    }
}
