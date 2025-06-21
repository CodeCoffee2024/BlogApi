using BlogV3.Domain.Entities;
using BlogV3.Domain.Interfaces;
using BlogV3.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogV3.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        #region Public Constructors

        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User?> GetByEmailAsync(string email) =>
            await _context.Set<User>().FirstOrDefaultAsync(user => user.Email == email);

        public async Task<User?> EmailUsernameExists(string email, string username) =>
            await _context.Set<User>().FirstOrDefaultAsync(user => user.Email == email || user.UserName == username);

        public async Task<bool> HasPermission(Guid userId, string moduleName, string permissionName) =>
            await _context.Set<User>()
            .Where(u => u.Id == userId)
            .SelectMany(u => u.UserRoles)
            .SelectMany(ur => ur.Role.RolePermissions)
            .AnyAsync(rp =>
                rp.Permission.Name == permissionName &&
                rp.Permission.Module.Name == moduleName);

        #endregion Public Constructors
    }
}