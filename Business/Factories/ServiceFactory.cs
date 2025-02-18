using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ServiceFactory
{

    public static ServiceEntity CreateEntity(ServiceDto form)
    {
        return new ServiceEntity
        {
            Name = form.ServiceName,
            Price = form.Price,
        };
    }

    public static ServiceModel Create(ServiceEntity entity)
    {
        
        return new ServiceModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Unit = entity.Unit.Unit,
            Price = entity.Price
        };
    }

}
