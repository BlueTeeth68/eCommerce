using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Generics;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Index(nameof(FacebookId), IsUnique = true)]
[Index(nameof(PhoneNumber), IsUnique = true)]
public class User : BaseEntity
{
    [StringLength(100)] public string? FacebookId { get; set; }

    [StringLength(20)] public string? PhoneNumber { get; set; }

    [Column(TypeName = "tinyint")] public Gender? Gender { get; set; }

    public int CartId { get; set; }

    public virtual Cart Cart { get; set; } = null!;

    public int AccountId { get; set; }

    public virtual Account Account { get; set; } = null!;


    public virtual ICollection<Address>? Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Payment>? Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}