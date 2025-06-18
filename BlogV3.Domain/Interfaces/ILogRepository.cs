using BlogV3.Domain.Entities;

namespace BlogV3.Domain.Interfaces
{
    public interface ILogRepository
    {
        #region Public Methods

        Task AddAsync(Log log);

        #endregion Public Methods
    }
}