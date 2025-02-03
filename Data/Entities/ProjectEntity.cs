using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ProjectEntity
{
    [Key]
    public int Id { get; set; }


    public string Title { get; set; } = null!;

    [Column(TypeName = "date")]
    public DateTime StartDate { get; set; } = DateTime.Now;

    [Column(TypeName = "date")]
    public DateTime EndDate { get; set; }


    public int EmployeeId { get; set; }
    public EmployeeEntity Employee { get; set; } = null!;

    public int CustomerId { get; set; }
    public CustomerEntity Customer { get; set; } = null!;

    public int ServiceId { get; set; }
    public ICollection<ServiceEntity> Service { get; set; } = [];

    public int StatusId { get; set; }
    public StatusEntity Status { get; set; } = null!;

}
