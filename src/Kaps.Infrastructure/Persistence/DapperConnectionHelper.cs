using System.Data;
using Kaps.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Kaps.Infrastructure.Persistence
{
    public class DapperConnectionHelper
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperConnectionHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlServer");
        }
        public IDbConnection CreateSqlConnection() => new SqlConnection(_connectionString);
        
       
    }
}
