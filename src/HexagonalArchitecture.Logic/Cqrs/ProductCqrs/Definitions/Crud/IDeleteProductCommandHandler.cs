using HexagonalArchitecture.Domain.Logic.Cqrs.Interfaces;

namespace HexagonalArchitecture.Logic.Cqrs.ProductCqrs.Definitions.Crud
{
    public class DeleteProductCommand : ICommand<bool>
    {
        public long Id { get; set; }
    }

    public interface IDeleteProductCommandHandler : IDefaultCommandHandler<DeleteProductCommand, bool> { }
}
