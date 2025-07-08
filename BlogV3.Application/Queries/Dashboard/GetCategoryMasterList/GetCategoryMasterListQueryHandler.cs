using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using MediatR;

namespace BlogV3.Application.Queries.Dashboard.GetCategoryMasterList
{
    public class GetCategoryMasterListQueryHandler(
        ICategoryRepository _repository,
        IMapper _mapper
    ) : IRequestHandler<GetCategoryMasterListQuery, Result<IEnumerable<CategoryDto>>>
    {
        #region Public Methods

        public async Task<Result<IEnumerable<CategoryDto>>> Handle(GetCategoryMasterListQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync();

            return Result.Success(_mapper.Map<IEnumerable<CategoryDto>>(result.ToList()));
        }

        #endregion Public Methods
    }
}