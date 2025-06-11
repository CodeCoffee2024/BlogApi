namespace BlogV3.Domain.Interfaces
{
    public interface IPostRepository
    {
        #region Public Methods

        Task<bool> ExistsAsync(Guid id);

        #endregion Public Methods
    }
}