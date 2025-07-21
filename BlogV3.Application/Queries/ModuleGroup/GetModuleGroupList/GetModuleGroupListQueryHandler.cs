using BlogV3.Application.Dtos;
using BlogV3.Application.Interfaces.Services;
using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.ModuleGroup.GetModuleGroupList
{
    public class GetModuleGroupListQueryHandler(
        IModuleGroupService _moduleGroupService
    ) : IRequestHandler<GetModuleGroupListQuery, Result<IEnumerable<ModuleGroupDto>>>
    {
        #region Public Methods

        public async Task<Result<IEnumerable<ModuleGroupDto>>> Handle(GetModuleGroupListQuery request, CancellationToken cancellationToken)
        {
            var result = _moduleGroupService.GetAllModuleGroups();

            return Result.Success(result);
        }

        #endregion Public Methods
    }
}