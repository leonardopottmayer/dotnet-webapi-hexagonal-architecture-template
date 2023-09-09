using Dapper.FluentMap.Dommel.Mapping;
using HexagonalArchitecture.Domain.Entities;

namespace HexagonalArchitecture.Adapter.Data.Mapper.UserMap
{
    public class UserMapper : DommelEntityMap<User>
    {
        public UserMapper()
        {
            ToTable("user");

            Map(i => i.Id).ToColumn("id").IsKey();
            Map(i => i.Name).ToColumn("name");
            Map(i => i.Username).ToColumn("username");
            Map(i => i.Password).ToColumn("password");
            Map(i => i.Email).ToColumn("email");
            Map(i => i.PasswordSalt).ToColumn("password_salt");
        }
    }
}
