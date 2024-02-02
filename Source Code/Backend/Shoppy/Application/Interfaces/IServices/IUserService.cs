using Application.Dtos.Request.User;
using Application.Dtos.Response.User;

namespace Application.Interfaces.IServices;

public interface IUserService
{
    Task<LoginUserDto> RegisterAsync(RegisterDto dto);

    Task<LoginUserDto> LoginAsync(LoginDto request);
}