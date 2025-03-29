using EmailCommunication.Domain.Entities;

namespace EmailCommunication.Domain.Repositories;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetCustomersWithIncompleteRegistrationAsync();
    Task<IEnumerable<Customer>> GetCustomersBirthdayTodayAsync();
}
