using Dapper.FluentMap.Dommel.Mapping;
using HexagonalArchitecture.Domain.Entities;

namespace HexagonalArchitecture.Adapter.Data.Mapper.SystemParameterMap
{
    public class SystemParameterMapper : DommelEntityMap<SystemParameter>
    {
        public SystemParameterMapper()
        {
            ToTable("system_parameter");

            Map(i => i.Id).ToColumn("id").IsKey();
            Map(i => i.Code).ToColumn("code");
            Map(i => i.Name).ToColumn("name");
            Map(i => i.Description).ToColumn("description");
            Map(i => i.Type).ToColumn("type");
            Map(i => i.Value).ToColumn("value");
            Map(i => i.IsEditable).ToColumn("is_editable");
        }
    }
}
