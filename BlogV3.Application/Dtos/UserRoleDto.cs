namespace BlogV3.Application.Dtos
{
    public record UserRoleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}