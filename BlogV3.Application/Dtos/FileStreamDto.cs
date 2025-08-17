namespace BlogV3.Application.Dtos
{
    public record FileStreamDto
    {
        public string FileStream { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
    }
}