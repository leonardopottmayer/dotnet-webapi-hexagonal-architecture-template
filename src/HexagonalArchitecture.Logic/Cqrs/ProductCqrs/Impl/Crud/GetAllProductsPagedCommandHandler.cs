using AutoMapper;
using HexagonalArchitecture.Domain.Adapters.Data;
using HexagonalArchitecture.Domain.Adapters.Rest;
using HexagonalArchitecture.Domain.Models.ProductModels;
using HexagonalArchitecture.Domain.Repositories;
using HexagonalArchitecture.Logic.Cqrs.ProductCqrs.Definitions.Crud;

namespace HexagonalArchitecture.Logic.Cqrs.ProductCqrs.Impl.Crud
{
    public class GetAllProductsPagedCommandHandler : AbstractCommandHandler<GetAllProductsPagedCommand, FetchPageResult<ProductDto>>, IGetAllProductsPagedCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IDBContext _dbContext;
        public GetAllProductsPagedCommandHandler(IMapper mapper, IDBContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        protected override async Task<FetchPageResult<ProductDto>> HandleAsync(GetAllProductsPagedCommand request, CancellationToken cancellationToken)
        {
            var repo = _dbContext.AcquireRepository<IProductRepository>();
            var (products, totalProducts) = await repo.FetchPageAsync(request.PageIndex, request.PageSize, cancellationToken);

            return new FetchPageResult<ProductDto>()
            {
                Entities = _mapper.Map<List<ProductDto>>(products),
                EntitiesCount = totalProducts
            };
        }
    }
}
