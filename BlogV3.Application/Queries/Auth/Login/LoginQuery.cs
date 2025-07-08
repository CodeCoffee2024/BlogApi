using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.Auth.Login
{
    public class LoginQuery : IRequest<Result>
    {
        #region Public Constructors

        public LoginQuery(string usernameEmail, string password)
        {
            UsernameEmail = usernameEmail;
            Password = password;
        }

        public string? UsernameEmail { get; set; }
        public string? Password { get; set; }

        #endregion Public Constructors
    }
}