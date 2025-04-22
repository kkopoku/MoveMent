using Microsoft.EntityFrameworkCore;
using MoveMent.API.Models;

namespace MoveMent.API.Configurations;


public class MoveMentDbContext(DbContextOptions<MoveMentDbContext> options) : DbContext(options)
{
    public DbSet<Staff> Staffs { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Consumer> Consumers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Product)
            .WithOne(p => p.OrderItem)
            .HasForeignKey<OrderItem>(oi => oi.ProductId);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Consumer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.ConsumerId);


        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Order )
            .WithMany( o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId);

        base.OnModelCreating(modelBuilder);
    }

}

