using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Commands.Module.CreateModule
{
    public sealed record CreateModuleCommand(Guid UserId, string Name) : IRequest<Result>;
}