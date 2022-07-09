using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Common.Store
{
    public interface IDbConnectionHolder
    {
        IDbConnection Application { get; }
    }

    public class DbConnectionHolder : IDbConnectionHolder
    {
        private readonly IConfiguration _configuration;
        public DbConnectionHolder(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public IDbConnection Application => new MySqlConnection(_configuration.GetConnectionString("MSN"));
    }
}
