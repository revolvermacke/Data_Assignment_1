using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<CustomerEntity> Customers { get; set; } = null!;
        public DbSet<StatusEntity> Statuses { get; set; } = null!;
        public DbSet<RoleEntity> Roles { get; set; } = null!;
        public DbSet<EmployeeEntity> Employees { get; set; } = null!;
        public DbSet<ServiceEntity> Services { get; set; } = null!;
        public DbSet<ProjectEntity> Projects { get; set; } = null!;
        public DbSet<UnitEntity> Units { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectEntity>()
                .HasMany(p => p.Service)
                .WithMany(s => s.Project);
        }
    }
}
