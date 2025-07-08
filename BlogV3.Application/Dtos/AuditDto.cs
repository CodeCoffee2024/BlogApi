namespace BlogV3.Application.Dtos
{
    public class AuditDto
    {
        #region Properties

        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public UserDto? CreatedBy { get; private set; }

        #endregion Properties
    }
}