namespace HexagonalArchitecture.Domain.Models.SystemLogModels
{
    public class CreateSystemLogDto
    {
        public string Message { get; set; }
        public string Type { get; set; }
        public long UserId { get; set; }
        public DateTimeOffset Date { get; set; }
        public string? StackTrace { get; set; }

        public CreateSystemLogDto() { }
        public CreateSystemLogDto(string message, string type, long userId, DateTimeOffset date, string? stackTrace)
        {
            Message = message;
            Type = type;
            UserId = userId;
            Date = date;
            StackTrace = stackTrace;
        }
    }
}
