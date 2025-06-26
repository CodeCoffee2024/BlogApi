using BlogV3.Application.Abstractions;
using BlogV3.Application.Commands.Post.CreatePost;
using BlogV3.Application.Commands.Post.UpdatePost;
using BlogV3.Application.Dtos;
using BlogV3.Application.Queries.Post.GetPostList;
using Microsoft.AspNetCore.Http;

namespace BlogV3.Application.Requests
{
    public class PostRequest : PageRequest
    {
        #region Properties

        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public ICollection<TagDto> Tags { get; set; } = new List<TagDto>();
        public string Title { get; set; } = string.Empty;
        public IFormFile Img { get; set; } = default!;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = "activ";

        #endregion Properties

        #region Public Methods

        public CreatePostCommand SetAddCommand(Guid UserId) =>
            new(UserId, Title, Description, CategoryId, Tags, Img);

        public UpdatePostCommand SetUpdateCommand(Guid UserId, Guid Id) =>
            new(UserId, Id, Title, Description, CategoryId, Tags, Img);

        public GetPostListQuery ToQuery() => new(Search, OrderBy, PageNumber, PageSize, Status);

        #endregion Public Methods
    }
}