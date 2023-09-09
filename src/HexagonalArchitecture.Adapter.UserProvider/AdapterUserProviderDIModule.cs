using Autofac;
using HexagonalArchitecture.Domain.Adapters.UserProvider;

namespace HexagonalArchitecture.Adapter.UserProvider
{
    public class AdapterUserProviderDIModule : Module
    {
        public AdapterUserProviderDIModule() { }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserReference>().As<IUserReference>().InstancePerLifetimeScope();
        }
    }
}
