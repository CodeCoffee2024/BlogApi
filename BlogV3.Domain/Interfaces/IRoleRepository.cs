using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Entities;
using System.Linq.Expressions;

namespace BlogV3.Domain.Interfaces
{
    public interface IRoleRepository
    {
        #region Public Methods

        Task<bool> ExistsAsync(Guid id);

        Task<bool> ExistsByNameAsync(string name);

        Task<Role?> GetByIdAsync(Guid id);

        Task<IEnumerable<Role>> GetUserRolesAsync();

        Task<IEnumerable<Role>> GetUserRolesByUserIdAsync(Guid userId);

        Task<Role?> GetByNameAsync(string name);

        Task AddAsync(Role post);

        void Update(Role post);

        void Remove(Role tag);

        Task<PageResult<Role>> GetPaginatedRolesAsync(int page, int pageSize, string? search, string orderBy, Expression<Func<Role, bool>>? statusFilter);

        #endregion Public Methods
    }
}