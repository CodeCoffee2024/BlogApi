using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.Post.GetPostStatuses
{
    public class GetPostStatusesQuery : IRequest<Result<IEnumerable<StatusDto>>>
    {
    }
}