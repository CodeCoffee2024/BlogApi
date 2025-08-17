using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.User.GetUserList
{
    public class GetUserListQuery : PagedQuery, IRequest<Result<PageResult<UserDto>>>
    {
        #region Public Constructors

        public GetUserListQuery(
            string? search = null,
            string? orderBy = "Email",
            int pageNumber = 1,
            int pageSize = 1,
            string? status = "activ",
            ICollection<RoleDto>? roles = null
        )
        {
            Search = search;
            OrderBy = orderBy;
            PageNumber = pageNumber;
            PageSize = pageSize;
            Status = status;
            Roles = roles;
        }

        public string? Status { get; set; }
        public ICollection<RoleDto>? Roles { get; set; }

        #endregion Public Constructors
    }
}