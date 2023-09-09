using AutoMapper;
using HexagonalArchitecture.Domain.Adapters.Data;
using HexagonalArchitecture.Domain.Models.ProductModels;
using HexagonalArchitecture.Domain.Repositories;
using HexagonalArchitecture.Logic.Cqrs.ProductCqrs.Definitions.Crud;

namespace HexagonalArchitecture.Logic.Cqrs.ProductCqrs.Impl.Crud
{
    public class GetAllProductsCommandHandler : AbstractCommandHandler<GetAllProductsCommand, IEnumerable<ProductDto>>, IGetAllProductsCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IDBContext _dbContext;
        public GetAllProductsCommandHandler(IMapper mapper, IDBContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        protected override async Task<IEnumerable<ProductDto>> HandleAsync(GetAllProductsCommand request, CancellationToken cancellationToken)
        {
            var repo = _dbContext.AcquireRepository<IProductRepository>();
            var product = await repo.FetchAsync();

            return _mapper.Map<List<ProductDto>>(product);
        }
    }
}
