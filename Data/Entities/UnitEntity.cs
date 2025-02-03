using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class UnitEntity
{
    [Key]
    public int Id { get; set; }
    [StringLength(10)]
    public string Quantity { get; set; } = null!;

    public ICollection<ServiceEntity> Services { get; set; } = [];
}
