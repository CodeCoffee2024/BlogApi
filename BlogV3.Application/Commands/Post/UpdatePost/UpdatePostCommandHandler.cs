using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Application.Interfaces.Common;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace BlogV3.Application.Commands.Post.UpdatePost
{
    internal sealed class UpdatePostCommandHandler(
        IPostRepository _repository,
        ITagRepository _tagRepository,
        IMapper _mappper,
        IFileService _fileService,
        IValidator<UpdatePostCommand> _validator,
        IUnitOfWork _unitOfWork
    ) : IRequestHandler<UpdatePostCommand, Result>
    {
        #region Public Methods

        public async Task<Result> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var exists = await _repository.ExistsAsync(request.Id);
            if (!exists)
            {
                return Result.Failure(Error.Notfound("Post"));
            }
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return Result.Failure<List<PostDto>>(Error.Validation, validationResult.ToErrorList());
            }

            string imgPath = await _fileService.UploadImage(request.Img);
            var entity = await _repository.GetByIdAsync(request.Id);
            entity!.Update(
                request.CategoryId,
                request.Title,
                request.Description,
                DateTime.Now,
                request.UserId,
                imgPath

            );
            _repository.Update(entity);

            var existingTags = await _tagRepository.GetByPostIdAsync(entity.Id!.Value);

            var incomingTagNames = request.Tags.Select(t => t.Trim().ToLower()).ToList();
            var existingTagNames = existingTags!.Select(t => t.Name.Trim().ToLower()).ToList();

            var tagsToAdd = incomingTagNames.Except(existingTagNames);
            var tagsToRemove = existingTags!.Where(t => !incomingTagNames.Contains(t.Name.Trim().ToLower())).ToList();
            foreach (var tagName in tagsToAdd)
            {
                var tagEntity = BlogV3.Domain.Entities.Tag.Create(entity.Id!.Value, tagName);
                await _tagRepository.AddAsync(tagEntity);
            }
            foreach (var tag in tagsToRemove)
            {
                _tagRepository.Remove(tag);
            }
            await _unitOfWork.SaveChangesAsync();
            return Result.Success(_mappper.Map<PostDto>(entity));
        }

        #endregion Public Methods
    }
}