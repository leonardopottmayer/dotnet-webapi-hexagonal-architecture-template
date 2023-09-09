namespace HexagonalArchitecture.Domain.Adapters.Rest
{
    public class ErrorCodes
    {
        public static Dictionary<int, string> ErrorCodeMessages = new Dictionary<int, string>()
        {
            { 0, "Internal server error." },
            { 400, "Invalid data." },
            { 401, "Unauthorized." },
            { 404, "Not found." },
            { 500, "Internal server error." }
        };

        public static string GetErrorMessage(int errorCode)
        {
            if (ErrorCodeMessages.ContainsKey(errorCode))
            {
                return ErrorCodeMessages[errorCode];
            }
            else
            {
                return ErrorCodeMessages[0];
            }
        }
    }
}
