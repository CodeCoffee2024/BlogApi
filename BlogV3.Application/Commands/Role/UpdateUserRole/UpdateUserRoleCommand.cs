using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Commands.Role.UpdateUserRole
{
    public sealed record UpdateUserRoleCommand(
        Guid UserId,
        IEnumerable<Guid> RoleIds) : IRequest<Result>;
}