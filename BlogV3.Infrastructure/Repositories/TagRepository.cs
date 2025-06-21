using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Entities;
using BlogV3.Domain.Interfaces;
using BlogV3.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogV3.Infrastructure.Repositories
{
    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        #region Public Constructors

        public TagRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<PageResult<Tag>> GetPaginatedTagsAsync(int page, int pageSize, string? search, string orderBy)
        {
            return await GetPaginatedAsync(page, pageSize, search, new[] { "Name" }, orderBy);
        }

        public async Task<IEnumerable<Tag>?> GetByPostIdAsync(Guid id)
        {
            return await _context.Set<Tag>().Where(it => it.PostId == id).ToListAsync();
        }

        #endregion Public Constructors
    }
}