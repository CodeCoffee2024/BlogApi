using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Commands.Auth.Register
{
    public sealed record RegisterCommand(
        string UserName,
        string Email,
        string Password,
        string FirstName,
        string LastName,
        string MiddleName) : IRequest<Result>;
}