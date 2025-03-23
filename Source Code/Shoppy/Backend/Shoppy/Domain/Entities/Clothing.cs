using System.ComponentModel.DataAnnotations;
using Domain.Entities.Generics;
using Domain.Enums;

namespace Domain.Entities;

public class Clothing : BaseEntity
{
    [StringLength(100)] public string? Material { get; set; }

    [StringLength(20)] public string? MadeIn { get; set; }

    [StringLength(50)] public string? Brand { get; set; }

    [StringLength(50)] public string? BrandOrigin { get; set; }

    public ClothingSexType? SexType { get; set; }

    [StringLength(50)] public string? Model { get; set; }

    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public int CategoryId { get; set; }

    public virtual ClothingCategory Category { get; set; } = null!;
}