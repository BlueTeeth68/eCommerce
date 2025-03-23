using System.ComponentModel.DataAnnotations;
using Domain.Entities.Generics;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Index(nameof(Order), nameof(ProductId), IsUnique = true)]
public class ProductOption : BaseEntity
{
    [Range(0, int.MaxValue)] public decimal Price { get; set; }

    [Range(0, int.MaxValue)] public decimal SalePrice { get; set; }

    [Range(1, 20)] public int Order { get; set; }

    [StringLength(250)] public string ImageUrl { get; set; } = null!;

    [StringLength(10)] public string? Size { get; set; }

    [StringLength(50)]
    public string? Color { get; set; }

    [StringLength(50)] public string? Version { get; set; }

    [Range(0, int.MaxValue)] public int TotalProduct { get; set; }

    public bool IsOutOfStock { get; set; }

    public bool IsDelete { get; set; }

    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;
}