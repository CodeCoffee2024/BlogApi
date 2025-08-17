using BlogV3.Application.Dtos;
using BlogV3.Application.Interfaces.Common;
using BlogV3.Application.Queries.Auth.Login;
using BlogV3.Common.Entities;
using BlogV3.Domain.Entities;
using BlogV3.Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogV3.Infrastructure.Auth
{
    public class JwtTokenGenerator(JwtSettings _settings, IUserRepository _userRepository) : IJwtTokenGenerator
    {
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

        public async Task<LoginResponse> RefreshToken(string refreshToken)
        {
            var principal = GetPrincipalFromExpiredToken(refreshToken);
            if (principal == null)
            {
                return null!;
            }

            var identity = principal.Identity as ClaimsIdentity;
            var userId = identity!.Claims.First(it => it.Type == ClaimTypes.NameIdentifier).Value;

            if (string.IsNullOrEmpty(userId))
            {
                return null!;
                throw new SecurityTokenException("Invalid refresh token");
            }

            var user = await _userRepository.GetByIdAsync(Guid.Parse(userId));

            if (user == null)
            {
                return null!;
            }

            return GenerateToken(user);
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

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false, // Disabled to allow expired tokens
                ValidateAudience = false, // Disabled for refresh token validation
                ValidateLifetime = false, // Allow expired tokens
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key))
            };

            try
            {
                var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken securityToken);
                var jwtToken = securityToken as JwtSecurityToken;

                if (jwtToken == null)
                {
                    Console.WriteLine("Invalid JWT token.");
                    return null;
                }

                Console.WriteLine($"Principal Created: {principal.Identity?.Name}");
                return principal;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Token validation failed: {ex.Message}");
                return null;
            }
        }

        #endregion Public Methods
    }
}