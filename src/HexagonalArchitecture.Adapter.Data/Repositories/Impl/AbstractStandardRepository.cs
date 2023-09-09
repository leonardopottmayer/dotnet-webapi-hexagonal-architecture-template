using Dommel;
using HexagonalArchitecture.Domain.Adapters.Data;
using HexagonalArchitecture.Domain.Repositories;

namespace HexagonalArchitecture.Adapter.Data.Repositories.Impl
{
    public class AbstractStandardRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private IDBConnection _dBConnection { get; set; }

        public AbstractStandardRepository(IDBConnection dBConnection)
        {
            _dBConnection = dBConnection;
        }

        public virtual async Task<long> CountAsync(CancellationToken cancellationToken = default)
        {
            using (var conn = _dBConnection.GetConnection())
            {
                return (await conn.GetAllAsync<TEntity>()).Count();
            }
        }

        public virtual async Task<long> CreateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            using (var conn = _dBConnection.GetConnection())
            {
                return Convert.ToInt64(await conn.InsertAsync<TEntity>(entity));
            }
        }

        public virtual async Task<bool> DeleteByKeyAsync(object id, CancellationToken cancellationToken)
        {
            using (var conn = _dBConnection.GetConnection())
            {
                var entityToDelete = await conn.GetAsync<TEntity>(id);
                return await conn.DeleteAsync<TEntity>(entityToDelete);
            }
        }

        public virtual async Task<bool> DeleteByEntityAsync(TEntity entity, CancellationToken cancellationToken)
        {
            using (var conn = _dBConnection.GetConnection())
            {
                return await conn.DeleteAsync<TEntity>(entity);
            }
        }

        public virtual async Task<IEnumerable<TEntity>> FetchAsync(CancellationToken cancellationToken = default)
        {
            using (var conn = _dBConnection.GetConnection())
            {
                return await conn.GetAllAsync<TEntity>();
            }
        }

        public virtual async Task<TEntity> FetchIdAsync(object id, CancellationToken cancellationToken = default)
        {
            using (var conn = _dBConnection.GetConnection())
            {
                return await conn.GetAsync<TEntity>(id);
            }
        }

        public virtual async Task<(IEnumerable<TEntity> Entities, long EntitiesCount)> FetchPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default)
        {
            using (var conn = _dBConnection.GetConnection())
            {
                var entities = await conn.GetPagedAsync<TEntity>(pageIndex, pageSize);
                var totalEntities = await CountAsync(cancellationToken);

                return (entities, totalEntities);
            }
        }

        public virtual async Task<bool> UpdateByEntityAsync(TEntity entity, CancellationToken cancellationToken)
        {
            using (var conn = _dBConnection.GetConnection())
            {
                return await conn.UpdateAsync<TEntity>(entity);
            }
        }
    }
}
