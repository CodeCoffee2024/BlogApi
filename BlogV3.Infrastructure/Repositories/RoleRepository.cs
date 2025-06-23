using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Entities;
using BlogV3.Domain.Interfaces;
using BlogV3.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogV3.Infrastructure.Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        #region Public Constructors

        public RoleRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<PageResult<Role>> GetPaginatedRolesAsync(int page, int pageSize, string? search, string orderBy)
        {
            return await GetPaginatedAsync(page, pageSize, search, new[] { "Name", "RolePermissions.Permission.Name" }, orderBy);
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Set<Role>().AnyAsync(it => it.Name == name);
        }

        #endregion Public Constructors
    }
}