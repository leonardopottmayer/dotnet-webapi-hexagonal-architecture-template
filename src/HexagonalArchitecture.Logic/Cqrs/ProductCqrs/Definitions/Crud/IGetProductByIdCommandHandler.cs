using HexagonalArchitecture.Domain.Logic.Cqrs.Interfaces;
using HexagonalArchitecture.Domain.Models.ProductModels;

namespace HexagonalArchitecture.Logic.Cqrs.ProductCqrs.Definitions.Crud
{
    public class GetProductByIdCommand : ICommand<ProductDto>
    {
        public long Id { get; set; }
    }

    public interface IGetProductByIdCommandHandler : IDefaultCommandHandler<GetProductByIdCommand, ProductDto> { }
}
