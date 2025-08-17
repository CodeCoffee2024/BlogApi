using BlogV3.Application.Abstractions;
using BlogV3.Application.Commands.Post.CreatePost;
using BlogV3.Application.Commands.Post.UpdatePost;
using BlogV3.Application.Extensions;
using BlogV3.Application.Queries.Post.GetPostList;
using BlogV3.Application.Queries.Post.GetPostListByCategory;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace BlogV3.Application.Requests
{
    public class PostRequest : PageRequest
    {
        #region Properties

        public Guid? Id { get; set; }
        public Guid? CategoryId { get; set; }
        public string Tags { get; set; } = string.Empty;
        public string? Title { get; set; } = string.Empty;
        public IFormFile? Img { get; set; } = default!;
        public string? Description { get; set; } = string.Empty;
        public string? Status { get; set; } = Common.Entities.Status.All.GetDescription();

        private ICollection<string>? TagConverted()
        {
            return JsonSerializer.Deserialize<string[]>(Tags);
        }

        #endregion Properties

        #region Public Methods

        public CreatePostCommand SetAddCommand(Guid UserId) =>
            new(UserId, Title!, Description!, CategoryId!.Value, TagConverted()!, Img!);

        public UpdatePostCommand SetUpdateCommand(Guid UserId, Guid Id) =>
            new(UserId, Id, Title!, Description!, CategoryId!.Value, TagConverted()!, Img!);

        public GetPostListQuery ToQuery() => new(Search, OrderBy, PageNumber, PageSize, Status);

        public GetPostListByCategoryQuery ToDashboardQuery(string Category) => new(Search, Category, PageNumber, PageSize, Status);

        #endregion Public Methods
    }
}