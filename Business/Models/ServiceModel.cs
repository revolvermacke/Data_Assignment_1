﻿namespace Business.Models;

public class ServiceModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string Unit { get; set; } = null!;
    public int Quantity { get; set; }
}