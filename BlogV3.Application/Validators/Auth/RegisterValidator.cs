using BlogV3.Application.Commands.Auth.Register;
using FluentValidation;

namespace BlogV3.Application.Validators.Auth
{
    public class RegisterValidator : AbstractValidator<RegisterCommand>
    {
        #region Public Constructors

        public RegisterValidator()
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