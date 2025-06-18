using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Commands.Category.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<Result>
    {
        #region Properties

        public DeleteCategoryCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        #endregion Properties
    }
}