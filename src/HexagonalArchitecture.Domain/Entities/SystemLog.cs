namespace HexagonalArchitecture.Domain.Entities
{
    public class SystemLog
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public long UserId { get; set; }
        public DateTimeOffset Date { get; set; }
        public string? StackTrace { get; set; }

        public SystemLog() { }
        public SystemLog(long id, string message, string type, long userId, DateTimeOffset date, string? stackTrace)
        {
            Id = id;
            Message = message;
            Type = type;
            UserId = userId;
            Date = date;
            StackTrace = stackTrace;
        }
    }
}
