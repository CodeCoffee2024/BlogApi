using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Entities;
using BlogV3.Domain.Interfaces;
using BlogV3.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogV3.Infrastructure.Repositories
{
    public class ModuleRepository : RepositoryBase<Module>, IModuleRepository
    {
        #region Public Constructors

        public ModuleRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<PageResult<Module>> GetPaginatedPostsAsync(int page, int pageSize, string? search, string orderBy)
        {
            return await GetPaginatedAsync(page, pageSize, search, new[] { "Name" }, orderBy);
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Set<Module>().AnyAsync(it => it.Name == name);
        }

        public async Task<List<Module>> GetByModuleNames(IEnumerable<string> names)
        {
            return await _context.Modules
                .Where(m => names.Contains(m.Name) && m.IsSystemGenerated)
                .ToListAsync();
        }

        #endregion Public Constructors
    }
}