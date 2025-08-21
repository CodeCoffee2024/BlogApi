using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Entities;
using System.Linq.Expressions;

namespace BlogV3.Domain.Interfaces
{
    public interface IPostRepository
    {
        #region Public Methods

        Task<bool> ExistsAsync(Guid id);

        Task<Post?> GetByIdAsync(Guid id);

        Task<IEnumerable<Post>> GetTop4();

        Task<IEnumerable<Post>> GetHighlights();

        Task<IEnumerable<Post>> GetTop2();

        Task<IEnumerable<Post>> GetLatest();

        Task<int> GetActivePostsCount();

        Task<int> GetNewPostsForWeekCount();

        Task<IEnumerable<Post>> GetPostsByDateRangeAsync(

        DateTime dateFrom,
        DateTime dateTo,
        CancellationToken cancellationToken);

        Task AddAsync(Post post);

        void Update(Post post);

        void Remove(Post tag);

        Task<PageResult<Post>> GetPaginatedPostsAsync(int page, int pageSize, string? search, string orderBy, Expression<Func<Post, bool>>? statusFilter);

        #endregion Public Methods
    }
}