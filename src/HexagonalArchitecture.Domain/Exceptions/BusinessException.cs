using HexagonalArchitecture.Domain.Models.ExceptionModels;

namespace HexagonalArchitecture.Domain.Exceptions
{
    public class BusinessException : Exception
    {
        public string Message { get; private set; }
        public int StatusCode { get; private set; }

        private Dictionary<long, ExceptionDictionaryItem> ErrorMessages { get; } = new Dictionary<long, ExceptionDictionaryItem>()
        {
            { 1, new ExceptionDictionaryItem("Internal server error.", 500) },
            { 2, new ExceptionDictionaryItem("Unknown error.", 500) },
            { 3, new ExceptionDictionaryItem("Invalid password.", 401) },
            { 4, new ExceptionDictionaryItem("Failed to authenticate.", 500) },
            { 5, new ExceptionDictionaryItem("Failed to create.", 500) },
            { 6, new ExceptionDictionaryItem("Failed to delete.", 500) },
            { 7, new ExceptionDictionaryItem("Failed to update.", 500) },
            { 8, new ExceptionDictionaryItem("Failed to fetch.", 500) },
        };

        public BusinessException(long messageCode)
        {
            if (ErrorMessages.ContainsKey(messageCode))
            {
                Message = ErrorMessages[messageCode].Message;
                StatusCode = ErrorMessages[messageCode].StatusCode;
            }
            else
            {
                Message = ErrorMessages[1].Message;
                StatusCode = ErrorMessages[1].StatusCode;
            }
        }
    }
}
