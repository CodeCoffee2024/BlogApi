using System.Linq.Expressions;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Entities;
using BlogV3.Domain.Interfaces;
using BlogV3.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogV3.Infrastructure.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        #region Public Constructors

        public PostRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<PageResult<Post>> GetPaginatedPostsAsync(int page, int pageSize, string? search, string orderBy, Expression<Func<Post, bool>>? statusFilter = null)
        {
            return await GetPaginatedAsync(page, pageSize, search, new[] { "Status", "Title", "Description", "Category.Name", "Tags.Name" }, orderBy, statusFilter);
        }

        public async Task<IEnumerable<Post>> GetTop4()
        {
            return await _context.Set<Post>().OrderByDescending(it => it.CreatedOn).Take(4).ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetHighlights()
        {
            return await _context.Set<Post>().Take(1).ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetTop2()
        {
            return await _context.Set<Post>().OrderByDescending(it => it.CreatedOn).Take(2).ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetLatest()
        {
            return await _context.Set<Post>().OrderByDescending(it => it.CreatedOn).Take(3).ToListAsync();
        }

        #endregion Public Constructors
    }
}