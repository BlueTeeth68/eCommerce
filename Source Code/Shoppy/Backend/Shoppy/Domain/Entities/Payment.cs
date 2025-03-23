using System.ComponentModel.DataAnnotations;
using Domain.Entities.Generics;

namespace Domain.Entities;

public class Payment : BaseEntity
{
    [StringLength(100)] public string? AccountId { get; set; } 

    [StringLength(20)] public string Name { get; set; } = null!;

    public bool IsDefault { get; set; }

    public int TypeId { get; set; }

    public PaymentType Type { get; set; } = null!;

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}