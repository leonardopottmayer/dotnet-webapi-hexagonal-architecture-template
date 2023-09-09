using Dommel;
using HexagonalArchitecture.Domain.Adapters.Data;
using HexagonalArchitecture.Domain.Entities;
using HexagonalArchitecture.Domain.Repositories;

namespace HexagonalArchitecture.Adapter.Data.Repositories.Impl
{
    public class SystemMessageRepository : AbstractStandardRepository<SystemMessage>, ISystemMessageRepository
    {
        private readonly IDBConnection _dBConnection;

        public SystemMessageRepository(IDBConnection dBConnection) : base(dBConnection)
        {
            _dBConnection = dBConnection;
        }

        public async Task<SystemMessage> GetByCode(long code)
        {
            using (var conn = _dBConnection.GetConnection())
            {
                return (await conn.SelectAsync<SystemMessage>(o => o.Code == code)).FirstOrDefault();
            }
        }
    }
}
