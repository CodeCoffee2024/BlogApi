using BlogV3.Application.Interfaces.Common;
using BlogV3.Infrastructure.Data;

namespace BlogV3.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields

        private readonly AppDbContext _context;

        #endregion Fields

        #region Public Constructors

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        #endregion Public Methods
    }
}