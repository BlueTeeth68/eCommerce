namespace Application.Dtos.Response.User;

public class LoginUserDto
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;
    
    public string? PictureUrl { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string AccessToken { get; set; } = null!;

    public string RefreshToken { get; set; } = null!;
}