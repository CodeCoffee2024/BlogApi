using BlogV3.Application.Commands.Category.CreateCategory;
using FluentValidation;

namespace BlogV3.Application.Validators.Category
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
    {
        #region Public Constructors

        public CreateCategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Tag name is required.")
                .MaximumLength(100);
            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required.")
                .MaximumLength(5);
        }

        #endregion Public Constructors
    }
}