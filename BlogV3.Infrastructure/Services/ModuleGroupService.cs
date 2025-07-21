using BlogV3.Application.Dtos;
using BlogV3.Application.Interfaces.Services;
using BlogV3.Common.Constants;
using BlogV3.Domain.Interfaces;

namespace BlogV3.Infrastructure.Services
{
    public class ModuleGroupService(IModuleRepository moduleRepository) : IModuleGroupService
    {
        #region Public Methods

        public IEnumerable<ModuleGroupDto> GetAllModuleGroups()
        {
            return ModuleGroups.GROUPS.Select(group => new ModuleGroupDto
            {
                Key = group.Key,
                Modules = moduleRepository.GetByModuleNames(group.Value)
                .Result.Select(m => new ModuleDto
                {
                    Id = m.Id!.Value,
                    Name = m.Name,
                    Link = m.Link
                }).ToList()
            });
        }

        #endregion Public Methods
    }
}