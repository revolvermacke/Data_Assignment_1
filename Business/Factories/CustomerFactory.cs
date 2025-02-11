using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class CustomerFactory
{
    public static CustomerEntity CreateEntity(CustomerRegistrationForm registrationForm) => new()
    {
        Name = registrationForm.CustomerName
    };

    public static CustomerEntity CreateEntity(CustomerRegistrationForm registrationForm, int id) => new()
    {
        Id = id,
        Name = registrationForm.CustomerName,
    };

    public static Customer CreateModel(CustomerEntity entity) => new()
    {
        Id = entity.Id,
        CustomerName = entity.Name
    };
}
