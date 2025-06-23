using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Commands.User.CreateUser
{
    public sealed record CreateUserCommand(
        Guid UserId,
        string UserName,
        string Email,
        string Password,
        string FirstName,
        string LastName,
        string MiddleName) : IRequest<Result>;
}