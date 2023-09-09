using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using HexagonalArchitecture.Adapter.Data.Mapper.ProductMap;
using HexagonalArchitecture.Adapter.Data.Mapper.SystemLogMap;
using HexagonalArchitecture.Adapter.Data.Mapper.SystemMessageMap;
using HexagonalArchitecture.Adapter.Data.Mapper.SystemParameterMap;
using HexagonalArchitecture.Adapter.Data.Mapper.UserMap;

namespace HexagonalArchitecture.Adapter.Data.Mapper
{
    public static class RegisterMappings
    {
        public static void Register()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new UserMapper());
                config.AddMap(new SystemParameterMapper());
                config.AddMap(new SystemMessageMapper());
                config.AddMap(new SystemLogMapper());
                config.AddMap(new ProductMapper());
                config.ForDommel();
            });
        }
    }
}
