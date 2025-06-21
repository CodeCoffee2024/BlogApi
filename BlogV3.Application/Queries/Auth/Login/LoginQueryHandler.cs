using BlogV3.Application.Interfaces.Common;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using MediatR;

namespace BlogV3.Application.Queries.Auth.Login
{
    public class LoginQueryHandler(
        IUserRepository _repository,
        IJwtTokenGenerator _jwtTokenGenerator,
        IPasswordHasherService _passwordHasherService
    ) : IRequestHandler<LoginQuery, Result<LoginResponse>>
    {
        #region Public Methods

        public async Task<Result<LoginResponse>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.EmailUsernameExists(request.Email!, request.Username!);
            if (user == null)
            {
                Result.Failure(Error.Notfound);
            }
            if (!_passwordHasherService.VerifyPassword(user!.Password, request.Password!))
            {
                Result.Failure(Error.Notfound);
            }
            var token = _jwtTokenGenerator.GenerateToken(user!);
            return Result.Success(token);
        }

        #endregion Public Methods
    }
}