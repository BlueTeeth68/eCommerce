using System.ComponentModel.DataAnnotations;
using Domain.Entities.Generics;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public class Rating : BaseEntity
{
    [Range(0, 5)] public int Value { get; set; }

    [DataType(DataType.DateTime)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
    [Precision(2)]
    public DateTime Date { get; set; } = DateTime.UtcNow;

    [StringLength(750)] public string? Comment { get; set; }

    [DataType(DataType.DateTime)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
    [Precision(2)]
    public DateTime OrderReceiveDate { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;

    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public int ProductOptionId { get; set; }

    public virtual ProductOption ProductOption { get; set; } = null!;

    public int ProductTypeId { get; set; }

    public virtual ProductType ProductType { get; set; } = null!;

    public virtual ICollection<RatingResource> RatingResources { get; set; } = new List<RatingResource>();
}