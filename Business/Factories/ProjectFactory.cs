using Business.Dtos;
using Business.Models;
using Data.Entities;
using System.Linq;

namespace Business.Factories
{
    public static class ProjectFactory
    {
        public static ProjectEntity Create(ProjectRegistrationForm registrationForm, decimal projectTotalPrice)
        {
            return new ProjectEntity
            {
                Title = registrationForm.Title,
                EndDate = registrationForm.EndDate,
                EmployeeId = registrationForm.EmployeeNameId,
                CustomerId = registrationForm.CustomerNameId,
                StatusId = registrationForm.StatusTypeId,
                ProjectTotalPrice = projectTotalPrice,
               
               
            };
        }

        public static ProjectEntity Create(ProjectRegistrationForm registrationForm, int id)
        {
            return new ProjectEntity
            {
                Id = id,
                Title = registrationForm.Title,
                EndDate = registrationForm.StatusTypeId == 3 ? DateTime.Now : registrationForm.EndDate,
                EmployeeId = registrationForm.EmployeeNameId,
                CustomerId = registrationForm.CustomerNameId,
                StatusId = registrationForm.StatusTypeId,
            };
        }

        public static Project Create(ProjectEntity entity)
        {
            return new Project
            {
                Id = entity.Id,
                Title = entity.Title,
                EndDate = entity.EndDate.ToString(),
                EmployeeName = entity.Employee.FirstName + " " + entity.Employee.LastName,
                CustomerName = entity.Customer.Name,
                StatusType = entity.Status.StatusType,
                ProjectTotalPrice= entity.ProjectTotalPrice,
                Services = entity.ProjectServices.Select(ps => new ServiceModel
                {
                    Id = ps.Services.Id,
                    Name = ps.Services.Name,

                    // Om du vill visa totalpriset i din ServiceModel:
                    Price = ps.TotalPrice,

                    // Om du i stället vill visa ett styckpris:
                    // Price = ps.Quantity == 0 ? 0 : ps.TotalPrice / ps.Quantity,

                    // Enhet – byt ut ".Name" mot det som faktiskt finns i UnitEntity
                    Unit = ps.Services.Unit.Unit,

                    Quantity = ps.Quantity
                }).ToList()
            };
        }
    }
}
