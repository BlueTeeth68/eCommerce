using Domain.Entities;

namespace Application.Interfaces.IServices;

public interface IAuthenticationService
{
    string CreateAccessToken(Account user);

    string CreateRefreshToken(Account user);

    int GetCurrentUserId();

    void GetCurrentUserInformation(out int userId, out string role);
}