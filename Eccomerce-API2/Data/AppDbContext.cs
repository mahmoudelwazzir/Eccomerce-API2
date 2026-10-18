using Eccomerce_API2.Models;
using Microsoft.EntityFrameworkCore;

namespace Eccomerce_API2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasIndex(u => u.Name).IsUnique();
            modelBuilder.Entity<ApplicationUser>().HasIndex(u => u.Email).IsUnique();

            modelBuilder.Entity<Product>()
                .HasOne(c => c.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Order>()
                .HasOne(c => c.Customer)
                .WithMany(o => o.Orders)
                .HasForeignKey(cu => cu.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<OrderItem>()
                .HasOne(o => o.Order)
                .WithMany(oi => oi.OrderItems)
                .HasForeignKey(or => or.OrderId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<OrderItem>()
                .HasOne(p => p.Product)
                .WithMany(oi => oi.OrderItems)
                .HasForeignKey(pr => pr.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            /* Data Seed */

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser { Id = 1, FullName = "Ahmed Hassan", Email = "ahmed@example.com", PasswordHash = "123456A", Role = UseRole.Customer },
                new ApplicationUser { Id = 2, FullName = "Mona Ali", Email = "mona@example.com", PasswordHash = "123456M", Role = UseRole.Customer },
                new ApplicationUser { Id = 3, FullName = "Store Admin", Email = "admin@example.com", PasswordHash = "123456Adm", Role = UseRole.Admin }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics", Description = "Electronic devices and gadgets" },
                new Category { Id = 2, Name = "Accessories", Description = "Everyday computer accessories" },
                new Category { Id = 3, Name = "Books", Description = "Programming and technical books" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Description = "High-performance laptop", Price = 1200.00m, StockQuantity = 10, CategoryId = 1 },
                new Product { Id = 2, Name = "Smartphone", Description = "Latest smartphone model", Price = 800.00m, StockQuantity = 20, CategoryId = 1 },
                new Product { Id = 3, Name = "Headphones", Description = "Noise-cancelling headphones", Price = 150.00m, StockQuantity = 15, CategoryId = 2 },
                new Product { Id = 4, Name = "Keyboard", Description = "Mechanical keyboard", Price = 100.00m, StockQuantity = 25, CategoryId = 2 },
                new Product { Id = 5, Name = "Programming Book", Description = "Learn C# programming", Price = 40.00m, StockQuantity = 30, CategoryId = 3 }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, OrderDate = new DateTime(2026, 10, 1), Status = OrderStatus.Completed, TotalAmount = 1500.00m, CustomerId = 1 },
                new Order { Id = 2, OrderDate = new DateTime(2026, 10, 10), Status = OrderStatus.Pending, TotalAmount = 800.00m, CustomerId = 2 },
                new Order { Id = 3, OrderDate = new DateTime(2026, 10, 12), Status = OrderStatus.Cancelled, TotalAmount = 220.00m, CustomerId = 1 }
            );

            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { Id = 1, OrderId = 1, ProductId = 1, Quantity = 1, UnitPrice = 1200.00m },
                new OrderItem { Id = 2, OrderId = 1, ProductId = 3, Quantity = 2, UnitPrice = 150.00m },
                new OrderItem { Id = 3, OrderId = 2, ProductId = 2, Quantity = 1, UnitPrice = 800.00m },
                new OrderItem { Id = 4, OrderId = 3, ProductId = 4, Quantity = 1, UnitPrice = 100.00m },
                new OrderItem { Id = 5, OrderId = 3, ProductId = 5, Quantity = 3, UnitPrice = 40.00m }
            );
        }
    }
}
