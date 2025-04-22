namespace MoveMent.API.Models;


public class Consumer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
