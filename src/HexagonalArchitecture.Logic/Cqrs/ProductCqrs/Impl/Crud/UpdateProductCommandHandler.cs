using AutoMapper;
using HexagonalArchitecture.Domain.Adapters.Data;
using HexagonalArchitecture.Domain.Adapters.UserProvider;
using HexagonalArchitecture.Domain.Repositories;
using HexagonalArchitecture.Logic.Cqrs.ProductCqrs.Definitions.Crud;

namespace HexagonalArchitecture.Logic.Cqrs.ProductCqrs.Impl.Crud
{
    public class UpdateProductCommandHandler : AbstractCommandHandler<UpdateProductCommand, bool>, IUpdateProductCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IDBContext _dbContext;
        private readonly IUserReference _userReference;

        public UpdateProductCommandHandler(IMapper mapper, IDBContext dbContext, IUserReference userReference)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userReference = userReference;
        }

        protected override async Task<bool> HandleAsync(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            // TO-DO: Update vai dar erro por conta das datas
            if (!request.Product.FieldsAreValied())
                throw new ArgumentException();

            var repo = _dbContext.AcquireRepository<IProductRepository>();

            var productToUpdate = await repo.FetchIdAsync(request.ProductId);

            productToUpdate.Name = request.Product.Name;
            productToUpdate.Price = request.Product.Price;

            productToUpdate.UpdatedAt = DateTime.Now;
            productToUpdate.UpdatedBy = _userReference.User.Id;

            var wasUpdated = await repo.UpdateByEntityAsync(productToUpdate, cancellationToken);

            return wasUpdated;
        }
    }
}
