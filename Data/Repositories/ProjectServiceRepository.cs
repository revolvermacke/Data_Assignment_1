using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class ProjectServiceRepository(DataContext context) : BaseRepository<ProjectServiceEntity>(context), IProjectServiceRepository
{
    public async Task<bool> AddRangeAsync(List<ProjectServiceEntity> entities)
    {
		try
		{
			await _context.ProjectServices.AddRangeAsync(entities);
			return true;

		}
		catch (Exception)
		{

			return false;
		}

    }
}