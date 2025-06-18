using System.Linq.Expressions;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Entities;
using BlogV3.Domain.Interfaces;
using BlogV3.Infrastructure.Data;

namespace BlogV3.Infrastructure.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        #region Public Constructors

        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<PageResult<Category>> GetPaginatedCategoriesAsync(int page, int pageSize, string? search, string orderBy, Expression<Func<Category, bool>>? statusFilter = null)
        {
            return await GetPaginatedAsync(page, pageSize, search, new[] { "Name", "Status" }, orderBy, statusFilter);
        }

        #endregion Public Constructors
    }
}