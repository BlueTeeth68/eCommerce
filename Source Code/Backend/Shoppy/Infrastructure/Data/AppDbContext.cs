using System.Reflection.Metadata;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Constant = Application.Configurations.Constant;

namespace Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<Transaction> Transactions { get; set; }
    public virtual DbSet<RatingResource> RatingResources { get; set; }
    public virtual DbSet<Rating> Ratings { get; set; }
    public virtual DbSet<ProductOption> ProductOptions { get; set; }
    public virtual DbSet<ProductImage> ProductImages { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Payment> Payments { get; set; }
    public virtual DbSet<OrderDetail> OrderDetails { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<ClothingCategory> ClothingCategories { get; set; }
    public virtual DbSet<Clothing> Clothings { get; set; }
    public virtual DbSet<CartDetail> CartDetails { get; set; }
    public virtual DbSet<Cart> Carts { get; set; }
    public virtual DbSet<BookCategory> BookCategories { get; set; }
    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<Address> Addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CartDetail>()
            .HasOne(cd => cd.ProductOption)
            .WithMany()
            .HasForeignKey(cd => cd.ProductOptionId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CartDetail>()
            .HasOne(cd => cd.Product)
            .WithMany()
            .HasForeignKey(cd => cd.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Rating>()
            .HasOne(r => r.Product)
            .WithMany()
            .HasForeignKey(r => r.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Rating>()
            .HasOne(r => r.ProductOption)
            .WithMany()
            .HasForeignKey(r => r.ProductOptionId)
            .OnDelete(DeleteBehavior.Restrict);

        //data seeding
        modelBuilder.Entity<Role>().HasData(
            new Role() { Id = 1, Name = Constant.AdminRole },
            new Role() { Id = 2, Name = Constant.UserRole }
        );
    }
}