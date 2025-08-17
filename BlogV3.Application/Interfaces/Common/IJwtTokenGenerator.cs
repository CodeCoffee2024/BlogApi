using BlogV3.Application.Queries.Auth.Login;
using BlogV3.Domain.Entities;

namespace BlogV3.Application.Interfaces.Common
{
    public interface IJwtTokenGenerator
    {
        #region Public Methods

        LoginResponse GenerateToken(User user);

        Task<LoginResponse> RefreshToken(string refreshToken);

        #endregion Public Methods
    }
}