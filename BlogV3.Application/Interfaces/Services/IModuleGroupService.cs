using BlogV3.Application.Dtos;

namespace BlogV3.Application.Interfaces.Services
{
    public interface IModuleGroupService
    {
        #region Public Methods

        IEnumerable<ModuleGroupDto> GetAllModuleGroups();

        #endregion Public Methods
    }
}