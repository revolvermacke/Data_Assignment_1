using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos;

public class ProjectRegistrationForm
{
    public string Title { get; set; } = null!;
    public DateTime EndDate { get; set; }
    public string EmployeeName { get; set; } = null!;
    public string CustomerName { get; set; } = null!;
    public string Servicename { get; set; } = null!;
    public string StatusType { get; set; } = null!;
}
