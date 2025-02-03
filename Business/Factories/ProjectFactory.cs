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
        StatusId = registrationForm.StatusTypeId

    };

    public static Project Create(ProjectEntity entity) => new()
    {
        Id = entity.Id,
        Title = entity.Title,
        EndDate = entity.EndDate.ToString(),
        EmployeeName = entity.Employee.FirstName + " " + entity.Employee.LastName,
        CustomerName = entity.Customer.Name,
        StatusType = entity.Status.StatusType
    };
}
