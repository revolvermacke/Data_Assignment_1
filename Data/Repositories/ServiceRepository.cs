using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories;

public class ServiceRepository(DataContext context) : BaseRepository<ServiceEntity>(context), IServiceRepository
{
    private readonly DataContext _context = context;

    public override async Task<IEnumerable<ServiceEntity>> GetAllAsync()
    {
        var entities = await _context.Services
            .Include(x => x.Unit)
            .ToListAsync();

        return entities;
    }

    public override async Task<ServiceEntity?> GetAsync(Expression<Func<ServiceEntity, bool>> expression)
    {
        var entity = await _context.Services
            .Include(x => x.Unit)
            .FirstOrDefaultAsync(expression);

        return entity;
    }
}
