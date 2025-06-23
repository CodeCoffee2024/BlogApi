using BlogV3.Application.Commands.User.CreateUser;
using FluentValidation;

namespace BlogV3.Application.Validators.User
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        #region Public Constructors

        public CreateUserValidator()
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

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password length must be atleast 6 characters.");
        }

        #endregion Public Constructors
    }
}