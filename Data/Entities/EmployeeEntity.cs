using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class EmployeeEntity
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    public int RoleId { get; set; }
    public RoleEntity Role { get; set; } = null!;

    public ICollection<ProjectEntity> Projects { get; set; } = [];
}
