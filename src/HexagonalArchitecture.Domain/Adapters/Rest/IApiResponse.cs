namespace HexagonalArchitecture.Domain.Adapters.Rest
{
    public interface IApiResponse
    {
        bool Success { get; }
        int StatusCode { get; set; }
    }
}
