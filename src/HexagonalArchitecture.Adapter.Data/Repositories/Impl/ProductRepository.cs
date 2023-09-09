using AutoMapper;
using HexagonalArchitecture.Domain.Adapters.Data;
using HexagonalArchitecture.Domain.Entities;
using HexagonalArchitecture.Domain.Repositories;

namespace HexagonalArchitecture.Adapter.Data.Repositories.Impl
{
    public class ProductRepository : AbstractStandardRepository<Product>, IProductRepository
    {
        private readonly IMapper _mapper;
        public ProductRepository(IDBConnection dBConnection, IMapper mapper) : base(dBConnection)
        {
            _mapper = mapper;
        }
    }
}
