using HexagonalArchitecture.Domain.Adapters.Data;
using MySqlConnector;
using System.Data;

namespace HexagonalArchitecture.Adapter.Data
{
    public class DBConnection : IDBConnection
    {
        private readonly MySqlConnection connection;

        public DBConnection(MySqlConnection connection)
        {
            this.connection = connection;
        }

        public IDbConnection GetConnection()
        {
            return connection;
        }

        public void Dispose()
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
            connection.Dispose();
        }
    }
}
