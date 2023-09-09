using AutoMapper;
using HexagonalArchitecture.Domain.Adapters.Data;
using HexagonalArchitecture.Domain.Models.ProductModels;
using HexagonalArchitecture.Domain.Repositories;
using HexagonalArchitecture.Logic.Cqrs.ProductCqrs.Definitions.Crud;

namespace HexagonalArchitecture.Logic.Cqrs.ProductCqrs.Impl.Crud
{
    public class GetProductByIdCommandHandler : AbstractCommandHandler<GetProductByIdCommand, ProductDto>, IGetProductByIdCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IDBContext _dbContext;
        public GetProductByIdCommandHandler(IMapper mapper, IDBContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        protected override async Task<ProductDto> HandleAsync(GetProductByIdCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == 0)
            {
                throw new ArgumentException();
            }

            var repo = _dbContext.AcquireRepository<IProductRepository>();
            var product = await repo.FetchIdAsync(request.Id);

            return _mapper.Map<ProductDto>(product);
        }
    }
}
