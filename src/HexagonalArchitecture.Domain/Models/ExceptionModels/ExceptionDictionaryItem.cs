namespace HexagonalArchitecture.Domain.Models.ExceptionModels
{
    public class ExceptionDictionaryItem
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }

        public ExceptionDictionaryItem(string message, int statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }
    }
}
