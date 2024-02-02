namespace Application.Tests.Services;

public class UserServiceTest
{
    // [Fact]
    // public async Task RegisterAsync_WithNonExistingEmail_ShouldRegisterUser()
    // {
    //     // Arrange
    //     var unitOfWorkMock = new Mock<IUnitOfWork>();
    //     unitOfWorkMock.Setup(u => u.AccountRepository.GetAsync(It.IsAny<Func<Account, bool>>(), null, null, false))
    //         .ReturnsAsync(new Account[0]);
    //
    //     unitOfWorkMock.Setup(u => u.RoleRepository.GetAsync(It.IsAny<Func<Role, bool>>(), null, null, false))
    //         .ReturnsAsync(new Role { Id = 1, Name = Constant.UserRole });
    //
    //     var authServiceMock = new Mock<IAuthenticationService>();
    //     authServiceMock.Setup(a => a.CreateAccessToken(It.IsAny<Account>()))
    //         .Returns("MockedAccessToken");
    //     authServiceMock.Setup(a => a.CreateRefreshToken(It.IsAny<Account>()))
    //         .Returns("MockedRefreshToken");
    //
    //     var yourClass = new YourClass(unitOfWorkMock.Object, authServiceMock.Object);
    //
    //     var registerDto = new RegisterDto
    //     {
    //         Email = "newuser@example.com",
    //         FullName = "New User",
    //         Password = "password123"
    //     };
    //
    //     // Act
    //     var result = await yourClass.RegisterAsync(registerDto);
    //
    //     // Assert
    //     result.Should().NotBeNull();
    //     result.AccessToken.Should().Be("MockedAccessToken");
    //     result.RefreshToken.Should().Be("MockedRefreshToken");
    // }


}