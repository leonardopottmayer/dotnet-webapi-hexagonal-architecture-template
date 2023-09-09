namespace HexagonalArchitecture.Domain.Adapters.Rest
{
    public interface IErrorApiResponse : IApiResponse
    {
        string ErrorMessage { get; set; }
    }
}
