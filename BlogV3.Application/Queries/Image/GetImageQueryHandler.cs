using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Hosting;

namespace BlogV3.Application.Queries.Image
{
    public class GetImageQueryHandler : IRequestHandler<GetImageQuery, Result<FileStreamDto>>
    {
        #region Fields

        private readonly IWebHostEnvironment _env;

        #endregion Fields

        #region Public Constructors

        public GetImageQueryHandler(IWebHostEnvironment env)
        {
            _env = env;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<Result<FileStreamDto>> Handle(GetImageQuery request, CancellationToken cancellationToken)
        {
            var imagePath = Path.Combine(_env.WebRootPath, "uploads", request.ImageName);

            if (!File.Exists(imagePath))
            {
                return Result.Failure<FileStreamDto>(Error.Notfound("Image"));
            }
            try
            {
                // Read the file into a byte array
                byte[] fileBytes;
                using (var fileStream = File.OpenRead(imagePath))
                {
                    using var memoryStream = new MemoryStream();
                    await fileStream.CopyToAsync(memoryStream, cancellationToken);
                    fileBytes = memoryStream.ToArray();
                }

                var contentType = GetContentType(request.ImageName);
                var base64String = Convert.ToBase64String(fileBytes);

                return Result.Success(new FileStreamDto
                {
                    FileStream = base64String,
                    ContentType = contentType,
                    FileName = request.ImageName,
                });
            }
            catch (Exception ex)
            {
                return Result.Failure<FileStreamDto>(Error.Notfound("Image"));
            }
        }

        #endregion Public Methods

        #region Private Methods

        private string GetContentType(string fileName)
        {
            var extension = Path.GetExtension(fileName).ToLowerInvariant();
            return extension switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".bmp" => "image/bmp",
                ".webp" => "image/webp",
                _ => "application/octet-stream"
            };
        }

        #endregion Private Methods
    }
}