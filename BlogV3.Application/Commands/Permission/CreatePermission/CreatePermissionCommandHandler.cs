using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Application.Interfaces.Common;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace BlogV3.Application.Commands.Permission.CreatePermission
{
    internal sealed class CreatePermissionCommandHandler(
        IPermissionRepository _repository,
        IModuleRepository _moduleRepository,
        IMapper _mappper,
        IValidator<CreatePermissionCommand> _validator,
        IUnitOfWork _unitOfWork
    ) : IRequestHandler<CreatePermissionCommand, Result>
    {
        #region Public Methods

        public async Task<Result> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            var moduleId = await _moduleRepository.GetByIdAsync(request.ModuleId);
            if (moduleId == null)
            {
                validationResult.Errors.Add(new ValidationFailure("Module", "Module not found"));
            }
            else
            {
                var permissionExists = await _repository.ExistsByNameAndModuleIdAsync(request.Name, moduleId!.Id!.Value);
                if (permissionExists)
                {
                    return Result.Failure(Error.DuplicateEntity);
                }
            }
            if (!validationResult.IsValid)
            {
                return Result.Failure<List<PermissionDto>>(Error.Validation, validationResult.ToErrorList());
            }

            var entity = BlogV3.Domain.Entities.Permission.Create(request.Name, request.ModuleId);
            await _repository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success(_mappper.Map<PermissionDto>(entity));
        }

        #endregion Public Methods
    }
}