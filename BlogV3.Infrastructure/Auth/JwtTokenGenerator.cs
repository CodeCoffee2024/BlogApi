using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BlogV3.Application.Dtos;
using BlogV3.Application.Interfaces.Common;
using BlogV3.Application.Queries.Auth.Login;
using BlogV3.Common.Entities;
using BlogV3.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace BlogV3.Infrastructure.Auth
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        #region Fields

        private readonly JwtSettings _settings;

        #endregion Fields

        #region Public Constructors

        public JwtTokenGenerator(JwtSettings settings)
        {
            _settings = settings;
        }

        #endregion Public Constructors

        #region Public Methods

        public LoginResponse GenerateToken(User user)
        {
            LoginDto response = new LoginDto();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };

            claims.AddRange(user.UserRoles.Select(ur =>
                new Claim(ClaimTypes.Role, ur.Role.Name)));

            response.ExpiresAt = DateTime.UtcNow.AddMinutes(_settings.ExpirationMinutes);
            response.RefreshTokenExpiresAt = DateTime.UtcNow.AddMinutes(_settings.ExpirationMinutes * 3);
            response.Email = user.Email;
            response.Token = GenerateJwtToken(claims, response.ExpiresAt);
            response.RefreshToken = GenerateJwtToken(claims, response.RefreshTokenExpiresAt);
            return new LoginResponse(response);
        }

        private string GenerateJwtToken(List<Claim> claims, DateTime expires)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: _settings.Audience,
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        #endregion Public Methods
    }
}