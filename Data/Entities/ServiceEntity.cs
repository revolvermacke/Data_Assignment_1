using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class ServiceEntity
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    public decimal Price { get; set; }


    public ICollection<ProjectServiceEntity> ProjectServices { get; set; } = [];


    public int UnitId { get; set; }
    public UnitEntity Unit { get; set; } = null!;

}
