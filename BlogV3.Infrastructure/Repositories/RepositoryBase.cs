using BlogV3.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogV3.Infrastructure.Repositories
{
    public abstract class RepositoryBase<TEntity> where TEntity : class
    {
        #region Fields

        protected readonly AppDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        #endregion Fields

        #region Protected Constructors

        protected RepositoryBase(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        #endregion Protected Constructors

        #region Public Methods

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public virtual async Task<bool> ExistsAsync(Guid id)
        {
            // Assumes all entities have a property named "Id" of type Guid
            return await _dbSet.AnyAsync(e =>
                EF.Property<Guid>(e, "Id") == id);
        }

        #endregion Public Methods
    }
}