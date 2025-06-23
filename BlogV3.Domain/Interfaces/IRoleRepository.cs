using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Entities;

namespace BlogV3.Domain.Interfaces
{
    public interface IRoleRepository
    {
        #region Public Methods

        Task<bool> ExistsAsync(Guid id);

        Task<bool> ExistsByNameAsync(string name);

        Task<Role?> GetByIdAsync(Guid id);

        Task AddAsync(Role post);

        void Update(Role post);

        void Remove(Role tag);

        Task<PageResult<Role>> GetPaginatedRolesAsync(int page, int pageSize, string? search, string orderBy);

        #endregion Public Methods
    }
}