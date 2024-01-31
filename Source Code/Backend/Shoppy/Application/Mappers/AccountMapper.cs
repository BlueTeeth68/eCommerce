using Application.Dtos.Response.User;
using Domain.Entities;

namespace Application.Mappers;

public static class AccountMapper
{
    public static LoginUserDto AccountEntityToLoginUserDto(Account entity) => new LoginUserDto()
    {
        Id = entity.Id,
        Email = entity.Email,
        PictureUrl = entity.PictureUrl,
        Role = entity.Role?.Name ?? "Undefined"
    };
}