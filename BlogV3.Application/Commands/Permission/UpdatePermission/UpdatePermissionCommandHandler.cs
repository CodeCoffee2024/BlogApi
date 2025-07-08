using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Application.Interfaces.Common;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace BlogV3.Application.Commands.Permission.UpdatePermission
{
    internal sealed class UpdatePermissionCommandHandler(
        IPermissionRepository _repository,
        IModuleRepository _moduleRepository,
        IMapper _mappper,
        IValidator<UpdatePermissionCommand> _validator,
        IUnitOfWork _unitOfWork
    ) : IRequestHandler<UpdatePermissionCommand, Result>
    {
        #region Public Methods

        public async Task<Result> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
        {
            var exists = await _repository.ExistsAsync(request.Id);
            if (!exists)
            {
                return Result.Failure(Error.Notfound("Permission"));
            }
            var validationResult = await _validator.ValidateAsync(request);
            var moduleId = await _moduleRepository.GetByIdAsync(request.ModuleId);
            if (moduleId == null)
            {
                validationResult.Errors.Add(new ValidationFailure("Module", "Module not found"));
            }
            else
            {
                var permissionExists = await _repository.GetByNameAndModuleIdAsync(request.Name, moduleId!.Id!.Value);
                if (permissionExists != null && permissionExists.Id != request.Id)
                {
                    return Result.Failure(Error.DuplicateEntity);
                }
            }

            if (!validationResult.IsValid)
            {
                return Result.Failure<List<PermissionDto>>(Error.Validation, validationResult.ToErrorList());
            }

            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity!.Name == request.Name && entity.Id != request.Id)
            {
                return Result.Failure(Error.DifferentEntity);
            }
            entity!.Update(request.Name);
            _repository.Update(entity);

            await _unitOfWork.SaveChangesAsync();
            return Result.Success(_mappper.Map<PermissionDto>(entity));
        }

        #endregion Public Methods
    }
}