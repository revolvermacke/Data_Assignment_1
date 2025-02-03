using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class RoleEntity
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string RoleName { get; set; } = null!;

    public ICollection<EmployeeEntity> Emplyoees { get; set; } = [];
}
