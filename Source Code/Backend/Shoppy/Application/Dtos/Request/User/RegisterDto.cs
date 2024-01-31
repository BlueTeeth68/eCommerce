using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Request.User;

public record RegisterDto
{
    [Required] [StringLength(50)] public string FullName { get; init; } = null!;

    [Required]
    [DataType(DataType.EmailAddress)]
    [StringLength(50)]
    public string Email { get; init; } = null!;

    [Required]
    [StringLength(4)]
    [DataType(DataType.Password)]
    public string Password { get; init; } = null!;
}