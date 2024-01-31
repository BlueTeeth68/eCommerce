using Application.Dtos.Request.User;
using Application.Dtos.Response.User;
using Application.Interfaces.IServices;
using Microsoft.Extensions.Logging;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<UserService> _logger;

    public UserService(IUnitOfWork unitOfWork, ILogger<UserService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public LoginUserDto RegisterAsync(RegisterDto dto)
    {
        
        
        throw new NotImplementedException();
    }
}