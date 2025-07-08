using System.Linq.Expressions;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Entities;

namespace BlogV3.Domain.Interfaces
{
    public interface IUserRepository
    {
        #region Public Methods

        Task<IEnumerable<User>> GetAllAsync();

        Task<bool> ExistsAsync(Guid id);

        Task<bool> HasPermission(Guid id, string moduleName, string permissionName);

        Task<bool> UsernameExists(string username);

        Task<bool> EmailExists(string email);

        Task<User?> GetByIdAsync(Guid id);

        Task<User?> EmailUsernameExists(string usernameEmail);

        Task<User?> GetByEmailAsync(string email);

        Task<User?> GetByUsernameAsync(string username);

        void Remove(User tag);

        Task AddAsync(User tag);

        Task<PageResult<User>> GetPaginatedUsersAsync(int page, int pageSize, string? search, string orderBy, Expression<Func<User, bool>>? statusFilter);

        #endregion Public Methods
    }
}