using BlogV3.Application.Dtos;
using BlogV3.Application.Interfaces.Common;
using BlogV3.Common.Entities;
using BlogV3.Common.Helpers;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace BlogV3.Application.Commands.Category.CreateCategory
{
    internal sealed class CreateCategoryCommandHandler(
        ICategoryRepository _repository,
        IValidator<CreateCategoryCommand> _validator,
        IUnitOfWork _unitOfWork
    ) : IRequestHandler<CreateCategoryCommand, Result>
    {
        #region Public Methods

        public async Task<Result> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return Result.Failure<List<CategoryDto>>(Error.Validation, validationResult.ToErrorList());
            }

            var entity = BlogV3.Domain.Entities.Category.Create(request.Name, Status.Active.GetDescription()!, DateTime.Now, request.UserId);
            await _repository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success(entity);
        }

        #endregion Public Methods
    }
}