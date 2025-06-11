using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Application.Interfaces.Services;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;

namespace BlogV3.Infrastructure.Services
{
    public class TagService : ITagService
    {
        #region Fields

        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;

        #endregion Fields

        #region Public Constructors

        public TagService(ITagRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<Result<List<TagDto>>> GetAllTagsAsync(string name = "", string status = "")
        {
            var result = await _repository.GetAllAsync();
            return Result.Success(_mapper.Map<List<TagDto>>(result));
        }

        public async Task Delete(Guid id)
        {
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