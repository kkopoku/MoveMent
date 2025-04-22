namespace MoveMent.API.Models;


public class Product 
{

    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required float Price { get; set; }

    public OrderItem? OrderItem { get; set; }


}