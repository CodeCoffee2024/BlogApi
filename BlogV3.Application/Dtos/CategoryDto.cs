namespace BlogV3.Application.Dtos
{
    public class CategoryDto
    {
        #region Properties

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        #endregion Properties
    }
}