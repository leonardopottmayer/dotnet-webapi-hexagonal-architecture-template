using HexagonalArchitecture.Domain.Adapters.Rest;

namespace HexagonalArchitecture.Adapter.Rest
{
    public class DefaultApiResponse<TResult> : ISuccessApiResponse<TResult>, IErrorApiResponse
    {
        public TResult? Result { get; set; }
        public bool Success { get; private set; }
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }

        protected DefaultApiResponse(bool success, int statusCode, TResult result, string errorMessage = null)
        {
            Success = success;
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
            Result = result;
        }

        protected DefaultApiResponse(bool success, int statusCode, string errorMessage = null)
        {
            Success = success;
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }

        public static DefaultApiResponse<TResult> Ok(int statusCode, TResult result)
        {
            return new DefaultApiResponse<TResult>(true, statusCode, result);
        }

        public static DefaultApiResponse<TResult> Error(int statusCode, string errorMessage = null)
        {
            return new DefaultApiResponse<TResult>(false, statusCode, errorMessage);
        }
    }
}
