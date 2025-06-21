using BlogV3.Application.Dtos;

namespace BlogV3.Application.Queries.Auth.Login
{
    public sealed class LoginResponse : LoginDto
    {
        #region Public Constructors

        public LoginResponse(LoginDto login) : base()
        {
            Token = login.Token;
            Email = login.Email;
            RefreshToken = login.RefreshToken;
            ExpiresAt = login.ExpiresAt;
            RefreshTokenExpiresAt = login.RefreshTokenExpiresAt;
        }

        #endregion Public Constructors
    }
}