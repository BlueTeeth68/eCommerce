using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Constant = Application.Configurations.Constant;

namespace Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }
    public virtual DbSet<Admin> Admins { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Address> Addresses { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<Transaction> Transactions { get; set; }
    public virtual DbSet<TransactionType> TransactionTypes { get; set; }
    public virtual DbSet<RatingResource> RatingResources { get; set; }
    public virtual DbSet<Rating> Ratings { get; set; }
    public virtual DbSet<ProductOption> ProductOptions { get; set; }
    public virtual DbSet<ProductImage> ProductImages { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<ProductType> ProductTypes { get; set; }
    public virtual DbSet<Payment> Payments { get; set; }
    public virtual DbSet<PaymentType> PaymentTypes { get; set; }
    public virtual DbSet<OrderDetail> OrderDetails { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<ClothingCategory> ClothingCategories { get; set; }
    public virtual DbSet<Clothing> Clothings { get; set; }
    public virtual DbSet<CartDetail> CartDetails { get; set; }
    public virtual DbSet<Cart> Carts { get; set; }
    public virtual DbSet<BookCategory> BookCategories { get; set; }
    public virtual DbSet<BookCoverType> BookCoverTypes { get; set; }
    public virtual DbSet<Book> Books { get; set; }

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

        modelBuilder.Entity<OrderDetail>()
            .HasOne(od => od.ProductType)
            .WithMany()
            .HasForeignKey(od => od.ProductTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<OrderDetail>()
            .HasOne(od => od.Product)
            .WithMany()
            .HasForeignKey(od => od.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<OrderDetail>()
            .HasOne(od => od.ProductOption)
            .WithMany()
            .HasForeignKey(od => od.ProductOptionId)
            .OnDelete(DeleteBehavior.Restrict);

        //data seeding
        modelBuilder.Entity<Role>().HasData(
            new Role() { Id = 1, Name = Constant.AdminRole },
            new Role() { Id = 2, Name = Constant.UserRole }
        );

        modelBuilder.Entity<ProductType>().HasData(
            new ProductType() { Id = 1, Name = Constant.ProductTypeBook },
            new ProductType() { Id = 2, Name = Constant.ProductTypeClothing }
        );

        modelBuilder.Entity<PaymentType>().HasData(
            new PaymentType() { Id = 1, Name = Constant.PaymentTypeCash },
            new PaymentType() { Id = 2, Name = Constant.PaymentTypeMomo },
            new PaymentType() { Id = 3, Name = Constant.PaymentTypeVnPay }
        );

        modelBuilder.Entity<TransactionType>().HasData(
            new TransactionType() { Id = 1, Name = Constant.TransactionTypeOnlinePayment },
            new TransactionType() { Id = 2, Name = Constant.TransactionTypeRefund }
        );

        modelBuilder.Entity<ClothingCategory>().HasData(
            new ClothingCategory() { Id = 1, Name = Constant.ClothingCategoryTShirt },
            new ClothingCategory() { Id = 2, Name = Constant.ClothingCategoryPant },
            new ClothingCategory() { Id = 3, Name = Constant.ClothingCategorySneaker }
        );

        modelBuilder.Entity<BookCoverType>().HasData(
            new BookCoverType() { Id = 1, Name = Constant.BookCoverTypeHardCover },
            new BookCoverType() { Id = 2, Name = Constant.BookCoverTypePaperback }
        );
    }
}