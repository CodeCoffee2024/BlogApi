using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.Dashboard.GetCategoryMasterList
{
    public class GetCategoryMasterListQuery : IRequest<Result<IEnumerable<CategoryDto>>>
    {
    }
}