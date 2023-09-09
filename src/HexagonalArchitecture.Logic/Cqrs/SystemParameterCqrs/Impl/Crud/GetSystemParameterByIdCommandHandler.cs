using HexagonalArchitecture.Domain.Adapters.Data;
using HexagonalArchitecture.Domain.Entities;
using HexagonalArchitecture.Domain.Repositories;
using HexagonalArchitecture.Logic.Cqrs.SystemParameterCqrs.Definitions.Crud;

namespace HexagonalArchitecture.Logic.Cqrs.ProductCqrs.Impl.Crud
{
    public class GetSystemParameterByIdCommandHandler : AbstractCommandHandler<GetSystemParameterByIdCommand, SystemParameter>, IGetSystemParameterByIdCommandHandler
    {
        private readonly IDBContext _dbContext;
        public GetSystemParameterByIdCommandHandler(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected override async Task<SystemParameter> HandleAsync(GetSystemParameterByIdCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == 0)
            {
                throw new ArgumentException();
            }

            var repo = _dbContext.AcquireRepository<ISystemParameterRepository>();
            var SystemParameter = await repo.FetchIdAsync(request.Id);

            return SystemParameter;
        }
    }
}
