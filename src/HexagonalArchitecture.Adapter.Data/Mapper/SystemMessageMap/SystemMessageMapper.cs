using Dapper.FluentMap.Dommel.Mapping;
using HexagonalArchitecture.Domain.Entities;

namespace HexagonalArchitecture.Adapter.Data.Mapper.SystemMessageMap
{
    public class SystemMessageMapper : DommelEntityMap<SystemMessage>
    {
        public SystemMessageMapper()
        {
            ToTable("system_message");

            Map(i => i.Id).ToColumn("id").IsKey();
            Map(i => i.Code).ToColumn("code");
            Map(i => i.Name).ToColumn("name");
            Map(i => i.Description).ToColumn("description");
            Map(i => i.Value).ToColumn("value");
            Map(i => i.IsEditable).ToColumn("is_editable");
        }
    }
}
