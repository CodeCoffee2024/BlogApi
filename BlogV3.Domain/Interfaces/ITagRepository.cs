using BlogV3.Domain.Entities;

namespace BlogV3.Domain.Interfaces
{
    public interface ITagRepository
    {
        #region Public Methods

        Task<IEnumerable<Tag>> GetAllAsync();

        Task<bool> ExistsAsync(Guid id);

        Task<Tag?> GetByIdAsync(Guid id);

        void Remove(Tag tag);

        Task AddAsync(Tag tag);

        #endregion Public Methods
    }
}