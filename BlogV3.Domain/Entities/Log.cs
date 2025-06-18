namespace BlogV3.Domain.Entities
{
    public class Log
    {
        #region Properties

        public int Id { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string Level { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string? Exception { get; set; }
        public string? Source { get; set; }

        #endregion Properties
    }
}