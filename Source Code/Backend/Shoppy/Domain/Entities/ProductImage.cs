using System.ComponentModel.DataAnnotations;
using Domain.Entities.Generics;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Index(nameof(Order), nameof(ProductId), IsUnique = true)]
public class ProductImage : BaseEntity
{
    public string? Title { get; set; }

    [StringLength(250)] public string Url { get; set; } = null!;

    [Range(1, 50)] public int Order { get; set; }

    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;
}