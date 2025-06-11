namespace BlogV3.Application.Dtos
{
    public class TagDto
    {
        #region Properties

        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public string Name { get; set; } = string.Empty;

        #endregion Properties
    }
}