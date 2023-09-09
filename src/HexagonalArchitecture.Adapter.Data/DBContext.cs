using HexagonalArchitecture.Domain;
using HexagonalArchitecture.Domain.Adapters.Data;

namespace HexagonalArchitecture.Adapter.Data
{
    public class DBContext : IDBContext
    {
        private readonly IContainerService _containerService;
        public DBContext(IContainerService containerService)
        {
            _containerService = containerService;
        }

        public T AcquireRepository<T>()
        {
            return _containerService.Resolve<T>();
        }
    }
}
