using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.Category.GetCategoryStatuses
{
    public class GetCategoryStatusesQuery : IRequest<Result<IEnumerable<StatusDto>>>
    {
    }
}