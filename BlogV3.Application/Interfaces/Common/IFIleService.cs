using Microsoft.AspNetCore.Http;

namespace BlogV3.Application.Interfaces.Common
{
    public interface IFileService
    {
        #region Public Methods

        Task<string> UploadImage(IFormFile file);

        #endregion Public Methods
    }
}