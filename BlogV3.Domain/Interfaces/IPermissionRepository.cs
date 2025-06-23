using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Entities;

namespace BlogV3.Domain.Interfaces
{
    public interface IPermissionRepository
    {
        #region Public Methods

        Task<bool> ExistsAsync(Guid id);

        Task<bool> ExistsByNameAndModuleIdAsync(string name, Guid moduleId);

        Task<Permission> GetByNameAndModuleIdAsync(string name, Guid moduleId);

        Task<Permission?> GetByIdAsync(Guid id);

        Task AddAsync(Permission post);

        void Update(Permission post);

        void Remove(Permission tag);

        Task<PageResult<Permission>> GetPaginatedPostsAsync(int page, int pageSize, string? search, string orderBy);

        #endregion Public Methods
    }
}