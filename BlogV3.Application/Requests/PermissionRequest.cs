using BlogV3.Application.Abstractions;
using BlogV3.Application.Commands.Permission.CreatePermission;
using BlogV3.Application.Commands.Permission.UpdatePermission;
using BlogV3.Application.Queries.Permission.GetPermissionList;

namespace BlogV3.Application.Requests
{
    public class PermissionRequest : PageRequest
    {
        #region Properties

        public Guid Id { get; set; }
        public Guid ModuleId { get; set; }
        public string Name { get; set; } = string.Empty;

        #endregion Properties

        #region Public Methods

        public CreatePermissionCommand SetAddCommand() =>
            new(Name, ModuleId);

        public UpdatePermissionCommand SetUpdateCommand(Guid Id) =>
            new(Id, ModuleId, Name);

        public GetPermissionListQuery ToQuery() => new(Search, OrderBy, PageNumber, PageSize);

        #endregion Public Methods
    }
}