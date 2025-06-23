using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Commands.User.UpdateUser
{
    public sealed record UpdateUserCommand(
        Guid UserId,
        Guid Id,
        string UserName,
        string Email,
        string Password,
        string FirstName,
        string LastName,
        string MiddleName) : IRequest<Result>;
}