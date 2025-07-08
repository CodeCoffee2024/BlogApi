using System.Linq.Expressions;
using BlogV3.Domain.Abstractions;
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

        public async Task<User?> GetByUsernameAsync(string username) =>
            await _context.Set<User>().FirstOrDefaultAsync(user => user.UserName == username);

        public async Task<User?> EmailUsernameExists(string usernameEmail) =>
            await _context.Set<User>().FirstOrDefaultAsync(user => user.Email == usernameEmail || user.UserName == usernameEmail);

        public async Task<bool> EmailExists(string email) =>
            await _context.Set<User>().AnyAsync(user => user.Email == email);

        public async Task<bool> UsernameExists(string username) =>
            await _context.Set<User>().AnyAsync(user => user.UserName == username);

        public async Task<bool> HasPermission(Guid userId, string moduleName, string permissionName) =>
            await _context.Set<User>()
            .Where(u => u.Id == userId)
            .SelectMany(u => u.UserRoles)
            .SelectMany(ur => ur.Role.RolePermissions)
            .AnyAsync(rp =>
                rp.Permission.Name == permissionName &&
                rp.Permission.Module.Name == moduleName);

        public async Task<PageResult<User>> GetPaginatedUsersAsync(int page, int pageSize, string? search, string orderBy, Expression<Func<User, bool>>? statusFilter = null)
        {
            return await GetPaginatedAsync(page, pageSize, search, new[] { "Email", "Status", "UserName", "FirstName", "MiddleName", "LastName", "UserRoles.Role.Name" }, orderBy, statusFilter);
        }

        #endregion Public Constructors
    }
}