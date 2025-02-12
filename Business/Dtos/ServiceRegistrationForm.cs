namespace Business.Dtos;

public class ServiceRegistrationForm
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string Unit { get; set; } = null!;
    public int Quantity { get; set; }
}
