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
            // Default values for different statuses.
            modelBuilder.Entity<StatusEntity>().HasData(
                new StatusEntity { Id = 1, StatusType = "Ej påbörjad" },
                new StatusEntity { Id = 2, StatusType = "Pågående" },
                new StatusEntity { Id = 3, StatusType = "Avslutad" }
                );

            modelBuilder.Entity<EmployeeEntity>()
                .HasOne(x => x.Role)
                .WithMany(x => x.Emplyoees)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ServiceEntity>()
                .HasOne(x => x.Unit)
                .WithMany(x => x.Services)
                .HasForeignKey(x => x.UnitId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectEntity>()
                .HasOne(x => x.Customer)
                .WithMany(x => x.Projects)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectEntity>()
                .HasOne(x => x.Employee)
                .WithMany(x => x.Projects)
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectEntity>()
                .HasOne(x => x.Status)
                .WithMany(x => x.Projects)
                .HasForeignKey(x => x.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectEntity>()
                .HasMany(x => x.Service)
                .WithMany(x => x.Project);

            modelBuilder.Entity<ProjectEntity>()
                .Property(e => e.Id)
                .UseIdentityColumn(100, 1);
        }
    }
}

