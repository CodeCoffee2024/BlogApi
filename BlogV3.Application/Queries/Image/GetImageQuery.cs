using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.Image
{
    public class GetImageQuery : IRequest<Result<FileStreamDto>>
    {
        #region Properties

        public GetImageQuery(string imageName)
        {
            ImageName = imageName;
        }

        public string ImageName { get; set; }

        #endregion Properties
    }
}