using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.Role.GetRoleStatuses
{
    public class GetRoleStatusesQuery : IRequest<Result<IEnumerable<StatusDto>>>
    {
    }
}