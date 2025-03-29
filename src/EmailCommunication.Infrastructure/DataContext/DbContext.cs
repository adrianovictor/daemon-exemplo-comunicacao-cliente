using Microsoft.Data.SqlClient;
using System.Data;

namespace EmailCommunication.Infrastructure.DataContext;

public class DbContext(string connectionString) : IDbContext
{
    private readonly string _connectionString = connectionString;

    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
}
