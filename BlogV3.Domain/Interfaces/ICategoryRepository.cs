using System.Linq.Expressions;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Entities;

namespace BlogV3.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        #region Public Methods

        Task<IEnumerable<Category>> GetAllAsync();

        Task<bool> ExistsAsync(Guid id);

        Task<Category?> GetByIdAsync(Guid id);

        Task<PageResult<Category>> GetPaginatedCategoriesAsync(int page, int pageSize, string? search, string orderBy, Expression<Func<Category, bool>>? statusFilter);

        void Remove(Category tag);

        Task AddAsync(Category tag);

        #endregion Public Methods
    }
}