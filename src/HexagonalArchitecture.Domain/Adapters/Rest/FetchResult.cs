namespace HexagonalArchitecture.Domain.Adapters.Rest
{
    public class FetchResult<TResult>
    {
        public IEnumerable<TResult> Entities { get; set; }
    }
}
