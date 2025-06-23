using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Entities;
using BlogV3.Domain.Interfaces;
using BlogV3.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogV3.Infrastructure.Repositories
{
    public class PermissionRepository : RepositoryBase<Permission>, IPermissionRepository
    {
        #region Public Constructors

        public PermissionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<PageResult<Permission>> GetPaginatedPostsAsync(int page, int pageSize, string? search, string orderBy)
        {
            return await GetPaginatedAsync(page, pageSize, search, new[] { "Name", "Module.Name" }, orderBy);
        }

        public async Task<bool> ExistsByNameAndModuleIdAsync(string name, Guid moduleId)
        {
            return await _context.Set<Permission>().AnyAsync(it => it.Name == name && it.ModuleId == moduleId);
        }

        public async Task<Permission?> GetByNameAndModuleIdAsync(string name, Guid moduleId)
        {
            return await _context.Set<Permission>().FirstOrDefaultAsync(it => it.Name == name && it.ModuleId == moduleId);
        }

        #endregion Public Constructors
    }
}