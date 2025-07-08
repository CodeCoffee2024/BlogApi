using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Application.Interfaces.Common;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace BlogV3.Application.Commands.Module.UpdateModule
{
    internal sealed class UpdateModuleCommandHandler(
        IModuleRepository _repository,
        IMapper _mappper,
        IValidator<UpdateModuleCommand> _validator,
        IUnitOfWork _unitOfWork
    ) : IRequestHandler<UpdateModuleCommand, Result>
    {
        #region Public Methods

        public async Task<Result> Handle(UpdateModuleCommand request, CancellationToken cancellationToken)
        {
            var exists = await _repository.ExistsAsync(request.Id);
            if (!exists)
            {
                return Result.Failure(Error.Notfound("Category"));
            }
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return Result.Failure<List<ModuleDto>>(Error.Validation, validationResult.ToErrorList());
            }

            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity!.Name == request.Name && entity.Id != request.Id)
            {
                return Result.Failure(Error.DifferentEntity);
            }
            entity!.Update(
                request.Name,
                request.UserId,
                DateTime.Now
            );
            _repository.Update(entity);

            await _unitOfWork.SaveChangesAsync();
            return Result.Success(_mappper.Map<ModuleDto>(entity));
        }

        #endregion Public Methods
    }
}