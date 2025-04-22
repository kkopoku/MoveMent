namespace MoveMent.API.Models;

public class OrderItem
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public int Quantity { get; set; }

    public Guid ProductId { get; set; }
    public required Product Product { get; set; }

    public Guid OrderId { get; set; }
    public Order Order { get; set; } = default!;
}
