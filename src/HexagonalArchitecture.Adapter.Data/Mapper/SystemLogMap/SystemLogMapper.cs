using Dapper.FluentMap.Dommel.Mapping;
using HexagonalArchitecture.Domain.Entities;

namespace HexagonalArchitecture.Adapter.Data.Mapper.SystemLogMap
{
    public class SystemLogMapper : DommelEntityMap<SystemLog>
    {
        public SystemLogMapper()
        {
            ToTable("system_log");

            Map(i => i.Id).ToColumn("id").IsKey();
            Map(i => i.Message).ToColumn("message");
            Map(i => i.Type).ToColumn("type");
            Map(i => i.UserId).ToColumn("user_id");
            Map(i => i.Date).ToColumn("date");
            Map(i => i.StackTrace).ToColumn("stack_trace");
        }
    }
}
