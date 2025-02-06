namespace Business.Models;

public class Project
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string EndDate { get; set; } = null!;
    public string EmployeeName { get; set; } = null!;
    public string CustomerName { get; set; } = null!;
    public string ServiceName { get; set; } = null!;
    public string StatusType { get; set; } = null!;
    public ICollection<ServiceModel> Services { get; set; } = [];
}
