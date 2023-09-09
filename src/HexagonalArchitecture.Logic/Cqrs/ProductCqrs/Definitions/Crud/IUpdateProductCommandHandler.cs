using HexagonalArchitecture.Domain.Logic.Cqrs.Interfaces;
using HexagonalArchitecture.Domain.Models.ProductModels;

namespace HexagonalArchitecture.Logic.Cqrs.ProductCqrs.Definitions.Crud
{
    public class UpdateProductCommand : ICommand<bool>
    {
        public UpdateProductDto Product { get; set; }
        public long ProductId { get; set; }
    }

    public interface IUpdateProductCommandHandler : IDefaultCommandHandler<UpdateProductCommand, bool> { }
}
