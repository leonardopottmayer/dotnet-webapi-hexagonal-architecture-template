using AutoMapper;
using HexagonalArchitecture.Domain.Adapters.Data;
using HexagonalArchitecture.Domain.Adapters.UserProvider;
using HexagonalArchitecture.Domain.Entities;
using HexagonalArchitecture.Domain.Exceptions;
using HexagonalArchitecture.Domain.Repositories;
using HexagonalArchitecture.Logic.Cqrs.ProductCqrs.Definitions.Crud;

namespace HexagonalArchitecture.Logic.Cqrs.ProductCqrs.Impl.Crud
{
    public class CreateProductCommandHandler : AbstractCommandHandler<CreateProductCommand, long>, ICreateProductCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IDBContext _dbContext;
        private readonly IUserReference _userReference;

        public CreateProductCommandHandler(IMapper mapper, IDBContext dbContext, IUserReference userReference)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userReference = userReference;
        }

        protected override async Task<long> HandleAsync(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (!request.Product.FieldsAreValied())
                throw new BusinessException(2);

            var repo = _dbContext.AcquireRepository<IProductRepository>();

            var productToCreate = _mapper.Map<Product>(request.Product);

            productToCreate.CreatedAt = DateTime.Now;
            productToCreate.CreatedBy = _userReference.User.Id;

            var productId = await repo.CreateAsync(productToCreate, cancellationToken);

            return productId;
        }
    }
}
