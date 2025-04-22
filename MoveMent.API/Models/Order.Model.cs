namespace MoveMent.API.Models;


public class Order 
{

    public Guid Id { get; set; } = Guid.NewGuid();
    public float TotalAmount { get; set; }

    public Guid ConsumerId { get; set; }
    public Consumer Consumer { get; set; } = default!;

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

}