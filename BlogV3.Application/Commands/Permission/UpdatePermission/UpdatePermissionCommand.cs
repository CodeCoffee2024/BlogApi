using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Commands.Permission.UpdatePermission
{
    public sealed record UpdatePermissionCommand(
        Guid Id,
        Guid ModuleId,
        string Name) : IRequest<Result>;
}