using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Commands.Post.CreatePost
{
    public sealed record CreatePostCommand(
        Guid UserId,
        string Title,
        string Description,
        Guid CategoryId,
        ICollection<TagDto> Tags) : IRequest<Result>;
}