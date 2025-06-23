namespace BlogV3.Application.Dtos
{
    public record class RoleDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } = string.Empty;
    }
}