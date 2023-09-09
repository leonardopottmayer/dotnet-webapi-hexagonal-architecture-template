using Dapper.FluentMap.Dommel.Mapping;
using HexagonalArchitecture.Domain.Entities;

namespace HexagonalArchitecture.Adapter.Data.Mapper
{
    public abstract class AuditableEntityClassMapper<TEntity> : DommelEntityMap<TEntity> where TEntity : AuditableEntity
    {
        public AuditableEntityClassMapper()
        {
            Map(i => i.CreatedBy).ToColumn("created_by");
            Map(i => i.CreatedAt).ToColumn("created_at");
            Map(i => i.UpdatedBy).ToColumn("updated_by");
            Map(i => i.UpdatedAt).ToColumn("updated_at");
        }
    }
}
