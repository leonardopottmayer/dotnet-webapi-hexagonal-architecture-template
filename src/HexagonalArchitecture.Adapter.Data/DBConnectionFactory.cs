using HexagonalArchitecture.Domain.Adapters.Data;
using MySqlConnector;
using System.Data;

namespace HexagonalArchitecture.Adapter.Data
{
    public class DBConnectionFactory : IDBConnection
    {
        private readonly string connectionString;
        private IDbConnection connection;

        public DBConnectionFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IDbConnection GetConnection()
        {
            if (connection == null || connection.State != ConnectionState.Open)
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            return connection;
        }

        public void Dispose()
        {
            if (connection != null && connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }
    }
}
