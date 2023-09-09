using AutoMapper;
using HexagonalArchitecture.Domain.Adapters.Data;
using HexagonalArchitecture.Domain.Entities;
using HexagonalArchitecture.Domain.Repositories;
using HexagonalArchitecture.Logic.Cqrs.SystemParameterCqrs.Definitions.Crud;

namespace HexagonalArchitecture.Logic.Cqrs.ProductCqrs.Impl.Crud
{
    public class GetSystemParameterByCodeCommandHandler : AbstractCommandHandler<GetSystemParameterByCodeCommand, SystemParameter>, IGetSystemParameterByCodeCommandHandler
    {
        private readonly IDBContext _dbContext;
        public GetSystemParameterByCodeCommandHandler(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected override async Task<SystemParameter> HandleAsync(GetSystemParameterByCodeCommand request, CancellationToken cancellationToken)
        {
            if (request.Code == 0)
            {
                throw new ArgumentException();
            }

            var repo = _dbContext.AcquireRepository<ISystemParameterRepository>();
            var SystemParameter = await repo.GetByCode(request.Code);

            return SystemParameter;
        }
    }
}
