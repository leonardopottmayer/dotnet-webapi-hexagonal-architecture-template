using HexagonalArchitecture.Domain.Adapters.Data;
using HexagonalArchitecture.Domain.Entities;
using HexagonalArchitecture.Domain.Repositories;
using HexagonalArchitecture.Logic.Cqrs.SystemParameterCqrs.Definitions.Crud;

namespace HexagonalArchitecture.Logic.Cqrs.SystemParameterCqrs.Impl.Crud
{
    public class GetAllSystemParametersCommandHandler : AbstractCommandHandler<GetAllSystemParametersCommand, IEnumerable<SystemParameter>>, IGetAllSystemParametersCommandHandler
    {
        private readonly IDBContext _dbContext;
        public GetAllSystemParametersCommandHandler(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected override async Task<IEnumerable<SystemParameter>> HandleAsync(GetAllSystemParametersCommand request, CancellationToken cancellationToken)
        {
            var repo = _dbContext.AcquireRepository<ISystemParameterRepository>();
            var SystemParameters = await repo.FetchAsync();

            return SystemParameters;
        }
    }
}
