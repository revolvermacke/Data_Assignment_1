using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class ServiceRegistrationForm
{
    public int ServiceId { get; set; }
    public int Quantity { get; set; }

    public decimal Price { get; set; }


}

public class ServiceDto
{
    public string ServiceName { get; set; } = null!;
    public int ServiceId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

}
