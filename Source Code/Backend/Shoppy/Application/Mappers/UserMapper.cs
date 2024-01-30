using Application.Dtos.Request.User;
using Application.Dtos.Response.User;
using Domain.Entities;

namespace Application.Mappers;

public static class UserMapper
{
    public static LoginUserDto EntityToLoginUserDto(User entity) => new LoginUserDto()
    {
        Id = entity.Id
    };
}