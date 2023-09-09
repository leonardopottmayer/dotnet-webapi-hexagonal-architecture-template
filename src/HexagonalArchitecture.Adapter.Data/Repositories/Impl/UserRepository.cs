using Dapper;
using HexagonalArchitecture.Domain.Adapters.Data;
using HexagonalArchitecture.Domain.Entities;
using HexagonalArchitecture.Domain.Repositories;

namespace HexagonalArchitecture.Adapter.Data.Repositories.Impl
{
    public class UserRepository : AbstractStandardRepository<User>, IUserRepository
    {
        private IDBConnection _dBConnection { get; set; }
        public UserRepository(IDBConnection dBConnection) : base(dBConnection)
        {
            _dBConnection = dBConnection;
        }

        public async Task<User> GetUserByUsername(string username)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@username", username);

            var sql = "SELECT * FROM user t WHERE t.username = @username";

            using (var conn = _dBConnection.GetConnection())
            {
                var result = (await conn.QueryAsync<User>(sql, parameters)).FirstOrDefault();

                return result;
            }
        }
    }
}
