using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Generics;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public class CartDetail : BaseEntity
{
    [Range(1, 1000)] public int Quantity { get; set; }

    [Column(TypeName = "tinyint")] public CartStatus Status { get; set; } = CartStatus.Active;

    [DataType(DataType.DateTime)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
    [Precision(2)]
    public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public int CartId { get; set; }

    public virtual Cart Cart { get; set; } = null!;

    public int ProductOptionId { get; set; }

    public virtual ProductOption ProductOption { get; set; } = null!;

    public int ProductTypeId { get; set; }

    public virtual ProductType ProductType { get; set; } = null!;
}