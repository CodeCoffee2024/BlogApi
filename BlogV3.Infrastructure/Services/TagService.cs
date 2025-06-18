using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Application.Interfaces.Services;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace BlogV3.Infrastructure.Services
{
    public class TagService(ITagRepository _repository, IMapper _mapper, ILogger<TagService> _logger) : ITagService
    {
        #region Public Methods

        public async Task<Result<List<TagDto>>> GetAllTagsAsync(string name = "", string status = "")
        {
            var result = await _repository.GetAllAsync();
            return Result.Success(_mapper.Map<List<TagDto>>(result));
        }

        public async Task Delete(Guid id)
        {
            _logger.LogInformation("Deleted Tag with Id " + id);
            var result = await _repository.GetByIdAsync(id);
            _repository.Remove(result!);
        }

        public async Task<Result<TagDto>> FindById(Guid id)
        {
            var result = await _repository.GetByIdAsync(id);
            return Result.Success(_mapper.Map<TagDto>(result));
        }

        #endregion Public Methods
    }
}