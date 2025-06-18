using BlogV3.Domain.Entities;
using BlogV3.Domain.Interfaces;
using BlogV3.Infrastructure.Data;

namespace BlogV3.Infrastructure.Repositories
{
    public class LogRepository : RepositoryBase<Log>, ILogRepository
    {
        #region Public Constructors

        public LogRepository(AppDbContext context) : base(context)
        {
        }

        #endregion Public Constructors
    }
}