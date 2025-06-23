namespace BlogV3.Application.Dtos
{
    public record class RoleDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public virtual ICollection<PermissionDto> Permissions { get; private set; } = new List<PermissionDto>();
    }
}