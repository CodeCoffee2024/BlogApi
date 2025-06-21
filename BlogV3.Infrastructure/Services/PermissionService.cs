using BlogV3.Application.Interfaces.Services;
using BlogV3.Domain.Interfaces;

namespace BlogV3.Infrastructure.Services
{
    public class PermissionService(IUserRepository _userRepository) : IPermissionService
    {
        #region Public Methods

        public async Task<bool> HasPermissionAsync(Guid userId, string moduleName, string permissionName)
        {
            return await _userRepository.HasPermission(userId, moduleName, permissionName);
        }

        #endregion Public Methods
    }
}