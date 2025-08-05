using BlogV3.Application.Dtos;
using BlogV3.Common.Helpers;
using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.User.GetUserStatuses
{
    public class GetUserStatusesQueryHandler() : IRequestHandler<GetUserStatusesQuery, Result<IEnumerable<StatusDto>>>
    {
        #region Public Methods

        public async Task<Result<IEnumerable<StatusDto>>> Handle(GetUserStatusesQuery request, CancellationToken cancellationToken)
        {
            var mappedResult = BlogV3.Domain.Entities.User.Statuses.Select(s => new StatusDto
            {
                Name = s.GetDescription()!,
                Description = s.ToString()
            });
            return Result.Success(mappedResult);
        }

        #endregion Public Methods
    }
}