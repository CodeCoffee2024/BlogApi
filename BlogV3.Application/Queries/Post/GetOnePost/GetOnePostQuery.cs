using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.Post.GetOnePost
{
    public class GetOnePostQuery : IRequest<Result<PostDto>>
    {
        #region Properties

        public GetOnePostQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        #endregion Properties
    }
}