using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class CustomerEntity
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;


    public ICollection<ProjectEntity> Projects { get; set; } = [];

}
