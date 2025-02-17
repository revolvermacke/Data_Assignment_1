using Business.Dtos;
using Data.Entities;

namespace Business.Factories;

public static class ProjectServiceFactory
{
    public static List<ProjectServiceEntity> Create(List<ServiceRegistrationForm> form)
    {
        var projectServices = new List<ProjectServiceEntity>();
      
        foreach (var service in form)
        {
            if (service == null)
                 return [];
            
            var projectService = new ProjectServiceEntity
            {
                ServiceId = service.ServiceId,
                Quantity = service.Quantity,
                TotalPrice = service.Price * service.Quantity
            };
            projectServices.Add(projectService);
        }
        return projectServices;
    }

    public static List<ProjectServiceDto> Create(List<ProjectServiceEntity> projectServiceEntities)
    {
        return projectServiceEntities.Select(x => new ProjectServiceDto
        {
            ServiceId = x.ServiceId,
            Quantity = x.Quantity,
            TotalPrice = x.TotalPrice,
        }).ToList();
    }

    public static List<ProjectServiceEntity> Create(List<ProjectServiceDto> projectServicesDto)
    {
        return projectServicesDto.Select(x => new ProjectServiceEntity
        {
            ServiceId = x.ServiceId,
            Quantity = x.Quantity,
            TotalPrice = x.TotalPrice,

        }).ToList();
    }
}
