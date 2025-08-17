using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.Auth.RefreshToken
{
    public class RefreshTokenQuery : IRequest<Result>
    {
        #region Properties

        public RefreshTokenQuery(string token)
        {
            Token = token;
        }

        public string Token { get; set; }

        #endregion Properties
    }
}