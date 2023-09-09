using HexagonalArchitecture.Domain.Adapters.Rest;
using HexagonalArchitecture.Domain.Logic.Cqrs.Interfaces;
using HexagonalArchitecture.Domain.Models.ProductModels;

namespace HexagonalArchitecture.Logic.Cqrs.ProductCqrs.Definitions.Crud
{
    public class GetAllProductsPagedCommand : ICommand<FetchPageResult<ProductDto>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }

    public interface IGetAllProductsPagedCommandHandler : IDefaultCommandHandler<GetAllProductsPagedCommand, FetchPageResult<ProductDto>> { }
}
