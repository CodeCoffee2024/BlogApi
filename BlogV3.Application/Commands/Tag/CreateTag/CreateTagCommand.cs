using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Commands.Tag.CreateTag
{
    public sealed record CreateTagCommand(
        Guid PostId,
        string Name) : IRequest<Result>;
}