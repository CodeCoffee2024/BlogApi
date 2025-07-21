using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Commands.Module.UpdateModule
{
    public sealed record UpdateModuleCommand(
        Guid UserId,
        Guid Id,
        string Name,
        string Link) : IRequest<Result>;
}