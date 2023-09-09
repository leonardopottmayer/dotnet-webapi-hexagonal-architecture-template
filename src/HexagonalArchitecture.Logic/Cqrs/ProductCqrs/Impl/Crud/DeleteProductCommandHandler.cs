using AutoMapper;
using HexagonalArchitecture.Domain.Adapters.Data;
using HexagonalArchitecture.Domain.Repositories;
using HexagonalArchitecture.Logic.Cqrs.ProductCqrs.Definitions.Crud;

namespace HexagonalArchitecture.Logic.Cqrs.ProductCqrs.Impl.Crud
{
    public class DeleteProductCommandHandler : AbstractCommandHandler<DeleteProductCommand, bool>, IDeleteProductCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IDBContext _dbContext;
        public DeleteProductCommandHandler(IMapper mapper, IDBContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        protected override async Task<bool> HandleAsync(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == 0)
            {
                throw new ArgumentException();
            }

            var repo = _dbContext.AcquireRepository<IProductRepository>();

            var productToDelete = await repo.FetchIdAsync(request.Id, cancellationToken);

            var wasDeleted = await repo.DeleteByEntityAsync(productToDelete, cancellationToken);

            return wasDeleted;
        }
    }
}
