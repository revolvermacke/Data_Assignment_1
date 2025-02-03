using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class StatusEntity
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    public string StatusType { get; set; } = null!;

    public ICollection<ProjectEntity> Projects { get; set; } = [];
}
