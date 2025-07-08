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
    ) : IRequestHandler<LoginQuery, Result>
    {
        #region Public Methods

        public async Task<Result> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.EmailUsernameExists(request.UsernameEmail!);
            if (user == null)
            {
                return Result.Failure(Error.Notfound("User"));
            }
            if (!_passwordHasherService.VerifyPassword(user!.Password, request.Password!))
            {
                return Result.Failure(Error.Invalid("User", "Invalid password"));
            }
            var token = _jwtTokenGenerator.GenerateToken(user!);
            return Result.Success(token);
        }

        #endregion Public Methods
    }
}