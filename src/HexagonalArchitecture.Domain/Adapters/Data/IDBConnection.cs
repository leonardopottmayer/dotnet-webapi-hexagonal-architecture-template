using System.Data;

namespace HexagonalArchitecture.Domain.Adapters.Data
{
    public interface IDBConnection : IDisposable
    {
        IDbConnection GetConnection();
    }
}
