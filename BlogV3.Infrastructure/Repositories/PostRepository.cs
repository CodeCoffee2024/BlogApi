using BlogV3.Application.Extensions;
using BlogV3.Common.Entities;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Entities;
using BlogV3.Domain.Interfaces;
using BlogV3.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public async Task<int> GetActivePostsCount()
        {
            return await _context.Set<Post>().Where(it => it.Status == Status.Active.GetDescription()).CountAsync();
        }

        public async Task<int> GetNewPostsForWeekCount()
        {
            var startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
            var endOfWeek = startOfWeek.AddDays(7);

            return await _context.Set<Post>()
                .Where(it => it.CreatedOn >= startOfWeek && it.CreatedOn < endOfWeek)
                .CountAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsByDateRangeAsync(
            DateTime dateFrom,
            DateTime dateTo,
            CancellationToken cancellationToken)
        {
            var from = new DateTime(dateFrom.Year, dateFrom.Month, 1, 0, 0, 0);

            var lastDay = DateTime.DaysInMonth(dateTo.Year, dateTo.Month);
            var to = new DateTime(dateTo.Year, dateTo.Month, lastDay, 23, 59, 59);

            return await _context.Set<Post>()
                .Where(u => u.CreatedOn >= from && u.CreatedOn <= to)
                .ToListAsync(cancellationToken);
        }

        #endregion Public Constructors
    }
}