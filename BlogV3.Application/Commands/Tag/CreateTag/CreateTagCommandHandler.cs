using BlogV3.Application.Dtos;
using BlogV3.Application.Interfaces.Common;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace BlogV3.Application.Commands.Tag.CreateTag
{
    internal sealed class CreateTagCommandHandler(
        ITagRepository _repository,
        IValidator<CreateTagCommand> _validator,
        IUnitOfWork _unitOfWork
    ) : IRequestHandler<CreateTagCommand, Result>
    {
        #region Public Methods

        public async Task<Result> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return Result.Failure<List<TagDto>>(Error.Validation, validationResult.ToErrorList());
            }
            var entity = BlogV3.Domain.Entities.Tag.Create(request.PostId, request.Name);
            await _repository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success(entity);
        }

        #endregion Public Methods
    }
}