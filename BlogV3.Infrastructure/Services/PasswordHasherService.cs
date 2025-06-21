using BlogV3.Application.Interfaces.Common;
using Microsoft.AspNetCore.Identity;

namespace BlogV3.Infrastructure.Services
{
    public class PasswordHasherService(PasswordHasher<object> _passwordHasher) : IPasswordHasherService
    {
        #region Public Methods

        public string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(null, password);
        }

        public bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success;
        }

        #endregion Public Methods
    }
}