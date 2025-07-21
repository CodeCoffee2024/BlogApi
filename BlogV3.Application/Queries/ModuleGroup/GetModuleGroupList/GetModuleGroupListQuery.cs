using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.ModuleGroup.GetModuleGroupList
{
    public class GetModuleGroupListQuery() : IRequest<Result<IEnumerable<ModuleGroupDto>>>
    {
    }
}