using HexagonalArchitecture.Domain.Repositories;

namespace HexagonalArchitecture.Domain.Adapters.Data
{
    public interface IDBContext
    {
        T AcquireRepository<T>();
    }
}
