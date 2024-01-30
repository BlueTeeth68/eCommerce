using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Generics;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Index(nameof(Email), IsUnique = true)]
public class Account : BaseEntity
{
    [StringLength(50)] public string FullName { get; set; } = null!;

    [StringLength(50)]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Column(TypeName = "tinyint")] public UserStatus Status { get; set; } = UserStatus.Active;

    [StringLength(250)] public string PasswordHash { get; set; } = null!;

    [StringLength(250)] public string? PictureUrl { get; set; }

    [DataType(DataType.DateTime)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
    [Precision(2)]
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public bool IsDelete { get; set; }

    public int RoleId { get; set; }

    public Role Role { get; set; } = null!;
}