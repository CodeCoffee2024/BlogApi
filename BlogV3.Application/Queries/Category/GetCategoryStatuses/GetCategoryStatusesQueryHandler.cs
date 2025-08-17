using BlogV3.Application.Dtos;
using BlogV3.Application.Extensions;
using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.Category.GetCategoryStatuses
{
    public class GetCategoryStatusesQueryHandler() : IRequestHandler<GetCategoryStatusesQuery, Result<IEnumerable<StatusDto>>>
    {
        #region Public Methods

        public async Task<Result<IEnumerable<StatusDto>>> Handle(GetCategoryStatusesQuery request, CancellationToken cancellationToken)
        {
            var mappedResult = BlogV3.Domain.Entities.Category.Statuses.Select(s => new StatusDto
            {
                Name = s.GetDescription()!,
                Description = s.ToString()
            });
            return Result.Success(mappedResult);
        }

        #endregion Public Methods
    }
}