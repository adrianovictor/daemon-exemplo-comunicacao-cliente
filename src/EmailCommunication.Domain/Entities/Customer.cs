using EmailCommunication.Domain.Core;
using EmailCommunication.Domain.Enum;

namespace EmailCommunication.Domain.Entities;

public class Customer : Entity<Customer>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PasswordHas { get; set; }
    public DateTime BirthDate { get; set; }
    public Status Status{ get; set; }

    protected Customer() { }

    public Customer(string firstName, string lastName, string email, string password, DateTime birthDate, Status status)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHas = password;
        BirthDate = birthDate;
        Status = status;
    }
}
