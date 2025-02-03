using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class UnitEntity
{
    [Key]
    public int Id { get; set; }
    [StringLength(10)]
    public int Quantity { get; set; }

    public int ServiceId { get; set; }
    public ICollection<ServiceEntity> Services { get; set; } = [];
}
