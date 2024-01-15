using System.ComponentModel.DataAnnotations;
using Domain.Entities.Generics;

namespace Domain.Entities;

public class Address : BaseEntity
{
    [StringLength(20)]
    public string PhoneNumber { get; set; } = null!;
    [StringLength(250)]
    public string Detail { get; set; } = null!;
    public bool IsDefault { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}