namespace HexagonalArchitecture.Domain.Adapters.Rest
{
    public interface ISuccessApiResponse<T> : IApiResponse
    {
        T? Result { get; set; }
    }
}
