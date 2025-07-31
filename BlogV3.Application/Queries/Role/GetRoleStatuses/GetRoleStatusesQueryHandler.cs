using BlogV3.Application.Dtos;
using BlogV3.Common.Helpers;
using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.Role.GetRoleStatuses
{
    public class GetRoleStatusesQueryHandler() : IRequestHandler<GetRoleStatusesQuery, Result<IEnumerable<StatusDto>>>
    {
        #region Public Methods

        public async Task<Result<IEnumerable<StatusDto>>> Handle(GetRoleStatusesQuery request, CancellationToken cancellationToken)
        {
            var mappedResult = BlogV3.Domain.Entities.Role.Statuses.Select(s => new StatusDto
            {
                Name = s.GetDescription()!,
                Description = s.ToString()
            });
            return Result.Success(mappedResult);
        }

        #endregion Public Methods
    }
}