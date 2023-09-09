using HexagonalArchitecture.Domain.Logic.Cqrs.Interfaces;
using HexagonalArchitecture.Domain.Models.ProductModels;

namespace HexagonalArchitecture.Logic.Cqrs.ProductCqrs.Definitions.Crud
{
    public class CreateProductCommand : ICommand<long>
    {
        public CreateProductDto Product { get; set; }
    }

    public interface ICreateProductCommandHandler : IDefaultCommandHandler<CreateProductCommand, long> { }
}
