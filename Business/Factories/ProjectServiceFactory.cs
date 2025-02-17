using Business.Dtos;
using Data.Entities;

namespace Business.Factories;

public static class ProjectServiceFactory
{
    public static ProjectServiceEntity Create(int projectId, List<ServiceRegistrationForm> services )
    {
        return new ProjectServiceEntity
        {
            ProjectId = projectId,
            ServiceId = serviceId,
            Quantity = quantity,
            TotalPrice = price * quantity,
        };
    }

}
