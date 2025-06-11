using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Domain.Interfaces;
using MediatR;

namespace BlogV3.Application.Queries.Tag.GetOneTag
{
    public class GetOneTagQueryHandler(ITagRepository _repository, IMapper _mapper) : IRequestHandler<GetOneTagQuery, TagDto>
    {
        #region Public Methods

        public async Task<TagDto> Handle(GetOneTagQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.Id);
            var mappedResult = _mapper.Map<TagDto>(result);
            return mappedResult;
        }

        #endregion Public Methods
    }
}