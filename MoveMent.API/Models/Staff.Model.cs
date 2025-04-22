namespace MoveMent.API.Models;


public class Staff
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Role { get; set; }
    }
