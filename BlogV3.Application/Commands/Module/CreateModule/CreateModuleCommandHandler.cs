using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Application.Interfaces.Common;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace BlogV3.Application.Commands.Module.CreateModule
{
    internal sealed class CreateModuleCommandHandler(
        IModuleRepository _repository,
        IMapper _mappper,
        IValidator<CreateModuleCommand> _validator,
        IUnitOfWork _unitOfWork
    ) : IRequestHandler<CreateModuleCommand, Result>
    {
        #region Public Methods

        public async Task<Result> Handle(CreateModuleCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return Result.Failure<List<ModuleDto>>(Error.Validation, validationResult.ToErrorList());
            }

            var entity = BlogV3.Domain.Entities.Module.Create(request.Name, request.UserId);
            await _repository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success(_mappper.Map<ModuleDto>(entity));
        }

        #endregion Public Methods
    }
}