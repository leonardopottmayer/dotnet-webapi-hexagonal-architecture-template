using HexagonalArchitecture.Domain.Adapters.Rest;
using HexagonalArchitecture.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace HexagonalArchitecture.Adapter.Rest.Middlewares
{
    public class ResponseWrapper
    {
        private readonly RequestDelegate _next;

        public ResponseWrapper(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";

            var currentBody = context.Response.Body;

            using (var memoryStream = new MemoryStream())
            {
                try
                {
                    context.Response.Body = memoryStream;

                    await _next(context);

                    if (context.Response.StatusCode != (int)HttpStatusCode.InternalServerError)
                    {
                        context.Response.Body = currentBody;
                        memoryStream.Seek(0, SeekOrigin.Begin);

                        var readToEnd = new StreamReader(memoryStream).ReadToEnd();

                        var objectResult = JsonSerializer.Deserialize<object>(readToEnd);
                        var result = DefaultApiResponse<object>.Ok(context.Response.StatusCode, objectResult);

                        await context.Response.WriteAsync(JsonSerializer.Serialize(result, typeof(object), new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        }));
                    }
                }
                catch (Exception ex)
                {
                    context.Response.Body = currentBody;
                    memoryStream.Seek(0, SeekOrigin.Begin);

                    var (status, message) = GetErrorResponse(ex, context);
                    context.Response.StatusCode = (int)status;
                    context.Response.ContentType = "application/problem+json";

                    //await _loggingUtils.Log(LogType.Error, ex.Message + "|$|" + message, ex.StackTrace);

                    await context.Response.WriteAsync(message);
                }
            }
        }

        private (HttpStatusCode code, string message) GetErrorResponse(Exception exception, HttpContext context)
        {
            HttpStatusCode code;
            string errorMessage = String.Empty;

            switch (exception)
            {
                case KeyNotFoundException or FileNotFoundException:
                    code = HttpStatusCode.NotFound;
                    errorMessage = ErrorCodes.GetErrorMessage((int)HttpStatusCode.NotFound);
                    break;

                case UnauthorizedAccessException:
                    code = HttpStatusCode.Unauthorized;
                    errorMessage = ErrorCodes.GetErrorMessage((int)HttpStatusCode.Unauthorized);
                    break;

                case ArgumentException or InvalidOperationException:
                    code = HttpStatusCode.BadRequest;
                    errorMessage = ErrorCodes.GetErrorMessage((int)HttpStatusCode.BadRequest);
                    break;

                case BusinessException:
                    code = (HttpStatusCode)(exception as BusinessException).StatusCode;
                    errorMessage = (exception as BusinessException).Message;
                    break;

                default:
                    code = HttpStatusCode.InternalServerError;
                    errorMessage = ErrorCodes.GetErrorMessage((int)HttpStatusCode.InternalServerError);
                    break;
            }

            return (code, JsonSerializer.Serialize(DefaultApiResponse<object>.Error((int)code, errorMessage), typeof(object), new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }));
        }
    }
}
