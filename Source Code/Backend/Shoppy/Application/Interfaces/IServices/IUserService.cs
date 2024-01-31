using Application.Dtos.Request.User;
using Application.Dtos.Response.User;

namespace Application.Interfaces.IServices;

public interface IUserService
{
    LoginUserDto RegisterAsync(RegisterDto dto);
}