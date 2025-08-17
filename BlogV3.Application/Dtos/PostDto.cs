namespace BlogV3.Application.Dtos
{
    public record PostDto : AuditDto
    {
        #region Properties

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public CategoryFragment? Category { get; set; }
        public IEnumerable<TagDto>? Tags { get; set; }
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public string ImgPath { get; private set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        #endregion Properties
    }
}