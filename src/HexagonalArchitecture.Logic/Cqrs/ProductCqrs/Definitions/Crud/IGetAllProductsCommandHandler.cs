using HexagonalArchitecture.Domain.Logic.Cqrs.Interfaces;
using HexagonalArchitecture.Domain.Models.ProductModels;

namespace HexagonalArchitecture.Logic.Cqrs.ProductCqrs.Definitions.Crud
{
    public class GetAllProductsCommand : ICommand<IEnumerable<ProductDto>>
    {
    }

    public interface IGetAllProductsCommandHandler : IDefaultCommandHandler<GetAllProductsCommand, IEnumerable<ProductDto>> { }
}
