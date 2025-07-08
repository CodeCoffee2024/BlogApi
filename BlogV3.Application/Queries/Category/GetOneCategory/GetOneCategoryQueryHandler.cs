using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using MediatR;

namespace BlogV3.Application.Queries.Category.GetOneCategory
{
    public class GetOneCategoryQueryHandler(ICategoryRepository _repository, IMapper _mapper) : IRequestHandler<GetOneCategoryQuery, Result<CategoryDto>>
    {
        #region Public Methods

        public async Task<Result<CategoryDto>> Handle(GetOneCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.Id);
            if (result == null)
            {
                return Result.Failure<CategoryDto>(Error.Notfound("Category"));
            }
            var mappedResult = _mapper.Map<CategoryDto>(result);
            return Result.Success(mappedResult);
        }

        #endregion Public Methods
    }
}