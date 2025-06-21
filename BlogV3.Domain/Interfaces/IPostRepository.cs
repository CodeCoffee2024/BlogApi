using System.Linq.Expressions;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Entities;

namespace BlogV3.Domain.Interfaces
{
    public interface IPostRepository
    {
        #region Public Methods

        Task<bool> ExistsAsync(Guid id);

        Task<Post?> GetByIdAsync(Guid id);

        Task AddAsync(Post post);

        void Update(Post post);

        void Remove(Post tag);

        Task<PageResult<Post>> GetPaginatedPostsAsync(int page, int pageSize, string? search, string orderBy, Expression<Func<Post, bool>>? statusFilter);

        #endregion Public Methods
    }
}