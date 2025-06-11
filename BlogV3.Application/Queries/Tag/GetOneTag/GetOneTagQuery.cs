using BlogV3.Application.Dtos;
using MediatR;

namespace BlogV3.Application.Queries.Tag.GetOneTag
{
    public class GetOneTagQuery : IRequest<TagDto>
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