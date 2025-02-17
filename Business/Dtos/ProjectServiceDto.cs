using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos
{
    public class ProjectServiceDto
    {
        public int ProjectId { get; set; }
        public int ServiceId {  get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
