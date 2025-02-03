using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ProjectFactory
{
    public static ProjectEntity Create(ProjectRegistrationForm registrationForm, int emplyoeeId, int customerId, int serviceId, int statusId) => new()
    {
        Title = registrationForm.Title,
        EndDate = registrationForm.EndDate,

        EmployeeId = emplyoeeId,
        CustomerId = customerId,
        ServiceId = serviceId,
        StatusId = statusId

    };

    public static Project Create(ProjectEntity entity) => new()
    {
        Title = entity.Title,
        EndDate = entity.EndDate.ToString(),
        EmployeeName = entity.Employee.FirstName,
        CustomerName = entity.Customer.Name,
        ServiceName = entity.Service,
        StatusType = entity.Status.StatusType
    };
}
