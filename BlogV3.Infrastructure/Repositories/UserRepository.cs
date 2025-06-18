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

        #endregion Public Constructors
    }
}