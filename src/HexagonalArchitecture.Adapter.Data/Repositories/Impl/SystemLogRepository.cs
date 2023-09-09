using HexagonalArchitecture.Domain.Adapters.Data;
using HexagonalArchitecture.Domain.Entities;
using HexagonalArchitecture.Domain.Repositories;

namespace HexagonalArchitecture.Adapter.Data.Repositories.Impl
{
    public class SystemLogRepository : AbstractStandardRepository<SystemLog>, ISystemLogRepository
    {
        private readonly IDBConnection _dBConnection;
        public SystemLogRepository(IDBConnection dBConnection) : base(dBConnection)
        {
            _dBConnection = dBConnection;
        }
    }
}
