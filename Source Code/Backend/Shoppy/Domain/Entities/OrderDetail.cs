using System.ComponentModel.DataAnnotations;
using Domain.Entities.Generics;

namespace Domain.Entities;

public class OrderDetail : BaseEntity
{
    [Range(0, 100)] public int Quantity { get; set; }

    [StringLength(100)] public string? Message { get; set; }

    [Range(0, int.MaxValue)] public decimal Price { get; set; }

    public int OrderId { get; set; }

    public virtual Order Order { get; set; } = null!;

    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public int ProductTypeId { get; set; }

    public virtual ProductType ProductType { get; set; } = null!;

    public int ProductOptionId { get; set; }

    public virtual ProductOption ProductOption { get; set; } = null!;
}