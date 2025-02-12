using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ProjectFactory
{
    public static ProjectEntity Create(ProjectRegistrationForm registrationForm) => new()
    {
        Title = registrationForm.Title,
        EndDate = registrationForm.EndDate,

        EmployeeId = registrationForm.EmployeeNameId,
        CustomerId = registrationForm.CustomerNameId,
        StatusId = registrationForm.StatusTypeId,

    };

    public static ProjectEntity Create(ProjectRegistrationForm registrationForm, int id) => new()
    {
        Id = id,
        Title = registrationForm.Title,
        EndDate = registrationForm.StatusTypeId == 3 ? DateTime.Now : registrationForm.EndDate,

        EmployeeId = registrationForm.EmployeeNameId,
        CustomerId = registrationForm.CustomerNameId,
        StatusId = registrationForm.StatusTypeId,

    };

    public static Project Create(ProjectEntity entity) => new()
    {
        Id = entity.Id,
        Title = entity.Title,
        EndDate = entity.EndDate.ToString(),
        EmployeeName = entity.Employee.FirstName + " " + entity.Employee.LastName,
        CustomerName = entity.Customer.Name,
        StatusType = entity.Status.StatusType,
        
        Services = entity.ProjectServices.Select(x => new ServiceModel
        {
            Id = x.Services.Id,
            Name = x.Services.Name,
            Price = x.Services.Price,
            Unit = x.Services.Unit.Unit,
            Quantity = x.Services.Quantity,
        }).ToList(),
    };
}
