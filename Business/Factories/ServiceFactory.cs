using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class ServiceFactory
{
    public static ServiceEntity CreateEntity(ServiceRegistrationForm form, int unitId) => new()
    {
        Name = form.Name,
        Price = form.Price,
        UnitId = unitId,
    };

    public static ServiceModel Create(ServiceEntity entity) => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        Price = entity.Price,
        Unit = entity.Unit.Quantity,
    };
}
