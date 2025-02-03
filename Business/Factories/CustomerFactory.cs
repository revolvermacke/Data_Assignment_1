using Business.Dtos;
using Data.Entities;

namespace Business.Factories;

public static class CustomerFactory
{
    public static CustomerEntity Create(CustomerRegistrationForm registrationForm) => new()
    {
        Name = registrationForm.CustomerName
    };
}
