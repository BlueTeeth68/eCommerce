using System.ComponentModel.DataAnnotations;
using Domain.Entities.Generics;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Index(nameof(Order), nameof(RatingId), IsUnique = true)]
public class RatingResource : BaseEntity
{
    [StringLength(250)] public string Url { get; set; } = null!;

    [Range(1, 5)] public int Order { get; set; }

    public int RatingId { get; set; }

    public virtual Rating Rating { get; set; } = null!;
}