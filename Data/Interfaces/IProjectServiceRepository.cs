using Data.Entities;

namespace Data.Interfaces;

public interface IProjectServiceRepository : IBaseRepository<ProjectServiceEntity>
{
    Task<bool> AddRangeAsync(List<ProjectServiceEntity> entities);
}
