using BlogV3.Application.Commands.Permission.CreatePermission;
using BlogV3.Domain.Interfaces;
using FluentValidation;

namespace BlogV3.Application.Validators.Permission
{
    public class CreatePermissionValidator : AbstractValidator<CreatePermissionCommand>
    {
        #region Public Constructors

        public CreatePermissionValidator(IPermissionRepository repository)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Permission name is required.")
                .MaximumLength(100);
            RuleFor(x => x.ModuleId)
                .NotEmpty().WithMessage("Module is required.");
        }

        #endregion Public Constructors
    }
}