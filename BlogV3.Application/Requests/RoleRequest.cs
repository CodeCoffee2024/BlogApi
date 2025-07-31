using BlogV3.Application.Abstractions;
using BlogV3.Application.Commands.Role.CreateRole;
using BlogV3.Application.Commands.Role.UpdateRole;
using BlogV3.Application.Queries.Role.GetRoleList;

namespace BlogV3.Application.Requests
{
    public class RoleRequest : PageRequest
    {
        #region Properties

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Status { get; set; } = string.Empty;
        public List<Guid> Permissions { get; set; } = new List<Guid>();

        #endregion Properties

        #region Public Methods

        public CreateRoleCommand SetAddCommand(Guid UserId) =>
            new(Name, UserId, Permissions);

        public UpdateRoleCommand SetUpdateCommand(Guid Id, Guid UserId) =>
            new(UserId, Id, Name, Permissions);

        public GetRoleListQuery ToQuery() => new(Search, OrderBy, PageNumber, PageSize, Status);

        #endregion Public Methods
    }
}