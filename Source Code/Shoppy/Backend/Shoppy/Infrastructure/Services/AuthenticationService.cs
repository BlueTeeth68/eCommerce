using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application;
using Application.Configurations;
using Application.ErrorHandlers;
using Application.Interfaces.IServices;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly AppConfiguration _appConfiguration;
    private readonly IServiceProvider _serviceProvider;

    private readonly ILogger<AuthenticationService> _logger;

    private readonly IUnitOfWork _unit;
    private  TokenValidationParameters _tokenValidation;
    private  JwtSecurityTokenHandler _jwtSecurity;

    public AuthenticationService(AppConfiguration appConfiguration, 
        IServiceProvider serviceProvider, ILogger<AuthenticationService> logger,
        IUnitOfWork unit, TokenValidationParameters tokenValidation, JwtSecurityTokenHandler jwtSecurity)
    {
        _appConfiguration = appConfiguration;
        _serviceProvider = serviceProvider;
        _logger = logger;
        _unit = unit;
        _tokenValidation = tokenValidation;
        _jwtSecurity = jwtSecurity;
    }

    public string CreateAccessToken(Account account)
    {
        try
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appConfiguration.Key));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                new Claim(ClaimTypes.Role, account.Role.Name ?? throw new Exception("Role is empty"))
            };
            var token = new JwtSecurityToken(
                issuer: _appConfiguration.Issuer,
                audience: _appConfiguration.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        catch (Exception e)
        {
            _logger.LogError("Error at CreateAccessToken: {}", e.Message);
            throw;
        }
    }

    public string CreateRefreshToken(Account account)
    {
        try
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appConfiguration.Key));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, account.Id.ToString())
            };
            var token = new JwtSecurityToken(
                issuer: _appConfiguration.Issuer,
                audience: _appConfiguration.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(30),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        catch (Exception e)
        {
            _logger.LogError("Error at CreateRefreshToken: {}", e.Message);
            throw;
        }
    }

    public int GetCurrentUserId()
    {
        var httpContextAccessor = _serviceProvider.GetService<IHttpContextAccessor>();

        if (httpContextAccessor != null)
        {
            if (httpContextAccessor.HttpContext?.User.Identity is ClaimsIdentity claimsIdentity &&
                claimsIdentity.Claims.Any() &&
                int.TryParse(claimsIdentity.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value,
                    out var userId))
            {
                return userId;
            }
        }

        throw new NotFoundException();
    }

    public void GetCurrentUserInformation(out int userId, out string role)
    {
        var httpContextAccessor = _serviceProvider.GetService<IHttpContextAccessor>();

        if (httpContextAccessor != null)
        {
            if (httpContextAccessor.HttpContext?.User.Identity is ClaimsIdentity claimsIdentity &&
                claimsIdentity.Claims.Any())
            {
                // Retrieve the user ID claim
                var userIdClaim = claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out userId))
                {
                    throw new Exception("User ID claim not found or invalid.");
                }

                // Retrieve the role claim
                var roleClaim = claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

                if (roleClaim == null)
                {
                    throw new Exception("Role claim not found.");
                }

                role = roleClaim.Value;

                return;
            }
        }

        throw new NotFoundException();
    }
    
}