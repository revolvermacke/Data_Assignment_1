using Data.Entities;

namespace Data.Interfaces;

public interface IServiceRepository : IBaseRepository<ServiceEntity>
{
    Task<List<ServiceEntity>> GetByIdsAsync(List<int> serviceIds);
}

