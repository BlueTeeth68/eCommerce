using System.ComponentModel.DataAnnotations;
using Domain.Entities.Generics;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public class Book : BaseEntity
{
    [StringLength(30)] public string? Language { get; set; }

    [StringLength(100)] public string? Author { get; set; }

    [StringLength(100)] public string? Translator { get; set; }

    [StringLength(100)] public string? Publisher { get; set; }

    [StringLength(20)] public string? Size { get; set; }

    [DataType(DataType.DateTime)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
    [Precision(2)]
    public DateTime? DateOfPublish { get; set; }

    public int? CoverTypeId { get; set; }

    public BookCoverType? CoverType { get; set; }

    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<BookCategory>? Categories { get; set; }
}