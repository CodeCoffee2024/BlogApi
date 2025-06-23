using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Commands.Permission.CreatePermission
{
    public sealed record CreatePermissionCommand(string Name, Guid ModuleId) : IRequest<Result>;
}