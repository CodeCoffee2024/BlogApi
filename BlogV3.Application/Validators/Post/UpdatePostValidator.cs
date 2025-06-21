using BlogV3.Application.Commands.Post.UpdatePost;
using BlogV3.Domain.Interfaces;
using FluentValidation;

namespace BlogV3.Application.Validators.Post
{
    public class UpdatePostValidator : AbstractValidator<UpdatePostCommand>
    {
        #region Public Constructors

        public UpdatePostValidator(ICategoryRepository categoryRepository)
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100);

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500);

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Category Id is required.")
                .MustAsync(async (postId, cancellation) =>
                    await categoryRepository.ExistsAsync(postId))
                .WithMessage("Category does not exist.");
        }

        #endregion Public Constructors
    }
}