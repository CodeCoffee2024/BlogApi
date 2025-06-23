namespace BlogV3.Application.Dtos
{
    public class UserDto
    {
        #region Properties

        public string UserName { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Status { get; private set; } = string.Empty;
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public string MiddleName { get; private set; } = string.Empty;
        public virtual ICollection<RoleDto> UserRoles { get; private set; } = new List<RoleDto>();

        #endregion Properties
    }
}