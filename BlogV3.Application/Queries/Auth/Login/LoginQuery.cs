using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.Auth.Login
{
    public class LoginQuery : IRequest<Result<LoginResponse>>
    {
        #region Public Constructors

        public LoginQuery(string email, string username, string password)
        {
            Email = email;
            Username = username;
            Password = password;
        }

        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        #endregion Public Constructors
    }
}