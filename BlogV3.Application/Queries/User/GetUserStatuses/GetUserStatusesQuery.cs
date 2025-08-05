using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.User.GetUserStatuses
{
    public class GetUserStatusesQuery : IRequest<Result<IEnumerable<StatusDto>>>
    {
    }
}