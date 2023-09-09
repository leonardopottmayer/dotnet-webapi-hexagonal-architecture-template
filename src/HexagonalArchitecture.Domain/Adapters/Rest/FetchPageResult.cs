namespace HexagonalArchitecture.Domain.Adapters.Rest
{
    public class FetchPageResult<TResult>
    {
        public IEnumerable<TResult> Entities { get; set; }
        public long EntitiesCount { get; set; }
    }
}
