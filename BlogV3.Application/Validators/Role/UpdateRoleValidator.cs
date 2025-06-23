using BlogV3.Application.Commands.Role.UpdateRole;
using FluentValidation;

namespace BlogV3.Application.Validators.Role
{
    public class UpdateRoleValidator : AbstractValidator<UpdateRoleCommand>
    {
        #region Public Constructors

        public UpdateRoleValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100);
        }

        #endregion Public Constructors
    }
}