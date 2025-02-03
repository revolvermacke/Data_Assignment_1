using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq.Expressions;

namespace Data.Repositories;

public class EmployeeRepository(DataContext context) : BaseRepository<EmployeeEntity>(context), IEmployeeRepository
{

    public override async Task<IEnumerable<EmployeeEntity>> GetAllAsync()
    {
        var entities = await _context.Employees
            .Include(x => x.Role)
            .ToListAsync();

        return entities;
    }

    public override async Task<EmployeeEntity> GetAsync(Expression<Func<EmployeeEntity, bool>> expression)
    {
        var entity = await _context.Employees
            .Include(x => x.Role)
            .FirstOrDefaultAsync(expression);

        return entity ?? null!;
    }
}
