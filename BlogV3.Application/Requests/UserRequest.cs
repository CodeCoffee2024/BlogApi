using BlogV3.Application.Abstractions;
using BlogV3.Application.Commands.Auth.Register;
using BlogV3.Application.Commands.User.CreateUser;
using BlogV3.Application.Commands.User.UpdateUser;
using BlogV3.Application.Dtos;
using BlogV3.Application.Queries.User.GetUserList;

namespace BlogV3.Application.Requests
{
    public class UserRequest : PageRequest
    {
        #region Properties

        public Guid Id { get; set; }
        public ICollection<RoleDto> Roles { get; set; } = new List<RoleDto>();
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Status { get; set; } = "activ";

        #endregion Properties

        #region Public Methods

        public CreateUserCommand SetAddCommand(Guid UserId) =>
            new(UserId, UserName, Email, Password, FirstName, LastName, MiddleName);

        public RegisterCommand SetRegisterCommand() =>
            new(UserName, Email, Password, FirstName, LastName, MiddleName);

        public UpdateUserCommand SetUpdateCommand(Guid Id, Guid UserId) =>
            new(UserId, Id, UserName, Email, Password, FirstName, LastName, MiddleName);

        public GetUserListQuery ToQuery() => new(Search, OrderBy, PageNumber, PageSize, Status, Roles);

        #endregion Public Methods
    }
}