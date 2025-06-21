using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Entities;

namespace BlogV3.Domain.Interfaces
{
    public interface ITagRepository
    {
        #region Public Methods

        Task<IEnumerable<Tag>> GetAllAsync();

        Task<bool> ExistsAsync(Guid id);

        Task<Tag?> GetByIdAsync(Guid id);

        Task<IEnumerable<Tag>?> GetByPostIdAsync(Guid id);

        Task<PageResult<Tag>> GetPaginatedTagsAsync(int page, int pageSize, string? search, string orderBy);

        void Remove(Tag tag);

        Task AddAsync(Tag tag);

        #endregion Public Methods
    }
}