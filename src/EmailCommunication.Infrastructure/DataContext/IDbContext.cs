using System.Data;

namespace EmailCommunication.Infrastructure.DataContext;

public interface IDbContext
{
    IDbConnection CreateConnection();
}
