using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Generics;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public class Product : BaseEntity
{
    [StringLength(500)]
    public string Name { get; set; } = null!;

    [StringLength(5000)] public string? Description { get; set; }

    public int TotalProduct { get; set; }

    public int TotalSaleProduct { get; set; }

    public int OrderPerMonth { get; set; }

    public int TotalRate { get; set; }

    [Precision(2)] public decimal AverageRate { get; set; }

    [Precision(2)] public decimal? SalePrice { get; set; }

    [Precision(2)] public decimal? LowestPrice { get; set; }

    [Precision(2)] public decimal? HighestPrice { get; set; }

    [Column(TypeName = "tinyint")] public ProductStatus Status { get; set; } = ProductStatus.Active;

    public bool IsOutOfStock { get; set; }

    public bool IsDelete { get; set; }

    [DataType(DataType.DateTime)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
    [Precision(2)]
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public int CreatedById { get; set; }

    public virtual Admin CreatedBy { get; set; } = null!;
    
    public int ProductTypeId { get; set; }

    public ProductType ProductType { get; set; } = null!;

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    public virtual ICollection<ProductOption> ProductOptions { get; set; } = new List<ProductOption>();
}