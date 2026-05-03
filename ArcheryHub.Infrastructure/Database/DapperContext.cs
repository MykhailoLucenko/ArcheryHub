using System.Data;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace ArcheryHub.Infrastructure.Database;

public class DapperContext
{
    private readonly string _connection;

    public DapperContext(IConfiguration configuration)
    {
        _connection = configuration.GetConnectionString("DefaultConnection");
    }

    public IDbConnection CreateConnection()
    {
        return new MySqlConnection(_connection);
    }
    
}