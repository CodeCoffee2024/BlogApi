using BlogV3.Application.Commands.User.UpdateUser;
using FluentValidation;

namespace BlogV3.Application.Validators.User
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        #region Public Constructors

        public UpdateUserValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name is required.")
                .MaximumLength(100);

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is required.")
                .MaximumLength(100);

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required.");
        }

        #endregion Public Constructors
    }
}