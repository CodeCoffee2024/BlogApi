using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Commands.Role.UpdateRole
{
    public sealed record UpdateRoleCommand(
        Guid UserId,
        Guid Id,
        string Name,
        IEnumerable<Guid> Permissions) : IRequest<Result>;
}