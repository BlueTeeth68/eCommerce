using System.ComponentModel.DataAnnotations;
using Domain.Entities.Generics;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public class Book : BaseEntity
{
    // [Range(0, int.MaxValue)] public decimal Price { get; set; }

    // public decimal? SalePrice { get; set; }

    [StringLength(30)] public string? Language { get; set; }

    [StringLength(100)] public string? Author { get; set; }

    public BookCoverType? CoverType { get; set; }

    [StringLength(100)] public string? Translator { get; set; }

    [StringLength(100)] public string? Publisher { get; set; }

    [StringLength(20)] public string? Size { get; set; }

    [DataType(DataType.DateTime)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
    [Precision(2)]
    public DateTime? DateOfPublish { get; set; }

    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<BookCategory> Categories { get; set; } = new List<BookCategory>();
}