using BlogV3.Domain.Entities;

namespace BlogV3.Domain.Interfaces
{
    public interface IUserRepository
    {
        #region Public Methods

        Task<IEnumerable<User>> GetAllAsync();

        Task<bool> ExistsAsync(Guid id);

        Task<bool> HasPermission(Guid id, string moduleName, string permissionName);

        Task<User?> GetByIdAsync(Guid id);

        Task<User?> EmailUsernameExists(string email, string username);

        Task<User?> GetByEmailAsync(string email);

        void Remove(User tag);

        Task AddAsync(User tag);

        #endregion Public Methods
    }
}