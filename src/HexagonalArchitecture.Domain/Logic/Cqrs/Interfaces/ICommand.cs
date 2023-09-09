using MediatR;

namespace HexagonalArchitecture.Domain.Logic.Cqrs.Interfaces
{
    public interface ICommand<TResponse> : IRequest<TResponse>
    {
    }
}
