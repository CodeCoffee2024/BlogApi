using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.Category.GetOneCategory
{
    public class GetOneCategoryQuery : IRequest<Result<CategoryDto>>
    {
        #region Properties

        public GetOneCategoryQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        #endregion Properties
    }
}