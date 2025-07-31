namespace BlogV3.Application.Dtos
{
    public record AuditDto
    {
        #region Properties

        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public object? CreatedByUser { get; set; }
        public object? UpdatedByUser { get; set; }

        #endregion Properties
    }
}