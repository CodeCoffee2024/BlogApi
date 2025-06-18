using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.Tag.GetOneTag
{
    public class GetOneTagQuery : IRequest<Result<TagDto>>
    {
        #region Properties

        public GetOneTagQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        #endregion Properties
    }
}