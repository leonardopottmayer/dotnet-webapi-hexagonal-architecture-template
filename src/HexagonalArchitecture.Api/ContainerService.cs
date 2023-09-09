using Autofac;
using HexagonalArchitecture.Domain;

namespace HexagonalArchitecture.Api
{
    public class ContainerService : IContainerService
    {
        private readonly ILifetimeScope _lifetimeScope;

        public ContainerService(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public T Resolve<T>()
        {
            return _lifetimeScope.Resolve<T>();
        }
    }
}