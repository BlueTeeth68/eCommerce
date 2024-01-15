using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Generics;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Index(nameof(Email), IsUnique = true)]
[Index(nameof(FacebookId), IsUnique = true)]
[Index(nameof(PhoneNumber), IsUnique = true)]
public class User : BaseEntity
{
    [StringLength(50)] public string FullName { get; set; } = null!;

    [DataType(DataType.EmailAddress)] public string Email { get; set; } = null!;

    public string? FacebookId { get; set; }

    public string? PhoneNumber { get; set; }

    [Column(TypeName = "tinyint")] public Gender? Gender { get; set; }

    [Column(TypeName = "tinyint")] public UserStatus Status { get; set; } = UserStatus.Active;

    [StringLength(250)] public string PasswordHash { get; set; } = null!;

    public bool IsDelete { get; set; }

    [DataType(DataType.DateTime)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
    [Precision(2)]
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;

    public int CartId { get; set; }

    public virtual Cart Cart { get; set; } = null!;

    public virtual ICollection<Address>? Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Payment>? Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}