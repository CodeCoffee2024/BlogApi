using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Commands.Role.CreateRole
{
    public sealed record CreateRoleCommand(string Name, Guid UserId, IEnumerable<Guid> Permissions) : IRequest<Result>;
}