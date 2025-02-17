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
    public int EmployeeNameId { get; set; }
    public int CustomerNameId { get; set; }
    public int StatusTypeId { get; set; }

    public List<ServiceRegistrationForm> Services { get; set; } = [];
}
