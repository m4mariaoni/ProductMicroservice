using Npgsql;
using ProductMicroservice.Data.Interface;
using System.Data;
using System.Data.SqlClient;

namespace ProductMicroservice.Data.Services
{
    public class DefaultDatabaseConnectionProvider : IDatabaseConnnectionProvider
    {
        private readonly IConnectionStringProvider _connectionStringProvider;
        public DefaultDatabaseConnectionProvider(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }

        public IDbConnection GetDbConnection()
        {
            return new NpgsqlConnection(_connectionStringProvider.GetConnectionString());
        }
    }
}
