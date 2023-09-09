using Autofac;
using HexagonalArchitecture.Domain.Adapters.SystemInfoProvider;

namespace HexagonalArchitecture.Adapter.SystemInfoProvider
{
    public class AdapterSystemInfoProviderDIModule : Module
    {
        public AdapterSystemInfoProviderDIModule() { }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SystemInfoReference>().As<ISystemInfoReference>().SingleInstance();
        }
    }
}
