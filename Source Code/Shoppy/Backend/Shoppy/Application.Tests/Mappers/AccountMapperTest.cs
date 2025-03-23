using Application.Mappers;
using Domain.Entities;

namespace Application.Tests.Mappers;

public class AccountMapperTest
{
    [Fact]
    public void AccountEntityToLoginUserDtoShouldReturnDtoCase1()
    {
        //Arrange
        var accountEntity = new Account()
        {
            Id = 1,
            Email = "test@example.com",
            PictureUrl = null,
            Role = new Role { Id = 1, Name = "Admin" }
        };
        //Act
        var result = AccountMapper.AccountEntityToLoginUserDto(accountEntity);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(accountEntity.Id, result.Id);
        Assert.Equal(accountEntity.Email, result.Email);
        Assert.Equal(accountEntity.PictureUrl, result.PictureUrl);
        Assert.Equal(accountEntity.Role.Name, result.Role);
    }

    [Fact]
    public void AccountEntityToLoginUserDtoShouldReturnDtoCase2()
    {
        //Arrange
        var accountEntity = new Account()
        {
            Id = 1,
            Email = "test@example.com",
            PictureUrl = null,
            Role = new Role()
        };
        //Act
        var result = AccountMapper.AccountEntityToLoginUserDto(accountEntity);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(accountEntity.Id, result.Id);
        Assert.Equal(accountEntity.Email, result.Email);
        Assert.Equal(accountEntity.PictureUrl, result.PictureUrl);
        Assert.Equal("Undefined", result.Role);
    }
}