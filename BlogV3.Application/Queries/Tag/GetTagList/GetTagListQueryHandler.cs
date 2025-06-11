using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Domain.Interfaces;
using MediatR;

namespace BlogV3.Application.Queries.Tag.GetTagList
{
    public class GetTagListQueryHandler(
        ITagRepository _repository,
        IMapper _mapper
    ) : IRequestHandler<GetTagListQuery, GetTagListResponse>
    {
        #region Public Methods

        public async Task<GetTagListResponse> Handle(GetTagListQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync();
            var mappedResult = _mapper.Map<List<TagDto>>(result);
            return new GetTagListResponse(mappedResult);
        }

        #endregion Public Methods
    }
}