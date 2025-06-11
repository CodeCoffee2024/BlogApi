using BlogV3.Application.Commands.Tag.CreateTag;
using BlogV3.Domain.Interfaces;
using FluentValidation;

namespace BlogV3.Application.Validators.Tag
{
    public class CreateTagValidator : AbstractValidator<CreateTagCommand>
    {
        #region Public Constructors

        public CreateTagValidator(IPostRepository postRepository)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Tag name is required.")
                .MaximumLength(100);
            RuleFor(x => x.PostId)
                .NotEmpty().WithMessage("Post Id is required.")
                .MustAsync(async (postId, cancellation) =>
                    await postRepository.ExistsAsync(postId))
                .WithMessage("Post does not exist.");
        }

        #endregion Public Constructors
    }
}