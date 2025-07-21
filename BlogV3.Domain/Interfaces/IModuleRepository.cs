using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Entities;

namespace BlogV3.Domain.Interfaces
{
    public interface IModuleRepository
    {
        #region Public Methods

        Task<bool> ExistsAsync(Guid id);

        Task<bool> ExistsByNameAsync(string name);

        Task<Module?> GetByIdAsync(Guid id);

        Task AddAsync(Module post);

        void Update(Module post);

        void Remove(Module tag);

        Task<PageResult<Module>> GetPaginatedPostsAsync(int page, int pageSize, string? search, string orderBy);

        Task<List<Module>> GetByModuleNames(IEnumerable<string> names);

        #endregion Public Methods
    }
}