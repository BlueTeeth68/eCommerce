using System.ComponentModel.DataAnnotations;
using Domain.Entities.Generics;

namespace Domain.Entities;

public class OrderDetail : BaseEntity
{
    [Range(0, 100)] public int Quantity { get; set; }

    [StringLength(100)]
    public string? Message { get; set; }

    [Range(0, int.MaxValue)] public decimal Price { get; set; }

    public int OrderId { get; set; }

    public virtual Order Order { get; set; } = null!;
}