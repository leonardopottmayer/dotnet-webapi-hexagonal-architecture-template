namespace HexagonalArchitecture.Domain.Repositories
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> FetchIdAsync(object id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> FetchAsync(CancellationToken cancellationToken = default);
        Task<(IEnumerable<TEntity> Entities, long EntitiesCount)> FetchPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default);
        Task<long> CountAsync(CancellationToken cancellationToken = default);
        Task<long> CreateAsync(TEntity entity, CancellationToken cancellationToken);
        Task<bool> UpdateByEntityAsync(TEntity entity, CancellationToken cancellationToken);
        Task<bool> DeleteByKeyAsync(object id, CancellationToken cancellationToken);
        Task<bool> DeleteByEntityAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
