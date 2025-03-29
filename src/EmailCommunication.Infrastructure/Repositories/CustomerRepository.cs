using Dapper;
using EmailCommunication.Domain.Entities;
using EmailCommunication.Domain.Enum;
using EmailCommunication.Domain.Repositories;
using EmailCommunication.Infrastructure.DataContext;

namespace EmailCommunication.Infrastructure.Repositories;

public class CustomerRepository(IDbContext context) : ICustomerRepository
{
    private readonly IDbContext _context = context;

    public async Task<IEnumerable<Customer>> GetCustomersBirthdayTodayAsync()
    {
        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<Customer>(
            sql: $@"SELECT FirstName
                        , LastName
                        , Email
                        , BirthDate
                    FROM dbo.Customers
                    WHERE Status = {Status.Active:d} 
                      AND MONTH(BirthDate) = MONTH(GETDATE()) AND DAY(BirthDate) = DAY(GETDATE())"
        );
    }

    public async Task<IEnumerable<Customer>> GetCustomersWithIncompleteRegistrationAsync()
    {
        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<Customer>(
            sql: $@"SELECT FirstName
                        , LastName
                        , Email
                    FROM dbo.Customers
                    WHERE Status = {Status.Pending:d}"
        );
    }
}
