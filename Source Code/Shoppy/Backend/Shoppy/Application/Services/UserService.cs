using Application.Configurations;
using Application.Dtos.Request.User;
using Application.Dtos.Response.User;
using Application.ErrorHandlers;
using Application.Interfaces.IServices;
using Application.Mappers;
using Domain.Entities;
using Domain.Enums;
using Microsoft.Extensions.Logging;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<UserService> _logger;
    private readonly IAuthenticationService _authenticationService;

    public UserService(IUnitOfWork unitOfWork, ILogger<UserService> logger,
        IAuthenticationService authenticationService)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _authenticationService = authenticationService;
    }

    public async Task<LoginUserDto> RegisterAsync(RegisterDto dto)
    {
        var isAccountExist = await _unitOfWork.AccountRepository.GetAsync(
            filter: ac => ac.Email == dto.Email,
            orderBy: null,
            includeProperties: null,
            disableTracking: false
        ).ContinueWith(t => t.Result.Any());

        if (isAccountExist)
        {
            throw new ConflictException($"Email {dto.Email} has already existed.");
        }

        var role = await _unitOfWork.RoleRepository.GetAsync(
            filter: r => r.Name == Constant.UserRole,
            orderBy: null,
            includeProperties: null,
            disableTracking: false
        ).ContinueWith(t => t.Result.FirstOrDefault());

        if (role == null)
        {
            _logger.LogError("Role {} does not exist.", Constant.UserRole);
            throw new Exception("Error when get user role.");
        }

        var account = new Account()
        {
            Email = dto.Email,
            FullName = dto.FullName,
            PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(dto.Password),
            RoleId = role.Id
        };

        var cart = new Cart()
        {
            Quantity = 0,
            TotalPrice = 0
        };


        var user = new User()
        {
            Cart = cart,
            Account = account,
        };

        try
        {
            await _unitOfWork.UserRepository.AddAsync(user);
            var addResult = await _unitOfWork.SaveChangeAsync();

            account = user.Account;
            if (addResult > 0)
            {
                var result = AccountMapper.AccountEntityToLoginUserDto(account);
                result.AccessToken = _authenticationService.CreateAccessToken(account);
                result.RefreshToken = _authenticationService.CreateRefreshToken(account);

                return result;
            }

            throw new Exception("Can not create new user");
        }
        catch (Exception e)
        {
            _logger.LogError("Error when created new user. Detail:\n {error}", e.Message);
            throw new Exception("Error when created new user.");
        }
    }

    public async Task<LoginUserDto> LoginAsync(LoginDto request)
    {
        var account = await _unitOfWork.AccountRepository.GetAsync(
            filter: a => a.Email == request.Email && a.Status == UserStatus.Active && a.IsDelete == false,
            orderBy: null,
            includeProperties: $"{nameof(Account.Role)}",
            disableTracking: true
        ).ContinueWith(t => t.Result.FirstOrDefault());

        if (account == null)
            throw new UnauthorizedException("Email does not exist.");

        if (!BCrypt.Net.BCrypt.EnhancedVerify(request.Password, account.PasswordHash))
            throw new UnauthorizedException("Incorrect password.");
        var result = AccountMapper.AccountEntityToLoginUserDto(account);
        result.AccessToken = _authenticationService.CreateAccessToken(account);
        result.RefreshToken = _authenticationService.CreateRefreshToken(account);
        return result;
    }
}