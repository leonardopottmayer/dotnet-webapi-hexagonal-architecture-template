using Autofac;
using HexagonalArchitecture.Adapter.Data.Mapper;
using HexagonalArchitecture.Domain.Repositories;

namespace HexagonalArchitecture.Adapter.Data
{
    public class AdapterDataDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(this.ThisAssembly)
                .AsClosedTypesOf(typeof(IRepository<>))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            RegisterMappings.Register();
        }
    }
}
