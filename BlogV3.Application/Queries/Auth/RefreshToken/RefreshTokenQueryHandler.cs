using BlogV3.Application.Interfaces.Common;
using BlogV3.Application.Queries.Auth.RefreshToken;
using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.Auth.Refresh
{
    public class RefreshTokenQueryHandler(IJwtTokenGenerator _tokenGenerator) : IRequest<RefreshTokenQuery>
    {
        #region Public Methods

        public async Task<Result> Handle(RefreshTokenQuery request, CancellationToken cancellationToken)
        {
            var response = _tokenGenerator.RefreshToken(request.Token);
            return Result.Success(response);
        }

        #endregion Public Methods
    }
}