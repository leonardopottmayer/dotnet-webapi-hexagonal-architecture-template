using Dommel;
using HexagonalArchitecture.Domain.Adapters.Data;
using HexagonalArchitecture.Domain.Entities;
using HexagonalArchitecture.Domain.Repositories;

namespace HexagonalArchitecture.Adapter.Data.Repositories.Impl
{
    public class SystemParameterRepository : AbstractStandardRepository<SystemParameter>, ISystemParameterRepository
    {
        private readonly IDBConnection _dBConnection;
        public SystemParameterRepository(IDBConnection dBConnection) : base(dBConnection)
        {
            _dBConnection = dBConnection;
        }

        public async Task<SystemParameter> GetByCode(long code)
        {
            using (var conn = _dBConnection.GetConnection())
            {
                return (await conn.SelectAsync<SystemParameter>(o => o.Code == code)).FirstOrDefault();
            }
        }
    }
}
