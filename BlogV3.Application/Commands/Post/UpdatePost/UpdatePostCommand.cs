using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Commands.Post.UpdatePost
{
    public sealed record UpdatePostCommand(
        Guid UserId,
        Guid Id,
        string Title,
        string Description,
        Guid CategoryId,
        ICollection<TagDto> Tags) : IRequest<Result>;
}