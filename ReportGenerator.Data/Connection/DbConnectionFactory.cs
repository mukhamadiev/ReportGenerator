using System.Data;
using Microsoft.Data.SqlClient;

namespace ReportGenerator.Data.Connection
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IConnectionStringProvider _connectionStringProvider;

        public DbConnectionFactory(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }

        public IDbConnection Create()
        {
            return new SqlConnection(_connectionStringProvider.GetConnectionString());
        }
    }
}