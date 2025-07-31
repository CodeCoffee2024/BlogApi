using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Entities;
using BlogV3.Domain.Interfaces;
using BlogV3.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlogV3.Infrastructure.Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        #region Public Constructors

        public RoleRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<PageResult<Role>> GetPaginatedRolesAsync(int page, int pageSize, string? search, string orderBy, Expression<Func<Role, bool>>? statusFilter = null)
        {
            return await GetPaginatedAsync(page, pageSize, search, new[] { "Name", "RolePermissions.Permission.Name" }, orderBy, statusFilter);
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Set<Role>().AnyAsync(it => it.Name == name);
        }

        public async Task<Role?> GetByNameAsync(string name)
        {
            return await _context.Set<Role>().FirstOrDefaultAsync(it => it.Name == name);
        }

        public virtual async Task<Role?> GetByIdAndPermissionsAsync(Guid id)
        {
            return await _context.Set<Role>()
                .Include(role => role.RolePermissions)
                    .ThenInclude(rp => rp.Permission)
                .FirstOrDefaultAsync(role => role.Id!.Value == id);
        }

        #endregion Public Constructors
    }
}