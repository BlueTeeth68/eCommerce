using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Generics;
using Domain.Enums;

namespace Domain.Entities;

public class Payment : BaseEntity
{
    public int AccountId { get; set; }

    [Column(TypeName = "tinyint")] public PaymentType Type { get; set; } = PaymentType.Momo;

    [StringLength(20)]
    public string Name { get; set; } = null!;

    public bool IsDefault { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}