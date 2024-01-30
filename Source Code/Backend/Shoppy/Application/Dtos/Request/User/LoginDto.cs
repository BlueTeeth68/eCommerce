using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Request.User;

public record LoginDto
{
    [Required]
    [DataType(DataType.Date)]
    [StringLength(50)]
    public string Gmail { get; init; } = null!;

    [Required]
    [StringLength(4)]
    [DataType(DataType.Password)]
    public string Password { get; init; } = null!;
};